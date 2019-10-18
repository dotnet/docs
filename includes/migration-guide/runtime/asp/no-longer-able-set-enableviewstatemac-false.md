### No longer able to set EnableViewStateMac to false

|   |   |
|---|---|
|Details|ASP.NET no longer allows developers to specify <code>&lt;pages enableViewStateMac=&quot;false&quot;/&gt;</code> or <code>&lt;@Page EnableViewStateMac=&quot;false&quot; %&gt;</code>. The view state message authentication code (MAC) is now enforced for all requests with embedded view state. Only apps that explicitly set the EnableViewStateMac property to <code>false</code> are affected.|
|Suggestion|EnableViewStateMac must be assumed to be true, and any resulting MAC errors must be resolved (as explained in [this guidance](https://support.microsoft.com/kb/2915218), which contains multiple resolutions depending on the specifics of what is causing MAC errors).|
|Scope|Major|
|Version|4.5.2|
|Type|Runtime|
