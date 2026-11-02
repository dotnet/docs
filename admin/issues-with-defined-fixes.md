---
title: Issues with clearly defined fixes
ai-usage: ai-generated
---

# Issues with clearly defined fixes

Recommend the following 32 issues as GitHub Copilot (GHCP) assignment candidates because each has a specific remaining documentation gap, identified target files, and a bounded resolution. Track three additional defined fixes separately because implementation PRs are already open; one of those PRs needs correction before merge. No assignments or other GitHub changes have been made. Entries within each category follow issue creation time, not implementation priority.

## Review coverage

- **Repository and snapshot:** `dotnet/docs`, November 2, 2026; 848 open issues, excluding pull requests.
- **Completed batches:** The 125 oldest open issues, from [dotnet/docs#2608](https://github.com/dotnet/docs/issues/2608), opened July 12, 2017, through [dotnet/docs#25246](https://github.com/dotnet/docs/issues/25246), opened July 20, 2021.
- **Results:** 35 defined fixes (32 assignment candidates and 3 with open implementation PRs) and 25 [closure candidates](issues-to-close.md#closure-candidates).
- **Latest batch:** Issues 101-125 add 10 new assignment candidates, alongside 6 closure candidates. The three existing implementation PRs remain open.
- **Remaining:** 723 issues from this snapshot are unreviewed. Resume with [dotnet/docs#25247](https://github.com/dotnet/docs/issues/25247), opened July 20, 2021.
- **Evidence baseline:** Issue bodies, complete comment threads, current target documentation, candidate cross-reference timelines, open-PR checks, and the patches of the three active implementation PRs. Local source matched upstream `main` at `81cd030da804aa06cfbd8f23474cbbacba597c72`. Candidate issues were open when checked; existing ownership is noted where relevant.

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

### dotnet/docs#23596: Verify numeric-format examples and refresh their output

**Issue:** [dotnet/docs#23596](https://github.com/dotnet/docs/issues/23596). **Opened:** April 2, 2021. **Size:** Medium to large, bounded to one article and its examples. **GHCP suitability:** Suitable for a sample migration and verification task, with numerical-behavior review.

**Why it still applies:** The [general-format table](../docs/standard/base-types/standard-numeric-format-strings.md#GFormatString) now correctly distinguishes modern floating-point defaults from .NET Framework's `G7`/`G15` defaults. However, the [maintainer's final scope](https://github.com/dotnet/docs/issues/23596#issuecomment-848150766) also requires an article-wide check, migration from the old snippet system, and output recapture. The article still contains legacy sample references, including the general-format example. Fixing the table alone doesn't fulfill that follow-up.

**Why the solution is defined:** The maintainer specifies the work, the article identifies each format and sample, and the [floating-point compatibility note](../includes/core-changes/corefx/3.0/floating-point-changes.md) establishes why runtime-version distinctions matter.

**Proposed assignment scope:**

- Inventory and migrate the C# and Visual Basic samples referenced by `docs/standard/base-types/standard-numeric-format-strings.md` to article-relative projects, following the repository's snippet workflow. Preserve shared legacy regions still used by other articles.
- Run each published region with the latest stable SDK. Set or record the culture used for every culture-dependent example, then recapture and compare the actual output with the article's claims.
- Correct discrepancies and explicitly label runtime-dependent behavior. Retain justified .NET Framework distinctions instead of replacing all historical results with modern output.
- Include the reported `99.199999999999989d` case to demonstrate the difference between default general formatting and explicit `G15`. Don't revert the already-correct default-precision table.
- Keep the work to this article and the snippets it consumes, not a rewrite of every numeric-format guide.

**Acceptance criteria:** Every included region resolves, both language projects run, and the implementation PR records the SDK, cultures, commands, and observed outputs for all examples. Resolve or explicitly document discrepancies rather than claim success after compilation alone. Obtain runtime-owner review of changes to floating-point precision and version-specific claims.

### dotnet/docs#23616: Recommend XML documentation in library guidance

**Issue:** [dotnet/docs#23616](https://github.com/dotnet/docs/issues/23616). **Opened:** April 4, 2021. **Size:** Small. **GHCP suitability:** Strong; connect existing SDK guidance to the library-author workflow.

**Why it still applies:** Neither the [library getting-started page](../docs/standard/library-guidance/get-started.md) nor the [NuGet guidance](../docs/standard/library-guidance/nuget.md) explains how to generate and distribute XML API comments for consumers' IntelliSense. The SDK already documents [GenerateDocumentationFile](../docs/core/project-sdk/msbuild-props.md#generatedocumentationfile), so the gap is a recommendation and discoverability, not a missing compiler feature.

**Proposed assignment scope:** Add a short XML-documentation recommendation to `docs/standard/library-guidance/nuget.md` and mention that coverage in its existing getting-started signpost. Show `GenerateDocumentationFile=true`, explain the matching assembly/XML names, and link to the SDK property and existing language-specific XML-comment guides. Distinguish an IntelliSense XML file from a separately published API website. Don't create a duplicate XML-comment tutorial or recommend blanket suppression of missing-documentation warnings.

**Acceptance criteria:** Build and pack minimal C# and Visual Basic libraries with documented public members. Inspect the generated XML and `.nupkg` to confirm that the matching XML file accompanies each assembly under the appropriate target-framework folder. Record the commands and actual package contents; don't infer package inclusion solely from a successful build or confuse `dotnet publish` with `dotnet pack`.

### dotnet/docs#24018: Explain brace formatting for property patterns

**Issue:** [dotnet/docs#24018](https://github.com/dotnet/docs/issues/24018). **Opened:** May 3, 2021. **Size:** Small. **GHCP suitability:** Strong; the merged formatter change and tests establish the intended behavior.

**Why it still applies:** The [brace-option table](../docs/fundamentals/code-analysis/style-rules/csharp-formatting-options.md#csharp_new_line_before_open_brace) lists `object_collection_array_initializers` but doesn't explain that it also controls property-pattern braces. The issue's final request corrects its original proposal for a separate option.

**Why the solution is defined:** Merged [dotnet/roslyn#53110](https://github.com/dotnet/roslyn/pull/53110) applies the existing initializer option to `PropertyPatternClause` and tests enabled, disabled, and single-line cases. [dotnet/docs#24021](https://github.com/dotnet/docs/pull/24021), which proposed `property_pattern_clauses`, closed without merge.

**Proposed assignment scope:** Explain the expanded meaning of `object_collection_array_initializers` and add a focused multiline property-pattern example under `csharp_new_line_before_open_brace`. Show the option present and absent from the selected element list. Keep the existing option name and other supported values; don't add `property_pattern_clauses` or change the formatter's behavior.

**Acceptance criteria:** Run the formatter against both configurations and record the actual brace placement. Account for single-line preservation rather than promise that every compact pattern expands. Keep the change limited to this option and follow the repository's C# snippet rules for any extracted example.

### dotnet/docs#24065: State Windows container size trade-offs

**Issue:** [dotnet/docs#24065](https://github.com/dotnet/docs/issues/24065). **Opened:** May 6, 2021. **Size:** Small. **GHCP suitability:** Strong for a prose-only qualification of the existing recommendation.

**Why it still applies:** [When to choose .NET Framework for Docker containers](../docs/architecture/microservices/net-core-net-framework-containers/net-framework-container-scenarios.md) recommends direct containerization for existing applications but doesn't discuss the image-size cost raised by the report. The [adjacent modern .NET chapter](../docs/architecture/microservices/net-core-net-framework-containers/net-core-container-scenarios.md) already distinguishes Windows Server Core images from smaller Nano Server or Linux images; the recommendation page needs that context.

**Proposed assignment scope:** Add a concise trade-off paragraph to the direct-migration section and link to the adjacent comparison. Explain that .NET Framework's Windows Server Core dependency can increase image download, storage, and deployment costs. Distinguish image size from per-container writable storage and memory, and account for shared base layers. Preserve the option to leave an application on its current deployment when migration costs outweigh the benefit.

**Acceptance criteria:** The recommendation acknowledges the cost without claiming that every application requires a separate complete copy of the base image. Don't repeat the issue's `20 apps = 320 GB` estimate, prescribe unsupported .NET Core versions, or turn the clarification into a new proxy/migration tutorial.

### dotnet/docs#24137: Connect integration events, event sourcing, and the outbox

**Issue:** [dotnet/docs#24137](https://github.com/dotnet/docs/issues/24137). **Opened:** May 12, 2021. **Size:** Small. **GHCP suitability:** Strong for a focused conceptual clarification and cross-links.

**Why it still applies:** The [integration-events introduction](../docs/architecture/microservices/multi-container-microservice-net-applications/integration-event-based-microservice-communications.md#integration-events) defines cross-service messages without relating them to persisted event-sourcing records. The [atomicity discussion](../docs/architecture/microservices/multi-container-microservice-net-applications/subscribe-events.md#designing-atomicity-and-resiliency-when-publishing-to-the-event-bus) lists the Outbox pattern but also calls its integration-event table a simplified event-sourcing system, which leaves the reported distinction unclear.

**Why the solution is defined:** The issue identifies the two local sections and the [Azure Event Sourcing pattern](https://learn.microsoft.com/azure/architecture/patterns/event-sourcing) to connect. Their different purposes supply the explanation: cross-service contracts, state reconstruction from event history, and reliable publication of committed changes aren't interchangeable concepts.

**Proposed assignment scope:** Add a short comparison and links in the integration-events section. Clarify the existing outbox discussion so that durable outgoing messages don't imply a complete event-sourced domain model. Explain that an application can map internal events to separate integration contracts; don't prescribe a universal one-event-to-one-message mapping, database layout, or mandatory event-sourcing architecture.

**Acceptance criteria:** Readers can follow links among all three requested discussions, and the text distinguishes full event sourcing from an outbox without changing the existing transactional example. Use prose and cross-links only; no new event bus or persistence implementation is needed.

### dotnet/docs#24238: Show configuration access in an ordinary class

**Issue:** [dotnet/docs#24238](https://github.com/dotnet/docs/issues/24238). **Opened:** May 14, 2021. **Size:** Small. **GHCP suitability:** Strong; demonstrate the constructor-injection mechanism already described in the chapter.

**Why it still applies:** The [configuration chapter](../docs/architecture/blazor-for-web-forms-developers/config.md#read-configuration-in-the-app) says that any ASP.NET Core-managed class can request `IConfiguration`, but only demonstrates Razor's `@inject`. The options section likewise mentions class parameters without showing a normal class constructor. That omission is the reader's specific question.

**Proposed assignment scope:** Add a minimal service class that accepts `IConfiguration` through its constructor and reads an existing sample key. Show the registration and DI resolution needed for the example to work, and link to [the dependency-injection overview](../docs/core/extensions/dependency-injection/overview.md). State that the container supplies constructor arguments only when it creates the class. Follow the repository's C# and Visual Basic sample requirements; don't introduce a global configuration object, service locator, or second configuration root.

**Acceptance criteria:** Resolve the service through DI and demonstrate the expected value from the chapter's configuration structure. Record the actual result for both language examples. Keep the Razor and strongly typed options guidance intact and distinguish constructor injection from manually calling a parameterless constructor.

### dotnet/docs#24435: Clarify CA1806, IDE0058, and deliberate result discards

**Issue:** [dotnet/docs#24435](https://github.com/dotnet/docs/issues/24435). **Opened:** May 28, 2021. **Size:** Small to medium. **GHCP suitability:** Suitable for a bounded documentation correction, with analyzer-owner review.

**Why it still applies:** [CA1806](../docs/fundamentals/code-analysis/quality-rules/ca1806.md) still claims that LINQ methods have no side effects, omits the related IDE0058 rule, and doesn't explain intentional C# discards. [IDE0058](../docs/fundamentals/code-analysis/style-rules/ide0058.md) already distinguishes side-effect-free expressions from useful side effects and documents discard/local-variable alternatives.

**Proposed assignment scope:**

- Cross-link the two rules and explain CA1806's targeted correctness checks versus IDE0058's broader unused-expression style preference.
- Replace the universal LINQ side-effect claim with accurate guidance about unused results and deferred execution. Don't imply that discarding a deferred query causes enumeration or that arbitrary providers and callbacks are side-effect-free.
- Explain deliberate C# discards where the operation itself is intended and its result is genuinely unnecessary. Preserve the warning about ignored error codes and valuable query results; don't recommend a discard as a universal way to fix CA1806.
- Verify the report's `StringBuilder.Append` example against current analyzers before including it. Don't claim that default CA1806 flags every fluent API, and distinguish configurable additional methods from the default rule.
- Keep the work to these rule pages and any required verification snippets. The discussion's suggestion to merge the analyzers is a separate product decision, not a prerequisite or part of this assignment.

**Acceptance criteria:** Run targeted examples with CA1806 and IDE0058 explicitly enabled and record their analyzer versions, configuration, diagnostics, and before/after behavior. Include an intentionally ignored result and a deferred query, with Visual Basic's unused-local alternative where applicable. Obtain analyzer-owner review; don't infer semantic correctness merely because an explicit discard silences a diagnostic.

### dotnet/docs#24529: Load application configuration in the integration-test example

**Issue:** [dotnet/docs#24529](https://github.com/dotnet/docs/issues/24529). **Opened:** June 6, 2021. **Size:** Small to medium. **GHCP suitability:** Strong; replace a bare test host with the established application-test factory pattern.

**Why it still applies:** The [service-testing chapter](../docs/architecture/microservices/multi-container-microservice-net-applications/test-aspnet-core-services-web-apps.md#implementing-integration-and-functional-tests-for-each-microservice) still constructs `TestServer(new WebHostBuilder().UseStartup<Startup>())`. That bare builder doesn't establish the application's usual JSON configuration sources. The example verifies only a constant response, so it doesn't demonstrate the configuration behavior the issue asks about.

**Why the solution is defined:** The reporter identifies `WebApplicationFactory` as the working replacement. The linked [ASP.NET Core integration-testing guide](https://learn.microsoft.com/aspnet/core/test/integration-tests) documents that pattern, the application entry point, content root, and environment customization.

**Proposed assignment scope:** Replace the bare-host example with a minimal `WebApplicationFactory`-based test for an application with normal default configuration. Document the required `Microsoft.AspNetCore.Mvc.Testing` reference and match the actual app entry-point type rather than assume `Startup` is always the generic argument. Show environment selection for an environment-specific JSON file and explain content-root/file availability. Dispose the factory and client appropriately and preserve the chapter's existing distinction between unit and integration tests.

**Acceptance criteria:** Run tests that read a known value from `appsettings.json` and a different value from the selected environment's file. Confirm that the documented setup finds both files from the test runner's working directory. Follow the repository's language and snippet rules, record actual test results, and avoid a wider rewrite of the archived reference application or its Docker topology.

### dotnet/docs#24829: Refresh the ML.NET CLI sentiment tutorial

**Issue:** [dotnet/docs#24829](https://github.com/dotnet/docs/issues/24829). **Opened:** June 24, 2021. **Size:** Medium. **GHCP suitability:** Suitable for a bounded tutorial refresh, with actual CLI execution.

**Why it still applies:** The [CLI sentiment tutorial](../docs/machine-learning/tutorials/sentiment-analysis-cli.md) uses `--train-time` in its main command but later refers to `--max-exploration-time`. It also promises that extra time will produce a better model and describes positive/negative output as 1/2 despite the input dataset's 0/1 labels. Those concrete inconsistencies remain within the issue's requested tutorial review.

**Why the solution is defined:** The current [CLI reference](../docs/machine-learning/reference/ml-net-cli-reference.md) documents `--train-time`. The named dataset, tutorial command, and generated project provide a reproducible path to resolve the option, generated-file, and prediction-output discrepancies.

**Proposed assignment scope:** Run the tutorial with the current stable CLI and the specified dataset. Reconcile all option names with that version's help and the CLI reference, then update generated filenames, types, label descriptions, and captured output to match the run. Replace the guaranteed-improvement claim with accurate search-budget wording. Don't infer label mappings from a different generated API or claim a legacy option is rejected without checking it.

**Acceptance criteria:** Record the CLI/package versions, successful training and generated-project execution, and actual prediction output. All command references and label explanations agree with the verified run. Follow the repository's snippet rules for changed samples; don't fabricate deterministic scores or promise that a longer run always improves quality.

### dotnet/docs#24832: Complete the ML.NET algorithm guide's coverage

**Issue:** [dotnet/docs#24832](https://github.com/dotnet/docs/issues/24832). **Opened:** June 24, 2021. **Size:** Medium, bounded to the algorithm guide and its API/tutorial links. **GHCP suitability:** Suitable with an API-based coverage checklist and coordination with assignee `jwood803`.

**Why it still applies:** The [algorithm guide](../docs/machine-learning/how-to-choose-an-ml-net-algorithm.md) describes PCA for anomaly detection but omits the time-series SR-CNN detector. The [maintainer's explicit follow-up](https://github.com/dotnet/docs/issues/24832#issuecomment-907166898) identifies `DetectEntireAnomalyBySrCnn` and the existing [phone-call anomaly tutorial](../docs/machine-learning/tutorials/phone-calls-anomaly-detection.md). That tutorial demonstrates the API and its prediction options.

**Why the solution is defined:** The maintainer supplies a specific missing algorithm and an existing example. Published stable ML.NET API catalogs provide the source for the issue's broader request to check algorithm coverage; no new model implementation or invented performance comparison is necessary.

**Proposed assignment scope:** Compare the guide's algorithm families with the current stable trainer and time-series catalogs, record omissions, and add missing family descriptions with verified API/tutorial links. Explicitly cover SR-CNN and distinguish its batch time-series detection API from ordinary trainer selection. Reuse existing descriptions and tutorials rather than duplicate API reference material. Don't guess ONNX export support or conflate preprocessing transforms with training algorithms.

**Acceptance criteria:** Include a source-backed coverage checklist in the implementation PR and resolve each identified omission. The guide links to the SR-CNN API and tutorial and explains its time-series purpose. Don't claim that one SR-CNN entry alone completes the original all-algorithms review; obtain the existing owner's review of the coverage.

### dotnet/docs#24834: Finish the model-improvement navigation update

**Issue:** [dotnet/docs#24834](https://github.com/dotnet/docs/issues/24834). **Opened:** June 24, 2021. **Size:** Very small. **GHCP suitability:** Strong for the remaining TOC correction, with placement confirmed by assignee `jwood803`.

**Why it still applies:** Merged [dotnet/docs#27348](https://github.com/dotnet/docs/pull/27348) updated the article's title and introduction, but the [ML.NET TOC](../docs/machine-learning/toc.yml) still labels it **Improve model accuracy** under the conceptual group. The [article](../docs/machine-learning/resources/improve-machine-learning-model-ml-net.md) is now titled **Improve your ML.NET model** and marked as a how-to. The issue's navigation question remains distinct from the completed title patch.

**Why the solution is defined:** The existing title supplies the label, and the adjacent **How-to guides** group supplies the proposed location. No new article or URL change is required.

**Proposed assignment scope:** Align the TOC label with **Improve your ML.NET model**. Confirm the issue's proposed how-to placement with the owner, then move the existing TOC entry into that group without moving the Markdown file. Keep exactly one navigation entry and preserve the article URL. Limit the task to the demonstrated navigation inconsistency, not an open-ended model-quality rewrite.

**Acceptance criteria:** The TOC label matches the article, the agreed group contains the entry, and the existing relative link resolves. Don't introduce a duplicate page, redirect, or second assignment for the already-merged title change.

### dotnet/docs#24842: Correct concrete ML.NET glossary definitions

**Issue:** [dotnet/docs#24842](https://github.com/dotnet/docs/issues/24842). **Opened:** June 24, 2021. **Size:** Small. **GHCP suitability:** Strong for the demonstrated definition errors, with metric-owner review.

**Why it still applies:** The [glossary](../docs/machine-learning/resources/glossary.md) restricts R-squared to 0-1, calls 0.5 the worst ROC AUC, and defines normalization as a universal conversion to 0-1. The [metrics guide](../docs/machine-learning/resources/metrics.md) permits negative R-squared but incorrectly limits that possibility to particular model families and describes the baseline as random guessing.

**Why the solution is defined:** The [ML.NET regression evaluator](https://github.com/dotnet/machinelearning/blob/main/src/Microsoft.ML.Data/Evaluators/RegressionEvaluator.cs) calculates R-squared from prediction error relative to label variance. The [binary metrics contract](https://github.com/dotnet/machinelearning/blob/main/src/Microsoft.ML.Data/Evaluators/Metrics/BinaryClassificationMetrics.cs) documents ROC AUC's 0-1 range. Existing [normalization API links](../docs/machine-learning/resources/transforms.md#normalization-and-scaling) identify multiple methods, not one universal output range.

**Proposed assignment scope:** Correct the glossary's R-squared, ROC AUC, and normalization entries. Explain that R-squared can be negative relative to the mean-label baseline, while 0.5 ROC AUC denotes chance-level ranking rather than the minimum. Describe normalization as method-dependent. Correct the directly conflicting R-squared explanation in `resources/metrics.md`; don't preserve its unsupported restriction to nonlinear or constrained models.

**Acceptance criteria:** Check the wording against the metric/API contracts and demonstrate negative R-squared and ROC AUC below 0.5 with controlled inputs. Don't promise a finite R-squared for a zero-variance label dataset or import a normalization formula without verifying the selected API. Record actual results for any added examples and follow the repository's language/snippet rules.

### dotnet/docs#24897: Align MSTest tutorial setup with the testing guidance

**Issue:** [dotnet/docs#24897](https://github.com/dotnet/docs/issues/24897). **Opened:** June 29, 2021. **Size:** Small. **GHCP suitability:** Suitable for a localized example-consistency change.

**Why it still applies:** The [MSTest tutorial](../docs/core/testing/unit-testing-csharp-with-mstest.md) and its [local test file](../docs/core/testing/snippets/unit-testing-using-mstest/csharp/PrimeService.Tests/PrimeService_IsPrimeShould.cs) construct the service in a test-class constructor and access it through a field. The referenced [best-practices guide](../docs/core/testing/unit-testing-best-practices.md) favors a visible Arrange step and helper methods rather than hidden common setup. The constructor avoids an initialization attribute, but doesn't show the test's service creation at the point of use.

**Why the solution is defined:** For this stateless, parameterless service, each test can construct its own `PrimeService` in its Arrange step. No fixture lifecycle, asynchronous setup, or framework policy change is necessary. The recommendation is about tutorial consistency, not a claim that MSTest constructors share one instance across tests or are inherently invalid.

**Proposed assignment scope:** Replace the constructor/field arrangement with explicit local service creation in the inline first-test example and every affected region of the local test file. Preserve the assertions, data rows, and test-driven sequence. Check the linked `dotnet/samples` finished example and coordinate a matching change if needed; don't claim that an edit in this repository updates the external sample.

**Acceptance criteria:** Run the tutorial's initial-failure and subsequent-pass stages, then run all final tests. Confirm that each published region compiles in the complete example and follows the same setup pattern. Don't broaden the task into a testing-framework migration or unrelated tutorial cleanup.

### dotnet/docs#24984: Explain F# generalization for lists, options, and arrays

**Issue:** [dotnet/docs#24984](https://github.com/dotnet/docs/issues/24984). **Opened:** July 4, 2021. **Size:** Small to medium. **GHCP suitability:** Strong for a compiler-verifiable explanation, with F# review.

**Why it still applies:** The [automatic-generalization guide](../docs/fsharp/language-reference/generics/automatic-generalization.md) explains the value restriction but doesn't directly explain why a list or option containing `id` can generalize while the reported nonempty array binding cannot.

**Why the solution is defined:** The [F# specification's inference procedures](https://github.com/fsharp/fslang-spec/blob/main/spec/inference-procedures.md) enumerate generalizable expressions, including qualifying union-case constructions and the empty-array exception. During triage, F# Interactive from stable SDK 10.0.403 successfully used `[id; id]` and `Some id` at both `int` and `string`, while an otherwise unused `[| id; id |]` binding produced FS0030. A function that creates a fresh array also worked at both types.

**Proposed assignment scope:** Add a focused list/option-versus-nonempty-array explanation and verified examples to the existing guide. Tie the distinction to generalizable expression forms and mutable storage, not a blanket rule for all immutable collections. Show a function/factory alternative and explain that it creates a fresh value. Don't classify every `seq`, map, dictionary, or array expression solely by its type name; preserve the specification's empty-array exception.

**Acceptance criteria:** Compile successful examples with a current stable F# compiler, reproduce the intended value-restriction diagnostic in a separate negative example, and record the actual results. Keep examples F#-only, follow the repository's snippet rules, and obtain review of the expression-based explanation.

### dotnet/docs#25018: Explain how newer applications consume older-target libraries

**Issue:** [dotnet/docs#25018](https://github.com/dotnet/docs/issues/25018). **Opened:** July 7, 2021. **Size:** Small. **GHCP suitability:** Strong for a package-compatibility clarification.

**Why it still applies:** The [cross-platform library guidance](../docs/standard/library-guidance/cross-platform-targeting.md) discusses .NET Standard and multitargeting, but doesn't directly answer the reported distinction between an older-target library inside a newer application and an older application that needs a runtime.

**Why the solution is defined:** Existing [target-framework guidance](../docs/standard/frameworks.md) and package asset-selection rules provide the explanation: NuGet selects compatible assets for the consuming application's target; a library's target isn't an instruction to launch a separate older runtime inside that application.

**Proposed assignment scope:** Add a short explanation and cross-links in the library-targeting guidance. Use a supported example such as a `net10.0` application that consumes a `net8.0` library package. Distinguish compatible/nearest asset selection from application runtime roll-forward, and retain caveats for transitive dependencies, native assets, operating systems, and behavioral compatibility. Don't promise that every older binary works or recommend an unsupported runtime.

**Acceptance criteria:** Pack the example library, restore and run the consuming application, and inspect the selected package assets. Record the result in the implementation PR. The prose explains both package compatibility and the separate runtime-selection question without conflating them.

### dotnet/docs#25081: Clarify .NET Framework native Arm64 support

**Issue:** [dotnet/docs#25081](https://github.com/dotnet/docs/issues/25081). **Opened:** July 12, 2021. **Size:** Very small. **GHCP suitability:** Strong for a source-backed note and link.

**Why it still applies:** The [Framework versions-and-dependencies guide](../docs/framework/install/versions-and-dependencies.md) lists Windows versions and generic 64-bit support, but doesn't directly answer which Framework version adds native Arm64 support. A generic 64-bit entry doesn't establish the architecture matrix.

**Why the solution is defined:** The existing [Framework 4.8.1 Arm64 section](../docs/framework/whats-new/index.md#arm64native481) explicitly identifies 4.8.1 as the release that adds native Arm64 support and distinguishes it from emulation.

**Proposed assignment scope:** Add a concise Arm64 note beside the Framework 4.8.1 version information and link to that feature explanation and applicable system requirements. Distinguish native architecture support from emulation and retain the supported-Windows constraints. Don't extrapolate the statement to Arm32, Windows RT, every older Framework version, or an unverified emulation matrix.

**Acceptance criteria:** The versions guide answers the native-Arm64 question directly and links to the existing authoritative details. Keep the change prose-only; no new architecture tutorial or runtime sample is necessary.

### dotnet/docs#25240: Connect the migration guide to the existing .NET overview

**Issue:** [dotnet/docs#25240](https://github.com/dotnet/docs/issues/25240). **Opened:** July 20, 2021. **Size:** Very small. **GHCP suitability:** Strong; reuse existing overview content.

**Why it still applies:** In the [migration TOC](../docs/navigate/migration-guide/toc.yml), **General information > About .NET** is a grouping node without an overview link. Its children cover SDK versioning and server-framework choice, not the architecture/runtime overview requested by the issue.

**Why the solution is defined:** The existing [.NET introduction](../docs/core/introduction.md) explains components, implementation families, and app stacks. The Windows installation guide's [runtime-selection section](../docs/core/install/windows.md#choose-the-correct-runtime) explains the base, ASP.NET Core, and Desktop runtimes and the SDK. The issue explicitly permits reuse of existing documentation.

**Proposed assignment scope:** Add the existing introduction as the **About .NET** overview destination, preserving the group's current children. Provide a concise signpost to runtime-selection guidance from the relevant migration entry point if the introduction doesn't expose that distinction clearly enough. Don't duplicate the introduction or create a new runtime taxonomy page.

**Acceptance criteria:** Migration navigation reaches the architecture overview directly and retains the existing versioning/server-choice links. Runtime guidance distinguishes the SDK from the runtime choices without implying that one runtime supports every app stack. Coordinate the shared TOC edit with dotnet/docs#25241.

### dotnet/docs#25241: Rename the migration compatibility overview

**Issue:** [dotnet/docs#25241](https://github.com/dotnet/docs/issues/25241). **Opened:** July 20, 2021. **Size:** Very small. **GHCP suitability:** Strong; mechanical title/navigation alignment, coordinated with assignee `StephenBonikowsky`.

**Why it still applies:** The [porting compatibility page](../docs/core/porting/breaking-changes.md) still uses breaking-changes-only wording in its title and H1. The [migration TOC](../docs/navigate/migration-guide/toc.yml) likewise uses **Breaking changes** for the group, although the page explains compatibility categories as well.

**Why the solution is defined:** The issue explicitly requests **Compatibility and Breaking Changes**. Sentence-case **Compatibility and breaking changes** supplies the requested label without a new content design.

**Proposed assignment scope:** Update the page title, H1, and appropriate migration TOC group label to **Compatibility and breaking changes**. Preserve the Markdown filename, published URL, and existing overview/reference destinations. Check directly related references for title consistency, but don't rename unrelated breaking-change indexes.

**Acceptance criteria:** The displayed page title and migration label agree, and all existing destinations remain valid. No redirect is needed if the path stays unchanged. After owner coordination, consider one assignment with dotnet/docs#25240 to avoid concurrent changes to the same TOC; retain both issue references.

## Defined fixes already in progress

These issues still need their existing PRs to land, with corrections where noted. They aren't closure-without-action candidates and shouldn't receive duplicate implementation assignments.

### dotnet/docs#22074: Document the none API-surface value

**Issue:** [dotnet/docs#22074](https://github.com/dotnet/docs/issues/22074). **Opened:** December 17, 2020. **Status:** Covered by open, non-draft [dotnet/docs#56622](https://github.com/dotnet/docs/pull/56622).

**Why the solution is defined:** The [analyzer-owner reply](https://github.com/dotnet/docs/issues/22074#issuecomment-747846299) confirms `none` as an API-surface value. The current [options table](../docs/fundamentals/code-analysis/code-quality-rule-options.md#api_surface) omits it. The PR's actual patch adds `none` with the description that it applies to no APIs in exactly that table.

**Maintainer next action:** Review the existing PR rather than assign a second implementation. Confirm the wording and configuration scope against the supported analyzer versions; don't generalize the effect beyond rules that use `api_surface`. Close through the existing PR after merge, not before.

### dotnet/docs#22105: Remove the obsolete dotnet MyGet feed

**Issue:** [dotnet/docs#22105](https://github.com/dotnet/docs/issues/22105). **Opened:** December 21, 2020. **Status:** Covered by open, non-draft [dotnet/docs#56623](https://github.com/dotnet/docs/pull/56623).

**Why the solution is defined:** No MyGet references were found in the current sample files searched, but the [dotnet package add examples](../docs/core/tools/dotnet-package-add.md#examples) still contain `https://dotnet.myget.org/F/dotnet-core/api/v3/index.json`. The PR's actual patch replaces that obsolete .NET feed with `https://api.nuget.org/v3/index.json` in the same example.

**Scope distinction:** Other library-guidance articles mention MyGet as a third-party hosting service. Those generic service references aren't equivalent to the decommissioned Microsoft feed and don't justify a blanket deletion of every occurrence of the service name.

**Maintainer next action:** Review the existing one-line correction and confirm that the obsolete feed doesn't remain in sample/configuration files before closure. Don't open another PR or close the issue while the correction is still unmerged.

### dotnet/docs#24007: Correct the unhandled-exception method reference

**Issue:** [dotnet/docs#24007](https://github.com/dotnet/docs/issues/24007). **Opened:** May 1, 2021. **Status:** Open, non-draft [dotnet/docs#56491](https://github.com/dotnet/docs/pull/56491) attempts the fix but needs correction.

**Why the solution is defined:** The current [method page](../docs/core/unmanaged-api/debugging/icordebug/icordebugthread4-hadunhandledexception-method.md) contains the copied `GetBlockingObjects` signature and parameter. The runtime's [CorDebug IDL](https://github.com/dotnet/runtime/blob/main/src/coreclr/inc/cordebug.idl) declares `HRESULT HasUnhandledException();` with no parameters. The existing PR removes the copied parameter but substitutes `HadUnhandledException()`, retaining the documentation's incorrect method name.

**Maintainer next action:** Correct the existing PR rather than assign a duplicate. Align the syntax, title, API metadata, and interface links with `HasUnhandledException`, and verify the HRESULT descriptions against the same authoritative declaration. Preserve the old URL or add an appropriate redirect if the file moves. Don't merge the current patch as a complete fix or close the issue merely because it has an `in-pr` label.

## Assignment order

For the quickest independent changes, start with the table escaping, the paired COM wording corrections, or the existing prose-only signposts. Coordinate the instrumentation link with its current owner. Treat the two COM issues as one assignment, and use the existing hosted-service issue rather than duplicate work for dotnet/docs#23440.

The model-improvement TOC label, Framework Arm64 signpost, and migration overview/title links are additional small changes. Coordinate the two migration tasks as one TOC pass if the existing owner agrees. Both the algorithm inventory and model-improvement navigation task have current assignee `jwood803`; don't create parallel ownership without coordination.

The coding-components overview needs new-page review. Source Link, plugin publication, the trimming limitation, XML package documentation, constructor injection, and integration-test configuration need focused execution evidence. Verify formatter output for the property-pattern explanation and obtain analyzer-owner review of the CA1806 corrections. The numeric-format article is a larger sample-verification task, not a one-line table fix. The linker correction requires the .NET Framework toolchain, and the PEVerify clarification needs compiler-owner review.

The CLI tutorial needs a real training/generated-project run. The glossary corrections and library-targeting clarification need controlled metric/package examples, while the MSTest cleanup needs the tutorial's fail/pass sequence. The F# explanation already has a stable-compiler reproduction, but its eventual published snippets still need execution and F# review.

Review the three existing implementation PRs separately from new assignments; correct the unhandled-exception method name before merge. Issues that don't fit either candidate category are omitted for a future task.
