using MyCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

namespace MyCalculator.ViewModel
{
    class CalculatorViewModel
    {
        private bool enterOperator = false;
        private bool finishCalculate = false;
        private CalculatorResult calResult;
        private CalculatorExpression calExpression;
        private ExtendCalculator myCalculator;

        public CalculatorResult CalResult
        {
            get { return calResult; }
            set { calResult = value; }
        }

        public CalculatorExpression CalExpression
        {
            get { return calExpression; }
            set { calExpression = value; }
        }

        public CalculatorViewModel()
        {
            calResult = new();
            calExpression = new();
            myCalculator = new();
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
                case "Copy":
                    Copy();
                    break;
                case "Paste":
                    Paste();
                    break;
                default:
                    break;
            }
        }
        public ObservableCollection<CalculatorHistory> GetHistoryItemsSource()
        {
            return CalculatorHistory.GetInstance();
        }

        private void Paste()
        {
            string ClipboardData = Clipboard.GetText();
            try
            {
                _ = double.Parse(ClipboardData);
                calResult.CalResult = ClipboardData;
            }
            catch (FormatException)
            {
                ClearData();
                calResult.CalResult = "잘못된 입력입니다.";
            }

        }

        private void Copy()
        {
            Clipboard.SetText(calResult.CalResult);
        }

        /*
            주의 : 첫 항만 있을때의 단항 연산과 두 번째 항까지 있을때의 단항 연산에 주의
            두 번째 항까지 있을때의 단항 연산은 단항 연산을 먼저 수행 후 다항 연산 실행
         */
        private void UnaryOperator(string inputData)
        {
            if(calExpression.Oper.Length < 1 || finishCalculate)
            {
                UpdateDataFirstTerm(calResult.CalResult);
                calExpression.Oper = "";
                calExpression.SecondTerm.Clear();

                switch (inputData)
                {
                    case "%":
                        break;
                    case "√":
                        calResult.CalResult = $"{myCalculator.Root(calExpression.FirstTerm)}";
                        UpdateDataFirstTerm($"√{calExpression.FirstTerm.RealNum}");
                        break;
                    case "x²":
                        calResult.CalResult = $"{myCalculator.DoubleSquare(calExpression.FirstTerm)}";
                        UpdateDataFirstTerm($"({calExpression.FirstTerm.RealNum})²");
                        break;
                    case "1/x":
                        calResult.CalResult = $"{myCalculator.OneInNum(calExpression.FirstTerm)}";
                        UpdateDataFirstTerm($"1/({calExpression.FirstTerm.RealNum})");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                UpdateDataSecondTerm(calResult.CalResult);
                switch (inputData)
                {
                    case "%":
                        calResult.CalResult = $"{myCalculator.Percenatage(calExpression.FirstTerm, calExpression.SecondTerm)}";
                        UpdateDataSecondTerm(calResult.CalResult);
                        break;
                    case "√":
                        calResult.CalResult = $"{myCalculator.Root(calExpression.SecondTerm)}";
                        UpdateDataSecondTerm($"√{calExpression.SecondTerm.RealNum}");
                        break;
                    case "x²":
                        calResult.CalResult = $"{myCalculator.DoubleSquare(calExpression.SecondTerm)}";
                        UpdateDataSecondTerm($"({calExpression.SecondTerm.RealNum})²");
                        break;
                    case "1/x":
                        calResult.CalResult = $"{myCalculator.OneInNum(calExpression.SecondTerm)}";
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
                UpdateDataSecondTerm($"{calResult.CalResult} =");

            switch (calExpression.Oper)
            {
                case "÷":
                    try
                    {
                        calResult.CalResult = myCalculator.Divide(calExpression.FirstTerm, calExpression.SecondTerm);
                    }
                    catch (DivideByZeroException)
                    {
                        ClearData();
                        calResult.CalResult = "계산할 수 없습니다.";
                    }
                    break;
                case "×":
                    calResult.CalResult = myCalculator.Multiply(calExpression.FirstTerm, calExpression.SecondTerm);
                    break;
                case "-":
                    calResult.CalResult = myCalculator.Sub(calExpression.FirstTerm, calExpression.SecondTerm);
                    break;
                case "+":
                    calResult.CalResult = myCalculator.Sum(calExpression.FirstTerm, calExpression.SecondTerm);
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
                , Answer = $"{calResult.CalResult}" });
        }

        private void EnterOperator(string inputData)
        {
            UpdateDataFirstTerm(calResult.CalResult);
            
            calExpression.Oper = inputData;

            calExpression.SecondTerm.StrName = "";

            finishCalculate = false;
            enterOperator = true;
        }

        private void SignChange()
        {
            string target = calResult.CalResult;

            if (target.Equals("0")) return;

            if (target.ElementAt(0) == '-')
            {
                calResult.CalResult = target.Substring(1);
            }
            else
            {
                calResult.CalResult = $"-{target}";
            }
        }

        private void DeleteNumber()
        {
            string target = calResult.CalResult;

            if (target.Length <= 1)
                calResult.CalResult = "0";
            else
            {
                calResult.CalResult = target.Substring(0, target.Length - 1);
            }
        }

        private void ClearData()
        {
            calResult.CalResult = "0";
            calExpression.FirstTerm.Clear();
            calExpression.Oper = "";
            calExpression.SecondTerm.Clear();
        }

        //주의 : 이미 소수점이 있는데 또다시 . 명령어가 들어오면 무시한다.
        private void EnterNumber(string inputData)
        {
            if (finishCalculate)
            {
                ClearData();
                finishCalculate = false;
            }

            string target = calResult.CalResult;

            if (target.Contains(".") && inputData.Equals(".")) 
                return;

            if (string.Equals(target, "0") || enterOperator)
            {
                if (enterOperator) enterOperator = false;
                calResult.CalResult = $"{inputData}";
            }
            else 
                calResult.CalResult = $"{calResult.CalResult}{inputData}";
        }

        private void UpdateDataFirstTerm(string termName)
        {
            calExpression.FirstTerm.StrName = termName;
            try
            {
                calExpression.FirstTerm.RealNum = double.Parse(calResult.CalResult);
            }
            catch (FormatException)
            {
                ClearData();
                calResult.CalResult = "계산할 수 없습니다.";
            }
        }

        private void UpdateDataSecondTerm(string termName)
        {
            calExpression.SecondTerm.StrName = termName;
            try
            {
                calExpression.SecondTerm.RealNum = double.Parse(calResult.CalResult);
            }
            catch (FormatException)
            {
                ClearData();
                calResult.CalResult = "계산할 수 없습니다.";
            }
        }
    }
}
