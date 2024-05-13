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
        private string firstTerm = "";
        private string oper = "";
        private string secondTerm = "";

        public string CalExpression
        {
            get { return calExpression; }
            set
            {
                calExpression = value;
                OnPropertyChanged("CalExpression");
            }
        }

        public string FirstTerm
        {
            get { return firstTerm; }
            set
            {
                firstTerm = value;
                CalExpression = $"{firstTerm} {oper} {secondTerm}";
                OnPropertyChanged("CalExpression");
            }
        }

        public string Oper
        {
            get { return oper; }
            set
            {
                oper = value;
                CalExpression = $"{firstTerm} {oper} {secondTerm}";
                OnPropertyChanged("CalExpression");
            }
        }

        public string SecondTerm
        {
            get { return secondTerm; }
            set
            {
                secondTerm = value;
                CalExpression = $"{firstTerm} {oper} {secondTerm}";
                OnPropertyChanged("CalExpression");
            }
        }

        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
