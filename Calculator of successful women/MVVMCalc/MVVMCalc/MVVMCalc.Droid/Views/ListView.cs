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
using MvvmCross.Droid.Views;
using MVVMCalc.ViewModels;
using MvvmCross.Platform;

namespace MVVMCalc.Droid.Views
{
    [Activity(Label = "Main layout")]
    class ListView : MvxActivity
    {
        Android.Widget.ListView list;
        ViewHolderAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.result_layout);

            //list = FindViewById<Android.Widget.ListView>(Resource.Id.listResult);

            //adapter = new ViewHolderAdapter(HistoryData.Results);
            //adapter = new ViewHolderAdapter(DataBaseHelper.Instance.GetResults());
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_result, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var lvm = this.ViewModel as ListViewModel;
            switch (item.ItemId)
            {
                case Resource.Id.itemCalc:
                    lvm.ClickNewItem.Execute(null);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

            HistoryData.CurrentResult = null;
            //DataBaseHelper.Instance.Current = null;

            //list.Adapter = adapter;

            //list.EmptyView = FindViewById<TextView>(Resource.Id.emptyText);

            //list.ItemClick += List_ItemClick;
        }

        private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           
            //DataBaseHelper.Instance.Selected(e.Position);
            HistoryData.SelectedResult(e.Position);
            StartActivity(new Intent(this, typeof(CalcView)));
        }

        protected override void OnStop()
        {
            list.ItemClick -= List_ItemClick;
            base.OnStop();
        }

    }
}