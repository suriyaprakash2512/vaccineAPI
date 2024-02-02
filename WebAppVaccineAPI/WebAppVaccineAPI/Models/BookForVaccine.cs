using System;
using System.Collections.Generic;

namespace WebAppVaccineAPI.Models
{
    public partial class BookForVaccine
    {
        public int BookingId { get; set; }
        public string? VaccineName { get; set; }
        public string? CityName { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public int? DatetimeId { get; set; }
        public int? NumberOfDose { get; set; }
        public string? Status { get; set; }

        public virtual Location? CityNameNavigation { get; set; }
        public virtual DateTimeSlot? Datetime { get; set; }
        public virtual VaccineDose? NumberOfDoseNavigation { get; set; }
        public virtual StatusOfVaccine? StatusNavigation { get; set; }
        public virtual UserDetail? User { get; set; }
        public virtual VaccineDetail? VaccineNameNavigation { get; set; }
    }
}
