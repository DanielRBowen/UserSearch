using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using System;
using System.IO;
using UserSearch.Data;

namespace UserSearch.Controllers
{
    public class MediaController : Controller
    {
        private UserSearchContext UserSearchContext { get; }

        public MediaController(UserSearchContext userSearchContext)
        {
            UserSearchContext = userSearchContext ?? throw new ArgumentNullException(nameof(userSearchContext));
        }

        // GET: Media
        public IActionResult Index(int id)
        {
            var media = UserSearchContext.Media.Find(id);

            if (media == null)
            {
                return NotFound();
            }

            return File(media.Content, media.Type, media.FileName);
        }

        public IActionResult Thumbnail(int id)
        {
            var media = UserSearchContext.Media.Find(id);

            if (media == null)
            {
                return NotFound();
            }

            var outputStream = new MemoryStream();

            using (var inputStream = new MemoryStream(media.Content))
            {
                ResizeImage(inputStream, outputStream, 150);
            }

            outputStream.Position = 0;

            return File(outputStream, media.Type, media.FileName);
        }

        public IActionResult DetailSized(int id)
        {
            var media = UserSearchContext.Media.Find(id);

            if (media == null)
            {
                return NotFound();
            }

            var outputStream = new MemoryStream();

            using (var inputStream = new MemoryStream(media.Content))
            {
                ResizeImage(inputStream, outputStream, 400);
            }

            outputStream.Position = 0;

            return File(outputStream, media.Type, media.FileName);
        }

        public void ResizeImage(Stream input, Stream output, int size, int quality = 75)
        {
            using (var inputStream = new SKManagedStream(input))
            using (var original = SKBitmap.Decode(inputStream))
            {
                int width, height;

                if (original.Width > original.Height)
                {
                    width = size;
                    height = original.Height * size / original.Width;
                }
                else
                {
                    width = original.Width * size / original.Height;
                    height = size;
                }

                using (var resized = original.Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3))
                {
                    if (resized == null)
                    {
                        return;
                    }

                    using (var image = SKImage.FromBitmap(resized))
                    {
                        image.Encode(SKEncodedImageFormat.Jpeg, quality)
                            .SaveTo(output);
                    }
                }
            }
            return;
        }
    }
}
