using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CSW
{
    [Activity(Label = "Calculator of successful women", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button calcButton;
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

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            InitControls();

            calcButton.Click += CalcButton_Click;

        }

        private void InitControls()
        {
            // Get our controls from the layout resource,
            calcButton = FindViewById<Button>(Resource.Id.calculateButton);
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

        private void CalcButton_Click(object sender, EventArgs e)
        {
            int input = 0;
            if (!NormaAge() || !CanCalcKids())
            {
                input = 5;
            }
            else if (IsAnotherPlanet())
            {
                input = 4;
            }
            else if (!IsAdult())
            {
                input = 1;
            }
            else if(kids == 0)
            {
                if(CatLady() || !ClassicalOrientation() || !familyRadioButton.Checked)
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
            GetResult(input);
        }

        private void GetResult(int index)
        {
            switch (index)
            {
                case 1:
                    ansver.Text = nameText.Text + "\n" + Result.Ansver1;
                    break;
                case 2:
                    ansver.Text = nameText.Text + "\n" + Result.Ansver2;
                    break;
                case 31:
                    ansver.Text = nameText.Text + "\n" + Result.Ansver31;
                    break;
                case 32:
                    ansver.Text = nameText.Text + "\n" + Result.Ansver32;
                    break;
                case 4:
                    ansver.Text = nameText.Text + "\n" + Result.Ansver4;
                    break;
                default:
                    ansver.Text = nameText.Text + "\n" + Result.Ansver5;
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
                if (kids > 0) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        private bool ClassicalOrientation()
        {
            if(boyCheckBox.Checked && girlCheckBox.Checked || girlCheckBox.Checked)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CatLady()
        {
            if(catCheckBox.Checked && dogCheckBox.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool NormaAge()
        {
            if (int.TryParse(ageText.Text, out age))
            {
                if (age > 0 && age < 100) return true;
                else return false;
            }
            else return false;
        }

        private bool IsAdult()
        {
            if(NormaAge() && age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsAnotherPlanet()
        {
            if(nameText.Text == string.Empty || dogCheckBox.Checked && catCheckBox.Checked && girlCheckBox.Checked && boyCheckBox.Checked)
            {
                return true;
            }
            return false;
        }
    }
}

