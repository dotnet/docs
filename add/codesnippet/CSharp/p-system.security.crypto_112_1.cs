        public override int KeySize 
        {
            get { return KeySizeValue; }
            set
            {
                for (int i=0; i < keySizes.Length; i++)
                {
                    if (keySizes[i].SkipSize == 0) 
                    {
                        if (keySizes[i].MinSize == value)
                        {
                            KeySizeValue = value;
                            return;
                        }
                    }
                    else
                    {
                        for (int j = keySizes[i].MinSize;
                            j <= keySizes[i].MaxSize;
                            j += keySizes[i].SkipSize)
                        {
                            if (j == value)
                            {
                                KeySizeValue = value;
                                return;
                            }
                        }
                    }
                }

                // If the key does not fall within the range identified 
                // in the keySizes member variable, throw an exception.
                throw new CryptographicException("Invalid key size.");
            }
        }