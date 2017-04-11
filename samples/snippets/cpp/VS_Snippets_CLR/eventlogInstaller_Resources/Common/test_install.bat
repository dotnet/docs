
@if not "%2"=="/u" if not exist .\eventlogmsgs.dll echo Resource dll not found - .\EventLogMsgs.DLL
@if not "%2"=="/u" if not exist .\eventlogmsgs.dll goto end
@if not exist "%1"               echo Must specify install binary (source_cs.exe, source_vb.exe, etc)
@if not exist "%1"               goto end

@rem A very basic install - copy the resource dll and run the installer.

@rem If this isn't an uninstall, copy the resource dll.
@echo Copying resource dll to system directory...
@if not "%2"=="/u" xcopy /F /Y .\eventlogmsgs.dll %SystemRoot%\system32\eventlogmsgs.dll

InstallUtil %2 %1

:end