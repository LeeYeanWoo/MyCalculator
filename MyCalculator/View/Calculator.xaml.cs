﻿using MyCalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyCalculator
{
    public partial class Calculator : Window
    {
        private CalculatorViewModel calculatorViewModel;
        private bool isHistoryVisible = false;
        public Calculator()
        {
            InitializeComponent();
            calculatorViewModel = new CalculatorViewModel();
            DataContext = calculatorViewModel;
            HistoryListBox.ItemsSource = calculatorViewModel.GetHistoryItemsSource();
        }

        private void ToggleHistoryVisibility()
        {
            if (isHistoryVisible)
            {
                historyGrid.Visibility = Visibility.Collapsed;
                keyPadGrid.Visibility = Visibility.Visible;
                isHistoryVisible = false;
            }
            else
            {
                historyGrid.Visibility = Visibility.Visible;
                keyPadGrid.Visibility = Visibility.Collapsed;
                isHistoryVisible = true;
                HistoryListBox.SelectedIndex = HistoryListBox.Items.Count - 1;
                HistoryListBox.ScrollIntoView(HistoryListBox.SelectedItem);
            }
        }

        // 주의 : 버튼 클릭 후 포커스를 윈도우로 바꿔주지 않으면 엔터 입력시 이전 버튼 클릭 이벤트 발생
        private void HistoryButtonClick(object sender, RoutedEventArgs e)
        {
            ToggleHistoryVisibility();

            FocusManager.SetFocusedElement(this, this);
        }

        // 주의 : 버튼 클릭 후 포커스를 윈도우로 바꿔주지 않으면 엔터 입력시 이전 버튼 클릭 이벤트 발생
        private void KeyPadButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            calculatorViewModel.UserInput(btn.Content.ToString());

            FocusManager.SetFocusedElement(this, this);
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            string userCMD = "";

            if((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                switch (e.Key)
                {
                    case Key.C:
                        userCMD = "Copy";
                        break;
                    case Key.V:
                        userCMD = "Paste";
                        break;
                    default:
                        break;
                }
            }

            else if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                switch (e.Key)
                {
                    case Key.OemPlus:
                        userCMD = "+";
                        break;
                    case Key.D8:
                        userCMD = "*";
                        break;
                    case Key.D5:
                        userCMD = "%";
                        break;
                    default:
                        break;
                }
            }

            else
            {
                switch (e.Key)
                {
                    case Key.D0:
                    case Key.NumPad0:
                        userCMD = "0";
                        break;
                    case Key.D1:
                    case Key.NumPad1:
                        userCMD = "1";
                        break;
                    case Key.D2:
                    case Key.NumPad2:
                        userCMD = "2";
                        break;
                    case Key.D3:
                    case Key.NumPad3:
                        userCMD = "3";
                        break;
                    case Key.D4:
                    case Key.NumPad4:
                        userCMD = "4";
                        break;
                    case Key.D5:
                    case Key.NumPad5:
                        userCMD = "5";
                        break;
                    case Key.D6:
                    case Key.NumPad6:
                        userCMD = "6";
                        break;
                    case Key.D7:
                    case Key.NumPad7:
                        userCMD = "7";
                        break;
                    case Key.D8:
                    case Key.NumPad8:
                        userCMD = "8";
                        break;
                    case Key.D9:
                    case Key.NumPad9:
                        userCMD = "9";
                        break;
                    case Key.Add:
                        userCMD = "+";
                        break;
                    case Key.Subtract:
                    case Key.OemMinus:
                        userCMD = "-";
                        break;
                    case Key.Multiply:
                        userCMD = "×";
                        break;
                    case Key.Divide:
                    case Key.Oem2:
                        userCMD = "÷";
                        break;
                    case Key.OemPeriod:
                    case Key.Decimal:
                        userCMD = ".";
                        break;
                    case Key.OemPlus:
                    case Key.Enter:
                        userCMD = "=";
                        break;
                    case Key.Back:
                        userCMD = "≪";
                        break;
                    case Key.Delete:
                        userCMD = "C";
                        break;
                    default:
                        break;
                }
            }
            calculatorViewModel.UserInput(userCMD);
        }
    }
}
