            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("jane@contoso.com", 
               "Jane " + (char)0xD8+ " Clayton", 
            System.Text.Encoding.UTF8);