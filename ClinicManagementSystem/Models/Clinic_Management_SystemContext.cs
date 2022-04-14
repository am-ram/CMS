using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClinicManagementSystem.Models
{
    public partial class Clinic_Management_SystemContext : DbContext
    {
        public Clinic_Management_SystemContext()
        {
        }

        public Clinic_Management_SystemContext(DbContextOptions<Clinic_Management_SystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<BillHeader> BillHeader { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<DoctorSchedule> DoctorSchedule { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress; Database=Clinic_Management_System; User ID=sa; Password=root123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentNo)
                    .HasName("PK__Appointm__FD01AD70F5ACA988");

                entity.Property(e => e.AppointmentNo).HasColumnName("Appointment_No");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnName("Appointment_Date")
                    .HasColumnType("date");

                entity.Property(e => e.AppointmentTime).HasColumnName("Appointment_Time");

                entity.Property(e => e.Notes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

                entity.Property(e => e.ScheduleId).HasColumnName("Schedule_Id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_patientid");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_scheduleid");
            });

            modelBuilder.Entity<BillHeader>(entity =>
            {
                entity.HasKey(e => e.BillNo)
                    .HasName("PK__Bill_Hea__CF6FA49F5879A29C");

                entity.ToTable("Bill_Header");

                entity.Property(e => e.BillNo).HasColumnName("Bill_No");

                entity.Property(e => e.AppointmentNo).HasColumnName("Appointment_No");

                entity.Property(e => e.BillAmount).HasColumnName("Bill_Amount");

                entity.Property(e => e.BillDate)
                    .HasColumnName("Bill_Date")
                    .HasColumnType("date");

                entity.Property(e => e.PaymentMethod)
                    .HasColumnName("Payment_Method")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AppointmentNoNavigation)
                    .WithMany(p => p.BillHeader)
                    .HasForeignKey(d => d.AppointmentNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_apptno");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");

                entity.Property(e => e.DoctorAddress)
                    .IsRequired()
                    .HasColumnName("Doctor_Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorCity)
                    .IsRequired()
                    .HasColumnName("Doctor_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorDescription)
                    .IsRequired()
                    .HasColumnName("Doctor_Description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorFees).HasColumnName("Doctor_Fees");

                entity.Property(e => e.DoctorGender)
                    .HasColumnName("Doctor_Gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasColumnName("Doctor_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorPhoneNo)
                    .IsRequired()
                    .HasColumnName("Doctor_Phone_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorPostalCode)
                    .IsRequired()
                    .HasColumnName("Doctor_Postal_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorState)
                    .IsRequired()
                    .HasColumnName("Doctor_State")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Specilization)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DoctorSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PK__Doctor_S__8C4D3C5B11F7C088");

                entity.ToTable("Doctor_Schedule");

                entity.Property(e => e.ScheduleId).HasColumnName("Schedule_Id");

                entity.Property(e => e.AvailableDays)
                    .IsRequired()
                    .HasColumnName("Available_Days")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");

                entity.Property(e => e.FromTime).HasColumnName("From_Time");

                entity.Property(e => e.NoOfPatients).HasColumnName("No_Of_Patients");

                entity.Property(e => e.ToTime).HasColumnName("To_Time");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorSchedule)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("fk_docid");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

                entity.Property(e => e.PatientAddress)
                    .IsRequired()
                    .HasColumnName("Patient_Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientAge).HasColumnName("Patient_Age");

                entity.Property(e => e.PatientCity)
                    .IsRequired()
                    .HasColumnName("Patient_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientDob)
                    .HasColumnName("Patient_DOB")
                    .HasColumnType("date");

                entity.Property(e => e.PatientGender)
                    .IsRequired()
                    .HasColumnName("Patient_Gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasColumnName("Patient_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientPhoneNo)
                    .IsRequired()
                    .HasColumnName("Patient_Phone_No")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatientPostalCode)
                    .IsRequired()
                    .HasColumnName("Patient_Postal_Code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatientState)
                    .IsRequired()
                    .HasColumnName("Patient_State")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.PrescriptionNo)
                    .HasName("PK__Prescrip__E82965DB8195ED04");

                entity.Property(e => e.PrescriptionNo).HasColumnName("Prescription_No");

                entity.Property(e => e.AppointmentNo).HasColumnName("Appointment_No");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");

                entity.Property(e => e.DrugName)
                    .HasColumnName("Drug_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Instruction)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AppointmentNoNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.AppointmentNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_appno");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_doctid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
