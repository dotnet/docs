all: Transform.dll XsltDynamicMethodLoad.dll
 
Transform.dll: Transform.xslt
 xsltc /settings:script+ Transform.xslt 
 
XsltDynamicMethodLoad.dll: XsltDynamicMethodLoad.vb
 vbc /r:Transform.dll XsltDynamicMethodLoad.vb