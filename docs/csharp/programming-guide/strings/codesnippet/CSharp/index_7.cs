            string s3 = "Visual C# Express";
            System.Console.WriteLine(s3.Substring(7, 2));
            // Output: "C#"

            System.Console.WriteLine(s3.Replace("C#", "Basic"));
            // Output: "Visual Basic Express"

            // Index values are zero-based
            int index = s3.IndexOf("C");
            // index = 7