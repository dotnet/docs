
    'Get the specified handler's index.
    Dim httpHandler2 As System.Web.Configuration.HttpHandlerAction  = new HttpHandlerAction( _
    "Calculator.custom", _
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler", _
    "GET", _
    true)
    Dim handlerIndex As Integer = httpHandlers.IndexOf(httpHandler2)
