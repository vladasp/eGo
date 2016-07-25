using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCalc.Services
{
    public interface IDataBaseService
    {
        List<ResultModel> GetResults();
        void AddResult(ResultModel result);
        void Update(ResultModel result);
        ResultModel Selected(ResultModel result);
    }
}
