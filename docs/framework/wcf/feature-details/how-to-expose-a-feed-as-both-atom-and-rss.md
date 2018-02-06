---
title: "How to: Expose a Feed as Both Atom and RSS"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: fe374932-67f5-487d-9325-f868812b92e4
caps.latest.revision: 23
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Expose a Feed as Both Atom and RSS
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] allows you to create a service that exposes a syndication feed. This topic discusses how to create a syndication service that exposes a syndication feed using both Atom 1.0 and RSS 2.0. This service exposes one endpoint that can return either syndication format. For simplicity the service used in this sample is self hosted. In a production environment a service of this type would be hosted under IIS or WAS. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the different [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] hosting options, see [Hosting](../../../../docs/framework/wcf/feature-details/hosting.md).  
  
### To create a basic syndication service  
  
1.  Define a service contract using an interface marked with the <xref:System.ServiceModel.Web.WebGetAttribute> attribute. Each operation that is exposed as a syndication feed returns a <xref:System.ServiceModel.Syndication.SyndicationFeedFormatter> object. Note the parameters for the <xref:System.ServiceModel.Web.WebGetAttribute>. `UriTemplate` specifies the URL used to invoke this service operation. The string for this parameter contains literals and a variable in braces ({*format*}). This variable corresponds to the service operation's `format` parameter. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.UriTemplate>. `BodyStyle` affects how the messages that this service operation sends and receives are written. <xref:System.ServiceModel.Web.WebMessageBodyStyle.Bare> specifies that the data sent to and from this service operation are not wrapped by infrastructure-defined XML elements. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.Web.WebMessageBodyStyle>.  
  
     [!code-csharp[htAtomRss#0](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/program.cs#0)]
     [!code-vb[htAtomRss#0](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/htatomrss/vb/program.vb#0)]  
  
    > [!NOTE]
    >  Use the <xref:System.ServiceModel.ServiceKnownTypeAttribute> to specify the types that are returned by the service operations in this interface.  
  
2.  Implement the service contract.  
  
     [!code-csharp[htAtomRss#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/program.cs#1)]
     [!code-vb[htAtomRss#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/htatomrss/vb/program.vb#1)]  
  
3.  Create a <xref:System.ServiceModel.Syndication.SyndicationFeed> object and add an author, category, and description.  
  
     [!code-csharp[htAtomRss#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/program.cs#2)]
     [!code-vb[htAtomRss#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/htatomrss/vb/program.vb#2)]  
  
4.  Create several <xref:System.ServiceModel.Syndication.SyndicationItem> objects.  
  
     [!code-csharp[htAtomRss#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/program.cs#3)]
     [!code-vb[htAtomRss#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/htatomrss/vb/program.vb#3)]  
  
5.  Add the <xref:System.ServiceModel.Syndication.SyndicationItem> objects to the feed.  
  
     [!code-csharp[htAtomRss#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/program.cs#4)]
     [!code-vb[htAtomRss#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/htatomrss/vb/program.vb#4)]  
  
6.  Use the format parameter to return the requested format.  
  
     [!code-csharp[htAtomRss#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/program.cs#5)]
     [!code-vb[htAtomRss#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/htatomrss/vb/program.vb#5)]  
  
### To host the service  
  
1.  Create a <xref:System.ServiceModel.Web.WebServiceHost> object. The <xref:System.ServiceModel.Web.WebServiceHost> class automatically adds an endpoint at the service's base address unless one is specified in code or configuration. In this sample, no endpoints are specified so the default endpoint is exposed.  
  
     [!code-csharp[htAtomRss#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/program.cs#6)]
     [!code-vb[htAtomRss#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/htatomrss/vb/program.vb#6)]  
  
2.  Open the service host, load the feed from the service, display the feed, and wait for the user to press ENTER.  
  
     [!code-csharp[htAtomRss#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/program.cs#8)]
     [!code-vb[htAtomRss#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/htatomrss/vb/program.vb#8)]  
  
### To call GetBlog with an HTTP GET  
  
1.  Open Internet Explorer, type the following URL, and press ENTER. http://localhost:8000/BlogService/GetBlog  
  
     The URL contains the base address of the service (http://localhost:8000/BlogService), the relative address of the endpoint, and the service operation to call.  
  
### To call GetBlog() from code  
  
1.  Create an <xref:System.Xml.XmlReader> with the base address and the method you are calling.  
  
     [!code-csharp[htAtomRss#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/snippets.cs#9)]
     [!code-vb[htAtomRss#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/htatomrss/vb/snippets.vb#9)]  
  
2.  Call the static <xref:System.ServiceModel.Syndication.SyndicationFeed.Load%28System.Xml.XmlReader%29> method, passing in the <xref:System.Xml.XmlReader> you just created.  
  
     [!code-csharp[htAtomRss#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/snippets.cs#10)]
     [!code-vb[htAtomRss#10](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/htatomrss/vb/snippets.vb#10)]  
  
     This invokes the service operation and populates a new <xref:System.ServiceModel.Syndication.SyndicationFeed> with the formatter returned from the service operation.  
  
3.  Access the feed object.  
  
     [!code-csharp[htAtomRss#11](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/snippets.cs#11)]
     [!code-vb[htAtomRss#11](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/htatomrss/vb/snippets.vb#11)]  
  
## Example  
 The following is the full code listing for this example.  
  
 [!code-csharp[htAtomRss#12](../../../../samples/snippets/csharp/VS_Snippets_CFX/htatomrss/cs/program.cs#12)]  
  
## Compiling the Code  
 When compiling the preceding code, reference System.ServiceModel.dll and System.ServiceModel.Web.dll.  
  
## See Also  
 <xref:System.ServiceModel.WebHttpBinding>  
 <xref:System.ServiceModel.Web.WebGetAttribute>
