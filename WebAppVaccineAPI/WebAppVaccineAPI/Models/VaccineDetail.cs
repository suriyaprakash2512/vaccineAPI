using System;
using System.Collections.Generic;

namespace WebAppVaccineAPI.Models
{
    public partial class VaccineDetail
    {
        public VaccineDetail()
        {
            BookForVaccines = new HashSet<BookForVaccine>();
        }

        //public int VaccineId { get; set; }
        public string VaccineName { get; set; } = null!;
        public string? Manufacturer { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<BookForVaccine> BookForVaccines { get; set; }
    }
}
