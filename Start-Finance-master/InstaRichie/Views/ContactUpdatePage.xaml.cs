using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using StartFinance.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StartFinance.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactUpdatePage : Page
    {
        ContactSearchViewModel viewModel;
        public ContactUpdatePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int id = (int)e.Parameter;

            if (viewModel == null)
            {
                viewModel = new ContactSearchViewModel(id);
                DataContext = viewModel.Contact;
            }
        }

        private async void UpdateBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Contact c = new Contact();

            //validate FirstName is empty
            if (String.IsNullOrEmpty(ConFNameTxtBox.Text))
            {
                MessageDialog md = new MessageDialog("Please write Name in field", "Wrong Name");
                await md.ShowAsync();
                ConFNameTxtBox.Focus(FocusState.Programmatic);
                ConFNameTxtBox.SelectAll();
                return;
            }
            else
            {
                c.FirstName = ConFNameTxtBox.Text;
            }

            //validate LastName is empty
            if (String.IsNullOrEmpty(ConLNameTxtBox.Text))
            {
                MessageDialog md = new MessageDialog("Please write Name in field", "Wrong Name");
                await md.ShowAsync();
                ConLNameTxtBox.Focus(FocusState.Programmatic);
                ConLNameTxtBox.SelectAll();
                return;
            }
            else
            {
                c.LastName = ConLNameTxtBox.Text;
            }

            //validate CompanyName is empty
            if (String.IsNullOrEmpty(ConCompNameTxtBox.Text))
            {
                MessageDialog md = new MessageDialog("Please write Name in field", "Wrong Company Name");
                await md.ShowAsync();
                ConCompNameTxtBox.Focus(FocusState.Programmatic);
                ConCompNameTxtBox.SelectAll();
                return;
            }
            else
            {
                c.CompanyName = ConCompNameTxtBox.Text;
            }

            //validate Mobile number is empty
            if (String.IsNullOrEmpty(MobNoTxtBox.Text))
            {
                MessageDialog md = new MessageDialog("Please write Mobile Number in field", "Wrong Mobile Number");
                await md.ShowAsync();
                MobNoTxtBox.Focus(FocusState.Programmatic);
                MobNoTxtBox.SelectAll();
                return;
            }
            else
            {
                c.MobilePhone = MobNoTxtBox.Text;
            }


            //show update is successed
            if (viewModel.SaveEditedProduct(viewModel.Contact))
            {
                MessageDialog md = new MessageDialog("Contact changes updated", "UPDATE OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Contact changes NOT updated", "UPDATE OUTCOME");
                await md.ShowAsync();
            }

            Frame.Navigate(typeof(ContactViewPage), viewModel.Contact.ContactID);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ContactPage));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ContactViewPage), viewModel.Contact.ContactID);
        }
    }
}
