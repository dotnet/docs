all: Transform.dll XsltDynamicMethodLoad.dll
 
Transform.dll: Transform.xslt
 xsltc /settings:script+ Transform.xslt 
 
XsltDynamicMethodLoad.dll: XsltDynamicMethodLoad.cs
 csc /r:Transform.dll XsltDynamicMethodLoad.cs 