'<Snippet1>
Imports System
Imports System.Reflection

Class ADGetData   
   
   Public Shared Sub Main()
      ' appdomain setup information
      Dim currentDomain As AppDomain = AppDomain.CurrentDomain
      
      'Create a new value pair for the appdomain
      currentDomain.SetData("ADVALUE", "Example value")
      
      'get the value specified in the setdata method
      Console.WriteLine(("ADVALUE is: " & currentDomain.GetData("ADVALUE")))
      
      'get a system value specified at appdomainsetup
      Console.WriteLine("System value for loader optimization: {0}", _
         currentDomain.GetData("LOADER_OPTIMIZATION"))

   End Sub 
End Class 

' This code example produces the following output:
'
'ADVALUE is: Example value
'System value for loader optimization: NotSpecified

'</Snippet1>
