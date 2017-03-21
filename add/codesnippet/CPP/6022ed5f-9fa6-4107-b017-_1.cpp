public:
    [SecurityPermission(SecurityAction::Demand, SerializationFormatter = true)]
    virtual void GetObjectData(SerializationInfo^ info, StreamingContext context)
    {
        // Serialize the desired values for this class.
        info->AddValue("title", title);

        // Get the set of serializable members for the class and base classes.
        Type^ thisType = this->GetType();
        array<MemberInfo^>^ serializableMembers =
            FormatterServices::GetSerializableMembers(thisType, context);

        // Serialize the base class's fields to the info object.
        for each (MemberInfo^ serializableMember in serializableMembers)
        {
            // Do not serialize fields for this class.
            if (serializableMember->DeclaringType != thisType)
            {
                // Skip this field if it is marked NonSerialized.
                if (!(Attribute::IsDefined(serializableMember,
                    NonSerializedAttribute::typeid)))
                {
                    // Get the value of this field and add it to the
                    // SerializationInfo object.
                    info->AddValue(serializableMember->Name,
                        ((FieldInfo^)serializableMember)->GetValue(this));
                }
            }
        }

        // Call the method below to see the contents of the
        // SerializationInfo object.
        DisplaySerializationInfo(info);
    }