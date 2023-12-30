using Lab1Bychko.Lab3.ViewModel;

namespace Lab1Bychko.Lab3.View;

public partial class SushiSetView : ContentPage
{
	SetViewModel _SetViewModel;

    public SushiSetView(SetViewModel vm)
	{
		InitializeComponent();
        _SetViewModel = vm;
        BindingContext = _SetViewModel;
    }

    private void SetPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SetPicker.SelectedIndex == -1)
            return;
        _SetViewModel.ChangedSushiSet(SetPicker.SelectedIndex + 1);
    }
}