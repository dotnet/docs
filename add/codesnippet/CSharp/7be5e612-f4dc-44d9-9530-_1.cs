        PrincipalPermission ppBob = new PrincipalPermission("Bob", "Administrator");
        PrincipalPermission ppLouise = new PrincipalPermission("Louise", "Administrator");
        IPermission pp1 = ppBob.Intersect(ppLouise);