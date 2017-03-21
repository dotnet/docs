      Dim myServiceDescription As ServiceDescription = _
         ServiceDescription.Read("StockQuote_vb.wsdl")
      myServiceDescription.Imports.Add( _
         CreateImport("http://localhost/stockquote/schemas", _
         "http://localhost/stockquote/stockquote_vb.xsd"))