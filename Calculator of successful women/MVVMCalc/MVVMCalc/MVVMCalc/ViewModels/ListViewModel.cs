using MVVMCalc.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVVMCalc.ViewModels
{
    public class ListViewModel: MvxViewModel
    {

        private readonly IDataBaseService _servise;
        public ListViewModel(IDataBaseService service)
        {
            _servise = service;
            Task.Run(() => { Results = service.GetResults(); });
        }

        private List<ResultModel> _results;
        public List<ResultModel> Results
        {
            get { return _results; }
            set {
                _results = value;
                RaisePropertyChanged(() => Results);
            }
        }

        private void DoSelectItem(ResultModel item)
        {
            BufferData.CurrentResult = item;
            ShowViewModel<CalcViewModel>();
        }

        public IMvxCommand ClickNewItem
        {
            get
            {
                return new MvxCommand(() =>
                {
                    BufferData.CurrentResult = null;
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
