using System;
using System.Collections;
using System.Globalization;

namespace ca1024
{
    //<snippet1>
    public class Appointment
    {
        static long nextAppointmentID;
        static double[] discountScale = { 5.0, 10.0, 33.0 };
        string customerName;
        long customerID;
        DateTime when;

        // Static constructor.
        static Appointment()
        {
            // Initializes the static variable for Next appointment ID.
        }

        // This method violates the rule, but should not be a property.
        // This method has an observable side effect. 
        // Calling the method twice in succession creates different results.
        public static long GetNextAvailableID()
        {
            nextAppointmentID++;
            return nextAppointmentID - 1;
        }

        // This method violates the rule, but should not be a property.
        // This method performs a time-consuming operation. 
        // This method returns an array.
        public Appointment[] GetCustomerHistory()
        {
            // Connect to a database to get the customer's appointment history.
            return LoadHistoryFromDB(customerID);
        }

        // This method violates the rule, but should not be a property.
        // This method is static but returns a mutable object.
        public static double[] GetDiscountScaleForUpdate()
        {
            return discountScale;
        }

        // This method violates the rule, but should not be a property.
        // This method performs a conversion.
        public string GetWeekDayString()
        {
            return DateTimeFormatInfo.CurrentInfo.GetDayName(when.DayOfWeek);
        }

        // These methods violate the rule and should be properties.
        // They each set or return a piece of the current object's state.

        public DayOfWeek GetWeekDay()
        {
            return when.DayOfWeek;
        }

        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }

        public string GetCustomerName()
        {
            return customerName;
        }

        public void SetCustomerID(long customerID)
        {
            this.customerID = customerID;
        }

        public long GetCustomerID()
        {
            return customerID;
        }

        public void SetScheduleTime(DateTime when)
        {
            this.when = when;
        }

        public DateTime GetScheduleTime()
        {
            return when;
        }

        // Time-consuming method that is called by GetCustomerHistory.
        Appointment[] LoadHistoryFromDB(long customerID)
        {
            ArrayList records = new ArrayList();
            // Load from database.
            return (Appointment[])records.ToArray();
        }
    }
    //</snippet1>
}
