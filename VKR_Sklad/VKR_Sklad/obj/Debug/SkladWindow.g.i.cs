﻿#pragma checksum "..\..\SkladWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "826799A8D0686C475010D6D26AF700988F93F1DD827CEA80FC52D11FAF8200D0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
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


namespace VKR_Sklad {
    
    
    /// <summary>
    /// SkladWindow
    /// </summary>
    public partial class SkladWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 56 "..\..\SkladWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button but_barcode;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\SkladWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button otwet_barcode;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\SkladWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button but_back;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\SkladWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button but_exit;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\SkladWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\SkladWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button but_add;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\SkladWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox_sort;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\SkladWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox_filtr;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\SkladWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid memberDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/VKR_Sklad;component/skladwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SkladWindow.xaml"
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
            
            #line 11 "..\..\SkladWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            
            #line 11 "..\..\SkladWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.but_barcode = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\SkladWindow.xaml"
            this.but_barcode.Click += new System.Windows.RoutedEventHandler(this.but_barcode_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.otwet_barcode = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\SkladWindow.xaml"
            this.otwet_barcode.Click += new System.Windows.RoutedEventHandler(this.but_barcode_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.but_back = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\SkladWindow.xaml"
            this.but_back.Click += new System.Windows.RoutedEventHandler(this.but_back_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.but_exit = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\SkladWindow.xaml"
            this.but_exit.Click += new System.Windows.RoutedEventHandler(this.but_exit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 118 "..\..\SkladWindow.xaml"
            this.txtSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.but_add = ((System.Windows.Controls.Button)(target));
            
            #line 136 "..\..\SkladWindow.xaml"
            this.but_add.Click += new System.Windows.RoutedEventHandler(this.but_add_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.comboBox_sort = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.comboBox_filtr = ((System.Windows.Controls.ComboBox)(target));
            
            #line 181 "..\..\SkladWindow.xaml"
            this.comboBox_filtr.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBox_filtr_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.memberDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 9:
            
            #line 171 "..\..\SkladWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 171 "..\..\SkladWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 172 "..\..\SkladWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 172 "..\..\SkladWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 184 "..\..\SkladWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 184 "..\..\SkladWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            break;
            case 14:
            
            #line 227 "..\..\SkladWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_but_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

