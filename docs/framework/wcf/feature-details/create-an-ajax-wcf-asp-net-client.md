---
title: "How to: Create an AJAX-Enabled WCF Service and an ASP.NET Client that Accesses the Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 95012df8-2a66-420d-944a-8afab261013e
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create an AJAX-Enabled WCF Service and an ASP.NET Client that Accesses the Service
This topic shows how to use Visual Studio 2008 to create an AJAX-enabled [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service and an ASP.NET client that accesses the service. The code for the service and for the client are provided in the Example section after the steps for creating them are described in the Procedures section.  
  
### To create the ASP.NET client application  
  
1.  Open [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)].  
  
2.  From the **File** menu, select **New**, then **Project**, then **Web**, and then select **ASP.NET Web Application**.  
  
3.  Name the Project `SandwichServices` and click **OK**.  
  
### To create the WCF AJAX-enabled service  
  
1.  Right-click the `SandwichServices` project in the **Solution Explorer** window and select **Add**, then **New Item**, and then **AJAX-enabled WCF Service**.  
  
2.  Name the service `CostService` in the **Name** box and click **Add**.  
  
3.  Open the CostService.svc.cs file.  
  
4.  Specify the `Namespace` for <xref:System.ServiceModel.ServiceContractAttribute> as `SandwichService`:  
  
    ```  
    namespace SandwichServices  
    {  
      [ServiceContract(Namespace = "SandwichServices")]  
      [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]  
       public class CostService  
       {  
         …  
       }  
     }  
    ```  
  
5.  Implement the operations in the service. Add the <xref:System.ServiceModel.OperationContractAttribute> to each of the operations to indicate that they are part of the contract. The following example implements a method that returns the cost of a given quantity of sandwiches.  
  
    ```  
    public class CostService  
    {  
        [OperationContract]  
        public double CostOfSandwiches(int quantity)  
        {  
            return 1.25 * quantity;  
        }  
  
    // Add more operations here and mark them with [OperationContract]  
    }  
    ```  
  
### To configure the client to access the service  
  
1.  Open the Default.aspx page and select the **Design** view.  
  
2.  From the **View** menu, select **Toolbox**.  
  
3.  Expand the **AJAX Extensions** node and drag and drop a **ScriptManager** on to the Default.aspx page.  
  
4.  Right-click the **ScriptManager** and select **Properties**.  
  
5.  Expand the **Services** collection in the **Properties** window to open up the **ServiceReference Collection Editor** window.  
  
6.  Click **Add**, specify `CostService.svc` as the **Path** referenced, and click **OK**.  
  
7.  Expand the **HTML** node in the **Toolbox** and drag and drop an **Input (Button)** on to the Default.aspx page.  
  
8.  Right-click the **Button** and select **Properties**.  
  
9. Change the **Value** field to `Price for 3 Sandwiches`.  
  
10. Double-click the **Button** to access the JavaScript code.  
  
11. Pass in the following JavaScript code within the <`script`> element.  
  
    ```  
    function Button1_onclick() {  
    var service = new SandwichServices.CostService();  
    service.CostOfSandwiches(3, onSuccess, null, null);  
    }  
  
    function onSuccess(result){  
    alert(result);  
    }  
    ```  
  
### To access the service from the client  
  
1.  Use Ctrl +F5 to launch the service and the Web client. Click the **Price for 3 Grilled Sandwiches** button to generate the expected output of "3.75".  
  
## Example  
 This example contains the service code contained in the WCFService.svc.cs file and the client code contained in the Default.aspx file.  
  
```  
//The service code contained in the CostService.svc.cs file.  
  
using System;  
using System.Linq;  
using System.Runtime.Serialization;  
using System.ServiceModel;  
using System.ServiceModel.Activation;  
using System.ServiceModel.Web;  
  
namespace SandwichServices  
{  
    [ServiceContract(Namespace="SandwichServices")]  
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]  
    public class CostService  
    {  
        // Add [WebGet] attribute to use HTTP GET  
        [OperationContract]  
        public double CostOfSandwiches(int quantity)  
        {  
            return 1.25 * quantity;  
        }  
  
        // Add more operations here and mark them with [OperationContract]  
    }  
}  
//The code for hosting the service is contained in the CostService.svc file.  
  
<%@ ServiceHost Language="C#" Debug="true" Service="SandwichServices.CostService" CodeBehind="CostService.svc.cs" %>  
  
//The client code contained in the Default.aspx file.  
  
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SandwichServices._Default" %>  
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
  
<html >  
<head runat="server">  
    <title>Untitled Page</title>  
<script language="javascript" type="text/javascript">  
// <!CDATA[  
  
function Button1_onclick() {  
var service = new SandwichServices.CostService();  
service.CostOfSandwiches(3, onSuccess, null, null);  
}  
  
function onSuccess(result){  
alert(result);  
}  
  
// ]]>  
</script>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
  
    </div>  
    <asp:ScriptManager ID="ScriptManager1" runat="server">  
        <services>  
            <asp:servicereference Path="CostService.svc" />  
        </services>  
    </asp:ScriptManager>  
    </form>  
    <p>  
        <input id="Button1" type="button" value="Price for 3 Sandwiches" onclick="return Button1_onclick()" /></p>  
</body>  
</html>  
```     
