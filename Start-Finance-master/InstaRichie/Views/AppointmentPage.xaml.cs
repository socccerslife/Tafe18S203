using System;
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
    public sealed partial class AppointmentPage : Page
    {
        AppointmentSearchViewModel viewModelS;
        AppointmentViewModel viewModel;
        public AppointmentPage()
        {
            this.InitializeComponent();
            viewModel = new AppointmentViewModel();
            if (!viewModel.IsDataLoaded) { viewModel.LoadData(); }

            DataContext = viewModel;
            this.Loaded += new RoutedEventHandler(AppointmentPage_Loaded);
            
        }

        private async void SearchBarBtn_Click(object sender, RoutedEventArgs e)
        {
            MainListBox.Items.Clear();
            int numberI;

            //validate
            if (!String.IsNullOrEmpty(EventIDTxtBox.Text))
            {
                //validate search section is numeric
                try
                {
                    numberI = int.Parse(EventIDTxtBox.Text);
                }
                catch
                {
                    MessageDialog md = new MessageDialog("Please wrtie numberic in this field", "Wrong type method");
                    await md.ShowAsync();
                    EventIDTxtBox.Text = string.Empty;
                    EventIDTxtBox.Focus(FocusState.Programmatic);
                    EventIDTxtBox.SelectAll();
                    return;
                }

                //validate data is exist
                try
                {
                    viewModelS = new AppointmentSearchViewModel(int.Parse(EventIDTxtBox.Text));
                    this.DataContext = viewModelS;
                    this.MainListBox.Items.Add(viewModelS.Appointment);
                    //Frame.Navigate(typeof(ContactViewPage), viewModelS.Contact.ContactID);
                }
                catch
                {
                    MessageDialog md = new MessageDialog("There is no data with that ID", "No Data Exist");
                    await md.ShowAsync();
                    EventIDTxtBox.Text = string.Empty;
                    EventIDTxtBox.Focus(FocusState.Programmatic);
                    EventIDTxtBox.SelectAll();
                    return;
                }

                //try
                //{
                //    Frame.Navigate(typeof(ContactViewPage), viewModelS.Contact.ContactID);
                //}
                //catch
                //{
                //    MessageDialog md = new MessageDialog("There is no data with that ID", "No Data Exist");
                //    await md.ShowAsync();
                //    ContIDTxtBox.Text = string.Empty;
                //    ContIDTxtBox.Focus(FocusState.Programmatic);
                //    ContIDTxtBox.SelectAll();
                //    return;
                //}

            }

            else
            {
                MessageDialog md = new MessageDialog("There is no data with that information", "NO DATA");
                await md.ShowAsync();
                EventIDTxtBox.Text = string.Empty;
                EventIDTxtBox.Focus(FocusState.Programmatic);
                EventIDTxtBox.SelectAll();
                return;
            }

            EventIDTxtBox.SelectAll();


        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentAddPage));
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var appointment = MainListBox.SelectedItem as Appointment;
        /*    try
            {
                Frame.Navigate(typeof(AppointmentViewPage), appointment.EventID);
            }
            catch
            {
                MessageDialog md = new MessageDialog("There is no data with that ID", "No Data Exist");
                await md.ShowAsync();
                EventIDTxtBox.Text = string.Empty;
                EventIDTxtBox.Focus(FocusState.Programmatic);
                EventIDTxtBox.SelectAll();
                return;
            }*/
            if (appointment !=null)
            {
                Frame.Navigate(typeof(AppointmentViewPage), appointment.EventID);
            }


            MainListBox.SelectedIndex = -1;
        }
        private void AppointmentPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!viewModel.IsDataLoaded)
            {
                viewModel.LoadData();
            }
   
        }
    }
}
