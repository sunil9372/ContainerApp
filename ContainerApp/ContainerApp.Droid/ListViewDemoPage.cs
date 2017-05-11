using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ContainerApp.Droid
{
    public class ListViewDemoPage : ContentPage
    {
        class Person
        {
            public Person(string name, DateTime birthday, Color favoriteColor)
            {
                this.Name = name;
                this.Birthday = birthday;
                this.FavoriteColor = favoriteColor;
            }

            public string Name { private set; get; }

            public DateTime Birthday { private set; get; }

            public Color FavoriteColor { private set; get; }
        };
        public ListViewDemoPage()
        {
            Xamarin.Forms.Label header = new Xamarin.Forms.Label
            {
                Text = "ListView",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Xamarin.Forms.Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            // Define some data.
            List<Person> people = new List<Person>
            {
                new Person("Abigail", new DateTime(1975, 1, 15), Color.Aqua),
                new Person("Bob", new DateTime(1976, 2, 20), Color.Black),
                // ...etc.,...
                new Person("Yvonne", new DateTime(1987, 1, 10), Color.Purple),
                new Person("Zachary", new DateTime(1988, 2, 5), Color.Red)
            };

            // Create the ListView.
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = people,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Xamarin.Forms.Label nameLabel = new Xamarin.Forms.Label();
                    nameLabel.SetBinding(Xamarin.Forms.Label.TextProperty, "Name");

                    Xamarin.Forms.Label birthdayLabel = new Xamarin.Forms.Label();
                    birthdayLabel.SetBinding(Xamarin.Forms.Label.TextProperty,
                        new Binding("Birthday", BindingMode.OneWay,
                            null, null, "Born {0:d}"));

                    BoxView boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            birthdayLabel
                                        }
                                        }
                                }
                        }
                    };
                })
            };
            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            Content = new StackLayout
            {
                Children = {
                    header,
                    listView
                }
            };
        }
    }
}
