                //Demonstrate the SecurityException constructor by 
                // throwing the exception again.
                Display("Rethrowing the exception thrown as a result of a " + 
                    "PermitOnly security action.");
                throw new SecurityException(sE.Message, sE.DenySetInstance, 
                    sE.PermitOnlySetInstance, sE.Method, sE.Demanded, 
                    (IPermission)sE.FirstPermissionThatFailed);