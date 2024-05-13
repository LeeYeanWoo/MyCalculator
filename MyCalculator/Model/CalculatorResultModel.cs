using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Model
{
    public class CalculatorResultModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
            
        private string calResult = "0";
        public string CalResult 
        {
            get { return calResult; }
            set
            {
                calResult = value;
                OnPropertyChanged("CalResult");
            }
        }

        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
