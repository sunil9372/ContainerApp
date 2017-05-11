using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ContainerApp.Droid
{
    public class WebViewPage2 : ContentPage
    {
        public WebViewPage2()
        {
            WebView webview = new WebView
            {
                Source = "http://xamarin.com",
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
