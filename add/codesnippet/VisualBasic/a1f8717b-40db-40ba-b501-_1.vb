        myServiceDescription = _
           ServiceDescription.Read("StockQuoteService_vb.wsdl")
      myServiceDescription.Imports.Insert(0, _
         CreateImport("http://localhost/stockquote/definitions", _
         "http://localhost/stockquote/stockquote_vb.wsdl"))