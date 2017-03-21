   Public Class HelloService
      Inherits MarshalByRefObject

      Public Function HelloMethod(name As String) As String
         Console.WriteLine(("Hello " + name))
         Return "Hello " + name
      End Function 'HelloMethod

      <PermissionSet(SecurityAction.LinkDemand)> _
      Public Function HeaderMethod(name As String, arrHeader() As Header) As String
         Console.WriteLine("HeaderMethod " + name)
         'Header Set with the header array passed
         CallContext.SetHeaders(arrHeader)
         Return "HeaderMethod " + name
      End Function 'HeaderMethod
   End Class 'HelloService