            OperationDescriptionCollection odc = cd.Operations;
            Console.WriteLine("\tDisplay Operations:");
            foreach (OperationDescription od in odc)
            {
                Console.WriteLine("\t\t" + od.Name);
            }