// <snippet0>
#using <System.EnterpriseServices.dll>

using namespace System;
using namespace System::EnterpriseServices;
using namespace System::Reflection;

// References:
// System.EnterpriseServices

// An instance of this class will not participate in transactions, but can
// share its caller's context even if its caller is configured as
// NotSupported, Supported, Required, or RequiresNew.
[Transaction(TransactionOption::Disabled)]
public ref class TransactionDisabled : public ServicedComponent
{
};

// An instance of this class will not participate in transactions, and will
// share its caller's context only if its caller is also configured as
// NotSupported.
[Transaction(TransactionOption::NotSupported)]
public ref class TransactionNotSupported : public ServicedComponent
{
};

// An instance of this class will participate in its caller's transaction
// if one exists.
[Transaction(TransactionOption::Supported)]
public ref class TransactionSupported : public ServicedComponent
{
};

// An instance of this class will participate in its caller's transaction
// if one exists. If not, a new transaction will be created for it.
[Transaction(TransactionOption::Required)]
public ref class TransactionRequired : public ServicedComponent
{
};

// A new transaction will always be created for an instance of this class.
[Transaction(TransactionOption::RequiresNew)]
public ref class TransactionRequiresNew : public ServicedComponent
{
};
// </snippet0>
