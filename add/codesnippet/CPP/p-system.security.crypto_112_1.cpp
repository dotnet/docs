        public:
            property int KeySize
            {
                virtual int get() override
                {
                    return KeySizeValue;
                }

                virtual void set(int value) override
                {
                    for (int i = 0; i < customValidKeySizes->Length; i++)
                    {
                        if (customValidKeySizes[i]->SkipSize == 0)
                        {
                            if (customValidKeySizes[i]->MinSize == value)
                            {
                                KeySizeValue = value;
                                return;
                            }
                        }
                        else
                        {
                            for (int j = customValidKeySizes[i]->MinSize;
                                j <= customValidKeySizes[i]->MaxSize;
                                j += customValidKeySizes[i]->SkipSize)
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
                    throw gcnew CryptographicException("Invalid key size.");
                }
            }