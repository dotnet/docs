---
title: "Attribute-Based Mapping"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6dd89999-f415-4d61-b8c8-237d23d7924e
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Attribute-Based Mapping
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] maps a SQL Server database to a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] object model by either applying attributes or by using an external mapping file. This topic outlines the attribute-based approach.  
  
 In its most elementary form, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] maps a database to a <xref:System.Data.Linq.DataContext>, a table to a class, and columns and relationships to properties on those classes. You can also use attributes to map an inheritance hierarchy in your object model. For more information, see [How to: Generate the Object Model in Visual Basic or C#](../../../../../../docs/framework/data/adonet/sql/linq/how-to-generate-the-object-model-in-visual-basic-or-csharp.md).  
  
 Developers using [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] typically perform attribute-based mapping by using the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)]. You can also use the SQLMetal command-line tool, or you can hand-code the attributes yourself. For more information, see [How to: Generate the Object Model in Visual Basic or C#](../../../../../../docs/framework/data/adonet/sql/linq/how-to-generate-the-object-model-in-visual-basic-or-csharp.md).  
  
> [!NOTE]
>  You can also map by using an external XML file. For more information, see [External Mapping](../../../../../../docs/framework/data/adonet/sql/linq/external-mapping.md).  
  
 The following sections describe attribute-based mapping in more detail. For more information, see the <xref:System.Data.Linq.Mapping> namespace.  
  
## DatabaseAttribute Attribute  
 Use this attribute to specify the default name of the database when a name is not supplied by the connection. This attribute is optional, but if you use it, you must apply the <xref:System.Data.Linq.Mapping.DatabaseAttribute.Name%2A> property, as described in the following table.  
  
|Property|Type|Default|Description|  
|--------------|----------|-------------|-----------------|  
|<xref:System.Data.Linq.Mapping.DatabaseAttribute.Name%2A>|String|See <xref:System.Data.Linq.Mapping.DatabaseAttribute.Name%2A>|Used with its <xref:System.Data.Linq.Mapping.DatabaseAttribute.Name%2A> property, specifies the name of the database.|  
  
 For more information, see <xref:System.Data.Linq.Mapping.DatabaseAttribute>.  
  
## TableAttribute Attribute  
 Use this attribute to designate a class as an entity class that is associated with a database table or view. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] treats classes that have this attribute as persistent classes. The following table describes the <xref:System.Data.Linq.Mapping.TableAttribute.Name%2A> property.  
  
|Property|Type|Default|Description|  
|--------------|----------|-------------|-----------------|  
|<xref:System.Data.Linq.Mapping.TableAttribute.Name%2A>|String|Same string as class name|Designates a class as an entity class associated with a database table.|  
  
 For more information, see <xref:System.Data.Linq.Mapping.TableAttribute>.  
  
## ColumnAttribute Attribute  
 Use this attribute to designate a member of an entity class to represent a column in a database table. You can apply this attribute to any field or property.  
  
 Only those members you identify as columns are retrieved and persisted when [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] saves changes to the database. Members without this attribute are assumed to be non-persistent and are not submitted for inserts or updates.  
  
 The following table describes properties of this attribute.  
  
|Property|Type|Default|Description|  
|--------------|----------|-------------|-----------------|  
|<xref:System.Data.Linq.Mapping.ColumnAttribute.AutoSync%2A>|AutoSync|Never|Instructs the common language runtime (CLR) to retrieve the value after an insert or update operation.<br /><br /> Options: Always, Never, OnUpdate, OnInsert.|  
|<xref:System.Data.Linq.Mapping.ColumnAttribute.CanBeNull%2A>|Boolean|`true`|Indicates that a column can contain null values.|  
|<xref:System.Data.Linq.Mapping.ColumnAttribute.DbType%2A>|String|Inferred database column type|Uses database types and modifiers to specify the type of the database column.|  
|<xref:System.Data.Linq.Mapping.ColumnAttribute.Expression%2A>|String|Empty|Defines a computed column in a database.|  
|<xref:System.Data.Linq.Mapping.ColumnAttribute.IsDbGenerated%2A>|Boolean|`false`|Indicates that a column contains values that the database auto-generates.|  
|<xref:System.Data.Linq.Mapping.ColumnAttribute.IsDiscriminator%2A>|Boolean|`false`|Indicates that the column contains a discriminator value for a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] inheritance hierarchy.|  
|<xref:System.Data.Linq.Mapping.ColumnAttribute.IsPrimaryKey%2A>|Boolean|`false`|Specifies that this class member represents a column that is or is part of the primary keys of the table.|  
|<xref:System.Data.Linq.Mapping.ColumnAttribute.IsVersion%2A>|Boolean|`false`|Identifies the column type of the member as a database timestamp or version number.|  
|<xref:System.Data.Linq.Mapping.ColumnAttribute.UpdateCheck%2A>|UpdateCheck|`Always`, unless <xref:System.Data.Linq.Mapping.ColumnAttribute.IsVersion%2A> is `true` for a member|Specifies how [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] approaches the detection of optimistic concurrency conflicts.|  
  
 For more information, see <xref:System.Data.Linq.Mapping.ColumnAttribute>.  
  
> [!NOTE]
>  AssociationAttribute and ColumnAttribute Storage property values are case sensitive. For example, ensure that values used in the attribute for the AssociationAttribute.Storage property match the case for the corresponding property names used elsewhere in the code. This applies to all .NET programming languages, even those which are not typically case sensitive, including [!INCLUDE[vb_current_short](../../../../../../includes/vb-current-short-md.md)]. For more information about the Storage property, see <xref:System.Data.Linq.Mapping.DataAttribute.Storage%2A?displayProperty=nameWithType>.  
  
