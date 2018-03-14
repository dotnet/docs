
#pragma once

// The following macros define the minimum required platform.  The minimum required platform
// is the earliest version of Windows, Internet Explorer etc. that has the necessary features
// to run your application.  The macros work by enabling all features available on platform
// versions up to and including the version specified.

// Modify the following defines if you have to target a platform prior to the ones specified below.
// Refer to MSDN for the latest info on corresponding values for different platforms.

#include <WinSDKVer.h>

#ifndef _WIN32_WINNT
#define _WIN32_WINNT _WIN32_WINNT_MAXVER      // Change this to the appropriate value to target other versions of Windows.
#endif

#include <SDKDDKVer.h>
