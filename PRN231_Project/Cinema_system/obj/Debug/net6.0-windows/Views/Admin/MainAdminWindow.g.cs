﻿#pragma checksum "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BF576397CB2B8315F90F93AFAAC65C548C5B8D16"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Cinema_system.Views.Admin;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Cinema_system.Views.Admin {
    
    
    /// <summary>
    /// MainAdminWindow
    /// </summary>
    public partial class MainAdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Cinema_system.Views.Admin.MainAdminWindow mainadminwindow;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainFrame;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid shadow;
        
        #line default
        #line hidden
        
        
        #line 375 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton SlideButton;
        
        #line default
        #line hidden
        
        
        #line 416 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CurrentUserName;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Cinema_system;component/views/admin/mainadminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.mainadminwindow = ((Cinema_system.Views.Admin.MainAdminWindow)(target));
            return;
            case 2:
            
            #line 41 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseLeftButtonUp_1);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 66 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 5:
            this.shadow = ((System.Windows.Controls.Grid)(target));
            
            #line 112 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
            this.shadow.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MainFrame_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 119 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
            ((MaterialDesignThemes.Wpf.ColorZone)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.mainadminwindow_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SlideButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 377 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
            this.SlideButton.Checked += new System.Windows.RoutedEventHandler(this.SlideButton_Checked);
            
            #line default
            #line hidden
            
            #line 378 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
            this.SlideButton.Unchecked += new System.Windows.RoutedEventHandler(this.SlideButton_Unchecked);
            
            #line default
            #line hidden
            
            #line 382 "..\..\..\..\..\Views\Admin\MainAdminWindow.xaml"
            this.SlideButton.Loaded += new System.Windows.RoutedEventHandler(this.SlideButton_Loaded);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CurrentUserName = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
