---
title: "How to: Get Progress from the .NET Framework 4.5 Installer"
description: Learn how to get progress from the .NET Framework 4.5 installer. If you develop apps for this .NET version, you can include (chain) .NET Framework 4.5 setup in your app's setup.
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
helpviewer_keywords:
  - "progress information, .NET Framework installer"
  - ".NET Framework, installing"
ms.assetid: 0a1a3ba3-7e46-4df2-afd3-f3a8237e1c4f
---

# How to: Get Progress from the .NET Framework 4.5 Installer

The .NET Framework 4.5 is a redistributable runtime. If you develop apps for this version of the .NET Framework, you can include (chain) .NET Framework 4.5 setup as a prerequisite part of your app's setup. To present a customized or unified setup experience, you may want to silently launch .NET Framework 4.5 setup and track its progress while showing your app's setup progress. To enable silent tracking, .NET Framework 4.5 setup (which can be watched) defines a protocol by using a memory-mapped I/O (MMIO) segment to communicate with your setup (the watcher or chainer). This protocol defines a way for a chainer to obtain progress information, get detailed results, respond to messages, and cancel the .NET Framework 4.5 setup.

- **Invocation**. To call .NET Framework 4.5 setup and receive progress information from the MMIO section, your setup program must do the following:

    1. Call the .NET Framework 4.5 redistributable program:

        `dotNetFx45_Full_x86_x64.exe /q /norestart /pipe section-name`

        Where *section name* is any name you want to use to identify your app. .NET Framework setup reads and writes to the MMIO section asynchronously, so you might find it convenient to use events and messages during that time. In the example, the .NET Framework setup process is created by a constructor that both allocates the MMIO section (`TheSectionName`) and defines an event (`TheEventName`):

        ```cpp
        Server():ChainerSample::MmioChainer(L"TheSectionName", L"TheEventName")
        ```

        Please replace those names with names that are unique to your setup program.

    2. Read from the MMIO section. In the .NET Framework 4.5, the download and installation operations are simultaneous: One part of the .NET Framework might be installing while another part is downloading. As a result, progress is sent back (that is, written) to the MMIO section as two numbers (`m_downloadSoFar` and `m_installSoFar`) that increase from 0 to 255. When 255 is written and the .NET Framework exits, the installation is complete.

- **Exit codes**. The following exit codes from the command to call the .NET Framework 4.5 redistributable program indicate whether setup has succeeded or failed:

  - 0 - Setup completed successfully.

  - 3010 – Setup completed successfully; a system restart is required.

  - 1602 – Setup has been canceled.

  - All other codes - Setup encountered errors; examine the log files created in %temp% for details.

- **Canceling setup**. You can cancel setup at any time by using the `Abort` method to set the `m_downloadAbort` and `m_ installAbort` flags in the MMIO section.

## Chainer Sample

The Chainer sample silently launches and tracks .NET Framework 4.5 setup while showing progress. This sample is similar to the Chainer sample provided for the .NET Framework 4. However, in addition, it can avoid system restarts by processing the message box for closing .NET Framework 4 apps. For information about this message box, see [Reducing System Restarts During .NET Framework 4.5 Installations](reducing-system-restarts.md). You can use this sample with the .NET Framework 4 installer; in that scenario, the message is simply not sent.

> [!WARNING]
> You must run the example as an administrator.

The following sections describe the significant files in this sample: MMIOChainer.h, ChainingdotNet4.cpp, and IProgressObserver.h.

#### MMIOChainer.h

- The MMIOChainer.h file contains the data structure definition and the base class from which the chainer class should be derived. The .NET Framework 4.5 extends the MMIO data structure to handle data that the .NET Framework 4.5 installer needs. The changes to the MMIO structure are backward-compatible, so a .NET Framework 4 chainer can work with .NET Framework 4.5 setup without requiring recompilation. However, this scenario does not support the feature for reducing system restarts.

    A version field provides a means of identifying revisions to the structure and message format. The .NET Framework setup determines the version of the chainer interface by calling the `VirtualQuery` function to determine the size of the file mapping. If the size is large enough to accommodate the version field, .NET Framework setup uses the specified value. If the file mapping is too small to contain a version field, which is the case with the .NET Framework 4, the setup process assumes version 0 (4). If the chainer does not support the version of the message that .NET Framework setup wants to send, .NET Framework setup assumes an ignore response.

    The MMIO data structure is defined as follows:

    ```cpp
    // MMIO data structure for interprocess communication
        struct MmioDataStructure
        {
            bool m_downloadFinished;               // Is download complete?
            bool m_installFinished;                // Is installation complete?
            bool m_downloadAbort;                  // Set to cause downloader to abort.
            bool m_installAbort;                   // Set to cause installer to abort.
            HRESULT m_hrDownloadFinished;          // Resulting HRESULT for download.
            HRESULT m_hrInstallFinished;           // Resulting HRESULT for installation.
            HRESULT m_hrInternalError;
            WCHAR m_szCurrentItemStep[MAX_PATH];
            unsigned char m_downloadSoFar;         // Download progress 0-255 (0-100% done).
            unsigned char m_installSoFar;          // Installation progress 0-255 (0-100% done).
            WCHAR m_szEventName[MAX_PATH];         // Event that chainer creates and chainee opens to sync communications.

            BYTE m_version;                        // Version of the data structure, set by chainer:
                                                   // 0x0: .NET Framework 4
                                                   // 0x1: .NET Framework 4.5

            DWORD m_messageCode;                   // Current message sent by the chainee; 0 if no message is active.
            DWORD m_messageResponse;               // Chainer's response to current message; 0 if not yet handled.
            DWORD m_messageDataLength;             // Length of the m_messageData field, in bytes.
            BYTE m_messageData[1];                 // Variable-length buffer; content depends on m_messageCode.
        };
    ```

