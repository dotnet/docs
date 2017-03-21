                KeySizes[] legalKeySizes = customCrypto.LegalKeySizes;
                if (legalKeySizes.Length > 0)
                {
                    for (int i=0; i < legalKeySizes.Length; i++)
                    {
                        Console.Write("Keysize" + i + " min, max, step: ");
                        Console.Write(legalKeySizes[i].MinSize + ", ");
                        Console.Write(legalKeySizes[i].MaxSize + ", ");
                        Console.WriteLine(legalKeySizes[i].SkipSize + ", ");
                    }
                }