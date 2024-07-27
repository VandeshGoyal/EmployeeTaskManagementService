using Microsoft.AspNetCore.Http;

namespace EmployeeTaskManagementService.DataAcessLayer.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly EmployeeTaskDbContext _dbContext;
        private const string folderStorage = "UploadedDocs";

        public DocumentRepository(EmployeeTaskDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public Task<(byte[], string)> DownloadDocument(string fileKey, int tasKId)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderStorage, fileKey);
            
            if (!File.Exists(filePath))
            {
                throw new ApplicationException("File not found");
            }

            var file = System.IO.File.ReadAllBytes(filePath);
            var ext = Path.GetExtension(filePath);

            return Task.FromResult((file, ext));
        }

        public async Task<string> UploadDocument(int tasKId, IFormFile file)
        {
            var rootDir = Directory.GetCurrentDirectory();
            var storagePath = Path.Combine(rootDir, folderStorage);

            if(!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }
            
            var fileNameKey = Guid.NewGuid().ToString() + file.FileName;

            using (var stream = new FileStream(Path.Combine(storagePath, fileNameKey), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _dbContext.Documents.Add(new Models.Document
            {
                FileKeyName= fileNameKey,
                TaskID= tasKId,
                CreatedTime = DateTime.UtcNow,
            });
            await _dbContext.SaveChangesAsync();

            return $"File with file key name: {fileNameKey} uploaded successfully";

        }

        public async Task<List<string>> GetAllDocumentsForTask(int taskId)
        {
           return _dbContext.Documents.Where(x => x.TaskID == taskId).Select(x => x.FileKeyName).ToList();
        }
    }
}
