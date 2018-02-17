using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UserSearch.Data;
using UserSearch.Models;
using UserSearch.ViewModels;

namespace UserSearch.Controllers
{
    public class HomeController : Controller
    {
        private UserSearchContext UserSearchContext { get; }

        public HomeController(UserSearchContext userSearchContext)
        {
            UserSearchContext = userSearchContext ?? throw new ArgumentNullException(nameof(userSearchContext));
        }

        public async Task<IActionResult> Index(int? pageIndex, int? pageSize, string searchQuery)
        {
            var usersQuery =
                from user in UserSearchContext.Users
                orderby user.FirstName
                orderby user.LastName
                select new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    Age = user.Age,
                    Phone = user.Phone,
                    FirstMediaId = user.UserMedia.FirstOrDefault().MediaId
                };

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                usersQuery = usersQuery.Where(user0 => user0.FirstName.Contains(searchQuery)
                    || user0.LastName.Contains(searchQuery));
            }

            var userViewModels = await PaginatedList<UserViewModel>.CreateAsync(usersQuery, pageIndex ?? 1, pageSize ?? 10);

            var viewModel = new IndexViewModel
            {
                UserViewModels = userViewModels,
                SearchQuery = searchQuery,
                PageSize = pageSize
            };

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
