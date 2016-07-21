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
        public IMvxCommand ClickNewItem
        {
            get
            {
                return new MvxCommand(() =>
                {
                    HistoryData.CurrentResult = null;
                    this.ShowViewModel<CalcViewModel>();
                });
            }
        }

    }
}
