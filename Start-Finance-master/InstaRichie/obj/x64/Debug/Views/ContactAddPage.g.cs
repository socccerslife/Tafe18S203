﻿#pragma checksum "C:\MyContactDetail\Tafe18S203\Start-Finance-master\InstaRichie\Views\ContactAddPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "61FBEA8719E1280EF73CECD79F928012"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StartFinance.Views
{
    partial class ContactAddPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
        };

        private class ContactAddPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IContactAddPage_Bindings
        {
            private global::StartFinance.Views.ContactAddPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.AppBarButton obj19;
            private global::Windows.UI.Xaml.Controls.AppBarButton obj20;
            private global::Windows.UI.Xaml.Controls.AppBarButton obj21;

            public ContactAddPage_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 19:
                        this.obj19 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        ((global::Windows.UI.Xaml.Controls.AppBarButton)target).Click += (global::System.Object param0, global::Windows.UI.Xaml.RoutedEventArgs param1) =>
                        {
                        this.dataRoot.ViewModel.GotoSettings();
                        };
                        break;
                    case 20:
                        this.obj20 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        ((global::Windows.UI.Xaml.Controls.AppBarButton)target).Click += (global::System.Object param0, global::Windows.UI.Xaml.RoutedEventArgs param1) =>
                        {
                        this.dataRoot.ViewModel.GotoPrivacy();
                        };
                        break;
                    case 21:
                        this.obj21 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        ((global::Windows.UI.Xaml.Controls.AppBarButton)target).Click += (global::System.Object param0, global::Windows.UI.Xaml.RoutedEventArgs param1) =>
                        {
                        this.dataRoot.ViewModel.GotoAbout();
                        };
                        break;
                    default:
                        break;
                }
            }

            // IContactAddPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // ContactAddPage_obj1_Bindings

            public void SetDataRoot(global::StartFinance.Views.ContactAddPage newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2:
                {
                    this.ViewModel = (global::StartFinance.ViewModels.MainPageViewModel)(target);
                }
                break;
            case 3:
                {
                    this.AdaptiveVisualStateGroup = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 4:
                {
                    this.VisualStateNarrow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 5:
                {
                    this.VisualStateNormal = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 6:
                {
                    this.VisualStateWide = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 7:
                {
                    this.pageHeader = (global::Template10.Controls.PageHeader)(target);
                }
                break;
            case 8:
                {
                    this.pageFooter = (global::Template10.Controls.PageHeader)(target);
                }
                break;
            case 9:
                {
                    this.TitlePanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 10:
                {
                    this.PageStart = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 11:
                {
                    this.ConFNameTxtBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12:
                {
                    this.ConLNameTxtBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13:
                {
                    this.ConCompNameTxtBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14:
                {
                    this.MobNoTxtBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 15:
                {
                    this.SubmitBarBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 103 "..\..\..\Views\ContactAddPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SubmitBarBtn).Click += this.SubmitBarBtn_Click;
                    #line default
                }
                break;
            case 16:
                {
                    this.PageTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17:
                {
                    this.Home = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 82 "..\..\..\Views\ContactAddPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Home).Click += this.Home_Click;
                    #line default
                }
                break;
            case 18:
                {
                    this.Cancel = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 83 "..\..\..\Views\ContactAddPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Cancel).Click += this.Cancel_Click;
                    #line default
                }
                break;
            case 19:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element19 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 20:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element20 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 21:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element21 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ContactAddPage_obj1_Bindings bindings = new ContactAddPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}
