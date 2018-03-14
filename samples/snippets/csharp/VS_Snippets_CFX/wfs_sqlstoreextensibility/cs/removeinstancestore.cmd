@echo off
sqlcmd.exe -S ".\SQLEXPRESS" -Q "drop database InstanceStore"
echo InstanceStore successfully removed
pause