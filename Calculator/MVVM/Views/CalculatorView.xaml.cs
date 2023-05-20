using Calculator.MVVM.ViewModels;
using System.Data;

namespace Calculator.MVVM.Views;

public partial class CalculatorView : ContentPage
{
  

    public CalculatorView()
    {
        InitializeComponent();
        BindingContext =new CalculatorViewModel();
    }

   
}

