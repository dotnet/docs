                // Create a new auditing behavior and set the log location.
                ServiceSecurityAuditBehavior newAudit = 
                    new ServiceSecurityAuditBehavior();
                newAudit.AuditLogLocation = 
                    AuditLogLocation.Application;