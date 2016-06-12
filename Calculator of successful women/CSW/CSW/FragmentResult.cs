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

namespace CSW
{
    class FragmentResult: Fragment
    {
        string _result;
        TextView resultTW;

        public FragmentResult(string result)
        {
            _result = result;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            resultTW = Activity.FindViewById<TextView>(Resource.Id.textResult);

            resultTW.Text = _result;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            return inflater.Inflate(Resource.Layout.fragment_result, container, false);
        }

    }
}