### No longer able to set EnableViewStateMac to false

#### Details

ASP.NET no longer allows developers to specify `<pages enableViewStateMac=&quot;false&quot;/>` or `<@Page EnableViewStateMac=&quot;false&quot; %>`. The view state message authentication code (MAC) is now enforced for all requests with embedded view state. Only apps that explicitly set the EnableViewStateMac property to `false` are affected.

#### Suggestion

EnableViewStateMac must be assumed to be true, and any resulting MAC errors must be resolved (as explained in [this guidance](https://support.microsoft.com/kb/2915218), which contains multiple resolutions depending on the specifics of what is causing MAC errors).

| Name    | Value   |
| :------ | :------ |
| Scope   | Major   |
| Version | 4.5.2   |
| Type    | Runtime |

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
