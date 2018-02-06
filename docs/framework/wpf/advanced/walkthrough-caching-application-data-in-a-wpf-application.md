---
title: "Walkthrough: Caching Application Data in a WPF Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "walkthroughs [WPF], caching"
  - "caching [.NET Framework]"
  - "caching [WPF]"
ms.assetid: dac2c9ce-042b-4d23-91eb-28f584415cef
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Caching Application Data in a WPF Application
Caching enables you to store data in memory for rapid access. When the data is accessed again, applications can get the data from the cache instead retrieving it from the original source. This can improve performance and scalability. In addition, caching makes data available when the data source is temporarily unavailable.  
  
 The [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] provides classes that enable you to use caching in [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] applications. These classes are located in the <xref:System.Runtime.Caching> namespace.  
  
> [!NOTE]
>  The <xref:System.Runtime.Caching> namespace is new in the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)]. This namespace makes caching is available to all [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] applications. In previous versions of the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)], caching was available only in the <xref:System.Web> namespace and therefore required a dependency on ASP.NET classes.  
  
 This walkthrough shows you how to use the caching functionality that is available in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] as part of a [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] application. In the walkthrough, you cache the contents of a text file.  
  
 Tasks illustrated in this walkthrough include the following:  
  
-   Creating a WPF application project.  
  
-   Adding a reference to the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
-   Initializing a cache.  
  
-   Adding a cache entry that contains the contents of a text file.  
  
-   Providing an eviction policy for the cache entry.  
  
-   Monitoring the path of the cached file and notifying the cache instance about changes to the monitored item.  
  
## Prerequisites  
 In order to complete this walkthrough, you will need:  
  
-   Microsoft [!INCLUDE[vs_dev10_long](../../../../includes/vs-dev10-long-md.md)].  
  
-   A text file that contains a small amount of text. (You will display the contents of the text file in a message box.) The code illustrated in the walkthrough assumes that you are working with the following file:  
  
     `c:\cache\cacheText.txt`  
  
     However, you can use any text file and make small changes to the code in this walkthrough.  
  
## Creating a WPF Application Project  
 You will start by creating a WPF application project.  
  
#### To create a WPF application  
  
1.  Start [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)].  
  
2.  In the **File** menu, click **New**, and then click **New Project**.  
  
     The **New Project** dialog box is displayed.  
  
3.  Under **Installed Templates**, select the programming language you want to use (**Visual Basic** or **Visual C#**).  
  
4.  In the **New Project** dialog box, select **WPF Application**.  
  
    > [!NOTE]
    >  If you do not see the **WPF Application** template, make sure that you are targeting a version of the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] that supports WPF. In the **New Project** dialog box, select [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] from the list.  
  
5.  In the **Name** text box, enter a name for your project. For example, you can enter **WPFCaching**.  
  
6.  Select the **Create directory for solution** check box.  
  
7.  Click **OK**.  
  
     The WPF Designer opens in **Design** view and displays the MainWindow.xaml file. [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] creates the **My Project** folder, the Application.xaml file, and the MainWindow.xaml file.  
  
## Targeting the .NET Framework and Adding a Reference to the Caching Assemblies  
 By default, WPF applications target the [!INCLUDE[net_client_v40_long](../../../../includes/net-client-v40-long-md.md)]. To use the <xref:System.Runtime.Caching> namespace in a WPF application, the application must target the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] (not the [!INCLUDE[net_client_v40_long](../../../../includes/net-client-v40-long-md.md)]) and must include a reference to the namespace.  
  
 Therefore, the next step is to change the .NET Framework target and add a reference to the <xref:System.Runtime.Caching> namespace.  
  
> [!NOTE]
>  The procedure for changing the .NET Framework target is different in a Visual Basic project and in a Visual C# project.  
  
#### To change the target .NET Framework in Visual Basic  
  
1.  In **Solutions Explorer**, right-click the project name, and then click **Properties**.  
  
     The properties window for the application is displayed.  
  
2.  Click the **Compile** tab.  
  
3.  At the bottom of the window, click **Advanced Compile Options…**.  
  
     The **Advanced Compiler Settings** dialog box is displayed.  
  
4.  In the **Target framework (all configurations)** list, select [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)]. (Do not select [!INCLUDE[net_client_v40_long](../../../../includes/net-client-v40-long-md.md)].)  
  
