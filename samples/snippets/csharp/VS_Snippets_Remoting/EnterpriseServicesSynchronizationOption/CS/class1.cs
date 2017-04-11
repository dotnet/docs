// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// An instance of this class will not join an activity, but can share its
// caller's context even if its caller is configured as NotSupported,
// Supported, Required, or RequiresNew.
[Synchronization(SynchronizationOption.Disabled)]
public class SynchronizationAttribute_SynchronizationDisabled :
    ServicedComponent
{
}

// An instance of this class will not join an activity, and will share its
// caller's context only if its caller is also configured as NotSupported.
[Synchronization(SynchronizationOption.NotSupported)]
public class SynchronizationAttribute_SynchronizationNotSupported :
    ServicedComponent
{
}

// An instance of this class will join its caller's activity if one exists.
[Synchronization(SynchronizationOption.Supported)]
public class SynchronizationAttribute_SynchronizationSupported :
    ServicedComponent
{
}

// An instance of this class will join its caller's activity if one exists.
// If not, a new activity will be created for it.
[Synchronization(SynchronizationOption.Required)]
public class SynchronizationAttribute_SynchronizationRequired :
    ServicedComponent
{
}

// A new activity will always be created for an instance of this class.
[Synchronization(SynchronizationOption.RequiresNew)]
public class SynchronizationAttribute_SynchronizationRequiresNew :
    ServicedComponent
{
}

// </snippet0>