all: program.exe

program.exe: program.cs snippets.cs MySyndicationFeed.cs
 csc /t:exe program.cs snippets.cs MySyndicationFeed.cs /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /lib:c:\whidbey\assemblies 