5.  Click **OK**.  
  
     The **Target Framework Change** dialog box is displayed.  
  
6.  In the **Target Framework Change** dialog box, click **Yes**.  
  
     The project is closed and is then reopened.  
  
7.  Add a reference to the caching assembly by following these steps:  
  
    1.  In **Solution Explorer**, right-click the name of the project and then click **Add Reference**.  
  
    2.  Select the **.NET** tab, select `System.Runtime.Caching`, and then click **OK**.  
  
#### To change the target .NET Framework in a Visual C# project  
  
1.  In **Solution Explorer**, right-click the project name and then click **Properties**.  
  
     The properties window for the application is displayed.  
  
2.  Click the **Application** tab.  
  
3.  In the **Target framework** list, select [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)]. (Do not select **.NET Framework 4 Client Profile**.)  
  
4.  Add a reference to the caching assembly by following these steps:  
  
    1.  Right-click the **References** folder and then click **Add Reference**.  
  
    2.  Select the **.NET** tab, select `System.Runtime.Caching`, and then click **OK**.  
  
## Adding a Button to the WPF Window  
 Next, you will add a button control and create an event handler for the button's `Click` event. Later you will add code to so when you click the button, the contents of the text file are cached and displayed.  
  
#### To add a button control  
  
1.  In **Solution Explorer**, double-click the MainWindow.xaml file to open it.  
  
2.  From the **Toolbox**, under **Common WPF Controls**, drag a `Button` control to the `MainWindow` window.  
  
3.  In the **Properties** window, set the `Content` property of the `Button` control to **Get Cache**.  
  
## Initializing the Cache and Caching an Entry  
 Next, you will add the code to perform the following tasks:  
  
-   Create an instance of the cache class—that is, you will instantiate a new <xref:System.Runtime.Caching.MemoryCache> object.  
  
-   Specify that the cache uses a <xref:System.Runtime.Caching.HostFileChangeMonitor> object to monitor changes in the text file.  
  
-   Read the text file and cache its contents as a cache entry.  
  
-   Display the contents of the cached text file.  
  
#### To create the cache object  
  
1.  Double-click the button you just added in order to create an event handler in the MainWindow.xaml.cs or MainWindow.Xaml.vb file.  
  
