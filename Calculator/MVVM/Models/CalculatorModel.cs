using System.ComponentModel;


namespace Calculator.MVVM.Models
{
    public class CalculatorModel : INotifyPropertyChanged
    {
        private double operand1;
        private double operand2;
        private double result;

        public double Operand1
        {
            get { return operand1; }
            set
            {
                operand1 = value;
                OnPropertyChanged(nameof(Operand1));
            }
        }

        public double Operand2
        {
            get { return operand2; }
            set
            {
                operand2 = value;
                OnPropertyChanged(nameof(Operand2));
            }
        }

        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public void Add()
        {
            Result = Operand1 + Operand2;
        }

        public void Subtract()
        {
            Result = Operand1 - Operand2;
        }

        public void Multiply()
        {
            Result = Operand1 * Operand2;
        }

        public void Divide()
        {
            if (Operand2 != 0)
                Result = Operand1 / Operand2;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

