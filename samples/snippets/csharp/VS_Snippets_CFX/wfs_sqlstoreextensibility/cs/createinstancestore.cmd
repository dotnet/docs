@echo off
if not .%FrameworkVersion% == . goto createStore
echo ERROR: Execute this script in a Visual Studio 2010 command prompt
pause
goto end

:createStore
sqlcmd.exe -S ".\SQLEXPRESS" -Q "create database InstanceStore"
sqlcmd.exe -S ".\SQLEXPRESS" -d InstanceStore -i %FrameworkDir%\%FrameworkVersion%\SQL\en\SqlWorkflowInstanceStoreSchema.sql
sqlcmd.exe -S ".\SQLEXPRESS" -d InstanceStore -i %FrameworkDir%\%FrameworkVersion%\SQL\en\SqlWorkflowInstanceStoreLogic.sql
echo InstanceStore successfully created
pause
:end