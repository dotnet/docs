ECHO OFF

ECHO Warning--snippets have been added to the file.

REM Generate the CS files for EntityObject EDM:
"C:\WINNT\Microsoft.NET\Framework\v3.5\edmgen.exe" /mode:EntityClassGeneration /incsdl:.\CS\BIN\DEBUG\SalesOrders.csdl /outobjectlayer:.\SalesOrders.context.new.cs /language:CSharp /namespace:Microsoft.Samples.Edm /entitycontainer:SalesOrdersEntities


REM Generate the VB files for EntityObject EDM:
"C:\WINNT\Microsoft.NET\Framework\v3.5\edmgen.exe" /mode:EntityClassGeneration /incsdl:.\VB\BIN\DEBUG\SalesOrders.csdl /outobjectlayer:.\SalesOrders.context.new.vb /language:VB /namespace:Microsoft.Samples.Edm /entitycontainer:SalesOrdersEntities

pause