using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAVETing.ProgramData;

namespace NAVETing
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            var loginButton = FindViewById<Button>(Resource.Id.loginButton);
            loginButton.Click += Login;
        }
        private void Login(object sender, EventArgs e)
        {
            Data defaultUser = new Data();
            var emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            var passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            if (emailEditText.Text == defaultUser.email && passwordEditText.Text == defaultUser.password)
                LoginSuccessfull();
            else
                LoginUnsuccessfull();
        }
        private void LoginSuccessfull()
        {

        }
        private void LoginUnsuccessfull()
        {
            var emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            var passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            var statusLoginTextView = FindViewById<TextView>(Resource.Id.statusLoginTextView);
            statusLoginTextView.Text = "Email or Password Invalid";
            emailEditText.Text = "";
            passwordEditText.Text = "";
        }
    }
}