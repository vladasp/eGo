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
    public static class HistoryData
    {
        public static List<ResultModel> Results = new List<ResultModel>();
        public static ResultModel CurrentResult;
        public static void SelectedResult(int position)
        {
            CurrentResult = Results[position];
            CurrentResult.Position = position;
        }
    }
}