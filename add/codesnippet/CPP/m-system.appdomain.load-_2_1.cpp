         AppDomain^ ad = AppDomain::CreateDomain("ChildDomain");
         ad->Load("MyAssembly");