---
ms.topic: include
ms.date: 04/25/2025
---

Brokered authentication collects user credentials using the system authentication broker to authenticate an app. A system authentication broker is an app running on a user's machine that manages the authentication handshakes and token maintenance for all connected accounts.

Brokered authentication offers the following benefits:

- **Enables Single Sign-On (SSO):** Enables apps to simplify how users authenticate with Microsoft Entra ID and protects Microsoft Entra ID refresh tokens from exfiltration and misuse.
- **Enhanced security:** Many security enhancements are delivered with the broker, without needing to update the app logic.
- **Enhanced feature support:** With the help of the broker, developers can access rich OS and service capabilities.
- **System integration:** Applications that use the broker plug-and-play with the built-in account picker, allowing the user to quickly pick an existing account instead of re-entering the same credentials over and over.
- **Token Protection:** Ensures that the refresh tokens are device bound and enables apps to acquire device bound access tokens. For more information, see [Token Protection](/azure/active-directory/conditional-access/concept-token-protection).
