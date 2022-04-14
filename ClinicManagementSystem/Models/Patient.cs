using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClinicManagementSystem.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public string PatientCity { get; set; }
        public string PatientState { get; set; }
        public string PatientPostalCode { get; set; }
        public string PatientPhoneNo { get; set; }
        public string PatientGender { get; set; }
        public DateTime PatientDob { get; set; }
        public int PatientAge { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
