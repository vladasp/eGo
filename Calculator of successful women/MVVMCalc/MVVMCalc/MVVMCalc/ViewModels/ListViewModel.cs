using MVVMCalc.Services;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMCalc.ViewModels
{
    public class ListViewModel: MvxViewModel
    {

        private readonly IAnswerService _servise;
        public ListViewModel(IAnswerService service)
        {
            _servise = service;
            Results = service.Results;
        }

        private List<ResultModel> _results;
        public List<ResultModel> Results
        {
            get { return _results; }
            set {
                _results = value;
                RaisePropertyChanged(() => Results);
            }
            //set { this.RaiseAndSetIfChanged(ref this._results, value); }
        }

        //private MvxCommand<ResultModel> _itemSelectedCommand;

        //public System.Windows.Input.ICommand ItemSelectedCommand
        //{
        //    get
        //    {
        //        _itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<ResultModel>(DoSelectItem);
        //        return _itemSelectedCommand;
        //    }
        //}

        private void DoSelectItem(ResultModel item)
        {
            HistoryData.CurrentResult = item;
            ShowViewModel<CalcViewModel>();
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
                return new MvxCommand<ResultModel>(DoSelectItem);
            }
        }


    }
}
