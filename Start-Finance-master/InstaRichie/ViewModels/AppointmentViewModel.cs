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
    class AppointmentViewModel : INotifyPropertyChanged
    {
        private IAppointmentRepository Db { get; }
        private ObservableCollection<Appointment> appointment;
        public ObservableCollection<Appointment> Appointment
        {
            get { return appointment; }
            set
            {
                if (value != appointment)
                {
                    appointment = value;
                    NotifyPropertyChanged("Appointment");
                }
            }
        }

        public AppointmentViewModel()
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
            Appointment = new ObservableCollection<Models.Appointment>(Db.GetAppointment().ToList());
            IsDataLoaded = true;
        }

        internal async void AddNewAppointment(Appointment newAppointment)
        {
            if (Db.InsertAppointment(newAppointment))
            {
                MessageDialog md = new MessageDialog("Appointment added to db", "INSERT OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Appointment NOT added to db", "INSERT OUTCOME");
                await md.ShowAsync();
            }
        }

        internal async void DeleteContact(int EventID)
        {
            if (Db.DeleteAppointment(EventID))
            {
                MessageDialog md = new MessageDialog("Appointment deleted from db", "DELETE OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Appointment NOT deleted from db", "INSERT OUTCOME");
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
