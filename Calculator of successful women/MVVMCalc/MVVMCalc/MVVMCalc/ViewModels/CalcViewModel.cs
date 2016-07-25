using MVVMCalc.Services;
using MvvmCross.Core.ViewModels;

namespace MVVMCalc.ViewModels
{
    public class CalcViewModel 
        : MvxViewModel
    {
        private readonly IDataBaseService _servise;

        public CalcViewModel(IDataBaseService servise)
        {
            _servise = servise;
            SetValues();
        }

        #region Binding properties
        private string _name = string.Empty;
        public string Name
        { 
            get { return _name; }
            set { SetProperty (ref _name, value); }
        }

        private string _age = string.Empty;
        public string Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        private string _kids = string.Empty;
        public string Kids
        {
            get { return _kids; }
            set { SetProperty(ref _kids, value); }
        }

        private bool _boys = false;
        public bool Boys
        {
            get { return _boys; }
            set { SetProperty(ref _boys, value); }
        }

        private bool _girls = false;
        public bool Girls
        {
            get { return _girls; }
            set { SetProperty(ref _girls, value); }
        }

        private bool _cats = false;
        public bool Cats
        {
            get { return _cats; }
            set { SetProperty(ref _cats, value); }
        }

        private bool _dogs = false;
        public bool Dogs
        {
            get { return _dogs; }
            set { SetProperty(ref _dogs, value); }
        }

        private bool _career = false;
        public bool Career
        {
            get { return _career; }
            set { SetProperty(ref _career, value); }
        }

        private bool _family = false;
        public bool Family
        {
            get { return _family; }
            set { SetProperty(ref _family, value); }
        }

        private bool _yourself = false;
        public bool Yourself
        {
            get { return _yourself; }
            set { SetProperty(ref _yourself, value); }
        }

        private string _answer = string.Empty;
        public string Answer
        {
            get { return _answer; }
            set { SetProperty(ref _answer, value); }
        }
        #endregion

        #region Binding commands
        public IMvxCommand CalculateCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    GetResult(GetInputValue());
                    this.ShowViewModel<ListViewModel>();
                });
            }
        }
        public IMvxCommand ClearCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Clear();
                    this.ShowViewModel<CalcViewModel>();
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

            //if (!DataBaseHelper.Instance.IsClear && DataBaseHelper.Instance.Current != null)
            //{
            //    Name = DataBaseHelper.Instance.Current.Name;
            //    Age = DataBaseHelper.Instance.Current.Age;
            //    Kids = DataBaseHelper.Instance.Current.Kids;
            //    Cats = DataBaseHelper.Instance.Current.Cats;
            //    Dogs = DataBaseHelper.Instance.Current.Dogs;
            //    Boys = DataBaseHelper.Instance.Current.Boys;
            //    Girls = DataBaseHelper.Instance.Current.Girls;
            //    Career = DataBaseHelper.Instance.Current.Career;
            //    Family = DataBaseHelper.Instance.Current.Family;
            //    Yourself = DataBaseHelper.Instance.Current.Yourself;
            //}
            //DataBaseHelper.Instance.IsClear = false;
        }
        void Clear()
        {
            BufferData.IsClear = true;
            //DataBaseHelper.Instance.IsClear = true;

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
        private void GetResult(int index)
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

            if (BufferData.CurrentResult != null)
            {
                this._servise.Update(currentResult);
            }
            else
            {
                this._servise.AddResult(currentResult);
                BufferData.CurrentResult = currentResult;
            }
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
