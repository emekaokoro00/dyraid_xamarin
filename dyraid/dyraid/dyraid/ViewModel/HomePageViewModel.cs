using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dyraid.Model;

namespace dyraid.ViewModel
{
    public class HomePageViewModel : BaseNavigationViewModel
    {
        public HomePageViewModel(User user)
        {
            TheUser = user;
        }

        public User TheUser { private set; get; }

        public bool HasEmailAddress => !string.IsNullOrWhiteSpace(TheUser?.Email);
         
    }
}
