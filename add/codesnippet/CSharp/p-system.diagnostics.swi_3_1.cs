            SwitchAttribute[] switches = SwitchAttribute.GetAll(typeof(TraceTest).Assembly);
            for (int i = 0; i < switches.Length; i++)
            {
                Console.WriteLine("Switch name = " + switches[i].SwitchName);
                Console.WriteLine("Switch type = " + switches[i].SwitchType);
            }