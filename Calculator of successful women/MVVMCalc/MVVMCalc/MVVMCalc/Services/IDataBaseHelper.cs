using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCalc.Services
{
    public interface IDataBaseHelper
    {
        List<ResultModel> GetResults();
        void AddResult(ResultModel result);
        void Update(int position, ResultModel result);
        void Selected(int position);
    }
}
