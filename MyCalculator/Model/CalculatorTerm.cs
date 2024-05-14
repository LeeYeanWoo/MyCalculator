using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Model
{
    class CalculatorTerm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string strName = "";
        private double realNum = 0.0;

        public string StrName
        {
            get { return strName; }
            set
            {
                strName = value;
                OnPropertyChanged("StrName");
            }
        }
        public double RealNum
        {
            get { return realNum; }
            set
            {
                realNum = value;
                OnPropertyChanged("RealNum");
            }
        }

        public void Clear()
        {
            StrName = "";
            RealNum = 0.0;
        }

        public static string operator +(CalculatorTerm firstTerm, CalculatorTerm secondTerm)
        {
            double calResult = firstTerm.RealNum + secondTerm.RealNum;
            return $"{calResult:0.#########}";
        }

        public static string operator -(CalculatorTerm firstTerm, CalculatorTerm secondTerm)
        {
            double calResult = firstTerm.RealNum - secondTerm.RealNum;
            return $"{calResult:0.#########}";
        }

        public static string operator *(CalculatorTerm firstTerm, CalculatorTerm secondTerm)
        {
            double calResult = firstTerm.RealNum * secondTerm.RealNum;
            return $"{calResult:0.#########}";
        }

        public static string operator /(CalculatorTerm firstTerm, CalculatorTerm secondTerm)
        {
           if(secondTerm.RealNum != 0)
            {
                double calResult = firstTerm.RealNum / secondTerm.RealNum;
                return $"{calResult:0.#########}";
            }
            throw new DivideByZeroException();
        }

        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
