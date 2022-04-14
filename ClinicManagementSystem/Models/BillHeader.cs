using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClinicManagementSystem.Models
{
    public partial class BillHeader
    {
        public int BillNo { get; set; }
        public string PaymentMethod { get; set; }
        public int AppointmentNo { get; set; }
        public DateTime BillDate { get; set; }
        public double BillAmount { get; set; }

        public virtual Appointment AppointmentNoNavigation { get; set; }
    }
}
