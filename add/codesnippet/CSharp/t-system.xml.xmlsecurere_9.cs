
Evidence myEvidence = XmlSecureResolver.CreateEvidenceForUrl(sourceURI);
XmlSecureResolver myResolver = new XmlSecureResolver(new XmlUrlResolver(), myEvidence);