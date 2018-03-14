// File name: ProgrammableValidatorAttribute.cs
// Allowed snippet tags range: [31 - 40].

// <Snippet31>

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Samples.AspNet
{

    // Show how to create a custom programmable 
    // validator. That is a validator whose
    // validation parameters can be passed when the
    // validator is applied to a property.
    public class ProgrammableValidator : 
        ConfigurationValidatorBase
    {
        private string pmake;
        private string pcolor;
        private long pmaxMiles;
        private int pminYear;

        public ProgrammableValidator(string make, string color, 
            long maxMiles, int minYear)
        {
            pmake = make;
            pcolor = color;
            pminYear = minYear;
            pmaxMiles = maxMiles;
        }

        public override bool CanValidate(Type type)
        {
            return type == typeof(Automobile);
        }

        public override void Validate(object value)
        {

            Automobile car = (Automobile)value;

            try
            {

                // Validate make
                if (car.Make != pmake)
                {
                    throw new ConfigurationErrorsException(
                       "I do not by cars made by " + car.Make);
                }

                // Validate color
                if (car.Color != pcolor)
                {
                    throw new ConfigurationErrorsException(
                        "My commute car must be " + pcolor);
                }

                // Validate year
                if (car.Year < pminYear)
                {
                    throw new ConfigurationErrorsException(
                        "It's about time you get a new car.");
                }

                // Validate miles
                if (car.Miles > pmaxMiles)
                {
                    throw new ConfigurationErrorsException(
                        "Don't take too long trips with that car.");
                }

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
    }


    public class ProgrammableValidatorAttribute : 
        ConfigurationValidatorAttribute
    {
        private string pmake;
        private string pcolor;
        private int pminYear;
        private long pmaxMiles;


        public string Make
        {
            get { return pmake; }
            set { pmake = value; }
        }

        public string Color
        {
            get { return pcolor; }
            set { pcolor = value; }
        }

        public int MinYear
        {
            get { return pminYear; }
            set { pminYear = value; }
        }
        public long MaxMiles
        {
            get { return pmaxMiles; }
            set { pmaxMiles = value; }
        }

        public ProgrammableValidatorAttribute(string make, string color,
            long miles, int year)
        {
            pmake = make;
            pcolor = color;
            pminYear = year;
            pmaxMiles = miles;
            
        }
        

        public override ConfigurationValidatorBase ValidatorInstance
        {
            get
            {
                return new ProgrammableValidator(pmake, pcolor, pmaxMiles, pminYear);
            }
        }
    }

}
// </Snippet31>