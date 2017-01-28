---
title: "System.ComponentModel namespaces for UWP apps | Microsoft Docs"
ms.custom: ""
ms.date: "12/14/2016"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ea42fce2-0e54-4041-bf62-4bb1a879e2b7
caps.latest.revision: 5
author: "msatranjr"
ms.author: "misatran"
manager: "markl"
---
# System.ComponentModel namespaces for UWP apps
`System.ComponentModel`, `System.ComponentModel.DataAnnotations`, and `System.ComponentModel.DataAnnotations.Schema` contain types that implement the run-time and design-time behavior of components and controls.  
  
 This topic displays the types in the `System.ComponentModel` namespaces that are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]. Note that [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)].  
  
## System.ComponentModel namespace  
  
|Types supported in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.ComponentModel.ArrayConverter>|Provides a type converter to convert Array objects to and from various other representations.|  
|<xref:System.ComponentModel.AsyncCompletedEventArgs>|Provides data for the MethodNameCompleted event.|  
|<xref:System.ComponentModel.AsyncCompletedEventHandler>|Represents the method that will handle the MethodNameCompleted event of an asynchronous operation.|  
|<xref:System.ComponentModel.AsyncOperation>|Tracks the lifetime of an asynchronous operation.|  
|<xref:System.ComponentModel.AsyncOperationManager>|Provides concurrency management for classes that support asynchronous method calls. This class cannot be inherited.|  
|<xref:System.ComponentModel.BackgroundWorker>|Executes an operation on a separate thread.|  
|<xref:System.ComponentModel.BaseNumberConverter>|Provides a base type converter for nonfloating-point numerical types.|  
|<xref:System.ComponentModel.BooleanConverter>|Provides a type converter to convert Boolean objects to and from various other representations.|  
|<xref:System.ComponentModel.ByteConverter>|Provides a type converter to convert 8-bit unsigned integer objects to and from various other representations.|  
|<xref:System.ComponentModel.CancelEventArgs>|Provides data for a cancelable event.|  
|<xref:System.ComponentModel.CharConverter>|Provides a type converter to convert Unicode character objects to and from various other representations.|  
|<xref:System.ComponentModel.CollectionConverter>|Provides a type converter to convert collection objects to and from various other representations.|  
|<xref:System.ComponentModel.ComponentCollection>|Provides a read-only container for a collection of IComponent objects.|  
|<xref:System.ComponentModel.DataErrorsChangedEventArgs>|Provides data for the INotifyDataErrorInfo.ErrorsChanged event.|  
|<xref:System.ComponentModel.DateTimeConverter>|Provides a type converter to convert DateTime objects to and from various other representations.|  
|<xref:System.ComponentModel.DateTimeOffsetConverter>|Provides a type converter to convert DateTimeOffset structures to and from various other representations.|  
|<xref:System.ComponentModel.DecimalConverter>|Provides a type converter to convert Decimal objects to and from various other representations.|  
|<xref:System.ComponentModel.DefaultValueAttribute>|Specifies the default value for a property.|  
|<xref:System.ComponentModel.DoubleConverter>|Provides a type converter to convert double-precision; floating point number objects to and from various other representations.|  
|<xref:System.ComponentModel.DoWorkEventArgs>|Provides data for the DoWork event handler.|  
|<xref:System.ComponentModel.DoWorkEventHandler>|Represents the method that will handle the DoWork event. This class cannot be inherited.|  
|<xref:System.ComponentModel.EditorBrowsableAttribute>|Specifies that a property or method is viewable in an editor. This class cannot be inherited.|  
|<xref:System.ComponentModel.EditorBrowsableState>|Specifies the browsable state of a property or method from within an editor.|  
|<xref:System.ComponentModel.EnumConverter>|Provides a type converter to convert Enum objects to and from various other representations.|  
|<xref:System.ComponentModel.GuidConverter>|Provides a type converter to convert Guid objects to and from various other representations.|  
|<xref:System.ComponentModel.IChangeTracking>|Defines the mechanism for querying the object for changes and resetting of the changed status.|  
|<xref:System.ComponentModel.IComponent>|Provides functionality required by all components.|  
|<xref:System.ComponentModel.IContainer>|Provides functionality for containers. Containers are objects that logically contain zero or more components.|  
|<xref:System.ComponentModel.IEditableObject>|Provides functionality to commit or roll back changes to an object that is used as a data source.|  
|<xref:System.ComponentModel.INotifyDataErrorInfo>|Defines members that data entity classes can implement to provide custom synchronous and asynchronous validation support.|  
|<xref:System.ComponentModel.INotifyPropertyChanged>|Notifies clients that a property value has changed.|  
|<xref:System.ComponentModel.INotifyPropertyChanging>|Notifies clients that a property value is changing.|  
|<xref:System.ComponentModel.Int16Converter>|Provides a type converter to convert 16-bit signed integer objects to and from other representations.|  
|<xref:System.ComponentModel.Int32Converter>|Provides a type converter to convert 32-bit signed integer objects to and from other representations.|  
|<xref:System.ComponentModel.Int64Converter>|Provides a type converter to convert 64-bit signed integer objects to and from various other representations.|  
|<xref:System.ComponentModel.IRevertibleChangeTracking>|Provides support for rolling back the changes|  
|<xref:System.ComponentModel.ISite>|Provides functionality required by sites.|  
|<xref:System.ComponentModel.ITypeDescriptorContext>|Provides contextual information about a component; such as its container and property descriptor.|  
|<xref:System.ComponentModel.MultilineStringConverter>|Provides a type converter to convert multiline strings to a simple string.|  
|<xref:System.ComponentModel.NullableConverter>|Provides automatic conversion between a nullable type and its underlying primitive type.|  
|<xref:System.ComponentModel.ProgressChangedEventArgs>|Provides data for the ProgressChanged event.|  
|<xref:System.ComponentModel.ProgressChangedEventHandler>|Represents the method that will handle the ProgressChanged event of the BackgroundWorker class. This class cannot be inherited.|  
|<xref:System.ComponentModel.PropertyChangedEventArgs>|Provides data for the PropertyChanged event.|  
|<xref:System.ComponentModel.PropertyChangedEventHandler>|Represents the method that will handle the PropertyChanged event raised when a property is changed on a component.|  
|<xref:System.ComponentModel.PropertyChangingEventArgs>|Provides data for the PropertyChanging event.|  
|<xref:System.ComponentModel.PropertyChangingEventHandler>|Represents the method that will handle the PropertyChanging event of an INotifyPropertyChanging interface.|  
|<xref:System.ComponentModel.PropertyDescriptor>|Provides an abstraction of a property on a class.|  
|<xref:System.ComponentModel.RunWorkerCompletedEventArgs>|Provides data for the MethodNameCompleted event.|  
|<xref:System.ComponentModel.RunWorkerCompletedEventHandler>|Represents the method that will handle the RunWorkerCompleted event of a BackgroundWorker class.|  
|<xref:System.ComponentModel.SByteConverter>|Provides a type converter to convert 8-bit unsigned integer objects to and from a string.|  
|<xref:System.ComponentModel.SingleConverter>|Provides a type converter to convert single-precision; floating point number objects to and from various other representations.|  
|<xref:System.ComponentModel.StringConverter>|Provides a type converter to convert string objects to and from other representations.|  
|<xref:System.ComponentModel.TimeSpanConverter>|Provides a type converter to convert TimeSpan objects to and from other representations.|  
|<xref:System.ComponentModel.TypeConverter>|Provides a unified way of converting types of values to other types; as well as for accessing standard values and subproperties.|  
|<xref:System.ComponentModel.TypeConverterAttribute>|Specifies what type to use as a converter for the object this attribute is bound to.|  
|<xref:System.ComponentModel.TypeDescriptor>|Provides information about the characteristics for a component; such as its attributes; properties; and events. This class cannot be inherited.|  
|<xref:System.ComponentModel.TypeListConverter>|Provides a type converter that can be used to populate a list box with available types.|  
|<xref:System.ComponentModel.UInt16Converter>|Provides a type converter to convert 16-bit unsigned integer objects to and from other representations.|  
|<xref:System.ComponentModel.UInt32Converter>|Provides a type converter to convert 32-bit unsigned integer objects to and from various other representations.|  
|<xref:System.ComponentModel.UInt64Converter>|Provides a type converter to convert 64-bit unsigned integer objects to and from other representations.|  
|<xref:System.ComponentModel.Win32Exception>|Throws an exception for a Win32 error code.|  
  
