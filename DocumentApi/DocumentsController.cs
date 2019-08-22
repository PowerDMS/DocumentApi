using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DocumentApi
{
    public class DocumentsController : ControllerBase
    {
        [HttpGet]
        [Route("uploadDocuments")]
        public Task<ActionResult<IEnumerable<DocumentDto>>> UploadDocuments(IEnumerable<DocumentDto> documents)
        {
            var documentRepository = new DocumentRepository();

            var currentDocuments = documentRepository.GetAllDocuments().Result;

            foreach (var document in documents)
            {
                var documentExists = false;

                foreach (var currentDocument in currentDocuments)
                {
                    if (currentDocument.Name == document.Name)
                    {
                        documentExists = true;
                    }
                }

                if (!documentExists)
                {
                    var createdDocument = documentRepository.UploadDocument(document).Result;
                    document.Id = createdDocument.Id;
                }
            }

            HttpContext.Response.StatusCode = 200;
            return Task.FromResult(new ActionResult<IEnumerable<DocumentDto>>(documents));
        }
    }
}