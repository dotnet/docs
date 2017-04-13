// File name: AutomobileConverter.cs
// Allowed snippet tags range: [1 - 10].

// <Snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using System.Globalization;

namespace Samples.AspNet
{
    // The AutomobileConverter converts between the Automobile
    // object and its related configuration commute and
    // dream attribute string values. 
    public sealed class AutomobileConverter :
    ConfigurationConverterBase
    {
       
        internal bool ValidateType(object value,
            Type expected)
        {
            bool result;

            if ((value != null) &&
                (value.GetType() != expected))
                result = false;
            else
                result = true;

            return result;
        }



        public override bool CanConvertTo(
            ITypeDescriptorContext ctx, Type type)
        {
            return (type == typeof(Automobile));
        }


        public override bool CanConvertFrom(
            ITypeDescriptorContext ctx, Type type)
        {
            return (type == typeof(Automobile));
        }



        public override object ConvertTo(
            ITypeDescriptorContext ctx, CultureInfo ci,
            object value, Type type)
        {
            string data;

            if (ValidateType(value, typeof(Automobile)))
            {
                string make = (string)(((Automobile)value).Make);
                string color = (string)(((Automobile)value).Color);
                string miles = (string)(((Automobile)value).Miles.ToString());
                string year = (string)(((Automobile)value).Year.ToString());

                data = "Make:" + make + " Color:" + color + 
                        " Miles:" + miles + " Year:" + year;

            }
            else
                data = "Invalid type";

            return data;
        }

        public override object ConvertFrom(
            ITypeDescriptorContext ctx, CultureInfo ci, object data)
        {
            Automobile selectedCar = 
                new Automobile();
 
            string carInfo  = (string)data;

            string[] carSpecs = carInfo.Split(new Char[] { ' ' });

            // selectedCar.Make = carSpecs[0].ToString();
            // selectedCar.Make = carSpecs[0].ToString();

            string make = 
                carSpecs[(int)Automobile.specification.make].ToString();
            string color =
                carSpecs[(int)Automobile.specification.color].ToString();
            string miles =
                carSpecs[(int)Automobile.specification.miles].ToString();
            string year =
                carSpecs[(int)Automobile.specification.year].ToString();
            
           
            selectedCar.Make = 
                make.Substring(make.IndexOf(":")+1);
            selectedCar.Color = 
                color.Substring(color.IndexOf(":") + 1);
            selectedCar.Miles = 
                Convert.ToInt32(miles.Substring(miles.IndexOf(":") + 1));
            selectedCar.Year = 
                Convert.ToInt32(year.Substring(year.IndexOf(":") + 1));
            
            return selectedCar;
        }


    }

}
// </Snippet1>