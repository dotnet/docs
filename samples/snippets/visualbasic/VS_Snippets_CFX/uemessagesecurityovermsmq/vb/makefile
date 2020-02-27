all: program.exe
 
program.exe : Program.vb
 vbc /t:exe Program.vb /r:System.ServiceModel.dll,System.Messaging.dll /lib:c:\whidbey\assemblies

