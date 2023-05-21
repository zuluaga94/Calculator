using Calculator.MVVM.Models;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace Calculator.MVVM.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _calculator;

        private string _displayText;
        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public ICommand NumberCommand { get; }
        public ICommand OperatorCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand EqualCommand { get; }
        public ICommand BackspaceCommand { get; }
        public ICommand PercentageCommand { get; }
        public ICommand NegateCommand { get; }

        public CalculatorViewModel()
        {
            _calculator = new CalculatorModel();
            NumberCommand = new Command<string>(AppendNumber);
            OperatorCommand = new Command<string>(SetOperator);
            ClearCommand = new Command(Clear);
            EqualCommand = new Command(PerformCalculation);
            BackspaceCommand = new Command(Backspace);
            PercentageCommand = new Command(CalculatePercentage);
            NegateCommand = new Command(NegateNumber);
        }

        private void AppendNumber(string number)
        {
            DisplayText += number;
        }

        private void SetOperator(string op)
        {
            if (!string.IsNullOrEmpty(DisplayText))
            {
                DisplayText += op;
            }
        }

        private void Clear()
        {
            _calculator.FirstNumber = 0;
            _calculator.Operator = null;
            DisplayText = string.Empty;
        }

        private void PerformCalculation()
        {
            if (!string.IsNullOrEmpty(DisplayText))
            {
                var dataTable = new DataTable();
                 var result = dataTable.Compute(DisplayText, "");
                DisplayText = result.ToString();
            }
        }

        private void Backspace()
        {
            if (!string.IsNullOrEmpty(DisplayText))
            {
                DisplayText = DisplayText.Substring(0, DisplayText.Length - 1);
            }
        }

        private void CalculatePercentage()
        {
            if (!string.IsNullOrEmpty(DisplayText))
            {
                var dataTable = new DataTable();
                var expression = $"{DisplayText}/100";
                var result = dataTable.Compute(expression, "");
                DisplayText = result.ToString();
            }
        }

        private void NegateNumber()
        {
            if (!string.IsNullOrEmpty(DisplayText))
            {
                if (double.TryParse(DisplayText, out double number))
                {
                    number *= -1;
                    DisplayText = number.ToString();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
