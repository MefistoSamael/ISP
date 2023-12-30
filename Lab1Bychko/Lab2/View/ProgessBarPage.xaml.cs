using Lab1Bychko.Lab2.ViewModel;

namespace Lab1Bychko.Lab2.View;
public partial class ProgessBarPage : ContentPage
{
   ProgressBarVM progressBar;
    public ProgessBarPage()
	{
		InitializeComponent();

        progressBar = new ProgressBarVM();
        BindingContext = progressBar;
	}

    private void OnButtonStartClicked(object sender, EventArgs e)
    {
        progressBar.StartEvaluating();
    }

    private void OnButtonCancelClicked(object sender, EventArgs e)
    {
        progressBar.StopEvaluating();
    }
}