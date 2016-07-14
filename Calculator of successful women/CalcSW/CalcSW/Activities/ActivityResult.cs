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
using CalcSW.Adapters;

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

            Button buttonAdd = FindViewById<Button>(Resource.Id.buttonAdd);

            var adapter = new ViewHolderAdapter(HistoryData.Results);

            list.Adapter = adapter;

            list.EmptyView = FindViewById<TextView>(Resource.Id.emptyText);

            buttonAdd.Click += (sender, e) =>
            {
                HistoryData.CurrentResult = null;
                StartActivity(new Intent(this, typeof(MainActivity)));
            };
            
            list.ItemClick += (sender, e) =>
            {
                HistoryData.SelectedResult(e.Position);
                StartActivity(new Intent(this, typeof(MainActivity)));
            };

        }
    }
}