' <Snippet1>
' Declare an interface.
Interface IInterface
End Interface

Class Example : Implements IInterface
   Public Shared Sub Main()
      ' Determine whether IInterface is an interface.
       Dim isInterface1 As Boolean = GetType(IInterface).IsInterface
       Console.WriteLine("Is IInterface an interface? {0}", isInterface1)

       ' Determine whether Example is an interface.
       Dim isInterface2 As Boolean = GetType(Example).IsInterface
       Console.WriteLine("Is Example an interface? {0}", isInterface2)
   End Sub 
End Class 
' The example displays the following output:
'       Is IInterface an interface? True
'       Is Example an interface? False
' </Snippet1>