2.  At the top of the file (before the class declaration), add the following `Imports` (Visual Basic) or `using` (C#) statements:  
  
    ```csharp  
    using System.Runtime.Caching;  
    using System.IO;  
    ```  
  
    ```vb  
    Imports System.Runtime.Caching  
    Imports System.IO  
    ```  
  
3.  In the event handler, add the following code to instantiate the cache object:  
  
    ```csharp  
    ObjectCache cache = MemoryCache.Default;  
    ```  
  
    ```vb  
    Dim cache As ObjectCache = MemoryCache.Default  
    ```  
  
     The <xref:System.Runtime.Caching.ObjectCache> class is a built-in class that provides an in-memory object cache.  
  
4.  Add the following code to read the contents of a cache entry named `filecontents`:  
  
    ```vb  
    Dim fileContents As String = TryCast(cache("filecontents"), String)  
    ```  
  
    ```csharp  
    string fileContents = cache["filecontents"] as string;  
    ```  
  
5.  Add the following code to check whether the cache entry named `filecontents` exists:  
  
    ```vb  
    If fileContents Is Nothing Then  
  
    End If  
    ```  
  
    ```csharp  
    if (fileContents == null)  
    {  
  
    }  
    ```  
  
     If the specified cache entry does not exist, you must read the text file and add it as a cache entry to the cache.  
  
6.  In the `if/then` block, add the following code to create a new <xref:System.Runtime.Caching.CacheItemPolicy> object that specifies that the cache entry expires after 10 seconds.  
  
    ```vb  
    Dim policy As New CacheItemPolicy()  
    policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10.0)  
    ```  
  
    ```csharp  
    CacheItemPolicy policy = new CacheItemPolicy();  
    policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10.0);  
    ```  
  
     If no eviction or expiration information is provided, the default is <xref:System.Runtime.Caching.ObjectCache.InfiniteAbsoluteExpiration>, which means the cache entries never expire based only on an absolute time. Instead, cache entries expire only when there is memory pressure. As a best practice, you should always explicitly provide either an absolute or a siding expiration.  
  
7.  Inside the `if/then` block and following the code you added in the previous step, add the following code to create a collection for the file paths that you want to monitor, and to add the path of the text file to the collection:  
  
    ```vb  
    Dim filePaths As New List(Of String)()  
    filePaths.Add("c:\cache\cacheText.txt")  
    ```  
  
    ```csharp  
    List<string> filePaths = new List<string>();  
    filePaths.Add("c:\\cache\\cacheText.txt");  
    ```  
  
    > [!NOTE]
    >  If the text file you want to use is not `c:\cache\cacheText.txt`, specify the path where the text file is that you want to use.  
  
8.  Following the code that you added in the previous step, add the following code to add a new <xref:System.Runtime.Caching.HostFileChangeMonitor> object to the collection of change monitors for the cache entry:  
  
    ```vb  
    policy.ChangeMonitors.Add(New HostFileChangeMonitor(filePaths))  
    ```  
  
    ```csharp  
    policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));  
    ```  
  
     The <xref:System.Runtime.Caching.HostFileChangeMonitor> object monitors the text file's path and notifies the cache if changes occur. In this example, the cache entry will expire if the content of the file changes.  
  
9. Following the code that you added in the previous step, add the following code to read the contents of the text file:  
  
    ```vb  
    fileContents = File.ReadAllText("c:\cache\cacheText.txt") & vbCrLf & DateTime.Now.ToString()  
    ```  
  
    ```csharp  
    fileContents = File.ReadAllText("c:\\cache\\cacheText.txt") + + "\n" + DateTime.Now;   
    ```  
  
     The date and time timestamp is added so that you will be able to see when the cache entry expires.  
  
10. Following the code that you added in the previous step, add the following code to insert the contents of the file into the cache object as a <xref:System.Runtime.Caching.CacheItem> instance:  
  
    ```vb  
    cache.Set("filecontents", fileContents, policy)  
    ```  
  
    ```csharp  
    cache.Set("filecontents", fileContents, policy);  
    ```  
  
     You specify information about how the cache entry should be evicted by passing the <xref:System.Runtime.Caching.CacheItemPolicy> object that you created earlier as a parameter.  
  
11. After the `if/then` block, add the following code to display the cached file content in a message box:  
  
    ```vb  
    MessageBox.Show(fileContents)  
    ```  
  
    ```csharp  
    MessageBox.Show(fileContents);  
    ```  
  
12. In the **Build** menu, click **Build WPFCaching** to build your project.  
  
## Testing Caching in the WPF Application  
 You can now test the application.  
  
#### To test caching in the WPF application  
  
1.  Press CTRL+F5 to run the application.  
  
     The `MainWindow` window is displayed.  
  
2.  Click **Get Cache**.  
  
     The cached content from the text file is displayed in a message box. Notice the timestamp on the file.  
  
3.  Close the message box and then click **Get Cache** again**.**  
  
     The timestamp is unchanged. This indicates the cached content is displayed.  
  
4.  Wait 10 seconds or more and then click **Get Cache** again.  
  
     This time a new timestamp is displayed. This indicates that the policy let the cache entry expire and that new cached content is displayed.  
  
5.  In a text editor, open the text file that you created. Do not make any changes yet.  
  
6.  Close the message box and then click **Get Cache** again**.**  
  
     Notice the timestamp again.  
  
7.  Make a change to the text file and then save the file.  
  
8.  Close the message box and then click **Get Cache** again.  
  
     This message box contains the updated content from the text file and a new timestamp. This indicates that the host-file change monitor evicted the cache entry immediately when you changed the file, even though the absolute timeout period had not expired.  
  
    > [!NOTE]
    >  You can increase the eviction time to 20 seconds or more to allow more time for you to make a change in the file.  
  
## Code Example  
 After you have completed this walkthrough, the code for the project you created will resemble the following example.  
  
 [!code-csharp[CachingWPFApplications#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CachingWPFApplications/CSharp/MainWindow.xaml.cs#1)]
 [!code-vb[CachingWPFApplications#1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CachingWPFApplications/VisualBasic/MainWindow.xaml.vb#1)]  
  
## See Also  
 <xref:System.Runtime.Caching.MemoryCache>  
 <xref:System.Runtime.Caching.ObjectCache>  
 <xref:System.Runtime.Caching>  
 [Caching in .NET Framework Applications](../../../../docs/framework/performance/caching-in-net-framework-applications.md)
