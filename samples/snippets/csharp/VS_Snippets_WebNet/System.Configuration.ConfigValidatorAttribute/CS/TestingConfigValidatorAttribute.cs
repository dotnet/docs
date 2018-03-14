// File name: TestingConfigValidatorAttribute.cs
// Allowed snippet tags range: [41 - 50].

// <Snippet41>

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Samples.AspNet
{

    class TestingConfigValidatorAttribute
    {
        static TestingConfigValidatorAttribute()
        {
            try
            {

                SelectCar car;

                // Get the current configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Create the section entry for the selected car.
                if (config.Sections["Cars"] == null)
                {
                    
                    car = new SelectCar();
                    
                    config.Sections.Add("Cars", car);
                    
                    car.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);

                }

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

      
        private static void GetCars()
        {

            try
            {
                // Get the current configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the Cars section.
                SelectCar cars =
                    config.GetSection("Cars") as SelectCar;

                Console.WriteLine("Dream Make: {0} Color: {1} Miles: {2} Year: {3}",
                    cars.Dream.Make, cars.Dream.Color,
                    cars.Dream.Miles, cars.Dream.Year);

                Console.WriteLine("Commute Make: {0} Color: {1} Miles: {2} Year: {3}",
                    cars.Commute.Make, cars.Commute.Color,
                    cars.Commute.Miles, cars.Commute.Year);

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }


        private static void NotAllowedCars()
        {

            try
            {
                // Get the current configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                Automobile dreamCar = new Automobile();
                dreamCar.Color = "Red";
                dreamCar.Make = "BMW";
                dreamCar.Miles = 10;
                dreamCar.Year = 2005;

                Automobile commuteCar = new Automobile();
                commuteCar.Color = "Blue";
                commuteCar.Make = "Yugo";
                commuteCar.Miles = 10;
                commuteCar.Year = 1990;

                // Get the Cars section.
                SelectCar cars =
                    config.GetSection("Cars") as SelectCar;

                cars.Dream = dreamCar;
                cars.Commute = commuteCar;

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        static void Main(string[] args)
        {
            GetCars();
            NotAllowedCars();
    
        }

    }
}
// </Snippet41>