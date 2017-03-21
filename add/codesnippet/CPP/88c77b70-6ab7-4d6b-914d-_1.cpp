      //Define users and roles.
      PrincipalPermission^ ppBob = gcnew PrincipalPermission( "Bob", "Manager" );
      PrincipalPermission^ ppLouise = gcnew PrincipalPermission( "Louise", "Supervisor" );
      PrincipalPermission^ ppGreg = gcnew PrincipalPermission( "Greg", "Employee" );
      
      //Define groups of users.
      PrincipalPermission^ pp1 = (PrincipalPermission^) (ppBob->Union( ppLouise ));
      PrincipalPermission^ pp2 = (PrincipalPermission^) (ppGreg->Union( pp1 ));