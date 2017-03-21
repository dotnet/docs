            KeyedByTypeCollection<IContractBehavior> behaviors = cd.Behaviors;
            Console.WriteLine("\tDisplay all behaviors:");
            foreach (IContractBehavior behavior in behaviors)
            {
                Console.WriteLine("\t\t" + behavior.ToString());
            }