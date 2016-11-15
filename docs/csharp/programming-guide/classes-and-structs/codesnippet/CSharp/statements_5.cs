                // Recommended style. Embedded statement in  block.
                foreach (string s in System.IO.Directory.GetDirectories(
                                        System.Environment.CurrentDirectory))
                {
                    System.Console.WriteLine(s);
                }

                // Not recommended.
                foreach (string s in System.IO.Directory.GetDirectories(
                                        System.Environment.CurrentDirectory))
                    System.Console.WriteLine(s);