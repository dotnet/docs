   Public Shared Sub GetSetExclusiveAddressUse(t As TcpListener)
      ' Set Exclusive Address Use for the underlying socket.
      t.ExclusiveAddressUse = True
      Console.WriteLine("ExclusiveAddressUse value is {0}", t.ExclusiveAddressUse)
   End Sub 'GetSetExclusiveAddressUse
   