using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using NAVETing.ProgramData;
using System;

namespace NAVETing
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SetTextOnScreen();
            var changeDefaultUserCredentials = FindViewById<TextView>(Resource.Id.changeDefaultUserCredentials);
            changeDefaultUserCredentials.Click += ChangeCredentials;
        }
        private void ChangeCredentials(object sender, EventArgs e)
        {
            Intent changeCredentialsIntent = new Intent(this, typeof(ChangeCredentialsActivity));
            StartActivity(changeCredentialsIntent);
        }
        private void SetTextOnScreen()
        {
            var usernameTextView = FindViewById<TextView>(Resource.Id.usernameTextView);
            var useremailTextView = FindViewById<TextView>(Resource.Id.useremailTextView);
            var userpasswordTextView = FindViewById<TextView>(Resource.Id.userpasswordTextView);
            Data defaultUser = new Data();
            usernameTextView.Text = defaultUser.name;
            useremailTextView.Text = defaultUser.email;
            userpasswordTextView.Text = passwordWithStars(defaultUser.password);
        }
        private string passwordWithStars(string password)
        {
            char[] passwordArray = password.ToCharArray();
            for(int i = 0; i < password.Length; i++)
            {
                if (i <= (password.Length - 3))
                    passwordArray[i] = '*';
            }
            string passwd = new string(passwordArray);
            return (passwd);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}