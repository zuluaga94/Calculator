using Calculator.MVVM.Models;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Windows.Input;

namespace  Calculator.MVVM.ViewModels
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
                _calculator.FirstNumber = double.Parse(DisplayText);
                _calculator.Operator = op;
                DisplayText += op;
            }
        }


        private void Clear()
            {
            //alculator.FirstNumber = null;
            //_calculator.Operator = null;
            DisplayText = string.Empty;
            }

        private void PerformCalculation()
        {
            if (!string.IsNullOrEmpty(DisplayText) && _calculator.FirstNumber != null && !string.IsNullOrEmpty(_calculator.Operator))
            {
                var secondNumberText = DisplayText.Substring(DisplayText.IndexOf(_calculator.Operator, StringComparison.Ordinal) + 1);
                _calculator.SecondNumber = double.Parse(secondNumberText);

                switch (_calculator.Operator)
                {
                    case "+":
                        _calculator.Result = _calculator.FirstNumber + _calculator.SecondNumber;
                        break;
                    case "-":
                        _calculator.Result = _calculator.FirstNumber - _calculator.SecondNumber;
                        break;
                    case "*":
                        _calculator.Result = _calculator.FirstNumber * _calculator.SecondNumber;
                        break;
                    case "C":
                        _calculator.Result = 0;
                        break;
                    case "/":
                        if (_calculator.SecondNumber != 0)
                        {
                            _calculator.Result = _calculator.FirstNumber / _calculator.SecondNumber;
                        }
                        else
                        {
                            // Manejo de la división por cero
                            _calculator.Result = 0;
                        }
                        break;
                }

                DisplayText = _calculator.Result.ToString();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
