all: common.dll Client.exe service.exe

common.dll: constants.cs
	csc /t:library /out:common.dll constants.cs 

service.exe: service.cs common.dll
	csc /t:exe service.cs /r:common.dll /r:System.ServiceModel.dll /r:System.ServiceModel.Activities.dll /r:System.Activities.dll

client.exe: client.cs common.dll
	csc /t:exe client.cs /r:common.dll /r:System.Runtime.Serialization.dll /r:System.ServiceModel.dll /r:System.ServiceModel.Activities.dll /r:System.Activities.dll /r:System.Runtime.DurableInstancing.dll