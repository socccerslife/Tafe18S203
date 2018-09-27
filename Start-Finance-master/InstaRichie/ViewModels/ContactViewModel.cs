using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartFinance.Models;
using Windows.UI.Popups;

namespace StartFinance.ViewModels
{
    class ContactViewModel : INotifyPropertyChanged
    {
        private IContactRepository Db { get; }
        private ObservableCollection<Contact> contact;
        public ObservableCollection<Contact> Contact
        {
            get { return contact; }
            set
            {
                if (value != contact)
                {
                    contact = value;
                    NotifyPropertyChanged("Contact");
                }
            }
        }

        public ContactViewModel()
        {
            Db = App.Data;
        }
        
        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            Contact = new ObservableCollection<Models.Contact>(Db.GetContact().ToList());
            IsDataLoaded = true;
        }

        internal async void AddNewContact(Contact newContact)
        {
            if (Db.InsertContact(newContact))
            {
                MessageDialog md = new MessageDialog("Contact added to db", "INSERT OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Contact NOT added to db", "INSERT OUTCOME");
                await md.ShowAsync();
            }
        }

        internal async void DeleteContact(int contactId)
        {
            if (Db.DeleteContact(contactId))
            {
                MessageDialog md = new MessageDialog("Contact deleted from db", "DELETE OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Contact NOT deleted from db", "INSERT OUTCOME");
                await md.ShowAsync();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
