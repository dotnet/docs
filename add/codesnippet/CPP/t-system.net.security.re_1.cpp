        // Load a table of errors that might cause 
        // the certificate authentication to fail.
        static void InitializeCertificateErrors()
        {
            certificateErrors->Add(0x800B0101,
                "The certification has expired.");
            certificateErrors->Add(0x800B0104,
                "A path length constraint "
                "in the certification chain has been violated.");
            certificateErrors->Add(0x800B0105,
                "A certificate contains an unknown extension "
                "that is marked critical.");
            certificateErrors->Add(0x800B0107,
                "A parent of a given certificate in fact "
                "did not issue that child certificate.");
            certificateErrors->Add(0x800B0108,
                "A certificate is missing or has an empty value "
                "for a necessary field.");
            certificateErrors->Add(0x800B0109,
                "The certificate root is not trusted.");
            certificateErrors->Add(0x800B010C,
                "The certificate has been revoked.");
            certificateErrors->Add(0x800B010F,
                "The name in the certificate does not not match "
                "the host name requested by the client.");
            certificateErrors->Add(0x800B0111,
                "The certificate was explicitly marked "
                "as untrusted by the user.");
            certificateErrors->Add(0x800B0112,
                "A certification chain processed correctly, "
                "but one of the CA certificates is not trusted.");
            certificateErrors->Add(0x800B0113,
                "The certificate has an invalid policy.");
            certificateErrors->Add(0x800B0114,
                "The certificate name is either not "
                "in the permitted list or is explicitly excluded.");
            certificateErrors->Add(0x80092012,
                "The revocation function was unable to check "
                "revocation for the certificate.");
            certificateErrors->Add(0x80090327,
                "An unknown error occurred while "
                "processing the certificate.");
            certificateErrors->Add(0x80096001,
                "A system-level error occurred "
                "while verifying trust.");
            certificateErrors->Add(0x80096002,
                "The certificate for the signer of the message "
                "is invalid or not found.");
            certificateErrors->Add(0x80096003,
                "One of the counter signatures was invalid.");
            certificateErrors->Add(0x80096004,
                "The signature of the certificate "
                "cannot be verified.");
            certificateErrors->Add(0x80096005,
                "The time stamp signature or certificate "
                "could not be verified or is malformed.");
            certificateErrors->Add(0x80096010,
                "The digital signature of the object "
                "was not verified.");
            certificateErrors->Add(0x80096019,
                "The basic constraint extension of a certificate "
                "has not been observed.");
        }

        static String^ CertificateErrorDescription(UInt32 problem)
        {
            // Initialize the error message dictionary 
            // if it is not yet available.
            if (certificateErrors->Count == 0)
            {
                InitializeCertificateErrors();
            }

            String^ description = safe_cast<String^>(
                certificateErrors[problem]);
            if (description == nullptr)
            {
                description = String::Format(
                    CultureInfo::CurrentCulture,
                    "Unknown certificate error - 0x{0:x8}",
                    problem);
            }

            return description;
        }

    public:
        // The following method is invoked 
        // by the CertificateValidationDelegate.
    static bool ValidateServerCertificate(
            Object^ sender,
            X509Certificate^ certificate,
            X509Chain^ chain,
            SslPolicyErrors sslPolicyErrors)
        {
        
            Console::WriteLine("Validating the server certificate.");
            if (sslPolicyErrors == SslPolicyErrors::None)
                return true;

            Console::WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }