REM <snippetGenClientFromService>
"%windir%\Microsoft.NET\Framework\v4.0.20217\DataSvcUtil.exe" /language:CSharp /out:northwind.cs /uri:http://localhost:12345/Northwind.svc
REM </snippetGenClientFromService>

REM <snippetGenClientFromCsdl>
"%windir%\Microsoft.NET\Framework\v4.0.20217\DataSvcUtil.exe" /language:CSharp /in:Northwind.csdl /out:northwind.cs
REM </snippetGenClientFromCsdl>

REM <snippetGenClientFromEdmx>
rem "%windir%\Microsoft.NET\Framework\v4.0.20217\DataSvcUtil.exe" /language:CSharp /in:Northwind.edmx /out:northwind.cs
REM </snippetGenClientFromEdmx>

pause

