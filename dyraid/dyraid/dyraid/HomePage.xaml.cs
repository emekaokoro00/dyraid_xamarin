using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using dyraid.Model;
using dyraid.UserAuth;
using dyraid.Utility;

namespace dyraid
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private static readonly string USERLOGLIST_REQUEST_URL = "http://192.168.56.56:8000/userlog/api/";//Remove hardcode

        public HomePage()
        {
            InitializeComponent();
            // User user = (User)this.BindingContext;
            // this.displayUserName.Text = user.FirstName;
        }
    }
}