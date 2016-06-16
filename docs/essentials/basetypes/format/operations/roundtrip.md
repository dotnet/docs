# How to: Round-trip Date and Time Values

In many applications, a date and time value is intended to unambiguously identify a single point in time. This topic shows how to save and restore a [DateTime](http://dotnet.github.io/api/System.DateTime.html) value, and a [DateTimeOffset](http://dotnet.github.io/api/System.DateTimeOffset.html) value so that the restored value identifies the same time as the saved value.

## To round-trip a DateTime value

1. Convert the [DateTime](http://dotnet.github.io/api/System.DateTime.html) value to its string representation by calling the [DateTime.ToString(String)](http://dotnet.github.io/api/System.DateTime.html#System_DateTime_ToString_System_String_) method with the "o" format specifier.

2. Save the string representation of the [DateTime](http://dotnet.github.io/api/System.DateTime.html) value to a file, or pass it across a process, application domain, or machine boundary.

3. Retrieve the string that represents the [DateTime](http://dotnet.github.io/api/System.DateTime.html) value.

4. Call the [DateTime.Parse(String, IFormatProvider, DateTimeStyles)](http://dotnet.github.io/api/System.DateTime.html#System_DateTime_Parse_System_String_System_IFormatProvider_System_Globalization_DateTimeStyles_) method, and pass [DateTimeStyles.RoundtripKind](http://dotnet.github.io/api/System.Globalization.DateTimeStyles.html#System_Globalization_DateTimeStyles_RoundtripKind) as the value of the *styles* parameter.

The following example illustrates how to round-trip a [DateTime](http://dotnet.github.io/api/System.DateTime.html) value.

```csharp
const string fileName = @".\DateFile.txt";

StreamWriter outFile = new StreamWriter(fileName);

// Save DateTime value.
DateTime dateToSave = DateTime.SpecifyKind(new DateTime(2008, 6, 12, 18, 45, 15), 
                                           DateTimeKind.Local);
string dateString = dateToSave.ToString("o");      
Console.WriteLine("Converted {0} ({1}) to {2}.", 
                  dateToSave.ToString(), 
                  dateToSave.Kind.ToString(), 
                  dateString);      
outFile.WriteLine(dateString);
Console.WriteLine("Wrote {0} to {1}.", dateString, fileName);
outFile.Close();

// Restore DateTime value.
DateTime restoredDate;

StreamReader inFile = new StreamReader(fileName);
dateString = inFile.ReadLine();
inFile.Close();
restoredDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
Console.WriteLine("Read {0} ({2}) from {1}.", restoredDate.ToString(), 
                                              fileName, 
                                              restoredDate.Kind.ToString());
// The example displays the following output:
//    Converted 6/12/2008 6:45:15 PM (Local) to 2008-06-12T18:45:15.0000000-05:00.
//    Wrote 2008-06-12T18:45:15.0000000-05:00 to .\DateFile.txt.
//    Read 6/12/2008 6:45:15 PM (Local) from .\DateFile.txt.
```

When round-tripping a [DateTime](http://dotnet.github.io/api/System.DateTime.html) value, this technique successfully preserves the time for all local and universal times. For example, if a local [DateTime](http://dotnet.github.io/api/System.DateTime.html) value is saved on a system in the U.S. Pacific Standard Time zone and is restored on a system in the U.S. Central Standard Time zone, the restored date and time will be two hours later than the original time, which reflects the time difference between the two time zones. However, this technique is not necessarily accurate for unspecified times. All [DateTime](http://dotnet.github.io/api/System.DateTime.html) values whose [Kind]([DateTime](http://dotnet.github.io/api/System.DateTime.html)) property is [Unspecified](http://dotnet.github.io/api/System.DateTimeKind.html#System_DateTimeKind_Unspecified) are treated as if they are local times. If this is not the case, the [DateTime](http://dotnet.github.io/api/System.DateTime.html) will not successfully identify the correct point in time. The workaround for this limitation is to tightly couple a date and time value with its time zone for the save and restore operation.

## To round-trip a DateTimeOffset value

Convert the [DateTimeOffset](http://dotnet.github.io/api/System.DateTimeOffset.html) value to its string representation by calling the [DateTimeOffset.ToString(String)](http://dotnet.github.io/api/System.DateTimeOffset.html#System_DateTimeOffset_ToString_System_String_) method with the "o" format specifier.

2. Save the string representation of the [DateTimeOffset](http://dotnet.github.io/api/System.DateTimeOffset.html) value to a file, or pass it across a process, application domain, or machine boundary.

3. Retrieve the string that represents the [DateTimeOffset](http://dotnet.github.io/api/System.DateTimeOffset.html) value.

4. Call the [DateTimeOffset.Parse(String, IFormatProvider, DateTimeStyles)](http://dotnet.github.io/api/System.DateTimeOffset.html#System_DateTimeOffset_Parse_System_String_System_IFormatProvider_System_Globalization_DateTimeStyles_) method, and pass [DateTimeStyles.RoundtripKind](http://dotnet.github.io/api/System.Globalization.DateTimeStyles.html#System_Globalization_DateTimeStyles_RoundtripKind) as the value of the *styles* parameter.

The following example illustrates how to round-trip a [DateTimeOffset](http://dotnet.github.io/api/System.DateTimeOffset.html) value.

```csharp
const string fileName = @".\DateOff.txt";

StreamWriter outFile = new StreamWriter(fileName);

// Save DateTime value.
DateTimeOffset dateToSave = new DateTimeOffset(2008, 6, 12, 18, 45, 15, 
                                               new TimeSpan(7, 0, 0));
string dateString = dateToSave.ToString("o");      
Console.WriteLine("Converted {0} to {1}.", dateToSave.ToString(), 
                  dateString);      
outFile.WriteLine(dateString);
Console.WriteLine("Wrote {0} to {1}.", dateString, fileName);
outFile.Close();

// Restore DateTime value.
DateTimeOffset restoredDateOff;

StreamReader inFile = new StreamReader(fileName);
dateString = inFile.ReadLine();
inFile.Close();
restoredDateOff = DateTimeOffset.Parse(dateString, null, 
                                       DateTimeStyles.RoundtripKind);
Console.WriteLine("Read {0} from {1}.", restoredDateOff.ToString(), 
                  fileName);
// The example displays the following output:
//    Converted 6/12/2008 6:45:15 PM +07:00 to 2008-06-12T18:45:15.0000000+07:00.
//    Wrote 2008-06-12T18:45:15.0000000+07:00 to .\DateOff.txt.
//    Read 6/12/2008 6:45:15 PM +07:00 from .\DateOff.txt.
```

This technique always unambiguously identifies a [DateTimeOffset](http://dotnet.github.io/api/System.DateTimeOffset.html) value as a single point in time. The value can then be converted to Coordinated Universal Time (UTC) by calling the [DateTimeOffset.ToUniversalTime](http://dotnet.github.io/api/System.DateTimeOffset.html#System_DateTimeOffset_ToUniversalTime) method, or it can be converted to the time in a particular time zone by calling the [DateTimeOffset.ToOffset](http://dotnet.github.io/api/System.DateTimeOffset.html#System_DateTimeOffset_ToOffset_System_TimeSpan_) or [TimeZoneInfo.ConvertTime(DateTimeOffset, TimeZoneInfo)]http://dotnet.github.io/api/System.TimeZoneInfo.html#System_TimeZoneInfo_ConvertTime_System_DateTime_System_TimeZoneInfo_ method. The major limitation of this technique is that date and time arithmetic, when performed on a [DateTimeOffset](http://dotnet.github.io/api/System.DateTimeOffset.html) value that represents the time in a particular time zone, may not produce accurate results for that time zone. This is because when a [DateTimeOffset](http://dotnet.github.io/api/System.DateTimeOffset.html) value is instantiated, it is disassociated from its time zone. Therefore, that time zone's adjustment rules can no longer be applied when you perform date and time calculations. You can work around this problem by defining a custom type that includes both a date and time value and its accompanying time zone.

## See Also

[Performing Formatting Operations](../performingformattingoperations.md)

[Standard Date and Time Format Strings](../standarddatetime.md)


