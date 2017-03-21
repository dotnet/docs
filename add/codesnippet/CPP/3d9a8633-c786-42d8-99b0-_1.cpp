            GacMembershipCondition ^ Gac3 = gcnew GacMembershipCondition;
            GacMembershipCondition ^ Gac4 = gcnew GacMembershipCondition;
            IEnumerator^ policyEnumerator = SecurityManager::PolicyHierarchy();
            while (policyEnumerator->MoveNext())
            {
                PolicyLevel^ currentLevel = 
                    dynamic_cast<PolicyLevel^>(policyEnumerator->Current);
                if (currentLevel->Label->Equals("Machine"))
                {
                    Console::WriteLine("Result of ToXml(level) = {0}", 
                        Gac3->ToXml(currentLevel));
                    Gac4->FromXml(Gac3->ToXml(), currentLevel);
                    Console::WriteLine(
                        "Result of FromXml(element, level) = {0}", Gac4);
                }
            }