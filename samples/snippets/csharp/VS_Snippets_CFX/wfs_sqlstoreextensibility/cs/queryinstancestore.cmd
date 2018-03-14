@echo off
sqlcmd.exe -S ".\SQLEXPRESS" -d InstanceStore -Q "select PromotionName, value1 from [System.Activities.DurableInstancing].[InstancePromotedProperties]"
pause