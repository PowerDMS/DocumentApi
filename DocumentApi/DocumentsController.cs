using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DocumentApi
{
    public class DocumentsController : ControllerBase
    {
        [HttpGet]
        [Route("uploadDocuments")]
        public Task<ActionResult<IEnumerable<DocumentDto>>> UploadDocuments()
        {
            var documentRepository = new DocumentRepository();

            HttpContext.Response.StatusCode = 200;
        }
    }
}