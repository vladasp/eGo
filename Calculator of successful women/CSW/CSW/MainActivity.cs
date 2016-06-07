using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace CSW
{
    [Activity(Label = "CSW", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        #region Initial fields
        CheckBox catCheckBox;
        CheckBox dogCheckBox;
        CheckBox boyCheckBox;
        CheckBox girlCheckBox;
        EditText nameText;
        EditText ageText;
        int age;
        EditText kidsText;
        int kids;
        RadioButton careerRadioButton;
        RadioButton familyRadioButton;
        RadioButton yourselfRadioButton;
        TextView ansver;
        #endregion

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            InitControls();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menuItem:
                    CalcButton_Click();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
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
            ansver = FindViewById<TextView>(Resource.Id.textViewRsult);
        }

        private void CalcButton_Click()
        {
            kidsText.SetBackgroundColor(Color.LightGray);
            ageText.SetBackgroundColor(Color.LightGray);
            nameText.SetBackgroundColor(Color.LightGray);

            int input = GetInputValue();

            GetResult(input);
        }

        private int GetInputValue()
        {
            int input = 0;

            if (!NormaAge() || !CanCalcKids())
            {
                ageText.SetBackgroundColor(NormaAge() ? Color.LightGray : Color.LightPink);
                kidsText.SetBackgroundColor(CanCalcKids() ? Color.LightGray : Color.LightPink);
                nameText.SetBackgroundColor((nameText.Text == string.Empty) ? Color.LightPink : Color.LightGray);
                input = 5;
            }
            else if (IsAnotherPlanet())
            {
                nameText.SetBackgroundColor((nameText.Text == string.Empty) ? Color.LightPink : Color.LightGray);
                input = 4;
            }
            else if (!IsAdult())
            {
                input = 1;
            }
            else if (kids == 0)
            {
                if (CatLady() || !ClassicalOrientation() || !familyRadioButton.Checked)
                {
                    input = 2;
                }
                else if (familyRadioButton.Checked)
                {
                    input = 32;
                }
            }
            else if (kids > 0)
            {
                if (yourselfRadioButton.Checked)
                {
                    input = 2;
                }
                else
                {
                    input = 31;
                }
            }
            return input;
        }

        private void GetResult(int index)
        {
            switch (index)
            {
                case 1:
                    ansver.Text = nameText.Text + "\n" + GetString(Resource.String.Ansver1);
                    break;
                case 2:
                    ansver.Text = nameText.Text + "\n" + GetString(Resource.String.Ansver2);
                    break;
                case 31:
                    ansver.Text = nameText.Text + "\n" + GetString(Resource.String.Ansver31);
                    break;
                case 32:
                    ansver.Text = nameText.Text + "\n" + GetString(Resource.String.Ansver32);
                    break;
                case 4:
                    ansver.Text = nameText.Text + "\n" + GetString(Resource.String.Ansver4);
                    break;
                default:
                    ansver.Text = nameText.Text + "\n" + GetString(Resource.String.Ansver5);
                    break;
            }
        }

        private bool CanCalcKids()
        {
            if (kidsText.Text == string.Empty)
            {
                kids = 0;
                return true;
            }
            else if (int.TryParse(kidsText.Text, out kids))
            {
                return kids >= 0;
            }
            else
            {
                return false;
            }
        }

        private bool NormaAge()
        {
            return int.TryParse(ageText.Text, out age) && age > 0 && age < 100;
        }

        private bool ClassicalOrientation()
        {
            return boyCheckBox.Checked && girlCheckBox.Checked || girlCheckBox.Checked;
        }

        private bool CatLady()
        {
            return catCheckBox.Checked && dogCheckBox.Checked;
        }

        private bool IsAdult()
        {
            return NormaAge() && age >= 18;
        }

        private bool IsAnotherPlanet()
        {
            return nameText.Text == string.Empty || dogCheckBox.Checked && catCheckBox.Checked && girlCheckBox.Checked && boyCheckBox.Checked;
        }
    }
}

