                NameValueCollection parameters =
                    pSettings.Parameters;

                IEnumerator pEnum =
                    parameters.GetEnumerator();

                int i = 0;
                while (pEnum.MoveNext())
                {
                    string pLength =
                        parameters[i].Length.ToString();
                    Console.WriteLine(
                        "Provider ssettings: {0} has {1} parameters",
                        pSettings.Name, pLength);

                }