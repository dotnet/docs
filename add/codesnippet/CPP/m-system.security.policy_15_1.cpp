        GacMembershipCondition ^ Gac1 = gcnew GacMembershipCondition;
        try
        {
            Console::WriteLine(
                "Result of GetHashCode for a GacMembershipCondition = {0}\n",
                Gac1->GetHashCode());
        }
        catch (Exception^ e) 
        {
             Console::WriteLine("GetHashCode failed : {0}{1}", Gac1, e);
             return false;
        }