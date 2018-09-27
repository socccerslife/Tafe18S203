using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartFinance.Models;

namespace StartFinance.ViewModels
{
    class ContactSearchViewModel : INotifyPropertyChanged
    {
        private IContactRepository Db { get; }
        private Contact contact;

        public Contact Contact
        {
            get { return contact; }
            set
            {
                if (contact != value)
                {
                    contact = value;
                    RaisePropertyChanged("Contact");
                }
            }
        }

        public ContactSearchViewModel(int contactId)
        {
            Db = App.Data;
            contact = Db.GetContactById(contactId);
        }

        public bool SaveEditedProduct(Contact c)
        {
            return Db.UpdateContact(c);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            var eh = PropertyChanged;
            if (eh != null)
                eh(this, new PropertyChangedEventArgs(propname));
        }
    }
}
