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
using Android.Webkit;

namespace ContainerApp.Droid
{
    [Activity(Label = "Sodexo - In My Kitchen")]
    public class WebViewUIPage2 : Activity
    {
        WebView web_view;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.WebView2);
            // Create your application here

            web_view = FindViewById<WebView>(Resource.Id.LocalWebView2);
            web_view.SetWebViewClient(new HelloWebViewClient());

            web_view.LoadUrl("http://inmykitchen.sodexo.com/");
            web_view.Settings.JavaScriptEnabled = true;
            web_view.Settings.BuiltInZoomControls = true;
            web_view.Settings.SetSupportZoom(true);

            // scrollbar stuff            
            web_view.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
            // so there's no 'white line'            
            web_view.ScrollbarFadingEnabled = false;
        }
        public override bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if (keyCode == Keycode.Back && web_view.CanGoBack())
            {
                web_view.GoBack();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }

        //In the HelloAndroid Activity, add this nested class
        public class HelloWebViewClient : WebViewClient
        {
#pragma warning disable CS0672 // Member overrides obsolete member
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
#pragma warning restore CS0672 // Member overrides obsolete member
            {
                view.LoadUrl(url);
                return true;
            }
        }
    }
}