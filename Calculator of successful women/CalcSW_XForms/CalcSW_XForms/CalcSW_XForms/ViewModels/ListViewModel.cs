using CalcSW_XForms.Halpers;
using CalcSW_XForms.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalcSW_XForms.ViewModels
{
    public class ListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public ListViewModel()
        {
            Task.Run(() => 
            {
                Results = new ObservableCollection<ResultModel>(DBHelper.Instance.ResultModels);
            });
        }

        private ObservableCollection<ResultModel> _results;

        public ObservableCollection<ResultModel> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                OnPropertyChanged("Results");
            }
        }

        private void DoSelectItem(ResultModel item)
        {
            BufferData.CurrentResult = item;
            //ShowViewModel<CalcViewModel>();
        }

        public ICommand ClickNewItem
        {
            get
            {
                return new Command(() =>
                {
                    BufferData.CurrentResult = null;
                    //this.ShowViewModel<CalcViewModel>();
                });
            }
        }

        public ICommand ClickListItem
        {
            get
            {
                return new Command<ResultModel>(DoSelectItem);
            }
        }

    }
}
