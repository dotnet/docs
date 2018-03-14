all: bin\Samples.AspNet.dll

bin\Samples.AspNet.dll:  OdbcMembershipUser.vb SampleMembershipProvider.vb
        IF NOT EXIST bin md bin
   vbc /target:library /nologo /out:bin\Samples.AspNet.dll OdbcMembershipUser.vb SampleMembershipProvider.vb /r:System.Web.dll /r:System.Configuration.dll 
