//<Snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Globalization;
using System.ComponentModel;


public sealed class CustomTimeSpanMinutesConverter :
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

    //<Snippet2>
    public override bool CanConvertTo(
        ITypeDescriptorContext ctx, Type type)
    {
        return (type == typeof(string));
    }
    //</Snippet2>

    //<Snippet3>
    public override bool CanConvertFrom(
        ITypeDescriptorContext ctx, Type type)
    {
        return (type == typeof(string));
    }
    //</Snippet3>

    //<Snippet4>
    public override object ConvertTo(
        ITypeDescriptorContext ctx, CultureInfo ci,
        object value, Type type)
    {
        ValidateType(value, typeof(TimeSpan));

        long data = (long)(((TimeSpan)value).TotalMinutes);

        return data.ToString(CultureInfo.InvariantCulture);
    }
    //</Snippet4>

    //<Snippet5>
    public override object ConvertFrom(
        ITypeDescriptorContext ctx, CultureInfo ci, object data)
    {

        long min = long.Parse((string)data,
            CultureInfo.InvariantCulture);

        return TimeSpan.FromMinutes((double)min);
    }
    //</Snippet5>

}
//</Snippet1>
