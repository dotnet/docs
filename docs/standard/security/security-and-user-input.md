---
title: "Security and User Input"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "security [.NET Framework], user input"
  - "user input, security"
  - "secure coding, user input"
  - "code security, user input"
ms.assetid: 9141076a-96c9-4b01-93de-366bb1d858bc
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Security and User Input
User data, which is any kind of input (data from a Web request or URL, input to controls of a Microsoft Windows Forms application, and so on), can adversely influence code because often that data is used directly as parameters to call other code. This situation is analogous to malicious code calling your code with strange parameters, and the same precautions should be taken. User input is actually harder to make safe because there is no stack frame to trace the presence of the potentially untrusted data.  
  
 These are among the subtlest and hardest security bugs to find because, although they can exist in code that is seemingly unrelated to security, they are a gateway to pass bad data through to other code. To look for these bugs, follow any kind of input data, imagine what the range of possible values might be, and consider whether the code seeing this data can handle all those cases. You can fix these bugs through range checking and rejecting any input the code cannot handle.  
  
 Some important considerations involving user data include the following:  
  
-   Any user data in a server response runs in the context of the server's site on the client. If your Web server takes user data and inserts it into the returned Web page, it might, for example, include a **\<script>** tag and run as if from the server.  
  
-   Remember that the client can request any URL.  
  
-   Consider tricky or invalid paths:  
  
    -   ..\ , extremely long paths.  
  
    -   Use of wild card characters (*).  
  
    -   Token expansion (%token%).  
  
    -   Strange forms of paths with special meaning.  
  
    -   Alternate file system stream names such as `filename::$DATA`.  
  
    -   Short versions of file names such as `longfi~1` for `longfilename`.  
  
-   Remember that Eval(userdata) can do anything.  
  
-   Be wary of late binding to a name that includes some user data.  
  
-   If you are dealing with Web data, consider the various forms of escapes that are permissible, including:  
  
    -   Hexadecimal escapes (%nn).  
  
    -   Unicode escapes (%nnn).  
  
    -   Overlong UTF-8 escapes (%nn%nn).  
  
    -   Double escapes (%nn becomes %mmnn, where %mm is the escape for '%').  
  
-   Be wary of user names that might have more than one canonical format. For example, you can often use either the MYDOMAIN\\*username* form or the *username*@mydomain.example.com form.  
  
## See Also  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)
