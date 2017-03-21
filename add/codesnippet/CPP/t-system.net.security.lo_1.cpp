    static X509Certificate^ SelectLocalCertificate(
            Object^ sender, 
			String^ targetHost, 
			X509CertificateCollection^ localCertificates, 
			X509Certificate^ remoteCertificate, 
			array<String^>^ acceptableIssuers
    )
    {	
        Console::WriteLine("Client is selecting a local certificate.");
        if (acceptableIssuers != nullptr && 
                acceptableIssuers->Length > 0 &&
                localCertificates != nullptr &&
                localCertificates->Count > 0)
        {
            // Use the first certificate that is from an acceptable issuer.
            IEnumerator^ myEnum1 = localCertificates->GetEnumerator();
            while ( myEnum1->MoveNext() )
            {
				X509Certificate^ certificate = safe_cast<X509Certificate^>(myEnum1->Current);
				String^ issuer = certificate->Issuer;
				if ( Array::IndexOf( acceptableIssuers, issuer ) != -1 )
					return certificate;
            }
        }
        if (localCertificates != nullptr &&
                localCertificates->Count > 0)
			return localCertificates[0];
                
        return nullptr;
     }
