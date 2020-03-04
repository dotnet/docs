all: WebServiceHostFactory.dll

WebServiceHostFactory.dll: MyWebServiceHost.vb
 vbc /t:library MyWebServiceHost.vb /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /lib:c:\whidbey\assemblies