## System.ComponentModel.DataAnnotations namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.ComponentModel.DataAnnotations.AssociationAttribute>|Specifies that an entity member represents a data relationship, such as a foreign key relationship.|  
|<xref:System.ComponentModel.DataAnnotations.CompareAttribute>|Provides an attribute that compares two properties.|  
|<xref:System.ComponentModel.DataAnnotations.ConcurrencyCheckAttribute>|Specifies that a property participates in optimistic concurrency checks.|  
|<xref:System.ComponentModel.DataAnnotations.CreditCardAttribute>|Specifies that a data field value is a credit card number.|  
|<xref:System.ComponentModel.DataAnnotations.CustomValidationAttribute>|Specifies a custom validation method that is used to validate a property or class instance.|  
|<xref:System.ComponentModel.DataAnnotations.DataType>|Represents an enumeration of the data types associated with data fields and parameters.|  
|<xref:System.ComponentModel.DataAnnotations.DataTypeAttribute>|Specifies the name of an additional type to associate with a data field.|  
|<xref:System.ComponentModel.DataAnnotations.DisplayAttribute>|Provides a general-purpose attribute that lets you specify localizable strings for types and members of entity partial classes.|  
|<xref:System.ComponentModel.DataAnnotations.DisplayColumnAttribute>|Specifies the column that is displayed in the referred table as a foreign-key column.|  
|<xref:System.ComponentModel.DataAnnotations.DisplayFormatAttribute>|Specifies how data fields are displayed and formatted.|  
|<xref:System.ComponentModel.DataAnnotations.EditableAttribute>|Indicates whether a data field is editable.|  
|<xref:System.ComponentModel.DataAnnotations.EmailAddressAttribute>|Validates an email address.|  
|<xref:System.ComponentModel.DataAnnotations.EnumDataTypeAttribute>|Enables a .NET Framework enumeration to be mapped to a data column.|  
|<xref:System.ComponentModel.DataAnnotations.FileExtensionsAttribute>|Validates file name extensions.|  
|<xref:System.ComponentModel.DataAnnotations.FilterUIHintAttribute>|Represents an attribute that is used to specify the filtering behavior for a column.|  
|<xref:System.ComponentModel.DataAnnotations.IValidatableObject>|Provides a way for an object to be invalidated.|  
|<xref:System.ComponentModel.DataAnnotations.KeyAttribute>|Denotes one or more properties that uniquely identify an entity.|  
|<xref:System.ComponentModel.DataAnnotations.MaxLengthAttribute>|Specifies the maximum length of array or string data allowed in a property.|  
|<xref:System.ComponentModel.DataAnnotations.MinLengthAttribute>|Specifies the minimum length of array or string data allowed in a property.|  
|<xref:System.ComponentModel.DataAnnotations.PhoneAttribute>|Specifies that a data field value is a  well-formed phone number using a regular expression for phone numbers.|  
|<xref:System.ComponentModel.DataAnnotations.RangeAttribute>|Specifies the numeric range constraints for the value of a data field.|  
|<xref:System.ComponentModel.DataAnnotations.RegularExpressionAttribute>|Specifies that a data field value must match the specified regular expression.|  
|<xref:System.ComponentModel.DataAnnotations.RequiredAttribute>|Specifies that a data field value is required.|  
|<xref:System.ComponentModel.DataAnnotations.ScaffoldColumnAttribute>|Specifies whether a class or data column uses scaffolding.|  
|<xref:System.ComponentModel.DataAnnotations.StringLengthAttribute>|Specifies the minimum and maximum length of characters that are allowed in a data field.|  
|<xref:System.ComponentModel.DataAnnotations.TimestampAttribute>|Specifies the data type of the column as a row version.|  
|<xref:System.ComponentModel.DataAnnotations.UIHintAttribute>|Specifies the template or user control used to display a data field.|  
|<xref:System.ComponentModel.DataAnnotations.UrlAttribute>|Provides URL validation.|  
|<xref:System.ComponentModel.DataAnnotations.ValidationAttribute>|Serves as the base class for all validation attributes.|  
|<xref:System.ComponentModel.DataAnnotations.ValidationContext>|Describes the context in which a validation check is performed.|  
|<xref:System.ComponentModel.DataAnnotations.ValidationException>|Represents the exception that occurs during validation of a data field when the ValidationAttribute class is used.|  
|<xref:System.ComponentModel.DataAnnotations.ValidationResult>|Represents a container for the results of a validation request.|  
|<xref:System.ComponentModel.DataAnnotations.Validator>|Defines a helper class that can be used to validate objects, properties, and methods when it is included in their associated ValidationAttribute attributes.|  
  
## System.ComponentModel.DataAnnotations.Schema namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]||  
|----------------------------------------------------------------------------------------------|-|  
|<xref:System.ComponentModel.DataAnnotations.Schema.ColumnAttribute>|Represents the database column that a property is mapped to.|  
|<xref:System.ComponentModel.DataAnnotations.Schema.ComplexTypeAttribute>|Denotes that the class is a complex type. Complex types are non-scalar properties of entity types that enable scalar properties to be organized within entities. Complex types do not have keys and cannot be managed by the Entity Framework apart from the parent object.|  
|<xref:System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute>|Represents a database generated attribute.|  
|<xref:System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption>|Enumerates a database generated options.|  
|<xref:System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute>|Denotes a property used as a foreign key in a relationship. The annotation may be placed on the foreign key property and specify the associated navigation property name; or placed on a navigation property and specify the associated foreign key name.|  
|<xref:System.ComponentModel.DataAnnotations.Schema.InversePropertyAttribute>|Specifies the inverse of a navigation property that represents the other end of the same relationship.|  
|<xref:System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute>|Denotes that a property or class should be excluded from database mapping.|  
|<xref:System.ComponentModel.DataAnnotations.Schema.TableAttribute>|Specifies the database table that a class is mapped to.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)