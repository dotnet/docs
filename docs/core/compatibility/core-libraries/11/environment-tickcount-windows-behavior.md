---
title: "Breaking change: Environment.TickCount made consistent with Windows timeout behavior"
description: "Learn about the breaking change in .NET 11 where Environment.TickCount and Environment.TickCount64 on Windows now exclude sleep and hibernation time, consistent with OS wait APIs."
ms.date: 01/07/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/50755
---

# Environment.TickCount made consistent with Windows timeout behavior

On Windows, <xref:System.Environment.TickCount?displayProperty=nameWithType> and <xref:System.Environment.TickCount64?displayProperty=nameWithType> have been updated to be consistent with the behavior seen in the underlying wait APIs for the OS. They no longer include sleep or hibernation time as part of the elapsed time measured. This change also makes Windows behavior consistent with the behavior seen on other platforms and ensures it updates at the same frequency as the underlying interrupt timer for the system. This change allows for higher responsiveness in apps that opted in to higher frequency updates.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, on Windows, `Environment.TickCount64` returned the result of the Win32 [GetTickCount64](/windows/win32/api/sysinfoapi/nf-sysinfoapi-gettickcount64) API, which updated at a fixed cadence of 10-16ms (typically 15.5ms) and included the time the system spent in sleep, hibernation, or other low-power states.

On other platforms (such as Linux and macOS), `Environment.TickCount64` updated at the same frequency as the underlying interrupt timer for the system and only included the time the system was considered "awake".

On all platforms, `Environment.TickCount` returned the truncated result of `Environment.TickCount64` and exhibited identical behavior, but was subject to overflow approximately every 49 days.

## New behavior

On Windows, `Environment.TickCount64` now returns the result of the Win32 [QueryUnbiasedInterruptTime](/windows/win32/api/realtimeapiset/nf-realtimeapiset-queryunbiasedinterrupttime) API. This change brings the .NET API inline with the behavior used in the underlying wait APIs for the OS. It no longer includes non-awake time and updates at the same frequency as the underlying interrupt timer for the system.

On other platforms, `Environment.TickCount64` retains its behavior, which is consistent with the new behavior on Windows.

On all platforms, `Environment.TickCount` maintains its implementation and mirrors the behavior of `Environment.TickCount64`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Windows took a similar behavior breaking change in Windows 8 and Windows Server 2012 and newer versions such that APIs that accept a timeout (like [SleepEx](/windows/win32/api/synchapi/nf-synchapi-sleepex) and [WaitForMultipleObjectsEx](/windows/win32/api/synchapi/nf-synchapi-waitformultipleobjectsex)) no longer factor in non-awake time. This caused an inconsistency with .NET, as such wait APIs are frequently used in conjunction with <xref:System.Environment.TickCount64?displayProperty=nameWithType>, leading to hard-to-diagnose bugs such as timers firing unexpectedly.

Additionally, the underlying API that was used, [GetTickCount64](/windows/win32/api/sysinfoapi/nf-sysinfoapi-gettickcount64), was less precise and only updated at a fixed resolution. This resolution wasn't adjusted if the underlying interrupt timer for the OS had its frequency changed, which could lead to additional work being done for apps that had opted to run at a higher priority. The behavior was also inconsistent with the behavior seen on other platforms such as macOS and Linux.

The change ensures consistency with the underlying OS and across platforms. It can also lead to higher responsiveness in apps that opted into more frequent updates.

## Recommended action

Unless opted into higher frequency interrupt times, most code shouldn't experience any change in behavior. Apps will continue seeing updates at the same frequency as before. However, if update frequency is relevant, ensure that your timeouts pass in a correct value that meets the expectations of your code, or ensure that the application isn't opting into too high an update frequency. (This can only be done via P/Invoke APIs today.)

Some code might see timers no longer fire immediately after a machine wakes from a sleeping or low-power state. If such time is relevant, use APIs such as <xref:System.DateTime.UtcNow?displayProperty=nameWithType> to ensure such time can always be included. Such code might have to account for potential clock adjustments.

Code that is impacted by this change on Windows is likely already impacted by the same scenario on other platforms such as Linux and macOS.

## Affected APIs

- <xref:System.Environment.TickCount?displayProperty=fullName>
- <xref:System.Environment.TickCount64?displayProperty=fullName>
