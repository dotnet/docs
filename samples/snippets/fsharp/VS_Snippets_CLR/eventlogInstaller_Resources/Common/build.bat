if exist .\source_*.exe erase .\source_*.exe

call nmake source_cs.exe
call nmake source_vb.exe
call nmake eventlogmsgs.dll

dir source_*.exe
if not "%TESTDIR%" == "" if exist %TESTDIR%\. if exist source_*.exe copy source_*.exe %TESTDIR%