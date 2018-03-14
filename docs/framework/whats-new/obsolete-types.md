---
title: "Obsolete Types in the .NET Framework"
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
ms.workload: 
  - "dotnet"
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
|<xref:System.ExecutionEngineException?displayProperty=nameWithType>|This type previously indicated an unspecified fatal error in the runtime. The runtime no longer raises this exception so this type is obsolete.|  
|<xref:System.Collections.CaseInsensitiveHashCodeProvider?displayProperty=nameWithType>|Please use <xref:System.StringComparer?displayProperty=nameWithType> instead.|  
|<xref:System.Collections.IHashCodeProvider?displayProperty=nameWithType>|Please use <xref:System.Collections.IEqualityComparer?displayProperty=nameWithType> instead.|  
|<xref:System.Configuration.Assemblies.AssemblyHash?displayProperty=nameWithType>|The <xref:System.Configuration.Assemblies.AssemblyHash> class has been deprecated.|  
|<xref:System.Diagnostics.Contracts.Internal.ContractHelper?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5. Use the <xref:System.Runtime.CompilerServices.ContractHelper?displayProperty=nameWithType> class in the System.Runtime.CompilerServices namespace instead.|  
|<xref:System.Reflection.Emit.UnmanagedMarshal?displayProperty=nameWithType>|An alternate API is available: Emit the <xref:System.Runtime.InteropServices.MarshalAsAttribute?displayProperty=nameWithType> custom attribute instead.|  
|<xref:System.Runtime.InteropServices.BIND_OPTS?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.BIND_OPTS?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.BINDPTR?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.BINDPTR?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.CALLCONV?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.CALLCONV?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.CONNECTDATA?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.CONNECTDATA?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.DESCKIND?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.DESCKIND?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.DISPPARAMS?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.DISPPARAMS?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.ELEMDESC?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.ELEMDESC?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.EXCEPINFO?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.EXCEPINFO?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.FILETIME?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.FILETIME?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.FUNCDESC?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.FUNCDESC?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.FUNCFLAGS?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.FUNCFLAGS?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.FUNCKIND?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.FUNCKIND?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.IDispatchImplAttribute?displayProperty=nameWithType>|This attribute is deprecated and will be removed in a future version.|  
|<xref:System.Runtime.InteropServices.IDispatchImplType?displayProperty=nameWithType>|The <xref:System.Runtime.InteropServices.IDispatchImplAttribute?displayProperty=nameWithType> is deprecated.|  
|<xref:System.Runtime.InteropServices.IDLDESC?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IDLDESC?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.IDLFLAG?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IDLFLAG?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.IMPLTYPEFLAGS?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IMPLTYPEFLAGS?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.INVOKEKIND?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.INVOKEKIND?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.LIBFLAGS?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.LIBFLAGS?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.PARAMDESC?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.PARAMDESC?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.PARAMFLAG?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.PARAMFLAG?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.SetWin32ContextInIDispatchAttribute?displayProperty=nameWithType>|This attribute has been deprecated. Application Domains no longer respect Activation Context boundaries in IDispatch calls.|  
|<xref:System.Runtime.InteropServices.STATSTG?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.STATSTG?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.SYSKIND?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.SYSKIND?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.TYPEATTR?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.TYPEATTR?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.TYPEDESC?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.TYPEDESC?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.TYPEFLAGS?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.TYPEFLAGS?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.TYPEKIND?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.TYPEKIND?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.TYPELIBATTR?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.TYPELIBATTR?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIBindCtx?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IBindCtx?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIConnectionPoint?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IConnectionPoint?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIConnectionPointContainer?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IConnectionPointContainer?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIEnumConnectionPoints?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IEnumConnectionPoints?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIEnumConnections?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IEnumConnections?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIEnumMoniker?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IEnumMoniker?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIEnumString?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IEnumString?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIEnumVARIANT?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IEnumVARIANT?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIMoniker?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IMoniker?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIPersistFile?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IPersistFile?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIRunningObjectTable?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IRunningObjectTable?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMIStream?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.IStream?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMITypeComp?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.ITypeComp?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMITypeInfo?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.ITypeInfo?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.UCOMITypeLib?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.ITypeLib?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.VARDESC?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.VARDESC?displayProperty=nameWithType> instead.|  
|<xref:System.Runtime.InteropServices.VARFLAGS?displayProperty=nameWithType>|Use <xref:System.Runtime.InteropServices.ComTypes.VARFLAGS?displayProperty=nameWithType> instead.|  
|<xref:System.Security.SecurityCriticalScope?displayProperty=nameWithType>|<xref:System.Security.SecurityCriticalScope> is only used for .NET 2.0 transparency compatibility.|  
|<xref:System.Security.SecurityTreatAsSafeAttribute?displayProperty=nameWithType>|<xref:System.Security.SecurityTreatAsSafeAttribute> is only used for .NET 2.0 transparency compatibility. Please use the <xref:System.Security.SecuritySafeCriticalAttribute?displayProperty=nameWithType> instead.|  
|<xref:System.Security.Policy.FirstMatchCodeGroup?displayProperty=nameWithType>|This type is obsolete and will be removed in a future release of the .NET Framework.|  
|<xref:System.Security.Policy.PermissionRequestEvidence?displayProperty=nameWithType>|Assembly level declarative security is obsolete and is no longer enforced by the CLR by default.|  
|<xref:System.Security.Policy.UnionCodeGroup?displayProperty=nameWithType>|This type is obsolete and will be removed in a future release of the .NET Framework.|  
  
 [Back to top](#introduction)  
  
<a name="Core"></a>   
### Assembly: System.Core.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Runtime.CompilerServices.ExecutionScope?displayProperty=nameWithType>|Use of this type generates a compiler error.<br /><br /> Do not use this type.|  
  
 [Back to top](#introduction)  
  
<a name="data"></a>   
### Assembly: System.Data.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Data.DataSysDescriptionAttribute?displayProperty=nameWithType>|<xref:System.Data.DataSysDescriptionAttribute> has been deprecated.|  
|<xref:System.Data.PropertyAttributes?displayProperty=nameWithType>|<xref:System.Data.PropertyAttributes> has been deprecated.|  
|<xref:System.Data.TypedDataSetGenerator?displayProperty=nameWithType>|The <xref:System.Data.TypedDataSetGenerator> class will be removed in a future release. Please use <xref:System.Data.Design.TypedDataSetGenerator?displayProperty=nameWithType> in System.Design.dll.|  
|<xref:System.Xml.XmlDataDocument?displayProperty=nameWithType>|The <xref:System.Xml.XmlDataDocument> class will be removed in a future release.|  
  
 [Back to top](#introduction)  
  
<a name="oracleclient"></a>   
### Assembly: System.Data.OracleClient.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Data.OracleClient.OracleClientFactory?displayProperty=nameWithType>|<xref:System.Data.OracleClient.OracleClientFactory> has been deprecated.|  
|<xref:System.Data.OracleClient.OracleCommand?displayProperty=nameWithType>|<xref:System.Data.OracleClient.OracleCommand> has been deprecated.|  
|<xref:System.Data.OracleClient.OracleCommandBuilder?displayProperty=nameWithType>|<xref:System.Data.OracleClient.OracleCommandBuilder> has been deprecated.|  
|<xref:System.Data.OracleClient.OracleConnection?displayProperty=nameWithType>|<xref:System.Data.OracleClient.OracleConnection> has been deprecated.|  
|<xref:System.Data.OracleClient.OracleConnectionStringBuilder?displayProperty=nameWithType>|<xref:System.Data.OracleClient.OracleConnectionStringBuilder> has been deprecated.|  
|<xref:System.Data.OracleClient.OracleDataAdapter?displayProperty=nameWithType>|<xref:System.Data.OracleClient.OracleDataAdapter> has been deprecated.|  
|<xref:System.Data.OracleClient.OraclePermission?displayProperty=nameWithType>|<xref:System.Data.OracleClient.OraclePermission> has been deprecated.|  
|<xref:System.Data.OracleClient.OraclePermissionAttribute?displayProperty=nameWithType>|<xref:System.Data.OracleClient.OraclePermissionAttribute?displayProperty=nameWithType> has been deprecated.|  
  
 [Back to top](#introduction)  
  
<a name="design"></a>   
### Assembly: System.Design.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.ComponentModel.Design.LocalizationExtenderProvider?displayProperty=nameWithType>|This class has been deprecated. Use <xref:System.ComponentModel.Design.Serialization.CodeDomLocalizationProvider?displayProperty=nameWithType> instead.|  
|<xref:System.Web.UI.Design.DataBindingCollectionConverter?displayProperty=nameWithType>|Use of this type is not recommended because DataBindings editing is launched via a <xref:System.ComponentModel.Design.DesignerActionList?displayProperty=nameWithType> instead of the property grid.|  
|<xref:System.Web.UI.Design.DataBindingCollectionEditor?displayProperty=nameWithType>|Use of this type is not recommended because DataBindings editing is launched via a <xref:System.ComponentModel.Design.DesignerActionList?displayProperty=nameWithType> instead of the property grid.|  
|<xref:System.Web.UI.Design.IControlDesignerBehavior?displayProperty=nameWithType>|The recommended alternative is <xref:System.Web.UI.Design.IControlDesignerTag?displayProperty=nameWithType> and <xref:System.Web.UI.Design.IControlDesignerView?displayProperty=nameWithType>.|  
|<xref:System.Web.UI.Design.IHtmlControlDesignerBehavior?displayProperty=nameWithType>|The recommended alternative is <xref:System.Web.UI.Design.IControlDesignerTag?displayProperty=nameWithType> and <xref:System.Web.UI.Design.IControlDesignerView?displayProperty=nameWithType>.|  
|<xref:System.Web.UI.Design.ITemplateEditingFrame?displayProperty=nameWithType>|Use of this type is not recommended because template editing is handled in <xref:System.Web.UI.Design.ControlDesigner?displayProperty=nameWithType>. To support template editing, expose template data in the <xref:System.Web.UI.Design.ControlDesigner.TemplateGroups%2A?displayProperty=nameWithType> property and call <xref:System.Web.UI.Design.ControlDesigner.SetViewFlags%2A?displayProperty=nameWithType>.|  
|<xref:System.Web.UI.Design.IWebFormReferenceManager?displayProperty=nameWithType>|The recommended alternative is <xref:System.Web.UI.Design.WebFormsReferenceManager?displayProperty=nameWithType>. The <xref:System.Web.UI.Design.WebFormsReferenceManager> contains additional functionality and allows for more extensibility. To get the <xref:System.Web.UI.Design.WebFormsReferenceManager>, use the `RootDesigner.ReferenceManager` property from your <xref:System.Web.UI.Design.ControlDesigner?displayProperty=nameWithType>.|  
|<xref:System.Web.UI.Design.IWebFormsDocumentService?displayProperty=nameWithType>|The recommended alternative is <xref:System.Web.UI.Design.WebFormsRootDesigner?displayProperty=nameWithType>. The <xref:System.Web.UI.Design.WebFormsRootDesigner> contains additional functionality and allows for more extensibility. To get the <xref:System.Web.UI.Design.WebFormsRootDesigner>, use the <xref:System.Web.UI.Design.ControlDesigner.RootDesigner%2A> property from your <xref:System.Web.UI.Design.ControlDesigner?displayProperty=nameWithType>.|  
|<xref:System.Web.UI.Design.ITemplateEditingService?displayProperty=nameWithType>|Use of this type is not recommended because template editing is handled in <xref:System.Web.UI.Design.ControlDesigner?displayProperty=nameWithType>. To support template editing, expose template data in the <xref:System.Web.UI.Design.ControlDesigner.TemplateGroups%2A?displayProperty=nameWithType> property and call <xref:System.Web.UI.Design.ControlDesigner.SetViewFlags%2A?displayProperty=nameWithType>.|  
|<xref:System.Web.UI.Design.ReadWriteControlDesigner?displayProperty=nameWithType>|The recommended alternative is <xref:System.Web.UI.Design.ContainerControlDesigner?displayProperty=nameWithType> because it uses an <xref:System.Web.UI.Design.EditableDesignerRegion?displayProperty=nameWithType> for editing the content. Designer regions allow for better control of the content being edited.|  
|<xref:System.Web.UI.Design.TemplateEditingService?displayProperty=nameWithType>|Use of this type is not recommended because template editing is handled in <xref:System.Web.UI.Design.ControlDesigner?displayProperty=nameWithType>. To support template editing, expose template data in the <xref:System.Web.UI.Design.ControlDesigner.TemplateGroups%2A?displayProperty=nameWithType> property and call <xref:System.Web.UI.Design.ControlDesigner.SetViewFlags%2A?displayProperty=nameWithType>.|  
|<xref:System.Web.UI.Design.TemplateEditingVerb?displayProperty=nameWithType>|Use of this type is not recommended because template editing is handled in <xref:System.Web.UI.Design.ControlDesigner?displayProperty=nameWithType>. To support template editing, expose template data in the <xref:System.Web.UI.Design.ControlDesigner.TemplateGroups%2A?displayProperty=nameWithType> property and call <xref:System.Web.UI.Design.ControlDesigner.SetViewFlags%2A?displayProperty=nameWithType>.|  
|<xref:System.Web.UI.Design.WebControls.CalendarAutoFormatDialog?displayProperty=nameWithType>|Use of this type is not recommended because the AutoFormat dialog is launched by the designer host. The list of available AutoFormats is exposed on the <xref:System.Web.UI.Design.ControlDesigner?displayProperty=nameWithType> in the <xref:System.Web.UI.Design.ControlDesigner.AutoFormats%2A?displayProperty=nameWithType> property.|  
|<xref:System.Web.UI.Design.WebControls.PanelDesigner?displayProperty=nameWithType>|The recommended alternative is <xref:System.Web.UI.Design.WebControls.PanelContainerDesigner?displayProperty=nameWithType> because it uses an <xref:System.Web.UI.Design.EditableDesignerRegion?displayProperty=nameWithType> for editing the content. Designer regions allow for better control of the content being edited.|  
  
 [Back to top](#introduction)  
  
<a name="system"></a>   
### Assembly: System.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.ComponentModel.IComNativeDescriptorHandler?displayProperty=nameWithType>|This interface has been deprecated. Add a <xref:System.ComponentModel.TypeDescriptionProvider?displayProperty=nameWithType> to handle type <xref:System.ComponentModel.TypeDescriptor.ComObjectType%2A?displayProperty=nameWithType> instead.|  
|<xref:System.ComponentModel.RecommendedAsConfigurableAttribute?displayProperty=nameWithType>|Use <xref:System.ComponentModel.SettingsBindableAttribute?displayProperty=nameWithType> instead to work with the new settings model.|  
|<xref:System.ComponentModel.Design.Serialization.RootDesignerSerializerAttribute?displayProperty=nameWithType>|This attribute has been deprecated. Use <xref:System.ComponentModel.Design.Serialization.DesignerSerializerAttribute?displayProperty=nameWithType> instead. For example, to specify a root designer for CodeDom, use `DesignerSerializerAttribute\(...,typeof\(TypeCodeDomSerializer\)\)`.|  
|<xref:System.Diagnostics.DiagnosticsConfigurationHandler?displayProperty=nameWithType>|This class has been deprecated.|  
|<xref:System.Diagnostics.PerformanceCounterManager?displayProperty=nameWithType>|This class has been deprecated. Use the performance counters through the <xref:System.Diagnostics.PerformanceCounter?displayProperty=nameWithType> class instead.|  
|<xref:System.Net.GlobalProxySelection?displayProperty=nameWithType>|This class has been deprecated. Please use <xref:System.Net.WebRequest.DefaultWebProxy%2A?displayProperty=nameWithType> instead to access and set the global default proxy. Use 'null' instead of <xref:System.Net.GlobalProxySelection.GetEmptyWebProxy%2A?displayProperty=nameWithType>.|  
|<xref:System.Net.Sockets.SocketClientAccessPolicyProtocol?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
  
 [Back to top](#introduction)  
  
<a name="enterpriseservices"></a>   
### Assembly: System.EnterpriseServices.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.EnterpriseServices.RegistrationHelperTx?displayProperty=nameWithType>|The <xref:System.EnterpriseServices.RegistrationHelperTx> class has been deprecated.|  
  
 [Back to top](#introduction)  
  
<a name="net"></a>   
### Assembly: System.Net.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Net.INetworkProgress?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.IUnsafeWebRequestCreate?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.NetworkProgressChangedEventArgs?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.UiSynchronizationContext?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.Sockets.HttpPolicyDownloaderProtocol?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.Sockets.SecurityCriticalAction?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.Sockets.SocketPolicy?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.Sockets.UdpAnySourceMulticastClient?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Net.Sockets.UdpSingleSourceMulticastClient?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
  
 [Back to top](#introduction)  
  
<a name="servicemodel"></a>   
### Assembly: System.ServiceModel.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.ServiceModel.NetPeerTcpBinding?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.Channels.HttpCookieContainerBindingElement?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> This type is obsolete. To enable Http <xref:System.Net.CookieContainer>, use the `AllowCookies` property on the Http binding or on the <xref:System.ServiceModel.Channels.HttpTransportBindingElement>.|  
|<xref:System.ServiceModel.Channels.PeerCustomResolverBindingElement?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.Channels.PeerTransportBindingElement?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.Configuration.NetPeerTcpBindingCollectionElement?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.Configuration.NetPeerTcpBindingElement?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.Configuration.PeerTransportElement?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
|<xref:System.ServiceModel.PeerResolvers.CustomPeerResolverService?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The peer channel feature is obsolete and will be removed in the future.|  
  
 [Back to top](#introduction)  
  
<a name="web"></a>   
### Assembly: System.Web.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Web.Configuration.PassportAuthentication?displayProperty=nameWithType>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.Mail.MailAttachment?displayProperty=nameWithType>|The recommended alternative is <xref:System.Net.Mail.Attachment?displayProperty=nameWithType>.|  
|<xref:System.Web.Mail.MailEncoding?displayProperty=nameWithType>|The recommended alternative is <xref:System.Net.Mime.TransferEncoding?displayProperty=nameWithType>.|  
|<xref:System.Web.Mail.MailFormat?displayProperty=nameWithType>|The recommended alternative is <xref:System.Net.Mail.MailMessage.IsBodyHtml%2A?displayProperty=nameWithType>.|  
|<xref:System.Web.Mail.MailMessage?displayProperty=nameWithType>|The recommended alternative is <xref:System.Net.Mail.MailMessage?displayProperty=nameWithType>.|  
|<xref:System.Web.Mail.MailPriority?displayProperty=nameWithType>|The recommended alternative is <xref:System.Net.Mail.MailPriority?displayProperty=nameWithType>.|  
|<xref:System.Web.Mail.SmtpMail?displayProperty=nameWithType>|The recommended alternative is <xref:System.Net.Mail.SmtpClient?displayProperty=nameWithType>.|  
|<xref:System.Web.Security.PassportAuthenticationEventArgs?displayProperty=nameWithType>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.Security.PassportAuthenticationEventHandler?displayProperty=nameWithType>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.Security.PassportAuthenticationModule?displayProperty=nameWithType>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.Security.PassportIdentity?displayProperty=nameWithType>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.Security.PassportPrincipal?displayProperty=nameWithType>|This type is obsolete. The Passport authentication product is no longer supported and has been superseded by [Microsoft Account](http://go.microsoft.com/fwlink/?LinkId=733413)|  
|<xref:System.Web.UI.ObjectConverter?displayProperty=nameWithType>|The recommended alternative is <xref:System.Convert?displayProperty=nameWithType> and <xref:System.String.Format%2A?displayProperty=nameWithType>.|  
  
 [Back to top](#introduction)  
  
<a name="mobile"></a>   
### Assembly: System.Web.Mobile.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Web.Mobile.CookielessData?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.DeviceFilterElement?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.DeviceFilterElementCollection?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.DeviceFiltersSection?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.ErrorHandlerModule?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.MobileCapabilities?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.MobileDeviceCapabilitiesSectionHandler?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.MobileErrorInfo?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.Mobile.MobileFormsAuthentication?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.Design.MobileControls.IMobileDesigner?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.Design.MobileControls.IMobileWebFormServices?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.Design.MobileControls.MobileResource?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.Design.MobileControls.Converters.DataFieldConverter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.Design.MobileControls.Converters.DataMemberConverter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.AdRotator?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Alignment?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ArrayListCollectionBase?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.BaseValidator?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.BooleanOption?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Calendar?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Command?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.CommandFormat?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.CompareValidator?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Constants?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ControlElement?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ControlElementCollection?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ControlPager?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.CustomValidator?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DesignerAdapterAttribute?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceElement?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceElementCollection?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceOverridableAttribute?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecific?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificChoice?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificChoiceCollection?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificChoiceControlBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificChoiceTemplateBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificChoiceTemplateContainer?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.DeviceSpecificControlBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ErrorFormatterPage?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.FontInfo?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.FontSize?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Form?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.FormControlBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.FormMethod?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.IControlAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Image?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.IObjectListFieldCollection?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.IPageAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ItemPager?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ITemplateable?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Label?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Link?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.List?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListCommandEventArgs?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListCommandEventHandler?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListControlBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListDataBindEventArgs?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListDataBindEventHandler?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListDecoration?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ListSelectType?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LiteralLink?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LiteralText?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LiteralTextContainerControlBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LiteralTextControlBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LoadItemsEventArgs?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.LoadItemsEventHandler?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileControl?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileControlBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileControlsSection?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileControlsSectionHandler?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileListItem?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileListItemCollection?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileListItemType?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobilePage?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileTypeNameConverter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.MobileUserControl?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectList?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListCommand?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListCommandCollection?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListCommandEventArgs?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListCommandEventHandler?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListControlBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListDataBindEventArgs?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListDataBindEventHandler?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListField?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListFieldCollection?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListItem?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListItemCollection?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListSelectEventArgs?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListSelectEventHandler?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListShowCommandsEventArgs?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListShowCommandsEventHandler?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListTitleAttribute?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ObjectListViewMode?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.PagedControl?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.PagerStyle?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Panel?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.PanelControlBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.PersistNameAttribute?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.PhoneCall?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.RangeValidator?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.RegularExpressionValidator?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.RequiredFieldValidator?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.SelectionList?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Style?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.StyleSheet?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.StyleSheetControlBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TemplateContainer?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TextBox?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TextBoxControlBuilder?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TextControl?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TextView?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.TextViewElement?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.ValidationSummary?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Wrapping?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlCalendarAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlCommandAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlFormAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlImageAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlLinkAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlMobileTextWriter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlPageAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlPhoneCallAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlSelectionListAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ChtmlTextBoxAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.ControlAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlCalendarAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlCommandAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlControlAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlFormAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlImageAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlLabelAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlLinkAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlListAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlLiteralTextAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlMobileTextWriter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlObjectListAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlPageAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlPanelAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlPhoneCallAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlSelectionListAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlTextBoxAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlTextViewAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlValidationSummaryAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.HtmlValidatorAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.MobileTextWriter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.MultiPartWriter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.UpWmlMobileTextWriter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.UpWmlPageAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlCalendarAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlCommandAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlControlAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlFormAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlImageAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlLabelAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlLinkAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlListAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlLiteralTextAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlMobileTextWriter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlObjectListAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlPageAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlPanelAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlPhoneCallAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlPostFieldType?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlSelectionListAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlTextBoxAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlTextViewAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlValidationSummaryAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.WmlValidatorAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.Doctype?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.StyleSheetLocation?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlCalendarAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlCommandAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlControlAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlCssHandler?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlFormAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlImageAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlLabelAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlLinkAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlListAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlLiteralTextAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlMobileTextWriter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlObjectListAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlPageAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlPanelAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlPhoneCallAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlSelectionListAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlTextBoxAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlTextViewAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlValidationSummaryAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
|<xref:System.Web.UI.MobileControls.Adapters.XhtmlAdapters.XhtmlValidatorAdapter?displayProperty=nameWithType>|The System.Web.Mobile.dll assembly has been deprecated and should no longer be used. For information about how to develop ASP.NET mobile applications, see [ASP.NET for Mobiles](http://go.microsoft.com/fwlink/?LinkId=157231).|  
  
 [Back to top](#introduction)  
  
<a name="workflow_activities"></a>   
### Assembly: System.Workflow.Activities.dll  
  
|Type|Message|  
|----------|-------------|  
|All types in the <xref:System.Workflow.Activities?displayProperty=nameWithType> namespace|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.Activities.Configuration.ActiveDirectoryRoleFactoryConfiguration?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.Activities.Rules.RuleActionTrackingEvent?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.Activities.Rules.RuleConditionReference?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.Activities.Rules.RuleSetReference?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
  
 [Back to top](#introduction)  
  
<a name="workflow_componentmodel"></a>   
### Assembly: System.Workflow.ComponentModel.dll  
  
|Type|Message|  
|----------|-------------|  
|All types in the <xref:System.Workflow.ComponentModel> namespace except <xref:System.Workflow.ComponentModel.GetValueOverride?displayProperty=nameWithType> and <xref:System.Workflow.ComponentModel.SetValueOverride?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|All types in the <xref:System.Workflow.ComponentModel.Compiler> namespace except <xref:System.Workflow.ComponentModel.Compiler.ValidationError?displayProperty=nameWithType> and <xref:System.Workflow.ComponentModel.Compiler.ValidationErrorCollection?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|All types in the <xref:System.Workflow.ComponentModel.Design> namespace except <xref:System.Workflow.ComponentModel.Design.ConnectorEventHandler>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.ActivityCodeDomSerializationManager?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.ActivityCodeDomSerializer?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.ActivityMarkupSerializer?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.ActivitySurrogateSelector?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.ActivityTypeCodeDomSerializer?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.CompositeActivityMarkupSerializer?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.ComponentModel.Serialization.DependencyObjectCodeDomSerializer?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The System.Workflow.\* types are deprecated. Instead, please use the new types from <xref:System.Activities>.\*.|  
  
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
|<xref:System.ServiceModel.WorkflowServiceHost?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Activation.WorkflowServiceHostFactory?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Activities.Description.WorkflowRuntimeEndpoint?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Configuration.ExtendedWorkflowRuntimeServiceElementCollection?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Configuration.PersistenceProviderElement?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Configuration.WorkflowRuntimeElement?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Description.DurableOperationAttribute?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Description.DurableServiceAttribute?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Description.PersistenceProviderBehavior?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Description.UnknownExceptionAction?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Description.WorkflowRuntimeBehavior?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Dispatcher.DurableOperationContext?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.InstanceLockException?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.InstanceNotFoundException?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.LockingPersistenceProvider?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.PersistenceException?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.PersistenceProvider?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.PersistenceProviderFactory?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.ServiceModel.Persistence.SqlPersistenceProviderFactory?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|All types in the <xref:System.Workflow.Activities?displayProperty=nameWithType> namespace|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
|<xref:System.Workflow.Runtime.Hosting.ChannelManagerService?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> The WF 3 types are deprecated. Instead, please use the new WF 4 types from <xref:System.Activities>.\*.|  
  
 [Back to top](#introduction)  
  
<a name="xaml"></a>   
### Assembly: System.Xaml.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Windows.Markup.AcceptedMarkupExtensionExpressionTypeAttribute?displayProperty=nameWithType>|This is not used by the XAML parser. Please look at <xref:System.Windows.Markup.XamlSetMarkupExtensionAttribute?displayProperty=nameWithType>.|  
  
 [Back to top](#introduction)  
  
<a name="xml"></a>   
### Assembly: System.Xml.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Xml.IApplicationResourceStreamResolver?displayProperty=nameWithType>|First deprecated in the .NET Framework 4.5.<br /><br /> Use of this type generates a compiler error.<br /><br /> This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Xml.Schema.XmlSchemaCollection?displayProperty=nameWithType>|Use <xref:System.Xml.Schema.XmlSchemaSet?displayProperty=nameWithType> for schema compilation and validation.|  
|<xref:System.Xml.XmlValidatingReader?displayProperty=nameWithType>|Use an <xref:System.Xml.XmlReader?displayProperty=nameWithType> created by the <xref:System.Xml.XmlReader.Create%2A?displayProperty=nameWithType> method using the appropriate <xref:System.Xml.XmlReaderSettings?displayProperty=nameWithType> instead.|  
|<xref:System.Xml.XmlXapResolver?displayProperty=nameWithType>|Use of this type generates a compiler error. This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.|  
|<xref:System.Xml.Xsl.XslTransform?displayProperty=nameWithType>|This class has been deprecated. Please use <xref:System.Xml.Xsl.XslCompiledTransform?displayProperty=nameWithType> instead.|  
  
 [Back to top](#introduction)  
  
<a name="WindowsBase"></a>   
### Assembly: WindowsBase.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:System.Windows.Markup.IReceiveMarkupExtension?displayProperty=nameWithType>|<xref:System.Windows.Markup.IReceiveMarkupExtension?displayProperty=nameWithType> has been deprecated. This interface is no longer in use.|  
  
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
|<xref:Microsoft.Build.BuildEngine.Engine?displayProperty=nameWithType>|This class has been deprecated. Please use <xref:Microsoft.Build.Evaluation.ProjectCollection?displayProperty=nameWithType> from the *Microsoft.Build* assembly instead.|  
|<xref:Microsoft.Build.BuildEngine.Project?displayProperty=nameWithType>|This class has been deprecated. Please use <xref:Microsoft.Build.Evaluation.ProjectCollection?displayProperty=nameWithType> from the *Microsoft.Build* assembly instead.|  
  
 [Back to top](#introduction)  
  
<a name="jscript"></a>   
### Assembly: Microsoft.JScript.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:Microsoft.JScript.Vsa.BaseVsaEngine?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.BaseVsaSite?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.BaseVsaStartup?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaCodeItem?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaEngine?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaError?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaGlobalItem?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaItem?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaItems?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaPersistSite?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaReferenceItem?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.IJSVsaSite?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.JSVsaError?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.JSVsaException?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.JSVsaItemFlag?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.JSVsaItemType?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.ResInfo?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
|<xref:Microsoft.JScript.Vsa.VsaEngine?displayProperty=nameWithType>|Use of this type is not recommended because it is being deprecated in Visual Studio 2005; there will be no replacement for this feature. Please see the <xref:System.CodeDom.Compiler.ICodeCompiler?displayProperty=nameWithType> documentation for additional help.|  
  
 [Back to top](#introduction)  
  
<a name="VBCompat"></a>   
### Assembly: Microsoft.VisualBasic.Compatibility.dll  
  For information about migrating from Visual Basic 6, see [Visual Basic 6.0 Resource Center](https://msdn.microsoft.com/library/windows/desktop/ms788229).
|Type|Message|  
|----------|-------------|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.BaseControlArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.BaseOcxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ButtonArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.CheckedListBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ColorDialogArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DirListBox?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DirListBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DriveListBox?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DriveListBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.FileListBox?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.FileListBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.FixedLengthString?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.FontDialogArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.FormShowConstants?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.HScrollBarArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ImageListArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.LabelArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ListBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ListViewArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.LoadResConstants?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.MaskedTextBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.MenuItemArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.MouseButtonConstants?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.OpenFileDialogArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.PanelArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.PrintDialogArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ProgressBarArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.RichTextBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.SaveFileDialogArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ScaleMode?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ShiftConstants?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.StatusBarArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.StatusStripArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.Support?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.TabControlArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.TimerArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ToolBarArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ToolStripArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.TreeViewArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.VScrollBarArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebBrowserArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClass?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassContainingClassNotOptional?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassCouldNotFindEvent?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassNextItemCannotBeCurrentWebItem?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassNextItemRespondNotFound?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassUserWebClassNameNotOptional?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassWebClassFileNameNotOptional?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebClassWebItemNotValid?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItem?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemAssociatedWebClassNotOptional?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemClosingTagNotFound?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemCouldNotLoadEmbeddedResource?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemCouldNotLoadTemplateFile?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemNameNotOptional?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemNoTemplateSpecified?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemTooManyNestedTags?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.WebItemUnexpectedErrorReadingTemplateFile?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ZOrderConstants?displayProperty=nameWithType>|This member is obsolete.|  
  
 [Back to top](#introduction)  
  
<a name="VBCompatData"></a>   
### Assembly: Microsoft.VisualBasic.Compatibility.Data.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.EndOfRecordsetDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.ErrorDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.FetchCompleteDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.FetchProgressDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.FieldChangeCompleteDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.MoveCompleteDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.RecordChangeCompleteDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.RecordsetChangeCompleteDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.WillChangeFieldDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.WillChangeRecordDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.WillChangeRecordsetDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODC.WillMoveDelegate?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.ADODCArray?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.BaseDataEnvironment?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.BindingCollectionEnumerator?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.CONNECTDATA?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBBINDING?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBCOLUMNINFO?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBID?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBinding?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBindingCollection?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBKINDENUM?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.DBPROPIDSET?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IAccessor?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IChapteredRowset?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IColumnsInfo?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IConnectionPoint?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IConnectionPointContainer?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IDataFormat?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IDataFormatDisp?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IEnumConnectionPoints?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IEnumConnections?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowPosition?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowPositionChange?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowset?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowsetChange?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowsetIdentity?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowsetInfo?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.IRowsetNotify?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.MBinding?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.MBindingCollection?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.SRDescriptionAttribute?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.UGUID?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.UNAME?displayProperty=nameWithType>|This member is obsolete.|  
|<xref:Microsoft.VisualBasic.Compatibility.VB6.UpdateMode?displayProperty=nameWithType>|This member is obsolete.|  
  
 [Back to top](#introduction)  
  
<a name="visualc"></a>   
### Assembly: Microsoft.VisualC.dll  
  
|Type|Message|  
|----------|-------------|  
|<xref:Microsoft.VisualC.DebugInfoInPDBAttribute?displayProperty=nameWithType>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.DecoratedNameAttribute?displayProperty=nameWithType>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.IsConstModifier?displayProperty=nameWithType>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.IsCXXReferenceModifier?displayProperty=nameWithType>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.IsLongModifier?displayProperty=nameWithType>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.IsSignedModifier?displayProperty=nameWithType>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.IsVolatileModifier?displayProperty=nameWithType>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.MiscellaneousBitsAttribute?displayProperty=nameWithType>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.NeedsCopyConstructorModifier?displayProperty=nameWithType>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
|<xref:Microsoft.VisualC.NoSignSpecifiedModifier?displayProperty=nameWithType>|Microsoft.VisualC.dll is an obsolete assembly and exists only for backwards compatibility.|  
  
## See Also  
 [What's Obsolete in the Class Library](../../../docs/framework/whats-new/whats-obsolete.md)  
 [Obsolete Members](../../../docs/framework/whats-new/obsolete-members.md)
