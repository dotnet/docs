all: bin\Samples.AspNet.dll

bin\Samples.AspNet.dll:  OdbcMembershipUser.cs SampleMembershipProvider.cs
        IF NOT EXIST bin md bin
   csc /target:library /nologo /out:bin\Samples.AspNet.dll OdbcMembershipUser.cs SampleMembershipProvider.cs /r:System.Web.dll /r:System.Configuration.dll 
