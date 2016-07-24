using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCalc.Services
{
    public interface IAnswerService
    {
        List<ResultModel> Results { get; set; }
        ResultModel this[int position] { get; }
        void ReadData();
    }
}
 