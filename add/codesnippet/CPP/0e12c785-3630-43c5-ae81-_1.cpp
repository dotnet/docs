    array<Object^>^hostEvidence = {myGacInstalled};
    array<Object^>^assemblyEvidence = {};
    Evidence^ myEvidence = gcnew Evidence( hostEvidence,assemblyEvidence );
    GacIdentityPermission ^ myPerm = dynamic_cast<GacIdentityPermission^>
        (myGacInstalled->CreateIdentityPermission( myEvidence ));
    Console::WriteLine( myPerm->ToXml() );