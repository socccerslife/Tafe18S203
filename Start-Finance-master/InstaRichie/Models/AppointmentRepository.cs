using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartFinance.Models
{
    public class AppointmentRepository : IAppointmentRepository
    {
        string path;
        SQLiteConnection conn;

        public AppointmentRepository(string dbName)
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalCacheFolder.Path, dbName);
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn.CreateTable<Appointment>();
        }

        public bool DeleteAppointment(int eventId)
        {
            Appointment c = GetAppointmentById(eventId);
            if (conn.Delete(c) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Appointment> GetAppointment()
        {
            return conn.Table<Appointment>().OrderBy(c => c.EventName).ToList();
        }

        public IEnumerable<List<Appointment>> GetAppointmentList()
        {
            return conn.Table<List<Appointment>>().ToList();
        }

        public Appointment GetAppointmentById(int eventId)
        {
            var Appointment = conn.Table<Appointment>().ToList();
            return Appointment.First(c => c.EventID == eventId);
        }

        public bool InsertAppointment(Appointment appointment)
        {
            if (conn.Insert(appointment) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            if (conn.Update(appointment) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
