
' Remove a HttpHandlerAction object 
    Dim httpHandler3 As System.Web.Configuration.HttpHandlerAction  = new HttpHandlerAction( _
    "Calculator.custom", _
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler", _
    "GET", _
    true)
    httpHandlers.Remove(httpHandler3)
