using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ContainerApp.Droid
{
    [Activity(Label = "ListContrActivity")]
    public class ListContrActivity : Activity
    {
        private List<string> _demoList;
        private ListView demoItemslistView;
        //ListView lstView = new ListView();
        //ArrayAdapter<String> adapters;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListContnr);
            // Create your application heres
            // _demoList.Add(new DemoItems { Name = "Inspection App", Deails = "Test 1" });
            //_demoList.Add(new DemoItems { Name = "Mindful", Deails = "Test 2" });
            //_demoList.Add(new DemoItems { Name = "In My Kitchen", Deails = "Test 2" });
            //ListView demoItemslistView = new ListView(this);
            //demoItemslistView.itemt

            //demoItemslistView = FindViewById<ListView>(ContainerApp.Droid.Resource.Id.myDemoList);
            //_demoList = new List<string>();
            //_demoList.Add("Inspection App");
            //_demoList.Add("Mindful");
            //_demoList.Add("In My Kitchen");
            //_demoList.Add("Test");

            

            //if (demoItemslistView == null)
            //{
                //demoItemslistView = FindViewById<ListView>(Resource.Id.myDemoList);
            //}
            //demoItemslistView = FindViewById<ListView>(Resource.Id.demolist);
            
            ArrayAdapter adapters = new ArrayAdapter(this, Resource.Layout.ListContnr, _demoList);
            //demoItemslistView.Adapter = adapters; //= new ArrayAdapter(this, Resource.Layout.ListContnr, _demoList);
            ////adapter = new ArrayAdapter<string>(this, Resource.Layout.ListContnr, _demoList);

            demoItemslistView.Adapter= adapters;
            demoItemslistView.ItemClick += DemoItemslistView_ItemClick;
            //FindViewById<ListView>(Resource.Id.demolist).ItemClick += DemoItemslistView_ItemClick;
        }

        private void DemoItemslistView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           // adapters.NotifyDataSetChanged();
            if (_demoList[e.Position] == "Inspection App")
            {

            }
            if (_demoList[e.Position] == "Mindful")
            {
                StartActivity(new Intent(Application.Context, typeof(WebViewUIPage)));
            }
            if (_demoList[e.Position] == "In My Kitchen")
            {
                StartActivity(new Intent(Application.Context, typeof(WebViewUIPage2)));
                
            }
        }
    }


    public class DemoItems
    {
        public string Name
        {
            get;
            set;
        }
        public string Deails
        {
            get;
            set;
        }
    }
}