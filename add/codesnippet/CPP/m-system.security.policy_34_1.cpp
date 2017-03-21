    GacInstalled ^ myGacInstalledCopy = 
        dynamic_cast<GacInstalled^>(myGacInstalled->Copy());
    bool result = myGacInstalled->Equals( myGacInstalledCopy );