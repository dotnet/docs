    public override bool CanConvertTo(
        ITypeDescriptorContext ctx, Type type)
    {
        return (type == typeof(string));
    }