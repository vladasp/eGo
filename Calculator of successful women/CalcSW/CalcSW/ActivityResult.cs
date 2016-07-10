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
using Java.Lang;

namespace CalcSW
{
    [Activity(Label = "Results")]
    public class ActivityResult : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.result_layout);

            HistoryData.CurrentResult = null;

            ListView list = FindViewById<ListView>(Resource.Id.listResult);

            var adapter = new ResultAdapter(HistoryData.Results);

            list.Adapter = adapter;

            list.EmptyView = FindViewById<TextView>(Resource.Id.emptyText);

            list.ItemClick += (sender, e) =>
            {
                HistoryData.SelectedResult(e.Position);
                StartActivity(new Intent(this, typeof(MainActivity)));
            };

        }
    }
}