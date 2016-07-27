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
        }
    }
}
