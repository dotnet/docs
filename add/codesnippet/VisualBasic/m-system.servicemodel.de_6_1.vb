            ' Create a new auditing behavior and set the log location.
            Dim newAudit As New ServiceSecurityAuditBehavior()
            newAudit.AuditLogLocation = AuditLogLocation.Application