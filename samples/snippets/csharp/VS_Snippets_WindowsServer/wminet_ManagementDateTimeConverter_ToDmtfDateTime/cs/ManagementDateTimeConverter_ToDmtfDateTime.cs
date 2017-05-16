//<Snippet1>
using System;
using System.Management;

// The sample below demonstrates the various conversions
// that can be done using ManagementDateTimeConverter class    
class Sample_ManagementDateTimeConverterClass
{
    public static int Main(string[] args) 
    {
        string dmtfDate = "20020408141835.999999-420";
        string dmtfTimeInterval = "00000010122532:123456:000";
        
        // Converting DMTF datetime to System.DateTime
        DateTime dt = 
            ManagementDateTimeConverter.ToDateTime(dmtfDate);
   
        // Converting System.DateTime to DMTF datetime
        string dmtfDateTime = 
            ManagementDateTimeConverter.ToDmtfDateTime(DateTime.Now);

        // Converting DMTF time interval to System.TimeSpan
        System.TimeSpan tsRet = 
            ManagementDateTimeConverter.ToTimeSpan(dmtfTimeInterval);

        //Converting System.TimeSpan to DMTF time interval format
        System.TimeSpan ts = 
            new System.TimeSpan(10,12,25,32,456);
        string dmtfTimeInt  = 
            ManagementDateTimeConverter.ToDmtfTimeInterval(ts);
        
        return 0;
    }
}
//</Snippet1>