using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSearch.Data;
using UserSearch.Models;

namespace UserSearch.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserSearchContext _context;

        public UsersController(UserSearchContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .AsNoTracking()
                .Include(user0 => user0.UserMedia)
                .SingleOrDefaultAsync(user0 => user0.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Age,Phone")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .AsNoTracking()
                .Include(user0 => user0.UserMedia)
                .SingleOrDefaultAsync(user0 => user0.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Age,Phone")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .AsNoTracking()
                .Include(user0 => user0.UserMedia)
                .SingleOrDefaultAsync(user0 => user0.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users
                .Include(user0 => user0.UserMedia)
                .SingleOrDefaultAsync(user0 => user0.Id == id);

            var userMedia = _context.UserMedia
                .Where(userMedia0 => userMedia0.UserId == id);

            if (userMedia.Any())
            {
                var mediaIds = userMedia.Select(userMedia0 => userMedia0.MediaId);
                //var mediaList = new List<Media>();
                var media =
                    from media0 in _context.Media
                    from mediaId in mediaIds
                    where media0.Id == mediaId
                    select new Media
                    {
                        Id = mediaId,
                        Content = media0.Content,
                        FileName = media0.FileName,
                        Type = media0.Type
                    };

                //foreach (var mediaId in mediaIds)
                //{
                //    mediaList.Add(_context.Media.SingleOrDefault(media => media.Id == mediaId));
                //}

                _context.UserMedia.RemoveRange(userMedia);
                _context.Media.RemoveRange(media);
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Upload(int userId, ICollection<IFormFile> files)
        {
            foreach (var file in files)
            {
                var size = (int)file.Length;

                if (size <= 0)
                {
                    continue;
                }

                var content = ReadAllBytes(file);

                var media = new Media
                {
                    FileName = file.FileName,
                    Type = file.ContentType,
                    Content = content
                };

                _context.Media.Add(media);

                var userMedia = new UserMedia
                {
                    UserId = userId,
                    Media = media
                };

                _context.UserMedia.Add(userMedia);
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Added {files.Count} images to the item.";

            return RedirectToAction(nameof(Edit), routeValues: new { id = userId });
        }

        private static byte[] ReadAllBytes(IFormFile file)
        {
            var size = (int)file.Length;
            var buffer = new byte[size];

            using (var inputStream = file.OpenReadStream())
            {
                var bytesRemaining = size;
                var offset = 0;

                while (offset < size)
                {
                    var bytesRead = inputStream.Read(buffer, offset, bytesRemaining);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    offset += bytesRead;
                    bytesRemaining -= bytesRead;
                }
            }

            return buffer;
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMedia(int? mediaId, int? userId)
        {
            if (mediaId == null || userId == null)
            {
                return NotFound();
            }

            var userMedia = await _context.UserMedia
                .AsNoTracking()
                .SingleOrDefaultAsync(userMedia0 => userMedia0.MediaId == mediaId);

            var media = await _context.Media
                .AsNoTracking()
                .SingleOrDefaultAsync(media0 => media0.Id == mediaId);

            if (userMedia == null || media == null)
            {
                return NotFound();
            }

            _context.UserMedia.Remove(userMedia);
            _context.Media.Remove(media);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Deleted Media #{mediaId.ToString()}.";
            return RedirectToAction(nameof(Edit), new { id = userId.Value });
        }
    }
}
