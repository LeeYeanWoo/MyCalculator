using MyCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRLArithmetic;
using System.Collections.ObjectModel;

namespace MyCalculator.ViewModel
{
    class CalculatorViewModel
    {
        private bool enterOperator = false;
        private bool finishCalculate = false;
        private CalculatorResultModel calResultModel;
        private CalculatorExpression calExpression;
        private Arithmetic arithmetic;

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
            arithmetic = new CRLArithmetic.Arithmetic();
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
                    UnaryOperator(inputData);
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

        public ObservableCollection<CalculatorHistory> GetHistoryItemsSource()
        {
            return CalculatorHistory.GetInstance();
        }

        private void UnaryOperator(string inputData)
        {
            if(calExpression.Oper.Length < 1 || finishCalculate)
            {
                UpdateDataFirstTerm(calResultModel.CalResult);
                calExpression.Oper = "";
                calExpression.SecondTerm.Clear();

                switch (inputData)
                {
                    case "%":
                        break;
                    case "√":
                        calResultModel.CalResult = $"{arithmetic.Root(calExpression.FirstTerm.RealNum)}";
                        UpdateDataFirstTerm($"√{calExpression.FirstTerm.RealNum}");
                        break;
                    case "x²":
                        calResultModel.CalResult = $"{arithmetic.DoubleSquare(calExpression.FirstTerm.RealNum)}";
                        UpdateDataFirstTerm($"({calExpression.FirstTerm.RealNum})²");
                        break;
                    case "1/x":
                        calResultModel.CalResult = $"{arithmetic.OneInNum(calExpression.FirstTerm.RealNum)}";
                        UpdateDataFirstTerm($"1/({calExpression.FirstTerm.RealNum})");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                UpdateDataSecondTerm(calResultModel.CalResult);
                switch (inputData)
                {
                    case "%":
                        calResultModel.CalResult = $"{arithmetic.Percenatage(calExpression.FirstTerm.RealNum, calExpression.SecondTerm.RealNum)}";
                        UpdateDataSecondTerm(calResultModel.CalResult);
                        break;
                    case "√":
                        calResultModel.CalResult = $"{arithmetic.Root(calExpression.SecondTerm.RealNum)}";
                        UpdateDataSecondTerm($"√{calExpression.SecondTerm.RealNum}");
                        break;
                    case "x²":
                        calResultModel.CalResult = $"{arithmetic.DoubleSquare(calExpression.SecondTerm.RealNum)}";
                        UpdateDataSecondTerm($"({calExpression.SecondTerm.RealNum})²");
                        break;
                    case "1/x":
                        calResultModel.CalResult = $"{arithmetic.OneInNum(calExpression.SecondTerm.RealNum)}";
                        UpdateDataSecondTerm($"1/({calExpression.SecondTerm.RealNum})");
                        break;
                    default:
                        break;
                }

                Calculate();
            }


        }

        private void Calculate()
        {
            if (calExpression.Oper.Length < 1) return;

            
            if(calExpression.SecondTerm.StrName.Length > 0)
                UpdateDataSecondTerm($"{calExpression.SecondTerm.StrName} =");
            else
                UpdateDataSecondTerm($"{calResultModel.CalResult} =");

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

            WriteHistory();
            finishCalculate = true;
        }

        private void WriteHistory()
        {
            CalculatorHistory.GetInstance()
                .Add(new CalculatorHistory() 
                { Expression = $"{calExpression.FirstTerm.StrName} {calExpression.Oper} {calExpression.SecondTerm.StrName}"
                , Answer = $"{calResultModel.CalResult}" });
        }

        private void EnterOperator(string inputData)
        {
            UpdateDataFirstTerm(calResultModel.CalResult);
            
            calExpression.Oper = inputData;

            calExpression.SecondTerm.StrName = "";

            finishCalculate = false;
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
            if (finishCalculate)
            {
                ClearData();
                finishCalculate = false;
            }

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

        private void UpdateDataFirstTerm(string termName)
        {
            calExpression.FirstTerm.StrName = termName;
            try
            {
                calExpression.FirstTerm.RealNum = double.Parse(calResultModel.CalResult);
            }
            catch (FormatException)
            {
                ClearData();
                calResultModel.CalResult = "계산할 수 없습니다.";
            }
        }

        private void UpdateDataSecondTerm(string termName)
        {
            calExpression.SecondTerm.StrName = termName;
            try
            {
                calExpression.SecondTerm.RealNum = double.Parse(calResultModel.CalResult);
            }
            catch (FormatException)
            {
                ClearData();
                calResultModel.CalResult = "계산할 수 없습니다.";
            }
        }
    }
}
