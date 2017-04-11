all: NetHttpBinding.dll
 
NetHttpBinding.dll : NetHttpDefaults.cs NetHttpSecurityMode.cs NetHttpBinding.cs NetHttpBindingCollectionElement.cs NetHttpBindingElement.cs NetHttpConfigurationStrings.cs
 csc /t:library /out:NetHttpBinding.dll NetHttpDefaults.cs NetHttpSecurityMode.cs NetHttpBinding.cs NetHttpBindingCollectionElement.cs NetHttpBindingElement.cs NetHttpConfigurationStrings.cs /r:System.ServiceModel.dll /r:System.Runtime.Serialization.dll 


