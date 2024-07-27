using Microsoft.AspNetCore.Http;

namespace EmployeeTaskManagementService.DataAcessLayer.Repository
{
    public interface IDocumentRepository
    {
        public Task<string> UploadDocument(int tasKId, IFormFile file);
        public Task<(byte[], string)> DownloadDocument(string fileKey, int tasKId);

        public Task<List<string>> GetAllDocumentsForTask(int taskId);

    }
}
