@echo off
if not .%FrameworkVersion% == . goto createStore
echo ERROR: Execute this script in a Visual Studio 2010 command prompt
pause
goto end

:createStore
sqlcmd.exe -S ".\SQLEXPRESS" -Q "create database SampleInstanceStore"
sqlcmd.exe -S ".\SQLEXPRESS" -d SampleInstanceStore -i %FrameworkDir%\%FrameworkVersion%\SQL\en\SqlWorkflowInstanceStoreSchema.sql
sqlcmd.exe -S ".\SQLEXPRESS" -d SampleInstanceStore -i %FrameworkDir%\%FrameworkVersion%\SQL\en\SqlWorkflowInstanceStoreLogic.sql
echo SampleInstanceStore successfully created
pause
:end