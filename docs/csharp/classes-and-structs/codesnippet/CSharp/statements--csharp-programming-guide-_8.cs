                foreach (string s in System.IO.Directory.GetDirectories(
                    System.Environment.CurrentDirectory))
                {
                    if (s.StartsWith("CSharp"))
                    {
                        if (s.EndsWith("TempFolder"))
                        {
                            return s;
                        }
                    }

                }
                return "Not found.";