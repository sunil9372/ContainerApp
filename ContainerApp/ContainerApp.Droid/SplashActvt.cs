using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Util;
using ContainerApp.Droid;

namespace InspectionApp.Resources.layout
{
    [Activity(Label = "Sodexo", MainLauncher = true, Theme = "@style/SplashScreen", NoHistory = true, Icon = "@drawable/icon", LaunchMode = Android.Content.PM.LaunchMode.SingleTop)] //,MainLauncher = true,Theme ="@style/Theme.Splash",NoHistory =true,
    public class SplashActvt : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Thread.Sleep(1000);
            //StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            //StartActivity(typeof(Loginactivity));
            StartActivity(new Intent(Application.Context, typeof(Loginactivity)));
        }
    }
}