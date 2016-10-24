            byte[] vals = { 0x01, 0xAA, 0xB1, 0xDC, 0x10, 0xDD };

            string str = BitConverter.ToString(vals);
            Console.WriteLine(str);

            str = BitConverter.ToString(vals).Replace("-", "");
            Console.WriteLine(str);

            /*Output:
              01-AA-B1-DC-10-DD
              01AAB1DC10DD
             */