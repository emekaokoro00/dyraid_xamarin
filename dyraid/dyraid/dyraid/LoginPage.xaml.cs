using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

using dyraid.Model;
using dyraid.UserAuth;
using dyraid.Utility;

namespace dyraid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public static readonly string REST_URL = "http://192.168.56.56:8000/home/rest-auth/login/";
        private static readonly string USERDETAILS_REQUEST_URL = "http://192.168.56.56:8000/home/rest-auth/user/";//Remove hardcode

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
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            User user = null;
            bool isValid = false;

            Tuple<bool, User> cred = await AreCredentialsCorrect(username, password);
            if (cred.Item1)
            {
                App.IsUserLoggedIn = true;
                var mainPage = new MainPage();
                mainPage.BindingContext = cred.Item2;
                Navigation.InsertPageBefore(mainPage, this);
                await Navigation.PopAsync();

                // await Navigation.PushAsync(mainPage);
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        async Task<Tuple<bool, User>> AreCredentialsCorrect(string username, string password)
        {
            User user = null;
            // validate
            bool ans = false;
            // RestService restService = new RestService();
            res = await RestService.Instance.AuthenticateUserAsync(REST_URL, username, password);
            if (res != null) {
                var user_json = await RestService.Instance.GetUserDetailsAsync(USERDETAILS_REQUEST_URL);
                user = JsonConvert.DeserializeObject<User>(user_json);
                ans = true;
            }
            return Tuple.Create(ans, user);
        }

    }
}