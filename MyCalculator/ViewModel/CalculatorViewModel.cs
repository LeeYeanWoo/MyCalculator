using MyCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.ViewModel
{
    class CalculatorViewModel
    {
        private bool enterOperator = false;
        private CalculatorResultModel calResultModel;
        private CalculatorExpression calExpression;
        public CalculatorResultModel CalResultModel
        {
            get { return calResultModel; }
            set { calResultModel = value; }
        }

        public CalculatorExpression CalExpression
        {
            get { return calExpression; }
            set { calExpression = value; }
        }

        public CalculatorViewModel()
        {
            calResultModel = new();
            calExpression = new();
        }

        public void UserInput(string inputData)
        {
            switch (inputData)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case ".":
                    EnterNumber(inputData);
                    break;
                case "÷":
                case "×":
                case "-":
                case "+":
                    EnterOperator(inputData);
                    break;
                case "%":
                case "√":
                case "x²":
                case "1/x":
                    break;
                case "C":
                case "CE":
                    ClearData();
                    break;
                case "≪":
                    DeleteNumber();
                    break;
                case "±":
                    SignChange();
                    break;
                case "=":
                    Calculate();
                    break;
            }
        }

        private void Calculate()
        {
            if (calExpression.Oper.Length < 1) return;

            calExpression.SecondTerm.StrName = $"{calResultModel.CalResult} = ";
            try
            {
                calExpression.SecondTerm.RealNum = double.Parse(calResultModel.CalResult);
            }
            catch (FormatException)
            {
                ClearData();
                calResultModel.CalResult = "계산할 수 없습니다.";
            }

            switch (calExpression.Oper)
            {
                case "÷":
                    try
                    {
                        calResultModel.CalResult = calExpression.FirstTerm / calExpression.SecondTerm;
                    }
                    catch (DivideByZeroException)
                    {
                        ClearData();
                        calResultModel.CalResult = "계산할 수 없습니다.";
                    }
                    break;
                case "×":
                    calResultModel.CalResult = calExpression.FirstTerm * calExpression.SecondTerm;
                    break;
                case "-":
                    calResultModel.CalResult = calExpression.FirstTerm - calExpression.SecondTerm;
                    break;
                case "+":
                    calResultModel.CalResult = calExpression.FirstTerm + calExpression.SecondTerm;
                    break;
                default:
                    return;
            }
        }

        private void EnterOperator(string inputData)
        {
            calExpression.FirstTerm.StrName = calResultModel.CalResult;
            try
            {
                calExpression.FirstTerm.RealNum = double.Parse(calResultModel.CalResult);
            }
            catch (FormatException)
            {
                ClearData();
                calResultModel.CalResult = "계산할 수 없습니다.";
            }
            
            calExpression.Oper = inputData;

            calExpression.SecondTerm.StrName = "";

            enterOperator = true;
        }

        private void SignChange()
        {
            string target = calResultModel.CalResult;

            if (target.Equals("0")) return;

            if (target.ElementAt(0) == '-')
            {
                calResultModel.CalResult = target.Substring(1);
            }
            else
            {
                calResultModel.CalResult = $"-{target}";
            }
        }

        private void DeleteNumber()
        {
            string target = calResultModel.CalResult;

            if (target.Length <= 1)
                calResultModel.CalResult = "0";
            else
            {
                calResultModel.CalResult = target.Substring(0, target.Length - 1);
            }
        }

        private void ClearData()
        {
            calResultModel.CalResult = "0";
            calExpression.FirstTerm.Clear();
            calExpression.Oper = "";
            calExpression.SecondTerm.Clear();
        }

        private void EnterNumber(string inputData)
        {
            string target = calResultModel.CalResult;

            //이미 소수점이 있는데 또다시 . 명령어가 들어오면 무시한다.
            if (target.Contains(".") && inputData.Equals(".")) 
                return;

            if (string.Equals(target, "0") || enterOperator)
            {
                if (enterOperator) enterOperator = false;
                calResultModel.CalResult = $"{inputData}";
            }
            else 
                calResultModel.CalResult = $"{calResultModel.CalResult}{inputData}";
        }
    }
}
