using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;

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
            ViewModels.CalcViewModel cvm = new ViewModels.CalcViewModel();
            switch (item.ItemId)
            {
                case Resource.Id.menuItem:
                    cvm.CalculateCommand.Execute();
                    StartActivity(new Intent(this, typeof(ActivityResult)));
                    return true;
                case Resource.Id.menuClear:
                    cvm.ClearCommand.Execute();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

    }
}
