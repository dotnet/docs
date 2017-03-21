
    // Get the specified handler's index.
    HttpHandlerAction httpHandler2 = new HttpHandlerAction(
    "Calculator.custom",
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler",
    "GET", true);
    int handlerIndex = httpHandlers.IndexOf(httpHandler2);
