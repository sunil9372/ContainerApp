using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ContainerApp.Droid
{
    public class WebViewPage1 : ContentPage
    {
        public WebViewPage1()
        {
            WebView webview = new WebView
            {
                Source = "http://google.com",
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Content = new StackLayout
            {
                Children = {
                   webview
                }
            };
        }
    }
}
