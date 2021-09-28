---
description: "Learn more about: Diagnostics Symbol Store Interfaces"
title: "Diagnostics Symbol Store Interfaces"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "unmanaged interfaces [.NET Framework], debugging"
  - "diagnostics symbol store interfaces [.NET Framework]"
  - "interfaces [.NET Framework], diagnostics symbol store"
  - "unmanaged interfaces [.NET Framework], diagnostics symbol store"
  - "debugging interfaces [.NET Framework]"
  - "interfaces [.NET Framework debugging]"
ms.assetid: f96987d5-e6a5-478b-ac5e-302e16545cce
---
# Diagnostics Symbol Store Interfaces

This topic describes the unmanaged interfaces that enable a compiler to generate symbol information for use by a debugger.  
  
## In This Section  

 [IBindingDisplay Interface](ibindingdisplay-interface.md)  
 Provides methods that display current binding information about the running application.  
  
 [IDebugAutoAttach Interface](idebugautoattach-interface.md)  
 Defines the interface for a server-invoked debugger auto attach.  
  
 [INotifyConnection2 Interface](inotifyconnection2-interface.md)  
 Declares methods for registering and unregistering a connection notification source.  
  
 [INotifySink2 Interface](inotifysink2-interface.md)  
 Declares methods for sink notification.  
  
 [INotifySource2 Interface](inotifysource2-interface.md)  
 Declares a method for setting notification filters.  
  
 [ISymENCUnmanagedMethod Interface](isymencunmanagedmethod-interface.md)  
 Provides information for the Edit and Continue feature.  
  
 [ISymUnmanagedAsyncMethod Interface](isymunmanagedasyncmethod-interface.md)  
 This interface is the reading complement to [ISymUnmanagedAsyncMethodPropertiesWriter Interface](isymunmanagedasyncmethodpropertieswriter-interface.md).  
  
 [ISymUnmanagedAsyncMethodPropertiesWriter Interface](isymunmanagedasyncmethodpropertieswriter-interface.md)  
 Allows definition of optional async method information per method symbol. Must use with an opened method (that is, between calls to the [OpenMethod Method](isymunmanagedwriter-openmethod-method.md)and the [CloseMethod Method](isymunmanagedwriter-closemethod-method.md)).  
  
 [ISymUnmanagedBinder Interface](isymunmanagedbinder-interface.md)  
 Represents a symbol binder for unmanaged code.  
  
 [ISymUnmanagedBinder2 Interface](isymunmanagedbinder2-interface.md)  
 Represents a symbol binder for unmanaged code, and extends the `ISymUnmanagedBinder` interface.  
  
 [ISymUnmanagedBinder3 Interface](isymunmanagedbinder3-interface.md)  
 Represents a symbol binder for unmanaged code, and extends the `ISymUnmanagedBinder` interface.  
  
 [ISymUnmanagedConstant Interface](isymunmanagedconstant-interface.md)  
 Provides access to unmanaged constants.  
  
 [ISymUnmanagedDispose Interface](isymunmanageddispose-interface.md)  
 Disposes of unmanaged resources.  
  
 [ISymUnmanagedDocument Interface](isymunmanageddocument-interface.md)  
 Represents a document referenced by a symbol store.  
  
 [ISymUnmanagedDocumentWriter Interface](isymunmanageddocumentwriter-interface.md)  
 Provides methods for writing to a document referenced by a symbol store.  
  
 [ISymUnmanagedENCUpdate Interface](isymunmanagedencupdate-interface.md)  
 Provides methods for the Edit and Continue feature.  
  
 [ISymUnmanagedMethod Interface](isymunmanagedmethod-interface.md)  
 Represents a method within the symbol store.  
  
 [ISymUnmanagedNamespace Interface](isymunmanagednamespace-interface.md)  
 Represents a namespace.  
  
 [ISymUnmanagedReader Interface](isymunmanagedreader-interface.md)  
 Represents a symbol reader that provides access to documents, methods, and variables within a symbol store.  
  
 [ISymUnmanagedReader2 Interface](isymunmanagedreader2-interface.md)  
 Gets a symbol reader method given a method token and an edit-and-copy version number.  
  
 [ISymUnmanagedReaderSymbolSearchInfo Interface](isymunmanagedreadersymbolsearchinfo-interface.md)  
 Provides methods that get symbol search information.  
  
 [ISymUnmanagedScope Interface](isymunmanagedscope-interface.md)  
 Represents a lexical scope within a method.  
  
 [ISymUnmanagedScope2 Interface](isymunmanagedscope2-interface.md)  
 Represents a lexical scope within a method, and extends the `ISymUnmanagedScope` interface with methods that get information about constants defined within the scope..  
  
 [ISymUnmanagedSourceServerModule Interface](isymunmanagedsourceservermodule-interface.md)  
 Provides source server data for a module.  
  
 [ISymUnmanagedSymbolSearchInfo Interface](isymunmanagedsymbolsearchinfo-interface.md)  
 Provides methods that get information about the search path.  
  
 [ISymUnmanagedVariable Interface](isymunmanagedvariable-interface.md)  
 Represents a variable, such as a parameter, a local variable, or a field.  
  
 [ISymUnmanagedWriter Interface](isymunmanagedwriter-interface.md)  
 Represents a symbol writer, and provides methods to define documents, sequence points, lexical scopes, and variables.  
  
 [ISymUnmanagedWriter2 Interface](isymunmanagedwriter2-interface.md)  
 Represents a symbol writer, and provides methods to define documents, sequence points, lexical scopes, and variables. Extends the `ISymUnmanagedWriter` interface.  
  
 [ISymUnmanagedWriter3 Interface](isymunmanagedwriter3-interface.md)  
 Represents a symbol writer, and provides methods to define documents, sequence points, lexical scopes, and variables. Extends the `ISymUnmanagedWriter` interface.  
  
 [ISymUnmanagedWriter4 Interface](isymunmanagedwriter4-interface.md)  
 ISymUnmanagedWriter4 interface.  
  
 [ISymUnmanagedWriter5 Interface](isymunmanagedwriter5-interface.md)  
 ISymUnmanagedWriter5 interface.  
  
## Related Sections  

 [Diagnostics Symbol Store Enumerations](diagnostics-symbol-store-enumerations.md)  
  
 [Diagnostics Symbol Store Structures](diagnostics-symbol-store-structures.md)  
  
 [Debugging](../debugging/index.md)
