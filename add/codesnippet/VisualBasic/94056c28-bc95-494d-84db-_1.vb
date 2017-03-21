' Add a new HttpHandlerAction to the Handlers property HttpHandlerAction collection.
httpHandlersSection.Handlers.Add(new HttpHandlerAction( _
    "Calculator.custom", _
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler", _
    "GET", _
    true))