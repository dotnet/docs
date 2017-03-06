#include <stdio.h>
#include "mscoree.h"	// Generated from mscoree.idl


// The host must be able to find CoreCLR.dll to start the runtime.
// This string is used as a common, known location for a centrally installed CoreCLR.dll on Windows.
// If your customers will have the CoreCLR.dll installed elsewhere, this will, of course, need modified.
// Some hosts will carry the runtime and Framework with them locally so that necessary files like CoreCLR.dll 
// are easy to find and known to be good versions. Other hosts may expect that the apps they run will include
// CoreCLR.dll next to them. Still others may rely on an environment variable being set to indicate where
// the library can be found. In the end, every host will have its own heuristics for finding the core runtime
// library, but it must always be findable in order to start the CLR.
static const wchar_t *coreCLRInstallDirectory = L"%programfiles%\\dotnet\\shared\\Microsoft.NETCore.App\\1.1.0";

// Main clr library to load
// Note that on Linux and Mac platforms, this library will
// be called libcoreclr.so or libcoreclr.dylib, respectively
static const wchar_t* coreCLRDll = L"coreclr.dll";

// Helper method to check for CoreCLR.dll in a given path and load it, if possible
HMODULE LoadCoreCLR(const wchar_t* directoryPath);

// Function pointer type to be used if this sample is modified to use CreateDelegate to
// call into a static managed method (with signature void (string[])). This would be
// an alternative to using the ICLRRuntimeHost2::ExecuteAssembly helper function which
// loads and executes a managed assembly's entry point directly.
typedef void (STDMETHODCALLTYPE MainMethodFp)(LPWSTR* args);

