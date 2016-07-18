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

namespace MVVMCalc.Droid
{
    public class ViewHolderAdapter : BaseAdapter<ResultModel>
    {
        protected IList<ResultModel> _results;

        public ViewHolderAdapter(List<ResultModel> results)
        {
            _results = results;
        }

        public override ResultModel this[int position]
        {
            get
            {
                return _results[position];
            }
        }

        public override int Count
        {
            get
            {
                return _results.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public virtual ResultModel GetRawItem(int position)
        {
            return _results[position];
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];
            var view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_layout, parent, false);
                var viewHolder = new ViewHolder();
                viewHolder.Name = view.FindViewById<TextView>(Resource.Id.rowName);
                viewHolder.Age = view.FindViewById<TextView>(Resource.Id.rowAge);
                viewHolder.Ansver = view.FindViewById<TextView>(Resource.Id.rowAnsver);
                view.Tag = viewHolder;
            }
            var holder = (ViewHolder)view.Tag;
            holder.Ansver.Text = item.Ansver;
            holder.Name.Text = (string.IsNullOrEmpty(item.Name)) ? string.Empty : item.Name;
            holder.Age.Text = (string.IsNullOrEmpty(item.Age)) ? string.Empty : item.Age;
            return view;
        }

        class ViewHolder : Java.Lang.Object
        {
            public TextView Name { get; set; }
            public TextView Age { get; set; }
            public TextView Ansver { get; set; }
        }
    }
}