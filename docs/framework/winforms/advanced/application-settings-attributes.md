---
title: "Application Settings Attributes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "application settings [Windows Forms], attributes"
  - "attributes [Windows Forms], application settings"
  - "wrapper classes [Windows Forms], application settings"
ms.assetid: 53caa66c-a9fb-43a5-953c-ad092590098d
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Application Settings Attributes
The Application Settings architecture provides many attributes that can be applied either to the applications settings wrapper class or its individual properties. These attributes are examined at run time by the application settings infrastructure, often specifically the settings provider, in order to tailor its functioning to the stated needs of the custom wrapper.  
  
 The following table lists the attributes that can be applied to the application settings wrapper class, this class's individual properties, or both. By definition, only a single scope attribute—**UserScopedSettingAttribute** or **ApplicationScopedSettingAttribute**—must be applied to each and every settings property.  
  
> [!NOTE]
>  A custom settings provider, derived from the <xref:System.Configuration.SettingsProvider> class, is only required to recognize the following three attributes: **ApplicationScopedSettingAttribute**, **UserScopedSettingAttribute**, and **DefaultSettingValueAttribute**.  
  
|Attribute|Target|Description|  
|---------------|------------|-----------------|  
|<xref:System.Configuration.SettingsProviderAttribute>|Both|Specifies the short name of the settings provider to use for persistence.<br /><br /> If this attribute is not supplied, the default provider, <xref:System.Configuration.LocalFileSettingsProvider>, is assumed.|  
|<xref:System.Configuration.UserScopedSettingAttribute>|Both|Defines a property as a user-scoped application setting.|  
|<xref:System.Configuration.ApplicationScopedSettingAttribute>|Both|Defines a property as an application-scoped application setting.|  
|<xref:System.Configuration.DefaultSettingValueAttribute>|Property|Specifies a string that can be deserialized by the provider into the hard-coded default value for this property.<br /><br /> The <xref:System.Configuration.LocalFileSettingsProvider> does not require this attribute, and will override any value provided by this attribute if there is a value already persisted.|  
|<xref:System.Configuration.SettingsDescriptionAttribute>|Property|Provides the descriptive test for an individual setting, used primarily by run-time and design-time tools.|  
|<xref:System.Configuration.SettingsGroupNameAttribute>|Class|Provides an explicit name for a settings group. If this attribute is missing, <xref:System.Configuration.ApplicationSettingsBase> uses the wrapper class name.|  
|<xref:System.Configuration.SettingsGroupDescriptionAttribute>|Class|Provides the descriptive test for a settings group, used primarily by run-time and design-time tools.|  
|<xref:System.Configuration.SettingsManageabilityAttribute>|Both|Specifies zero or more manageability services that should be provided to the settings group or property. The available services are described by the <xref:System.Configuration.SettingsManageability> enumeration.|  
|<xref:System.Configuration.SpecialSettingAttribute>|Property|Indicates that a setting belongs to a special, predefined category, such as a connection string, that suggests special processing by the settings provider. The predefined categories for this attribute are defined by the <xref:System.Configuration.SpecialSetting> enumeration.|  
|<xref:System.Configuration.SettingsSerializeAsAttribute>|Both|Specifies a preferred serialization mechanism for a settings group or property. The available serialization mechanisms are defined by the <xref:System.Configuration.SettingsSerializeAs> enumeration.|  
|<xref:System.Configuration.NoSettingsVersionUpgradeAttribute>|Property|Specifies that a settings provider should disable all application upgrade functionality for the marked property.|  
  
 *Class* indicates that the attribute can be applied only to an application settings wrapper class. *Property* indicates that the attribute can be applied only settings properties. *Both* indicates that the attribute can be applied at either level.  
  
## See Also  
 <xref:System.Configuration.ApplicationSettingsBase>  
 <xref:System.Configuration.SettingsProvider>  
 [Application Settings Architecture](../../../../docs/framework/winforms/advanced/application-settings-architecture.md)  
 [How to: Create Application Settings](http://msdn.microsoft.com/library/53b3af80-1c02-4e35-99c6-787663148945)
