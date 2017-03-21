                int i = 0;
                while (groupEnum.MoveNext())
                {
                    string groupName = groups.GetKey(i);
                    Console.WriteLine(
                        "Group name: {0}", groupName);
                    i += 1;
                }