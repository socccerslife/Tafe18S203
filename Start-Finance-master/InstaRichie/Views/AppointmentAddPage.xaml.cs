﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using StartFinance.Models;
using StartFinance.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StartFinance.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppointmentAddPage : Page
    {
        private AppointmentViewModel viewModel;
        public AppointmentAddPage()
        {
            this.InitializeComponent();
            viewModel = new AppointmentViewModel();
        }

        private async void SubmitBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Appointment c = new Appointment();

            //validate FirstName is empty
            if (String.IsNullOrEmpty(AppNameTxtBox.Text))
            {
                MessageDialog md = new MessageDialog("Please write Name in field", "Wrong Name");
                await md.ShowAsync();
                AppNameTxtBox.Focus(FocusState.Programmatic);
                AppNameTxtBox.SelectAll();
                return;
            }
            else
            {
                c.EventName = AppNameTxtBox.Text;
            }

            //validate LastName is empty
            if (String.IsNullOrEmpty(AppLocTxtBox.Text))
            {
                MessageDialog md = new MessageDialog("Please write the Location in field", "Wrong Location");
                await md.ShowAsync();
                AppLocTxtBox.Focus(FocusState.Programmatic);
                AppLocTxtBox.SelectAll();
                return;
            }
            else
            {
                c.EventLocation = AppLocTxtBox.Text;
            }

            //validate CompanyName is empty
            if (String.IsNullOrEmpty(StartTimeTxtBox.Text))
            {
                MessageDialog md = new MessageDialog("Please write Time in field", "Wrong Start Time");
                await md.ShowAsync();
                StartTimeTxtBox.Focus(FocusState.Programmatic);
                StartTimeTxtBox.SelectAll();
                return;
            }
            else
            {
                c.EventStartTime = StartTimeTxtBox.Text;
            }

            //validate Mobile number is empty
            if (String.IsNullOrEmpty(EndTimeTxtBox.Text))
            {
                MessageDialog md = new MessageDialog("Please write Time in field", "Wrong End Time");
                await md.ShowAsync();
                EndTimeTxtBox.Focus(FocusState.Programmatic);
                EndTimeTxtBox.SelectAll();
                return;
            }
            else
            {
                c.EventEndTime = EndTimeTxtBox.Text;
            }

            viewModel.AddNewAppointment(c);


            Frame.Navigate(typeof(AppointmentPage));
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentPage));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentPage));
        }

    }
}
