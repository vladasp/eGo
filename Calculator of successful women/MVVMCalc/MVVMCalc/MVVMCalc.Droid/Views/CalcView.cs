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
        #region Initial fields
        EditText nameText;
        EditText ageText;
        EditText kidsText;
        #endregion

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CalcView);
            InitControls();
            kidsText.SetBackgroundColor(Color.LightGray);
            ageText.SetBackgroundColor(Color.LightGray);
            nameText.SetBackgroundColor(Color.LightGray);
        }

        private void InitControls()
        {
            // Get our controls from the layout resource,
            nameText = FindViewById<EditText>(Resource.Id.editTextName);
            ageText = FindViewById<EditText>(Resource.Id.editTextAge);
            kidsText = FindViewById<EditText>(Resource.Id.editTextKids);
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
