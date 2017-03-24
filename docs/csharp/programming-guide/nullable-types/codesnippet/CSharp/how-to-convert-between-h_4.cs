
            string hexString = "43480170";
            uint num = uint.Parse(hexString, System.Globalization.NumberStyles.AllowHexSpecifier);

            byte[] floatVals = BitConverter.GetBytes(num);
            float f = BitConverter.ToSingle(floatVals, 0);
            Console.WriteLine("float convert = {0}", f);

            // Output: 200.0056            