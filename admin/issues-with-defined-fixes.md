---
title: Issues with clearly defined fixes
ai-usage: ai-generated
---

# Issues with clearly defined fixes

Recommend the following 100 issues as GitHub Copilot (GHCP) assignment candidates because each has a specific remaining documentation gap, identified target files, and a bounded resolution. Track fourteen additional defined fixes separately because implementation PRs are already open; several need correction or completion before merge. No assignments or other GitHub changes have been made. Entries within each category follow issue creation time, not implementation priority.

## Review coverage

- **Repository and snapshot:** `dotnet/docs`, November 2, 2026; 848 open issues, excluding pull requests.
- **Completed batches:** The 300 oldest open issues, from [dotnet/docs#2608](https://github.com/dotnet/docs/issues/2608), opened July 12, 2017, through [dotnet/docs#32096](https://github.com/dotnet/docs/issues/32096), opened October 31, 2022.
- **Results:** 114 defined fixes (100 assignment candidates and 14 with open implementation PRs) and 58 [closure candidates](issues-to-close.md#closure-candidates).
- **Latest batch:** Issues 276-300 add 7 new assignment candidates and 2 fixes with open implementation PRs, alongside 8 closure candidates.
- **Remaining:** 548 issues from this snapshot are unreviewed. The requested additional 150 issues (positions 151-300) are complete. Stop here; any future tranche starts with [dotnet/docs#32112](https://github.com/dotnet/docs/issues/32112), opened November 1, 2022.
- **Evidence baseline:** Issue bodies, complete comment threads, current target documentation, candidate cross-reference timelines, open-PR checks, and the patches of the fourteen active implementation PRs. Local source matched upstream `main` at `81cd030da804aa06cfbd8f23474cbbacba597c72`. Candidate issues were open when checked; existing ownership is noted where relevant.

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

**Proposed assignment scope:** Compare the guide's algorithm families with the current stable trainer and time-series catalogs, record omissions, and add missing family descriptions with verified API/tutorial links. Explicitly cover SSA forecasting, relevant time-series anomaly algorithms, and SR-CNN; distinguish time-series estimator APIs from ordinary trainer selection. Reuse the existing [forecasting tutorial](../docs/machine-learning/tutorials/time-series-demand-forecasting.md) and anomaly tutorials rather than duplicate API reference material. Preserve the forecasting requirement from overlapping dotnet/docs#30043 and coordinate with its assignee `luisquintanilla` as well as `jwood803`. Don't guess ONNX export support or conflate preprocessing transforms with training algorithms.

**Acceptance criteria:** Include a source-backed coverage checklist in the implementation PR and resolve each identified omission, including forecasting. The guide links to the verified forecasting and anomaly APIs/tutorials and explains their time-series purpose. Don't claim that one SR-CNN entry alone completes the original all-algorithms review; obtain the existing owners' review of the coverage.

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

Preserve the explicit support-confirmation question from duplicate [dotnet/docs#25478](https://github.com/dotnet/docs/issues/25478), currently assigned to `StephenBonikowsky`. State the supported compatible-library scenario with its qualifications, rather than report only that one test happened to work.

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

### dotnet/docs#25252: Add actionable pre-migration examples and limitations

**Issue:** [dotnet/docs#25252](https://github.com/dotnet/docs/issues/25252). **Opened:** July 20, 2021. **Size:** Medium, bounded to the prerequisites guide. **GHCP suitability:** Suitable for a source-backed procedural expansion.

**Why it still applies:** The [prerequisites guide](../docs/core/porting/premigration-needed-changes.md) still gives only one-sentence instructions for `PackageReference` and SDK-style conversion. It doesn't explain the requested common problems or show the relevant project changes.

**Why the solution is defined:** The authoritative [NuGet migration guide](https://learn.microsoft.com/nuget/consume-packages/migrate-packages-config-to-package-reference) already documents the migrator, backups, compatibility report, unsupported project types, ignored installation scripts, and content differences. The [.NET project SDK overview](../docs/core/project-sdk/overview.md) explains implicit item inclusion and duplicate-item failures.

**Proposed assignment scope:** Expand the terse conversion sections with the applicable tool workflow, a small before/after project example, and links to the documented migration limitations. Explain that project-format conversion and target-framework changes are separate steps. Include package-compatibility review and SDK duplicate-item pitfalls; don't prescribe the Visual Studio migrator for unsupported C++ or classic ASP.NET projects or imply every Framework project converts unchanged.

**Acceptance criteria:** Validate representative eligible C# and Visual Basic projects before and after the documented steps. Preserve their Framework target until the separate retargeting step, verify restore/build behavior, and record actual results. Keep larger source examples in the repository's snippet format, and use current supported tooling rather than revive ApiPort.

### dotnet/docs#25253: Move porting-plan navigation before the upgrade

**Issue:** [dotnet/docs#25253](https://github.com/dotnet/docs/issues/25253). **Opened:** July 20, 2021. **Size:** Very small. **GHCP suitability:** Strong; an explicitly requested TOC move.

**Why it still applies:** The [migration TOC](../docs/navigate/migration-guide/toc.yml) still places **Create a porting plan**, including **Approaches** and **Project structure**, under **Upgrade**. The issue explicitly requests those existing pages under pre-migration.

**Proposed assignment scope:** Move the existing plan group and both children into **Pre-upgrade**, preserving their labels, URLs, and relative links. Don't move the article files or duplicate the group. Coordinate this shared TOC edit with dotnet/docs#25240 and dotnet/docs#25241.

**Acceptance criteria:** Planning appears before execution in navigation, both original pages remain reachable exactly once, and the upgrade/application-guide groups retain their other children.

### dotnet/docs#25294: Dispose the linked-cancellation example's owned resources

**Issue:** [dotnet/docs#25294](https://github.com/dotnet/docs/issues/25294). **Opened:** July 22, 2021. **Size:** Medium, bounded to one article and its two samples. **GHCP suitability:** Suitable for a lifecycle correction with deterministic cancellation tests.

**Why it still applies:** The [multiple-cancellation article](../docs/standard/threading/how-to-listen-for-multiple-cancellation-requests.md) references [C#](../samples/snippets/csharp/VS_Snippets_Misc/cancellation/cs/cancellationex13.cs) and [Visual Basic](../samples/snippets/visualbasic/VS_Snippets_Misc/cancellation/vb/cancellationex13.vb) workers that own an internal `CancellationTokenSource` but never dispose it. `CancellationToken` itself isn't disposable, so the issue's terminology needs correction rather than dismissal. The VB sample also compares an exception's linked token with predecessor tokens instead of checking their cancellation state.

**Proposed assignment scope:** Explain ownership of the sources, linked source, timer, and tokens. Dispose owned sources and the timer only after worker execution and callbacks can no longer use them. Ensure that cancellation of a wait doesn't abandon the worker before cleanup. Align VB's cancellation-origin logic with the article and C# sample; retain the external-cancellation and timeout paths. Follow the snippet rules if the legacy examples move.

**Acceptance criteria:** Exercise external cancellation and timeout without keyboard-dependent automation. Verify worker completion, correct path reporting, and cleanup without `ObjectDisposedException` or timer callbacks that use disposed sources. Don't add a nonexistent `CancellationToken.Dispose` or treat disposal as a request to cancel.

### dotnet/docs#25405: Qualify IDE0071's compiler-lowering explanation

**Issue:** [dotnet/docs#25405](https://github.com/dotnet/docs/issues/25405). **Opened:** July 29, 2021. **Size:** Small. **GHCP suitability:** Strong for a precise wording correction, with compiler review.

**Why it still applies:** The [IDE0071 overview](../docs/fundamentals/code-analysis/style-rules/ide0071.md) says the compiler implicitly invokes the same method after removing `ToString()`. That wording suggests identical lowering, although the reported value-type example can box on older targets. The [compiler discussion](https://github.com/dotnet/roslyn/issues/55240) confirms the diagnostic is intentional and distinguishes .NET 6 code generation.

**Proposed assignment scope:** Describe the rule as a readability simplification, not a guarantee of identical calls, IL, boxing, or allocation behavior. Explain that interpolation lowering depends on compiler/target support and link to the interpolation reference. Don't label the analyzer incorrect or promise that simplification always improves performance.

**Acceptance criteria:** The revised overview matches the compiler-owner explanation. If it includes a version-specific lowering or allocation example, verify that exact compiler/target pair and record the result rather than infer behavior from a current-runtime run.

### dotnet/docs#25445: Demonstrate extension GetEnumerator in conceptual guidance

**Issue:** [dotnet/docs#25445](https://github.com/dotnet/docs/issues/25445). **Opened:** August 3, 2021. **Size:** Small. **GHCP suitability:** Strong; add the requested example to the language reference, not the proposal.

**Why it still applies:** The [foreach reference](../docs/csharp/language-reference/statements/iteration-statements.md#the-foreach-statement) allows an extension `GetEnumerator`, but its adjacent example uses `Span<T>`'s instance pattern. It doesn't demonstrate the extension feature that prompted the issue. The final discussion favors conceptual discoverability rather than expanding normative proposal text.

**Proposed assignment scope:** Add one complete, minimal example of a type without an instance enumeration pattern that becomes enumerable through a public extension `GetEnumerator`. Explain the enumerator's `Current`/`MoveNext` requirements and the distinction from LINQ or `List.ForEach`. Use the existing iteration-reference snippet project and preserve the specification link.

**Acceptance criteria:** Compile and run the actual `foreach` example, capture its output, and confirm the extension supplies the enumeration pattern. Don't rely on a type that already implements the required instance/interface pattern or add an unrelated LINQ tutorial.

### dotnet/docs#25469: Include enums in interop blittability guidance

**Issue:** [dotnet/docs#25469](https://github.com/dotnet/docs/issues/25469). **Opened:** August 5, 2021. **Size:** Small. **GHCP suitability:** Strong for a localized type-rule clarification with interop review.

**Why it still applies:** The [interop best-practices list](../docs/standard/native-interop/best-practices.md#blittable-types) doesn't explicitly identify enum types. The runtime's [field-marshalling implementation](https://github.com/dotnet/runtime/blob/main/src/coreclr/vm/fieldmarshaler.cpp) resolves enum handling through the underlying integral type.

**Proposed assignment scope:** State how a C#/VB enum with a blittable integral underlying type fits the runtime-enabled list, and align the explanation with the existing runtime-disabled rules. Distinguish a concrete enum from a parameter typed as `System.Enum`. Explain that native enum width, struct packing, and layout must match the ABI; don't assume matching member names or an unsafe managed byte copy proves native compatibility.

**Acceptance criteria:** Review the wording against the supported marshalling rules. If the change adds an example, verify native round-trips and struct offsets for explicitly matched integral widths, in both documentation languages. Don't use `Marshal.SizeOf<TEnum>()` alone as a blittability test or extrapolate to every marshalling backend.

### dotnet/docs#25482: Show how multitargeted projects vary their source

**Issue:** [dotnet/docs#25482](https://github.com/dotnet/docs/issues/25482). **Opened:** August 5, 2021. **Size:** Small. **GHCP suitability:** Strong; connect the existing project-layout explanation to conditional-compilation guidance.

**Why it still applies:** The [project-structure article](../docs/core/porting/project-structure.md#replace-existing-projects-with-a-multi-targeted-net-project) promises framework-specific source but its multitargeting section only links project files. It doesn't explain how the source differs per target.

**Proposed assignment scope:** Add a concise explanation of SDK-defined framework symbols and conditional compilation, with a direct link to the existing [library-targeting example](../docs/standard/library-guidance/cross-platform-targeting.md#multi-targeting). Distinguish conditional source from conditional package/project items. If an additional local sample is needed, keep one public API with verified per-target implementations and show the applicable project targets; don't copy the existing illustrative helper calls as though they were complete implementations.

**Acceptance criteria:** Readers reach a concrete source-variation example from the multitargeted-project section. Verify any newly published code against every stated target, include both C# and VB where required, and record which outputs ran. Don't imply that merely adding `TargetFrameworks` makes unavailable APIs compile for all targets.

### dotnet/docs#25514: Reconcile Code Contracts visibility and exception wording

**Issue:** [dotnet/docs#25514](https://github.com/dotnet/docs/issues/25514). **Opened:** August 7, 2021. **Size:** Very small. **GHCP suitability:** Suitable for two precise clarifications in the Framework article.

**Why it still applies:** The [Code Contracts article](../docs/framework/debug-trace-profile/code-contracts.md) permits less-visible members in postconditions but later gives an unqualified visibility rule for all contracts. Its exceptional-postcondition wording also leaves the exact-`T` case implicit.

**Proposed assignment scope:** Qualify **Visibility** so it doesn't contradict **Postconditions**, and cross-link the distinction. Describe exceptional postconditions as applying to exceptions of type `T` or a derived type; don't accept the incorrect inference that derived exceptions are excluded. Preserve the article's Framework-only support warning and existing attribute exceptions.

**Acceptance criteria:** The two visibility explanations agree, and the exception wording remains consistent with `EnsuresOnThrow<TException>`. Keep the change prose-only unless legacy tooling is actually available to verify a new example; don't claim Code Contracts tooling works on modern .NET.

### dotnet/docs#25519: Document the non-generic TaskCompletionSource

**Issue:** [dotnet/docs#25519](https://github.com/dotnet/docs/issues/25519). **Opened:** August 8, 2021. **Size:** Very small for the core correction. **GHCP suitability:** Strong; the contradictory API exists.

**Why it still applies:** The [TAP implementation guide](../docs/standard/asynchronous-programming-patterns/implementing-the-task-based-asynchronous-pattern.md#io-bound-tasks) still says `TaskCompletionSource<TResult>` has no nongeneric counterpart. The [runtime implementation](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Threading/Tasks/TaskCompletionSource.cs) defines `TaskCompletionSource` with parameterless `SetResult` and `TrySetResult`.

**Proposed assignment scope:** Correct the statement, link to the nongeneric API available from .NET 5, and distinguish modern no-result tasks from the dummy-result technique needed on older targets such as .NET Framework. Keep the existing generic example valid and accurately scoped. Don't imply that the nongeneric API is available on every target covered by this shared guide.

**Acceptance criteria:** API cross-references resolve and version scope is explicit. If the implementation replaces or adds a no-result example, update and execute both language snippets and record successful completion; don't pass a dummy result to the nongeneric completion methods.

### dotnet/docs#25526: Explain permission-policy alternatives for microservices

**Issue:** [dotnet/docs#25526](https://github.com/dotnet/docs/issues/25526). **Opened:** August 9, 2021. **Size:** Small, prose and cross-links. **GHCP suitability:** Suitable with authorization-owner review.

**Why it still applies:** The [authentication chapter](../docs/architecture/microservices/secure-net-microservices-web-applications/index.md) and [authorization chapter](../docs/architecture/microservices/secure-net-microservices-web-applications/authorization-net-microservices-web-applications.md) cover JWT role claims and policies. They don't directly answer whether every service permission must be embedded in the token or explain the requested alternative of service-side permission evaluation.

**Proposed assignment scope:** Add a short signpost from authentication to authorization, then distinguish token-carried roles/claims from custom policy handlers that consult service-owned authorization data. Link to authoritative ASP.NET Core policy/handler guidance and explain the freshness, caching, and availability trade-offs without prescribing one universal model. Keep enforcement at the API/service boundary. Don't invent automatic permission claims or revive an IdentityServer4 configuration tutorial.

**Acceptance criteria:** The explanation answers the all-permissions-in-every-token concern and links to the existing role/policy mechanisms. Obtain review of authorization semantics; no new token issuer, permission service, or sample security architecture is required.

### dotnet/docs#25541: Explain the sample's request-ID deduplication path

**Issue:** [dotnet/docs#25541](https://github.com/dotnet/docs/issues/25541). **Opened:** August 10, 2021. **Size:** Small to medium. **GHCP suitability:** Strong for a source-backed explanation, not a new message-processing system.

**Why it still applies:** The [event-handler deduplication section](../docs/architecture/microservices/multi-container-microservice-net-applications/subscribe-events.md#deduplicating-message-events-at-the-eventhandler-level) stops at wrapping a command with `RequestId`. The linked sample's [IdentifiedCommandHandler](https://github.com/dotnet-architecture/eShopOnContainers/blob/main/src/Services/Ordering/Ordering.API/Application/Commands/IdentifiedCommandHandler.cs) actually checks `ExistAsync`, returns on a duplicate, records a new request, and dispatches the inner command. [RequestManager](https://github.com/dotnet-architecture/eShopOnContainers/blob/main/src/Services/Ordering/Ordering.Infrastructure/Idempotency/RequestManager.cs) supplies the persisted request lookup and insertion.

**Proposed assignment scope:** Trace that existing handler/store path in the article and link directly to the missing checks. Explain identifier reuse on redelivery and distinguish duplicate detection from idempotent business updates. Describe the archived sample as an illustration; don't copy its catch-and-default pattern as a new recommendation or imply that attaching an ID alone provides atomic, exactly-once processing.

**Acceptance criteria:** Readers can locate the duplicate branch, request store, and business dispatch from the explanation. Verify any new code against repeated-ID, new-ID, and failure cases, and state transaction/concurrency limits explicitly. Don't introduce a new inbox implementation or claim a serial in-memory test proves distributed exactly-once behavior.

### dotnet/docs#25547: Distinguish runtime tests from framework-specific package builds

**Issue:** [dotnet/docs#25547](https://github.com/dotnet/docs/issues/25547). **Opened:** August 10, 2021. **Size:** Small. **GHCP suitability:** Strong for a focused library-guidance clarification.

**Why it still applies:** The [library-targeting guide](../docs/standard/library-guidance/cross-platform-targeting.md#multi-targeting) explains separate framework assets and dependency binding, but doesn't directly answer whether testing a .NET Standard assembly on Framework runtimes substitutes for producing framework-targeted assets. Its historical `net461` recommendation has changed to `net462`; that edit alone doesn't answer the conceptual question.

**Proposed assignment scope:** Explain that runtime tests exercise the selected compiled artifact, while a framework-specific build uses that target's compile-time references, conditional code, and dependency graph and produces a distinct NuGet asset. Link the explanation to the existing target-selection guidance and distinguish behavioral testing from packaging support. Coordinate edits with dotnet/docs#25018 rather than create competing changes to the same article.

**Acceptance criteria:** The text doesn't equate test coverage with generating an additional target asset. If it includes a package example, inspect the packed target folders and restore selection, then test the stated runtime matrix and record results. Use supported targets instead of reinstating the obsolete `net461` recommendation.

### dotnet/docs#25758: Add multiline tuple formatting examples

**Issue:** [dotnet/docs#25758](https://github.com/dotnet/docs/issues/25758). **Opened:** August 21, 2021. **Size:** Small. **GHCP suitability:** Suitable for an example aligned with existing conventions, with F# style review.

**Why it still applies:** The [tuple-expression section](../docs/fsharp/style-guide/formatting.md#formatting-tuple-expressions) still shows only short tuples. The same guide now places closing parentheses on separate lines in multiline tupled arguments and union-case applications, but doesn't demonstrate the requested standalone/nested tuple case.

**Proposed assignment scope:** Add a multiline tuple example and explain the corresponding closing-parenthesis placement, consistent with the guide's existing multiline application examples. Link related conventions rather than repeat a new global policy. Preserve compact short tuples; don't reinterpret the request as a mandate to reformat every example or invent a Fantomas option.

**Acceptance criteria:** Compile the examples and check them against the current Fantomas version and relevant settings. Record any formatter/configuration assumptions and obtain F# style review. Keep the change local to the missing example and explanation.

### dotnet/docs#26016: Explain why a custom repository abstraction is optional

**Issue:** [dotnet/docs#26016](https://github.com/dotnet/docs/issues/26016). **Opened:** September 8, 2021. **Size:** Small, prose only. **GHCP suitability:** Strong for a localized architecture clarification.

**Why it still applies:** The [persistence-layer chapter](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design.md) explains that EF Core's `DbContext` already implements repository/unit-of-work concepts, but ends its optional-repository discussion with a quotation and an unhelpful choice to use the pattern or not. Earlier wording also says updates must use repositories without distinguishing a custom interface from the abstraction EF Core already supplies.

**Proposed assignment scope:** Explain that the optional decision concerns an additional, custom repository abstraction over EF Core, not whether persistence or aggregate invariants matter. Contrast that abstraction with application handlers that use `DbContext` directly, and describe the relevant coupling/testing trade-offs. Reconcile the earlier unconditional wording and preserve the chapter's separation of domain rules from infrastructure dependencies. Link existing EF Core and architecture guidance rather than prescribe one universal architecture or rewrite the archived sample.

**Acceptance criteria:** The optional section directly explains what the reader can omit, what remains responsible for persistence, and which architectural trade-offs change. Obtain architecture review; no new repository implementation, mocking framework, or sample application is necessary.

### dotnet/docs#26219: Correct GetFunctionInfo2 buffer-count instructions

**Issue:** [dotnet/docs#26219](https://github.com/dotnet/docs/issues/26219). **Opened:** September 22, 2021. **Size:** Small. **GHCP suitability:** Strong; pair with dotnet/docs#26220 and coordinate with assignee `tommcdon`.

**Why it still applies:** The [GetFunctionInfo2 reference](../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-getfunctioninfo2-method.md) treats an element count as bytes, describes the scalar output-count pointer as a buffer, and suggests an undersized nonzero call reveals the total required capacity. The runtime's [profiler implementation](https://github.com/dotnet/runtime/blob/main/src/coreclr/vm/proftoeeinterfaceimpl.cpp) instead returns the total generic-argument count for `cTypeArgs == 0`; a nonzero call caps the returned/copied count at the supplied capacity.

**Proposed assignment scope:** Replace the incorrect comparison/retry advice with a two-call sequence: query the element count with zero capacity and a valid output-count pointer, allocate that many `ClassID` elements, and retrieve them with the resulting capacity. Correct the parameter descriptions and references to the `typeArgs` buffer. Remove the divisions by `sizeof(ClassID)` and don't describe `pcTypeArgs` as an array.

**Acceptance criteria:** Verify the zero-capacity and undersized-buffer semantics against the profiler contract and applicable Framework implementation, with profiler-owner review. If the eventual PR includes code, test zero, insufficient, and sufficient capacity on a known generic method. Don't claim a nonzero undersized call returns the total count or that modern-runtime source alone establishes every historical Framework version's behavior.

### dotnet/docs#26220: Correct GetClassIDInfo2 buffer-count instructions

**Issue:** [dotnet/docs#26220](https://github.com/dotnet/docs/issues/26220). **Opened:** September 22, 2021. **Size:** Small. **GHCP suitability:** Strong as the second page in the owner-coordinated profiler-count fix.

**Why it still applies:** The [GetClassIDInfo2 reference](../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-getclassidinfo2-method.md) still says an undersized call can return a count larger than its nonzero capacity. In the [runtime implementation](https://github.com/dotnet/runtime/blob/main/src/coreclr/vm/proftoeeinterfaceimpl.cpp), zero capacity returns the total generic-argument count; a nonzero call reports only the count that fits and is copied.

**Proposed assignment scope:** Make the zero-capacity size query the documented allocation procedure. Specify that capacities/counts measure `ClassID` elements, clarify the output-count parameter for each call mode, and remove the misleading larger-than-capacity retry test. Keep names specific to this method (`cNumTypeArgs` and `pcNumTypeArgs`) rather than copy the other page's parameter names.

**Acceptance criteria:** Use the same contract/Framework-version review and zero/insufficient/sufficient-capacity checks as dotnet/docs#26219. Deliver both pages in one coordinated change with `tommcdon`; these are two issues, not two independent implementations.

### dotnet/docs#26381: Define Visual Basic binding by member resolution

**Issue:** [dotnet/docs#26381](https://github.com/dotnet/docs/issues/26381). **Opened:** October 5, 2021. **Size:** Small. **GHCP suitability:** Strong for a language-rule correction with focused examples.

**Why it still applies:** The [early/late binding article](../docs/visual-basic/programming-guide/language-features/early-late-binding/index.md) still defines binding as assignment to an object variable and labels every assignment to `Object` as late binding. That wording conflates the variable's declared type with how a particular member access is resolved.

**Proposed assignment scope:** Define early versus late binding at the member-access/call site. Contrast a statically typed receiver with an `Object` receiver whose member isn't resolved until runtime, and explain `Option Strict` restrictions. Distinguish storing a reference as `Object`, calling a statically known `Object` member, constructing an object through `CreateObject`, and explicitly invoking reflection. Don't claim that every `Object` variable, `CreateObject` call, or reflection operation is itself a VB late-bound member call.

**Acceptance criteria:** Compile/run small positive examples and separately verify the prohibited late-bound call with `Option Strict On`. Record the compiler diagnostic and actual output in the implementation PR. Keep examples local and avoid an Office/COM installation dependency merely to demonstrate the language distinction.

### dotnet/docs#26537: Complete image schema and preprocessing guidance

**Issue:** [dotnet/docs#26537](https://github.com/dotnet/docs/issues/26537). **Opened:** October 15, 2021. **Size:** Medium. **GHCP suitability:** Suitable for the explicit remaining sections, coordinated with assignees `zewditu` and `luisquintanilla`.

**Why it still applies:** The [load-data guide](../docs/machine-learning/how-to-guides/load-data-ml-net.md#load-images) now includes image-path loading and an in-memory encoded-byte example. However, the [prepare-data guide](../docs/machine-learning/how-to-guides/prepare-data-ml-net.md) has no image-preprocessing section, and the [image transformation table](../docs/machine-learning/resources/transforms.md#image-transformations) doesn't link to that requested walkthrough. The loading examples also don't explain the requested image-column type/schema distinction. [dotnet/docs#40993](https://github.com/dotnet/docs/pull/40993) merged, but that partial coverage doesn't fulfill all three explicit requirements; the earlier [dotnet/docs#32972](https://github.com/dotnet/docs/pull/32972) closed without merge.

**Proposed assignment scope:** Preserve the existing loading work and finish the image-column/schema explanation, with accurate distinctions between file paths, encoded byte vectors, and decoded image columns (`ImageDataViewType`). Explain the applicable image attribute/schema APIs rather than suggest that `ImageDataViewType` itself is an attribute. Add a short, executable image preprocessing pipeline to the prepare-data guide, using documented transforms such as resize and pixel extraction, and link it from the image table. Use the issue's linked ML.NET sample and current API contracts as sources, not an invented model workflow.

**Acceptance criteria:** Run the file-backed and in-memory variants on a known image, inspect the resulting data-view schema, and verify output dimensions/pixel-vector shape for the chosen transforms. State package/platform requirements and dispose image resources correctly. Follow the repository's language/snippet conventions and include actual outputs in the implementation PR. Don't close the issue merely because the loading PR merged.

### dotnet/docs#26766: Separate semaphore wait duration from internal spinning

**Issue:** [dotnet/docs#26766](https://github.com/dotnet/docs/issues/26766). **Opened:** November 2, 2021. **Size:** Small. **GHCP suitability:** Strong for a source-backed correction to the introductory guidance.

**Why it still applies:** The [semaphore overview](../docs/standard/threading/semaphore-and-semaphoreslim.md) now elaborates on short waits, but introduces microsecond/millisecond categories and recommends `Semaphore` whenever waits are long or unpredictable. It still doesn't clearly answer the question about a long overall wait. The [SemaphoreSlim implementation](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Threading/SemaphoreSlim.cs) exposes timeout/cancellation contracts and asynchronous waiter tasks; those aren't a short-duration correctness limit.

**Proposed assignment scope:** State that a long overall wait doesn't by itself make `SemaphoreSlim` invalid, and link its timeout/cancellation APIs. Distinguish a synchronous wait's bounded internal spin optimization from the duration of the entire wait and from `WaitAsync`, which doesn't occupy a thread for the pending wait. Remove the unsupported duration categories and blanket long-wait recommendation. Keep named/cross-process coordination as a separate reason to choose `Semaphore`.

**Acceptance criteria:** Review the explanation against both synchronous and asynchronous paths and their API contracts. Don't promise a universal performance winner or imply that an async I/O wait requires minutes of CPU spinning. If a timeout example is added, verify the documented argument range and cancellation behavior; a quick uncontended run isn't evidence that a wait actually lasted the stated duration.

### dotnet/docs#26834: Link to a C# cancel-after-first-completion example

**Issue:** [dotnet/docs#26834](https://github.com/dotnet/docs/issues/26834). **Opened:** November 5, 2021. **Size:** Small to medium. **GHCP suitability:** Suitable for a bounded missing example and navigation fix.

**Why it still applies:** The [VB cancel-after-one-completes article](../docs/visual-basic/programming-guide/concepts/async/cancel-remaining-async-tasks-after-one-is-complete.md) still has no C# counterpart link. The existing [C# cancellation tutorial](../docs/csharp/asynchronous-programming/cancel-an-async-task-or-a-list-of-tasks.md) cancels on user input, while the [C# WhenAny walkthrough](../docs/csharp/asynchronous-programming/start-multiple-async-tasks-and-process-them-as-they-complete.md) processes all downloads. Neither demonstrates the same first-completion/cancel-the-rest workflow.

**Proposed assignment scope:** Add a focused C# example to the existing WhenAny walkthrough: start operations once with a shared cancellation token, await `WhenAny`, request cancellation of the remaining operations, await the selected task for its result or failure, and observe completion of the other tasks before cleanup. Link directly to that section from the VB article. Reuse existing guidance and snippet infrastructure rather than create another full WPF tutorial or mislabel the user-input example as equivalent.

**Acceptance criteria:** Verify a successful first completion, a first-task failure, and cancellation of the remaining work with controlled tasks or a local test endpoint. Make clear that `WhenAny` neither starts tasks nor cancels them automatically, and that first completion isn't necessarily first success. Don't hide unrelated failures or dispose the token source while dependent work remains active. Record actual output and keep the existing process-all-tasks workflow intact.

### dotnet/docs#26886: Demonstrate the custom logging event name

**Issue:** [dotnet/docs#26886](https://github.com/dotnet/docs/issues/26886). **Opened:** November 9, 2021. **Size:** Small. **GHCP suitability:** Strong; the existing sample and missing observable value are explicit.

**Why it still applies:** The [source-generation examples](../docs/core/extensions/logging/source-generation.md#more-logging-examples) set `EventName = "CustomEventName"` in `LogWithCustomEventName`, but both displayed formatter outputs show only the numeric event ID and message. Neither output demonstrates the configured name.

**Proposed assignment scope:** Explain that event-name display depends on the provider/formatter and that the shown built-in console outputs don't expose the name. Add a minimal, clearly identified observation of `EventId.Name`, through an appropriate test logger or small custom formatter, and display its actual output for the existing generated method. Keep the SimpleConsole/JsonConsole examples accurate; don't fabricate an `EventName` property in built-in JSON output or change the message text as a substitute for the event name.

**Acceptance criteria:** Run the source-generated method through the chosen observer and show `CustomEventName` with event ID 9. Verify both existing formatter outputs separately if they change, and include commands/results in the implementation PR. Don't imply that setting `LoggerMessageAttribute.EventName` forces every provider to print it.

### dotnet/docs#27011: Explain the newline search through the selected overload

**Issue:** [dotnet/docs#27011](https://github.com/dotnet/docs/issues/27011). **Opened:** November 10, 2021. **Size:** Small. **GHCP suitability:** Suitable for a focused example with globalization review.

**Why it still applies:** The old comparison article now redirects to [string best practices](../docs/standard/base-types/best-practices-strings.md). Its [overload explanation](../docs/standard/base-types/best-practices-strings.md#specify-string-comparisons-explicitly) correctly distinguishes `IndexOf(string)` from `IndexOf(char)`, but the specific newline-search clarification/example remains absent. Its cross-runtime section instead discusses null/control characters.

**Proposed assignment scope:** Add the requested CRLF/newline example to the current guide, not the redirected file. Explain that the string overload selects a culture-sensitive comparer regardless of whether a human considers the searched character linguistic. Contrast that default with explicit `StringComparison.Ordinal`, and link the behavioral example to the overload explanation. Preserve the existing redirect and avoid a new duplicate article.

**Acceptance criteria:** Verify the ordinal result is 6 for the issue's exact string in both documentation languages. Record actual culture-sensitive results with runtime, culture, globalization backend, and relevant ICU/NLS version. Review nearby control-character claims against those results; don't copy the issue's 2021 platform/output table as a guarantee for every current ICU version.

### dotnet/docs#27082: Link the BCL overview to its source inventory

**Issue:** [dotnet/docs#27082](https://github.com/dotnet/docs/issues/27082). **Opened:** November 15, 2021. **Size:** Very small, prose and links. **GHCP suitability:** Strong; the issue explicitly accepts a repository link.

**Why it still applies:** The former Framework Libraries page redirects to the [core-library overview](../docs/standard/class-library-overview.md). That overview lists example types and links the API browser, but doesn't identify the [runtime library source directory](https://github.com/dotnet/runtime/tree/main/src/libraries) as the requested inventory.

**Proposed assignment scope:** Add a short source/discovery paragraph with the repository link and the existing API-browser link. Explain that namespaces, assemblies, source folders, and NuGet packages aren't interchangeable inventories. Distinguish runtime-shipped libraries from optional extensions instead of promising that every source directory is an assembly in every shared framework.

**Acceptance criteria:** Both links resolve and readers can reach the source inventory from the old URL's current destination. Don't maintain a new exhaustive hand-written list or move the article.

### dotnet/docs#27142: Distinguish recommendation Score from the input Label

**Issue:** [dotnet/docs#27142](https://github.com/dotnet/docs/issues/27142). **Opened:** November 18, 2021. **Size:** Small. **GHCP suitability:** Strong for a localized schema/explanation correction.

**Why it still applies:** The [movie-recommendation tutorial](../docs/machine-learning/tutorials/movie-recommendation.md#use-your-model) correctly calls `Score` the predicted rating, and its current branch already tests `movieRatingPrediction.Score`. However, `MovieRatingData.cs` still exposes an unused `Label` on `MovieRatingPrediction`, without explaining why the input label isn't a second prediction. The wording about likelihood can also reinforce the reporter's incorrect confidence-score interpretation.

**Proposed assignment scope:** Explain the training/observed `Label` versus predicted numeric `Score`, and state that the regression-style score isn't an accuracy or probability estimate. Remove the unnecessary prediction-output `Label` if the verified schema permits, while preserving the training input's label. Align the explanation with the existing recommendation threshold instead of claiming the current code still tests the wrong property.

**Acceptance criteria:** Run the tutorial's prediction path and show which value controls the recommendation. Test values around the threshold and preserve or explicitly explain the existing rounding behavior. Don't promise the same trained score on every package/platform, remove the training label, or broaden the change to unrelated evaluation-metric corrections.

### dotnet/docs#27156: Explain the queue behind a saturated connection pool

**Issue:** [dotnet/docs#27156](https://github.com/dotnet/docs/issues/27156). **Opened:** November 18, 2021. **Size:** Small. **GHCP suitability:** Suitable for a narrowly versioned networking explanation.

**Why it still applies:** The former Framework connection-management page redirects to the [HTTP overview](../docs/fundamentals/networking/http/http-overview.md), which doesn't answer whether saturation queues requests or immediately throws. The Framework reference source's [connection group](https://github.com/microsoft/referencesource/blob/main/System/net/System/Net/_ConnectionGroup.cs) selects a busy connection when it can't create another, and its [connection implementation](https://github.com/microsoft/referencesource/blob/main/System/net/System/Net/_Connection.cs) adds waiting requests to `m_WaitList`.

**Proposed assignment scope:** Add a Framework-specific explanation in the [ServicePointManager migration section](../docs/fundamentals/networking/http/httpclient-migrate-from-httpwebrequest.md#migrate-servicepointmanager-usage), with a discoverable link from the current overview. Explain that requests can wait for capacity in the affected pool/group rather than fail solely because the limit is reached, and that timeout/cancellation can still end the wait. Link the modern handler's connection-limit API separately.

**Acceptance criteria:** Verify a queued request resumes after capacity is released and a separately configured timeout/cancellation ends a blocked request. Scope any executable example to its actual runtime and HTTP version. Don't equate connection counts with HTTP/2 or HTTP/3 concurrent streams, treat the limit as process-wide, or recommend legacy `ServicePointManager` configuration indiscriminately for modern clients.

### dotnet/docs#27211: Explain test-template package versions and the outdated check

**Issue:** [dotnet/docs#27211](https://github.com/dotnet/docs/issues/27211). **Opened:** November 21, 2021. **Size:** Very small. **GHCP suitability:** Strong for the explicit documentation fallback offered by the reporter.

**Why it still applies:** The [current MSTest tutorial](../docs/core/testing/unit-testing-csharp-with-mstest.md#create-the-test-project) uses `dotnet new mstest` and shows a versioned package example, but doesn't explain that template versions follow the installed SDK/template or how to check for newer stable packages.

**Proposed assignment scope:** Add a brief version note and link the [.NET package outdated check](../docs/core/tools/dotnet-package-list.md). Use the current `dotnet package list --outdated` spelling for .NET 10, with older syntax only if the tutorial's supported scope needs it. Explain compatibility review rather than promise that templates always use the latest NuGet release or instruct readers to upgrade every package automatically. Coordinate the same tutorial's edits with dotnet/docs#24897.

**Acceptance criteria:** Run the note's command on the generated test project and record its actual result. Preserve the tutorial's deliberate fail/pass sequence and don't add duplicate package-install commands or pin a new version solely to make the prose appear current.

### dotnet/docs#27240: Explain explicit SRTP member invocation syntax

**Issue:** [dotnet/docs#27240](https://github.com/dotnet/docs/issues/27240). **Opened:** November 23, 2021. **Size:** Small to medium. **GHCP suitability:** Suitable for bounded syntax examples with F# review.

**Why it still applies:** The [SRTP guide](../docs/fsharp/language-reference/generics/statically-resolved-type-parameters.md) now demonstrates simpler F# 7 member calls, but still includes complex explicit constraint invocations without explaining their final expression/argument syntax. The property-getter, instance receiver, and static-argument distinctions requested by the issue remain implicit.

**Proposed assignment scope:** Add a compact explanation of the explicit invocation's type parameter/signature and supplied expression. Demonstrate a property getter, an instance method, and a static member, including where the receiver belongs and when arguments form a tuple. Explain the existing type-disjunction form without replacing modern simplified calls. Cross-link the related constraints/generics pages to that one explanation.

**Acceptance criteria:** Compile and execute examples against a stable F# compiler, use more than one concrete type where appropriate to demonstrate SRTP behavior, and record outputs. Distinguish F# 7 simplifications from syntax that still requires `^`; don't claim an untested receiver/unit-tuple form is equivalent.

### dotnet/docs#27254: Explain nullable analysis alongside CA1062 runtime guards

**Issue:** [dotnet/docs#27254](https://github.com/dotnet/docs/issues/27254). **Opened:** November 24, 2021. **Size:** Small. **GHCP suitability:** Strong for a scoped analyzer/language clarification.

**Why it still applies:** The [CA1062 article](../docs/fundamentals/code-analysis/quality-rules/ca1062.md) describes explicit null validation, but doesn't discuss C# nullable contexts or a null-coalescing throw expression, both expressly requested.

**Proposed assignment scope:** Explain that nullable annotations and compiler analysis don't insert runtime argument guards or prevent callers from passing null. Link `#nullable`/project nullable configuration and demonstrate a valid modern guard, including the requested C# `?? throw` form where appropriate. Keep C# nullable-only features distinct from the existing VB `Nothing` checks, and describe CA1062 behavior for the analyzer version actually verified rather than assume annotations always enable or suppress it.

**Acceptance criteria:** Explicitly enable CA1062, state SDK/analyzer/settings, and verify guarded/unguarded cases under the stated nullable contexts. Exercise both null and non-null inputs in any new samples. Don't describe warning suppression or a non-nullable declaration as runtime validation.

### dotnet/docs#27267: Distinguish a faulted Task from an unhandled worker exception

**Issue:** [dotnet/docs#27267](https://github.com/dotnet/docs/issues/27267). **Opened:** November 24, 2021. **Size:** Small, primarily prose and cross-links. **GHCP suitability:** Strong for a focused concurrency clarification.

**Why it still applies:** The [thread-pool exception section](../docs/standard/threading/the-managed-thread-pool.md#exceptions-in-thread-pool-threads) still presents process termination and three exceptions without distinguishing task infrastructure that captures an exception into a faulted task. Its linked managed-thread exception guide doesn't supply that missing distinction at the point of use.

**Proposed assignment scope:** Explain the difference between an exception that escapes a raw worker callback, one captured by a task/async-task method, and an `async void` exception dispatched through its context. Link the existing TPL exception-handling guidance and reconcile the related general-thread paragraph. Keep Framework-era unobserved-exception policy separate from current .NET behavior.

**Acceptance criteria:** If examples are added, run faulted-task and raw-worker/`async void` cases in separate child processes, record exit/output behavior, and state the synchronization context/runtime. Don't terminate the verification host, imply every async method runs on the pool, or claim that faulted tasks have no exceptions merely because the process survives.

### dotnet/docs#27273: Scope the thread-safety guideline to shared instance state

**Issue:** [dotnet/docs#27273](https://github.com/dotnet/docs/issues/27273). **Opened:** November 24, 2021. **Size:** Very small, prose only. **GHCP suitability:** Strong for the exact misleading sentence.

**Why it still applies:** The [class-library threading guidelines](../docs/standard/threading/managed-threading-best-practices.md#recommendations-for-class-libraries) still claim that common application models execute user code on only one thread at a time, then use that claim to justify instance thread-safety defaults. That conflates ownership of one instance with concurrency across an application.

**Proposed assignment scope:** Replace the application-wide claim with an explanation of instance ownership and caller synchronization when an instance is shared. Preserve the distinction between static/shared state and instance state. Contrast a thread-affine UI or an unshared request-owned instance with concurrent server code, and direct readers to each type's actual thread-safety contract.

**Acceptance criteria:** The guideline no longer implies that server applications serialize all user code or that every .NET type has the same guarantees. Keep the change local; no new lock implementation, benchmark, or whole-article threading rewrite is needed.

### dotnet/docs#27411: Select the analyzer's VSIX startup project explicitly

**Issue:** [dotnet/docs#27411](https://github.com/dotnet/docs/issues/27411). **Opened:** December 5, 2021. **Size:** Very small. **GHCP suitability:** Strong; the reporter confirms the exact successful step.

**Why it still applies:** The [analyzer tutorial](../docs/csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix.md#explore-the-analyzer-template) calls `MakeConst.Vsix` the default startup project and immediately says to press F5. It doesn't tell readers to select that startup project if Visual Studio chose a library instead. The reporter's final comment says that switching the startup project to the VSIX project works.

**Proposed assignment scope:** Instruct readers to set `MakeConst.Vsix` as the startup project before F5 and explain that the VSIX launcher opens the experimental Visual Studio instance. Remove the unconditional default-selection assumption. Coordinate the tutorial edit with the CS8032 PR's requested signpost rather than expand this issue into a general template modernization.

**Acceptance criteria:** Verify the Visual Studio startup-project selection and experimental-instance launch with the stated template/IDE version. A successful `dotnet build` alone doesn't prove the F5 workflow. Don't tell readers to run the analyzer class library directly.

### dotnet/docs#27432: Summarize compilation-setting trade-offs and appropriate scenarios

**Issue:** [dotnet/docs#27432](https://github.com/dotnet/docs/issues/27432). **Opened:** December 7, 2021. **Size:** Small to medium, prose and a table. **GHCP suitability:** Suitable with runtime-performance review.

**Why it still applies:** The old URL redirects to the [current compilation settings](../docs/core/runtime-config/compilation.md). Quick JIT already has some startup/optimization trade-offs, but the article doesn't provide the requested consistent use/avoid overview across tiering, loops, ReadyToRun, dynamic-code testing, and PGO.

**Proposed assignment scope:** Add a concise scenario/trade-off table based on the existing runtime design and [ReadyToRun guidance](../docs/core/deploying/ready-to-run.md). Distinguish startup cost, steady-state optimization, instrumentation, and publish size without universal speedup promises. Identify `DynamicCodeSupport` as a fallback-test switch rather than a substitute for an actual Native AOT publish. Reconcile loop/default claims with the documented stable runtime and on-stack replacement.

**Acceptance criteria:** Obtain performance-owner review and scope version/platform-dependent recommendations. The [.NET 10 configuration source](https://github.com/dotnet/runtime/blob/v10.0.0/src/coreclr/inc/clrconfigvalues.h) defaults `TC_QuickJitForLoops` differently depending on on-stack-replacement support and enables tiered PGO; don't repeat legacy blanket defaults as universal current behavior. No benchmark percentages or workload thresholds should appear without actual evidence.

### dotnet/docs#27442: Demonstrate enumeration-class values and lookup

**Issue:** [dotnet/docs#27442](https://github.com/dotnet/docs/issues/27442). **Opened:** December 7, 2021. **Size:** Small to medium. **GHCP suitability:** Strong for a bounded usage example based on the linked implementation.

**Why it still applies:** The [enumeration-class chapter](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types.md) defines an abridged `Enumeration` and `CardType` but doesn't use their IDs/names in an example. The [full sample implementation on `main`](https://github.com/dotnet-architecture/eShopOnContainers/blob/main/src/Services/Ordering/Ordering.Domain/SeedWork/Enumeration.cs) includes `GetHashCode`, `FromValue`, and `FromDisplayName`, which the displayed class omits.

**Proposed assignment scope:** Show use of `CardType` values, their stable identifier and display name, enumeration through `GetAll`, and a lookup using an implementation actually supplied to the reader. Clearly label abridged code and link the verified full source, or include the needed complete implementation in executable snippets. Don't call `FromValue` as though it exists in the current abridged class.

**Acceptance criteria:** Run the example and verify ID/name, enumeration, successful lookup, and invalid-value behavior. Preserve equality/hash consistency if the implementation is included. Treat the archived class as an illustration, not an automatic ORM/serialization or trimming/AOT guarantee, and don't broaden the task to unrelated serialization documentation raised in a later comment.

### dotnet/docs#27545: Execute the WAL pragma as SQL, not a connection-string keyword

**Issue:** [dotnet/docs#27545](https://github.com/dotnet/docs/issues/27545). **Opened:** December 14, 2021. **Size:** Small. **GHCP suitability:** Strong; the missing operation and expected result are explicit.

**Why it still applies:** The [provider-comparison table](../docs/standard/data/sqlite/compare.md#connection-strings) says to send `PRAGMA journal_mode = <mode>` instead of the `Journal Mode` keyword, but shows no command execution. The [connection-string reference](../docs/standard/data/sqlite/connection-strings.md) doesn't make that missing example discoverable.

**Proposed assignment scope:** Add a short example that opens a writable file-backed `SqliteConnection`, creates a SQL command for `PRAGMA journal_mode=WAL`, executes it, and checks/displays the returned mode. Explicitly say not to append `Journal Mode` or the pragma text as unsupported connection-string keywords. Link the relevant supported-keyword guidance and keep the operation outside an active transaction.

**Acceptance criteria:** Run both language samples on an owned file-backed fixture and verify the returned/read-back mode is `wal`. Don't substitute an in-memory database, which has different journal-mode behavior, or hide a failure to switch modes. Isolate fixture pooling/cleanup without deleting user databases or changing process-wide pool state merely for convenience.

### dotnet/docs#27634: Clarify that native-to-managed entry doesn't establish fiber support

**Issue:** [dotnet/docs#27634](https://github.com/dotnet/docs/issues/27634). **Opened:** December 20, 2021. **Size:** Small, prose only. **GHCP suitability:** Suitable for a support-boundary clarification with runtime-owner review.

**Why it still applies:** The [fiber warning](../docs/standard/threading/managed-and-unmanaged-threading-in-windows.md#threads-and-fibers) says not to call unmanaged functions implemented with fibers. It doesn't explicitly address the reverse direction asked here: a native fiber entering managed code. In [dotnet/runtime#11373](https://github.com/dotnet/runtime/issues/11373), the runtime owner states that fibers aren't supported; the later fix hardens exception handling around native-only fibers rather than promises managed execution on their stacks.

**Proposed assignment scope:** Clarify that incidental success through COM/native-to-managed entry isn't a supported modern-.NET fiber execution model. Distinguish the native-only exception-handler hardening from support for managed execution, and direct managed entry to supported OS-thread/interop paths. Keep historical Framework-hosting differences appropriately scoped and reviewed.

**Acceptance criteria:** Obtain runtime-owner confirmation of the support wording. Don't turn the reporter's stack-guarantee experiments into supported thresholds, claim the linked runtime fix added fiber support, or introduce a native stack-switching workaround/sample.

### dotnet/docs#27653: Explain the locality requirement for live analyzer code fixes

**Issue:** [dotnet/docs#27653](https://github.com/dotnet/docs/issues/27653). **Opened:** December 22, 2021. **Size:** Small. **GHCP suitability:** Strong, with Roslyn review and an IDE-level check.

**Why it still applies:** The [analyzer/code-fix tutorial](../docs/csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix.md) doesn't explain why a reported analyzer diagnostic can appear without the IDE invoking its registered code-fix provider. The [Roslyn owner's explanation](https://github.com/dotnet/roslyn/issues/57621#issuecomment-999347642) identifies the non-local diagnostic in the linked reproduction and explicitly endorses a tutorial explanation.

**Proposed assignment scope:** Add a focused troubleshooting note and a small contrasting example. Explain that a symbol/node callback that reports on an unrelated base declaration can produce a non-local diagnostic outside the callback's analyzed declaration. Explain the live code-fix limitation and show a local diagnostic location instead. Distinguish the diagnostic's location from the documents a code action can edit; don't state that code fixes can never change another document.

**Acceptance criteria:** Reproduce the local/non-local contrast in the stated supported Visual Studio/Roslyn environment, confirm actual light-bulb availability, and record the results. A passing code-fix unit test alone doesn't establish the IDE behavior. Keep the diagnostic's meaning intact; don't recommend an always-present informational diagnostic or a new analyzer rule as a workaround. Coordinate this tutorial edit with the existing VSIX-startup and CS8032 tasks.

### dotnet/docs#27818: Correct the CA2215 derived-dispose example

**Issue:** [dotnet/docs#27818](https://github.com/dotnet/docs/issues/27818). **Opened:** January 12, 2022. **Size:** Small. **GHCP suitability:** Strong; the current samples expose the exact missing base call.

**Why it still applies:** The [CA2215 article](../docs/fundamentals/code-analysis/quality-rules/ca2215.md#example) calls its derived implementation correct, but both language snippets call the base method only when `disposing` is false. A public `Dispose()` call passes true and skips the base cleanup. The snippets also imply that every disposable type needs a finalizer.

**Proposed assignment scope:** Replace the inconsistent example with clear violating/corrected derived-dispose snippets in C# and Visual Basic, aligned with the [canonical dispose guidance](../docs/standard/garbage-collection/implementing-dispose.md). In the corrected override, call `base.Dispose(disposing)` or `MyBase.Dispose(disposing)` on both paths. Remove the blanket finalizer claim and any unnecessary finalizer boilerplate; use one only if the example actually owns an unmanaged resource. Don't copy the issue's proposed unconditional `base.Dispose(true)` onto the false/finalizer path.

**Acceptance criteria:** Run both samples and make base cleanup observable for true and false paths. Enable CA2215 explicitly and record the actual diagnostic results as well as runtime behavior; the absence of a warning alone doesn't prove both paths are correct. Preserve the canonical managed/unmanaged cleanup distinction and deterministic public disposal.

### dotnet/docs#27878: Document TensorFlow native redistributable requirements

**Issue:** [dotnet/docs#27878](https://github.com/dotnet/docs/issues/27878). **Opened:** January 18, 2022. **Size:** Small to medium. **GHCP suitability:** Strong for a release-scoped dependency section, with ML.NET review.

**Why it still applies:** The [extra-dependencies guide](../docs/machine-learning/how-to-guides/install-extra-dependencies.md) has no TensorFlow section. Individual tutorials mention SciSharp packages, but don't supply the central compatibility explanation requested here. In [dotnet/machinelearning#6040](https://github.com/dotnet/machinelearning/issues/6040), the owner identifies an incompatible native version and points to the release's version file; [dotnet/machinelearning#6047](https://github.com/dotnet/machinelearning/issues/6047) identifies the missing redistributable.

**Proposed assignment scope:** Add a TensorFlow subsection that distinguishes `Microsoft.ML.TensorFlow`/`Microsoft.ML.Vision`, managed `TensorFlow.NET` bindings, and the separately required native redistributable. Choose and name a supported ML.NET release, and obtain its matching versions from that release's source/package metadata. For example, the checked [v5.0.1 version file](https://github.com/dotnet/machinelearning/blob/v5.0.1/eng/Versions.props) specifies TensorFlow 2.16.0 and different Windows/Linux GPU versions; don't universally prescribe the older issue's 2.3.1 or install the latest native package independently. Link the relevant tutorials and distinguish missing-library failures from missing-entry-point/version mismatches.

**Acceptance criteria:** Restore and run a minimal TensorFlow model with the stated package versions, OS, architecture, and CPU/GPU variant. Record successful native loading and inference, and qualify platform/hardware prerequisites. Don't promise that installing a redistributable fixes unsupported CPU instructions, every GPU configuration, or arbitrary TensorFlow upgrades. Leave unrelated MKL installation instructions outside this task.

### dotnet/docs#27904: State the transaction boundary for nested domain-event saves

**Issue:** [dotnet/docs#27904](https://github.com/dotnet/docs/issues/27904). **Opened:** January 20, 2022. **Size:** Small to medium. **GHCP suitability:** Suitable for a source-backed clarification, with EF Core/architecture review.

**Why it still applies:** The [domain-events chapter](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/domain-events-design-implementation.md) equates a shared scoped context and deferred dispatch with one transaction, yet shows an event handler that calls `SaveEntitiesAsync` again. It doesn't explain the outer transaction that makes the reference application's repeated saves atomic.

**Why the solution is defined:** The actual archived [TransactionBehaviour](https://github.com/dotnet-architecture/eShopOnContainers/blob/main/src/Services/Ordering/Ordering.API/Application/Behaviors/TransactionBehaviour.cs) begins a transaction around the handler pipeline and commits afterward. [OrderingContext](https://github.com/dotnet-architecture/eShopOnContainers/blob/main/src/Services/Ordering/Ordering.Infrastructure/OrderingContext.cs) distinguishes `SaveEntitiesAsync`/`SaveChangesAsync` from `CommitTransactionAsync`. Multiple saves inside that explicit transaction aren't separate outer commits.

**Proposed assignment scope:** Explain and link the actual outer transaction, distinguish a save from a transaction commit, and qualify the sample's atomicity claims. State that a shared context alone doesn't make several independent saves one transaction. Preserve the chapter's alternative eventual-consistency model. Don't introduce the proposed recursion counter as though it establishes a database transaction or solves arbitrary event-dispatch reentrancy.

**Acceptance criteria:** Demonstrate with a relational provider that a later handler failure rolls back earlier saves inside the explicit transaction, and contrast the no-outer-transaction case. Don't substitute EF's in-memory provider as transaction evidence. Keep the clarification about the archived design rather than promise exactly-once events or universal atomicity across external services.

### dotnet/docs#27943: Explain Roslyn component API-version packaging

**Issue:** [dotnet/docs#27943](https://github.com/dotnet/docs/issues/27943). **Opened:** January 24, 2022. **Size:** Medium. **GHCP suitability:** Suitable for a bounded packaging guide, with SDK/Roslyn review.

**Why it still applies:** The current [Roslyn SDK documentation](../docs/csharp/roslyn-sdk/index.md) doesn't document `SupportsRoslynComponentVersioning` or versioned component selection. The issue specifies three concrete topics: when multiple compiler-API builds are needed, package selection with and without SDK support, and use of newer APIs.

**Why the solution is defined:** [dotnet/sdk#20793](https://github.com/dotnet/sdk/pull/20793) merged on September 14, 2021 and implements highest-compatible Roslyn asset selection. The [.NET 10 SDK targets](https://github.com/dotnet/sdk/blob/v10.0.100/src/Tasks/Microsoft.NET.Build.Tasks/targets/Microsoft.PackageDependencyResolution.targets) still advertise the capability and pass the compiler API version to package resolution. The property is a capability to inspect, not a switch that makes an old host support newer compiler APIs.

**Proposed assignment scope:** Add one Roslyn SDK article with a minimal two-version component package. Explain compiler-API minima versus runtime TFMs, the supported versioned analyzer folder layout, highest-compatible selection, package-authored fallback logic when the capability isn't available, and separate builds/conditional code for APIs absent from the older reference. Add the TOC entry and links from the analyzer tutorial and Roslyn SDK landing page. Coordinate a source-generator signpost with the existing draft [dotnet/docs#51546](https://github.com/dotnet/docs/pull/51546); that conceptual/tutorial PR doesn't implement this packaging guide.

**Acceptance criteria:** Build the package, inspect its analyzer assets, and consume it in concrete compatible-host scenarios that prove the selected assembly. Verify the legacy fallback with an actual applicable host/toolchain; merely setting the property false in a new SDK doesn't prove older SDK behavior. Include an incompatibility case and don't conflate application target frameworks, SDK versions, and the actual IDE/compiler host. Coordinate the earlier CS8032 compatibility guidance rather than duplicate its general troubleshooting text.

### dotnet/docs#28330: Simplify the inherited-event example

**Issue:** [dotnet/docs#28330](https://github.com/dotnet/docs/issues/28330). **Opened:** February 21, 2022. **Size:** Small. **GHCP suitability:** Strong; the maintainer accepted the focused simplification.

**Why it still applies:** The [base-class event how-to](../docs/csharp/programming-guide/events/how-to-raise-base-class-events-in-derived-classes.md) still uses custom shape event arguments, geometry calculations, two derived shape types, and a container. Those details obscure the requested base-event/derived-caller pattern.

**Proposed assignment scope:** Make the primary example a small standalone program with one base event, one protected base method that raises it, one derived method that calls that method, and a subscriber that observes the event. Use ordinary `EventArgs` unless custom event data demonstrates a separate required concept. Preserve any unique advanced guidance through an appropriate link rather than require the geometry machinery to understand the first example. Keep the explanation that the derived class can't directly invoke the base-declared event.

**Acceptance criteria:** Run the example and verify one subscriber invocation with the expected sender. Publish the executable code through an article-relative snippet project and retain correct event accessibility/null-subscriber behavior. No Windows Forms dependency or event-system redesign is needed.

### dotnet/docs#28429: Show how to acquire and load a simple native SQLite extension

**Issue:** [dotnet/docs#28429](https://github.com/dotnet/docs/issues/28429). **Opened:** February 28, 2022. **Size:** Medium. **GHCP suitability:** Suitable for a deliberately platform-scoped recipe, with native-interoperability review.

**Why it still applies:** The [extensions guide](../docs/standard/data/sqlite/extensions.md) explains SQLite's native-loader behavior but points to a multi-runtime SpatiaLite/NuGet sample without a simple acquisition/build-and-load path. The owner's response recommends platform packages or a known Windows DLL, but the reporter's final comment still reports a load failure after a Cygwin build. The earlier acknowledgement isn't evidence that the final failure was resolved.

**Proposed assignment scope:** Explain that the provider doesn't supply every SQLite extension and that a compatible native binary comes from its actual publisher, an OS package, or a source build. Add one explicitly Windows/architecture-scoped worked example using a trusted SQLite example extension and the [official build instructions](https://www.sqlite.org/loadext.html). Open a connection, call `LoadExtension`, and execute a query that proves the extension works. Contrast the simple recipe with the existing multi-runtime dependency example rather than remove it.

**Acceptance criteria:** Build/acquire the named binary and run the complete C# and Visual Basic load/query examples under the stated architecture. Explain that an existing DLL can still fail because its dependencies, architecture, or runtime ABI don't match. Don't claim to diagnose the reporter's unavailable Cygwin binary, promise a universal NuGet package, or recommend blind system-directory copies, untrusted extension paths, or unnecessary permanent enablement of SQL-level extension loading.

### dotnet/docs#28466: Demonstrate data loading without named schema classes

**Issue:** [dotnet/docs#28466](https://github.com/dotnet/docs/issues/28466). **Opened:** March 3, 2022. **Size:** Small to medium. **GHCP suitability:** Strong; the requested loader APIs and target guide are explicit.

**Why it still applies:** The [load-data guide](../docs/machine-learning/how-to-guides/load-data-ml-net.md) demonstrates named model classes and attributed members but not the requested non-generic text-loader options and anonymous-type enumerable inputs. Current [TextLoader source](https://github.com/dotnet/machinelearning/blob/v5.0.1/src/Microsoft.ML.Data/DataLoadSave/Text/TextLoader.cs) supplies a default label/features layout; that isn't general inference of a string class label or arbitrary feature types.

**Proposed assignment scope:** Add class-free text-loading and anonymous-input examples to the existing guide. For the issue's Iris data, use explicit typed `TextLoader.Column` definitions to preserve the text label and numeric feature vector; explain the narrower default layout separately instead of silently turning class names into missing numeric values. Show `LoadFromEnumerable` over anonymous inputs and verify the original F# anonymous-record case. Supply C#/Visual Basic equivalents where applicable and distinguish automatic CLR-member schema discovery from inference of learning roles, column ranges, or fixed vector dimensions.

**Acceptance criteria:** Run the examples against a tiny owned dataset and check actual schema names/types, row values, and feature-vector length. The Iris label must remain the original text, not NaN or a default value. Verify each language's anonymous-input behavior rather than assume identical visibility/mutability rules. Coordinate with assignee `luisquintanilla` and the existing image-loading task in the same guide; no model training is required to prove these loading operations.

### dotnet/docs#28632: Distinguish static-holder design from inheritance prevention

**Issue:** [dotnet/docs#28632](https://github.com/dotnet/docs/issues/28632). **Opened:** March 11, 2022. **Size:** Small. **GHCP suitability:** Strong for a precise analyzer/language clarification.

**Why it still applies:** The [CA1052 article](../docs/fundamentals/code-analysis/quality-rules/ca1052.md) still says that a type not meant for inheritance should be marked `static`. That overgeneralizes the rule: `sealed` prevents C# inheritance without making a type a static holder. The Cause section also names `Shared` as though it were a valid Visual Basic class modifier, while the actual fix section correctly recommends a module.

**Proposed assignment scope:** Explain that the rule identifies types whose members don't need instances. Distinguish the instantiation and inheritance effects of C# `static` from the inheritance-only effect of `sealed`. Align the Cause, description, and fix sections for both languages, preserving the documented Visual Basic module alternative. Check the [analyzer implementation](https://github.com/dotnet/roslyn-analyzers/blob/main/src/NetAnalyzers/Core/Microsoft.CodeQuality.Analyzers/ApiDesignGuidelines/StaticHolderTypes.cs), which has a language-specific exception for sealed Visual Basic types; don't promise identical C#/VB detection or prescribe `Shared Class`.

**Acceptance criteria:** Obtain analyzer/language review and verify any changed examples with CA1052 enabled. A normal instance type that merely prohibits inheritance must not be presented as a static-holder candidate. Preserve the existing breaking-change warning and don't broaden the task into changing the analyzer's behavior.

### dotnet/docs#28677: Unwrap calibrated model parameters before retraining

**Issue:** [dotnet/docs#28677](https://github.com/dotnet/docs/issues/28677). **Opened:** March 15, 2022. **Size:** Small. **GHCP suitability:** Strong; the product discussion contains a tested resolution.

**Why it still applies:** The [retraining guide](../docs/machine-learning/how-to-guides/retrain-model-ml-net.md) describes algorithm-specific parameter casts but doesn't explain the calibrated binary-classification wrapper in the report. Casting that wrapper directly to linear model parameters isn't the correction.

**Why the solution is defined:** In [dotnet/machinelearning#6092](https://github.com/dotnet/machinelearning/issues/6092), the owner tested access through `CalibratedModelParametersBase.SubModel` followed by the appropriate linear-parameter type, and the reporter confirmed the solution. That product issue closed with the documentation follow-up tracked here.

**Proposed assignment scope:** Add a calibrated-model case to the existing parameter-extraction explanation. Use checked type patterns or explicit validation before the retraining call, not an unchecked `as` cast that can pass null. Select a trainer that actually supports the documented retraining overload, preserve the fitted preprocessing pipeline and feature representation, and distinguish the calibrated wrapper from the underlying trainable model.

**Acceptance criteria:** Train, save, reload, unwrap, and retrain a small calibrated binary model with supported ML.NET packages. Execute both C# and VB examples, record the parameter types and successful predictions, and show that an unsupported model type produces an explicit diagnostic rather than a null-dependent failure. Don't imply every calibrated trainer supports warm-start retraining.

### dotnet/docs#28793: Explain intentional parameter-name literals in CA1507 suppressions

**Issue:** [dotnet/docs#28793](https://github.com/dotnet/docs/issues/28793). **Opened:** March 24, 2022. **Size:** Very small. **GHCP suitability:** Strong for a localized explanation.

**Why it still applies:** The [CA1507 suppression guidance](../docs/fundamentals/code-analysis/quality-rules/ca1507.md#when-to-suppress-warnings) still describes suppression as appropriate when the developer isn't concerned about maintainability. The report supplies a legitimate maintainability reason: a test's expected exception parameter name belongs to the method under test, not to an unrelated test parameter with the same spelling.

**Proposed assignment scope:** Replace the dismissive rationale with an intent-based explanation. Describe the coincidentally matching-name case and a narrow suppression, while retaining the normal benefits of `nameof`. Don't recommend a project-wide rule disable, change the analyzer, or assume every assertion API triggers CA1507.

**Acceptance criteria:** If an example is added, reproduce CA1507 with the actual analyzed API and show that the literal still describes the production method's parameter after the unrelated test parameter is renamed. The final guidance must distinguish intentional independent text from a name that really should follow a symbol.

### dotnet/docs#28865: Align the completed LINQ sample with the tutorial

**Issue:** [dotnet/docs#28865](https://github.com/dotnet/docs/issues/28865). **Opened:** March 31, 2022. **Size:** Small. **GHCP suitability:** Strong for an example/link alignment.

**Why it still applies:** The [tutorial](../docs/csharp/tutorials/working-with-linq.md) now includes string-based iterator steps in `InterimSteps.cs`, but its completed-sample link still leads to the [external enum-based sample](https://github.com/dotnet/samples/tree/main/csharp/getting-started/console-linq). The local completed `Program.cs` also uses enums. The existence of interim examples therefore doesn't resolve the completed-sample mismatch. Related [dotnet/docs#47671](https://github.com/dotnet/docs/pull/47671) closed unmerged; its patch targets a legacy snippet path rather than the current project.

**Proposed assignment scope:** Make `docs/csharp/tutorials/snippets/console-linq` the consistent completed implementation of the documented steps, then point the tutorial's completed-sample link to that maintained project. Align the string iterators, calls, card representation, snippet markers, and final shuffle logic; update or remove obsolete enum-dependent support code as necessary. Don't apply the old patch to a deleted or superseded path, or require an uncoordinated change to `dotnet/samples`.

**Acceptance criteria:** Build and run the complete local project, verify the expected 52 distinct cards and both documented shuffle cycles, and check every extracted step against the final implementation. Preserve the tutorial's lazy-evaluation/performance demonstrations. The completed-sample link must lead to the verified matching project.

### dotnet/docs#29054: State AnalysisLevel defaults by target framework and SDK

**Issue:** [dotnet/docs#29054](https://github.com/dotnet/docs/issues/29054). **Opened:** April 13, 2022. **Size:** Small. **GHCP suitability:** Strong; current property evaluation reproduces the discrepancy.

**Why it still applies:** Both the [analysis overview](../docs/fundamentals/code-analysis/overview.md) and [AnalysisLevel reference](../docs/core/project-sdk/msbuild-props.md#analysislevel) still describe a blanket `latest` default. Evaluation of otherwise unconfigured C# projects with the installed stable SDK 10.0.403 returned `AnalysisLevel=5.0`, `8.0`, and `9.0` for `net5.0`, `net8.0`, and `net9.0`, respectively. Only the `net10.0` project returned `latest`, with `EffectiveAnalysisLevel=10.0`. This was property evaluation, not a build or a claim that the older targets remain supported.

**Proposed assignment scope:** Correct both descriptions from the supported SDK's analyzer targets. Explain the target-framework-based default, when it resolves to `latest`, how an SDK upgrade differs from a target-framework upgrade, and how an explicit value changes the behavior. Preserve the distinctions between rule availability, default enablement, severity, and `AnalysisMode`; verify any claims about explicitly configured modes or analyzer packages rather than infer them from the unconfigured case.

**Acceptance criteria:** Record SDK selection and evaluated properties for an older supported target, the SDK's current target, and explicit numeric/`latest` overrides. Both pages must agree with that matrix. A merged SDK fix alone isn't evidence that the current blanket wording is correct.

### dotnet/docs#29207: Explain ownership of native UTF-8 string return values

**Issue:** [dotnet/docs#29207](https://github.com/dotnet/docs/issues/29207). **Opened:** April 28, 2022. **Size:** Small. **GHCP suitability:** Suitable for a precise interop addition with allocator/ABI review.

**Why it still applies:** The former Framework URL redirects to the [current string-marshalling article](../docs/standard/native-interop/default-marshalling-for-strings.md), but that article still concentrates on parameters rather than the returned UTF-8 buffer in the report. Its parameter-ownership wording doesn't explain when a native return allocation is released.

**Why the solution is defined:** The .NET 10 [built-in UTF-8 IL marshaller](https://github.com/dotnet/runtime/blob/v10.0.0/src/coreclr/vm/ilmarshalers.cpp) converts the native return to a managed string and emits native cleanup. The called [UTF-8 marshaller implementation](https://github.com/dotnet/runtime/blob/v10.0.0/src/libraries/System.Private.CoreLib/src/System/Runtime/InteropServices/Marshalling/Utf8StringMarshaller.cs) uses `PtrToStringUTF8` for conversion and `FreeCoTaskMem` for that cleanup. The copied managed string's later collection isn't the native buffer's ownership boundary.

**Proposed assignment scope:** Add a return-value subsection for built-in `DllImport` marshalling with `[return: MarshalAs(UnmanagedType.LPUTF8Str)]`. Explain the required matching allocator and call-boundary cleanup. Contrast that with an explicit pointer plus the native library's own release function for Rust-owned or otherwise incompatible allocations, and distinguish owned results from borrowed/static memory. Qualify the parameter-focused ownership paragraph; don't generalize this return contract to all COM, custom, or source-generated marshallers.

**Acceptance criteria:** Execute a small native/managed UTF-8 fixture, including non-ASCII text and repeated calls, with allocation/release evidence. For an explicit-pointer example, use the library's matching deallocator exactly once, including exceptional paths. Obtain interop review; never recommend freeing an arbitrary Rust allocation or borrowed pointer with a managed allocator.

### dotnet/docs#29297: Clarify how Framework proxy settings override system defaults

**Issue:** [dotnet/docs#29297](https://github.com/dotnet/docs/issues/29297). **Opened:** May 5, 2022. **Size:** Very small. **GHCP suitability:** Strong; the maintainer supplied the intended interpretation.

**Why it still applies:** The [proxy configuration reference](../docs/framework/configure-apps/file-schema/network/proxy-element-network-settings.md) still says that if `usesystemdefault` is true, subsequent attributes override system settings. That wording invites the reported inference that false means other attributes are ignored. The [maintainer's clarification](https://github.com/dotnet/docs/issues/29297#issuecomment-1489458380) instead says that explicit settings can override the defaults even when true.

**Proposed assignment scope:** Explain that the flag controls whether Framework obtains the system proxy defaults; it doesn't enable or disable all other explicit proxy attributes. Describe explicit overrides without suggesting XML attribute order matters. Match the explanation to [Framework's DefaultProxySection implementation](https://github.com/microsoft/referencesource/blob/main/System/net/System/Net/Configuration/DefaultProxySection.cs), including the false/no-other-settings case. Keep this scoped to Framework configuration, not modern `HttpClient`.

**Acceptance criteria:** The attribute description must distinguish true/system defaults, false/no system defaults, and explicitly configured proxy values. Confirm the wording against the source and, if a configuration example is added, run it with application-local settings without changing machine or user proxy configuration.

### dotnet/docs#29690: Replace cancellation-prone XOR hashing in the value-object example

**Issue:** [dotnet/docs#29690](https://github.com/dotnet/docs/issues/29690). **Opened:** June 1, 2022. **Size:** Small. **GHCP suitability:** Strong; the failure is localized and the maintainer accepted a correction.

**Why it still applies:** The [value-object example](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects.md) still XORs component hashes with an unseeded `Aggregate`. Equal component hashes cancel, so every two-component diagonal example collapses to zero. XOR also discards component order, unlike the example's ordered equality comparison, and the unseeded aggregation fails for no components.

**Proposed assignment scope:** Replace that aggregation with ordered `System.HashCode` accumulation over the equality components. Preserve null handling and the equality/hash contract, handle empty component sequences, and update the explanation to describe combination rather than guarantee unique hashes. Keep the change in the documented example; don't silently modify the archived external application.

**Acceptance criteria:** Compile the updated sample and exercise empty, null, single, multiple, and repeated components. Equal objects must have equal hashes within the process, and the implementation must no longer structurally cancel repeated component hashes. Unequal objects can still collide; don't assert universal uniqueness, nonzero results, or cross-process hash stability.

### dotnet/docs#29717: Complete the NonBacktracking section with an executable example

**Issue:** [dotnet/docs#29717](https://github.com/dotnet/docs/issues/29717). **Opened:** June 3, 2022. **Size:** Small. **GHCP suitability:** Strong for the remaining example, not another conceptual section.

**Why it still applies:** The [Nonbacktracking mode section](../docs/standard/base-types/regular-expression-options.md#nonbacktracking-mode) now explains the option, limitations, and capture difference, but still has no example. The original issue explicitly requests a section with an example, so the existing prose is only partial completion.

**Proposed assignment scope:** Add a short compatible-pattern example in C# and VB to the existing section. Show actual match results; a repeated-group capture comparison with the default engine can demonstrate the already documented final-capture distinction. Use article-relative snippet projects and references, retain the unsupported-construct/option restrictions, and keep the pattern trusted and simple.

**Acceptance criteria:** Run both language samples on stable .NET, record the exact match/capture output, and verify that the published snippets select the executed code. Don't introduce a timing threshold, claim every expression supports this option, or imply that it makes an untrusted pattern safe.

### dotnet/docs#29916: Surface supported analyzer options in each rule's summary

**Issue:** [dotnet/docs#29916](https://github.com/dotnet/docs/issues/29916). **Opened:** June 17, 2022. **Size:** Medium. **GHCP suitability:** Suitable for a source-backed rule-table pass with assignee `gewarren`.

**Why it still applies:** The [CA1000 page](../docs/fundamentals/code-analysis/quality-rules/ca1000.md) documents `api_surface` below its summary table, but the table doesn't identify supported options. The earlier options work explicitly left this rule-table follow-up open. Existing lower-page configuration sections don't satisfy the requested discoverability change.

**Proposed assignment scope:** Add supported option names and links to the top tables of applicable CA rule pages, using each page's existing configuration sections and the [shared options reference](../docs/fundamentals/code-analysis/code-quality-rule-options.md). Don't invent an option for a rule without one or redo the separate IDE-rule work. Distinguish severity configuration from rule options: the issue's screenshot uses an invalid severity prefix; the correct form is `dotnet_diagnostic.CA1000.severity`, not `dotnet_code_quality.CA1000.severity`.

**Acceptance criteria:** Supply a rule-to-option inventory from current sources and check every changed table against it. Option links resolve to the right scope and accepted values. CA1000 exposes its actual `api_surface` option, and no copied mock-up introduces unsupported configuration keys.

### dotnet/docs#29941: Add a focused Process lifecycle how-to

**Issue:** [dotnet/docs#29941](https://github.com/dotnet/docs/issues/29941). **Opened:** June 20, 2022. **Size:** Medium. **GHCP suitability:** Suitable for a bounded tutorial with cross-platform execution, not a survey of test frameworks.

**Why it still applies:** The API member documentation explains individual operations, but the current runtime-library supplements don't provide the requested start/wait/timeout/output lifecycle walkthrough. The `Process` and `ProcessStartInfo` API contracts already define the behavior needed for a concrete example.

**Proposed assignment scope:** Add `docs/fundamentals/runtime-libraries/system-diagnostics-process.md` with a small owned child-process fixture. Use `ArgumentList`, `UseShellExecute=false`, concurrent consumption of redirected standard output and error, an awaited exit path, and explicit timeout cleanup. Explain that timeout or cancellation of a wait doesn't terminate the process, and that disposal releases resources rather than automatically kills it. Add fundamentals TOC and runtime-library overview links; coordinate API-reference backlinks if needed.

**Acceptance criteria:** Run C# and VB examples on Windows and Linux with normal exit, nonzero exit, enough output on both streams to expose blocked pipes, and timeout. Record output, exit handling, and cleanup of the owned child. Don't kill arbitrary processes or claim that `WaitForExit` proves every descendant has exited after a tree-termination request.

### dotnet/docs#30227: Remove the unused model-output path from the price tutorial

**Issue:** [dotnet/docs#30227](https://github.com/dotnet/docs/issues/30227). **Opened:** July 14, 2022. **Size:** Small. **GHCP suitability:** Strong; the unused declaration and misleading explanation are localized.

**Why it still applies:** The [price-prediction tutorial](../docs/machine-learning/tutorials/predict-prices.md) still introduces `_modelPath` as the trained model's output location. Its maintained `snippets/predict-prices/csharp/Program.cs` declares that value but only trains and consumes an in-memory model; it never saves the model.

**Proposed assignment scope:** Remove the unused path and its promise of a model file, explain the in-memory workflow, and link to the existing model save/load guidance for persistence. Align the completed-sample link with the maintained project. Don't add an unrequested save step or claim an external sample changed without verifying it.

**Acceptance criteria:** Run the maintained tutorial project through training and prediction. Its declarations, explanation, and completed-sample destination agree, and no step promises a file that the sample doesn't create.

### dotnet/docs#30253: Show the native IDL contract for the COM-hosting example

**Issue:** [dotnet/docs#30253](https://github.com/dotnet/docs/issues/30253). **Opened:** July 17, 2022. **Size:** Medium. **GHCP suitability:** Suitable with Windows MIDL execution and ABI review.

**Why it still applies:** The [COM-hosting article](../docs/core/native-interop/expose-components-to-com.md) says to provide IDL or a native header but doesn't walk through the native contract corresponding to its managed `IServer` interface. Links to general COM material don't supply that missing step.

**Proposed assignment scope:** Add the matching IDL and MIDL workflow, with consistent interface/class GUIDs, `HRESULT` and `[out, retval]` marshaling, generated outputs, and a native-consumer check. Reuse relevant build and type-library patterns from the [OutOfProcCOM sample](https://github.com/dotnet/samples/tree/main/core/extensions/OutOfProcCOM), but adapt the interface: that sample's dual `IDispatch` contract isn't interchangeable with this article's `InterfaceIsIUnknown` contract. Explain how the outputs fit the article's existing hosting/type-library steps. Coordinate the earlier paired wording issues in the same article.

**Acceptance criteria:** Build the managed example, run Windows MIDL, and compile/run a native client against the matching contract. Record the toolchain, generated files, GUID agreement, and `ComputePi` result. Use an owned test environment for any registration; don't change the user's global COM configuration or present an unmodified `IDispatch` sample as an `IUnknown` solution.

### dotnet/docs#30257: Supply the live LLDB setup before unloadability diagnostics

**Issue:** [dotnet/docs#30257](https://github.com/dotnet/docs/issues/30257). **Opened:** July 18, 2022. **Size:** Medium. **GHCP suitability:** Suitable for an article-specific Linux walkthrough with execution evidence.

**Why it still applies:** The [unloadability guide](../docs/standard/assembly/unloadability.md) starts the LLDB instructions at `plugin load` without showing how to launch or attach to the managed process first. The [dotnet-sos installation page](../docs/core/diagnostics/dotnet-sos.md) explains installation and initialization, not the missing live-session sequence.

**Proposed assignment scope:** Add or link the minimal LLDB prerequisites, launch/attach steps, runtime/SOS readiness checks, and command-prefix differences needed for this guide's sample. Keep live-process setup distinct from dump analysis. Diagnose the reported runtime-library loading error against a matching runtime, architecture, process state, and tool version; don't prescribe a universal PATH or `libcoreclr.so` workaround.

**Acceptance criteria:** From a fresh supported Linux environment, follow only the documented prerequisites and reproduce the guide's managed inspection on an owned sample. Record OS, runtime, LLDB/SOS versions, commands, and meaningful output. Current source inspection establishes the missing setup, not a completed Linux reproduction.

### dotnet/docs#30320: Lead the class-library overview with modern library development

**Issue:** [dotnet/docs#30320](https://github.com/dotnet/docs/issues/30320). **Opened:** July 22, 2022. **Size:** Medium. **GHCP suitability:** Suitable for the maintainer's bounded overview rewrite.

**Why it still applies:** The [class-library article](../docs/standard/class-libraries.md) still leads with PE-format details and a platform-specific/PCL/.NET Standard taxonomy rather than explain an ordinary modern .NET library. The discussion supplies a concrete outline for the missing purpose, creation, and organization guidance.

**Proposed assignment scope:** Explain reusable library projects and normal SDK-style development first. Link to the [current creation tutorial](../docs/core/tutorials/create-class-library.md), targeting guidance, and library-design guidance rather than duplicate their walkthroughs. Retain legacy library models as qualified context, not the only choices. Clarify project/assembly boundaries; partial types combine within one compilation and aren't a mechanism to compose a type across DLLs.

**Acceptance criteria:** The overview gives a newcomer a clear purpose, a current creation path, and the relevant design/targeting decisions. Verify linked projects and terminology, and obtain owner review of the new structure. Don't turn the change into a new class-library taxonomy or a broad assembly-format tutorial.

### dotnet/docs#30432: Preserve the remaining overloaded SDK and CLI terminology

**Issue:** [dotnet/docs#30432](https://github.com/dotnet/docs/issues/30432). **Opened:** July 30, 2022. **Size:** Small. **GHCP suitability:** Suitable for a glossary clarification with assignee `tdykstra`.

**Why it still applies:** Much of the deleted introduction's terminology now appears in the [glossary](../docs/standard/glossary.md), but its SDK entry doesn't distinguish the installed development toolchain from an MSBuild project SDK. Its .NET CLI entry also doesn't explain the separate expansion **Common Language Infrastructure**.

**Proposed assignment scope:** Add those short distinctions and cross-links, including the [.NET project SDK overview](../docs/core/project-sdk/overview.md). Preserve the distinction between the .NET command-line tools and the standardized language/runtime infrastructure. Don't copy the obsolete introduction wholesale or restore its historical version recommendations.

**Acceptance criteria:** A reader can distinguish the SDK download from `Sdk="Microsoft.NET.Sdk"` and the two CLI meanings. Check the added definitions and links against current SDK/runtime sources; coordinate with the existing assignee.

### dotnet/docs#30471: Explain why structured log placeholders need meaningful names

**Issue:** [dotnet/docs#30471](https://github.com/dotnet/docs/issues/30471). **Opened:** August 3, 2022. **Size:** Small. **GHCP suitability:** Strong; the missing rule rationale has an established structured-logging explanation.

**Why it still applies:** [CA2253](../docs/fundamentals/code-analysis/quality-rules/ca2253.md) prohibits numeric-only placeholders without explaining why the distinction matters even for short messages. The companion [CA2254 description](../docs/fundamentals/code-analysis/quality-rules/ca2254.md) already explains structured property names and their value to consumers.

**Proposed assignment scope:** Explain that meaningful placeholders identify structured fields, not just positions in a rendered message. Add a concise bad/good comparison and link to the existing message-template guidance. Preserve positional argument binding; don't suggest placeholder names change that binding or make a claim about a particular provider's storage/index behavior.

**Acceptance criteria:** Compile the example with CA2253 enabled and show its diagnostic before correction and absence afterward. Capture structured logging state to verify meaningful keys and corresponding values, including a short message. Don't substitute a performance argument or a minimum-placeholder-count rule.

### dotnet/docs#30506: Clarify JSON DOM families and node-variable names

**Issue:** [dotnet/docs#30506](https://github.com/dotnet/docs/issues/30506). **Opened:** August 5, 2022. **Size:** Small. **GHCP suitability:** Suitable for a focused explanation and sample-name pass with assignee `gewarren`.

**Why it still applies:** The [current DOM guide](../docs/standard/serialization/system-text-json/use-dom.md) already introduces mutable and immutable choices, but their type relationships can be clearer. Its referenced `JsonNodeAverageGradeExample.cs` still names a `JsonNode` variable `document`, which preserves the specific ambiguity reported in the issue.

**Proposed assignment scope:** Make the `JsonDocument`/`JsonElement` model distinct from the `JsonNode` family (`JsonObject`, `JsonArray`, and `JsonValue`). Add a compact choice/type-role comparison and use unambiguous node names in the affected examples. Preserve the existing disposal, element-lifetime, and clone guidance. Don't describe `JsonObject` as a `JsonElement` subclass or rename unrelated examples.

**Acceptance criteria:** Run the affected snippets and confirm unchanged behavior, including the grade example's `81.92` result. The prose, selected snippets, variable names, mutability, and lifetime guidance agree. Coordinate the scope with the current owner rather than redesign the entire namespace documentation.

### dotnet/docs#30741: Link Linux globalization prerequisites from the settings page

**Issue:** [dotnet/docs#30741](https://github.com/dotnet/docs/issues/30741). **Opened:** August 18, 2022. **Size:** Small. **GHCP suitability:** Strong for a qualified prerequisite note and existing recipe link.

**Why it still applies:** The [runtime globalization settings page](../docs/core/runtime-config/globalization.md) describes invariant-mode switches but doesn't tell an Alpine-container reader how to supply ICU. The [owner's follow-up](https://github.com/dotnet/docs/issues/30741#issuecomment-2541979180) and the current [container globalization recipe](https://github.com/dotnet/dotnet-docker/blob/main/samples/enable-globalization.md) provide the missing installation/image guidance.

**Proposed assignment scope:** Add a Linux/container prerequisite note beside invariant mode and link the recipe and [container image choices](../docs/core/docker/container-images.md). Explain that the appropriate ICU libraries/data and a non-invariant configuration are separate requirements. Qualify image layers: Alpine SDK images already include ICU, other Alpine layers can require installation, and suitable `extra` images serve different deployment scenarios. Don't present an environment flag as an installer, claim every Linux image needs the same packages, or equate ICU culture support with translated resource files.

**Acceptance criteria:** Verify the selected supported Alpine image/tag with a real container run and representative culture-sensitive output, then check the installed-package/configuration explanation against the current recipe. Preserve explicit project/runtime configuration precedence and don't repeat the unverified blanket claim that missing data always fails silently.

### dotnet/docs#31009: Add beginner WinDbg setup to unloadability diagnostics

**Issue:** [dotnet/docs#31009](https://github.com/dotnet/docs/issues/31009). **Opened:** September 4, 2022. **Size:** Small to medium. **GHCP suitability:** Suitable for an owned Windows debugger walkthrough, coordinated with the LLDB setup task.

**Why it still applies:** The [unloadability guide](../docs/standard/assembly/unloadability.md#debug-unloading-issues) still begins at the debugger command line and `.loadby sos coreclr`. The owner's installation link answers where to get WinDbg but doesn't add the article's requested launch/attach, break-state, and command-context sequence.

**Proposed assignment scope:** Link current WinDbg installation instructions and show how to open or attach to the guide's example, reach its intended break, confirm SOS readiness, and enter the existing heap/root commands. Distinguish terminal commands from the WinDbg command window and explain the expected managed-process context. Coordinate a single article pass with dotnet/docs#30257; don't create competing Windows/Linux rewrites.

**Acceptance criteria:** From an owned Windows test environment, follow the instructions through a meaningful `LoaderAllocator`/GC-root result. Record debugger/runtime versions and actual commands/output, without treating copied sample addresses as stable. Source inspection establishes the missing setup; no WinDbg session was executed during this review.

### dotnet/docs#31194: Explain svcutil tool-runtime prerequisites separately from the SDK

**Issue:** [dotnet/docs#31194](https://github.com/dotnet/docs/issues/31194). **Opened:** September 15, 2022. **Size:** Small. **GHCP suitability:** Suitable for a version-specific prerequisite correction with a tool-host matrix.

**Why it still applies:** The old version tabs are gone, but the [current guide](../docs/core/additional-tools/dotnet-svcutil-guide.md) only says to install the latest SDK. It doesn't distinguish the tool's execution runtime from the generated project's target. The published stable [8.0.0 package](https://www.nuget.org/packages/dotnet-svcutil/8.0.0) and its [release-tagged project](https://github.com/dotnet/wcf/blob/v8.0.0-rtm-dotnet-svcutil/src/dotnet-svcutil/src/dotnet-svcutil.csproj) identify `net8.0` and `net9.0` tool targets, not the issue's blanket .NET 5 requirement.

**Proposed assignment scope:** Document the current tool version's supported execution prerequisites and distinguish SDK, installed runtime, tool target, and service-client target. Verify the packaged runtime configuration and roll-forward behavior before naming a required additional runtime. Don't restore the outdated tabs, recommend an unsupported .NET 5 installation, or generalize one historical 2.x package's requirements to the entire version family.

**Acceptance criteria:** Install/invoke the pinned current tool in isolated SDK/runtime combinations, capture `--help` startup success or the exact missing-runtime message, and confirm generated code still targets the selected supported project. Package download through the NuGet API failed here with a TLS handshake error; release source and published targets were verified, but tool execution and packaged roll-forward settings weren't. Those checks must precede the prerequisite wording.

### dotnet/docs#31475: Surface code-style build enablement on applicable rule pages

**Issue:** [dotnet/docs#31475](https://github.com/dotnet/docs/issues/31475). **Opened:** September 28, 2022. **Size:** Medium, mostly a shared include and source-backed rule pass. **GHCP suitability:** Strong with per-rule build-support checks.

**Why it still applies:** [IDE0073](../docs/fundamentals/code-analysis/style-rules/ide0073.md) still lacks the requested build-enable explanation before suppression. The [analysis overview](../docs/fundamentals/code-analysis/overview.md#enable-on-build) documents `EnforceCodeStyleInBuild` and warning/error severity, but the applicable rule pages don't surface that recipe. Some other rules already have a shared note that they never run on build.

**Proposed assignment scope:** Add a shared explanation in the current `docs/fundamentals/code-analysis/includes` location and use it on build-capable IDE rule pages. Include the property, required severity, and overview link before suppression, as the maintainer requested. Preserve the existing never-on-build exceptions rather than promise that the property enables every IDE rule. Use current analyzer sources for the rule inventory; don't repeat the issue's unverified historical breaking-change claim.

**Acceptance criteria:** Check each affected rule's support and run representative C# and VB builds. An owned SDK 10.0.403 probe emitted IDE0073 only after the opt-in, while IDE0002 stayed absent despite explicit warning severity, matching its documented IDE-only status. The shared text must explain both outcomes without suggesting a severity setting can make an unsupported rule run on build.

### dotnet/docs#31683: Describe expected behavior through unit-test names

**Issue:** [dotnet/docs#31683](https://github.com/dotnet/docs/issues/31683). **Opened:** October 10, 2022. **Size:** Small, prose only. **GHCP suitability:** Strong; the requested distinction is explicit.

**Why it still applies:** The merged freshness edit in [dotnet/docs#45326](https://github.com/dotnet/docs/pull/45326) changed the disputed sentence, but the [current naming paragraph](../docs/core/testing/unit-testing-best-practices.md#follow-test-naming-standards) still says standards express the test's "purpose and application." That wording doesn't make the requested distinction between descriptive names, the behavior under test, and the test's verification purpose.

**Proposed assignment scope:** State that descriptive test names communicate the method/scenario and expected application behavior, then explain their value as documentation and failure context. Preserve the existing examples and naming convention without implying that every testing style must use one exact name format. Don't broaden the change to test architecture or rewrite unrelated examples.

**Acceptance criteria:** The paragraph names the actor clearly and agrees with its method/scenario/expected-behavior list. A reader can distinguish the tested behavior from the act of verifying it; prose review is sufficient for this localized change.

### dotnet/docs#31941: Explain elastic trivia in the Roslyn API reference

**Issue:** [dotnet/docs#31941](https://github.com/dotnet/docs/issues/31941). **Opened:** October 20, 2022. **Size:** Small to medium. **GHCP suitability:** Suitable after an API-repository maintainer handoff, not as a docs-checkout implementation.

**Why it still applies:** The [API XML](https://github.com/dotnet/roslyn-api-docs/blob/main/dotnet/xml/Microsoft.CodeAnalysis/SyntaxAnnotation.xml) defines `ElasticAnnotation` in one sentence, but its value and remarks remain placeholders. Current Roslyn source identifies the shared marker and tests it on trivia in the formatting engine. The missing explanation can use established behavior rather than invent a new formatter mechanism.

**Proposed assignment scope:** Arrange the issue/assignment in `dotnet/roslyn-api-docs`, then fill the property's value and remarks with a focused explanation of generated elastic trivia and formatter behavior. Link public factory/formatting APIs and add a minimal example under that repository's conventions. Distinguish elastic trivia from selection of a node/subtree for formatting; attaching an annotation doesn't itself invoke the formatter. Don't expose internal `IsElastic` helpers as public APIs or rewrite unrelated member placeholders.

**Acceptance criteria:** Run the example with stated Roslyn/workspace versions and record before/after text and annotation checks. Verify immutable-tree handling and relevant formatting options. Obtain API-owner review and preserve version metadata; a GHCP assignment limited to `dotnet/docs` can't edit the API source.

### dotnet/docs#32096: Identify project files for library-version properties

**Issue:** [dotnet/docs#32096](https://github.com/dotnet/docs/issues/32096). **Opened:** October 31, 2022. **Size:** Small. **GHCP suitability:** Strong; the four property snippets need file/context labels, not a new versioning policy.

**Why it still applies:** The [versioning article](../docs/standard/library-guidance/versioning.md) shows `PackageVersion`, `AssemblyVersion`, `FileVersion`, and `InformationalVersion` XML fragments without saying where to put them. An owned stable-SDK project verified that those properties produce the expected package and assembly metadata.

**Proposed assignment scope:** Explain that the properties belong in a `PropertyGroup` in an SDK-style library's `.csproj` or `.vbproj`. Label each fragment consistently and link shared `Directory.Build.props` configuration if appropriate. Don't direct readers to edit generated `obj` files or conflate package, assembly, file, and informational versions. Coordinate the informational-version wording with the retained Source Link correction in dotnet/docs#22373.

**Acceptance criteria:** Verify the named project-file placement and resulting package/assembly metadata, with both language project names explained. The SDK 10.0.403 probe produced package `1.2.3-beta1`, assembly `1.2.0.0`, file `1.2.3.4`, and informational `triage-probe` from those project properties. If shared props are added to the explanation, verify their import/override behavior too.

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

### dotnet/docs#25426: Explain why the volatile sample can produce identical observations

**Issue:** [dotnet/docs#25426](https://github.com/dotnet/docs/issues/25426). **Opened:** August 2, 2021. **Status:** Covered by open, non-draft [dotnet/docs#56650](https://github.com/dotnet/docs/pull/56650).

**Why the solution is defined:** The [volatile article](../docs/csharp/language-reference/keywords/volatile.md) still implies reliably different observations, while the maintainer notes that no small sample can guarantee that distinction across all processors, operating systems, and targets. The PR adds JIT, configuration, architecture, and cooperative-cancellation context in the affected paragraph.

**Maintainer next action:** Review the existing explanation, especially its Debug/Release and hardware-ordering qualifications. Don't promise that Release mode always reproduces stale reads or that volatile means immediate cross-core visibility. Require compiler/concurrency review of technical claims; lint success doesn't demonstrate a race or validate the memory model. Don't assign a duplicate sample rewrite.

### dotnet/docs#25499: Expand static anonymous-function examples

**Issue:** [dotnet/docs#25499](https://github.com/dotnet/docs/issues/25499). **Opened:** August 6, 2021. **Status:** Open, non-draft [dotnet/docs#56663](https://github.com/dotnet/docs/pull/56663) implements the examples but needs diagnostic corrections.

**Why the solution is defined:** The PR adds static lambda, anonymous-method, constant, and static-member examples to the [lambda reference](../docs/csharp/language-reference/operators/lambda-expressions.md) and its existing snippet file, as the maintainer requested. However, it identifies the capture diagnostics as CS8828/CS8829. The compiler's [error-code declarations](https://github.com/dotnet/roslyn/blob/main/src/Compilers/CSharp/Portable/Errors/ErrorCode.cs) identify these cases as CS8820/CS8821.

**Maintainer next action:** Correct the diagnostic IDs and links in the existing PR, compile the positive examples, and reproduce both prohibited-capture diagnostics separately. Qualify allocation wording: prevention of a captured closure isn't a guarantee of zero delegate or other allocations. Don't close the issue before the corrected PR merges.

### dotnet/docs#25609: Separate assembly identity from compiler security features

**Issue:** [dotnet/docs#25609](https://github.com/dotnet/docs/issues/25609). **Opened:** August 12, 2021. **Status:** Covered by open, non-draft [dotnet/docs#56649](https://github.com/dotnet/docs/pull/56649).

**Why the solution is defined:** The current [compiler-options page](../docs/csharp/language-reference/compiler-options/security.md) groups signing under security. The PR updates its title, introduction, and TOC label, explains strong-name identity and modern-runtime signature behavior, and preserves `HighEntropyVA` as an actual ASLR security feature. The issue explicitly distinguishes that exception.

**Maintainer next action:** Review the existing prose and cross-links, retain Framework-versus-modern-runtime distinctions, and preserve the existing URL. Don't remove every security reference indiscriminately or open a second terminology PR.

### dotnet/docs#25722: Make both CA2000 examples reproduce their claimed diagnostics

**Issue:** [dotnet/docs#25722](https://github.com/dotnet/docs/issues/25722). **Opened:** August 19, 2021. **Status:** Open, non-draft [dotnet/docs#56665](https://github.com/dotnet/docs/pull/56665) replaces Example 1 but doesn't complete the two-example request.

**Why the solution is defined:** The [CA2000 article](../docs/fundamentals/code-analysis/quality-rules/ca2000.md) describes the two examples as violations. The PR replaces the first with undisposed `FileStream` examples and fixes in C# and VB, but leaves **Example 2** and its VB overflow/`StreamReader` diagnostic claim unchanged. The rule isn't enabled by default, and exceptional-path/ownership configuration affects what a reproduction proves.

**Maintainer next action:** Complete the existing PR rather than duplicate it. Specify the SDK/analyzer version, explicitly enable CA2000, record relevant analysis settings, and reproduce every retained diagnostic claim, including Example 2. Verify both positive and corrected examples in their actual language/compiler configurations. Update or remove unsupported legacy diagnostic claims instead of treating a new Example 1 as proof that the whole issue is fixed.

### dotnet/docs#26267: Explain analyzer/compiler API incompatibility for CS8032

**Issue:** [dotnet/docs#26267](https://github.com/dotnet/docs/issues/26267). **Opened:** September 26, 2021. **Status:** Open, non-draft [dotnet/docs#56689](https://github.com/dotnet/docs/pull/56689) addresses the core diagnostic explanation but needs precision and scope review.

**Why the solution is defined:** The actual patch adds newer-`Microsoft.CodeAnalysis`/older-host incompatibility and upgrade/downgrade remedies to the [source-generator diagnostic guidance](../docs/csharp/language-reference/compiler-messages/source-generator-errors.md). However, the original issue also asks how to determine compatible compiler/CLI versions and how to find the explanation from the analyzer tutorial. The patch changes only the diagnostic page; it doesn't add the tutorial link or a precise host-version reference.

**Maintainer next action:** Complete the existing PR rather than assign a duplicate. Qualify its broad "Roslyn 4.x"/".NET 6+ SDK" example: a later 4.x API dependency doesn't necessarily load in every .NET 6 SDK or Visual Studio 2022 release. Identify the minimum compatible host for the actual referenced API/package version, link authoritative version information, and add the requested signpost from the [analyzer tutorial](../docs/csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix.md). Distinguish analyzer target-framework compatibility from availability of the required Roslyn APIs. Verify the mismatch and corrected configuration before treating the whole request as complete.

### dotnet/docs#27727: Verify all reported compiler-help routes and correct the CS1574 patch

**Issue:** [dotnet/docs#27727](https://github.com/dotnet/docs/issues/27727). **Opened:** November 16, 2021. **Status:** Open, non-draft [dotnet/docs#56691](https://github.com/dotnet/docs/pull/56691) modernizes one article but doesn't by itself verify the original three help-link failures.

**Why the solution is defined:** Current topics exist for [CS8357](../docs/csharp/language-reference/compiler-messages/invalid-build-command-line.md#deterministic-assembly-versions), [CS7035](../docs/csharp/language-reference/compiler-messages/cs7035.md), and [CS1574](../docs/csharp/misc/cs1574.md). The PR's actual patch changes only CS1574 content and retains its existing `f1_keywords`. It also retains the old syntax-error description and adds a raw-angle-bracket generic example labeled CS1574. The compiler's [error codes](https://github.com/dotnet/roslyn/blob/main/src/Compilers/CSharp/Portable/Errors/ErrorCode.cs) and [diagnostic resources](https://github.com/dotnet/roslyn/blob/main/src/Compilers/CSharp/Portable/CSharpResources.resx) distinguish CS1574's unresolved reference from CS1584's invalid reference syntax.

**Maintainer next action:** Review the existing PR, not a duplicate assignment. Verify F1/help resolution for all three reported codes, and distinguish a successful route from an article-content improvement. Correct the CS1574 diagnostic description and reproduce every proposed example with XML documentation enabled, including any malformed-XML diagnostics from unescaped angle brackets. Validate the corrected example's zero-warning claim under stated compiler/options. Don't close the three-link issue solely because one article was expanded.

### dotnet/docs#29417: Distinguish packaged PDBs from available source code

**Issue:** [dotnet/docs#29417](https://github.com/dotnet/docs/issues/29417). **Opened:** May 11, 2022. **Status:** Covered by open, non-draft [dotnet/docs#56613](https://github.com/dotnet/docs/pull/56613).

**Why the solution is defined:** The [NuGet guidance](../docs/standard/library-guidance/nuget.md) explains PDB inclusion without adequately separating symbols from source availability. The existing PR's actual patch adds a note about build-machine source paths, Source Link, and `EmbedAllSources`, which addresses the reported consumer-debugging confusion.

**Maintainer next action:** Review the existing PR rather than assign a duplicate. Qualify the note so it doesn't imply every PDB has only local source paths: PDBs can already contain Source Link or embedded-source information. Distinguish PDBs in a package, `DebugType=embedded`, and embedded source. Verify a consumer-debugging scenario isolated from the producer's source with owned fixtures, and coordinate overlapping Source Link guidance with dotnet/docs#22373. Don't close before the corrected implementation merges.

### dotnet/docs#29834: Correct the WCF keep-alive configuration examples

**Issue:** [dotnet/docs#29834](https://github.com/dotnet/docs/issues/29834). **Opened:** June 14, 2022. **Status:** Covered by open, non-draft [dotnet/docs#56611](https://github.com/dotnet/docs/pull/56611).

**Why the solution is defined:** The actual patch moves `keepAliveEnabled` from `binding` to `httpTransport` in both [load-balancing examples](../docs/framework/wcf/load-balancing.md). It doesn't complete the requested attribute documentation in the [HTTPS transport reference](../docs/framework/configure-apps/file-schema/wcf/httpstransport.md).

**Maintainer next action:** Extend the existing PR rather than assign a duplicate. Cover the HTTPS inherited property and review the encoder's protocol version: a Framework 4.8 configuration probe accepted `KeepAliveEnabled=false` on both HTTP and HTTPS transports, but the PR's bare `textMessageEncoding` selects SOAP 1.2/WS-Addressing 1.0, unlike the section's BasicHttp/SOAP 1.1 context. Make that context explicit and validate an actual matching client/service exchange before merge. The probe verifies configuration properties and defaults, not a completed service interoperability test.

### dotnet/docs#29993: Explain alternatives to base/derived conversion operators

**Issue:** [dotnet/docs#29993](https://github.com/dotnet/docs/issues/29993). **Opened:** June 24, 2022. **Status:** Covered by open, non-draft [dotnet/docs#56683](https://github.com/dotnet/docs/pull/56683).

**Why the solution is defined:** The maintainer requests a conceptual explanation with a diagnostic-page link. The existing patch instead adds placeholder constructor/factory/extension signatures to the [consolidated operator diagnostics](../docs/csharp/language-reference/compiler-messages/overloaded-operator-errors.md), without the requested explanation in the [conversion-operator article](../docs/csharp/language-reference/operators/user-defined-conversion-operators.md).

**Maintainer next action:** Complete the existing implementation with executable alternatives and the conceptual/diagnostic links. Explain both directions of the base/derived restriction, including external base assemblies and generic derived types. Distinguish a valid runtime downcast from a new copy or wrapper: a constructor or factory doesn't change an existing base object's runtime type. Verify both the prohibited declarations' diagnostics and the alternatives' actual behavior before merge.

### dotnet/docs#31135: Document a bounded asynchronous concurrency pattern

**Issue:** [dotnet/docs#31135](https://github.com/dotnet/docs/issues/31135). **Opened:** September 13, 2022. **Status:** Covered by open, non-draft [dotnet/docs#56684](https://github.com/dotnet/docs/pull/56684).

**Why the solution is defined:** The existing patch adds `Parallel.ForEachAsync`, a semaphore-gated `Task.WhenAll` pattern, and a comparison to [async scenarios](../docs/csharp/asynchronous-programming/async-scenarios.md). The current article lacks the requested limit, so the open PR is implementation work rather than proof of resolution.

**Maintainer next action:** Complete the undefined helper/result types as executable article-relative snippets and measure peak in-flight operations against the configured maximum. Correct the comparison: `Task.WhenAll` waits for supplied tasks; it doesn't itself start operations or universally allocate those tasks. Semaphore gating can limit active work while still creating one task per input. Add cancellation/error cleanup, distinguish concurrency from request-rate limits, reconcile the article's broad I/O/TPL wording, and fix the encoded-star API reference. Don't close before the corrected, verified examples merge.

### dotnet/docs#32014: Complete CS1961 guidance and error-help discovery

**Issue:** [dotnet/docs#32014](https://github.com/dotnet/docs/issues/32014). **Opened:** October 24, 2022. **Status:** Covered by open, non-draft [dotnet/docs#56685](https://github.com/dotnet/docs/pull/56685).

**Why the solution is defined:** The existing patch extends the [generic type-parameter diagnostics](../docs/csharp/language-reference/compiler-messages/generic-type-parameters-errors.md#type-parameter-variance) with invariant validity and remedies. The original issue's exact catch-all URL still returns the "don't have specifics" page when fetched; adding prose alone doesn't verify Visual Studio help discovery.

**Maintainer next action:** Verify the reported `out T`/`ICollection<T>` diagnostic and corrected alternatives, keep composed variance positions accurate, and don't remove mutability requirements just to select a read-only interface. Use real diagnostic wording rather than a fabricated slash-separated message, and fix the percent-encoded backticks in generic API IDs. Check the actual Visual Studio/F1 help target after publication; existing `f1_keywords` metadata alone doesn't prove the link works. Scope completion to CS1961 rather than promise documentation for every compiler error or selective redirection of every historical catch-all URL.

## Assignment order

For the quickest independent changes, start with the table escaping, the paired COM wording corrections, or the existing prose-only signposts. Coordinate the instrumentation link with its current owner. Treat the two COM issues as one assignment, and use the existing hosted-service issue rather than duplicate work for dotnet/docs#23440.

The model-improvement TOC label, Framework Arm64 signpost, migration overview/title links, and pre-upgrade planning move are additional small changes. Coordinate the three migration TOC tasks as one pass if the existing owner agrees. Both the algorithm inventory and model-improvement navigation task have current assignee `jwood803`; don't create parallel ownership without coordination.

The coding-components overview needs new-page review. Source Link, plugin publication, the trimming limitation, XML package documentation, constructor injection, and integration-test configuration need focused execution evidence. Verify formatter output for the property-pattern explanation and obtain analyzer-owner review of the CA1806 corrections. The numeric-format article is a larger sample-verification task, not a one-line table fix. The linker correction requires the .NET Framework toolchain, and the PEVerify clarification needs compiler-owner review.

The CLI tutorial needs a real training/generated-project run. The glossary corrections and library-targeting clarification need controlled metric/package examples, while the MSTest cleanup needs the tutorial's fail/pass sequence. The F# explanation already has a stable-compiler reproduction, but its eventual published snippets still need execution and F# review.

The prerequisite examples and linked-cancellation lifecycle correction need focused build/resource tests. Coordinate the library compatibility and testing-versus-targeting explanations in one article pass. The interop addition needs ABI review, the permission explanation needs authorization review, and the deduplication explanation must preserve the archived sample's limits rather than promise exactly-once delivery.

The custom-repository explanation and logging-event demonstration are additional localized tasks. Pair the two profiler buffer-count issues in one owner-coordinated change, distinct from the earlier paired COM wording task. Coordinate the remaining image guidance with both existing assignees. The VB binding correction, semaphore explanation, and C# first-completion example need language/concurrency-specific review rather than a superficial wording pass.

The BCL source link, explicit VSIX startup selection, package-version note, and instance-thread-safety wording are additional small changes. Coordinate the package note with the earlier MSTest task and the VSIX note with the analyzer tutorial's CS8032 signpost. The CRLF example needs backend-specific evidence, and the recommendation explanation must distinguish training labels from predicted scores.

The SRTP syntax, nullable/CA1062 cases, task-exception distinction, enumeration usage, and SQLite WAL example need focused compiler/runtime or sample evidence. Scope connection queues to the actual handler/protocol and compilation trade-offs to reviewed runtime behavior. The fiber note states an unsupported boundary; it must not advertise a new support policy or workaround.

The CA1052 rationale and analyzer-locality note are additional focused clarifications; the latter needs IDE evidence, not just code-fix unit tests. Pair the dispose sample correction with both language examples and runtime cleanup checks. The inherited-event simplification is a separate small executable-example task.

The TensorFlow dependency note must use release-matched managed/native packages. The domain-event clarification needs a real relational rollback check, and the SQLite extension recipe needs a known native binary and platform-specific execution. Coordinate class-free ML.NET loading with its current owner and the retained image-loading task. The Roslyn packaging guide needs an actual multi-host asset-selection matrix and coordination with the draft generator tutorial, not another generic version-mismatch paragraph.

The CA1507 suppression rationale and Framework proxy clarification are additional small prose tasks. The AnalysisLevel correction must update both descriptions from a real SDK/target matrix. Align the complete LINQ project and its link together, and verify the nonbacktracking example in both languages rather than add another prose-only section.

The calibrated-retraining addition needs a real saved-model round trip and must retain preprocessing compatibility. Native string ownership needs a native fixture and allocator review, not just a managed build. The value-object hash correction needs equality-contract and edge-case checks without a no-collisions promise.

The unused model path, remaining glossary distinctions, and CA2253 rationale are additional localized tasks. The JSON DOM change must keep type roles and sample output consistent. Coordinate the analyzer-option tables with their owner, and preserve the forecasting requirement in the existing algorithm-coverage task rather than duplicate ownership.

The Process walkthrough needs owned child fixtures and cross-platform timeout/output checks. The COM contract needs Windows MIDL/native execution and coordination with the earlier wording corrections. The LLDB setup needs a fresh Linux run, and the class-library rewrite should link to the current creation tutorial rather than preserve an obsolete taxonomy.

The test-naming clarification and version-property file labels are additional small changes. Coordinate versioning edits with the Source Link correction. The globalization signpost has an existing recipe but still needs a selected-container run; the svcutil prerequisites need actual tool/runtime startup checks, not only target-framework metadata.

Coordinate Windows debugger setup with the LLDB task in one article pass. The build-enable include requires a supported/unsupported IDE-rule inventory. Arrange the elastic-trivia API correction in its owning repository before assignment; it isn't a change that a docs-only checkout can publish.

Review the fourteen existing implementation PRs separately from new assignments. Correct the unhandled-exception method name and static-lambda diagnostic IDs, complete the CA2000 two-example verification, refine the CS8032 version advice/tutorial signpost, and verify the CS1574 diagnostics and all three original help routes before merge. Check the packaged-PDB clarification against an isolated consumer, and coordinate it with the existing Source Link task. Complete the HTTPS reference and SOAP-version checks in the WCF PR, and add real conceptual examples to the conversion-operator PR. Measure the async concurrency limit and verify CS1961 help discovery rather than close either new implementation early. Issues that don't fit either candidate category are omitted for a future task.
