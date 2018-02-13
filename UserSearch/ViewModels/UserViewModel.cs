using System.Collections.Generic;

namespace UserSearch.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public int? FirstMediaId { get; set; }

        public List<int> MediaIds { get; set; }
    }
}
