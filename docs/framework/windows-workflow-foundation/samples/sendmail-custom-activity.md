---
title: "SendMail Custom Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 947a9ae6-379c-43a3-9cd5-87f573a5739f
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# SendMail Custom Activity
This sample demonstrates how to create a custom activity that derives from <xref:System.Activities.AsyncCodeActivity> to send mail using SMTP for use within a workflow application. The custom activity uses the capabilities of <xref:System.Net.Mail.SmtpClient> to send email asynchronously and to send mail with authentication. It also provides some end-user features like test mode, token replacement, file templates, and test drop path.  
  
 The following table details the arguments for the `SendMail` activity.  
  
|Name|Type|Description|  
|-|-|-|  
|Host|String|Address of the SMTP server host.|  
|Port|String|Port of the SMTP service in the host.|  
|EnableSsl|bool|Specifies whether the <xref:System.Net.Mail.SmtpClient> uses Secure Sockets Layer (SSL) to encrypt the connection.|  
|UserName|String|Username to set up the credentials to authenticate the sender <xref:System.Net.Mail.SmtpClient.Credentials%2A> property.|  
|Password|String|Password to set up the credentials to authenticate the sender <xref:System.Net.Mail.SmtpClient.Credentials%2A> property.|  
|Subject|<xref:System.Activities.InArgument%601>\<string>|Subject of the message.|  
|Body|<xref:System.Activities.InArgument%601>\<string>|Body of the message.|  
|Attachments|<xref:System.Activities.InArgument%601>\<string>|Attachment collection used to store data attached to this email message.|  
|From|<xref:System.Net.Mail.MailAddress>|From address for this email message.|  
|To|<xref:System.Activities.InArgument%601>\<<xref:System.Net.Mail.MailAddressCollection>>|Address collection that contains the recipients of this email message.|  
|CC|<xref:System.Activities.InArgument%601>\<<xref:System.Net.Mail.MailAddressCollection>>|Address collection that contains the carbon copy (CC) recipients for this email message.|  
|BCC|<xref:System.Activities.InArgument%601>\<<xref:System.Net.Mail.MailAddressCollection>>|Address collection that contains the blind carbon copy (BCC) recipients for this email message.|  
|Tokens|<xref:System.Activities.InArgument%601><IDictionary\<string, string>>|Tokens to replace in the body. This feature allows users to specify some values in the body than can be replaced later by the tokens provided using this property.|  
|BodyTemplateFilePath|String|Path of a template for the body. The `SendMail` activity copies the contents of this file to its body property.<br /><br /> The template can contain tokens that are replaced by the contents of the tokens property.|  
|TestMailTo|<xref:System.Net.Mail.MailAddress>|When this property is set, all emails are sent to the address specified in it.<br /><br /> This property is intended to be used when testing workflows. For example, when you want to make sure that all emails are sent without sending them to the actual recipients.|  
|TestDropPath|String|When this property is set, all emails are also saved in the specified file.<br /><br /> This property is intended to be used when you are testing or debugging workflows, to make sure that the format and contents of the outgoing emails is appropriate.|  
  
## Solution Contents  
 The solution contains two projects.  
  
|Project|Description|Important Files|  
|-------------|-----------------|---------------------|  
|SendMail|The SendMail activity|1.  SendMail.cs: implementation for the main activity<br />2.  SendMailDesigner.xaml and SendMailDesigner.xaml.cs: designer for the SendMail activity<br />3.  MailTemplateBody.htm: template for the email to be sent out.|  
|SendMailTestClient|Client to test the SendMail activity.  This project demonstrates two ways of invoking the SendMail activity: declaratively, and programmatically.|1.  Sequence1.xaml: workflow that invokes the SendMail activity.<br />2.  Program.cs: invokes Sequence1 and also creates a workflow programmatically that uses SendMail.|  
  
## Further configuration of the SendMail activity  
 Although not shown in the sample, users can perform addition configuration of the SendMail activity. The next three sections demonstrate how this is done.  
  
