using System.Collections.Generic;

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