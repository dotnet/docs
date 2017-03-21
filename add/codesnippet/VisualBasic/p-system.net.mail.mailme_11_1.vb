            Dim message As New MailMessage([from], [to])
            message.Body = "This is a test e-mail message sent by an application. "
            ' Include some non-ASCII characters in body and subject.
            Dim someArrows As New String(New Char() {ChrW(&H2190), ChrW(&H2191), ChrW(&H2192), ChrW(&H2193)})
            message.Body += Environment.NewLine & someArrows
            message.BodyEncoding = System.Text.Encoding.UTF8
            message.Subject = "test message 1" & someArrows
            message.SubjectEncoding = System.Text.Encoding.UTF8