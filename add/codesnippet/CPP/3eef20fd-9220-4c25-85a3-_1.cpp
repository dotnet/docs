        // Create a mailing address that includes a UTF8 
        // character in the display name.
        MailAddress^ from = gcnew MailAddress("jane@contoso.com",
            "Jane " + (wchar_t)0xD8 + " Clayton",
            System::Text::Encoding::UTF8);