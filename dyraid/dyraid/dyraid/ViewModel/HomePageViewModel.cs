using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dyraid.Model;

namespace dyraid.ViewModel
{
    public class HomePageViewModel : MainPageViewModel
    {
        public HomePageViewModel(User user) : base(user)
        {
            TheUser = user;
        }

        public bool HasEmailAddress => !string.IsNullOrWhiteSpace(TheUser?.Email);

    }
}
