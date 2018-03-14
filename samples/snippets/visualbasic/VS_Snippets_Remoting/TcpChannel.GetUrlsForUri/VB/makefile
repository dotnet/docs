all:  class1.dll service.dll

service.dll:  service.vb
        vbc /t:library service.vb
class1.dll: class1.vb service.dll
        vbc /t:library class1.vb /r:service.dll