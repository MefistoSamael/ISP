using Lab1Bychko.Lab4.DomainModel.Entities;
using Lab1Bychko.Lab4.DomainModel.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab1Bychko.Lab4.ViewModel
{
    public class CurrencyConverterVM : INotifyPropertyChanged
    {
        private static List<string> requiredCur = new List<string>() {
        "USD", "RUB", "CHF", "EUR", "CNY", "GBP" };

        private IRateService rateService;

        //привязываем к Picker (в Picker указываем свойство Cur_Name)
        private List<Rate> rates;

        //public ObservableCollection<Rate> Rates { get; set; }
        public List<Rate> Rates
        {
            get => rates;
            set
            {
                if (value != rates)
                {
                    rates = value;
                    OnPropertyChanged();
                }
            }
        }

        private Rate curRate;

        public Rate CurRate
        {
            get => curRate;
            set
            {
                if (value != curRate)
                {
                    curRate = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? belValue;

        public decimal? BelValue
        {
            get => belValue;
            set
            {
                if (value != belValue && value is not null)
                {
                    belValue = value < 0 ? decimal.Negate((decimal)value) : value;
                    OnPropertyChanged();
                }

                if (value is null)
                    belValue = value;
            }
        }

        private decimal? foreignValue;

        public decimal? ForeignValue
        {
            get => foreignValue;
            set
            {
                if (value != foreignValue && value is not null)
                {
                    foreignValue = value < 0 ? decimal.Negate((decimal)value) : value;
                    OnPropertyChanged();
                }

                if(value is null)
                    foreignValue = value;
            }
        }

        public CurrencyConverterVM(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public async Task GetNBRBRates(DateTime selectedDate)
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                var allRates = await rateService.GetRates(selectedDate);

                Rates = allRates.Where(r => requiredCur.Contains(r.Cur_Abbreviation)).ToList<Rate>();
            }
            else
            {
                throw new Exception("Internet access has been lost.");
            }
        }

        public void InputBel()
        {
            if (CurRate is not null && CurRate.Cur_OfficialRate is not null
                        && belValue is not null)
            {
                ForeignValue = Math.Round((decimal)belValue * CurRate.Cur_Scale 
                                                / (decimal)CurRate.Cur_OfficialRate, 2);
            }
            else
            {
                BelValue = Decimal.Zero;
                ForeignValue = Decimal.Zero;
            }
        }

        public void InputForeign()
        {
            if (CurRate is not null && CurRate.Cur_OfficialRate is not null
                        && foreignValue is not null)
            {
                BelValue = Math.Round((decimal)foreignValue * (decimal)CurRate.Cur_OfficialRate 
                                                    / CurRate.Cur_Scale, 2);
            }
            else
            {
                BelValue = Decimal.Zero;
                ForeignValue = Decimal.Zero;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
