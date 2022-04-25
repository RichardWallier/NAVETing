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
    [Activity(Label = "ChangeCredentialsACtivity")]
    public class ChangeCredentialsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_changeCredentials);
            var changeCredentialsButton = FindViewById<Button>(Resource.Id.changeCredentialsButton);
            changeCredentialsButton.Click += ChangeCredentials;
        }
        private void ChangeCredentials(object sender, EventArgs e)
        {
            var newUserName = FindViewById<EditText>(Resource.Id.newUserNameEditText);    
            var newUserEmail = FindViewById<EditText>(Resource.Id.newUserEmailEditText);    
            var newUserPassword = FindViewById<EditText>(Resource.Id.newUserPasswordEditText);
            Data defaultUser = new Data();
            defaultUser.name = newUserName.Text;
            defaultUser.email = newUserEmail.Text;
            defaultUser.password = newUserPassword.Text;
            Intent loginIntent = new Intent(this, typeof(LoginActivity));
            StartActivity(loginIntent);
        }
    }
}