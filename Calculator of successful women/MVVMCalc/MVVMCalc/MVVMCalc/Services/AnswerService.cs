using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCalc.Services
{
    public class AnswerService : IAnswerService
    {
        protected List<ResultModel> _results;
        public ResultModel this[int position]
        {
            get
            {
                return _results[position];
            }
        }
        public List<ResultModel> Results
        {
            get
            {
                return _results;
            }

            set
            {
                _results = value;
            }
        }
    }
}
