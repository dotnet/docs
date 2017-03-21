<Transaction(TransactionOption.Supported)>  _
Public Class TransactionAttribute_Ctor_TransactionOption
    Inherits ServicedComponent
End Class 'TransactionAttribute_Ctor_TransactionOption

<Transaction(TransactionOption.Supported, Isolation := TransactionIsolationLevel.Serializable)>  _
Public Class TransactionAttribute_Ctor_TransactionOption_Isolation
    Inherits ServicedComponent
End Class 'TransactionAttribute_Ctor_TransactionOption_Isolation

<Transaction(TransactionOption.Supported, Isolation := TransactionIsolationLevel.Serializable, Timeout := 30)>  _
Public Class TransactionAttribute_Ctor_TransactionOption_Isolation_Timeout
    Inherits ServicedComponent
End Class 'TransactionAttribute_Ctor_TransactionOption_Isolation_Timeout