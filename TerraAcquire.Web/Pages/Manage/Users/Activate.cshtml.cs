using CSMWebsite2023.Contracts;
using CSMWebsite2023.Contracts.SchoolPosts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.NetworkInformation;
using TerraAcquire.Web.Pages.Manage.User;

namespace TerraAcquire.Web.Pages.Manage.Users
{
    public class Create : PageModel
    {
        public readonly ISchoolPostService _schoolPostService;
        public readonly IWebHostEnvironment _env;
        public Create(ISchoolPostService schoolPostService, IWebHostEnvironment env)
        {
            _schoolPostService = schoolPostService;
            Dto = new CreateDto();
            _env = env;
        }

        public async Task OnPost()
        {
            if (ImageFile == null)
            {
                Error = "Please select an image file for your School Post";
                return;
            }

            var fileSize = ImageFile!.Length;
            if ((fileSize / 1048576.0) > 5)
            {
                Error = "The file you uploaded is too large. Filesize limit is 5mb.";
            }
            if (ImageFile!.ContentType != "image/jpeg" && ImageFile!.ContentType != "image/png")
            {
                Error = "Please upload a jpeg or png file for the attachment.";
            }

            var op = await _schoolPostService.Create(Dto);
            if (op != null && op.Status == OpStatus.Ok)
            {

                var dirPath = _env.WebRootPath + "/schoolposts/" + op.ReferenceId.ToString();
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                if (ImageFile!.Length > 0)
                {
                    byte[] bytes = await FileBytes(ImageFile!.OpenReadStream());
                    using (Image<Rgba32> image = SixLabors.ImageSharp.Image.Load<Rgba32>(bytes))
                    {
                        var galleryImage = image;
                        SaveFile(galleryImage, "gallery-image.png", dirPath, 200);

                        var articleImage = image;
                        SaveFile(articleImage, "article-image.png", dirPath, 800);

                        var thumbnail = image;
                        SaveFile(thumbnail, "thumbnail.png", dirPath, 30);
                    }
                }
            }
            else if (op != null && op.Status == OpStatus.Fail)
            {
                Error = op.Message;
            }
        }

        private void SaveFile(Image<Rgba32> image, string? filename = "", string? dirPath = "", int width = 800)
        {
            var filePath = dirPath + "/" + filename;
            if (image.Width > width)
            {
                var ratio = width / image.Width;
                image.Mutate(x => x.Resize(width, Convert.ToInt32(image.Height * ratio)));
            }

            image.Save(filePath);
        }

        public async Task<byte[]> FileBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        [BindProperty]
        public CreateDto? Dto { get; set; }

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        [BindProperty]
        public string? Error { get; set; }
    }
}