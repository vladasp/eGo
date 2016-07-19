using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCalc
{
    public static class HistoryData
    {
        public static List<ResultModel> Results = new List<ResultModel>();
        public static ResultModel CurrentResult;
        public static bool IsClear;
        public static void SelectedResult(int position)
        {
            CurrentResult = Results[position];
            CurrentResult.Position = position;
        }
    }
}
