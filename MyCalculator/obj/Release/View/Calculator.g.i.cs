﻿#pragma checksum "..\..\..\View\Calculator.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "51D5B51DC0FDA398F6365CFFC2A6AA3AB731B812A2499491F375ADC6E14A4034"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using MyCalculator;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MyCalculator {
    
    
    /// <summary>
    /// Calculator
    /// </summary>
    public partial class Calculator : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\View\Calculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid historyGrid;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\Calculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox HistoryListBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\View\Calculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid keyPadGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyCalculator;component/view/calculator.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Calculator.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\View\Calculator.xaml"
            ((MyCalculator.Calculator)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.KeyDownEvent);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 24 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HistoryButtonClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.historyGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.HistoryListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.keyPadGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            
            #line 82 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 86 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 90 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 94 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 99 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 103 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 107 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 111 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 116 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 120 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 124 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 128 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 133 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 137 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 141 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 145 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 150 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 154 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 158 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 162 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 167 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 171 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 175 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 179 "..\..\..\View\Calculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.KeyPadButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

