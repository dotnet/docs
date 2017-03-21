   // Parse an XSD gTime to create a SoapTime object.
   // The timezone of this object is the current timezone.
   String^ xsdTime = "12:13:14.123Z";
   SoapTime^ time = SoapTime::Parse( xsdTime );