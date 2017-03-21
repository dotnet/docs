        GacMembershipCondition ^ Gac1 = gcnew GacMembershipCondition;
        GacInstalled ^ myGac = gcnew GacInstalled;
        try
        {
             array<Object^>^hostEvidence = {myGac};
             array<Object^>^assemblyEvidence = {};
             Evidence^ myEvidence = 
                 gcnew Evidence(hostEvidence,assemblyEvidence);
             bool retCode = Gac1->Check(myEvidence);
             Console::WriteLine("Result of Check = {0}\n", retCode);
        }
        catch (Exception^ e) 
        {
             Console::WriteLine("Check failed : {0}{1}", Gac1, e);
             return false;
        }