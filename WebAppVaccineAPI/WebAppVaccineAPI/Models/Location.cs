using System;
using System.Collections.Generic;

namespace WebAppVaccineAPI.Models
{
    public partial class Location
    {
        public Location()
        {
            BookForVaccines = new HashSet<BookForVaccine>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;

        public virtual ICollection<BookForVaccine> BookForVaccines { get; set; }
    }
}
