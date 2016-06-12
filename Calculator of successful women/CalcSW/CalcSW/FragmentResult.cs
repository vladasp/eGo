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

namespace CalcSW
{
    class FragmentResult: Fragment
    {
        TextView resultTW;
        string _result;
        
        public FragmentResult(string result)
        {
            _result = result;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var v = inflater.Inflate(Resource.Layout.fragment_result, container, false);

            resultTW = v.FindViewById<TextView>(Resource.Id.textResult);

            resultTW.Text = _result;

            return v;
        }

    }
}