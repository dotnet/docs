// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// An instance of this class will not participate in transactions, but can
// share its caller's context even if its caller is configured as
// NotSupported, Supported, Required, or RequiresNew.
[Transaction(TransactionOption.Disabled)]
public class TransactionAttribute_TransactionDisabled : ServicedComponent
{
}

// An instance of this class will not participate in transactions, and will
// share its caller's context only if its caller is also configured as
// NotSupported.
[Transaction(TransactionOption.NotSupported)]
public class TransactionAttribute_TransactionNotSupported : ServicedComponent
{
}

// An instance of this class will participate in its caller's transaction
// if one exists.
[Transaction(TransactionOption.Supported)]
public class TransactionAttribute_TransactionSupported : ServicedComponent
{
}

// An instance of this class will participate in its caller's transaction
// if one exists. If not, a new transaction will be created for it.
[Transaction(TransactionOption.Required)]
public class TransactionAttribute_TransactionRequired : ServicedComponent
{
}

// A new transaction will always be created for an instance of this class.
[Transaction(TransactionOption.RequiresNew)]
public class TransactionAttribute_TransactionRequiresNew : ServicedComponent
{
}
// </snippet0>