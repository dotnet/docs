[Transaction(TransactionOption.Supported)]
public class TransactionAttribute_Ctor_TransactionOption : ServicedComponent
{
}

[Transaction(TransactionOption.Supported,
     Isolation=TransactionIsolationLevel.Serializable)]
public class TransactionAttribute_Ctor_TransactionOption_Isolation :
    ServicedComponent
{
}

[Transaction(TransactionOption.Supported,
     Isolation=TransactionIsolationLevel.Serializable,
     Timeout=30)]
public class TransactionAttribute_Ctor_TransactionOption_Isolation_Timeout :
     ServicedComponent
{
}