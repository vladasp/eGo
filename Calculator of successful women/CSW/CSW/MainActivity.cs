using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CSW
{
    [Activity(Label = "CSW", MainLauncher = true, Icon = "@drawable/icon")]
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
            int input = 5;
            if (nameText.Text == string.Empty)
            {
                input = 4;
            }
            else if (int.TryParse(ageText.Text, out age))
            {
                if (age > 100)
                {
                    input = 4;
                }
                else if (age < 18)
                {
                    input = 1;
                }
                else if (careerRadioButton.Checked || yourselfRadioButton.Checked)
                {
                    if (int.TryParse(kidsText.Text, out kids))
                    {
                        if (kids > 0 && kids < 15)
                        {
                            input = 3;
                        }
                        else
                        {
                            input = 4;
                        }
                    }
                    else
                    {
                        input = 2;
                    }
                }
                else if (familyRadioButton.Checked)
                {
                    if (int.TryParse(kidsText.Text, out kids))
                    {
                        if (kids > 0 && kids < 15)
                        {
                            input = 3;
                        }
                        else
                        {
                            input = 4;
                        }
                    }
                    else
                    {
                        input = 3;
                    }
                }
            }
            GetResult(input);
        }

        private void GetResult(int index)
        {
            switch (index)
            {
                case 1:
                    ansver.Text = Result.Ansver1;
                    break;
                case 2:
                    ansver.Text = Result.Ansver2;
                    break;
                case 3:
                    ansver.Text = Result.Ansver3;
                    break;
                case 4:
                    ansver.Text = Result.Ansver4;
                    break;
                default:
                    ansver.Text = Result.Ansver5;
                    break;
            }
        }

    }
}

