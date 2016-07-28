using CalcSW_XForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CalcSW_XForms.Pages
{
    public partial class CalcPage : ContentPage
    {
        public CalcPage()
        {
            InitializeComponent();
            BindingContext = new CalcViewModel();
            Switch switcher = new Switch();
        }
        public void OnCalcClick(object sender, EventArgs args)
        {
            var vm = BindingContext as CalcViewModel;
            vm.CalculateCommand.Execute(null);
            Navigation.PushAsync(new ListPage());
        }

        public void OnClearClick(object sender, EventArgs args)
        {
            var vm = BindingContext as CalcViewModel;
            vm.ClearCommand.Execute(null);
        }

    }
}
