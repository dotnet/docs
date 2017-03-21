            ' Create a mailing address that includes a UTF8 character
            ' in the display name.
            Dim [from] As New MailAddress("jane@contoso.com", "Jane " & ChrW(&HD8) & " Clayton", System.Text.Encoding.UTF8)