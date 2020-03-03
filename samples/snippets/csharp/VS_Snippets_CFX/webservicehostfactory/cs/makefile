all: WebServiceHostFactory.dll

WebServiceHostFactory.dll: MyWebServiceHost.cs
 csc /t:library MyWebServiceHost.cs /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /lib:c:\whidbey\assemblies

