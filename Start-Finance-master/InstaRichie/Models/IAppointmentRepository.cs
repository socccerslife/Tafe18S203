using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartFinance.Models
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAppointment();
        IEnumerable<List<Appointment>> GetAppointmentList();
        Appointment GetAppointmentById(int eventId);
        bool InsertAppointment(Appointment appointment);
        bool DeleteAppointment(int eventId);
        bool UpdateAppointment(Appointment appointment);
    }
}
