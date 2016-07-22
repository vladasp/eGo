using MVVMCalc.Services;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCalc.ViewModels
{
    public class ListViewModel: MvxViewModel
    {

        public ListViewModel(AnswerService service)
        {
            Results = service.Results;
        }

        private List<ResultModel> _results;
        public List<ResultModel> Results
        {
            get { return _results; }
            set { _results = value; RaisePropertyChanged(() => Results); }
        }

        public IMvxCommand ClickNewItem
        {
            get
            {
                return new MvxCommand(() =>
                {
                    HistoryData.CurrentResult = null;
                    //DataBaseHelper.Instance.Current = null;
                    this.ShowViewModel<CalcViewModel>();
                });
            }
        }

        public IMvxCommand ClickListItem
        {
            get
            {
                return new MvxCommand(() =>
                {
                    //HistoryData.SelectedResult(e.Position);
                    this.ShowViewModel<CalcViewModel>();
                });
            }
        }


    }
}
