using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using UploadFilesAngularAspNetCore.Models;

namespace UploadFilesAngularAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryImagesController : ControllerBase
    {
        private IWebHostEnvironment _env;

        public GalleryImagesController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<IActionResult> OnPostUploadAsync([FromForm]GalleryImageRequest model)
        {
            var response = new GalleryImageResponse(model.Name, model.Description);

            foreach (var formFile in model.Files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine(_env.WebRootPath, "images", formFile.FileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                        response.AddImage(formFile.FileName);
                    }
                }
            }

            return Ok(response);
        }
    }
}