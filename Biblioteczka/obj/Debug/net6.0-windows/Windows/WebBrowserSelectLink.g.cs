#pragma checksum "..\..\..\..\Windows\WebBrowserSelectLink.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82D35EFA56948CE4E0177B538A6D61B8678DF143"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Biblioteczka.Windows;
using Microsoft.Web.WebView2.Wpf;
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


namespace Biblioteczka.Windows {
    
    
    /// <summary>
    /// WebBrowserSelectLink
    /// </summary>
    public partial class WebBrowserSelectLink : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonBack;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonForward;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox uriTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonLoad;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonRefresh;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Web.WebView2.Wpf.WebView2 webView;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSave;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Biblioteczka;component/windows/webbrowserselectlink.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.buttonBack = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
            this.buttonBack.Click += new System.Windows.RoutedEventHandler(this.buttonBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonForward = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
            this.buttonForward.Click += new System.Windows.RoutedEventHandler(this.buttonForward_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.uriTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
            this.uriTextBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.uriTextBox_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonLoad = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
            this.buttonLoad.Click += new System.Windows.RoutedEventHandler(this.buttonLoad_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
            this.buttonRefresh.Click += new System.Windows.RoutedEventHandler(this.buttonRefresh_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.webView = ((Microsoft.Web.WebView2.Wpf.WebView2)(target));
            
            #line 43 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
            this.webView.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.webView_CoreWebView2InitializationCompleted);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
            this.webView.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.WebView2_NavigationCompleted);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
            this.webView.NavigationStarting += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs>(this.webView_NavigationStarting);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buttonSave = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
            this.buttonSave.Click += new System.Windows.RoutedEventHandler(this.buttonSave_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.buttonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\Windows\WebBrowserSelectLink.xaml"
            this.buttonCancel.Click += new System.Windows.RoutedEventHandler(this.buttonCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

