   Dim _money As Decimal   
   
   Public Property Money As <MarshalAs(UnmanagedType.Currency)> Decimal 
      Get
         Return Me._money
      End Get
      Set(<MarshalAs(UnmanagedType.Currency)> value As Decimal)
         Me._money = value
      End Set   
   End Property