using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Collections.Generic;

namespace CalcSW
{
    [Activity(Label = "CalcSW", MainLauncher = true, Icon = "@drawable/icon")]
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
        string result;
        FragmentResult resultFragment;
        FragmentDefault defultFragment;
        List<string> results;
        ListView list;
        ArrayAdapter adapter;
        #endregion

        protected override void OnCreate(Bundle bundle)
        {
            Console.WriteLine("Created activity");

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Console.WriteLine("Created layout");

            InitControls();

            Clear();

            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, results);

            list.Adapter = adapter;

            list.EmptyView = FindViewById<TextView>(Resource.Id.empty);

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
                case Resource.Id.menuClear:
                    Clear();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        void Clear()
        {
            kidsText.SetBackgroundColor(Color.LightGray);
            ageText.SetBackgroundColor(Color.LightGray);
            nameText.SetBackgroundColor(Color.LightGray);

            kidsText.Text = string.Empty;
            ageText.Text = string.Empty;
            nameText.Text = string.Empty;

            dogCheckBox.Checked = false;
            catCheckBox.Checked = false;
            girlCheckBox.Checked = false;
            boyCheckBox.Checked = false;

            FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, defultFragment).Commit();
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
            resultFragment = new FragmentResult();
            defultFragment = new FragmentDefault();
            results = new List<string>();
            list = FindViewById<ListView>(Resource.Id.myList);
        }

        private void CalcButton_Click()
        {
            kidsText.SetBackgroundColor(Color.LightGray);
            ageText.SetBackgroundColor(Color.LightGray);
            nameText.SetBackgroundColor(Color.LightGray);

            int input = GetInputValue();

            GetResult(input);

            FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, resultFragment).Commit();

            resultFragment.UpdateAnswer(result);

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
                    result = nameText.Text + "\n" + GetString(Resource.String.Ansver1);
                    break;
                case 2:
                    result = nameText.Text + "\n" + GetString(Resource.String.Ansver2);
                    break;
                case 31:
                    result = nameText.Text + "\n" + GetString(Resource.String.Ansver31);
                    break;
                case 32:
                    result = nameText.Text + "\n" + GetString(Resource.String.Ansver32);
                    break;
                case 4:
                    result = nameText.Text + "\n" + GetString(Resource.String.Ansver4);
                    break;
                default:
                    result = nameText.Text + "\n" + GetString(Resource.String.Ansver5);
                    break;
            }
            results.Add(result);

            if (results.Count != 0)
            {
                foreach(var result in results)
                {
                    adapter.Add(result);
                }
                adapter.NotifyDataSetChanged();
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

