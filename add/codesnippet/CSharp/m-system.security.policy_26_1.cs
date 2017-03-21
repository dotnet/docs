        GacMembershipCondition Gac1 = new GacMembershipCondition();
        Console.WriteLine("Original membership condition = ");
        Console.WriteLine(Gac1.ToXml().ToString());
        try
        {
            IMembershipCondition membershipCondition = Gac1.Copy();
            Console.WriteLine("Result of Copy = ");
            Console.WriteLine(
                ((GacMembershipCondition)membershipCondition).ToXml().ToString()
                );
        }
        catch (Exception e)
        {
            Console.WriteLine("Copy failed : " + Gac1.ToString() + e);
            return false;
        }
