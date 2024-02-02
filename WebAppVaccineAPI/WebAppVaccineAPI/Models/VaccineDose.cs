using System;
using System.Collections.Generic;

namespace WebAppVaccineAPI.Models
{
    public partial class VaccineDose
    {
        public VaccineDose()
        {
            BookForVaccines = new HashSet<BookForVaccine>();
        }

        public int NumberOfDose { get; set; }

        public virtual ICollection<BookForVaccine> BookForVaccines { get; set; }
    }
}
