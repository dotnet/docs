all: program.dll
 
program.dll: program.cs 
 csc /t:library program.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
