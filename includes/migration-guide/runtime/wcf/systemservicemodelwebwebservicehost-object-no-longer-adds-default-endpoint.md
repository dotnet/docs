### System.ServiceModel.Web.WebServiceHost object no longer adds a default endpoint

|   |   |
|---|---|
|Details|The <xref:System.ServiceModel.Web.WebServiceHost> object no longer adds a default endpoint if an explicit endpoint has been added by application code.|
|Suggestion|If users will expect to be able to connect to a default endpoint and other explicit endpoints have been added to the <xref:System.ServiceModel.Web.WebServiceHost?displayProperty=name>, default endpoints should also be added explicitly (using <xref:System.ServiceModel.ServiceHostBase.AddDefaultEndpoints?displayProperty=name>).|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.ServiceModel.ServiceHost.AddServiceEndpoint(System.Type%2CSystem.ServiceModel.Channels.Binding%2CSystem.String)?displayProperty=fullName></li><li><xref:System.ServiceModel.ServiceHost.AddServiceEndpoint(System.Type%2CSystem.ServiceModel.Channels.Binding%2CSystem.Uri)?displayProperty=fullName></li><li><xref:System.ServiceModel.ServiceHost.AddServiceEndpoint(System.Type%2CSystem.ServiceModel.Channels.Binding%2CSystem.String%2CSystem.Uri)?displayProperty=fullName></li><li><xref:System.ServiceModel.ServiceHost.AddServiceEndpoint(System.Type%2CSystem.ServiceModel.Channels.Binding%2CSystem.Uri%2CSystem.Uri)?displayProperty=fullName></li><li><xref:System.ServiceModel.ServiceHost.AddServiceEndpoint(System.Type%2CSystem.ServiceModel.Channels.Binding%2CSystem.Uri%2CSystem.Uri)?displayProperty=fullName></li><li><xref:System.ServiceModel.ServiceHostBase.AddServiceEndpoint(System.ServiceModel.Description.ServiceEndpoint)?displayProperty=fullName></li><li><xref:System.ServiceModel.ServiceHostBase.AddServiceEndpoint(System.String%2CSystem.ServiceModel.Channels.Binding%2CSystem.String)?displayProperty=fullName></li><li><xref:System.ServiceModel.ServiceHostBase.AddServiceEndpoint(System.String%2CSystem.ServiceModel.Channels.Binding%2CSystem.Uri)?displayProperty=fullName></li><li><xref:System.ServiceModel.ServiceHostBase.AddServiceEndpoint(System.String%2CSystem.ServiceModel.Channels.Binding%2CSystem.String%2CSystem.Uri)?displayProperty=fullName></li><li><xref:System.ServiceModel.ServiceHostBase.AddServiceEndpoint(System.String%2CSystem.ServiceModel.Channels.Binding%2CSystem.Uri%2CSystem.Uri)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0030A</li><li>CD0030B</li></ul>|

