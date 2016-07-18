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

namespace MVVMCalc.Droid
{
    [Activity(Label = "Results")]
    public class ActivityResult : Activity
    {

        ListView list;
        ViewHolderAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.result_layout);

            list = FindViewById<ListView>(Resource.Id.listResult);

            adapter = new ViewHolderAdapter(HistoryData.Results);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_result, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.itemCalc:
                    HistoryData.CurrentResult = null;
                    StartActivity(new Intent(this, typeof(MVVMCalc.Droid.Views.CalctView)));
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

            HistoryData.CurrentResult = null;

            list.Adapter = adapter;

            list.EmptyView = FindViewById<TextView>(Resource.Id.emptyText);

            list.ItemClick += List_ItemClick;
        }

        private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            HistoryData.SelectedResult(e.Position);
            StartActivity(new Intent(this, typeof(MVVMCalc.Droid.Views.CalctView)));
        }

        protected override void OnStop()
        {
            list.ItemClick -= List_ItemClick;
            base.OnStop();
        }
    }
}