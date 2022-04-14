using System;
using System.Collections.Generic;
using System.Text;
using ClinicManagementSystem.Models;
using System.Linq;

namespace ClinicManagementSystem
{
    public class DoctorScheduleDetails
    {
        Clinic_Management_SystemContext dbcontext = new Clinic_Management_SystemContext();
        int sid;int? did;
        public DoctorScheduleDetails()
        {
            Console.WriteLine("--Doctor Schedule Details--");
            Console.WriteLine("1. Insert Schedule ");
            Console.WriteLine("2. Update Schedule ");
            Console.WriteLine("3. Delete Schedule ");
            Console.WriteLine("4. All Doctor's Schedule Details ");
            Console.WriteLine("5. Exit");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    insertSchedule();
                    break;
                case 2:
                    Console.WriteLine("Enter Schedule Id to Update");
                    sid = int.Parse(Console.ReadLine());
                    updateSchedule();
                    getAllSchedules();
                    Console.WriteLine("Press any key to continue..");
                    break;
                case 3:
                    Console.WriteLine("Enter Schedule Id to Delete");
                    sid = int.Parse(Console.ReadLine());
                    deleteSchedule();
                    getAllSchedules();
                    Console.WriteLine("Press any key to continue..");
                    break;
                case 4:
                    getAllSchedules();
                    break;
                case 5:
                    new Menu();
                    break;
            }

        }
        public void insertSchedule()
        {
            DoctorSchedule sec = new DoctorSchedule();
            Console.WriteLine("Enter Doctor's Id");
            while (true)
            {
                sec.DoctorId = int.Parse(Console.ReadLine());
                did = sec.DoctorId;
                if (dbcontext.Doctor.Count((a) => a.DoctorId == sec.DoctorId) == 0)
                {
                    Console.WriteLine("Doctor is not available");
                    Console.WriteLine("Doctors available");
                    List<Doctor> doctors = (from d in dbcontext.Doctor select d).ToList<Doctor>();
                    foreach (Doctor d in doctors)
                    {
                        Console.WriteLine(d.DoctorId + " " + d.DoctorName + " ");
                    }
                    Console.WriteLine("Enter Doctor's Id");
                }
                else
                {
                    break;
                }
            }
            
            Console.WriteLine("Enter the No of Patients the doctor visits");
            sec.NoOfPatients = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Available Days");
            sec.AvailableDays = Console.ReadLine();
            Console.WriteLine("Enter From Time");
            sec.FromTime = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("Enter To Time");
            sec.ToTime = TimeSpan.Parse(Console.ReadLine());

            dbcontext.DoctorSchedule.Add(sec);
            dbcontext.SaveChanges();
            Console.WriteLine("RECORD INSERTED SUCCESSFULLY!");
            Console.WriteLine("Press any key to continue..");
        }

        public void updateSchedule()
        {
            using (var dbcontext = new Clinic_Management_SystemContext())
            {
                DoctorSchedule sec = (from d in dbcontext.DoctorSchedule where d.ScheduleId == sid select d).FirstOrDefault<DoctorSchedule>();
                if (sec != null)
                {
                    Console.WriteLine("Enter Doctor's Id");
                    sec.DoctorId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the No of Patients the doctor visits");
                    sec.NoOfPatients = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Available Days");
                    sec.AvailableDays = Console.ReadLine();
                    Console.WriteLine("Enter From Time");
                    sec.FromTime = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Enter To Time");
                    sec.ToTime = TimeSpan.Parse(Console.ReadLine());

                    dbcontext.DoctorSchedule.Update(sec);
                    dbcontext.SaveChanges();
                    Console.WriteLine("RECORD UPDATED SUCCESSFULLY!");
                }
            }
        }

        public void deleteSchedule()
        {
            using (var dbcontext = new Clinic_Management_SystemContext())
            {
                DoctorSchedule sec = (from d in dbcontext.DoctorSchedule where d.ScheduleId == sid select d).FirstOrDefault<DoctorSchedule>();
                if (sec != null)
                {
                    dbcontext.DoctorSchedule.Remove(sec);
                    dbcontext.SaveChanges();
                    Console.WriteLine("RECORD DELETED SUCCESSFULLY!");
                }
            }
        }

        public void getAllSchedules()
        {
            using (var dbcontext = new Clinic_Management_SystemContext())
            {
                List<DoctorSchedule> Schedules = (from d in dbcontext.DoctorSchedule select d).ToList<DoctorSchedule>();
                foreach (DoctorSchedule ds in Schedules)
                {
                    Console.WriteLine(ds.ScheduleId + " " + ds.DoctorId + " ");
                }
            }
        }
    }
}