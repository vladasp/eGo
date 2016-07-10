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
using Android.Util;

namespace CalcSW
{
    class ResultAdapter : BaseAdapter<ResultModel>
    {
        protected IList<ResultModel> _results;

        public ResultAdapter(List<ResultModel> results)
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

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_layout, parent, false);

            var name = view.FindViewById<TextView>(Resource.Id.rowName);
            var age = view.FindViewById<TextView>(Resource.Id.rowAge);
            var ansver = view.FindViewById<TextView>(Resource.Id.rowAnsver);

            name.Text = _results[position].Name;
            age.Text = _results[position].Age;
            ansver.Text = _results[position].Ansver;
            return view;
        }

        public virtual ResultModel GetRawItem(int position)
        {
            return _results[position];
        }

    }
}