            public string GetName(int ID)
            {
                if (ID < names.Length)
                    return names[ID];
                else
                    return String.Empty;
            }
            private string[] names = { "Spencer", "Sally", "Doug" };