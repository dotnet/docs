    public override object ConvertTo(
        ITypeDescriptorContext ctx, CultureInfo ci,
        object value, Type type)
    {
        ValidateType(value, typeof(TimeSpan));

        long data = (long)(((TimeSpan)value).TotalMinutes);

        return data.ToString(CultureInfo.InvariantCulture);
    }