- The `MmioDataStructure` data structure should not be used directly; use the `MmioChainer` class instead to implement your chainer. Derive from the `MmioChainer` class to chain the .NET Framework 4.5 redistributable.

#### IProgressObserver.h

- The IProgressObserver.h file implements a progress observer. This observer gets notified of download and installation progress (specified as an unsigned `char`, 0-255, indicating 1%-100% complete). The observer is also notified when the chainee sends a message, and the observer should send a response.

    ```cpp
        class IProgressObserver
        {
        public:
            virtual void OnProgress(unsigned char) = 0; // 0 - 255:  255 == 100%
            virtual void Finished(HRESULT) = 0;         // Called when operation is complete
            virtual DWORD Send(DWORD dwMessage, LPVOID pData, DWORD dwDataLength) = 0; // Called when a message is sent
        };
    ```

#### ChainingdotNet4.5.cpp

- The ChainingdotNet4.5.cpp file implements the `Server` class, which derives from the `MmioChainer` class and overrides the appropriate methods to display progress information. The MmioChainer creates a section with the specified section name and initializes the chainer with the specified event name. The event name is saved in the mapped data structure. You should make the section and event names unique. The `Server` class in the following code launches the specified setup program, monitors its progress, and returns an exit code.

    ```cpp
    class Server : public ChainerSample::MmioChainer, public ChainerSample::IProgressObserver
    {
    public:
        …………….
        Server():ChainerSample::MmioChainer(L"TheSectionName", L"TheEventName") //customize for your event names
        {}
    ```

    The installation is started in the Main method.

    ```cpp
    // Main entry point for program
    int __cdecl main(int argc, _In_count_(argc) char **_argv)
    {
        int result = 0;
        CString args;
        if (argc > 1)
        {
            args = CString(_argv[1]);
        }

        if (IsNetFx4Present(NETFX45_RC_REVISION))
        {
            printf(".NET Framework 4.5 is already installed");
        }
        else
        {
            result = Server().Launch(args);
        }

        return result;
    }
    ```

- Before launching the installation, the chainer checks to see if the .NET Framework 4.5 is already installed by calling `IsNetFx4Present`:

    ```cpp
    ///  Checks for presence of the .NET Framework 4.
    ///    A value of 0 for dwMinimumRelease indicates a check for the .NET Framework 4 full
    ///    Any other value indicates a check for a specific compatible release of the .NET Framework 4.
    #define NETFX40_FULL_REVISION 0
    // TODO: Replace with released revision number
    #define NETFX45_RC_REVISION MAKELONG(50309, 5)   // .NET Framework 4.5
    bool IsNetFx4Present(DWORD dwMinimumRelease)
    {
        DWORD dwError = ERROR_SUCCESS;
        HKEY hKey = NULL;
        DWORD dwData = 0;
        DWORD dwType = 0;
        DWORD dwSize = sizeof(dwData);

        dwError = ::RegOpenKeyExW(HKEY_LOCAL_MACHINE, L"SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full", 0, KEY_READ, &hKey);
        if (ERROR_SUCCESS == dwError)
        {
            dwError = ::RegQueryValueExW(hKey, L"Release", 0, &dwType, (LPBYTE)&dwData, &dwSize);

            if ((ERROR_SUCCESS == dwError) && (REG_DWORD != dwType))
            {
                dwError = ERROR_INVALID_DATA;
            }
            else if (ERROR_FILE_NOT_FOUND == dwError)
            {
                // Release value was not found, let's check for 4.0.
                dwError = ::RegQueryValueExW(hKey, L"Install", 0, &dwType, (LPBYTE)&dwData, &dwSize);

                // Install = (REG_DWORD)1;
                if ((ERROR_SUCCESS == dwError) && (REG_DWORD == dwType) && (dwData == 1))
                {
                    // treat 4.0 as Release = 0
                    dwData = 0;
                }
                else
                {
                    dwError = ERROR_INVALID_DATA;
                }
            }
        }

        if (hKey != NULL)
        {
            ::RegCloseKey(hKey);
        }

        return ((ERROR_SUCCESS == dwError) && (dwData >= dwMinimumRelease));
    }
    ```

