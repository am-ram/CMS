using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicManagementSystem.Models;

namespace ClinicManagementSystem
{
    public class AppointmentDetails
    {
        Clinic_Management_SystemContext dbcontext = new Clinic_Management_SystemContext();
        string pname, ppno, day;
        public AppointmentDetails()
        {
            Console.WriteLine("1. Search Patient By Name ");
            Console.WriteLine("2. Search Patient By Phone No ");
            Console.WriteLine("3. View all Appointments");
            Console.WriteLine("4. Back to Menu");
            Console.WriteLine("Enter your Choice");
            int choice;
            bool state = int.TryParse(Console.ReadLine(), out choice);
            while (!state)
            {
                System.Console.Write("Invalid input. Please try again: ");
                state = int.TryParse(Console.ReadLine(), out choice);
            }
            switch (choice)
            {
                case 1:
                    SearchByName();
                    break;

                case 2:
                    SearchByPhoneNo();
                    break;

                case 3:
                    getAllAppointments();
                    break;
                case 4:
                    new Menu();
                    break;
            }
        }
        public void SearchByName()
        {
            Console.WriteLine("Enter Patient Name");
            pname = Console.ReadLine();
            if (dbcontext.Patient.Count((a) => a.PatientName == pname) == 0)
            {
                Console.WriteLine("Record doesnt exists");
                Console.WriteLine();
                Console.WriteLine("Insert Patient Details");
                new PatientDetails();
            }
            else
            {
                Console.WriteLine("Record exists");
                App();
            }
        }

        public void SearchByPhoneNo()
        {
            Console.WriteLine("Enter Patient Phone No");
            ppno = Console.ReadLine();
            if (dbcontext.Patient.Count((a) => a.PatientPhoneNo == ppno) == 0)
            {
                Console.WriteLine("Record doesnt exists!");
                Console.WriteLine();
                Console.WriteLine("Insert Patient Details");
                new PatientDetails();
            }
            else
            {
                Console.WriteLine("Record exists");
                App();
            }
        }

