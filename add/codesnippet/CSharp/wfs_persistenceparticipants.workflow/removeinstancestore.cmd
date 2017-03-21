@echo off
sqlcmd.exe -S ".\SQLEXPRESS" -Q "drop database SampleInstanceStore"
echo SampleInstanceStore successfully removed
pause