using System;
using System.Collections.Generic;

namespace WebAppVaccineAPI.Models
{
    public partial class DateTimeSlot
    {
        public DateTimeSlot()
        {
            BookForVaccines = new HashSet<BookForVaccine>();
        }

        public int DatetimeId { get; set; }
        public DateTime? DateTimings { get; set; }

        public virtual ICollection<BookForVaccine> BookForVaccines { get; set; }
    }
}
