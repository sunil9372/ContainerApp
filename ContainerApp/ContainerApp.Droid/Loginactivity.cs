using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.Res;

namespace ContainerApp.Droid
{
    [Activity(Label = "CONTAINER",Theme = "@style/SplashScreen")]
    public class Loginactivity : Activity
    {
        //private Button login = nul;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LoginPage);
            // Create your application here
            //Initializing button from layout
            Button login = FindViewById<Button>(Resource.Id.login);

            //Login button click action
            login.Click += (object sender, EventArgs e) =>
            {
                // Android.Widget.Toast.MakeText(this, "Login Button Clicked!", Android.Widget.ToastLength.Short).Show();
                StartActivity(new Intent(Application.Context, typeof(StudentActivity)));
                //StartActivity(new Intent(Application.Context, typeof(ListViewDemoPage)));
                // Navigation.PushAsync(new PersonList());

            };
        }

   }
    
    
}