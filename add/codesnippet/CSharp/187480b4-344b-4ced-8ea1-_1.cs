        GacMembershipCondition Gac1 = new GacMembershipCondition();
        GacInstalled myGac = new GacInstalled();
        try
        {
            Object [] hostEvidence = {myGac};
            Object [] assemblyEvidence = {};

            Evidence myEvidence = new Evidence(hostEvidence,assemblyEvidence);
            bool retCode = Gac1.Check(myEvidence);
            Console.WriteLine("Result of Check = " + retCode.ToString() + "\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Check failed : " + Gac1.ToString() + e);
            return false;
        }