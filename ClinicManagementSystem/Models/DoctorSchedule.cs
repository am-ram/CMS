using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClinicManagementSystem.Models
{
    public partial class DoctorSchedule
    {
        public DoctorSchedule()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int ScheduleId { get; set; }
        public int? DoctorId { get; set; }
        public int NoOfPatients { get; set; }
        public string AvailableDays { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
