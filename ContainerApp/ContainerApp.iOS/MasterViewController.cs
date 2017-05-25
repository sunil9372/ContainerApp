using System;
using System.Collections.Generic;
using Sharp.Container.Code;
using UIKit;
using Foundation;

namespace Container
{
    public partial class MasterViewController : UITableViewController
    {
        public DetailViewController DetailViewController { get; set; }

        TableSource dataSource;

        protected MasterViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = NSBundle.MainBundle.LocalizedString("Sodexo", "Sodexo");

            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.LeftBarButtonItem = EditButtonItem;
			List<TableItem> tableItems = new List<TableItem>();

			//var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
			//addButton.AccessibilityLabel = "addButton";
			//NavigationItem.RightBarButtonItem = addButton;

			DetailViewController = (DetailViewController)((UINavigationController)SplitViewController.ViewControllers[1]).TopViewController;

			tableItems.Add(new TableItem("Inspection") { SubHeading = "Sodexo Audit", ImageName = "Vegetables.jpg" , Type="App"});
			tableItems.Add(new TableItem("So Happy") { SubHeading = "Yes", ImageName = "Fruits.jpg", Type="Website", Url = "https://www.google.com" });
			tableItems.Add(new TableItem("In My Kitchen") { SubHeading = "shark", ImageName = "Flower Buds.jpg", Type = "Website", Url="http://inmykitchen.sodexo.com/" });
			tableItems.Add(new TableItem("Sodexo India") { SubHeading = "me", ImageName = "Legumes.jpg", Type = "Website", Url = "http://in.sodexo.com/home.html" }); 
			tableItems.Add(new TableItem("Bite") { SubHeading = "me", ImageName = "Legumes.jpg", Type = "Website",Url = "http://bite.sodexo.com/" });
			//tableItems.Add(new TableItem("Bulbs") { SubHeading = "18 items", ImageName = "Bulbs.jpg" });
			//tableItems.Add(new TableItem("Tubers") { SubHeading = "43 items", ImageName = "Tubers.jpg" });
			//table.Source = new TableSource(tableItems, this);
			TableView.Source = dataSource = new TableSource(tableItems, this);
        }

        public override void ViewWillAppear(bool animated)
        {
            ClearsSelectionOnViewWillAppear = SplitViewController.Collapsed;
            base.ViewWillAppear(animated);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        //void AddNewItem(object sender, EventArgs args)
        //{
        //    dataSource.Objects.Insert(0, DateTime.Now);

        //    using (var indexPath = NSIndexPath.FromRowSection(0, 0))
        //        TableView.InsertRows(new[] { indexPath }, UITableViewRowAnimation.Automatic);
        //}

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            //if (segue.Identifier == "showDetail")
            //{
            //    var controller = (DetailViewController)((UINavigationController)segue.DestinationViewController).TopViewController;
            //    var indexPath = TableView.IndexPathForSelectedRow;
            //    var item = dataSource.[indexPath.Row];

            //    controller.SetDetailItem(item);
              //controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
            //    controller.NavigationItem.LeftItemsSupplementBackButton = true;
            //}
        }

		//------------------------
		public class TableSource : UITableViewSource
		{
			UIWebView webView;

			List<TableItem> tableItems;
			string cellIdentifier = "TableCell";
			MasterViewController owner;

			public TableSource(List<TableItem> items, MasterViewController owner)
			{
				tableItems = items;
				this.owner = owner;
			}

			/// <summary>
			/// Called by the TableView to determine how many cells to create for that particular section.
			/// </summary>
			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return tableItems.Count;
			}

			/// <summary>
			/// Called when a row is touched
			/// </summary>
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
                var url = "";
                switch(tableItems[indexPath.Row].Type)
                {
                    case "Website":
						//owner.NavigationItem.LeftBarButtonItem =  //DisplayModeButtonItem;
						//owner.NavigationItem.SetRightBarButtonItem(
						//	new UIBarButtonItem(UIBarButtonSystemItem.Undo, (sender, args) =>
						//	{

						//	})
						//, true);
						//                  owner.NavigationItem.Title = tableItems[indexPath.Row].Heading.ToUpper();
						//owner.NavigationItem.LeftItemsSupplementBackButton = true;
                        UIBarButtonItem backbutton = new UIBarButtonItem("Back", UIBarButtonItemStyle.Plain, null);
                        backbutton.Clicked += (o, e) =>
                        {
                            webView.RemoveFromSuperview();
                        };
                        owner.NavigationItem.LeftBarButtonItem = backbutton;

						webView = new UIWebView(tableView.Bounds);
						tableView.AddSubview(webView);

                        url = tableItems[indexPath.Row].Url; // NOTE: https secure request
                        webView.ScalesPageToFit = true;
						webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
                        break;
                        case "App":
                    default: return;
                }
				//webView = new UIWebView(tableView.Bounds);
				//tableView.AddSubview(webView);

