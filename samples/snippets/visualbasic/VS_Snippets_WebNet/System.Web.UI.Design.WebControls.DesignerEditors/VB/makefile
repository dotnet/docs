ASSEMBLY_LIST=/r:System.Configuration.Install.dll /r:System.Data.dll /r:System.Design.dll /r:System.DirectoryServices.dll /r:System.dll /r:System.Drawing.Design.dll /r:System.Drawing.dll /r:System.EnterpriseServices.dll /r:System.Management.dll /r:System.Messaging.dll /r:System.Runtime.Remoting.dll /r:System.Runtime.Serialization.Formatters.Soap.dll /r:System.Security.dll /r:System.ServiceProcess.dll /r:System.Web.dll /r:System.Web.RegularExpressions.dll /r:System.Web.Services.dll /r:System.Windows.Forms.dll /r:System.XML.dll /r:Microsoft.JScript.dll /r:Accessibility.dll /r:System.Data.OracleClient.dll

SRCV=DesignerEditors.vb 

OUTV=DesignerEditorsVB.dll

all: 
	vbc /target:library /out:$(OUTV) /nologo $(ASSEMBLY_LIST) $(SRCV)

clean:
	del $(OUTV)
