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
using Android.Net.Http;

namespace ContainerApp.Droid
{
    [Activity(Label = "Sodexo - Mindful")]
    public class WebViewUIPage : Activity
    {
        WebView web_view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WebView1);
            // Create your application here

            web_view = FindViewById<WebView>(Resource.Id.LocalWebView);
            web_view.SetWebViewClient(new HelloWebViewClient());
            
            web_view.LoadUrl("https://www.mindful.sodexo.com/");
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
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }

            // Continue only when there is a ssl warnings.
            public void onReceivedSslError(WebView view, SslErrorHandler handler, SslError error)
            {
                String message = "SSL Certificate error.";
                switch (error.PrimaryError)
                {
                    case SslError.SslUntrusted:
                        message = "The certificate authority is not trusted.";
                        break;
                    case SslError.SslExpired:
                        message = "The certificate has expired.";
                        break;
                    case SslError.SslIdmismatch:
                        message = "The certificate Hostname mismatch.";
                        break;
                    case SslError.SslNotyetvalid:
                        message = "The certificate is not yet valid.";
                        break;
                }
                message += "\"SSL Certificate Error\" Do you want to continue anyway?.. YES";

                //handler.proceed();
                handler.Proceed();
            }

            public void onReceivedError(WebView view, int errorCode, String description, String failingUrl)
            {
               string sError = "onReceivedError DEPRECATED Error: " + description);
                //Toast.MakeText(Contex, "Oh no! " + sError, ToastLength.Long).show();
                
            }
        }
    }
}