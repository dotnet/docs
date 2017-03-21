      ServiceDescription myServiceDescription = 
         ServiceDescription.Read("StockQuote_cs.wsdl");
      myServiceDescription.Imports.Add(
         CreateImport("http://localhost/stockquote/schemas",
         "http://localhost/stockquote/stockquote_cs.xsd"));