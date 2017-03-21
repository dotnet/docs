        PrincipalPermission^ ppBob = gcnew PrincipalPermission("Bob", "Administrator");
        PrincipalPermission^ ppLouise = gcnew PrincipalPermission("Louise", "Administrator");
        IPermission^ pp1 = ppBob->Intersect(ppLouise);