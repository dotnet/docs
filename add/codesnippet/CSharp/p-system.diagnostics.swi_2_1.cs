                // Display the SwitchLevelAttribute for the BooleanSwitch.
                Object[] attribs = typeof(BooleanSwitch).GetCustomAttributes(typeof(SwitchLevelAttribute), false);
                if (attribs.Length == 0)
                    Console.WriteLine("Error, couldn't find SwitchLevelAttribute on BooleanSwitch.");
                else
                    Console.WriteLine(((SwitchLevelAttribute)attribs[0]).SwitchLevelType.ToString());