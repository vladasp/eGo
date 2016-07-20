using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using Android.Graphics;
using MVVMCalc.ViewModels;

namespace MVVMCalc.Droid.Views
{
    [Activity(Label = "Main layout")]
    public class CalcView : MvxActivity
    {
        #region Initial fields
        CheckBox catCheckBox;
        CheckBox dogCheckBox;
        CheckBox boyCheckBox;
        CheckBox girlCheckBox;
        EditText nameText;
        EditText ageText;
        EditText kidsText;
        RadioButton careerRadioButton;
        RadioButton familyRadioButton;
        RadioButton yourselfRadioButton;
        #endregion

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CalcView);
            InitControls();
            kidsText.SetBackgroundColor(Color.LightGray);
            ageText.SetBackgroundColor(Color.LightGray);
            nameText.SetBackgroundColor(Color.LightGray);
        }

        private void InitControls()
        {
            // Get our controls from the layout resource,
            catCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxCat);
            dogCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxDog);
            boyCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxBoy);
            girlCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxGirl);
            nameText = FindViewById<EditText>(Resource.Id.editTextName);
            ageText = FindViewById<EditText>(Resource.Id.editTextAge);
            kidsText = FindViewById<EditText>(Resource.Id.editTextKids);
            careerRadioButton = FindViewById<RadioButton>(Resource.Id.radioButtonCareer);
            familyRadioButton = FindViewById<RadioButton>(Resource.Id.radioButtonFamily);
            yourselfRadioButton = FindViewById<RadioButton>(Resource.Id.radioButtonYourself);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var cvm = this.ViewModel as CalcViewModel;
            switch (item.ItemId)
            {
                case Resource.Id.menuItem:
                    FillData();
                    cvm.CalculateCommand.Execute();
                    StartActivity(new Intent(this, typeof(ActivityResult)));
                    return true;
                case Resource.Id.menuClear:
                    cvm.ClearCommand.Execute();
                    StartActivity(new Intent(this, typeof(MVVMCalc.Droid.Views.CalcView)));
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        void FillData()
        {
            var currentResult = new ResultModel
            {
                Name = (string.IsNullOrEmpty(nameText.Text)) ? string.Empty : nameText.Text,
                Age = (string.IsNullOrEmpty(ageText.Text)) ? string.Empty : ageText.Text,
                Kids = (string.IsNullOrEmpty(kidsText.Text)) ? string.Empty : kidsText.Text,
                Cats = catCheckBox.Checked,
                Dogs = dogCheckBox.Checked,
                Boys = boyCheckBox.Checked,
                Girls = girlCheckBox.Checked,
                Career = careerRadioButton.Checked,
                Family = familyRadioButton.Checked,
                Yourself = yourselfRadioButton.Checked
            };

            if (HistoryData.CurrentResult != null && HistoryData.CurrentResult.Position >= 0)
            {
                HistoryData.Results[HistoryData.CurrentResult.Position] = currentResult;
            }
            else
            {
                HistoryData.Results.Add(currentResult);
                HistoryData.CurrentResult = HistoryData.Results[HistoryData.Results.Count - 1];
                HistoryData.CurrentResult.Position = HistoryData.Results.Count - 1;
            }

        }
    }
}
