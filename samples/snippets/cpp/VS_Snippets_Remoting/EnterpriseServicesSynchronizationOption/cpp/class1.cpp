// <snippet0>
#using <System.EnterpriseServices.dll>

using namespace System;
using namespace System::EnterpriseServices;

// References:
// System.EnterpriseServices

// An instance of this class will not join an activity, but can share its
// caller's context even if its caller is configured as NotSupported,
// Supported, Required, or RequiresNew.
[Synchronization(SynchronizationOption::Disabled)]
public ref class SynchronizationAttribute_SynchronizationDisabled :
    public ServicedComponent
{
};

// An instance of this class will not join an activity, and will share its
// caller's context only if its caller is also configured as NotSupported.
[Synchronization(SynchronizationOption::NotSupported)]
public ref class SynchronizationAttribute_SynchronizationNotSupported :
    public ServicedComponent
{
};

// An instance of this class will join its caller's activity if one exists.
[Synchronization(SynchronizationOption::Supported)]
public ref class SynchronizationAttribute_SynchronizationSupported :
    public ServicedComponent
{
};

// An instance of this class will join its caller's activity if one exists.
// If not, a new activity will be created for it.
[Synchronization(SynchronizationOption::Required)]
public ref class SynchronizationAttribute_SynchronizationRequired :
    public ServicedComponent
{
};

// A new activity will always be created for an instance of this class.
[Synchronization(SynchronizationOption::RequiresNew)]
public ref class SynchronizationAttribute_SynchronizationRequiresNew :
    public ServicedComponent
{
};

// </snippet0>
