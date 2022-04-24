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
using System.Threading.Tasks;

namespace NAVETing
{
    [Activity(Label = "SplashActivity", MainLauncher =true, NoHistory =true)]
    public class SplashAcivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_splash);
            LoadingAnimation();
        }
        private async void LoadingAnimation()
        {
            var loadingText = FindViewById<TextView>(Resource.Id.loadingText);
            await Task.Delay(500);
            loadingText.Text = "Carregando";
            await Task.Delay(500);
            loadingText.Text = "Carregando.";
            await Task.Delay(500);
            loadingText.Text = "Carregando..";
            await Task.Delay(500);
            loadingText.Text = "Carregando...";
            LoadingAnimation();
        }
        protected override async void OnResume()
        {
            base.OnResume();
            await SimulateStartup();
        }
        async Task SimulateStartup()
        {
            await Task.Delay(TimeSpan.FromSeconds(8));
            StartActivity(new Intent(Application.Context, typeof(LoginActivity)));
        }
    }
}