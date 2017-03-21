            GacMembershipCondition ^ Gac1 = gcnew GacMembershipCondition;
            GacMembershipCondition ^ Gac2 = gcnew GacMembershipCondition;

            // Roundtrip a GacMembershipCondition to and from an XML encoding.
            Gac2->FromXml(Gac1->ToXml());
            bool result = Gac2->Equals(Gac1);
            if (result)
            {
                Console::WriteLine("Result of ToXml() = {0}", Gac2->ToXml());
                Console::WriteLine(
                    "Result of ToFromXml roundtrip = {0}", Gac2);
            }
            else
            {
                Console::WriteLine(Gac2->ToString());
                Console::WriteLine(Gac1->ToString());
                return false;
            }