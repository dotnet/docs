        GacMembershipCondition ^ Gac1 = gcnew GacMembershipCondition;
        Console::WriteLine("Original membership condition = ");
        Console::WriteLine(Gac1->ToXml());
        try
        {
            IMembershipCondition^ membershipCondition = Gac1->Copy();
            Console::WriteLine("Result of Copy = ");
            Console::WriteLine(
                (dynamic_cast<GacMembershipCondition^>(membershipCondition))
                ->ToXml());
        }
        catch (Exception^ e) 
        {
             Console::WriteLine("Copy failed : {0}{1}", Gac1, e);
             return false;
        }