            Collection<ContractDescription> inheretedContracts = cd.GetInheritedContracts();
            Console.WriteLine("\tInherited Contracts:");
            foreach (ContractDescription contractdescription in inheretedContracts)
            {
                Console.WriteLine("\t\t" + contractdescription.Name);
            }