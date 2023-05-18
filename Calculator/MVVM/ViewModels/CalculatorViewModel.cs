using Calculator.MVVM.Models;
using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace  Calculator.MVVM.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel calculator;

        public CalculatorModel Calculator
        {
            get { return calculator; }
            set
            {
                calculator = value;
                OnPropertyChanged(nameof(Calculator));
            }
        }

        public Command AddCommand { get; }
        public Command SubtractCommand { get; }
        public Command MultiplyCommand { get; }
        public Command DivideCommand { get; }

        public CalculatorViewModel()
        {
            Calculator = new CalculatorModel();

            AddCommand = new Command(ExecuteAddCommand);
            SubtractCommand = new Command(ExecuteSubtractCommand);
            MultiplyCommand = new Command(ExecuteMultiplyCommand);
            DivideCommand = new Command(ExecuteDivideCommand);
        }

        private void ExecuteAddCommand()
        {
            Calculator.Add();
        }

        private void ExecuteSubtractCommand()
        {
            Calculator.Subtract();
        }

        private void ExecuteMultiplyCommand()
        {
            Calculator.Multiply();
        }

        private void ExecuteDivideCommand()
        {
            Calculator.Divide();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