// One large main method to keep this sample streamlined.
// 
// This function demonstrates how to start the .NET Core runtime,
// create an AppDomain, and execute managed code.
//
// It is meant as an educational sample, so not all error paths are checked,
// cross-platform functionality is not yet implemented, and some design
// decisions have been made to emphasize readability over efficiency.
int wmain(int argc, wchar_t* argv[])
{
	printf("Sample CoreCLR Host\n\n");

	//
	// STEP 1: Get the app to be run from the command line
	//
	if (argc < 2)
	{
		printf("ERROR - Specify exe to run as the app's first parameter");
		return -1;
	}

	// <Snippet1>
	// The managed application to run should be the first command-line parameter.
	// Subsequent command line parameters will be passed to the managed app later in this host.
	wchar_t targetApp[MAX_PATH];
	GetFullPathNameW(argv[1], MAX_PATH, targetApp, NULL);
	// </Snippet1>

	// Also note the directory the target app is in, as it will be referenced later.
	// The directory is determined by simply truncating the target app's full path
	// at the last path delimiter (\)
	wchar_t targetAppPath[MAX_PATH];
	wcscpy_s(targetAppPath, targetApp);
	size_t i = wcslen(targetAppPath - 1);
	while (i >= 0 && targetAppPath[i] != L'\\') i--;
	targetAppPath[i] = L'\0';



	//
	// STEP 2: Find and load CoreCLR.dll
	//
	HMODULE coreCLRModule;

	// Look in %CORE_ROOT%
	wchar_t coreRoot[MAX_PATH];
	size_t outSize;
	_wgetenv_s(&outSize, coreRoot, MAX_PATH, L"CORE_ROOT");
	coreCLRModule = LoadCoreCLR(coreRoot);

	// If CoreCLR.dll wasn't in %CORE_ROOT%, look next to the target app
	if (!coreCLRModule)
	{
		wcscpy_s(coreRoot, MAX_PATH, targetAppPath);
		coreCLRModule = LoadCoreCLR(coreRoot);
	}

	// If CoreCLR.dll wasn't in %CORE_ROOT% or next to the app, 
	// look in the common 1.1.0 install directory
	if (!coreCLRModule)
	{
		::ExpandEnvironmentStringsW(coreCLRInstallDirectory, coreRoot, MAX_PATH);
		coreCLRModule = LoadCoreCLR(coreRoot);
	}
	
	if (!coreCLRModule)
	{
		printf("ERROR - CoreCLR.dll could not be found");
		return -1;
	}
	else
	{
		wprintf(L"CoreCLR loaded from %s\n", coreRoot);
	}



	//
	// STEP 3: Get ICLRRuntimeHost2 instance
	//

	// <Snippet3>
	ICLRRuntimeHost2* runtimeHost;

	FnGetCLRRuntimeHost pfnGetCLRRuntimeHost =
		(FnGetCLRRuntimeHost)::GetProcAddress(coreCLRModule, "GetCLRRuntimeHost");

	if (!pfnGetCLRRuntimeHost)
	{
		printf("ERROR - GetCLRRuntimeHost not found");
		return -1;
	}

	// Get the hosting interface
	HRESULT hr = pfnGetCLRRuntimeHost(IID_ICLRRuntimeHost2, (IUnknown**)&runtimeHost);
	// </Snippet3>

	if (FAILED(hr))
	{
		printf("ERROR - Failed to get ICLRRuntimeHost2 instance.\nError code:%x\n", hr);
		return -1;
	}

	//
	// STEP 4: Set desired startup flags and start the CLR
	//

	// <Snippet4>
	hr = runtimeHost->SetStartupFlags(
		// These startup flags control runtime-wide behaviors.
		// A complete list of STARTUP_FLAGS can be found in mscoree.h,
		// but some of the more common ones are listed below.
		static_cast<STARTUP_FLAGS>(
			// STARTUP_FLAGS::STARTUP_SERVER_GC |								// Use server GC
			// STARTUP_FLAGS::STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN |		// Maximize domain-neutral loading
			// STARTUP_FLAGS::STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN_HOST |	// Domain-neutral loading for strongly-named assemblies
			STARTUP_FLAGS::STARTUP_CONCURRENT_GC |						// Use concurrent GC
			STARTUP_FLAGS::STARTUP_SINGLE_APPDOMAIN |					// All code executes in the default AppDomain 
																		// (required to use the runtimeHost->ExecuteAssembly helper function)
			STARTUP_FLAGS::STARTUP_LOADER_OPTIMIZATION_SINGLE_DOMAIN	// Prevents domain-neutral loading
		)
	);
	// </Snippet4>

	if (FAILED(hr))
	{
		printf("ERROR - Failed to set startup flags.\nError code:%x\n", hr);
		return -1;
	}

	// Starting the runtime will initialize the JIT, GC, loader, etc.
	hr = runtimeHost->Start();
	if (FAILED(hr))
	{
		printf("ERROR - Failed to start the runtime.\nError code:%x\n", hr);
		return -1;
	}
	else
	{
		printf("Runtime started\b");
	}



	//
	// STEP 5: Prepare properties for the AppDomain we will create
	//

	// Flags
	// <Snippet5>
	int appDomainFlags =
		// APPDOMAIN_FORCE_TRIVIAL_WAIT_OPERATIONS |		// Do not pump messages during wait
		// APPDOMAIN_SECURITY_SANDBOXED |					// Causes assemblies not from the TPA list to be loaded as partially trusted
		APPDOMAIN_ENABLE_PLATFORM_SPECIFIC_APPS |			// Enable platform-specific assemblies to run
		APPDOMAIN_ENABLE_PINVOKE_AND_CLASSIC_COMINTEROP |	// Allow PInvoking from non-TPA assemblies
		APPDOMAIN_DISABLE_TRANSPARENCY_ENFORCEMENT;			// Entirely disables transparency checks 
	// </Snippet5>

	// <Snippet6>
	// TRUSTED_PLATFORM_ASSEMBLIES
	// "Trusted Platform Assemblies" are prioritized by the loader and always loaded with full trust.
	// A common pattern is to include any assemblies next to CoreCLR.dll as platform assemblies.
	// More sophisticated hosts may also include their own Framework extensions (such as AppDomain managers)
	// in this list.
	int tpaSize = 100 * MAX_PATH; // Starting size for our TPA (Trusted Platform Assemblies) list
	wchar_t* trustedPlatformAssemblies = new wchar_t[tpaSize];
	trustedPlatformAssemblies[0] = L'\0';

	// Extensions to probe for when finding TPA list files
	wchar_t *tpaExtensions[] = {
		L"*.dll",
		L"*.exe",
		L"*.winmd"
	};

	// Probe next to CoreCLR.dll for any files matching the extensions from tpaExtensions and
	// add them to the TPA list. In a real host, this would likely be extracted into a separate function
	// and perhaps also run on other directories of interest.
	for (int i = 0; i < _countof(tpaExtensions); i++)
	{
		// Construct the file name search pattern
		wchar_t searchPath[MAX_PATH];
		wcscpy_s(searchPath, MAX_PATH, coreRoot);
		wcscat_s(searchPath, MAX_PATH, L"\\");
		wcscat_s(searchPath, MAX_PATH, tpaExtensions[i]);

		// Find files matching the search pattern
		WIN32_FIND_DATAW findData;
		HANDLE fileHandle = FindFirstFileW(searchPath, &findData);

		if (fileHandle != INVALID_HANDLE_VALUE)
		{
			do
			{
				// Construct the full path of the trusted assembly
				wchar_t pathToAdd[MAX_PATH];
				wcscpy_s(pathToAdd, MAX_PATH, coreRoot);
				wcscat_s(pathToAdd, MAX_PATH, L"\\");
				wcscat_s(pathToAdd, MAX_PATH, findData.cFileName);

				// Check to see if TPA list needs expanded
				if (wcslen(pathToAdd) + (3) + wcslen(trustedPlatformAssemblies) >= tpaSize)
				{
					// Expand, if needed
					tpaSize *= 2;
					wchar_t* newTPAList = new wchar_t[tpaSize];
					wcscpy_s(newTPAList, tpaSize, trustedPlatformAssemblies);
					trustedPlatformAssemblies = newTPAList;
				}

				// Add the assembly to the list and delimited with a semi-colon
				wcscat_s(trustedPlatformAssemblies, tpaSize, pathToAdd);
				wcscat_s(trustedPlatformAssemblies, tpaSize, L";");

				// Note that the CLR does not guarantee which assembly will be loaded if an assembly
				// is in the TPA list multiple times (perhaps from different paths or perhaps with different NI/NI.dll
				// extensions. Therefore, a real host should probably add items to the list in priority order and only
				// add a file if it's not already present on the list.
				//
				// For this simple sample, though, and because we're only loading TPA assemblies from a single path,
				// we can ignore that complication.
			}
			while (FindNextFileW(fileHandle, &findData));
			FindClose(fileHandle);
		}
	}


	// APP_PATHS
	// App paths are directories to probe in for assemblies which are not one of the well-known Framework assemblies
	// included in the TPA list.
	//
	// For this simple sample, we just include the directory the target application is in.
	// More complex hosts may want to also check the current working directory or other
	// locations known to contain application assets.
	wchar_t appPaths[MAX_PATH * 50];

	// Just use the targetApp provided by the user and remove the file name
	wcscpy_s(appPaths, targetAppPath);


	// APP_NI_PATHS
	// App (NI) paths are the paths that will be probed for native images not found on the TPA list. 
	// It will typically be similar to the app paths.
	// For this sample, we probe next to the app and in a hypothetical directory of the same name with 'NI' suffixed to the end.
	wchar_t appNiPaths[MAX_PATH * 50];
	wcscpy_s(appNiPaths, targetAppPath);
	wcscat_s(appNiPaths, MAX_PATH * 50, L";");
	wcscat_s(appNiPaths, MAX_PATH * 50, targetAppPath);
	wcscat_s(appNiPaths, MAX_PATH * 50, L"NI");


	// NATIVE_DLL_SEARCH_DIRECTORIES
	// Native dll search directories are paths that the runtime will probe for native DLLs called via PInvoke
	wchar_t nativeDllSearchDirectories[MAX_PATH * 50];
	wcscpy_s(nativeDllSearchDirectories, appPaths);
	wcscat_s(nativeDllSearchDirectories, MAX_PATH * 50, L";");
	wcscat_s(nativeDllSearchDirectories, MAX_PATH * 50, coreRoot);


	// PLATFORM_RESOURCE_ROOTS
	// Platform resource roots are paths to probe in for resource assemblies (in culture-specific sub-directories)
	wchar_t platformResourceRoots[MAX_PATH * 50];
	wcscpy_s(platformResourceRoots, appPaths);


	// AppDomainCompatSwitch
	// Specifies compatibility behavior for the app domain. This indicates which compatibility
	// quirks to apply if an assembly doesn't have an explicit Target Framework Moniker. If a TFM is
	// present on an assembly, the runtime will always attempt to use quirks appropriate to the version
	// of the TFM.
	// 
	// Typically the latest behavior is desired, but some hosts may want to default to older Silverlight
	// or Windows Phone behaviors for compatibility reasons.
	wchar_t* appDomainCompatSwitch = L"UseLatestBehaviorWhenTFMNotSpecified";
	// </Snippet6>


	//
	// STEP 6: Create the AppDomain
	//

	// <Snippet7>
	DWORD domainId;

	// Setup key/value pairs for AppDomain  properties
	const wchar_t* propertyKeys[] = {
		L"TRUSTED_PLATFORM_ASSEMBLIES",
		L"APP_PATHS",
		L"APP_NI_PATHS",
		L"NATIVE_DLL_SEARCH_DIRECTORIES",
		L"PLATFORM_RESOURCE_ROOTS",
		L"AppDomainCompatSwitch"
	};

	// Property values which were constructed in step 5
	const wchar_t* propertyValues[] = {
		trustedPlatformAssemblies,
		appPaths,
		appNiPaths,
		nativeDllSearchDirectories,
		platformResourceRoots,
		appDomainCompatSwitch
	};

	// Create the AppDomain
	hr = runtimeHost->CreateAppDomainWithManager(
		L"Sample Host AppDomain",		// Friendly AD name
		appDomainFlags,
		NULL,							// Optional AppDomain manager assembly name
		NULL,							// Optional AppDomain manager type (including namespace)
		sizeof(propertyKeys)/sizeof(wchar_t*),
		propertyKeys,
		propertyValues,
		&domainId);
	// </Snippet7>

	if (FAILED(hr))
	{
		printf("ERROR - Failed to create AppDomain.\nError code:%x\n", hr);
		return -1;
	}
	else
	{
		printf("AppDomain %d created\n\n", domainId);
	}



	//
	// STEP 7: Run managed code
	//

	// ExecuteAssembly will load a managed assembly and execute its entry point.
	wprintf(L"Executing %s...\n\n", targetApp);

	// <Snippet8>
	DWORD exitCode = -1;
	hr = runtimeHost->ExecuteAssembly(domainId, targetApp, argc - 1, (LPCWSTR*)(argc > 1 ? &argv[1] : NULL), &exitCode);
	// </Snippet8>

	if (FAILED(hr))
	{
		wprintf(L"ERROR - Failed to execute %s.\nError code:%x\n", targetApp, hr);
		return -1;
	}

	// Alternatively, to start managed code execution with a method other than an assembly's entrypoint,
	// runtimeHost->CreateDelegate can be used to create a pointer to an arbitrary static managed method
	// which can then be executed directly or via runtimeHost->ExecuteInAppDomain.
	//
	//  void *pfnDelegate = NULL;
	//  hr = runtimeHost->CreateDelegate(
	//	  domainId,
	//	  L"HW, Version=1.0.0.0, Culture=neutral",	// Target managed assembly
	//	  L"ConsoleApplication.Program",				// Target managed type
	//	  L"Main",									// Target entry point (static method)
	//	  (INT_PTR*)&pfnDelegate);
	//  if (FAILED(hr))
	//  {
	//	  printf("ERROR - Failed to create delegate.\nError code:%x\n", hr);
	//	  return -1;
	//  }
	//  ((MainMethodFp*)pfnDelegate)(NULL);



	//
	// STEP 8: Clean up
	//

	// <Snippet9>
	runtimeHost->UnloadAppDomain(domainId, true /* Wait until unload complete */);
	runtimeHost->Stop();
	runtimeHost->Release();
	// </Snippet9>

	printf("\nDone\n");

	return exitCode;
}


// Helper methods

// Check for CoreCLR.dll in a given path and load it, if possible
HMODULE LoadCoreCLR(const wchar_t* directoryPath)
{
	wchar_t coreDllPath[MAX_PATH];
	wcscpy_s(coreDllPath, MAX_PATH, directoryPath);
	wcscat_s(coreDllPath, MAX_PATH, L"\\");
	wcscat_s(coreDllPath, MAX_PATH, coreCLRDll);

	// <Snippet2>
	HMODULE ret = LoadLibraryExW(coreDllPath, NULL, 0);
	// </Snippet2>
	return ret;
}
