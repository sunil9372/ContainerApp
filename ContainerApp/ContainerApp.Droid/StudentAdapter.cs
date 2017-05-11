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
using ContainerApp;
using ContainerApp.Droid;

namespace ContainerApp.Droid
{
    public class StudentAdapter : BaseAdapter<Student>
    {
        public List<Student> sList;
        private Context sContext;
        public StudentAdapter(Context context, List<Student> list)
        {
            sList = list;
            sContext = context;
        }
        public override Student this[int position]
        {
            get
            {
                return sList[position];
            }
        }

        public override int Count
        {
            get
            {
                return sList.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            try
            {
                if (row == null)
                {
                    row = LayoutInflater.From(sContext).Inflate(Resource.Layout.ListContnr, null, false);
                }
                TextView txtName = row.FindViewById<TextView>(Resource.Id.ItemsTxtName);
                txtName.Text = sList[position].Name;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally { }
            return row;
        }
    }
}