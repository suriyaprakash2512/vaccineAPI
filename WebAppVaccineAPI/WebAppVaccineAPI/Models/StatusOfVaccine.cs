using System;
using System.Collections.Generic;

namespace WebAppVaccineAPI.Models
{
    public partial class StatusOfVaccine
    {
        public StatusOfVaccine()
        {
            BookForVaccines = new HashSet<BookForVaccine>();
        }

        public string Status { get; set; } = null!;

        public virtual ICollection<BookForVaccine> BookForVaccines { get; set; }
    }
}
