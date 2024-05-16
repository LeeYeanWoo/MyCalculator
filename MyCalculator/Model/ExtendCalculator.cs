using CRLArithmetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Model
{
    public class ExtendCalculator : BaseCalculator
    {
        private Arithmetic arithmetic;

        public ExtendCalculator()
        {
            arithmetic = new();
        }

        public double Percenatage(CalculatorTerm firstTerm, CalculatorTerm secondTerm)
        {
            return arithmetic.Percenatage(firstTerm.RealNum, secondTerm.RealNum);
        }
        public double Root(CalculatorTerm term)
        {
            return arithmetic.Root(term.RealNum);
        }
        public double DoubleSquare(CalculatorTerm term)
        {
            return arithmetic.DoubleSquare(term.RealNum);
        }
        public double OneInNum(CalculatorTerm term)
        {
            return arithmetic.OneInNum(term.RealNum);
        }
    }
}
