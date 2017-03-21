    X509Chain^ ch = gcnew X509Chain();
    ch->ChainPolicy->ApplicationPolicy->Add(gcnew Oid("1.2.1.1"));