                int i = 0;
                while (secEnum.MoveNext())
                {
                    string setionName = sections.GetKey(i);
                    Console.WriteLine(
                        "Section name: {0}", setionName);
                    i += 1;
                }