- You can change the path of the executable (Setup.exe in the example) in the `Launch` method to point to its correct location, or customize the code to determine the location. The `MmioChainer` base class provides a blocking `Run()` method that the derived class calls.

    ```cpp
    bool Launch(const CString& args)
    {
    CString cmdline = L"dotNetFx45_Full_x86_x64.exe -pipe TheSectionName " + args; // Customize with name and location of setup .exe that you want to run
    STARTUPINFO si = {0};
    si.cb = sizeof(si);
    PROCESS_INFORMATION pi = {0};

    // Launch the Setup.exe that installs the .NET Framework 4.5
    BOOL bLaunchedSetup = ::CreateProcess(NULL,
     cmdline.GetBuffer(),
     NULL, NULL, FALSE, 0, NULL, NULL,
     &si,
     &pi);

    // If successful
    if (bLaunchedSetup != 0)
    {
    IProgressObserver& observer = dynamic_cast<IProgressObserver&>(*this);
    Run(pi.hProcess, observer);

    ……………………..
    return (bLaunchedSetup != 0);
    }
    ```

- The `Send` method intercepts and processes the messages. In this version of the .NET Framework, the only supported message is the close application message.

    ```cpp
            // SendMessage
            //
            // Send a message and wait for the response.
            // dwMessage: Message to send
            // pData: The buffer to copy the data to
            // dwDataLength: Initially a pointer to the size of pBuffer. Upon successful call, the number of bytes copied to pBuffer.
            //--------------------------------------------------------------
        virtual DWORD Send(DWORD dwMessage, LPVOID pData, DWORD dwDataLength)
        {
            DWORD dwResult = 0;
            printf("received message: %d\n", dwMessage);
            // Handle message
            switch (dwMessage)
            {
            case MMIO_CLOSE_APPS:
                {
                    printf("    applications are holding files in use:\n");
                    IronMan::MmioCloseApplications* applications = reinterpret_cast<IronMan::MmioCloseApplications*>(pData);
                    for(DWORD i = 0; i < applications->m_dwApplicationsSize; i++)
                    {
                        printf("      %ls (%d)\n", applications->m_applications[i].m_szName, applications->m_applications[i].m_dwPid);
                    }

                    printf("    should appliations be closed? (Y)es, (N)o, (R)efresh : ");
                    while (dwResult == 0)
                    {
                        switch (toupper(getwchar()))
                        {
                        case 'Y':
                            dwResult = IDYES;  // Close apps
                            break;
                        case 'N':
                            dwResult = IDNO;
                            break;
                        case 'R':
                            dwResult = IDRETRY;
                            break;
                        }
                    }
                    printf("\n");
                    break;
                }
            default:
                break;
            }
            printf("  response: %d\n  ", dwResult);
            return dwResult;
        }
    };
    ```

- Progress data is an unsigned `char` between 0 (0%) and 255 (100%).

    ```cpp
    private: // IProgressObserver
        virtual void OnProgress(unsigned char ubProgressSoFar)
        {…………
       }
    ```

- The HRESULT is passed to the `Finished` method.

    ```cpp
    virtual void Finished(HRESULT hr)
    {
    // This HRESULT is communicated over MMIO and may be different than process
    // Exit code of the Chainee Setup.exe itself
    printf("\r\nFinished HRESULT: 0x%08X\r\n", hr);
    }
    ```

    > [!IMPORTANT]
    > The .NET Framework 4.5 redistributable typically writes many progress messages and a single message that indicates completion (on the chainer side). It also reads asynchronously, looking for `Abort` records. If it receives an `Abort` record, it cancels the installation, and writes a finished record with E_ABORT as its data after the installation has been aborted and setup operations have been rolled back.

A typical server creates a random MMIO file name, creates the file (as shown in the previous code example, in `Server::CreateSection`), and launches the redistributable by using the `CreateProcess` method and passing the pipe name with the `-pipe someFileSectionName` option. The server should implement `OnProgress`, `Send`, and `Finished` methods with application UI-specific code.

## See also

- [Deployment Guide for Developers](deployment-guide-for-developers.md)
- [Deployment](index.md)
