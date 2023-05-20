using System.ComponentModel;


namespace Calculator.MVVM.Models
{
    
    public class CalculatorModel
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operator { get; set; }
        public double Result { get; set; }
    }
}
