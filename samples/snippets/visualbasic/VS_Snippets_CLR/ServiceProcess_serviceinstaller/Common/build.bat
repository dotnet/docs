
set SOURCENAME=SimpleService
set OTHERSOURCE=SimpleServiceInstaller

@if not exist .\%SOURCENAME%.* echo Sample file not found; check input specification prefix - %1
@if not exist .\%SOURCENAME%.* goto exit


:clean_exe
if exist ".\%SOURCENAME%_vb.exe"  erase %SOURCENAME%_vb.exe
if exist ".\%SOURCENAME%_cs.exe"  erase %SOURCENAME%_cs.exe
if exist ".\%SOURCENAME%_cpp.exe" erase %SOURCENAME%_cpp.exe
if exist ".\%SOURCENAME%_js.exe" erase %SOURCENAME%_js.exe
if exist ".\%SOURCENAME%_vb.obj"  erase %SOURCENAME%_vb.obj
if exist ".\%SOURCENAME%_cs.obj"  erase %SOURCENAME%_cs.obj
if exist ".\%SOURCENAME%_cpp.obj" erase %SOURCENAME%_cpp.obj
if exist ".\%SOURCENAME%_js.obj" erase %SOURCENAME%_js.obj


set VB_LIBS=/r:mscorlib.dll /r:system.dll /r:system.management.dll /r:system.serviceprocess.dll /r:system.windows.forms.dll /r:system.data.dll /r:microsoft.jscript.dll /r:System.Configuration.Install.dll /r:System.Drawing.dll

if exist ".\%SOURCENAME%.vb" vbc /debug:full %VB_LIBS% /target:exe /out:%SOURCENAME%_vb.exe %SOURCENAME%.vb %OTHERSOURCE%.vb

if exist ".\%SOURCENAME%.cs" csc /debug:full /o- /r:Microsoft.JScript.dll /out:%SOURCENAME%_cs.exe %SOURCENAME%.cs %OTHERSOURCE%.cs

if exist ".\%SOURCENAME%.cpp" %CL_CMD% /Od /Zi /clr /Fo%SOURCENAME%_cpp.obj /Fe%SOURCENAME%_cpp.exe %SOURCENAME%.cpp %OTHERSOURCE%.cpp

:check
dir %SOURCENAME%_*.exe
@if not "%TESTDIR%" == "" if exist %TESTDIR%\. if exist %SOURCENAME%_*.exe echo Copying sample executables to %TESTDIR%
@if not "%TESTDIR%" == "" if exist %TESTDIR%\. if exist %SOURCENAME%_*.exe copy %SOURCENAME%_*.exe %TESTDIR%

:exit
