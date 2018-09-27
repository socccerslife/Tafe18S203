using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartFinance.Models
{
    public class Appointment
    {
        [PrimaryKey AutoIncrement]
        public int EventID { get; private set; }
        [NotNull]
        public string EventName { get; set; }
        [NotNull]
        public string EventLocation { get; set; }
        [Unique]
        public string EventStartTime { get; set; }
        [Unique]
        public string EventEndTime { get; set; }
        [Unique]
        public string EventDate { get; set; }
    }
}
