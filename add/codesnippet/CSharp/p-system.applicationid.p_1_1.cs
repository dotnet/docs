            // To display the value of the public key, enumerate the Byte array for the property.
            Console.Write("ApplicationId.PublicKeyToken property = ");
            byte[] pk = asi.ApplicationId.PublicKeyToken;
            for (int i = 0; i < pk.GetLength(0); i++)
                Console.Write("{0:x}", pk[i]);