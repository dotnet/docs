        FieldInfo^ fi = obj->GetType()->GetField("field1");

        if ((fi->Attributes & FieldAttributes::FieldAccessMask) ==
            FieldAttributes::Public)
        {
            Console::WriteLine("{0:s} is public. Value: {1:d}", fi->Name, fi->GetValue(obj));
        }