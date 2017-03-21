            GacMembershipCondition Gac1 = new GacMembershipCondition();
            GacMembershipCondition Gac2 = new GacMembershipCondition();

            // Roundtrip a GacMembershipCondition to and from an XML encoding.
            Gac2.FromXml(Gac1.ToXml());
            bool result = Gac2.Equals(Gac1);
            if (result)
            {
                Console.WriteLine(
                    "Result of ToXml() = " + Gac2.ToXml().ToString());
                Console.WriteLine(
                    "Result of ToFromXml roundtrip = " + Gac2.ToString());
            }
            else
            {
                Console.WriteLine(Gac2.ToString());
                Console.WriteLine(Gac1.ToString());
                return false;
            }