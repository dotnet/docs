' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Interface IInterface
   Sub Display()
End Interface

Public Class Implementation : Implements IInterface
   Public Sub Display() _
      Implements IInterface.Display

      Console.WriteLine("The implementation...")
   End Sub
End Class

Module Example
   Public Sub Main()
      Console.WriteLine("Implementation is a subclass of IInterface:   {0}",
                        GetType(Implementation).IsSubclassOf(GetType(IInterface)))
      Console.WriteLine("IInterface is assignable from Implementation: {0}",
                        GetType(IInterface).IsAssignableFrom(GetType(Implementation)))
   End Sub
End Module
' The example displays the following output:
'       Implementation is a subclass of IInterface:   False
'       IInterface is assignable from Implementation: True
' </Snippet1>
