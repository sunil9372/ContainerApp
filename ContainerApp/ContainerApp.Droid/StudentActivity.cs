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
using ContainerApp.Droid;
using Android.Webkit;

namespace ContainerApp.Droid
{
    [Activity(Label = "Applications List")]
    public class StudentActivity : Activity
    {
        // Referd from
        // http://www.c-sharpcorner.com/article/how-to-use-list-view-and-adapter-in-xamarin-android-application/

        private ListView studentlistView;
        private List<Student> mlist;
        StudentAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListContnr);
            // Create your application here
            List<Student> objstud = new List<Student>();
            objstud.Add(new Student
            {
                Name = "Inspection App"
            });
            objstud.Add(new Student
            {
                Name = "Mindful"
               
            });
            objstud.Add(new Student
            {
                Name = "In My Kitchen"
            });
            studentlistView = FindViewById<ListView>(Resource.Id.myDemoList);
            mlist = new List<Student>();
            mlist = objstud;
            adapter = new StudentAdapter(this, mlist);
            studentlistView.Adapter = adapter;
            studentlistView.ItemClick += StudentlistView_ItemClick;
        }

        private void StudentlistView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (mlist[e.Position].Name == "Inspection App")
            {
                var geoUri = Android.Net.Uri.Parse("geo:42.374260,-71.120824");
                var mapIntent = new Intent(Intent.ActionView, geoUri);
                StartActivity(mapIntent);
            }
            if (mlist[e.Position].Name == "Mindful")
            {
                // StartActivity(new Intent(Application.Context, typeof(WebViewPage1)));

                var uri = Android.Net.Uri.Parse("https://www.mindful.sodexo.com/");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            }
            if (mlist[e.Position].Name == "In My Kitchen")
            {
                //StartActivity(new Intent(Application.Context, typeof(WebViewPage2)));
                var uri = Android.Net.Uri.Parse("http://inmykitchen.sodexo.com/");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            }
        }
    }
}