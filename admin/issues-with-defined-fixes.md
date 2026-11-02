---
title: Issues with clearly defined fixes
ai-usage: ai-generated
---

# Issues with clearly defined fixes

Recommend the following fourteen issues as GitHub Copilot (GHCP) assignment candidates because each has a specific remaining documentation gap, identified target files, and a bounded resolution. Track two additional defined fixes separately because implementation PRs are already open. No assignments or other GitHub changes have been made. Entries within each category follow issue creation time, not implementation priority.

## Review coverage

- **Repository and snapshot:** `dotnet/docs`, November 2, 2026; 848 open issues, excluding pull requests.
- **Completed batches:** The 75 oldest open issues, from [dotnet/docs#2608](https://github.com/dotnet/docs/issues/2608), opened July 12, 2017, through [dotnet/docs#23582](https://github.com/dotnet/docs/issues/23582), opened April 1, 2021.
- **Results:** 16 defined fixes (14 assignment candidates and 2 already in open PRs) and 13 [closure candidates](issues-to-close.md#closure-candidates).
- **Latest batch:** Issues 51-75 add 8 new assignment candidates, alongside 6 closure candidates.
- **Remaining:** 773 issues from this snapshot are unreviewed. Resume with [dotnet/docs#23596](https://github.com/dotnet/docs/issues/23596), opened April 2, 2021.
- **Evidence baseline:** Issue bodies, complete comment threads, current target documentation, candidate cross-reference timelines, open-PR checks, and the patches of the two active implementation PRs. Local source matched upstream `main` at `81cd030da804aa06cfbd8f23474cbbacba597c72`. Candidate issues were open when checked; existing ownership is noted where relevant.

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

### dotnet/docs#20945: Add a fundamental coding components overview

**Issue:** [dotnet/docs#20945](https://github.com/dotnet/docs/issues/20945). **Opened:** October 6, 2020. **Size:** Small. **GHCP suitability:** Strong for a navigation overview, not a consolidation project.

**Why it still applies:** The [Fundamental coding components TOC node](../docs/fundamentals/toc.yml) has child topics but no introductory page for the section itself. Existing pages such as the [common type system](../docs/standard/base-types/common-type-system.md) explain individual areas rather than provide the language-guide and shared-topic map requested in the issue.

**Why the solution is defined:** The issue supplies an explicit content list and distinguishes links into language guides from links to common .NET guidance. Its reference to eventual consolidation doesn't require an agent to move or merge all that content now.

**Proposed assignment scope:**

- Add a concise overview article under `docs/fundamentals` and an **Overview** entry under **Fundamental coding components** in `docs/fundamentals/toc.yml`.
- Briefly introduce namespaces, types, extension methods, classes, structs, interfaces, and enums, with links to the relevant language guides. Use existing C#, Visual Basic, and F# destinations where the concept applies; don't present C# syntax as a universal .NET language rule.
- Link to existing shared guidance for lambdas, delegates, events, attributes, and exceptions.
- Keep the page a conceptual orientation and navigation aid. Don't migrate language-guide content, alter its URLs, or create redundant code samples.
- Follow the repository's new-page metadata and TOC requirements.

**Acceptance criteria:** All twelve topic groups from the issue appear with an appropriate existing destination. The overview is reachable from the section's current TOC, language distinctions remain accurate, and no existing article is moved or removed. Check links and the documentation build rather than introduce new snippet projects for a prose-only overview.

### dotnet/docs#22058: Add a resilience-testing signpost

**Issue:** [dotnet/docs#22058](https://github.com/dotnet/docs/issues/22058). **Opened:** December 17, 2020. **Size:** Small. **GHCP suitability:** Strong for a short explanation and cross-link.

**Why it still applies:** The [microservices resilience introduction](../docs/architecture/microservices/implement-resilient-applications/index.md) describes partial failures and resilience strategies but doesn't explain how to exercise those strategies through controlled failures.

**Why the solution is defined:** The related cloud-native guide already contains a [resilience-testing section](../docs/architecture/cloud-native/application-resiliency-patterns.md#testing-for-resiliency) that describes end-to-end failure tests, process crashes, unavailable dependencies, and Chaos Monkey. The requested concept can be introduced and linked without selecting or implementing a new fault-injection platform.

**Proposed assignment scope:**

- Add a short paragraph or subsection to `docs/architecture/microservices/implement-resilient-applications/index.md` about deliberate, controlled resilience tests.
- Explain the difference between functional tests and end-to-end behavior under dependency or process failures. Link to the existing cloud-native resilience-testing section.
- State that tests should use a controlled environment and explicit safeguards. Don't tell readers to terminate arbitrary production processes.
- Keep this an explanation and discovery improvement. Don't add Chaos Monkey installation instructions, production experiments, cloud resources, or an application rewrite.

**Acceptance criteria:** Readers of the original section can find the existing chaos-testing guidance and understand why resilience needs failure testing. The link resolves, and the change doesn't imply the historical eShop sample already includes a fault-injection harness.

### dotnet/docs#22373: Correct Source Link version-property guidance

**Issue:** [dotnet/docs#22373](https://github.com/dotnet/docs/issues/22373). **Opened:** January 15, 2021. **Size:** Small. **GHCP suitability:** Strong, with SDK property-evaluation evidence.

**Why it still applies:** The [informational-version section](../docs/standard/library-guidance/versioning.md#assembly-informational-version) still says Source Link sets the informational version from the NuGet package version and advises readers not to set it themselves. That wording conflates `PackageVersion` with the base version used for `InformationalVersion`.

**Why the solution is defined:** The current [assembly-attribute guide](../docs/standard/assembly/set-attributes-project-file.md#use-package-properties-as-assembly-attributes) already explains that `InformationalVersion` defaults to `Version` and that source revision metadata is appended separately. The correction can align the library guidance with those documented SDK semantics.

**Proposed assignment scope:** Correct the property relationship, explain revision suffix generation separately, and link to the assembly-attribute guide. Explain the effect of setting `PackageVersion` independently instead of promising that it controls the assembly attribute. Don't mechanically replace the current advice with a universal requirement to copy `PackageVersion` into `InformationalVersion`.

**Acceptance criteria:** With a current stable SDK and a small source-controlled class library, compare builds that set only `PackageVersion`, set `Version`, and explicitly set `InformationalVersion`. Record evaluated properties and the emitted assembly informational version, including revision behavior. The revised explanation matches those results without changing unrelated assembly-version compatibility guidance.

### dotnet/docs#22857: Remove APM callback thread guarantees

**Issue:** [dotnet/docs#22857](https://github.com/dotnet/docs/issues/22857). **Opened:** February 16, 2021. **Size:** Small. **GHCP suitability:** Strong for a bounded conceptual-documentation correction.

**Why it still applies:** Both [the callback guide](../docs/standard/asynchronous-programming-patterns/using-an-asynccallback-delegate-to-end-an-asynchronous-operation.md) and [the state-object guide](../docs/standard/asynchronous-programming-patterns/using-an-asynccallback-delegate-and-state-object.md) still promise processing on a separate thread. The [APM overview](../docs/standard/asynchronous-programming-patterns/asynchronous-programming-model-apm.md) also describes execution and `CompletedSynchronously` in terms of particular threads.

**Why the solution is defined:** The [API-owner discussion](https://github.com/dotnet/dotnet-api-docs/pull/4640#issuecomment-690732459) explicitly says callbacks can run synchronously and requests the conceptual-doc review. The issue isn't asking an agent to invent new callback scheduling behavior.

**Proposed assignment scope:** Correct those three articles and check adjacent APM callback explanations for the same unconditional guarantee. Explain synchronous completion and callback reentrancy before the initiating call returns. Preserve the requirement to pair Begin/End operations correctly, and don't promise a specific thread for asynchronous completion either. Keep the task within conceptual docs; the separately owned API-reference page isn't a file in this repository.

**Acceptance criteria:** No reviewed APM callback explanation guarantees a separate thread. `CompletedSynchronously` describes synchronous completion rather than a universal thread identity test. Preserve existing examples unless a correction is necessary; if an example is added or changed, demonstrate both synchronous and asynchronous callback paths and record their actual ordering.

### dotnet/docs#23068: Show plugin publication to a chosen directory

**Issue:** [dotnet/docs#23068](https://github.com/dotnet/docs/issues/23068). **Opened:** March 2, 2021. **Size:** Small. **GHCP suitability:** Strong, with an end-to-end plugin-load check.

**Why it still applies:** The [plugin tutorial](../docs/core/tutorials/creating-app-with-plugin-support.md) now mentions that `dotnet publish` copies class-library dependencies, but still directs the loader to the plugin's Debug build directory. It doesn't show the requested publish-to-plugin-directory workflow. The [maintainer reply](https://github.com/dotnet/docs/issues/23068#issuecomment-791733665) agrees that this scenario belongs in the tutorial.

**Why the solution is defined:** Class-library publication produces assemblies and dependencies; it isn't restricted to NuGet package creation. The existing tutorial already explains `EnableDynamicLoading` and exclusion of the shared plugin-contract assembly.

**Proposed assignment scope:** Add a short CLI workflow that publishes one existing plugin with an explicit output directory, points the existing loader to its published DLL, and distinguishes publication from `dotnet pack`. Keep the dependency directory intact and preserve the shared-contract exclusion. Don't introduce a plugin installer, hot reload, or a new packaging format.

**Acceptance criteria:** Publish and load both the simple plugin and a plugin with dependencies using the documented directory convention. Record the commands, published artifacts, and actual command output. The host resolves the published plugin without loading a second copy of the interface assembly, and the text doesn't depend on a particular Visual Studio publish dialog.

### dotnet/docs#23070: Link trace collection to event instrumentation

**Issue:** [dotnet/docs#23070](https://github.com/dotnet/docs/issues/23070). **Opened:** March 2, 2021. **Size:** Very small. **GHCP suitability:** Strong, subject to coordination with current assignee `tommcdon`.

**Why it still applies:** The [dotnet-trace reference](../docs/core/diagnostics/dotnet-trace.md) describes provider selection and collection but doesn't link to guidance that teaches developers to emit their own events. Its See also section only lists well-known providers.

**Why the solution is defined:** The [EventSource getting-started tutorial](../docs/core/diagnostics/eventsource-getting-started.md) and [instrumentation guide](../docs/core/diagnostics/eventsource-instrumentation.md) already teach event production, and the [collection tutorial](../docs/core/diagnostics/eventsource-collect-and-view-traces.md) connects those events to tracing tools.

**Proposed assignment scope:** Add a short signpost near provider selection and a relevant See also link. Distinguish application/library instrumentation from enabling an existing runtime provider. Reuse the current tutorials rather than duplicate their code or add a new tracing API.

**Acceptance criteria:** Readers can navigate directly from `dotnet-trace` to a custom-event example and its collection instructions. Links resolve, existing tool options remain unchanged, and the owner agrees before an existing assignment is replaced or duplicated.

### dotnet/docs#23325: Explain the diagnostic impact of EventSourceSupport

**Issue:** [dotnet/docs#23325](https://github.com/dotnet/docs/issues/23325). **Opened:** March 15, 2021. **Size:** Small. **GHCP suitability:** Strong for a focused limitation and troubleshooting note.

**Why it still applies:** The [trimming options table](../docs/core/deploying/trimming/trimming-options.md#trim-framework-library-features) already says that `EventSourceSupport=false` removes EventSource code. However, the [dotnet-trace guide](../docs/core/diagnostics/dotnet-trace.md) doesn't explain that an application's publish-time removal of EventSource support can account for missing application-provider events.

**Why the solution is defined:** The [runtime-team explanation](https://github.com/dotnet/runtime/issues/43657#issuecomment-791759620) identifies the affected EventSource providers and the desired diagnostic guidance. Completion of runtime tooling work doesn't by itself add that explanation to these guides.

**Proposed assignment scope:** Add a concise diagnostic limitation to the trimming option and a linked troubleshooting note in the collection guide. Explain that selecting or enabling a provider can't restore instrumentation removed at publication time. Limit the claim to EventSource-dependent events; don't assert that every native runtime event, ETW session, or tool necessarily stops working.

**Acceptance criteria:** Compare a small app published with EventSource support enabled and disabled, then collect its custom provider events with the same tool settings. Record the actual SDK/runtime/tool versions and observed results. Don't invent a guaranteed warning message or broadly equate this switch with disabling every diagnostics facility.

### dotnet/docs#23439: Escape pipe characters in an analyzer-options table

**Issue:** [dotnet/docs#23439](https://github.com/dotnet/docs/issues/23439). **Opened:** March 22, 2021. **Size:** Very small. **GHCP suitability:** Strong; mechanical formatting correction.

**Why it still applies:** In [code-quality rule options](../docs/fundamentals/code-analysis/code-quality-rule-options.md#unsafe_dllimportsearchpath_bits), the default value for `unsafe_DllImportSearchPath_bits` contains two unescaped pipes inside an inline-code expression. Those pipes turn a four-column row into six cells under GitHub-flavored Markdown. An `MD056` suppression surrounds this exact table instead of fixing its structure.

**Proposed assignment scope:** Escape the two literal pipes using the same `\|` convention already used elsewhere in the article. Remove the now-unnecessary suppression around this table. Preserve the default numeric value, enum names, links, and analyzer semantics.

**Acceptance criteria:** The header and data row each have four cells, the full flag expression stays in the Default value cell, and both GitHub and Learn display the intended expression. Don't suppress a new table warning or change the value `770`.

### dotnet/docs#23475: Distinguish class and interface COM identifiers

**Issue:** [dotnet/docs#23475](https://github.com/dotnet/docs/issues/23475). **Opened:** March 24, 2021. **Size:** Very small. **GHCP suitability:** Strong; pair with dotnet/docs#23476 in one assignment.

**Why it still applies:** Step 8 of [Create the library](../docs/core/native-interop/expose-components-to-com.md#create-the-library) still calls the class GUID the identifier of an interface. The surrounding instructions don't explicitly say that the class identifier and interface identifier are different GUIDs.

**Proposed assignment scope:** Change the incorrect noun to class and clarify that the CLSID identifies the coclass, whereas the IID identifies the interface. State that the two identifiers must differ. Retain the existing distinct example GUIDs; no runtime or sample implementation change is necessary.

**Acceptance criteria:** Steps 5 and 8 consistently distinguish IID and CLSID without implying that one GUID should be reused for both. Make this correction together with the adjacent activation-note correction below rather than create competing edits to the same section.

### dotnet/docs#23476: Clarify the explicit CLSID requirement for COM hosting

**Issue:** [dotnet/docs#23476](https://github.com/dotnet/docs/issues/23476). **Opened:** March 24, 2021. **Size:** Very small. **GHCP suitability:** Strong; combine with dotnet/docs#23475.

**Why it still applies:** The important note after [Create the library](../docs/core/native-interop/expose-components-to-com.md#create-the-library) still says only that .NET Core requires a CLSID, without explaining how that differs from .NET Framework's behavior.

**Why the solution is defined:** The [interop-owner answer](https://github.com/dotnet/docs/issues/23476#issuecomment-816067931) specifies both `ComVisible(true)` and an explicit `Guid` for activation. The [follow-up qualification](https://github.com/dotnet/docs/issues/23476#issuecomment-816747425) warns that automatic GUID generation can still occur for objects that pass through the marshaling layer.

**Proposed assignment scope:** Explain the explicit class `Guid` requirement for activation through the generated COM host and contrast that requirement with .NET Framework's ability to supply an automatically generated identifier. Keep visibility and identity separate. Don't claim that modern .NET never generates GUIDs for any COM interop scenario.

**Acceptance criteria:** The note explains the role of both attributes and scopes the difference to COM-host activation. Preserve the separate marshaling case and existing code. Obtain interop-owner review of the wording; no new COM sample is needed.

## Defined fixes already in progress

These issues still need their existing PRs to land. They aren't closure-without-action candidates and shouldn't receive duplicate implementation assignments.

### dotnet/docs#22074: Document the none API-surface value

**Issue:** [dotnet/docs#22074](https://github.com/dotnet/docs/issues/22074). **Opened:** December 17, 2020. **Status:** Covered by open, non-draft [dotnet/docs#56622](https://github.com/dotnet/docs/pull/56622).

**Why the solution is defined:** The [analyzer-owner reply](https://github.com/dotnet/docs/issues/22074#issuecomment-747846299) confirms `none` as an API-surface value. The current [options table](../docs/fundamentals/code-analysis/code-quality-rule-options.md#api_surface) omits it. The PR's actual patch adds `none` with the description that it applies to no APIs in exactly that table.

**Maintainer next action:** Review the existing PR rather than assign a second implementation. Confirm the wording and configuration scope against the supported analyzer versions; don't generalize the effect beyond rules that use `api_surface`. Close through the existing PR after merge, not before.

### dotnet/docs#22105: Remove the obsolete dotnet MyGet feed

**Issue:** [dotnet/docs#22105](https://github.com/dotnet/docs/issues/22105). **Opened:** December 21, 2020. **Status:** Covered by open, non-draft [dotnet/docs#56623](https://github.com/dotnet/docs/pull/56623).

**Why the solution is defined:** No MyGet references were found in the current sample files searched, but the [dotnet package add examples](../docs/core/tools/dotnet-package-add.md#examples) still contain `https://dotnet.myget.org/F/dotnet-core/api/v3/index.json`. The PR's actual patch replaces that obsolete .NET feed with `https://api.nuget.org/v3/index.json` in the same example.

**Scope distinction:** Other library-guidance articles mention MyGet as a third-party hosting service. Those generic service references aren't equivalent to the decommissioned Microsoft feed and don't justify a blanket deletion of every occurrence of the service name.

**Maintainer next action:** Review the existing one-line correction and confirm that the obsolete feed doesn't remain in sample/configuration files before closure. Don't open another PR or close the issue while the correction is still unmerged.

## Assignment order

For the quickest independent changes, start with the table escaping, the paired COM wording corrections, or the existing prose-only signposts. Coordinate the instrumentation link with its current owner. Treat the two COM issues as one assignment, and use the existing hosted-service issue rather than duplicate work for dotnet/docs#23440.

The coding-components overview needs new-page review. Source Link, plugin publication, and the trimming limitation need focused execution evidence. The linker correction requires the .NET Framework toolchain, and the PEVerify clarification needs compiler-owner review.

Review the two existing implementation PRs separately from new assignments. Issues that don't fit either candidate category are omitted for a future task.
