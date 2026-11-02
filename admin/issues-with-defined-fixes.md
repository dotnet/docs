---
title: Issues with clearly defined fixes
ai-usage: ai-generated
---

# Issues with clearly defined fixes

Recommend the following issues as GitHub Copilot (GHCP) assignment candidates because each has a specific remaining documentation gap, identified target files, and a bounded resolution. No assignments or other GitHub changes have been made. Entries follow issue creation time, not implementation priority.

## Review coverage

- **Repository and snapshot:** `dotnet/docs`, November 2, 2026; 848 open issues, excluding pull requests.
- **Completed batch:** The 25 oldest open issues, from [dotnet/docs#2608](https://github.com/dotnet/docs/issues/2608), opened July 12, 2017, through [dotnet/docs#20038](https://github.com/dotnet/docs/issues/20038), opened August 13, 2020.
- **Results:** 4 defined-fix candidates, 3 [closure candidates](issues-to-close.md#closure-candidates), and 18 [issues held for further triage](issues-to-close.md#reviewed-issues-held-for-further-triage).
- **Remaining:** 823 issues from this snapshot are unreviewed. Resume with [dotnet/docs#20142](https://github.com/dotnet/docs/issues/20142), opened August 17, 2020.
- **Evidence baseline:** Issue bodies, complete comment threads, current target documentation, and candidate cross-reference timelines. Local source matched upstream `main` at `81cd030da804aa06cfbd8f23474cbbacba597c72`. Each candidate remained open and unassigned when rechecked.

These are proposed assignment briefs, not claims that fixes have been implemented or that sample commands have been executed. Recheck issue state, ownership, and related pull requests before assignment. Existing `Needs Research` labels weren't changed; the evidence below explains the proposed narrower scope. An old request with unresolved technical behavior isn't assignment-ready merely because an agent could research it.

## Defined-fix candidates

### dotnet/docs#19413: Explain PEVerify limitations with newer C# constructs

**Issue:** [dotnet/docs#19413](https://github.com/dotnet/docs/issues/19413). **Opened:** July 10, 2020. **Size:** Small. **GHCP suitability:** Suitable for a narrowly scoped documentation clarification, with compiler-owner review.

**Why it still applies:** The [PEVerify reference](../docs/framework/tools/peverify-exe-peverify-tool.md) discusses verification and type safety but doesn't explain the reported interaction with constructs such as `readonly struct` and `in` parameters. The issue includes an explicit [maintainer direction](https://github.com/dotnet/docs/issues/19413#issuecomment-657576921) to place guidance in the .NET Framework documentation and cross-reference language/framework compatibility.

**Why the solution is defined:** A [compiler-team explanation in dotnet/roslyn#27382](https://github.com/dotnet/roslyn/issues/27382#issuecomment-394542424) establishes that newer constructs can produce IL that legacy PEVerify implementations reject, and that verifier implementations differ. The issue isn't asking the agent to fix the compiler or invent a new workaround.

**Proposed assignment scope:**

- Add a short limitation/troubleshooting section to `docs/framework/tools/peverify-exe-peverify-tool.md`. Explain that some newer C# constructs can fail legacy PEVerify checks, particularly in .NET Framework scenarios that require verification. Don't imply every use of a `readonly struct` fails, or that unverifiable IL necessarily indicates an invalid modern .NET application.
- Cross-link the explanation from the existing C# language-version/framework guidance, using `docs/csharp/language-reference/configure-language-version.md` or its linked compatibility guidance as appropriate.
- Explain the distinction between language-version support and IL verification. Don't recommend upgrading .NET Framework projects to unsupported language versions.
- Keep any `peverify-compat` discussion explicitly limited to behavior verified against the relevant compiler version. The core clarification doesn't depend on recommending that feature flag as a supported, universal fix.

**Acceptance criteria:** Both guides lead the reader to the limitation, and the wording matches the compiler-team explanation. Don't change existing samples or partial-trust policy. If the eventual change adds a workaround command or code example, reproduce its before/after verification behavior with the applicable .NET Framework toolchain and include the actual results in the implementation PR. Obtain compiler-owner review of technical claims.

### dotnet/docs#19712: Add Blazor WebAssembly security guidance

**Issue:** [dotnet/docs#19712](https://github.com/dotnet/docs/issues/19712). **Opened:** July 27, 2020. **Size:** Small. **GHCP suitability:** Strong; use existing authoritative guidance rather than create a new authentication implementation.

**Why it still applies:** The [Web Forms-to-Blazor security chapter](../docs/architecture/blazor-for-web-forms-developers/security-authentication-authorization.md) includes only a brief note about server APIs for WebAssembly role/user operations. It doesn't explain OpenID Connect or link to the WebAssembly security documentation requested by the issue.

**Why the solution is defined:** The issue explicitly requests OpenID Connect coverage, secure web API calls, and a link to the [existing WebAssembly security guidance](https://learn.microsoft.com/aspnet/core/blazor/security/webassembly/). That live guide now directly explains the SPA/OIDC model and web API requests.

**Proposed assignment scope:**

- Add a short Blazor WebAssembly subsection to `docs/architecture/blazor-for-web-forms-developers/security-authentication-authorization.md`.
- Explain that client-side WebAssembly security follows the SPA model, and introduce OIDC-based user authentication with links to the authoritative ASP.NET Core guidance.
- Explain that protected operations run behind server APIs with server-side authorization; client-side UI checks don't protect an endpoint or conceal secrets.
- Link to the WebAssembly security overview and its web API guidance. Keep the existing server-side Identity migration discussion distinct from the client-side approach.
- Use prose and cross-links only. Don't introduce an identity-provider-specific setup, obsolete project template, token-handling sample, or duplicate authentication tutorial.

**Acceptance criteria:** The chapter explicitly covers WebAssembly, OIDC, and protected web API calls; the requested security link resolves to current guidance. The text doesn't instruct a client app to store secrets or directly manage the server's user database. Existing server-side migration instructions remain intact.

### dotnet/docs#19827: Clarify hosted-service behavior across replicas

**Issue:** [dotnet/docs#19827](https://github.com/dotnet/docs/issues/19827). **Opened:** July 30, 2020. **Size:** Small. **GHCP suitability:** Strong; a localized explanation resolves the ambiguity without an infrastructure implementation.

**Why it still applies:** The [background-tasks article](../docs/architecture/microservices/multi-container-microservice-net-applications/background-tasks-with-ihostedservice.md) explains application-lifetime coordination and deployment, but doesn't explicitly answer whether every service replica starts its own hosted service. The original single-instance sentence has changed, yet the load-balancer question remains unanswered. A changed sentence alone doesn't justify closing the issue.

**Why the solution is defined:** The article already states that each application's host starts and stops its registered services. The missing distinction is process-local host lifecycle versus coordination across independent hosts. A load balancer doesn't provide a distributed singleton for background work.

**Proposed assignment scope:**

- Add a paragraph or note under **Deployment considerations and takeaways** in `docs/architecture/microservices/multi-container-microservice-net-applications/background-tasks-with-ihostedservice.md`.
- State that each host instance starts its own registered hosted services. Replicating the app therefore replicates its background workers, regardless of how HTTP requests are load-balanced.
- State that `IHostedService` doesn't coordinate ownership across processes. To avoid concurrent execution across replicas, choose a separate worker deployment or an appropriate shared coordination mechanism.
- Distinguish a worker deployment configured for one replica from guaranteed exactly-once execution. Don't promise that one replica prevents retries, overlap during deployment, or duplicate side effects.
- Link to existing background-worker or architecture guidance where useful. Don't add a distributed lock, scheduler, or queue sample to resolve this explanatory issue.

**Acceptance criteria:** The text directly answers the original all-instances-versus-one-instance question and identifies coordination as a separate application/deployment concern. Keep the change limited to the deployment discussion; don't modernize unrelated examples in the old architecture chapter.

### dotnet/docs#20038: Replace the native linker command with Assembly Linker

**Issue:** [dotnet/docs#20038](https://github.com/dotnet/docs/issues/20038). **Opened:** August 13, 2020. **Size:** Small. **GHCP suitability:** Strong; the issue supplies a concrete correction supported by another article in this repository.

**Why it still applies:** The [cross-language interoperability section](../docs/standard/language-independence.md#cross-language-interoperability) still links to the C++ linker options and uses `link numberutil.netmodule stringutil.netmodule /out:UtilityLib.dll /dll` to combine the managed modules.

**Why the solution is defined:** The issue supplies the Assembly Linker replacement. The [.NET Framework multifile assembly guide](../docs/framework/app-domains/build-multifile-assembly.md) explicitly uses `Al.exe` to create the assembly manifest from managed modules and states that multifile assemblies are supported only by .NET Framework.

**Proposed assignment scope:**

- In `docs/standard/language-independence.md`, replace the C++ linker reference with the existing [Assembly Linker reference](../docs/framework/tools/al-exe-assembly-linker.md).
- Replace the command with `al NumberUtil.netmodule StringUtil.netmodule /out:UtilityLib.dll /target:lib`, consistent with the previously compiled module names and the consumer commands.
- Explicitly scope this multifile assembly example to .NET Framework. Don't imply modern .NET supports the same deployment model.
- Check the surrounding output assembly names for consistency as part of this example, without a wider rewrite of the article.

**Acceptance criteria:** In an environment with the .NET Framework C# compiler, Visual Basic compiler, and Assembly Linker, compile the existing two module samples, produce `UtilityLib.dll`, and run both existing consumer examples. Record the exact commands and their actual output in the implementation PR. If the agent's environment lacks that toolchain, report the limitation instead of claiming the new command was verified. The published article no longer directs readers to the native linker for this managed-module step.

## Assignment order

For the quickest independent changes, start with the hosted-service clarification or the Blazor cross-links. The linker correction has a concrete answer but requires the .NET Framework toolchain for execution evidence. The PEVerify clarification needs compiler-owner review and is the least mechanical of the four.

Keep the 18 held issues out of an automatic assignment queue until the missing scope, behavior, or ownership information recorded in [the coverage ledger](issues-to-close.md#reviewed-issues-held-for-further-triage) is resolved.
