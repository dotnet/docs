Evidence myEvidence = this.GetType().Assembly.Evidence;
XmlSecureResolver myResolver;
myResolver = new XmlSecureResolver(new XmlUrlResolver(), myEvidence);