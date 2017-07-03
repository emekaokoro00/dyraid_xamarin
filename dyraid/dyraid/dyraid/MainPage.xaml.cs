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
using dyraid.ViewModel;

namespace dyraid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.CurrentPage = Children[1];

        }

        public MainPage(HomePageViewModel bindingContextForHome)
        {
            InitializeComponent();
            this.CurrentPage = Children[1];
            this.CurrentPage.BindingContext = bindingContextForHome;
        }
    }
}
