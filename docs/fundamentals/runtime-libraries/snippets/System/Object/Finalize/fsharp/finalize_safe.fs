module finalize_safe

// <Snippet2>
open Microsoft.Win32.SafeHandles
open System
open System.ComponentModel
open System.IO
open System.Runtime.InteropServices

// Windows API constants.
let HKEY_CLASSES_ROOT = 0x80000000
let ERROR_SUCCESS = 0
let KEY_QUERY_VALUE = 1
let KEY_SET_VALUE = 0x2
let REG_SZ = 1u
let MAX_PATH = 260

// Windows API calls.
[<DllImport("advapi32.dll", CharSet= CharSet.Auto, SetLastError=true)>]
extern int RegOpenKeyEx(nativeint hKey, string lpSubKey, int ulOptions, int samDesired, nativeint& phkResult)
[<DllImport("advapi32.dll", CharSet= CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError=true)>]
extern int RegQueryValueEx(nativeint hKey, string lpValueName, int lpReserved, uint& lpType, string lpData, uint& lpcbData)
[<DllImport("advapi32.dll", SetLastError = true)>]
extern int RegSetValueEx(nativeint hKey, [<MarshalAs(UnmanagedType.LPStr)>] string lpValueName, int Reserved, uint dwType, [<MarshalAs(UnmanagedType.LPStr)>] string lpData, int cpData)
[<DllImport("advapi32.dll", SetLastError=true)>]
extern int RegCloseKey(unativeint hKey)

type FileAssociationInfo(fileExtension: string) =
    // Private values.
    let ext =
        if fileExtension.StartsWith "." |> not then
            "." + fileExtension
        else
            fileExtension
    let mutable args = ""
    let mutable hAppIdHandle = Unchecked.defaultof<SafeRegistryHandle>
    let mutable hExtHandle = Unchecked.defaultof<SafeRegistryHandle>
    let openCmd = 
        let mutable lpType = 0u
        let mutable hExtension = 0n
        // Get the file extension value.
        let retVal = RegOpenKeyEx(nativeint HKEY_CLASSES_ROOT, fileExtension, 0, KEY_QUERY_VALUE, &hExtension)
        if retVal <> ERROR_SUCCESS then
            raise (Win32Exception retVal)
        // Instantiate the first SafeRegistryHandle.
        hExtHandle <- new SafeRegistryHandle(hExtension, true)

        let appId = String(' ', MAX_PATH)
        let mutable appIdLength = uint appId.Length
        let retVal = RegQueryValueEx(hExtHandle.DangerousGetHandle(), String.Empty, 0, &lpType, appId, &appIdLength)
        if retVal <> ERROR_SUCCESS then
            raise (Win32Exception retVal)
        // We no longer need the hExtension handle.
        hExtHandle.Dispose()

        // Determine the number of characters without the terminating null.
        let appId = appId.Substring(0, int appIdLength / 2 - 1) + @"\shell\open\Command"

        // Open the application identifier key.
        let exeName = String(' ', MAX_PATH)
        let exeNameLength = uint exeName.Length
        let mutable hAppId = 0n
        let retVal = RegOpenKeyEx(nativeint HKEY_CLASSES_ROOT, appId, 0, KEY_QUERY_VALUE ||| KEY_SET_VALUE, &hAppId)
        if retVal <> ERROR_SUCCESS then
            raise (Win32Exception retVal)

        // Instantiate the second SafeRegistryHandle.
        hAppIdHandle <- new SafeRegistryHandle(hAppId, true)

        // Get the executable name for this file type.
        let exePath = String(' ', MAX_PATH)
        let mutable exePathLength = uint exePath.Length
        let retVal = RegQueryValueEx(hAppIdHandle.DangerousGetHandle(), String.Empty, 0, &lpType, exePath, &exePathLength)
        if retVal <> ERROR_SUCCESS then
            raise (Win32Exception retVal)

        // Determine the number of characters without the terminating null.
        let exePath = 
            exePath.Substring(0, int exePathLength / 2 - 1)
            // Remove any environment strings.
            |> Environment.ExpandEnvironmentVariables

        let position = exePath.IndexOf '%'
        if position >= 0 then
            args <- exePath.Substring position
            // Remove command line parameters ('%0', etc.).
            exePath.Substring(0, position).Trim()
        else
            exePath

    member _.Extension =
        ext

    member _.Open
        with get () = openCmd
        and set (value) =
            if hAppIdHandle.IsInvalid || hAppIdHandle.IsClosed then
                raise (InvalidOperationException "Cannot write to registry key.")
            if not (File.Exists value) then
                raise (FileNotFoundException $"'{value}' does not exist")
            
            let cmd = value + " %1"
            let retVal = RegSetValueEx(hAppIdHandle.DangerousGetHandle(), String.Empty, 0, REG_SZ, value, value.Length + 1)
            if retVal <> ERROR_SUCCESS then
                raise (Win32Exception retVal)

    member this.Dispose() =
        this.Dispose true
        GC.SuppressFinalize this

    member _.Dispose(disposing) =
        // Ordinarily, we release unmanaged resources here
        // but all are wrapped by safe handles.

        // Release disposable objects.
        if disposing then
           if hExtHandle <> null then hExtHandle.Dispose()
           if hAppIdHandle <> null then hAppIdHandle.Dispose()

    interface IDisposable with
        member this.Dispose() =
            this.Dispose()
// </Snippet2>