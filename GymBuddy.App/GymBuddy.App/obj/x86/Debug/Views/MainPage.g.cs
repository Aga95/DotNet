﻿#pragma checksum "C:\Users\Aga\Desktop\GymBuddy.App\GymBuddy.App\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FAA2943E622B402B6D92655CC7B0C44C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymBuddy.App.Views
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Button element1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 17 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element1).Click += this.AddDay;
                    #line default
                }
                break;
            case 2:
                {
                    this.Dates = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 3:
                {
                    this.Name = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.Lifted = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.Sets = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 23 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.GoToLogg;
                    #line default
                }
                break;
            case 7:
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 24 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Click += this.GoToProfile;
                    #line default
                }
                break;
            case 8:
                {
                    this.ProfileCB = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 9:
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 37 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.Button_Click;
                    #line default
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
            return returnValue;
        }
    }
}

