using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dyraid.Model;

namespace dyraid.ViewModel
{
    public class MainPageViewModel : BaseNavigationViewModel
    {
        public MainPageViewModel(User user)
        {
            TheUser = user;
        }

        public virtual User TheUser { protected set; get; }
    }
}
