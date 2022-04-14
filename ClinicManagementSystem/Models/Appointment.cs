using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClinicManagementSystem.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            BillHeader = new HashSet<BillHeader>();
            Prescription = new HashSet<Prescription>();
        }

        public int AppointmentNo { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public int ScheduleId { get; set; }
        public int PatientId { get; set; }
        public string Notes { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual DoctorSchedule Schedule { get; set; }
        public virtual ICollection<BillHeader> BillHeader { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
