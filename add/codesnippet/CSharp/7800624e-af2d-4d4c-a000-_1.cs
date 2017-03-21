            GacMembershipCondition Gac3 = new GacMembershipCondition();
            GacMembershipCondition Gac4 = new GacMembershipCondition();
            IEnumerator policyEnumerator = SecurityManager.PolicyHierarchy();
            while (policyEnumerator.MoveNext())
            {
                PolicyLevel currentLevel = 
                    (PolicyLevel)policyEnumerator.Current;
                if (currentLevel.Label == "Machine")
                {
                    Console.WriteLine("Result of ToXml(level) = " + 
                        Gac3.ToXml(currentLevel));
                    Gac4.FromXml(Gac3.ToXml(), currentLevel);
                    Console.WriteLine("Result of FromXml(element, level) = " + 
                        Gac4.ToString());
                }
            }