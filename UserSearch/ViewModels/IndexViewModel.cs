namespace UserSearch.ViewModels
{
    public class IndexViewModel
    {
        public PaginatedList<UserViewModel> UserViewModels { get; set; }

        public string SearchQuery { get; set; }

        public int? PageSize { get; set; }
    }
}
