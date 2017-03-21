    public override object ConvertFrom(
        ITypeDescriptorContext ctx, CultureInfo ci, object data)
    {

        long min = long.Parse((string)data,
            CultureInfo.InvariantCulture);

        return TimeSpan.FromMinutes((double)min);
    }