@echo off

echo Removing Contoso Sample Database...
Osql -S localhost\SQLExpress -E  -n -i %~dp0DbSetup\CleanupContoso.sql

Pause