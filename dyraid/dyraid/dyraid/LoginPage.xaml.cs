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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public string REST_URL = "http://192.168.56.56:8000/home/rest-auth/login/";
        string res;
        
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = await AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        async Task<bool> AreCredentialsCorrect(User user)
        {
            //return user.Username == "aa" && user.Password == "aa";

            // validate
            bool ans = false;
            RestService restService = new RestService();
            res = await restService.GetUserAsync(REST_URL, user.Username, user.Password);
            if (res != null) {
                ans = true;
            }
            return ans;
        }

    }
}