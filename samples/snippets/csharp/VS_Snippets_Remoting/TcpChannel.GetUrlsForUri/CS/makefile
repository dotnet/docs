all:  class1.dll service.dll

service.dll:  service.cs
        csc /t:library service.cs
class1.dll: class1.cs service.dll
        csc /t:library class1.cs /r:service.dll