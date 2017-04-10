// <snippet0>
#using <System.EnterpriseServices.dll>

using namespace System;
using namespace System::EnterpriseServices;
using namespace System::Reflection;

// References:
// System.EnterpriseServices

// An instance of this class will inherit its caller's transaction isolation
// level if available. If not, it will use isolation level Serializable.
[Transaction(Isolation=TransactionIsolationLevel::Any)]
public ref class IsolationAny : public ServicedComponent
{
};

// An instance of this class will read only committed data, but non-repeatable
// reads and phantom rows are still possible.
[Transaction(Isolation=TransactionIsolationLevel::ReadCommitted)]
public ref class IsolationReadCommitted : public ServicedComponent
{
};

// An instance of this class will read committed and uncommitted data, so dirty
// reads, non-repeatable reads, and phantom rows are possible.
[Transaction(Isolation=TransactionIsolationLevel::ReadUncommitted)]
public ref class IsolationReadUncommitted : public ServicedComponent
{
};

// An instance of this class will read only committed data and place shared
// locks on the data, preventing other users from modifying it, but other users
// can still insert rows into the data set, so phantom rows are still possible.
[Transaction(Isolation=TransactionIsolationLevel::RepeatableRead)]
public ref class IsolationRepeatableRead : public ServicedComponent
{
};

// An instance of this class will read only committed data and place a range
// lock on the data set, preventing other users from updating or inserting rows
// into the data set until its transaction is complete.
[Transaction(Isolation=TransactionIsolationLevel::Serializable)]
public ref class IsolationSerializable : public ServicedComponent
{
};

// </snippet0>
