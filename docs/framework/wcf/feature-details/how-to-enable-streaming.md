---
title: "How to: Enable Streaming"
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
ms.assetid: 6ca2cf4b-c7a1-49d8-a79b-843a90556ba4
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Enable Streaming
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] can send messages using either buffered or streamed transfers. In the default buffered-transfer mode, a message must be completely delivered before a receiver can read it. In streaming transfer mode, the receiver can begin to process the message before it is completely delivered. The streaming mode is useful when the information that is passed is lengthy and can be processed serially. Streaming mode is also useful when the message is too large to be entirely buffered.  
  
 To enable streaming, define the `OperationContract` appropriately and enable streaming at the transport level.  
  
### To stream data  
  
1.  To stream data, the `OperationContract` for the service must satisfy two requirements:  
  
    1.  The parameter that holds the data to be streamed must be the only parameter in the method. For example, if the input message is the one to be streamed, the operation must have exactly one input parameter. Similarly, if the output message is to be streamed, the operation must have either exactly one output parameter or a return value.  
  
    2.  At least one of the types of the parameter and return value must be either <xref:System.IO.Stream>, <xref:System.ServiceModel.Channels.Message>, or <xref:System.Xml.Serialization.IXmlSerializable>.  
  
     The following is an example of a contract for streamed data.  
  
     [!code-csharp[c_HowTo_EnableStreaming#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_enablestreaming/cs/service.cs#1)]
     [!code-vb[c_HowTo_EnableStreaming#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_enablestreaming/vb/service.vb#1)]  
  
     The `GetStream` operation receives some buffered input data as a `string`, which is buffered, and returns a `Stream`, which is streamed. Conversely `UploadStream` takes in a `Stream` (streamed) and returns a `bool` (buffered). `EchoStream` takes and returns `Stream` and is an example of an operation whose input and output messages are both streamed. Finally, `GetReversedStream` takes no inputs and returns a `Stream` (streamed).  
  
2.  Streaming must be enabled on the binding. You set a `TransferMode` property, which can take one of the following values:  
  
    1.  `Buffered`,  
  
    2.  `Streamed`, which enables streaming communication in both directions.  
  
    3.  `StreamedRequest`, which enables streaming the request only.  
  
    4.  `StreamedResponse`, which enables streaming the response only.  
  
     The `BasicHttpBinding` exposes the `TransferMode` property on the binding, as does `NetTcpBinding` and `NetNamedPipeBinding`. The `TransferMode` property can also be set on the transport binding element and used in a custom binding.  
  
     The following samples show how to set `TransferMode` by code and by changing the configuration file. The samples also both set the `maxReceivedMessageSize` property to 64 MB, which places a cap on the maximum allowable size of messages on receive. The default `maxReceivedMessageSize` is 64 KB, which is usually too low for streaming scenarios. Set this quota setting as appropriate depending on the maximum size of messages your application expects to receive. Also note that `maxBufferSize` controls the maximum size that is buffered, and set it appropriately.  
  
    1.  The following configuration snippet from the sample shows setting the `TransferMode` property to streaming on the `basicHttpBinding` and a custom HTTP binding.  
  
         [!code-xml[c_HowTo_EnableStreaming#103](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_enablestreaming/common/app.config#103)]   
  
    2.  The following code snippet shows setting the `TransferMode` property to streaming on the `basicHttpBinding` and a custom HTTP binding.  
  
         [!code-csharp[c_HowTo_EnableStreaming_code#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_enablestreaming_code/cs/c_howto_enablestreaming_code.cs#2)]
         [!code-vb[c_HowTo_EnableStreaming_code#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_enablestreaming_code/vb/c_howto_enablestreaming_code.vb#2)]  
  
    3.  The following code snippet shows setting the `TransferMode` property to streaming on a custom TCP binding.  
  
         [!code-csharp[c_HowTo_EnableStreaming_code#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_enablestreaming_code/cs/c_howto_enablestreaming_code.cs#3)]
         [!code-vb[c_HowTo_EnableStreaming_code#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_enablestreaming_code/vb/c_howto_enablestreaming_code.vb#3)]  
  
3.  The operations `GetStream`, `UploadStream`, and `EchoStream` all deal with sending data directly from a file or saving received data directly to a file. The following code is for `GetStream`.  
  
     [!code-csharp[c_HowTo_EnableStreaming#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_enablestreaming/cs/service.cs#4)]
     [!code-vb[c_HowTo_EnableStreaming#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_enablestreaming/vb/service.vb#4)]  
  
### Writing a custom stream  
  
1.  To do special processing on each chunk of a data stream as it is being sent or received, derive a custom stream class from <xref:System.IO.Stream>. As an example of a custom stream, the following code contains a `GetReversedStream` method and a `ReverseStream` class-.  
  
     `GetReversedStream` creates and returns a new instance of `ReverseStream`. The actual processing happens as the system reads from the `ReverseStream` object. The `ReverseStream.Read` method reads a chunk of bytes from the underlying file, reverses them, then returns the reversed bytes. This method does not reverse the entire file content; it reverses one chunk of bytes at a time. This example shows how you can perform stream processing as the content is being read to or written from the stream.  
  
     [!code-csharp[c_HowTo_EnableStreaming#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_enablestreaming/cs/service.cs#2)]
     [!code-vb[c_HowTo_EnableStreaming#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_enablestreaming/vb/service.vb#2)]  
  
## See Also  
 [Large Data and Streaming](../../../../docs/framework/wcf/feature-details/large-data-and-streaming.md)  
 [Stream](../../../../docs/framework/wcf/samples/stream.md)
