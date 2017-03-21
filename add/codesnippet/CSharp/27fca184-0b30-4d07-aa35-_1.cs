    public override bool CanConvertFrom(
        ITypeDescriptorContext ctx, Type type)
    {
        return (type == typeof(string));
    }