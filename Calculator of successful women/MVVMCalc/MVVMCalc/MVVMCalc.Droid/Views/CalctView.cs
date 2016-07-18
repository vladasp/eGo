using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;

namespace MVVMCalc.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class CalctView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menuItem:
                    StartActivity(new Intent(this, typeof(ActivityResult)));
                    return true;
                case Resource.Id.menuClear:
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

    }
}
