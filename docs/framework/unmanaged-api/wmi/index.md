---
title: WMI and Performance Counters (Unmanaged API Reference)
description: Summarizes the .NET Framework unmanaged API for WMI and performance counter information.
author: rpetrusha
ms.author: ronpet
manager: wpickett
ms.date: 11/06/2017
ms.topic: reference
ms.prod: .net-framework
ms.devlang: cpp
ms.workload: 
  - dotnet
---
# Windows Management Instrumentation (WMI) and Performance Counters (Unmanaged API Reference)

The .NET Framework WMI and Performance Counters unmanaged API consists of a set of functions that wrap calls to the [native Windows Management Instrumentation API](https://msdn.microsoft.com/library/aa389276(v=vs.85).aspx). It allows you to develop tools and libraries that manage and monitor remote computer systems.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
The API includes the following functions:

| Function | Description |
|---------|---------|
| [BeginEnumeration function](beginenumeration.md) | Resets the enumerator to the beginning of an enumeration of WMI object properties. |
| [BeginMethodEnumeration function](beginmethodenumeration.md) |  Begins an enumeration of the methods available for an object. |
| [BlessIWbemServices function](blessiwbemservices.md) | Indicates whether the user credentials permit access to a specified IWbemServices class. |
| [BlessIWbemServicesObject function](blessiwbemservicesobject.md) | Indicates whether the user credentials permit access to a specified IWbem service object. |
| [Clone function](clone.md) | Returns a new object that is a complete clone of the current object. |
| [CloneEnumWbemClassObject function](cloneenumwbemclassobject.md) | Makes a logical copy of an enumerator, retaining its current position in an enumeration. |
| [CompareTo function](compareto.md) | Compares an object to another Windows management object. |
| [ConnectServerWmi function](connectserverwmi.md) | Creates a connection through DCOM to a WMI namespace on a specified computer. |
| [CreateClassEnumWmi function](createclassenumwmi.md) | Returns an enumerator for all classes that satisfy the specified selection criteria. |
| [CreateInstanceEnumWmi function](createinstanceenumwmi.md) | Returns an enumerator that returns the intances of a specified class that meet specified selection criteria. |
| [Delete function](delete.md) | Deletes a specified property from a class definition and all of its qualifiers. |
| [DeleteMethod function](deletemethod.md) | Deletes a specified method from a CIM class definition. |
| [EndEnumeration function](endenumeration.md) | Terminates an enumeration sequence. | 
| [EndMethodEnumeration function](endmethodenumeration.md) | Terminates an enumeration sequence started by calling the  [BeginMethodEnumeration function](beginmethodenumeration.md). |
| [ExecNotificationQueryWmi function](execnotificationquerywmi.md) | Executes a query to receive events. |
| [ExecQueryWmi function](execquerywmi.md) | Executes a query to retrieve objects. |
| [FormatFromRawValue function](formatfromrawvalue.md) | Converts one raw performance data value to the specified format, or two raw performance data values if the format conversion is time-based. | 
| [Get function](get.md) | Retrieves a specified property value if it exists. |
| [GetCurrentApartmentType function](getcurrentapartmenttype.md) | Retrieves the type of apartment in which the caller is executing. |
| [GetDemultiplexedStub function](getdemultiplexedstub.md) | Creates an object forwarder sink to assist a client in receiving asynchronous calls from Windows Management. |
| [GetErrorInfo function](geterrorinfo.md) | Retrieves error information from the previous function call. | 
| [GetMethod function](getmethod.md) | Retrieves information about the specified method. | 
| [GetMethodOrigin function](getmethodorigin.md) | Determines the class in which a method is declared. |
| [GetMethodQualifierSet function](getmethodqualifierset.md) | Retrieves the qualifier set for a particular method. |
| [GetNames function](getnames.md) | Retrieves either a subset or all of the names of the properties of an object. |
| [GetObjectText function](getobjecttext.md) | Returns a textual rendering of an object in the MOF syntax. | 
| [GetPropertyHandle function](getpropertyhandle.md) | Returns a unique handle that identifies a property. |
| [GetPropertyOrigin function](getpropertyorigin.md) | Determines the class in which a property is declared. |
| [GetPropertyQualifierSet function](getpropertyqualifierset.md) | Retrieves the qualifier set for a particular property.  |
| [GetQualifierSet function](getqualifierset.md) | Retrieves the qualifier set for a class instance or a class definition. |
| [InheritsFrom function](inheritsfrom.md) | Determines whether the current class or instance derives from a specified parent class. |
| [Initialize function](initialize.md) | Performs WMI initialization. |
| [Next function](next.md) | Retrieves the next property in an enumeration. | 
| [NextMethod function](nextmethod.md) | Retrieves the next method in an enumeration. |
| [Put function](put.md) | Sets a named property to a new value. |
| [PutClassWmi function](putclasswmi.md) | Creates a new class or updates an existing one. |
| [PutInstanceWmi function](putinstancewmi.md) | Creates or updates an instance of an existing class. The instance is written to the WMI repository. |
| [PutMethod function](putmethod.md) | Creates a method. |
| [QualifierSet_BeginEnumeration function](qualifierset-beginenumeration.md) | Resets an enumerator of the qualifiers of an object to the beginning of the enumeration. |
| [QualifierSet_Delete function](qualifierset-delete.md) | Deletes a specified qualifier by name.  |
| [QualifierSet_EndEnumeration function](qualifierset-endenumeration.md) | Terminates the enumeration begun with a call to the `QualifierSet_BeginEnumeration` function. |
| [QualifierSet_Get function](qualifierset-get.md) | Gets the specified named qualifier.  |
| [QualifierSet_GetNames function](qualifierset-getnames.md) | Retrieves the names of all qualifiers or of specified qualifiers that are available from the current object or property. |
| [QualifierSet_Next function](qualifierset-next.md) | Retrieves the next qualifier in an enumeration that started with a call to the [QualifierSet_BeginEnumeration](qualifierset-beginenumeration.md) function. |
| [QualifierSet_Put function](qualifierset-put.md) | Writes the named qualifier and value. |
| [ResetSecurity function](resetsecurity.md) | Assigns the supplied impersonation token to the current thread. |
| [SetSecurity function](setsecurity.md) | Retrieves the impersonation token associated with the current thread. |
| [SpawnDerivedClass function](spawnderivedclass.md) | Creates a newly derived class object from a specified object. | 
| [SpawnInstance function](spawninstance.md) | Creates a new instance of a class. |   
| [VerifyClient function](verifyclientkey.md) | Ensures that the client key has the correct security. |
| [WritePropertyValue function](writepropertyvalue.md) | Writes a specified number of bytes to a property identified by a property handle. |

 ## See also
[Unmanaged API reference](../index.md) 