        public void App()
        {
            Patient pat = new Patient();
            Appointment app = new Appointment();
            using (var dbcontext = new Clinic_Management_SystemContext())
            {
                List<Patient> Patients = (from p in dbcontext.Patient select p).ToList<Patient>();
                foreach (Patient p in Patients)
                {
                    if (p.PatientName.ToLower() == pname.ToLower())
                    {
                        Console.WriteLine(p.PatientId + " " + p.PatientName + " ");
                    }
                }

                Console.WriteLine();

                Console.WriteLine("Enter Patient Id");
                app.PatientId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Appointment Date in yyyy/mm/dd format");
                app.AppointmentDate = Convert.ToDateTime(Console.ReadLine().Trim());
                day = app.AppointmentDate.ToString("dddd");
                Console.WriteLine(day);


                //Appointment time coulmn is also there..Wt shoould be done is if one person chooses a schedule from 9-10
                //And if he is the first person to take appointment for particular doctor
                //Then he should be assigned 9:00-9:10(10 mins or 15 mins etc) in the apointment column
                //Tried doing it in the below commented phrase but couldnt do


                Console.WriteLine("Enter the reason for visit");
                app.Notes = Console.ReadLine();

            //    List<DoctorSchedule> schedules = (from p in dbcontext.DoctorSchedule select p).ToList<DoctorSchedule>();
            //    List<Doctor> doctors = (from d in dbcontext.Doctor select d).ToList<Doctor>();
            //    List<Appointment> appointments = (from p in dbcontext.Appointment select p).ToList<Appointment>();
            //    var output = from d in doctors
            //                 join s in schedules on d.DoctorId equals s.DoctorId
            //                 join a in appointments on s.ScheduleId equals a.ScheduleId
            //                 select new
            //                 {
            //                     ftime = s.FromTime,
            //                     ttime = s.ToTime,
            //                     atime = a.AppointmentTime
            //                 };
            //    foreach (var v in output)
            //    {
            //        DateTime dftime = Convert.ToDateTime(v.ftime);
            //        DateTime dttime = Convert.ToDateTime(v.ttime);
            //        DateTime datime = Convert.ToDateTime(v.atime);
            //        TimeSpan span = dftime.Subtract(dttime);
            //        int endingrange = span.Hours * 2;
            //        var start = dftime;
            //        var clockQuery = from offset in Enumerable.Range(0, endingrange)
            //                         select start.AddMinutes(15 * offset);
            //        foreach (var t in clockQuery)
            //            //t.atime = t;
                        
            //        Console.WriteLine(datime.ToString("hh:mm tt"));
            //    }
            }
            Console.WriteLine();
            Console.WriteLine("Choose a schedule");
            Console.WriteLine();
            using (var dbcontext = new Clinic_Management_SystemContext())
            {
                List<DoctorSchedule> schedules = (from p in dbcontext.DoctorSchedule select p).ToList<DoctorSchedule>();
                List<Doctor> doctors = (from d in dbcontext.Doctor select d).ToList<Doctor>();

                var output = schedules.Join(
                doctors,
                doctor => doctor.DoctorId,
                schedule => schedule.DoctorId,
                (schedule, doctor) => new
                {
                    SecId = schedule.ScheduleId,
                    DocId = doctor.DoctorId,
                    DocName = doctor.DoctorName,
                    Spec = doctor.Specilization,
                    Desc = doctor.DoctorDescription,
                    Nop = schedule.NoOfPatients,
                    ADays = schedule.AvailableDays,
                    Ftime = schedule.FromTime,
                    Ttime = schedule.ToTime,
                });
                foreach (var d in output)
                {
                    if (d.ADays.ToLower().Contains(day.ToLower()))
                    {
                        Console.WriteLine(d.SecId + " " + d.DocId + " " + d.DocName + " " + d.Spec + " " + d.Desc + " " + d.Nop + " " + d.ADays + " "
                            + d.Ftime + " " + d.Ttime + " ");
                    }

                }

                Console.WriteLine("Enter the Schedule Id");
                app.ScheduleId = int.Parse(Console.ReadLine());
                var sch = output.Where(x => x.SecId == app.ScheduleId ).FirstOrDefault();
                var totappoint = (from ap in dbcontext.Appointment where ap.AppointmentDate == app.AppointmentDate select ap).Count();
                int totappleft = sch.Nop - totappoint;
                Console.WriteLine("No of Appointments left");
                Console.WriteLine(totappleft);
                //generate  appoitment time
                //get the total min the doctor will visit
                int min =Math.Abs( (sch.Ftime.Hours - sch.Ttime.Hours)*60);
                //for each patient the time required
                int eachappointtime =min/ sch.Nop;
                //find the aoppintment time for the current patient
                int tomin = eachappointtime * (totappoint + 1);
                string apptime = sch.Ftime.Hours + ":" +tomin ;
                if (tomin>59)
                {
                    int hr = tomin / 60;
                    int m = tomin % 60;
                    apptime = sch.Ftime.Hours+hr + ":" + m;
                }
                
             
                TimeSpan ts = TimeSpan.Parse(apptime);
                app.AppointmentTime = ts;
                Console.WriteLine("Appointment Time");
                Console.WriteLine(app.AppointmentTime);
                if (totappleft > 0)
                { 
                    dbcontext.Appointment.Add(app);
                }
                dbcontext.SaveChanges();
            }
        }
        public void getAllAppointments()
        {
            using (var dbcontext = new Clinic_Management_SystemContext())
            {
                List<Appointment> appointments = (from a in dbcontext.Appointment select a).ToList<Appointment>();
                foreach (Appointment ap in appointments)
                {
                    Console.WriteLine(ap.AppointmentNo + " " + ap.PatientId + " ");
                }
            }
        }
    }
}
