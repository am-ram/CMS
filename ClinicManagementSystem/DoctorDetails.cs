using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClinicManagementSystem
{
    public class DoctorDetails
    {
        Clinic_Management_SystemContext dbcontext = new Clinic_Management_SystemContext();
        int did;
        public DoctorDetails()
        {
            Console.WriteLine("-----Doctor Details-----");
            Console.WriteLine("1. Insert Doctor ");
            Console.WriteLine("2. Update Doctor ");
            Console.WriteLine("3. Delete Doctor ");
            Console.WriteLine("4. All Doctor Details ");
            Console.WriteLine("5. Exit");
            Console.WriteLine("------------------------");
            Console.WriteLine("Enter your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());            
            
            switch (choice)
            {
                case 1:
                    insertDoctor();
                    break;
                case 2:
                    Console.WriteLine("Enter Doctor Id to Update");
                    did = int.Parse(Console.ReadLine());
                    updateDoctor();
                    getAllDoctors();
                    Console.WriteLine("Press any key to continue..");
                    break;
                case 3:
                    Console.WriteLine("Enter Doctor Id to Delete");
                    did = int.Parse(Console.ReadLine());
                    deleteDoctor();
                    getAllDoctors();
                    Console.WriteLine("Press any key to continue..");
                    break;
                case 4:
                    getAllDoctors();
                    break;
                case 5:
                    new Menu();
                    break;
            }
            
        }
        public void insertDoctor()
        {
            Doctor doc = new Doctor();
            Console.WriteLine("Enter Doctor's Name");
            doc.DoctorName=Console.ReadLine();
            Console.WriteLine("Enter Address");
            doc.DoctorAddress = Console.ReadLine();
            Console.WriteLine("Enter City");
            doc.DoctorCity = Console.ReadLine();
            Console.WriteLine("Enter State");
            doc.DoctorState = Console.ReadLine();
            Console.WriteLine("Enter Postal Code");
            doc.DoctorPostalCode = Console.ReadLine();
            Console.WriteLine("Enter Gender");
            doc.DoctorGender = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            doc.DoctorPhoneNo = Console.ReadLine();
            Console.WriteLine("Enter Specialization");
            doc.Specilization = Console.ReadLine();
            Console.WriteLine("Enter Doctor Description");
            doc.DoctorDescription = Console.ReadLine();
            Console.WriteLine("Enter Fees");
            doc.DoctorFees = float.Parse(Console.ReadLine());

            dbcontext.Doctor.Add(doc);
            dbcontext.SaveChanges();
            Console.WriteLine("RECORD INSERTED SUCCESSFULLY!");
            Console.WriteLine("Press any key to continue..");
        }

        public void updateDoctor()
        {
            using (var dbcontext = new Clinic_Management_SystemContext())
            {
                Doctor doc = (from d in dbcontext.Doctor where d.DoctorId == did select d).FirstOrDefault<Doctor>();
                if (doc != null)
                {
                    Console.WriteLine("Enter Doctor's Name");
                    doc.DoctorName = Console.ReadLine();
                    Console.WriteLine("Enter Address");
                    doc.DoctorAddress = Console.ReadLine();
                    Console.WriteLine("Enter City");
                    doc.DoctorCity = Console.ReadLine();
                    Console.WriteLine("Enter State");
                    doc.DoctorState = Console.ReadLine();
                    Console.WriteLine("Enter Postal Code");
                    doc.DoctorPostalCode = Console.ReadLine();
                    Console.WriteLine("Enter Gender");
                    doc.DoctorGender = Console.ReadLine();
                    Console.WriteLine("Enter Phone Number");
                    doc.DoctorPhoneNo = Console.ReadLine();
                    Console.WriteLine("Enter Specialization");
                    doc.Specilization = Console.ReadLine();
                    Console.WriteLine("Enter Doctor Description");
                    doc.DoctorDescription = Console.ReadLine();
                    Console.WriteLine("Enter Fees");
                    doc.DoctorFees = float.Parse(Console.ReadLine());

                    dbcontext.Doctor.Update(doc);
                    dbcontext.SaveChanges();
                    Console.WriteLine("RECORD UPDATED SUCCESSFULLY!");
                }
            }
        }

        public void deleteDoctor()
        {
            using (var dbcontext = new Clinic_Management_SystemContext())
            {
                Doctor doc = (from d in dbcontext.Doctor where d.DoctorId == did select d).FirstOrDefault<Doctor>();
                if (doc != null)
                {
                    dbcontext.Doctor.Remove(doc);
                    dbcontext.SaveChanges();
                    Console.WriteLine("RECORD DELETED SUCCESSFULLY!");
                }
            }
        }

        public List<Doctor> getAllDoctors()
        {
            using (var dbcontext = new Clinic_Management_SystemContext())
            {
                List<Doctor> doctors = (from d in dbcontext.Doctor select d).ToList<Doctor>();
                foreach (Doctor d in doctors)
                {
                    Console.WriteLine(d.DoctorId + " " + d.DoctorName + " ");
                }
                return doctors;
            }
        }
    }
}
