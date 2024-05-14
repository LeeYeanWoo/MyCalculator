using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Model
{
    class CalculatorHistory : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string expression;
        private string answer;

        private static List<CalculatorHistory> instance;

        public string Expression
        {
            get { return expression; }
            set 
            {
                expression = value;
                OnPropertyChanged("Expression");
            }
        }

        public string Answer
        {
            get { return answer; }
            set
            {
                answer = value;
                OnPropertyChanged("Answer");
            }
        }

        public static List<CalculatorHistory> GetInstance()
        {
            if (instance == null)
                instance = new List<CalculatorHistory>();

            return instance;
        }

        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
