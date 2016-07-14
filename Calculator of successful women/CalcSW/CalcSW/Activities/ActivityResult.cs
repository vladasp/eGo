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

        ListView list;
        Button buttonAdd;
        ViewHolderAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.result_layout);

            list = FindViewById<ListView>(Resource.Id.listResult);

            buttonAdd = FindViewById<Button>(Resource.Id.buttonAdd);

            adapter = new ViewHolderAdapter(HistoryData.Results);
        }

        protected override void OnStart()
        {
            base.OnStart();

            HistoryData.CurrentResult = null;

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

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}