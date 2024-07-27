using EmployeeTaskManagementService.DataAcessLayer.Repository;
using EmployeeTaskManagementService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentContrioller : ControllerBase
    {
        public readonly IDocumentRepository _documentRepository;
        public DocumentContrioller(IDocumentRepository documentRepository)
        {
            _documentRepository= documentRepository;
        }

        [HttpPost("{taskId}")]
        public async Task<ActionResult<string>> Upload(int taskId, IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                BadRequest("No file attached");
            }

            try
            {
                var resp = await _documentRepository.UploadDocument(taskId, file);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("/{fileKey}/{taskId}")]
        public async Task<IActionResult> Download(string fileKey, int taskId)
        {
            try
            {
                var resp = await _documentRepository.DownloadDocument(fileKey, taskId);
                return File(resp.Item1, resp.Item2);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
