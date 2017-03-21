
// Remove a HttpHandlerAction object 
    HttpHandlerAction httpHandler3 = new HttpHandlerAction(
     "Calculator.custom",
     "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler",
     "GET", true);
    httpHandlers.Remove(httpHandler3);