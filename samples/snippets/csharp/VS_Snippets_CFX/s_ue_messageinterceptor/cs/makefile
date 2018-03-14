all: library.dll client.exe service.exe
 
library.dll: AsyncResult.cs ChainedAsyncResult.cs ChannelMessageInterceptor.cs InterceptingBindingElement.cs InterceptingBindingElementImporter.cs interceptingChannelBase.cs InterceptingChannelFactory.cs InterceptingChannelListener.cs InterceptingDuplexChannel.cs interceptingelement.cs TimeoutHelper.cs 
 csc /t:library /out:library.dll AsyncResult.cs ChainedAsyncResult.cs ChannelMessageInterceptor.cs InterceptingBindingElement.cs InterceptingBindingElementImporter.cs interceptingChannelBase.cs InterceptingChannelFactory.cs InterceptingChannelListener.cs InterceptingDuplexChannel.cs interceptingelement.cs TimeoutHelper.cs /r:System.ServiceModel.dll

client.exe: client.cs library.dll
 csc /t:exe client.cs /r:library.dll /r:System.ServiceModel.dll 

service.exe: service.cs library.dll
 csc /t:exe service.cs /r:library.dll /r:System.ServiceModel.dll 


