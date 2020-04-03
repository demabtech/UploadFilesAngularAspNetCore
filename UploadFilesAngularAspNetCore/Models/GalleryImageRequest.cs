using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace UploadFilesAngularAspNetCore.Models
{
    public class GalleryImageRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