    //            //Title.Replace("Sodexo","Shark");
    //            //Title = NSBundle.MainBundle.LocalizedString("Sodexo", "Sodexo");

				//var url = "https://xamarin.com"; // NOTE: https secure request
				//webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));

				//UIAlertController okAlertController = UIAlertController.Create("Row Selected", tableItems[indexPath.Row].Heading, UIAlertControllerStyle.Alert);
				//okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
				//owner.PresentViewController(okAlertController, true, null);

				tableView.DeselectRow(indexPath, true);
			}

			/// <summary>
			/// Called when the DetailDisclosureButton is touched.
			/// Does nothing if DetailDisclosureButton isn't in the cell
			/// </summary>
			public override void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
			{
				UIAlertController okAlertController = UIAlertController.Create("DetailDisclosureButton Touched", tableItems[indexPath.Row].Heading, UIAlertControllerStyle.Alert);
				okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
				owner.PresentViewController(okAlertController, true, null);

				tableView.DeselectRow(indexPath, true);
			}

			/// <summary>
			/// Called by the TableView to get the actual UITableViewCell to render for the particular row
			/// </summary>
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				// request a recycled cell to save memory
				UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);

				// UNCOMMENT one of these to use that style
				//var cellStyle = UITableViewCellStyle.Default;
				//          var cellStyle = UITableViewCellStyle.Subtitle;
				var cellStyle = UITableViewCellStyle.Value1;
				//          var cellStyle = UITableViewCellStyle.Value2;

				// if there are no cells to reuse, create a new one
				if (cell == null)
				{
					cell = new UITableViewCell(cellStyle, cellIdentifier);
				}



				// UNCOMMENT one of these to see that accessory
				//        cell.Accessory = UITableViewCellAccessory.Checkmark;
				          cell.Accessory = UITableViewCellAccessory.DetailButton;
				//          cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				//          cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;  // implement AccessoryButtonTapped
				//cell.Accessory = UITableViewCellAccessory.None; // to clear the accessory

				cell.TextLabel.Text = tableItems[indexPath.Row].Heading;

				// Default style doesn't support Subtitle
				if (cellStyle == UITableViewCellStyle.Subtitle
				   || cellStyle == UITableViewCellStyle.Value1
				   || cellStyle == UITableViewCellStyle.Value2)
				{
					cell.DetailTextLabel.Text = tableItems[indexPath.Row].SubHeading;
				}

				// Value2 style doesn't support an image
				if (cellStyle != UITableViewCellStyle.Value2)
					cell.ImageView.Image = UIImage.FromFile("Images/" + tableItems[indexPath.Row].ImageName);

				return cell;
			}

			public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
		    {
		        // Return false if you do not want the specified item to be editable.
		        return true;
		    }

			    public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			    {
			        if (editingStyle == UITableViewCellEditingStyle.Delete)
			        {
			            // Delete the row from the data source.
			            tableItems.RemoveAt(indexPath.Row);
			            owner.TableView.DeleteRows(new[] { indexPath }, UITableViewRowAnimation.Fade);
			        }
			        else if (editingStyle == UITableViewCellEditingStyle.Insert)
			        {
			            // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
			        }
			    }
		}






//-------------------------
        //class DataSource : UITableViewSource
        //{
        //    static readonly NSString CellIdentifier = new NSString("Cell");
        //    List<TableItem> objects = new List<TableItem>();
        //    readonly MasterViewController controller;

        //    public DataSource(MasterViewController controller)
        //    {
        //        this.controller = controller;
        //    }

		

        //    public IList<object> Objects
        //    {
        //        get { return objects; }
        //    }

        //    // Customize the number of sections in the table view.
        //    public override nint NumberOfSections(UITableView tableView)
        //    {
        //        return 1;
        //    }

        //    public override nint RowsInSection(UITableView tableview, nint section)
        //    {
        //        return objects.Count;
        //    }

        //    // Customize the appearance of table view cells.
        //    public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        //    {
        //        var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

        //        cell.TextLabel.Text = objects[indexPath.Row].ToString();

        //        return cell;
        //    }

        //    public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        //    {
        //        // Return false if you do not want the specified item to be editable.
        //        return true;
        //    }

        //    public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        //    {
        //        if (editingStyle == UITableViewCellEditingStyle.Delete)
        //        {
        //            // Delete the row from the data source.
        //            objects.RemoveAt(indexPath.Row);
        //            controller.TableView.DeleteRows(new[] { indexPath }, UITableViewRowAnimation.Fade);
        //        }
        //        else if (editingStyle == UITableViewCellEditingStyle.Insert)
        //        {
        //            // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
        //        }
        //    }

        //    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        //    {
        //        if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
        //            controller.DetailViewController.SetDetailItem(objects[indexPath.Row]);
        //    }
        //}


    }
}
