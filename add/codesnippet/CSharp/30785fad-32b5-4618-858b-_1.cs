// Add a new HttpHandlerAction to the Handlers property HttpHandlerAction collection.
httpHandlersSection.Handlers.Add(new HttpHandlerAction(
    "Calculator.custom", 
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler", 
    "GET", 
    true));