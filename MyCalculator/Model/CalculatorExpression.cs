using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Model
{
    class CalculatorExpression : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string calExpression = "";
        private CalculatorTerm firstTerm;
        private string oper = "";
        private CalculatorTerm secondTerm;

        public string CalExpression
        {
            get { return calExpression; }
            set
            {
                calExpression = value;
                OnPropertyChanged("CalExpression");
            }
        }

        public CalculatorTerm FirstTerm
        {
            get { return firstTerm; }
            set
            {
                firstTerm = value;
                CalExpression = $"{firstTerm.StrName} {oper} {secondTerm.StrName}";
                OnPropertyChanged("FirstTerm");
            }
        }

        public string Oper
        {
            get { return oper; }
            set
            {
                oper = value;
                CalExpression = $"{firstTerm.StrName} {oper} {secondTerm.StrName}";
                OnPropertyChanged("Oper");
            }
        }

        public CalculatorTerm SecondTerm
        {
            get { return secondTerm; }
            set
            {
                secondTerm = value;
                CalExpression = $"{firstTerm.StrName} {oper} {secondTerm.StrName}";
                OnPropertyChanged("SecondTerm");
            }
        }

        public CalculatorExpression()
        {
            firstTerm = new CalculatorTerm();
            secondTerm = new CalculatorTerm();
        }

        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
