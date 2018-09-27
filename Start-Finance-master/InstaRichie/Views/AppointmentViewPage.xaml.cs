using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using StartFinance.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StartFinance.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppointmentViewPage : Page
    {
        AppointmentSearchViewModel viewModel;
        AppointmentViewModel viewModelMain;
        public AppointmentViewPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int id = (int)e.Parameter;

            if (viewModel == null)
            {
                viewModel = new AppointmentSearchViewModel(id);
                DataContext = viewModel.Appointment;
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentPage));
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            //delete the current detail
            try
            {
                int id = int.Parse(EventId.Text);
                viewModelMain.DeleteContact(id);
            }
            catch
            {
                MessageDialog md = new MessageDialog("There is no data", "No data");
                await md.ShowAsync();
                EventId.Focus(FocusState.Programmatic);
                EventId.SelectAll();
                return;
            }
            Frame.Navigate(typeof(AppointmentPage));
        }

        private void EditBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentUpdatePage), viewModel.Appointment.EventID);
        }
    }
}
