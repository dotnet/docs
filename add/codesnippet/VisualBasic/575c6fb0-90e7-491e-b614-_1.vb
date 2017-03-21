            ' Demonstrate the SecurityException constructor by 
            ' throwing the exception again.
            Display("Rethrowing the exception thrown as a result of a " & _
                "PermitOnly security action.")
            Throw New SecurityException(sE.Message, sE.DenySetInstance, _
                sE.PermitOnlySetInstance, sE.Method, sE.Demanded, _
                CType(sE.FirstPermissionThatFailed, IPermission))