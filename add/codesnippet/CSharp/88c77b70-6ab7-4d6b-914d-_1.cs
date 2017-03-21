//Define users and roles.
PrincipalPermission ppBob = new PrincipalPermission("Bob", "Manager");
PrincipalPermission ppLouise = new PrincipalPermission("Louise", "Supervisor");
PrincipalPermission ppGreg = new PrincipalPermission("Greg", "Employee");

//Define groups of users.
PrincipalPermission pp1 = (PrincipalPermission)ppBob.Union(ppLouise);
PrincipalPermission pp2 = (PrincipalPermission)ppGreg.Union(pp1);