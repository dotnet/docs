            if (sp.Certificate == null)
                Console.WriteLine ("Certificate = (null)");
            else
                Console.WriteLine ("Certificate = " + sp.Certificate.ToString ());

            if (sp.ClientCertificate == null)
                Console.WriteLine ("ClientCertificate = (null)");
            else
                Console. WriteLine ("ClientCertificate = " + sp.ClientCertificate.ToString ());

            Console.WriteLine ("ProtocolVersion = " + sp.ProtocolVersion.ToString ());
            Console.WriteLine ("SupportsPipelining = " + sp.SupportsPipelining);
