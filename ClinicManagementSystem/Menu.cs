using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicManagementSystem
{
    public class Menu
    {
        public Menu()
        {

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("*********************Main Menu*********************");
                Console.WriteLine("1. Doctor Details");
                Console.WriteLine("2. Doctor Schedule Details");
                Console.WriteLine("3. Appointment and Patient Details");
                Console.WriteLine("4. Prescription and Billing");
                Console.WriteLine("5. Exit");
                Console.WriteLine("***************************************************");
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
                        new DoctorDetails();
                        break;
                    case 2:
                        new DoctorScheduleDetails();
                        break;
                    case 3:
                        new AppointmentDetails();
                        break;
                    case 4:
                        new PrescriptionAndBillingDetails();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}
