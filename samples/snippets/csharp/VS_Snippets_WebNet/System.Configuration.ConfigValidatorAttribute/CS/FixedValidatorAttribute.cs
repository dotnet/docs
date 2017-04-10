// File name: FixedValidatorAttribute.cs
// Allowed snippet tags range: [21 - 30].

// <Snippet21>
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Configuration;

namespace Samples.AspNet
{
    // Show how to create a custom fixed 
    // validator. That is a validator whose
    // validation parameters are hard code in this
    // type.
    public class FixedValidator :
            ConfigurationValidatorBase
    {
       
        public override bool CanValidate(Type type)
        {
            return type == typeof(Automobile);
        }

        public override void Validate(object value)
        {

            ArrayList make = new ArrayList();

            make.Add("Ferrari");
            make.Add("Porsche");
            make.Add("Lamborghini");

            int minYear = 2004;
            long maxMiles = 100;
            string color = "red";
            
            Automobile car = (Automobile)value;


            try
            {
                if (!make.Contains(car.Make))
                {
                    throw new ConfigurationErrorsException(
                       "My dream car is not made by " + car.Make);
                }

                // Make sure the year is valid 
                if (car.Year < minYear)
                {

                    throw new ConfigurationErrorsException(
                       "My dream car cannot be older than " + minYear.ToString());

                }

                // Make sure the car can still run on its own
                if (car.Miles > maxMiles)
                {
                  throw new ConfigurationErrorsException(
                        "My dream car drive odometer cannot read more than " + 
                        maxMiles.ToString() + " miles");
  
                }

                // Validate color
                if (car.Color.ToLower() != color)
                {
                    throw new ConfigurationErrorsException(
                        "My dream car can oly be " + color);
                }

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

    }

  }
// </Snippet21>