### Sending an email using tokens specified in the body  
 This code snippet demonstrates how you can send email with tokens in the body. Notice how the tokens are provided in the body property. Values for those tokens are provided to the tokens property.  
  
```html  
IDictionary<string, string> tokens = new Dictionary<string, string>();  
tokens.Add("@name", "John Doe");  
tokens.Add("@date", DateTime.Now.ToString());  
tokens.Add("@server", "localhost");  
  
new SendMail  
{  
    From = new LambdaValue<MailAddress>(ctx => new MailAddress("john.doe@contoso.com")),  
    To = new LambdaValue<MailAddressCollection>(  
                    ctx => new MailAddressCollection() { new MailAddress("someone@microsoft.com") }),  
    Subject = "Test email",  
    Body = "Hello @name. This is a test email sent from @server. Current date is @date",  
    Host = "localhost",  
    Port = 25,  
    Tokens = new LambdaValue<IDictionary<string, string>>(ctx => tokens)  
};  
```  
  
### Sending an email using a template  
 This snippet shows how to send an email using a template tokens in the body. Notice that when setting the `BodyTemplateFilePath` property we don’t need to provide the value for Body property (the contents of the template file will be copied to the body).  
  
```  
new SendMail  
{    
    From = new LambdaValue<MailAddress>(ctx => new MailAddress("john.doe@contoso.com")),  
    To = new LambdaValue<MailAddressCollection>(  
                    ctx => new MailAddressCollection() { new MailAddress("someone@microsoft.com") }),  
    Subject = "Test email",  
    Host = "localhost",  
    Port = 25,  
    Tokens = new LambdaValue<IDictionary<string, string>>(ctx => tokens),  
    BodyTemplateFilePath = @"..\..\..\SendMail\Templates\MailTemplateBody.htm",   
};  
```  
  
### Sending Mails in Testing Mode  
 This code snippet shows how to set the two testing properties: by setting `TestMailTo` to all messages will be sent to john.doe@contoso.con (without regard of the values of To, Cc, Bcc). By setting TestDropPath all outgoing emails will be also recorded in the provided path. These properties can be set independently (they are not related).  
  
```  
new SendMail  
{    
   From = new LambdaValue<MailAddress>(ctx => new MailAddress("john.doe@contoso.com")),  
   To = new LambdaValue<MailAddressCollection>(  
                    ctx => new MailAddressCollection() { new MailAddress("someone@microsoft.com") }),  
   Subject = "Test email",  
   Host = "localhost",  
   Port = 25,  
   Tokens = new LambdaValue<IDictionary<string, string>>(ctx => tokens),  
   BodyTemplateFilePath = @"..\..\..\SendMail\Templates\MailTemplateBody.htm",  
   TestMailTo= new LambdaValue<MailAddress>(ctx => new MailAddress("john.doe@contoso.com")),  
   TestDropPath = @"c:\Samples\SendMail\TestDropPath\",  
};  
```  
  
## Set-Up Instructions  
 Access to a SMTP server is required for this sample.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] setting up a SMTP server, see the following links.  
  
-   [Microsoft Technet](http://go.microsoft.com/fwlink/?LinkId=166060)  
  
-   [Configuring the SMTP Service (IIS 6.0)](http://go.microsoft.com/fwlink/?LinkId=150456)  
  
-   [IIS 7.0: Configure SMTP E-Mail](http://go.microsoft.com/fwlink/?LinkId=150457)  
  
-   [How to Install the SMTP Service](http://go.microsoft.com/fwlink/?LinkId=150458)  
  
 SMTP emulators provided by third parties are available for download.  
  
##### To run this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the SendMail.sln solution file.  
  
2.  Ensure that you have access to a valid SMTP server. See the set-up instructions.  
  
3.  Configure the program with your server address, and From and To email addresses.  
  
     To correctly run this sample, you may need to configure the value of From and To email addresses and the address of the SMTP server in  Program.cs and in Sequence.xaml. You will need to change the address in both locations since the program sends mail in two different ways  
  
4.  To build the solution, press CTRL+SHIFT+B.  
  
5.  To run the solution, press CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\SendMail`