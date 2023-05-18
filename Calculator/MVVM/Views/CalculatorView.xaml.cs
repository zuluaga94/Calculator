using Calculator.MVVM.ViewModels;
using System.Data;

namespace Calculator.MVVM.Views;

public partial class CalculatorView : ContentPage
{
    private string _displayText = string.Empty;

    public CalculatorView()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string buttonText = button.Text;

        if (buttonText == "C")
        {
            _displayText = string.Empty;
        }
        else if (buttonText == "=")
        {
            try
            {
                var dataTable = new DataTable();
                var result = dataTable.Compute(_displayText, "");
                _displayText = result.ToString();
            }
            catch (Exception ex)
            {
                _displayText = "Error";
            }
        }
        else
        {
            _displayText += buttonText;
        }

        DisplayLabel.Text = _displayText;
    }

}

