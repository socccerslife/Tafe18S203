using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartFinance.Models;

namespace StartFinance.ViewModels
{
    class AppointmentSearchViewModel : INotifyPropertyChanged
    {
        private IAppointmentRepository Db { get; }
        private Appointment appointment;

        public Appointment Appointment
        {
            get { return appointment; }
            set
            {
                if (appointment != value)
                {
                    appointment = value;
                    RaisePropertyChanged("Appointment");
                }
            }
        }

        public AppointmentSearchViewModel(int eventID)
        {
            Db = App.Data;
            appointment = Db.GetAppointmentById(eventID);
        }

        public bool SaveEditedProduct(Appointment c)
        {
            return Db.UpdateAppointment(c);
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
