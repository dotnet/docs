---
description: "Learn more about: Accessing Application Web Services (Visual Basic)"
title: "Accessing Application Web Services"
ms.date: 07/20/2015
helpviewer_keywords:
  - "Web services [Visual Basic], My.WebServices object"
  - "My.WebServices object"
  - "applications [Visual Basic], Web services"
ms.assetid: 8ad5405b-e771-42b1-82d3-ce97af2cea9e
---
# Accessing Application Web Services (Visual Basic)

The `My.WebServices` object provides an instance of each Web service referenced by the current project. Each instance is instantiated on demand. You can access these Web services through the properties of the `My.WebServices` object. The name of the property is the same as the name of the Web service that the property accesses. Any class that inherits from <xref:System.Web.Services.Protocols.SoapHttpClientProtocol> is a Web service.

## Tasks

The following table lists possible ways to access Web services referenced by an application.

|To|See|
|---|---|
|Call a Web service|[My.WebServices Object](../../language-reference/objects/my-webservices-object.md)|
|Call a Web service asynchronously and handle an event when it completes|[How to: Call a Web Service Asynchronously](how-to-call-a-web-service-asynchronously.md)|

## See also

- [My.WebServices Object](../../language-reference/objects/my-webservices-object.md)