## AssociationAttribute Attribute  
 Use this attribute to designate a property to represent an association in the database, such as a foreign key to primary key relationship. For more information about relationships, see [How to: Map Database Relationships](../../../../../../docs/framework/data/adonet/sql/linq/how-to-map-database-relationships.md).  
  
 The following table describes properties of this attribute.  
  
|Property|Type|Default|Description|  
|--------------|----------|-------------|-----------------|  
|<xref:System.Data.Linq.Mapping.AssociationAttribute.DeleteOnNull%2A>|Boolean|`false`|When placed on an association whose foreign key members are all non-nullable, deletes the object when the association is set to null.|  
|<xref:System.Data.Linq.Mapping.AssociationAttribute.DeleteRule%2A>|String|None|Adds delete behavior to an association.|  
|<xref:System.Data.Linq.Mapping.AssociationAttribute.IsForeignKey%2A>|Boolean|`false`|If true, designates the member as the foreign key in an association representing a database relationship.|  
|<xref:System.Data.Linq.Mapping.AssociationAttribute.IsUnique%2A>|Boolean|`false`|If true, indicates a uniqueness constraint on the foreign key.|  
|<xref:System.Data.Linq.Mapping.AssociationAttribute.OtherKey%2A>|String|ID of the related class|Designates one or more members of the target entity class as key values on the other side of the association.|  
|<xref:System.Data.Linq.Mapping.AssociationAttribute.ThisKey%2A>|String|ID of the containing class|Designates members of this entity class to represent the key values on this side of the association.|  
  
 For more information, see <xref:System.Data.Linq.Mapping.AssociationAttribute>.  
  
> [!NOTE]
>  AssociationAttribute and ColumnAttribute Storage property values are case sensitive. For example, ensure that values used in the attribute for the AssociationAttribute.Storage property match the case for the corresponding property names used elsewhere in the code. This applies to all .NET programming languages, even those which are not typically case sensitive, including [!INCLUDE[vb_current_short](../../../../../../includes/vb-current-short-md.md)]. For more information about the Storage property, see <xref:System.Data.Linq.Mapping.DataAttribute.Storage%2A?displayProperty=nameWithType>.  
  
## InheritanceMappingAttribute Attribute  
 Use this attribute to map an inheritance hierarchy.  
  
 The following table describes properties of this attribute.  
  
|Property|Type|Default|Description|  
|--------------|----------|-------------|-----------------|  
|<xref:System.Data.Linq.Mapping.InheritanceMappingAttribute.Code%2A>|String|None. Value must be supplied.|Specifies the code value of the discriminator.|  
|<xref:System.Data.Linq.Mapping.InheritanceMappingAttribute.IsDefault%2A>|Boolean|`false`|If true, instantiates an object of this type when no discriminator value in the store matches any one of the specified values.|  
|<xref:System.Data.Linq.Mapping.InheritanceMappingAttribute.Type%2A>|Type|None. Value must be supplied.|Specifies the type of the class in the hierarchy.|  
  
 For more information, see <xref:System.Data.Linq.Mapping.InheritanceMappingAttribute>.  
  
## FunctionAttribute Attribute  
 Use this attribute to designate a method as representing a stored procedure or user-defined function in the database.  
  
 The following table describes the properties of this attribute.  
  
|Property|Type|Default|Description|  
|--------------|----------|-------------|-----------------|  
|<xref:System.Data.Linq.Mapping.FunctionAttribute.IsComposable%2A>|Boolean|`false`|If false, indicates mapping to a stored procedure. If true, indicates mapping to a user-defined function.|  
|<xref:System.Data.Linq.Mapping.FunctionAttribute.Name%2A>|String|Same string as name in the database|Specifies the name of the stored procedure or user-defined function.|  
  
 For more information, see <xref:System.Data.Linq.Mapping.FunctionAttribute>.  
  
## ParameterAttribute Attribute  
 Use this attribute to map input parameters on stored procedure methods.  
  
 The following table describes properties of this attribute.  
  
|Property|Type|Default|Description|  
|--------------|----------|-------------|-----------------|  
|<xref:System.Data.Linq.Mapping.ParameterAttribute.DbType%2A>|String|None|Specifies database type.|  
|<xref:System.Data.Linq.Mapping.ParameterAttribute.Name%2A>|String|Same string as parameter name in database|Specifies a name for the parameter.|  
  
 For more information, see <xref:System.Data.Linq.Mapping.ParameterAttribute>.  
  
## ResultTypeAttribute Attribute  
 Use this attribute to specify a result type.  
  
 The following table describes properties of this attribute.  
  
|Property|Type|Default|Description|  
|--------------|----------|-------------|-----------------|  
|<xref:System.Data.Linq.Mapping.ResultTypeAttribute.Type%2A>|Type|(None)|Used on methods mapped to stored procedures that return <xref:System.Data.Linq.IMultipleResults>. Declares the valid or expected type mappings for the stored procedure.|  
  
 For more information, see <xref:System.Data.Linq.Mapping.ResultTypeAttribute>.  
  
## DataAttribute Attribute  
 Use this attribute to specify names and private storage fields.  
  
 The following table describes properties of this attribute.  
  
|Property|Type|Default|Description|  
|--------------|----------|-------------|-----------------|  
|<xref:System.Data.Linq.Mapping.DataAttribute.Name%2A>|String|Same as name in database|Specifies the name of the table, column, and so on.|  
|<xref:System.Data.Linq.Mapping.DataAttribute.Storage%2A>|String|Public accessors|Specifies the name of the underlying storage field.|  
  
 For more information, see <xref:System.Data.Linq.Mapping.DataAttribute>.  
  
## See Also  
 [Reference](../../../../../../docs/framework/data/adonet/sql/linq/reference.md)
