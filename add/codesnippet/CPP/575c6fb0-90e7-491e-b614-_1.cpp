                // Demonstrate the SecurityException constructor
                // by throwing the exception again.
                Display("Rethrowing the exception thrown as a "
                    "result of a PermitOnly security action.");
                throw gcnew SecurityException(exception->Message,
                    exception->DenySetInstance,
                    exception->PermitOnlySetInstance,
                    exception->Method, exception->Demanded,
                    exception->FirstPermissionThatFailed);