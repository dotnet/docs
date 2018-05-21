            int? x = 10;
            if (x.HasValue)
            {
                System.Console.WriteLine(x.Value);
            }
            else
            {
                System.Console.WriteLine("Undefined");
            }