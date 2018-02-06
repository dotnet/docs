---
title: "How to: Display Web-Style Links with the Windows Forms RichTextBox Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "text boxes [Windows Forms], displaying Web links"
  - "examples [Windows Forms], text boxes"
  - "RichTextBox control [Windows Forms], linking to Web pages"
ms.assetid: 95089a37-a202-4f7a-94ee-6ee312908851
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Display Web-Style Links with the Windows Forms RichTextBox Control
The Windows Forms <xref:System.Windows.Forms.RichTextBox> control can display Web links as colored and underlined. You can write code that opens a browser window showing the Web site specified in the link text when the link is clicked.  
  
### To link to a Web page with the RichTextBox control  
  
1.  Set the <xref:System.Windows.Forms.RichTextBox.Text%2A> property to a string that includes a valid URL (for example, "http://www.microsoft.com/").  
  
2.  Make sure the <xref:System.Windows.Forms.RichTextBox.DetectUrls%2A> property is set to `true` (the default).  
  
3.  Create a new global instance of the <xref:System.Diagnostics.Process> object.  
  
4.  Write an event handler for the <xref:System.Windows.Forms.RichTextBox.LinkClicked> event that sends the browser the desired text.  
  
     In the example below, the <xref:System.Windows.Forms.RichTextBox.LinkClicked> event opens an instance of Internet Explorer to the URL specified in the <xref:System.Windows.Forms.RichTextBox.Text%2A> property of the <xref:System.Windows.Forms.RichTextBox> control. This example assumes a form with a <xref:System.Windows.Forms.RichTextBox> control.  
  
    > [!IMPORTANT]
    >  In calling the <xref:System.Diagnostics.Process.Start%2A?displayProperty=nameWithType> method, you will encounter a <xref:System.Security.SecurityException> exception if you are running the code in a partial-trust context because of insufficient privileges. For more information, see [Code Access Security Basics](../../../../docs/framework/misc/code-access-security-basics.md).  
  
    ```vb  
    Public p As New System.Diagnostics.Process  
    Private Sub RichTextBox1_LinkClicked _  
       (ByVal sender As Object, ByVal e As _  
       System.Windows.Forms.LinkClickedEventArgs) _  
       Handles RichTextBox1.LinkClicked  
          ' Call Process.Start method to open a browser  
          ' with link text as URL.  
          p = System.Diagnostics.Process.Start("IExplore.exe", e.LinkText)  
    End Sub  
    ```  
  
    ```csharp  
    public System.Diagnostics.Process p = new System.Diagnostics.Process();  
  
    private void richTextBox1_LinkClicked(object sender,   
    System.Windows.Forms.LinkClickedEventArgs e)  
    {  
       // Call Process.Start method to open a browser  
       // with link text as URL.  
       p = System.Diagnostics.Process.Start("IExplore.exe", e.LinkText);  
    }  
    ```  
  
    ```cpp  
    public:  
       System::Diagnostics::Process ^ p;  
  
    private:  
       void richTextBox1_LinkClicked(System::Object ^  sender,  
          System::Windows::Forms::LinkClickedEventArgs ^  e)  
       {  
          // Call Process.Start method to open a browser  
          // with link text as URL.  
          p = System::Diagnostics::Process::Start("IExplore.exe",  
             e->LinkText);  
       }  
    ```  
  
     ([!INCLUDE[vcprvc](../../../../includes/vcprvc-md.md)]) You must initialize process `p`, which you can do by including the following statement in the constructor of your form:  
  
    ```cpp  
    p = gcnew System::Diagnostics::Process();  
    ```  
  
     ([!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], [!INCLUDE[vcprvc](../../../../includes/vcprvc-md.md)]) Place the following code in the form's constructor to register the event handler.  
  
    ```csharp  
    this.richTextBox1.LinkClicked += new   
       System.Windows.Forms.LinkClickedEventHandler  
       (this.richTextBox1_LinkClicked);  
    ```  
  
    ```cpp  
    this->richTextBox1->LinkClicked += gcnew  
       System::Windows::Forms::LinkClickedEventHandler  
       (this, &Form1::richTextBox1_LinkClicked);  
    ```  
  
     It is important to immediately stop the process you have created once you have finished working with it. Referring to the code presented above, your code to stop the process might look like this:  
  
    ```vb  
    Public Sub StopWebProcess()  
       p.Kill()  
    End Sub  
    ```  
  
    ```csharp  
    public void StopWebProcess()  
    {  
       p.Kill();  
    }  
    ```  
  
    ```cpp  
    public: void StopWebProcess()  
    {  
       p->Kill();  
    }  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.RichTextBox.DetectUrls%2A>  
 <xref:System.Windows.Forms.RichTextBox.LinkClicked>  
 <xref:System.Windows.Forms.RichTextBox>  
 [RichTextBox Control](../../../../docs/framework/winforms/controls/richtextbox-control-windows-forms.md)  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)
