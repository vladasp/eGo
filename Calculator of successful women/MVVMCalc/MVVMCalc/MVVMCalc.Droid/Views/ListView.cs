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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.result_layout);

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
        }


    }
}