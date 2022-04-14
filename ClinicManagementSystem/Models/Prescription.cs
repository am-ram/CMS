using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClinicManagementSystem.Models
{
    public partial class Prescription
    {
        public int PrescriptionNo { get; set; }
        public int AppointmentNo { get; set; }
        public int DoctorId { get; set; }
        public string DrugName { get; set; }
        public int? Frequency { get; set; }
        public string Instruction { get; set; }

        public virtual Appointment AppointmentNoNavigation { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
