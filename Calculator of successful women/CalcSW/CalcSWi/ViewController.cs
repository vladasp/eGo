using CoreGraphics;
using System;
using System.Collections.Generic;
using UIKit;

namespace CalcSWi
{
    public partial class ViewController : UIViewController
    {
        int kids = 0;
        int age = 0;
        List<string> results;
        TableSource ts;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            results = new List<string>();

            ts = new TableSource(results);

            NameText.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            };

            AgeText.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            };

            KidsText.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            };


            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false; //for iOS5
            View.AddGestureRecognizer(g);

            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), TableSource.CellIdentifier);
            TableView.Source = ts;

            Clear();
            RunButton.TouchUpInside += Calculation;
            ClearButton.TouchUpInside += ClearButton_TouchUpInside;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #region Event Hendlers
        private void ClearButton_TouchUpInside(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            KidsText.BackgroundColor = UIColor.White;
            AgeText.BackgroundColor = UIColor.White;
            NameText.BackgroundColor = UIColor.White;

            KidsText.Text = string.Empty;
            AgeText.Text = string.Empty;
            NameText.Text = string.Empty;

            DogSwitch.On = false;
            CatSwitch.On = false;
            GirlSwitch.On = false;
            BoySwitch.On = false;

            ResultLabel.Text = string.Empty;
        }

        private void Calculation(object sender, EventArgs e)
        {
            KidsText.BackgroundColor = UIColor.White;
            AgeText.BackgroundColor = UIColor.White;
            NameText.BackgroundColor = UIColor.White;

            int input = GetInputValue();

            GetResult(input);

            //TableView.ReloadData();
        }
        #endregion

        #region Data checking
        private void GetResult(int index)
        {
            switch (index)
            {
                case 1:
                    ResultLabel.Text = NameText.Text + "! " + Results.Ansver1;
                    break;
                case 2:
                    ResultLabel.Text = NameText.Text + "! " + Results.Ansver2;
                    break;
                case 31:
                    ResultLabel.Text = NameText.Text + "! " + Results.Ansver31;
                    break;
                case 32:
                    ResultLabel.Text = NameText.Text + "! " + Results.Ansver32;
                    break;
                case 4:
                    ResultLabel.Text = NameText.Text + "! " + Results.Ansver4;
                    break;
                default:
                    ResultLabel.Text = NameText.Text + "! " + Results.Ansver5;
                    break;
            }
            ts._objects.Add(ResultLabel.Text);
        }

        private bool CanCalcKids()
        {
            if (KidsText.Text == string.Empty)
            {
                kids = 0;
                return true;
            }
            else if (int.TryParse(KidsText.Text, out kids))
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
            return int.TryParse(AgeText.Text, out age) && age > 0 && age < 100;
        }

        private bool ClassicalOrientation()
        {
            return BoySwitch.On && GirlSwitch.On || GirlSwitch.On;
        }

        private bool CatLady()
        {
            return CatSwitch.On && DogSwitch.On;
        }

        private bool IsAdult()
        {
            return NormaAge() && age >= 18;
        }

        private bool IsAnotherPlanet()
        {
            return NameText.Text == string.Empty || DogSwitch.On && CatSwitch.On && BoySwitch.On && GirlSwitch.On;
        }
        #endregion

        private int GetInputValue()
        {
            int input = 0;

            if (!NormaAge() || !CanCalcKids())
            {
                AgeText.BackgroundColor = NormaAge() ? UIColor.White : UIColor.Orange;
                KidsText.BackgroundColor = CanCalcKids() ? UIColor.White : UIColor.Orange;
                NameText.BackgroundColor = (NameText.Text != string.Empty) ? UIColor.White : UIColor.Orange;
                input = 5;
            }
            else if (IsAnotherPlanet())
            {
                NameText.BackgroundColor = (NameText.Text != string.Empty) ? UIColor.White : UIColor.Orange;
                input = 4;
            }
            else if (!IsAdult())
            {
                input = 1;
            }
            else if (kids == 0)
            {
                if (CatLady() || !ClassicalOrientation() || Segments.SelectedSegment != 1)
                {
                    input = 2;
                }
                else if (Segments.SelectedSegment == 1)
                {
                    input = 32;
                }
            }
            else if (kids > 0)
            {
                if (Segments.SelectedSegment == 2)
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

    }
}