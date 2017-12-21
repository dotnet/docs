---
title: "How to: Create a Service That Returns Arbitrary Data Using The WCF Web HTTP Programming Model"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0283955a-b4ae-458d-ad9e-6fbb6f529e3d
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Service That Returns Arbitrary Data Using The WCF Web HTTP Programming Model
Sometimes developers must have full control of how data is returned from a service operation. This is the case when a service operation must return data in a format not supported by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. This topic discusses using the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WEB HTTP Programming Model to create such a service. This service has one operation that returns a stream.  
  
### To implement the service contract  
  
1.  Define the service contract. The contract is called `IImageServer` and has one method called `GetImage` that returns a <xref:System.IO.Stream>.  
  
    ```  
    [ServiceContract]  
        public interface IImageServer  
        {  
            [WebGet]  
            Stream GetImage(int width, int height);  
        }  
    ```  
  
     Because the method returns a <xref:System.IO.Stream>, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] assumes that the operation has complete control over the bytes that are returned from the service operation and it applies no formatting to the data that is returned.  
  
2.  Implement the service contract. The contract has only one operation (`GetImage`). This method generates a bitmap and then save it to a <xref:System.IO.MemoryStream> in .jpg format. The operation then returns that stream to the caller.  
  
    ```  
    public class Service : IImageServer  
       {  
           public Stream GetImage(int width, int height)  
           {  
               Bitmap bitmap = new Bitmap(width, height);  
               for (int i = 0; i < bitmap.Width; i++)  
               {  
                   for (int j = 0; j < bitmap.Height; j++)  
                   {  
                       bitmap.SetPixel(i, j, (Math.Abs(i - j) < 2) ? Color.Blue : Color.Yellow);  
                   }  
               }  
               MemoryStream ms = new MemoryStream();  
               bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);  
               ms.Position = 0;  
               WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";  
               return ms;  
           }  
       }  
    ```  
  
     Notice the second to last line of code: `WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";`  
  
     This sets the content type header to `"image/jpeg"`. Although this sample shows how to return a .jpg file, it can be modified to return any type of data that is required, in any format. The operation must retrieve or generate the data and then write it to a stream.  
  
### To host the service  
  
1.  Create a console application to host the service.  
  
    ```  
    class Program  
    {  
        static void Main(string[] args)  
        {  
        }   
    }  
    ```  
  
2.  Create a variable to hold the base address for the service within the `Main` method.  
  
    ```  
    string baseAddress = "http://" + Environment.MachineName + ":8000/Service";  
    ```  
  
3.  Create a <xref:System.ServiceModel.ServiceHost> instance for the service specifying the service class and the base address.  
  
    ```  
    ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));  
    ```  
  
4.  Add an endpoint using the <xref:System.ServiceModel.WebHttpBinding> and the <xref:System.ServiceModel.Description.WebHttpBehavior>.  
  
    ```  
    host.AddServiceEndpoint(typeof(IImageServer), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());  
    ```  
  
5.  Open the service host.  
  
    ```  
    host.Open()  
    ```  
  
6.  Wait until the user presses ENTER to terminate the service.  
  
    ```  
    Console.WriteLine("Service is running");  
    Console.Write("Press ENTER to close the host");  
    Console.ReadLine();  
    host.Close();  
    ```  
  
### To call the raw service using Internet Explorer  
  
1.  Run the service, you should see the following output from the service. `Service is running Press ENTER to close the host`  
  
2.  Open Internet Explorer and type in `http://localhost:8000/Service/GetImage?width=50&height=40` you should see a yellow rectangle with a blue diagonal line through the center.  
  
## Example  
 The following is a complete listing of the code for this topic.  
  
```  
using System;  
using System.Collections.Generic;  
using System.Text;  
using System.ServiceModel;  
using System.ServiceModel.Web;  
using System.ServiceModel.Description;  
using System.IO;  
using System.Drawing;  
  
namespace RawImageService  
{  
    // Define the service contract  
    [ServiceContract]  
    public interface IImageServer  
    {  
        [WebGet]  
        Stream GetImage(int width, int height);  
    }  
  
    // implement the service contract  
    public class Service : IImageServer  
    {  
        public Stream GetImage(int width, int height)  
        {  
            // Although this method returns a jpeg, it can be  
            // modified to return any data you want within the stream  
            Bitmap bitmap = new Bitmap(width, height);  
            for (int i = 0; i < bitmap.Width; i++)  
            {  
                for (int j = 0; j < bitmap.Height; j++)  
                {  
                    bitmap.SetPixel(i, j, (Math.Abs(i - j) < 2) ? Color.Blue : Color.Yellow);  
                }  
            }  
            MemoryStream ms = new MemoryStream();  
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);  
            ms.Position = 0;  
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";  
            return ms;  
        }  
    }  
  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";  
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));  
            host.AddServiceEndpoint(typeof(IImageServer), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());  
            host.Open();  
            Console.WriteLine("Service is running");  
            Console.Write("Press ENTER to close the host");  
            Console.ReadLine();  
            host.Close();  
  
        }  
    }  
}  
```  
  
## Compiling the Code  
  
-   When compiling the sample code reference System.ServiceModel.dll and System.ServiceModel.Web.dll.  
  
## See Also  
 [WCF Web HTTP Programming Model](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model.md)
