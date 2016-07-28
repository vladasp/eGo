using CalcSW_XForms.Models;
using CalcSW_XForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CalcSW_XForms.Pages
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = new ListViewModel();
        }
        public void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var lm = BindingContext as ListViewModel;
            lm.ClickListItem.Execute(null);
            Navigation.PushAsync(new CalcPage());
        }

    }
}
