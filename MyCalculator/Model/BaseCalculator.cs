using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Model
{
    public class BaseCalculator
    {
        public string Sum(CalculatorTerm firstTerm, CalculatorTerm secondTerm)
        {
            return firstTerm + secondTerm;
        }
        public string Sub(CalculatorTerm firstTerm, CalculatorTerm secondTerm)
        {
            return firstTerm - secondTerm;
        }
        public string Multiply(CalculatorTerm firstTerm, CalculatorTerm secondTerm)
        {
            return firstTerm * secondTerm;
        }
        public string Divide(CalculatorTerm firstTerm, CalculatorTerm secondTerm)
        {
            return firstTerm / secondTerm;
        }
    }
}
