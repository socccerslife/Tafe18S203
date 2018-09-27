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
    public sealed partial class ContactPage : Page
    {
        ContactSearchViewModel viewModelS;

        public ContactPage()
        {
            this.InitializeComponent();
        }

        private async void SearchBarBtn_Click(object sender, RoutedEventArgs e)
        {
            MainListBox.Items.Clear();
            int numberI;

            //validate
            if (!String.IsNullOrEmpty(ContIDTxtBox.Text))
            {
                //validate search section is numeric
                try
                {
                    numberI = int.Parse(ContIDTxtBox.Text);
                }
                catch
                {
                    MessageDialog md = new MessageDialog("Please wrtie numberic in this field", "Wrong type method");
                    await md.ShowAsync();
                    ContIDTxtBox.Text = string.Empty;
                    ContIDTxtBox.Focus(FocusState.Programmatic);
                    ContIDTxtBox.SelectAll();
                    return;
                }

                //validate data is exist
                try
                {
                    viewModelS = new ContactSearchViewModel(int.Parse(ContIDTxtBox.Text));
                    this.DataContext = viewModelS;
                    //this.MainListBox.Items.Add(viewModelS.Contact);
                    //Frame.Navigate(typeof(ContactViewPage), viewModelS.Contact.ContactID);
                }
                catch
                {
                    MessageDialog md = new MessageDialog("There is no data with that ID", "No Data Exist");
                    await md.ShowAsync();
                    ContIDTxtBox.Text = string.Empty;
                    ContIDTxtBox.Focus(FocusState.Programmatic);
                    ContIDTxtBox.SelectAll();
                    return;
                }

                try
                {
                    Frame.Navigate(typeof(ContactViewPage), viewModelS.Contact.ContactID);
                }
                catch
                {
                    MessageDialog md = new MessageDialog("There is no data with that ID", "No Data Exist");
                    await md.ShowAsync();
                    ContIDTxtBox.Text = string.Empty;
                    ContIDTxtBox.Focus(FocusState.Programmatic);
                    ContIDTxtBox.SelectAll();
                    return;
                }

            }

            else
            {
                MessageDialog md = new MessageDialog("There is no data with that information", "NO DATA");
                await md.ShowAsync();
                ContIDTxtBox.Text = string.Empty;
                ContIDTxtBox.Focus(FocusState.Programmatic);
                ContIDTxtBox.SelectAll();
                return;
            }

            ContIDTxtBox.SelectAll();


        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ContactAddPage));
        }

        private async void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var contact = MainListBox.SelectedItem as Contact;
            //if (contact != null)
            //{
            //    Frame.Navigate(typeof(ContactViewPage), contact.ContactID);
            //}
            try
            {
                Frame.Navigate(typeof(ContactViewPage), contact.ContactID);
            }
            catch
            {
                MessageDialog md = new MessageDialog("There is no data with that ID", "No Data Exist");
                await md.ShowAsync();
                ContIDTxtBox.Text = string.Empty;
                ContIDTxtBox.Focus(FocusState.Programmatic);
                ContIDTxtBox.SelectAll();
                return;
            }


            MainListBox.SelectedIndex = -1;
        }
    }
}
