### Error codes for maxRequestLength or maxReceivedMessageSize are different

|   |   |
|---|---|
|Details|Messages in WCF web services hosted in Internet Information Services (IIS) or ASP.NET Development Server that exceed maxRequestLength (in ASP.NET) or maxReceivedMessageSize (in WCF) have different error codeThe HTTP status code has changed from 400 (Bad Request) to 413 (Request Entity Too Large), and messages that exceed either the maxRequestLength or the maxReceivedMessageSize setting throw a <xref:System.ServiceModel.ProtocolException?displayProperty=name> exception. This includes cases in which the transfer mode is Streamed.|
|Suggestion|This change facilitates debugging in cases where the message length exceeds the limits allowed by ASP.NET or WCF.You must modify any code that performs processing based on an HTTP 400 status code.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
