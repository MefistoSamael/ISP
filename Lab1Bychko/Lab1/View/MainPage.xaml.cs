using Lab1Bychko.Lab1.ViewModel;

namespace Lab1Bychko.Lab1.View;
interface MyPage
{
    void ShowOnlyNumbers();   
}

public partial class MainPage : ContentPage, MyPage
{
    LU lU;
	public MainPage()
	{
		InitializeComponent();
        
        lU = new LU();
	    BindingContext= lU;
    }

    private void OnButtonPercentClicked(object sender, EventArgs e)
    {
        lU.EnteredPercent();
    }

    private void OnButtonDeleteClicked(object sender, EventArgs e)
    {
        lU.EnteredDelete();
    }

    private void OnButtonDenomClicked(object sender, EventArgs e)
    {
        lU.EnteredFraction();
    }

    private void OnButtonSquareClicked(object sender, EventArgs e)
    {
        lU.EnteredSquare();
    }

    private void OnButtonSqrtClicked(object sender, EventArgs e)
    {
        lU.EnteredSqrt();
    }

    private void OnButtonBinaryOperationClicked(object sender, EventArgs e)
    {
        string operation = "";
        if (sender is Button)
            operation = ((Button)sender).Text;

        lU.EnteredBinaryOperation(operation);

    }

    private void OnButtonDigitClicked(object sender, EventArgs e)
    {
        string digit = "";
        if (sender is Button)
            digit = ((Button)sender).Text;

        lU.EnteredNumber(digit);
    }

    private void OnButtonNegateClicked(object sender, EventArgs e)
    {
        lU.EnteredNegate();
    }

    private void OnButtonAnswerClicked(object sender, EventArgs e)
    {
        lU.EnteredAnswer();
    }

    private void OnButtonClearClicked(object sender, EventArgs e)
    {
        lU.EnteredClear();
    }

    private void OnButtonClearEvrythingClicked(object sender, EventArgs e)
    {
        lU.EnteredClearEvrything();
    }

    public void ShowOnlyNumbers()
    {
        throw new NotImplementedException();
    }

    private void OnButtonCommaClicked(object sender, EventArgs e)
    {
        lU.EnteredComma();
    }

    private void OnButtonTaskClicked(object sender, EventArgs e)
    {
        lU.EnteredTask();
    }
}

