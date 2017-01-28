---
title: "System.ComponentModel namespaces1 | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1174bd7f-9043-4ec3-87c4-6d5de0a71cd6
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# System.ComponentModel namespaces1
`System.ComponentModel`, `System.ComponentModel.DataAnnotations`, and `System.ComponentModel.DataAnnotations.Schema` contain types that implement the run-time and design-time behavior of components and controls.  
  
 This topic displays the types in the `System.ComponentModel` namespaces that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.ComponentModel namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.ComponentModel.AsyncCompletedEventArgs>|Provides data for the MethodNameCompleted event.|  
|<xref:System.ComponentModel.AsyncCompletedEventHandler>|Represents the method that will handle the MethodNameCompleted event of an asynchronous operation.|  
|<xref:System.ComponentModel.CancelEventArgs>|Provides data for a cancelable event.|  
|<xref:System.ComponentModel.DataErrorsChangedEventArgs>|Provides data for the INotifyDataErrorInfo.ErrorsChanged event.|  
|<xref:System.ComponentModel.DefaultValueAttribute>|Specifies the default value for a property.|  
|<xref:System.ComponentModel.EditorBrowsableAttribute>|Specifies that a property or method is viewable in an editor. This class cannot be inherited.|  
|<xref:System.ComponentModel.EditorBrowsableState>|Specifies the browsable state of a property or method from within an editor.|  
|<xref:System.ComponentModel.IChangeTracking>|Defines the mechanism for querying the object for changes and resetting of the changed status.|  
|<xref:System.ComponentModel.IEditableObject>|Provides functionality to commit or roll back changes to an object that is used as a data source.|  
|<xref:System.ComponentModel.INotifyDataErrorInfo>|Defines members that data entity classes can implement to provide custom synchronous and asynchronous validation support.|  
|<xref:System.ComponentModel.INotifyPropertyChanged>|Notifies clients that a property value has changed.|  
|<xref:System.ComponentModel.IRevertibleChangeTracking>|Provides support for rolling back the changes|  
|<xref:System.ComponentModel.ProgressChangedEventArgs>|Provides data for the ProgressChanged event.|  
|<xref:System.ComponentModel.ProgressChangedEventHandler>|Represents the method that will handle the ProgressChanged event of the BackgroundWorker class. This class cannot be inherited.|  
|<xref:System.ComponentModel.PropertyChangedEventArgs>|Provides data for the PropertyChanged event.|  
|<xref:System.ComponentModel.PropertyChangedEventHandler>|Represents the method that will handle the PropertyChanged event raised when a property is changed on a component.|  
  
## System.ComponentModel.DataAnnotations namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.ComponentModel.DataAnnotations.AssociationAttribute>|Specifies that an entity member represents a data relationship, such as a foreign key relationship.|  
|<xref:System.ComponentModel.DataAnnotations.ConcurrencyCheckAttribute>|Specifies that a property participates in optimistic concurrency checks.|  
|<xref:System.ComponentModel.DataAnnotations.CustomValidationAttribute>|Specifies a custom validation method that is used to validate a property or class instance.|  
|<xref:System.ComponentModel.DataAnnotations.DataType>|Represents an enumeration of the data types associated with data fields and parameters.|  
|<xref:System.ComponentModel.DataAnnotations.DataTypeAttribute>|Specifies the name of an additional type to associate with a data field.|  
|<xref:System.ComponentModel.DataAnnotations.DisplayAttribute>|Provides a general-purpose attribute that lets you specify localizable strings for types and members of entity partial classes.|  
|<xref:System.ComponentModel.DataAnnotations.DisplayColumnAttribute>|Specifies the column that is displayed in the referred table as a foreign-key column.|  
|<xref:System.ComponentModel.DataAnnotations.DisplayFormatAttribute>|Specifies how data fields are displayed and formatted.|  
|<xref:System.ComponentModel.DataAnnotations.EditableAttribute>|Indicates whether a data field is editable.|  
|<xref:System.ComponentModel.DataAnnotations.EnumDataTypeAttribute>|Enables a .NET Framework enumeration to be mapped to a data column.|  
|<xref:System.ComponentModel.DataAnnotations.FilterUIHintAttribute>|Represents an attribute that is used to specify the filtering behavior for a column.|  
|<xref:System.ComponentModel.DataAnnotations.KeyAttribute>|Denotes one or more properties that uniquely identify an entity.|  
|<xref:System.ComponentModel.DataAnnotations.RangeAttribute>|Specifies the numeric range constraints for the value of a data field.|  
|<xref:System.ComponentModel.DataAnnotations.RegularExpressionAttribute>|Specifies that a data field value must match the specified regular expression.|  
|<xref:System.ComponentModel.DataAnnotations.RequiredAttribute>|Specifies that a data field value is required.|  
|<xref:System.ComponentModel.DataAnnotations.StringLengthAttribute>|Specifies the minimum and maximum length of characters that are allowed in a data field.|  
|<xref:System.ComponentModel.DataAnnotations.TimestampAttribute>|Specifies the data type of the column as a row version.|  
|<xref:System.ComponentModel.DataAnnotations.UIHintAttribute>|Specifies the template or user control used to display a data field.|  
|<xref:System.ComponentModel.DataAnnotations.ValidationAttribute>|Serves as the base class for all validation attributes.|  
|<xref:System.ComponentModel.DataAnnotations.ValidationContext>|Describes the context in which a validation check is performed.|  
|<xref:System.ComponentModel.DataAnnotations.ValidationException>|Represents the exception that occurs during validation of a data field when the ValidationAttribute class is used.|  
|<xref:System.ComponentModel.DataAnnotations.ValidationResult>|Represents a container for the results of a validation request.|  
|<xref:System.ComponentModel.DataAnnotations.Validator>|Defines a helper class that can be used to validate objects, properties, and methods when it is included in their associated ValidationAttribute attributes.|  
  
## System.ComponentModel.DataAnnotations.Schema namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]||  
|---------------------------------------------------------------------------------------------|-|  
|<xref:System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute>|Represents a database generated attribute.|  
|<xref:System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption>|Enumerates a database generated options.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)