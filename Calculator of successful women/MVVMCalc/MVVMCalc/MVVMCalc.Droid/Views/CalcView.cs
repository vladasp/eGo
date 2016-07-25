using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using Android.Graphics;
using MVVMCalc.ViewModels;

namespace MVVMCalc.Droid.Views
{
    [Activity(Label = "Main layout")]
    public class CalcView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CalcView);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var cvm = this.ViewModel as CalcViewModel;
            switch (item.ItemId)
            {
                case Resource.Id.menuItem:
                    cvm.CalculateCommand.Execute(null);
                    return true;
                case Resource.Id.menuClear:
                    cvm.ClearCommand.Execute(null);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}
