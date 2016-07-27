using CalcSW_XForms.Halpers;
using CalcSW_XForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalcSW_XForms.ViewModels
{
    public class CalcViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public CalcViewModel()
        {
            SetValues();
        }

        #region Binding properties
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                Name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _age = string.Empty;
        public string Age
        {
            get { return _age; }
            set {
                    Age = value;
                    OnPropertyChanged("Age");
                }
        }

        private string _kids = string.Empty;
        public string Kids
        {
            get { return _kids; }
            set {
                    Kids = value;
                    OnPropertyChanged("Kids");
                }
        }

        private bool _boys = false;
        public bool Boys
        {
            get { return _boys; }
            set
            {
                Boys = value;
                OnPropertyChanged("Boys");
            }
        }

        private bool _girls = false;
        public bool Girls
        {
            get { return _girls; }
            set
            {
                Girls = value;
                OnPropertyChanged("Girls");
            }
        }

        private bool _cats = false;
        public bool Cats
        {
            get { return _cats; }
            set
            {
                Cats = value;
                OnPropertyChanged("Cats");
            }
        }

        private bool _dogs = false;
        public bool Dogs
        {
            get { return _dogs; }
            set
            {
                Dogs = value;
                OnPropertyChanged("Dogs");
            }
        }

        private bool _career = false;
        public bool Career
        {
            get { return _career; }
            set
            {
                Career = value;
                OnPropertyChanged("Career");
            }
        }

        private bool _family = false;
        public bool Family
        {
            get { return _family; }
            set
            {
                Family = value;
                OnPropertyChanged("Family");
            }
        }

        private bool _yourself = false;
        public bool Yourself
        {
            get { return _yourself; }
            set
            {
                Yourself = value;
                OnPropertyChanged("Yourself");
            }
        }

        private string _answer = string.Empty;
        public string Answer
        {
            get { return _answer; }
            set
            {
                Answer = value;
                OnPropertyChanged("Answer");
            }
        }
        #endregion

        #region Binding commands
        public ICommand CalculateCommand
        {
            get
            {
                return new Command(() =>
                {
                    GetResult(GetInputValue());
                    //this.ShowViewModel<ListViewModel>();
                });
            }
        }
        public ICommand ClearCommand
        {
            get
            {
                return new Command(() =>
                {
                    Clear();
                    //this.ShowViewModel<CalcViewModel>();
                });
            }
        }

        #endregion

        int age;
        int kids;
        string result;

        void SetValues()
        {
            if (!BufferData.IsClear && BufferData.CurrentResult != null)
            {
                Name = BufferData.CurrentResult.Name;
                Age = BufferData.CurrentResult.Age;
                Kids = BufferData.CurrentResult.Kids;
                Cats = BufferData.CurrentResult.Cats;
                Dogs = BufferData.CurrentResult.Dogs;
                Boys = BufferData.CurrentResult.Boys;
                Girls = BufferData.CurrentResult.Girls;
                Career = BufferData.CurrentResult.Career;
                Family = BufferData.CurrentResult.Family;
                Yourself = BufferData.CurrentResult.Yourself;
            }
            BufferData.IsClear = false;
        }
        void Clear()
        {
            BufferData.IsClear = true;

            Kids = string.Empty;
            Age = string.Empty;
            Name = string.Empty;

            Dogs = false;
            Cats = false;
            Girls = false;
            Boys = false;
        }
        private int GetInputValue()
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
            else if (kids == 0)
            {
                if (CatLady() || !ClassicalOrientation() || !Family)
                {
                    input = 2;
                }
                else if (Family)
                {
                    input = 32;
                }
            }
            else if (kids > 0)
            {
                if (Yourself)
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
        private async void GetResult(int index)
        {
            switch (index)
            {
                case 1:
                    result = ResultsString.Ansver1;
                    break;
                case 2:
                    result = ResultsString.Ansver2;
                    break;
                case 31:
                    result = ResultsString.Ansver31;
                    break;
                case 32:
                    result = ResultsString.Ansver32;
                    break;
                case 4:
                    result = ResultsString.Ansver4;
                    break;
                default:
                    result = ResultsString.Ansver5;
                    break;
            }

            var currentResult = new ResultModel
            {
                Name = (string.IsNullOrEmpty(Name)) ? string.Empty : Name,
                Age = (string.IsNullOrEmpty(Age)) ? string.Empty : Age,
                Kids = (string.IsNullOrEmpty(Kids)) ? string.Empty : Kids,
                Cats = Cats,
                Dogs = Dogs,
                Boys = Boys,
                Girls = Girls,
                Career = Career,
                Family = Family,
                Yourself = Yourself,
                Answer = result
            };
            await Task.Run(() =>
            {
                if (BufferData.CurrentResult != null)
                {
                    DBHelper.Instance.Update(currentResult);
                }
                else
                {
                    DBHelper.Instance.AddResult(currentResult);
                    BufferData.CurrentResult = currentResult;
                }
            });
        }

        #region Data validating
        private bool CanCalcKids()
        {
            if (Kids == string.Empty)
            {
                kids = 0;
                return true;
            }
            else if (int.TryParse(Kids, out kids))
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
            return int.TryParse(Age, out age) && age > 0 && age < 100;
        }
        private bool ClassicalOrientation()
        {
            return Boys && Girls || Girls;
        }
        private bool CatLady()
        {
            return Cats && Cats;
        }
        private bool IsAdult()
        {
            return NormaAge() && age >= 18;
        }
        private bool IsAnotherPlanet()
        {
            return Name == string.Empty || Dogs && Cats && Girls && Boys;
        }
        #endregion
    }
}
