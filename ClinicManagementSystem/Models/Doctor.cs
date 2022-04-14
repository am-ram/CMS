using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClinicManagementSystem.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            DoctorSchedule = new HashSet<DoctorSchedule>();
            Prescription = new HashSet<Prescription>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorAddress { get; set; }
        public string DoctorCity { get; set; }
        public string DoctorState { get; set; }
        public string DoctorPostalCode { get; set; }
        public string DoctorPhoneNo { get; set; }
        public string DoctorGender { get; set; }
        public string Specilization { get; set; }
        public string DoctorDescription { get; set; }
        public double DoctorFees { get; set; }

        public virtual ICollection<DoctorSchedule> DoctorSchedule { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
