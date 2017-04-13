// File name: AutomobileSection.cs
// Allowed snippet tags range: [11 - 20].

// <Snippet11>
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using System.Globalization;

namespace Samples.AspNet
{
    // Define the distinctive 
    // charecteristics of a car.
    public sealed class Automobile
    {
        public enum specification
        {
            make=0, color=1, miles=2, year=3, picture=4
        };

        public string Make;
        public string Color;
        public int Year;
        public long Miles;
        public string Picture;
    }

    // Define a custom section to select a car.
    // This section contains two properties one
    // to define a commute car the other 
    // to define a dream car.
    // This generates a configuration section such as:
    // <Cars commute="Make:AlfaRomeo Color:Blue Miles:10000 Year:2002"
    // dream="Make:Ferrari Color:Red Miles:10 Year:2005" />
    public sealed class SelectCar :
        ConfigurationSection
    {
        // Define your commute car.
        // The ProgrammableValidatorAttribute allows you to define the 
        // chracteristics of your commute car by changing
        // the values you pass to the next.
        // See the ProgrammableValidatorAttribute for details.
        [ProgrammableValidator("AlfaRomeo", "Blue", 10000, 2002)]
        
        // The AutomobileConverter converts between the Automobile
        // object and its related configuration commute attribute 
        // string value. 
        // Refer to AutomobileConverter for details.
        [TypeConverter(typeof(AutomobileConverter))]
        
        // Define the name of the configuration attribute to associate
        // with this property. Enter the default values.
        // Remember these default values must reflect the parameters
        // you entered in the ProgrammableValidator above.
        [ConfigurationProperty("commute", DefaultValue = "Make:AlfaRomeo Color:Blue Miles:10000 Year:2002")]
        public Automobile Commute
        {
            get
            {
                return (Automobile)this["commute"];
            }
            set
            {
                this["commute"] = value;
            }

        }

        // Apply the FixedValidatorAttribute. Here your choice 
        // (dream) is predetermined by the values contained in the
        // FixedValidatorAttribute. Being a dream, you would think 
        // otherwise but that's not the case.
        // See the FixedValidatorAttribute to choose your dream.
         [ConfigurationValidatorAttribute(
          typeof(FixedValidator))]

        // The AutomobileConverter converts between the Automobile
        // object and its related configuration dream attribute 
        // string value. 
        // Refer to AutomobileConverter for details.
        [TypeConverter(typeof(AutomobileConverter))]
        
        [ConfigurationProperty("dream", DefaultValue = "Make:Ferrari Color:Red Miles:10 Year:2005")]
        public Automobile Dream
        {
            get
            {
                return (Automobile)this["dream"];
            }
            set
            {
                this["dream"] = value;
            }

        }

        public SelectCar()
        {
            // Here you put your 
            // initializations, if necessary.
        }
    }    

}
// </Snippet11>