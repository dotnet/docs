    array<KeySizes^>^ legalKeySizes = customCryptoAlgorithm->LegalKeySizes;
    for (int i = 0; i < legalKeySizes->Length; i++)
    {
        Console::WriteLine(
            "Keysize{0} min, max, step: {1}, {2}, {3}, ", i,
            legalKeySizes[i]->MinSize,
            legalKeySizes[i]->MaxSize,
            legalKeySizes[i]->SkipSize);
    }