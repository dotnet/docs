        MailMessage^ message = gcnew MailMessage(from, to);
        message->Body = "This is a test e-mail message sent" +
            " by an application. ";
        // Include some non-ASCII characters in body and 
        // subject.
        String^ someArrows = gcnew String(gcnew array<wchar_t>{L'\u2190', 
            L'\u2191', L'\u2192', L'\u2193'});
        message->Body += Environment::NewLine + someArrows;
        message->BodyEncoding = System::Text::Encoding::UTF8;
        message->Subject = "test message 1" + someArrows;
        message->SubjectEncoding = System::Text::Encoding::UTF8;