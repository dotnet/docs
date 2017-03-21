                // Create a new auditing behavior and set the log location.
                ServiceSecurityAuditBehavior newAudit = 
                    new ServiceSecurityAuditBehavior();
                newAudit.AuditLogLocation = 
                    AuditLogLocation.Application;
                newAudit.MessageAuthenticationAuditLevel = 
                    AuditLevel.SuccessOrFailure;
                newAudit.ServiceAuthorizationAuditLevel = 
                    AuditLevel.SuccessOrFailure;
                newAudit.SuppressAuditFailure = false;