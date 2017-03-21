        GacMembershipCondition Gac1 = new GacMembershipCondition();
        try
        {
            Console.WriteLine(
                "Result of GetHashCode for a GacMembershipCondition = " + 
                Gac1.GetHashCode().ToString() + "\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("GetHashCode failed : " + Gac1.ToString() + e);
            return false;
        }