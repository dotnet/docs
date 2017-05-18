---
title: "Obsolete Types in the .NET Framework | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - ".NET Framework 4.5, obsolete types"
  - "types, obsolete in .NET Framework 4.5"
  - "obsolete types [.NET Framework]"
ms.assetid: e636d024-0fac-45eb-b721-25a8c0ceca8f
caps.latest.revision: 41
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Obsolete Types in the .NET Framework
<a name="introduction"></a> The tables in this article list the types that are obsolete in the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] and the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)], organized by assembly. Use the following links to see a list of the obsolete types and the recommended alternatives in each assembly. Because these types are obsolete, all their members are also obsolete. For a list of additional obsolete members in the .NET Framework class library, see [Obsolete Members](../../../docs/framework/whats-new/obsolete-members.md).  
  
-   [Obsolete types in system assemblies](#obsolete_types_in_system_assemblies)  
  
    -   [mscorlib.dll](#mscorlib)  
  
    -   [System.Core.dll](#Core)  
  
    -   [System.Data.dll](#data)  
  
    -   [System.Data.OracleClient.dll](#oracleclient)  
  
    -   [System.Design.dll](#design)  
  
    -   [System.dll](#system)  
  
    -   [System.EnterpriseServices.dll](#enterpriseservices)  
  
    -   [System.Net.dll](#net)  
  
    -   [System.ServiceModel.dll](#servicemodel)  
  
    -   [System.Web.dll](#web)  
  
    -   [System.Web.Mobile.dll](#mobile)  
  
    -   [System.Workflow.Activities.dll](#workflow_activities)  
  
    -   [System.Workflow.ComponentModel.dll](#workflow_componentmodel)  
  
    -   [System.Workflow.Runtime.dll](#workflow_runtime)  
  
    -   [System.WorkflowServices.dll](#workflowservices)  
  
    -   [System.Xaml.dll](#xaml)  
  
    -   [System.Xml.dll](#xml)  
  
    -   [WindowsBase.dll](#WindowsBase)  
  
-   [Obsolete types in Microsoft assemblies](#obsolete_types_in_microsoft_assemblies)  
  
    -   [IEHost.dll and IEExec.exe](#IEHost)  
  
    -   [Microsoft.Build.Engine.dll](#Engine)  
  
    -   [Microsoft.JScript.dll](#jscript)  
  
    -   [Microsoft.VisualBasic.Compatibility.dll](#VBCompat)  
  
    -   [Microsoft.VisualBasic.Compatibility.Data.dll](#VBCompatData)  
  
    -   [Microsoft.VisualC.dll](#visualc)  
  
<a name="obsolete_types_in_system_assemblies"></a>   
## Obsolete Types in System Assemblies  
 The following tables list the types that have been declared obsolete in system assemblies. These assemblies are used for general\-purpose application development that targets the .NET Framework.  
  
<a name="mscorlib"></a>   
### Assembly: mscorlib.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.ExecutionEngineException?displayProperty=fullName>|This type previously indicated an unspecified fatal error in the runtime. The runtime no longer raises this exception so this type is obsolete.|  
|<xref:System.Collections.CaseInsensitiveHashCodeProvider?displayProperty=fullName>|Please use <xref:System.StringComparer?displayProperty=fullName> instead.|  
|<xref:System.Collections.IHashCodeProvider?displayProperty=fullName>|Please use <xref:System.Collections.IEqualityComparer?displayProperty=fullName> instead.|  
|<xref:System.Configuration.Assemblies.AssemblyHash?displayProperty=fullName>|The <xref:System.Configuration.Assemblies.AssemblyHash> class has been deprecated.|  
|<xref:System.Diagnostics.Contracts.Internal.ContractHelper?displayProperty=fullName>|First deprecated in the .NET Framework 4.5. Use the <xref:System.Runtime.CompilerServices.ContractHelper?displayProperty=fullName> class in the System.Runtime.CompilerServices namespace instead.|  
|<xref:System.Reflection.Emit.UnmanagedMarshal?displayProperty=fullName>|An alternate API is available: Emit the <xref:System.Runtime.InteropServices.MarshalAsAttribute?displayProperty=fullName> custom attribute instead.|  
|<xref:System.Runtime.InteropServices.BIND_OPTS?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.BIND_OPTS?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.BINDPTR?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.BINDPTR?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.CALLCONV?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.CALLCONV?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.CONNECTDATA?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.CONNECTDATA?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.DESCKIND?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.DESCKIND?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.DISPPARAMS?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.DISPPARAMS?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.ELEMDESC?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.ELEMDESC?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.EXCEPINFO?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.EXCEPINFO?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.FILETIME?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.FILETIME?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.FUNCDESC?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.FUNCDESC?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.FUNCFLAGS?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.FUNCFLAGS?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.FUNCKIND?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.FUNCKIND?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.IDispatchImplAttribute?displayProperty=fullName>|This attribute is deprecated and will be removed in a future version.|  
|<xref:System.Runtime.InteropServices.IDispatchImplType?displayProperty=fullName>|The <xref:System.Runtime.InteropServices.IDispatchImplAttribute?displayProperty=fullName> is deprecated.|  
|<xref:System.Runtime.InteropServices.IDLDESC?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IDLDESC?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.IDLFLAG?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IDLFLAG?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.IMPLTYPEFLAGS?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.INVOKEKIND?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.INVOKEKIND?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.LIBFLAGS?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.LIBFLAGS?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.PARAMDESC?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.PARAMDESC?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.PARAMFLAG?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.PARAMFLAG?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.SetWin32ContextInIDispatchAttribute?displayProperty=fullName>|This attribute has been deprecated. Application Domains no longer respect Activation Context boundaries in IDispatch calls.|  
|<xref:System.Runtime.InteropServices.STATSTG?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.STATSTG?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.SYSKIND?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.SYSKIND?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.TYPEATTR?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.TYPEATTR?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.TYPEDESC?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.TYPEDESC?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.TYPEFLAGS?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.TYPEFLAGS?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.TYPEKIND?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.TYPEKIND?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.TYPELIBATTR?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.TYPELIBATTR?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIBindCtx?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IBindCtx?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIConnectionPoint?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IConnectionPoint?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIConnectionPointContainer?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IConnectionPointContainer?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIEnumConnectionPoints?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IEnumConnectionPoints?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIEnumConnections?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IEnumConnections?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIEnumMoniker?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IEnumMoniker?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIEnumString?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IEnumString?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIEnumVARIANT?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IEnumVARIANT?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIMoniker?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IMoniker?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIPersistFile?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IPersistFile?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIRunningObjectTable?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IRunningObjectTable?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIStream?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.IStream?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMITypeComp?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.ITypeComp?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMITypeInfo?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.ITypeInfo?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.UCOMITypeLib?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.ITypeLib?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.VARDESC?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.VARDESC?displayProperty=fullName> instead.|  
|<xref:System.Runtime.InteropServices.VARFLAGS?displayProperty=fullName>|Use <xref:System.Runtime.InteropServices.ComTypes.VARFLAGS?displayProperty=fullName> instead.|  
|<xref:System.Security.SecurityCriticalScope?displayProperty=fullName>|<xref:System.Security.SecurityCriticalScope> is only used for .NET 2.0 transparency compatibility.|  
|<xref:System.Security.SecurityTreatAsSafeAttribute?displayProperty=fullName>|<xref:System.Security.SecurityTreatAsSafeAttribute> is only used for .NET 2.0 transparency compatibility. Please use the <xref:System.Security.SecuritySafeCriticalAttribute?displayProperty=fullName> instead.|  
|<xref:System.Security.Policy.FirstMatchCodeGroup?displayProperty=fullName>|This type is obsolete and will be removed in a future release of the .NET Framework.|  
|<xref:System.Security.Policy.PermissionRequestEvidence?displayProperty=fullName>|Assembly level declarative security is obsolete and is no longer enforced by the CLR by default.|  
|<xref:System.Security.Policy.UnionCodeGroup?displayProperty=fullName>|This type is obsolete and will be removed in a future release of the .NET Framework.|  
  
 [Back to top](#introduction)  
  
<a name="Core"></a>   
### Assembly: System.Core.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Runtime.CompilerServices.ExecutionScope?displayProperty=fullName>|Use of this type generates a compiler error.<br /><br /> Do not use this type.|  
  
 [Back to top](#introduction)  
  
<a name="data"></a>   
### Assembly: System.Data.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Data.DataSysDescriptionAttribute?displayProperty=fullName>|<xref:System.Data.DataSysDescriptionAttribute> has been deprecated.|  
|<xref:System.Data.PropertyAttributes?displayProperty=fullName>|<xref:System.Data.PropertyAttributes> has been deprecated.|  
|<xref:System.Data.TypedDataSetGenerator?displayProperty=fullName>|The <xref:System.Data.TypedDataSetGenerator> class will be removed in a future release. Please use <xref:System.Data.Design.TypedDataSetGenerator?displayProperty=fullName> in System.Design.dll.|  
|<xref:System.Xml.XmlDataDocument?displayProperty=fullName>|The <xref:System.Xml.XmlDataDocument> class will be removed in a future release.|  
  
 [Back to top](#introduction)  
  
<a name="oracleclient"></a>   
### Assembly: System.Data.OracleClient.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Data.OracleClient.OracleClientFactory?displayProperty=fullName>|<xref:System.Data.OracleClient.OracleClientFactory> has been deprecated.|  
|<xref:System.Data.OracleClient.OracleCommand?displayProperty=fullName>|<xref:System.Data.OracleClient.OracleCommand> has been deprecated.|  
|<xref:System.Data.OracleClient.OracleCommandBuilder?displayProperty=fullName>|<xref:System.Data.OracleClient.OracleCommandBuilder> has been deprecated.|  
|<xref:System.Data.OracleClient.OracleConnection?displayProperty=fullName>|<xref:System.Data.OracleClient.OracleConnection> has been deprecated.|  
|<xref:System.Data.OracleClient.OracleConnectionStringBuilder?displayProperty=fullName>|<xref:System.Data.OracleClient.OracleConnectionStringBuilder> has been deprecated.|  
|<xref:System.Data.OracleClient.OracleDataAdapter?displayProperty=fullName>|<xref:System.Data.OracleClient.OracleDataAdapter> has been deprecated.|  
|<xref:System.Data.OracleClient.OraclePermission?displayProperty=fullName>|<xref:System.Data.OracleClient.OraclePermission> has been deprecated.|  
|<xref:System.Data.OracleClient.OraclePermissionAttribute?displayProperty=fullName>|<xref:System.Data.OracleClient.OraclePermissionAttribute?displayProperty=fullName> has been deprecated.|  
  
 [Back to top](#introduction)  
  
<a name="design"></a>   
### Assembly: System.Design.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.ComponentModel.Design.LocalizationExtenderProvider?displayProperty=fullName>|This class has been deprecated. Use <xref:System.ComponentModel.Design.Serialization.CodeDomLocalizationProvider?displayProperty=fullName> instead.|  
|<xref:System.Web.UI.Design.DataBindingCollectionConverter?displayProperty=fullName>|Use of this type is not recommended because DataBindings editing is launched via a <xref:System.ComponentModel.Design.DesignerActionList?displayProperty=fullName> instead of the property grid.|  
|<xref:System.Web.UI.Design.DataBindingCollectionEditor?displayProperty=fullName>|Use of this type is not recommended because DataBindings editing is launched via a <xref:System.ComponentModel.Design.DesignerActionList?displayProperty=fullName> instead of the property grid.|  
|<xref:System.Web.UI.Design.IControlDesignerBehavior?displayProperty=fullName>|The recommended alternative is <xref:System.Web.UI.Design.IControlDesignerTag?displayProperty=fullName> and <xref:System.Web.UI.Design.IControlDesignerView?displayProperty=fullName>.|  
|<xref:System.Web.UI.Design.IHtmlControlDesignerBehavior?displayProperty=fullName>|The recommended alternative is <xref:System.Web.UI.Design.IControlDesignerTag?displayProperty=fullName> and <xref:System.Web.UI.Design.IControlDesignerView?displayProperty=fullName>.|  
|<xref:System.Web.UI.Design.ITemplateEditingFrame?displayProperty=fullName>|Use of this type is not recommended because template editing is handled in <xref:System.Web.UI.Design.ControlDesigner?displayProperty=fullName>. To support template editing, expose template data in the <xref:System.Web.UI.Design.ControlDesigner.TemplateGroups%2A?displayProperty=fullName> property and call <xref:System.Web.UI.Design.ControlDesigner.SetViewFlags%2A?displayProperty=fullName>.|  
|<xref:System.Web.UI.Design.IWebFormReferenceManager?displayProperty=fullName>|The recommended alternative is <xref:System.Web.UI.Design.WebFormsReferenceManager?displayProperty=fullName>. The <xref:System.Web.UI.Design.WebFormsReferenceManager> contains additional functionality and allows for more extensibility. To get the <xref:System.Web.UI.Design.WebFormsReferenceManager>, use the `RootDesigner.ReferenceManager` property from your <xref:System.Web.UI.Design.ControlDesigner?displayProperty=fullName>.|  
|<xref:System.Web.UI.Design.IWebFormsDocumentService?displayProperty=fullName>|The recommended alternative is <xref:System.Web.UI.Design.WebFormsRootDesigner?displayProperty=fullName>. The <xref:System.Web.UI.Design.WebFormsRootDesigner> contains additional functionality and allows for more extensibility. To get the <xref:System.Web.UI.Design.WebFormsRootDesigner>, use the <xref:System.Web.UI.Design.ControlDesigner.RootDesigner%2A> property from your <xref:System.Web.UI.Design.ControlDesigner?displayProperty=fullName>.|  
|<xref:System.Web.UI.Design.ITemplateEditingService?displayProperty=fullName>|Use of this type is not recommended because template editing is handled in <xref:System.Web.UI.Design.ControlDesigner?displayProperty=fullName>. To support template editing, expose template data in the <xref:System.Web.UI.Design.ControlDesigner.TemplateGroups%2A?displayProperty=fullName> property and call <xref:System.Web.UI.Design.ControlDesigner.SetViewFlags%2A?displayProperty=fullName>.|  
|<xref:System.Web.UI.Design.ReadWriteControlDesigner?displayProperty=fullName>|The recommended alternative is <xref:System.Web.UI.Design.ContainerControlDesigner?displayProperty=fullName> because it uses an <xref:System.Web.UI.Design.EditableDesignerRegion?displayProperty=fullName> for editing the content. Designer regions allow for better control of the content being edited.|  
|<xref:System.Web.UI.Design.TemplateEditingService?displayProperty=fullName>|Use of this type is not recommended because template editing is handled in <xref:System.Web.UI.Design.ControlDesigner?displayProperty=fullName>. To support template editing, expose template data in the <xref:System.Web.UI.Design.ControlDesigner.TemplateGroups%2A?displayProperty=fullName> property and call <xref:System.Web.UI.Design.ControlDesigner.SetViewFlags%2A?displayProperty=fullName>.|  
|<xref:System.Web.UI.Design.TemplateEditingVerb?displayProperty=fullName>|Use of this type is not recommended because template editing is handled in <xref:System.Web.UI.Design.ControlDesigner?displayProperty=fullName>. To support template editing, expose template data in the <xref:System.Web.UI.Design.ControlDesigner.TemplateGroups%2A?displayProperty=fullName> property and call <xref:System.Web.UI.Design.ControlDesigner.SetViewFlags%2A?displayProperty=fullName>.|  
|<xref:System.Web.UI.Design.WebControls.CalendarAutoFormatDialog?displayProperty=fullName>|Use of this type is not recommended because the AutoFormat dialog is launched by the designer host. The list of available AutoFormats is exposed on the <xref:System.Web.UI.Design.ControlDesigner?displayProperty=fullName> in the <xref:System.Web.UI.Design.ControlDesigner.AutoFormats%2A?displayProperty=fullName> property.|  
|<xref:System.Web.UI.Design.WebControls.PanelDesigner?displayProperty=fullName>|The recommended alternative is <xref:System.Web.UI.Design.WebControls.PanelContainerDesigner?displayProperty=fullName> because it uses an <xref:System.Web.UI.Design.EditableDesignerRegion?displayProperty=fullName> for editing the content. Designer regions allow for better control of the content being edited.|  
  
 [Back to top](#introduction)  
  
<a name="system"></a>   
### Assembly: System.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.ComponentModel.IComNativeDescriptorHandler?displayProperty=fullName>|This interface has been deprecated. Add a <xref:System.ComponentModel.TypeDescriptionProvider?displayProperty=fullName> to handle type <xref:System.ComponentModel.TypeDescriptor.ComObjectType%2A?displayProperty=fullName> instead.|  
|<xref:System.ComponentModel.RecommendedAsConfigurableAttribute?displayProperty=fullName>|Use <xref:System.ComponentModel.SettingsBindableAttribute?displayProperty=fullName> instead to work with the new settings model.|  
|<xref:System.ComponentModel.Design.Serialization.RootDesignerSerializerAttribute?displayProperty=fullName>|This attribute has been deprecated. Use <xref:System.ComponentModel.Design.Serialization.DesignerSerializerAttribute?displayProperty=fullName> instead. For example, to specify a root designer for CodeDom, use `DesignerSerializerAttribute\(...,typeof\(TypeCodeDomSerializer\)\)`.|  
|<xref:System.Diagnostics.DiagnosticsConfigurationHandler?displayProperty=fullName>|This class has been deprecated.|  
|<xref:System.Diagnostics.PerformanceCounterManager?displayProperty=fullName>|This class has been deprecated. Use the performance counters through the <xref:System.Diagnostics.PerformanceCounter?displayProperty=fullName> class instead.|  
|<xref:System.Net.GlobalProxySelection?displayProperty=fullName>|This class has been deprecated. Please use <xref:System.Net.WebRequest.DefaultWebProxy%2A?displayProperty=fullName> instead to access and set the global default proxy. Use 'null' instead of <xref:System.Net.GlobalProxySelection.GetEmptyWebProxy%2A?displayProperty=fullName>.|  
|<xref:System.Net.Sockets.SocketClientAccessPolicyProtocol?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
  
 [Back to top](#introduction)  
  
<a name="enterpriseservices"></a>   
### Assembly: System.EnterpriseServices.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.EnterpriseServices.RegistrationHelperTx?displayProperty=fullName>|The <xref:System.EnterpriseServices.RegistrationHelperTx> class has been deprecated.|  
  
 [Back to top](#introduction)  
  
<a name="net"></a>   
### Assembly: System.Net.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Net.INetworkProgress?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.IUnsafeWebRequestCreate?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.NetworkProgressChangedEventArgs?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.UiSynchronizationContext?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.Sockets.HttpPolicyDownloaderProtocol?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.Sockets.SecurityCriticalAction?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.Sockets.SocketPolicy?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.Sockets.UdpAnySourceMulticastClient?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.Sockets.UdpSingleSourceMulticastClient?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
  
 [Back to top](#introduction)  
  
<a name="servicemodel"></a>   
### Assembly: System.ServiceModel.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.ServiceModel.NetPeerTcpBinding?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.Channels.HttpCookieContainerBindingElement?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> This type is obsolete. To enable Http <xref:System.Net.CookieContainer>, use the `AllowCookies` property on the Http binding or on the <xref:System.ServiceModel.Channels.HttpTransportBindingElement>.|  
|<xref:System.ServiceModel.Channels.PeerCustomResolverBindingElement?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.Channels.PeerTransportBindingElement?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.Configuration.NetPeerTcpBindingCollectionElement?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.Configuration.NetPeerTcpBindingElement?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.Configuration.PeerTransportElement?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.PeerResolvers.CustomPeerResolverService?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
  
 [Back to top](#introduction)  
  
<a name="web"></a>   
### Assembly: System.Web.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Web.Configuration.PassportAuthentication?displayProperty=fullName>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.Mail.MailAttachment?displayProperty=fullName>|The recommended alternative is <xref:System.Net.Mail.Attachment?displayProperty=fullName>.|  
|<xref:System.Web.Mail.MailEncoding?displayProperty=fullName>|The recommended alternative is <xref:System.Net.Mime.TransferEncoding?displayProperty=fullName>.|  
|<xref:System.Web.Mail.MailFormat?displayProperty=fullName>|The recommended alternative is <xref:System.Net.Mail.MailMessage.IsBodyHtml%2A?displayProperty=fullName>.|  
|<xref:System.Web.Mail.MailMessage?displayProperty=fullName>|The recommended alternative is <xref:System.Net.Mail.MailMessage?displayProperty=fullName>.|  
|<xref:System.Web.Mail.MailPriority?displayProperty=fullName>|The recommended alternative is <xref:System.Net.Mail.MailPriority?displayProperty=fullName>.|  
|<xref:System.Web.Mail.SmtpMail?displayProperty=fullName>|The recommended alternative is <xref:System.Net.Mail.SmtpClient?displayProperty=fullName>.|  
|<xref:System.Web.Security.PassportAuthenticationEventArgs?displayProperty=fullName>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.Security.PassportAuthenticationEventHandler?displayProperty=fullName>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.Security.PassportAuthenticationModule?displayProperty=fullName>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.Security.PassportIdentity?displayProperty=fullName>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.Security.PassportPrincipal?displayProperty=fullName>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.UI.ObjectConverter?displayProperty=fullName>|The recommended alternative is <xref:System.Convert?displayProperty=fullName> and <xref:System.String.Format%2A?displayProperty=fullName>.|  
  
 [Back to top](#introduction)  
  
<a name="mobile"></a>   
### Assembly: System.Web.Mobile.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Web.Mobile.CookielessData?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.DeviceFilterElement?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.DeviceFilterElementCollection?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.DeviceFiltersSection?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.ErrorHandlerModule?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.MobileCapabilities?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.MobileDeviceCapabilitiesSectionHandler?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.MobileErrorInfo?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.MobileFormsAuthentication?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.Design.MobileControls.IMobileDesigner?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.Design.MobileControls.IMobileWebFormServices?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.Design.MobileControls.MobileResource?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.Design.MobileControls.Converters.DataFieldConverter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.Design.MobileControls.Converters.DataMemberConverter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.AdRotator?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Alignment?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ArrayListCollectionBase?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.BaseValidator?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.BooleanOption?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Calendar?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Command?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.CommandFormat?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.CompareValidator?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Constants?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ControlElement?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ControlElementCollection?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ControlPager?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.CustomValidator?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DesignerAdapterAttribute?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceElement?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceElementCollection?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceOverridableAttribute?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecific?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificChoice?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificChoiceCollection?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificChoiceControlBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificChoiceTemplateBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificChoiceTemplateContainer?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificControlBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ErrorFormatterPage?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.FontInfo?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.FontSize?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Form?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.FormControlBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.FormMethod?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.IControlAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Image?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.IObjectListFieldCollection?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.IPageAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ItemPager?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ITemplateable?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Label?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Link?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.List?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListCommandEventArgs?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListCommandEventHandler?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListControlBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListDataBindEventArgs?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListDataBindEventHandler?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListDecoration?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListSelectType?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LiteralLink?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LiteralText?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LiteralTextContainerControlBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LiteralTextControlBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LoadItemsEventArgs?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LoadItemsEventHandler?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileControl?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileControlBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileControlsSection?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileControlsSectionHandler?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileListItem?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileListItemCollection?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileListItemType?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobilePage?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileTypeNameConverter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileUserControl?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectList?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListCommand?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListCommandCollection?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListCommandEventArgs?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListCommandEventHandler?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListControlBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListDataBindEventArgs?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListDataBindEventHandler?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListField?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListFieldCollection?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListItem?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListItemCollection?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListSelectEventArgs?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListSelectEventHandler?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListShowCommandsEventArgs?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListShowCommandsEventHandler?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListTitleAttribute?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListViewMode?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.PagedControl?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.PagerStyle?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Panel?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.PanelControlBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.PersistNameAttribute?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.PhoneCall?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.RangeValidator?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.RegularExpressionValidator?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.RequiredFieldValidator?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.SelectionList?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Style?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.StyleSheet?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.StyleSheetControlBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TemplateContainer?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TextBox?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TextBoxControlBuilder?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TextControl?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TextView?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TextViewElement?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ValidationSummary?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Wrapping?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlCalendarAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlCommandAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlFormAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlImageAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlLinkAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlMobileTextWriter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlPageAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlPhoneCallAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlSelectionListAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlTextBoxAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ControlAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlCalendarAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlCommandAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlControlAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlFormAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlImageAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlLabelAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlLinkAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlListAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlLiteralTextAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlMobileTextWriter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlObjectListAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlPageAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlPanelAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlPhoneCallAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlSelectionListAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlTextBoxAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlTextViewAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlValidationSummaryAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlValidatorAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.MobileTextWriter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.MultiPartWriter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.UpWmlMobileTextWriter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.UpWmlPageAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlCalendarAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlCommandAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlControlAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlFormAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlImageAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlLabelAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlLinkAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlListAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlLiteralTextAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlMobileTextWriter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlObjectListAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlPageAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlPanelAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlPhoneCallAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlPostFieldType?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlSelectionListAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlTextBoxAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlTextViewAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlValidationSummaryAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlValidatorAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.Doctype?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.StyleSheetLocation?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlCalendarAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlCommandAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlControlAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlCssHandler?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlFormAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlImageAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlLabelAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlLinkAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlListAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlLiteralTextAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlMobileTextWriter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlObjectListAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlPageAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlPanelAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlPhoneCallAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlSelectionListAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlTextBoxAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlTextViewAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlValidationSummaryAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlValidatorAdapter?displayProperty=fullName>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
  
 [Back to top](#introduction)  
  
<a name="workflow_activities"></a>   
### Assembly: System.Workflow.Activities.dll  
  
|Type|Message|  
|----------|-------------|  
|All types in the <xref:System.Workflow.Activities?displayProperty=fullName> namespace|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.Activities.Configuration.ActiveDirectoryRoleFactoryConfiguration?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.Activities.Rules.RuleActionTrackingEvent?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.Activities.Rules.RuleConditionReference?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.Activities.Rules.RuleSetReference?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
  
 [Back to top](#introduction)  
  
<a name="workflow_componentmodel"></a>   
### Assembly: System.Workflow.ComponentModel.dll  
  
|Type|Message|  
|----------|-------------|  
|All types in the <xref:System.Workflow.ComponentModel> namespace except <xref:System.Workflow.ComponentModel.GetValueOverride?displayProperty=fullName> and <xref:System.Workflow.ComponentModel.SetValueOverride?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|All types in the <xref:System.Workflow.ComponentModel.Compiler> namespace except <xref:System.Workflow.ComponentModel.Compiler.ValidationError?displayProperty=fullName> and <xref:System.Workflow.ComponentModel.Compiler.ValidationErrorCollection?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|All types in the <xref:System.Workflow.ComponentModel.Design> namespace except <xref:System.Workflow.ComponentModel.Design.ConnectorEventHandler>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.ActivityCodeDomSerializationManager?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.ActivityCodeDomSerializer?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.ActivityMarkupSerializer?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.ActivitySurrogateSelector?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.ActivityTypeCodeDomSerializer?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.CompositeActivityMarkupSerializer?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.DependencyObjectCodeDomSerializer?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
  
 [Back to top](#introduction)  
  
<a name="workflow_runtime"></a>   
### Assembly: System.Workflow.Runtime.dll  
  
|Type|Message|  
|----------|-------------| 
|<xref:System.Activities.Statements.Interop>|First deprecated in the .NET Framework 4.5.<br /><br />The Workflow Foundation 3.0 types are deprecated. Instead, use the Workflow 4.0 types from <xref:System.Activities>.\*.|  
|<xref:System.Activities.Tracking.InteropTrackingRecord>|First deprecated in the .NET Framework 4.5.<br /><br />The Workflow Foundation 3.0 types are deprecated. Instead, use the Workflow 4.0 types from <xref:System.Activities>.\*.|   
|All types in the <xref:System.Workflow.Runtime> namespace|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|All types in the <xref:System.Workflow.Runtime.Configuration> namespace|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|All types in the <xref:System.Workflow.Runtime.DebugEngine> namespace except <xref:System.Workflow.Runtime.DebugEngine.DebugEngineCallback>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|All types in the <xref:System.Workflow.Runtime.Hosting> namespace except <xref:System.Workflow.Runtime.Hosting.WorkflowCommitWorkBatchService.CommitWorkBatchCallback>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|All types in the <xref:System.Workflow.Runtime.Tracking> namespace|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
  
 [Back to top](#introduction)  
  
<a name="workflowservices"></a>   
### Assembly: System.WorkflowServices.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.ServiceModel.WorkflowServiceHost?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Activation.WorkflowServiceHostFactory?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Activities.Description.WorkflowRuntimeEndpoint?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Configuration.ExtendedWorkflowRuntimeServiceElementCollection?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Configuration.PersistenceProviderElement?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Configuration.WorkflowRuntimeElement?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Description.DurableOperationAttribute?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Description.DurableServiceAttribute?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Description.PersistenceProviderBehavior?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Description.UnknownExceptionAction?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Description.WorkflowRuntimeBehavior?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Dispatcher.DurableOperationContext?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.InstanceLockException?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.InstanceNotFoundException?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.LockingPersistenceProvider?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.PersistenceException?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.PersistenceProvider?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.PersistenceProviderFactory?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.SqlPersistenceProviderFactory?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|All types in the <xref:System.Workflow.Activities?displayProperty=fullName> namespace|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.Runtime.Hosting.ChannelManagerService?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
  
 [Back to top](#introduction)  
  
<a name="xaml"></a>   
### Assembly: System.Xaml.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Windows.Markup.AcceptedMarkupExtensionExpressionTypeAttribute?displayProperty=fullName>|This is not used by the XAML parser. Please look at <xref:System.Windows.Markup.XamlSetMarkupExtensionAttribute?displayProperty=fullName>.|  
  
 [Back to top](#introduction)  
  
<a name="xml"></a>   
### Assembly: System.Xml.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Xml.IApplicationResourceStreamResolver?displayProperty=fullName>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Xml.Schema.XmlSchemaCollection?displayProperty=fullName>|Use <xref:System.Xml.Schema.XmlSchemaSet?displayProperty=fullName> for schema compilation and validation.|  
|<xref:System.Xml.XmlValidatingReader?displayProperty=fullName>|Use an <xref:System.Xml.XmlReader?displayProperty=fullName> created by the <xref:System.Xml.XmlReader.Create%2A?displayProperty=fullName> method using the appropriate <xref:System.Xml.XmlReaderSettings?displayProperty=fullName> instead.|  
|<xref:System.Xml.XmlXapResolver?displayProperty=fullName>|Use of this type generates a compiler error. This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Xml.Xsl.XslTransform?displayProperty=fullName>|This class has been deprecated. Please use <xref:System.Xml.Xsl.XslCompiledTransform?displayProperty=fullName> instead.|  
  
 [Back to top](#introduction)  
  
<a name="WindowsBase"></a>   
### Assembly: WindowsBase.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Windows.Markup.IReceiveMarkupExtension?displayProperty=fullName>|<xref:System.Windows.Markup.IReceiveMarkupExtension?displayProperty=fullName> has been deprecated. This interface is no longer in use.|  
  
 [Back to top](#introduction)  
  
<a name="obsolete_types_in_microsoft_assemblies"></a>   
## Obsolete Types in Microsoft Assemblies  
 The following sections list the obsolete types in Microsoft assemblies. These assemblies are special-purpose assemblies such as assemblies that target an individual language (for example, Microsoft.JScript.dll or Microsoft.VisualC.dll).  
  
<a name="IEHost"></a>   
### Assembly: IEHost.dll and IEExec.exe  
 The IEHost.dll and IEExec.exe assemblies have been removed from the .NET Framework. All of their types and their members are obsolete and are not supported as of the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)]. These assemblies were used to host Windows Forms controls and to run executables in Internet Explorer. Recommended alternatives include ClickOnce, XAML browser applications (XBAP), and Microsoft Silverlight.  
  
 [Back to top](#introduction)  
  
<a name="Engine"></a>   
### Assembly: Microsoft.Build.Engine.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:Microsoft.Build.BuildEngine.Engine?displayProperty=fullName>|This class has been deprecated. Please use <xref:Microsoft.Build.Evaluation.ProjectCollection?displayProperty=fullName> from the *Microsoft.Build* assembly instead.|  
|<xref:Microsoft.Build.BuildEngine.Project?displayProperty=fullName>|This class has been deprecated. Please use <xref:Microsoft.Build.Evaluation.ProjectCollection?displayProperty=fullName> from the *Microsoft.Build* assembly instead.|  
  
 [Back to top](#introduction)  
  
<a name="jscript"></a>   
### Assembly: Microsoft.JScript.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:Microsoft.JScript.Vsa.BaseVsaEngine?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.BaseVsaSite?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.BaseVsaStartup?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaCodeItem?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaEngine?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaError?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaGlobalItem?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaItem?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaItems?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaPersistSite?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaReferenceItem?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaSite?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.JSVsaError?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.JSVsaException?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.JSVsaItemFlag?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.JSVsaItemType?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.ResInfo?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.VsaEngine?displayProperty=fullName>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=fullName> documentation for additional help.|  
  
 [Back to top](#introduction)  
  
<a name="VBCompat"></a>   
### Assembly: Microsoft.VisualBasic.Compatibility.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.BaseControlArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.BaseOcxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ButtonArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.CheckedListBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ColorDialogArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DirListBox?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DirListBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DriveListBox?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DriveListBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.FileListBox?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.FileListBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.FixedLengthString?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.FontDialogArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.FormShowConstants?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.HScrollBarArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ImageListArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.LabelArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ListBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ListViewArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.LoadResConstants?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.MaskedTextBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.MenuItemArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.MouseButtonConstants?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.OpenFileDialogArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.PanelArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.PrintDialogArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ProgressBarArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.RichTextBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.SaveFileDialogArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ScaleMode?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ShiftConstants?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.StatusBarArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.StatusStripArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.Support?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.TabControlArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.TimerArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ToolBarArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ToolStripArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.TreeViewArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.VScrollBarArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebBrowserArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClass?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassContainingClassNotOptional?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassCouldNotFindEvent?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassNextItemCannotBeCurrentWebItem?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassNextItemRespondNotFound?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassUserWebClassNameNotOptional?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassWebClassFileNameNotOptional?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassWebItemNotValid?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItem?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemAssociatedWebClassNotOptional?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemClosingTagNotFound?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemCouldNotLoadEmbeddedResource?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemCouldNotLoadTemplateFile?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemNameNotOptional?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemNoTemplateSpecified?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemTooManyNestedTags?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemUnexpectedErrorReadingTemplateFile?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ZOrderConstants?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
  
 [Back to top](#introduction)  
  
<a name="VBCompatData"></a>   
### Assembly: Microsoft.VisualBasic.Compatibility.Data.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.EndOfRecordsetDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.ErrorDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.FetchCompleteDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.FetchProgressDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.FieldChangeCompleteDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.MoveCompleteDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.RecordChangeCompleteDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.RecordsetChangeCompleteDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.WillChangeFieldDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.WillChangeRecordDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.WillChangeRecordsetDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.WillMoveDelegate?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODCArray?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.BaseDataEnvironment?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.BindingCollectionEnumerator?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.CONNECTDATA?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBBINDING?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBCOLUMNINFO?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBID?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBinding?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBindingCollection?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBKINDENUM?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBPROPIDSET?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IAccessor?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IChapteredRowset?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IColumnsInfo?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IConnectionPoint?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IConnectionPointContainer?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IDataFormat?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IDataFormatDisp?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IEnumConnectionPoints?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IEnumConnections?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowPosition?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowPositionChange?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowset?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowsetChange?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowsetIdentity?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowsetInfo?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowsetNotify?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.MBinding?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.MBindingCollection?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.SRDescriptionAttribute?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.UGUID?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.UNAME?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.UpdateMode?displayProperty=fullName>|See [Microsoft.VisualBasic.Compatibility.VB6.\<member> is obsolete and supported within 32-bit processes only](https://msdn.microsoft.com/library/ee839621.aspx).|  
  
 [Back to top](#introduction)  
  
<a name="visualc"></a>   
### Assembly: Microsoft.VisualC.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:Microsoft.VisualC.DebugInfoInPDBAttribute?displayProperty=fullName>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.DecoratedNameAttribute?displayProperty=fullName>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.IsConstModifier?displayProperty=fullName>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.IsCXXReferenceModifier?displayProperty=fullName>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.IsLongModifier?displayProperty=fullName>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.IsSignedModifier?displayProperty=fullName>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.IsVolatileModifier?displayProperty=fullName>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.MiscellaneousBitsAttribute?displayProperty=fullName>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.NeedsCopyConstructorModifier?displayProperty=fullName>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.NoSignSpecifiedModifier?displayProperty=fullName>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
  
## See Also  
 [What's Obsolete in the Class Library](../../../docs/framework/whats-new/whats-obsolete.md)   
 [Obsolete Members](../../../docs/framework/whats-new/obsolete-members.md)
