    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {

        // Serialize the desired values for this class.
        info.AddValue("title", title);

        // Get the set of serializable members for the class and base classes.
        Type thisType = this.GetType();
        MemberInfo[] mi = FormatterServices.GetSerializableMembers(thisType, context);

        // Serialize the base class's fields to the info object.
        for (Int32 i = 0; i < mi.Length; i++)
        {
            // Do not serialize fields for this class.
            if (mi[i].DeclaringType == thisType) continue;

            // Skip this field if it is marked NonSerialized.
            if (Attribute.IsDefined(mi[i], typeof(NonSerializedAttribute))) continue;
         
            // Get the value of this field and add it to the SerializationInfo object.
            info.AddValue(mi[i].Name, ((FieldInfo) mi[i]).GetValue(this));
        }

        // Call the method below to see the contents of the SerializationInfo object.
        DisplaySerializationInfo(info);
    }