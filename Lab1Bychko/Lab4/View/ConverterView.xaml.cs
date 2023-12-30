using Lab1Bychko.Lab4.ViewModel;

namespace Lab1Bychko.Lab4.View;

public partial class ConverterView : ContentPage
{
    CurrencyConverterVM converterVM;
    public ConverterView(CurrencyConverterVM currencyConverter)
    {
        InitializeComponent();

        CurrencyDatePicker.MinimumDate = new DateTime(1996, 1, 1);
        CurrencyDatePicker.MaximumDate = DateTime.Now;

        this.converterVM = currencyConverter;
        BindingContext = converterVM;

    }

    private void BelCur_Completed(object sender, EventArgs e)
    {
        converterVM.InputBel();
    }

    private void ForeignCur_Completed(object sender, EventArgs e)
    {
        converterVM.InputForeign();
    }

    private async void CurDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        if(CurrencyDatePicker.MaximumDate != DateTime.Now)
        {
            CurrencyDatePicker.MaximumDate = DateTime.Now;
        }

        try
        {
            await converterVM.GetNBRBRates(((DatePicker)sender).Date);
        }
        catch(Exception)
        {
            await DisplayAlert("Ошибка", "Проблемы с интернет соединением", "Понял");
        }
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        try
        {
            await converterVM.GetNBRBRates(DateTime.Now);
            await converterVM.GetNBRBRates(DateTime.Now);
            CurrencyDatePicker.Date = DateTime.Now;
        }
        catch (Exception)
        {
            await DisplayAlert("Ошибка", "Проблемы с интернет соединением", "Понял");
        }
    }
}