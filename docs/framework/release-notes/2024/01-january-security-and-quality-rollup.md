## January 2024 Security and Quality Rollup

_Released January 9, 2024_

### Summary of What's New in this Release

#### Security improvements

##### CVE-2023-36042 – .NET Framework Denial of Service Vulnerability

This security update addresses a security feature bypass vulnerability detailed in [CVE 2023-36042](https://portal.msrc.microsoft.com/en-US/security-guidance/advisory/CVE-2023-36042).

##### CVE-2024-0056 – .NET Framework Security Feature Bypass Vulnerability

Microsoft is releasing this security advisory to provide information about a vulnerability in .NET's System.Data.SqlClient and Microsoft.Data.SqlClient NuGet Packages. This advisory also provides guidance on what developers can do to update their applications to address this vulnerability. A vulnerability exists in the Microsoft.Data.SqlClient and System.Data.SqlClient SQL Data provider where an attacker can perform an AiTM (adversary-in-the-middle) attack between the SQL client and the SQL server. This may allow the attacker to steal authentication credentials intended for the database server, even if the connection is established over an encrypted channel like TLS. This security update addresses a security feature bypass vulnerability detailed in [CVE 2024-0056](https://portal.msrc.microsoft.com/en-US/security-guidance/advisory/CVE-2024-0056).

##### CVE-2024-0057 – .NET Framework Security Feature Vulnerability

Microsoft is releasing this security advisory to provide information about a vulnerability in .NET 6.0, .NET 7.0 and .NET 8.0 . This advisory also provides guidance on what developers can do to update their applications to address this vulnerability. A security feature bypass vulnerability exists when Microsoft .NET Framework-based applications use X.509 chain building APIs but do not completely validate the X.509 certificate due to a logic flaw. An attacker could present an arbitrary untrusted certificate with malformed signatures, triggering a bug in the framework. The framework will correctly report that X.509 chain building failed, but it will return an incorrect reason code for the failure. Applications which utilize this reason code to make their own chain building trust decisions may inadvertently treat this scenario as a successful chain build. This could allow an adversary to subvert the app's typical authentication logic. This security update addresses an elevation of privilege vulnerability detailed in [CVE 2024-0057](https://portal.msrc.microsoft.com/en-US/security-guidance/advisory/CVE-2024-0057).

##### CVE-2024-21312 – .NET Framework Denial of Service Vulnerability

This security update addresses a denial of service vulnerability detailed in [CVE 2024-21312](https://portal.msrc.microsoft.com/en-US/security-guidance/advisory/CVE-2024-21312).

##### .NET Framework Remote Code Execution Vulnerability

This security update addresses a remote code execution vulnerability to HTTP .NET remoting server channel chain.

#### Quality and Reliability

There are no new Quality and Reliability Improvements in this update.

### Known Issues in this Release

This release contains no known issues. The following table is for Windows 10 and Windows Server 2016+ versions.

| Product Version | Cumulative Update |     |
| --- | --- |
| **Microsoft server operating system, version 23H2** |
| .NET Framework 3.5, 4.8.1 | [5033917](https://support.microsoft.com/kb/5033917) |
| **Windows 11, version 22H2 and Windows 11, version 23H2** |
| .NET Framework 3.5, 4.8.1 | [5033920](https://support.microsoft.com/kb/5033920) |
| **Windows 11, version 21H2** | **[5034276](https://support.microsoft.com/kb/5034276)** |
| .NET Framework 3.5, 4.8 | [5033912](https://support.microsoft.com/kb/5033912) |
| .NET Framework 3.5, 4.8.1 | [5033919](https://support.microsoft.com/kb/5033919) |
| **Microsoft server operating system, version 22H2** | **[5034272](https://support.microsoft.com/kb/5034272)** |
| .NET Framework 3.5, 4.8 | [5033914](https://support.microsoft.com/kb/5033914) |
| .NET Framework 3.5, 4.8.1 | [5033922](https://support.microsoft.com/kb/5033922) |
| **Microsoft server operating system version 21H2** | **[5034272](https://support.microsoft.com/kb/5034272)** |
| .NET Framework 3.5, 4.8 | [5033914](https://support.microsoft.com/kb/5033914) |
| .NET Framework 3.5, 4.8.1 | [5033922](https://support.microsoft.com/kb/5033922) |
| **Windows 10, version 22H2** | **[5034275](https://support.microsoft.com/kb/5034275)** |
| .NET Framework 3.5, 4.8 | [5033909](https://support.microsoft.com/kb/5033909) |
| .NET Framework 3.5, 4.8.1 | [5033918](https://support.microsoft.com/kb/5033918) |
| **Windows 10, version 21H2** | **[5034274](https://support.microsoft.com/kb/5034274)** |
| .NET Framework 3.5, 4.8 | [5033909](https://support.microsoft.com/kb/5033909) |
| .NET Framework 3.5, 4.8.1 | [5033918](https://support.microsoft.com/kb/5033918) |
| **Windows 10 1809 and Windows Server 2019** | **[5034273](https://support.microsoft.com/kb/5034273)** |
| .NET Framework 3.5, 4.7.2 | [5033904](https://support.microsoft.com/kb/5033904) |
| .NET Framework 3.5, 4.8 | [5033911](https://support.microsoft.com/kb/5033911) |
| **Windows 10 1607 and Windows Server 2016** |
| .NET Framework 3.5, 4.6.2, 4.7, 4.7.1, 4.7.2 | [5034119](https://support.microsoft.com/kb/5034119) |
| .NET Framework 4.8 | [5033910](https://support.microsoft.com/kb/5033910) |
| **Windows 10 1507** |
| .NET Framework 3.5, 4.6, 4.6.2 | [5034134](https://support.microsoft.com/kb/5034134) |

The following tables are for earlier Windows and Windows Server versions for Security and Quality Rollup updates.  

| Product Version | Security and Quality Rollup |     |
| --- | --- |
| **Windows Server 2012 R2** | **[5034279](https://support.microsoft.com/kb/5034279)** |
| .NET Framework 3.5 | [5033900](https://support.microsoft.com/kb/5033900) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5033906](https://support.microsoft.com/kb/5033906) |
| .NET Framework 4.8 | [5033915](https://support.microsoft.com/kb/5033915) |
| **Windows Server 2012** | **[5034278](https://support.microsoft.com/kb/5034278)** |
| .NET Framework 3.5 | [5033897](https://support.microsoft.com/kb/5033897) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5033905](https://support.microsoft.com/kb/5033905) |
| .NET Framework 4.8 | [5033913](https://support.microsoft.com/kb/5033913) |
| **Windows Server 2008 R2** | **[5034277](https://support.microsoft.com/kb/5034277)** |
| .NET Framework 3.5.1 | [5033899](https://support.microsoft.com/kb/5033899) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5033907](https://support.microsoft.com/kb/5033907) |
| .NET Framework 4.8 |
| **Windows Server 2008** | **[5034280](https://support.microsoft.com/kb/5034280)** |
| .NET Framework 2.0, 3.0 |
| .NET Framework 3.5 | [5034008](https://support.microsoft.com/kb/5034008) |
| .NET Framework 4.6.2 | [5033907](https://support.microsoft.com/kb/5033907) |

The following tables are for earlier Windows and Windows Server versions for Security Only updates which are not cumulative

| Product Version | Security Only Update |     |
| --- | --- |
| **Windows Server 2012 R2** | **[5034279](https://support.microsoft.com/kb/5034279)** |
| .NET Framework 3.5 | [5033900](https://support.microsoft.com/kb/5033900) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5033906](https://support.microsoft.com/kb/5033906) |
| .NET Framework 4.8 | [5033915](https://support.microsoft.com/kb/5033915) |
| **Windows Server 2012** | **[5034278](https://support.microsoft.com/kb/5034278)** |
| .NET Framework 3.5 | [5033897](https://support.microsoft.com/kb/5033897) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5033905](https://support.microsoft.com/kb/5033905) |
| .NET Framework 4.8 | [5033913](https://support.microsoft.com/kb/5033913) |
| **Windows Server 2008 R2** | **[5034269](https://support.microsoft.com/kb/5034269)** |
| .NET Framework 3.5.1 | [5033946](https://support.microsoft.com/kb/5033946) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5033947](https://support.microsoft.com/kb/5033947) |
| .NET Framework 4.8 | [5033948](https://support.microsoft.com/kb/5033948) |
| **Windows Server 2008** | **[5034280](https://support.microsoft.com/kb/5034280)** |
| .NET Framework 2.0, 3.0 | [5033945](https://support.microsoft.com/kb/5033945) |
| .NET Framework 3.5 | [5033952](https://support.microsoft.com/kb/5033952) |
| .NET Framework 4.6.2 | [5033947](https://support.microsoft.com/kb/5033947) |