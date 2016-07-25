using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;
using MVVMCalc.ViewModels;

namespace MVVMCalc.Droid.Views
{
    [Activity(Label = "Main layout")]
    class ListView : MvxActivity
    {
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

            BufferData.CurrentResult = null;
        }


    }
}