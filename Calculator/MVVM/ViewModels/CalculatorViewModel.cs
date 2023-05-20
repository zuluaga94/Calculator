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

        public CalculatorViewModel()
        {
            _calculator = new CalculatorModel();
            NumberCommand = new Command<string>(AppendNumber);
            OperatorCommand = new Command<string>(SetOperator);
            ClearCommand = new Command(Clear);
            EqualCommand = new Command(PerformCalculation);
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
