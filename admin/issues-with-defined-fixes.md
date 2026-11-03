---
title: Issues with clearly defined fixes
ai-usage: ai-generated
---

# Issues with clearly defined fixes

Recommend the following 270 issues as GitHub Copilot (GHCP) assignment candidates because each has a specific remaining documentation gap, identified target files, and a bounded resolution. Track forty-seven additional issue-level fixes separately because forty-five implementation PRs are already open; two pairs of issues share PRs, several patches need correction or completion before merge, and two PRs remain drafts. No assignments or other GitHub changes have been made. Entries within each category follow issue creation time, not implementation priority.

## Review coverage

- **Repository and snapshot:** `dotnet/docs`, November 2, 2026; 848 open issues, excluding pull requests.
- **Completed batches:** The 675 oldest open issues, from [dotnet/docs#2608](https://github.com/dotnet/docs/issues/2608), opened July 12, 2017, through [dotnet/docs#43966](https://github.com/dotnet/docs/issues/43966), opened December 13, 2024.
- **Results:** 317 defined fixes (270 assignment candidates and 47 with open implementation PRs) and 132 [closure candidates](issues-to-close.md#closure-candidates).
- **Latest batch:** Issues 651-675 add 10 new assignment candidates and 4 new issue-level fixes with open implementation PRs, alongside 6 closure candidates. The 47 active entries are covered by 45 distinct PRs.
- **Remaining:** 173 issues from this snapshot are unreviewed. Of the requested remaining 298 issues (positions 551-848), 125 are complete and 173 remain. Continue with [dotnet/docs#43996](https://github.com/dotnet/docs/issues/43996), opened December 17, 2024, and finish the snapshot at position 848.
- **Evidence baseline:** Issue bodies, complete comment threads, current target documentation, candidate cross-reference timelines, open-PR checks, and actual patches for active implementations. For the 545-file curation draft, the complete file manifest and relevant deletion, replacement, and redirect patches were inspected; this isn't a line-by-line review of the entire replacement book. Local source matched upstream `main` at `81cd030da804aa06cfbd8f23474cbbacba597c72`. Candidate issues were open when checked; existing ownership is noted where relevant.

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

**Why the solution is defined:** The actual archived [TransactionBehaviour](https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.API/Application/Behaviors/TransactionBehaviour.cs) begins a transaction around the handler pipeline and commits afterward. [OrderingContext](https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.Infrastructure/OrderingContext.cs) distinguishes `SaveEntitiesAsync`/`SaveChangesAsync` from `CommitTransactionAsync`. Both source files were rechecked on the archived `dev` branch during the later duplicate review. Multiple saves inside that explicit transaction aren't separate outer commits.

**Proposed assignment scope:** Explain and link the actual outer transaction, distinguish a save from a transaction commit, and qualify the sample's atomicity claims. State that a shared context alone doesn't make several independent saves one transaction. Preserve the chapter's alternative eventual-consistency model. Don't introduce the proposed recursion counter as though it establishes a database transaction or solves arbitrary event-dispatch reentrancy.

**Related scope retained from dotnet/docs#43392:** Explicitly describe the failure/crash window between database commit and in-memory event dispatch, and link durable-event/outbox guidance where delivery must survive that window. Distinguish an in-process mediator from durable cross-process delivery without redefining every eventually consistent aggregate as an actor. The chapter already discusses post-commit inconsistency and persistent event records; extend that explanation rather than introduce a new message-bus implementation. Coordinate the surviving chapter with ebook-curation draft dotnet/docs#43185.

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

### dotnet/docs#32332: Illustrate variance positions beside the explanation

**Issue:** [dotnet/docs#32332](https://github.com/dotnet/docs/issues/32332). **Opened:** November 8, 2022. **Size:** Small. **GHCP suitability:** Strong for a localized example, not another variance overview.

**Why it still applies:** The [generics article](../docs/standard/generics/covariance-and-contravariance.md) now has clearer introductory definitions and existing assignment examples. However, the requested paragraph about return and parameter positions still lacks an adjacent declaration example that connects those positions to generic delegates and interfaces. Don't describe the entire article as lacking examples.

**Proposed assignment scope:** Add a compact, paired C#/VB illustration beside that paragraph, or reuse appropriate existing snippet regions. Show covariant output and contravariant input in both a generic interface and a generic delegate. Connect the declarations to safe assignments with the article's `Base`/`Derived` vocabulary, and retain the deeper examples rather than duplicate a second tutorial.

**Acceptance criteria:** Compile the examples in both languages and identify which declared positions permit each conversion. Preserve the reference-type limitation and invariant counterexample. Don't imply that variance annotations belong on ordinary classes or that every syntactic occurrence of a type parameter has the same composed variance.

### dotnet/docs#32337: Explain CA1305's UI-culture diagnostics

**Issue:** [dotnet/docs#32337](https://github.com/dotnet/docs/issues/32337). **Opened:** November 8, 2022. **Size:** Small. **GHCP suitability:** Strong; the missing diagnostic family is present in current analyzer source.

**Why it still applies:** [CA1305](../docs/fundamentals/code-analysis/quality-rules/ca1305.md) describes omitted format providers, but not explicit `CurrentUICulture`/`InstalledUICulture` arguments. The [current analyzer](https://github.com/dotnet/sdk/blob/main/src/Microsoft.CodeAnalysis.NetAnalyzers/src/Microsoft.CodeAnalysis.NetAnalyzers/Microsoft.NetCore.Analyzers/Runtime/SpecifyIFormatProvider.cs) still declares and reports the UI-culture variants.

**Proposed assignment scope:** Extend the cause, rationale, fixes, and suppression guidance for this case. Distinguish resource-language selection, user regional formatting, installed UI language, and invariant machine-readable output. Explain when an intentional formatting policy justifies a narrow suppression; don't suggest that every explicit provider satisfies the rule or that changing the resource language is the fix.

**Acceptance criteria:** Demonstrate the diagnostic and corrected behavior in both documentation languages. An SDK 10.0.403 probe emitted CA1305 for both UI-culture properties and formatted the same number as `19,50` with German current culture versus `19.50` with English UI culture. Record the chosen cultures and justify any suppression rather than copy the existing omitted-provider rationale unchanged.

### dotnet/docs#32685: State JsonTypeInfo customization limits on the APIs

**Issue:** [dotnet/docs#32685](https://github.com/dotnet/docs/issues/32685). **Opened:** November 21, 2022. **Size:** Medium. **GHCP suitability:** Suitable after an API-repository handoff and a version-specific member pass.

**Why it still applies:** The [conceptual article](../docs/standard/serialization/system-text-json/custom-contracts.md) now maps common modifications to kinds, and several API members already state their restrictions. However, [JsonTypeInfo API XML](https://github.com/dotnet/dotnet-api-docs/blob/main/xml/System.Text.Json.Serialization.Metadata/JsonTypeInfo.xml) still describes `CreateObject` and `PolymorphismOptions` failures with the uninformative "current metadata Kind" wording called out by the issue. The [runtime owner](https://github.com/dotnet/docs/issues/32685#issuecomment-1333598965) explicitly requests individual-API documentation because support changes by release.

**Proposed assignment scope:** Arrange the work in `dotnet/dotnet-api-docs` and identify the remaining vague members, including the generic `JsonTypeInfo<T>.CreateObject` surface. State actual supported kinds and other setter restrictions from matching release source. Preserve existing accurate member documentation and version metadata instead of replacing it with a timeless conceptual matrix.

**Acceptance criteria:** Use mutable resolver-produced metadata and distinguish kind restrictions, converter capability, and metadata locks. An SDK 10 probe accepted factories for representative object/list/dictionary contracts and rejected `None`; release source separately checks converter support, so those results don't prove that every enumerable accepts a factory. Check preview .NET 11 union behavior separately rather than extrapolate from .NET 10. Obtain API-owner review before publication.

### dotnet/docs#32773: Respect historical offsets in ambiguous-time examples

**Issue:** [dotnet/docs#32773](https://github.com/dotnet/docs/issues/32773). **Opened:** November 28, 2022. **Size:** Small to medium. **GHCP suitability:** Strong; deterministic custom-zone fixtures expose the error.

**Why it still applies:** [Automatic resolution](../docs/standard/datetime/resolve-ambiguous-times.md) still subtracts `BaseUtcOffset` in both languages, ignoring a historical `BaseUtcOffsetDelta`. The [user-choice article](../docs/standard/datetime/let-users-resolve-ambiguous-times.md) still explains the same invalid comparison, and its VB snippet uses it for standard/daylight labels. The C# user-choice snippet already displays offsets without those labels.

**Proposed assignment scope:** Preserve the automatic example's standard-time policy with the appropriate time-zone conversion API rather than manual base-offset arithmetic. Correct both articles' prose and affected language regions. For user choice, either present the actual offsets consistently or classify a chosen `DateTimeOffset` through the zone; don't restore the invalid base comparison or assume the smaller offset always means standard time. Keep the separate runtime API proposal outside this fix.

**Acceptance criteria:** Exercise nonzero base-offset deltas, positive and negative daylight deltas, both user choices, and relevant `DateTime.Kind` inputs. Owned SDK 10 fixtures found a one-hour error in the original arithmetic for both daylight-delta signs; `ConvertTimeToUtc` preserved the standard-time choice. The negative-delta fixture also disproved the proposed smaller-offset shortcut. Verify C# and VB outputs without changing the machine's time zone.

### dotnet/docs#32822: Distinguish worker-thread settings from legacy I/O counts

**Issue:** [dotnet/docs#32822](https://github.com/dotnet/docs/issues/32822). **Opened:** December 1, 2022. **Size:** Small. **GHCP suitability:** Strong with runtime-owner review; coordinate with current assignee `kouvel`.

**Why it still applies:** [Minimum-thread configuration](../docs/core/runtime-config/threading.md#minimum-threads) correctly names worker threads but links `SetMinThreads` without explaining its second parameter. The [owner's answer](https://github.com/dotnet/docs/issues/32822#issuecomment-1352484294) confirms no corresponding I/O-count setting and explains the changed implementation. [.NET 10 portable-pool source](https://github.com/dotnet/runtime/blob/v10.0.0/src/libraries/System.Private.CoreLib/src/System/Threading/PortableThreadPool.cs) retains legacy I/O counts for validation/reporting, separately from worker-thread control.

**Proposed assignment scope:** Add the requested distinction beside the setting and link the existing Windows-thread-pool exception. Explain the supported implementation/version boundaries without inventing a completion-port configuration key, claiming all API parameters are ignored, or treating a reported legacy count as a separate live completion-thread pool.

**Acceptance criteria:** Check modern portable-pool behavior against the owner/source, preserve older Framework distinctions, and respect `UseWindowsThreadPool`'s documented unsupported settings/APIs. Don't recommend the removed .NET 7 revert switch as a supported .NET 8+ solution. Any API-reference amendment requires coordination with its owning repository.

### dotnet/docs#32842: Document custom mapping and saved-model persistence

**Issue:** [dotnet/docs#32842](https://github.com/dotnet/docs/issues/32842). **Opened:** December 2, 2022. **Size:** Medium. **GHCP suitability:** Strong for a source-backed how-to; coordinate with `luisquintanilla` and `michaelgsharp`.

**Why it still applies:** The [transforms reference](../docs/machine-learning/resources/transforms.md#custom-transformations) lists `CustomMapping`, and the TensorFlow tutorial uses one, but neither supplies the requested define/use/save walkthrough. The official [basic example](https://github.com/dotnet/machinelearning/blob/main/docs/samples/Microsoft.ML.Samples/Dynamic/Transforms/CustomMapping.cs) and [save/load example](https://github.com/dotnet/machinelearning/blob/main/docs/samples/Microsoft.ML.Samples/Dynamic/Transforms/CustomMappingSaveAndLoad.cs) establish a concrete implementation pattern.

**Proposed assignment scope:** Add a focused custom-mapping how-to and navigation that covers input/output schemas, pipeline integration, a named contract, and its attributed factory for persistence. Explain why the null-contract example can't be saved. Use the existing sample as source, not a proposal for a new transformer framework. Verify release-specific assembly discovery: the source itself qualifies explicit `RegisterAssembly` as necessary only for old versions, so don't mandate that historical step for every current package.

**Acceptance criteria:** Run both language samples through transform, save, and reload with a fresh context/process, and compare the actual row results. Pin the supported package version and record any discovery requirements. Keep this concrete child task separate from broad ML.NET trackers and preserve both owners' coordination.

### dotnet/docs#32884: Signpost the reported Bootstrap license-path deployment collision

**Issue:** [dotnet/docs#32884](https://github.com/dotnet/docs/issues/32884). **Opened:** December 5, 2022. **Size:** Small, prose only. **GHCP suitability:** Suitable after a handoff to `dotnet/AspNetCore.Docs`.

**Why it still applies:** The original path now redirects to the [ASP.NET Core article](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/breaking-changes/6/identity-bootstrap4-to-5.md). Its current text doesn't include the [maintainer-approved narrow signpost](https://github.com/dotnet/docs/issues/32884#issuecomment-1489411553). A later reporter supplies the same `Identity\lib\bootstrap\LICENSE` error after a .NET 6-to-8 upgrade.

**Proposed assignment scope:** In the owning article, add the approved additional-information note that links this issue for the specific reported Web Deploy path/error. Distinguish the reported file/directory collision from proof that every access-denied error has that cause. Don't expand the note into a universal migration requirement, a broad deletion instruction, or advice to grant indiscriminate Full Control.

**Acceptance criteria:** Preserve Bootstrap-selection guidance and the existing redirect. Match the actual error/path and attribute the workaround to the discussion rather than claim a verified product fix. Any added cleanup procedure needs a safe, owned deployment reproduction and must preserve the required license file; the bounded signpost doesn't require such a procedure.

### dotnet/docs#32905: Make CA1506 suppression choices explicit

**Issue:** [dotnet/docs#32905](https://github.com/dotnet/docs/issues/32905). **Opened:** December 7, 2022. **Size:** Small. **GHCP suitability:** Strong; project-wide suppression has a direct SDK reproduction.

**Why it still applies:** [CA1506](../docs/fundamentals/code-analysis/quality-rules/ca1506.md) now shows pragma and configuration-file suppression, but not the explicitly requested `NoWarn` alternative. Its threshold section and related links don't explain the choice between one violation, a scoped rule setting, and project-wide suppression.

**Proposed assignment scope:** Clarify those scopes and add an append-preserving project-property example with appropriate `.csproj`/`.vbproj` context. Link shared `Directory.Build.props` or command-line usage rather than replace the rule page with a build-configuration tutorial. Distinguish suppression from a justified threshold change, and don't recommend suppression merely to avoid a code-quality decision.

**Acceptance criteria:** Enable the rule with a controlled threshold, show its diagnostic, and verify that `NoWarn` removes CA1506 without discarding other warnings or existing property entries. An SDK 10 probe emitted two CA1506 diagnostics before suppression and none afterward while retaining CA1305. Explain the scope in plain language and verify both language project forms.

### dotnet/docs#32978: Distinguish POCOs from data-only DTOs

**Issue:** [dotnet/docs#32978](https://github.com/dotnet/docs/issues/32978). **Opened:** December 10, 2022. **Size:** Small, primarily prose. **GHCP suitability:** Strong; the contradiction has identified source text.

**Why it still applies:** The [POCO glossary entry](../docs/standard/glossary.md#poco) still forbids methods, events, inheritance, and interfaces. The [domain-model guide](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-domain-model.md#rich-domain-model-versus-anemic-domain-model) explicitly describes entities with behavior, so the restrictive glossary creates the reported contradiction.

**Proposed assignment scope:** Define POCO in terms of ordinary CLR objects without mandatory framework-specific base types or contracts. Explain that POCOs can contain behavior and that a data-only DTO is one use, not the definition. Correct the blanket member/inheritance prohibitions and cross-link the domain-model explanation if useful. Don't strip methods from domain entities or mandate DDD for simple CRUD models.

**Acceptance criteria:** The glossary and domain-model guidance agree about behavior and distinguish a dependency requirement from an absolute ban on inheritance/interfaces. Preserve the existing rich/anemic trade-off and obtain architecture review. Prose review suffices unless the change adds a new code example.

### dotnet/docs#33257: Complete the DataFrame guide's string-input option

**Issue:** [dotnet/docs#33257](https://github.com/dotnet/docs/issues/33257). **Opened:** December 28, 2022. **Size:** Small. **GHCP suitability:** Strong for a remaining checklist item, not a replacement guide.

**Why it still applies:** [dotnet/docs#34470](https://github.com/dotnet/docs/pull/34470) merged on March 8, 2023, and the [published guide](../docs/machine-learning/how-to-guides/getting-started-dataframe.md) covers installation, file loading, inspection, transformations, combination, and saving. However, the issue explicitly names string input as well as file input; that option remains absent. [Current API source](https://github.com/dotnet/machinelearning/blob/main/src/Microsoft.Data.Analysis/DataFrame.IO.cs) names the real method `LoadCsvFromString`, not the issue's abbreviated `LoadCsvString`.

**Proposed assignment scope:** Add the missing in-memory CSV alternative to the existing load-data section and connect it to the same downstream workflow. Preserve the completed guide and navigation; don't reopen the entire outline or invent `Describe`/`LoadCsvString` APIs in place of `Description`/`LoadCsvFromString`.

**Acceptance criteria:** With a stated package version, run file and string loading against the same valid CSV and compare row/column counts, types, and representative values. Keep C#/VB examples consistent and verify that the subsequent transformation, merge, and save still work. Don't close solely because the original guide PR merged while the named input option remains undocumented.

### dotnet/docs#33258: Add the general ONNX model-consumption guide

**Issue:** [dotnet/docs#33258](https://github.com/dotnet/docs/issues/33258). **Opened:** December 28, 2022. **Size:** Medium to large. **GHCP suitability:** Suitable for the explicit outline, coordinated with current assignee `luisquintanilla`.

**Why it still applies:** [dotnet/docs#33532](https://github.com/dotnet/docs/pull/33532) closed without merging, despite its closing reference and the issue's `in-pr` label. The proposed how-to isn't in the checkout. The existing [object-detection tutorial](../docs/machine-learning/tutorials/object-detection-onnx.md) and [save/load guide](../docs/machine-learning/how-to-guides/save-load-machine-learning-models-ml-net.md) provide pieces, not the requested general schema/hardware/pipeline guide.

**Proposed assignment scope:** Complete the specified how-to: ONNX use cases, model inspection with Netron, input/output names and shapes, POCO mappings, shape overrides, CPU/GPU prerequisites, and the prediction pipeline. Reuse verified existing examples and the abandoned PR only as an outline, not proof of working code. Cover the requested pretrained/Azure export categories with current capability and lifecycle qualifications; don't imply that every AutoML model or service export supports ONNX. Add the page to the existing ML.NET TOC and check redirects.

**Acceptance criteria:** Run an available, identified model through the documented CPU path and record real outputs. Verify any advertised GPU path with its provider/package/hardware requirements rather than promise untested fallback or universal acceleration. Check every schema dimension and preserve preprocessing compatibility. Map adapted source sections and flag generated material for expert review; don't infer completion from the closed PR.

### dotnet/docs#33273: Correct CRLF parsing across ReadOnlySequence segments

**Issue:** [dotnet/docs#33273](https://github.com/dotnet/docs/issues/33273). **Opened:** December 30, 2022. **Size:** Small to medium. **GHCP suitability:** Strong; the published implementations supply a direct regression comparison.

**Why it still applies:** The [buffers article](../docs/standard/io/buffers.md) still includes the defective manual `snippet6` from [MyClass.cs](../samples/snippets/csharp/buffers/MyClass.cs). A CR without a following LF can leave invalid search state, and direct access to an empty next segment also fails. The same file's `snippet10` already implements the intended contract through `SequenceReader`.

**Proposed assignment scope:** Correct the manual example and any affected explanation/callers to preserve the existing complete-CRLF contract. Reuse the known-correct helper where appropriate instead of inventing a competing parser. Don't assume the suggested one-line index reset fixes repeated CRs, later valid delimiters, and empty segments. Keep the low-level slicing explanation consistent with the final code.

**Acceptance criteria:** Cover array-backed and linked segments, CRLF within/across segments, missing LF, trailing CR, multiple CRs, empty segments, and empty lines. A false result must preserve the input; success must return the line without CRLF and consume exactly through the delimiter. An owned nine-case linked-segment run against the actual source passed only five cases with the manual helper and all nine with the existing `SequenceReader` helper. Add regression evidence for the final published snippet rather than merely show it compiles.

### dotnet/docs#33293: Give Native AOT its own .NET 7 feature section

**Issue:** [dotnet/docs#33293](https://github.com/dotnet/docs/issues/33293). **Opened:** January 3, 2023. **Size:** Small, prose/navigation only. **GHCP suitability:** Strong; the requested prominence change is explicit.

**Why it still applies:** [What's new in .NET 7](../docs/core/whats-new/dotnet-7.md#performance) still presents Native AOT only as a performance-list item. The issue specifically asks for a standalone section so deployment-oriented readers don't miss the feature.

**Proposed assignment scope:** Promote the existing feature description to a peer-level Native AOT section and link the established deployment guidance. Explain the .NET 7 console-app/trimming context without importing later release capabilities. Correct the unqualified "no external dependencies" wording: an app can avoid an installed .NET runtime while retaining native platform dependencies. Don't imply that AOT first made every self-contained CLI deployment possible.

**Acceptance criteria:** The page's headings expose Native AOT independently of performance, existing links remain valid, and the wording distinguishes runtime independence from absence of all dependencies. Keep the historical version scope and avoid a duplicate deployment tutorial.

### dotnet/docs#33345: Add an introductory LINQ roadmap

**Issue:** [dotnet/docs#33345](https://github.com/dotnet/docs/issues/33345). **Opened:** January 5, 2023. **Size:** Small, prose/navigation only. **GHCP suitability:** Strong with current assignee `BillWagner`'s agreement.

**Why it still applies:** The [LINQ overview](../docs/standard/linq/index.md) still starts with a dense API-oriented sentence and immediately enters examples. Its XML examples don't substitute for a clear introduction or a direct route into the separate [LINQ to XML guide](../docs/standard/linq/linq-xml-overview.md).

**Proposed assignment scope:** Rewrite the introductory paragraph in plain language and add a compact roadmap to the existing LINQ fundamentals, LINQ to XML, and relevant provider guidance. Preserve working examples and current language coverage. The title's landing-page suggestion isn't approval to convert the article to a new YAML format, move the guide, or redesign its entire content set.

**Acceptance criteria:** A new reader can identify LINQ's purpose and navigate directly to LINQ to XML before the long examples. Verify target files and anchors and coordinate the small editorial change with the owner; don't create another tutorial.

### dotnet/docs#33644: Complete CSharpParseOptions override descriptions

**Issue:** [dotnet/docs#33644](https://github.com/dotnet/docs/issues/33644). **Opened:** January 20, 2023. **Size:** Small, API-source change. **GHCP suitability:** Strong after an owning-repository handoff.

**Why it still applies:** The [CSharpParseOptions API XML](https://github.com/dotnet/roslyn-api-docs/blob/main/dotnet/xml/Microsoft.CodeAnalysis.CSharp/CSharpParseOptions.xml) still leaves the `Features` and `Language` summaries as `To be added`, although [ParseOptions](https://github.com/dotnet/roslyn-api-docs/blob/main/dotnet/xml/Microsoft.CodeAnalysis/ParseOptions.xml) documents their base contracts. `PreprocessorSymbolNames` already has a summary, so the original list shouldn't be copied as a list of wholly undocumented properties.

**Proposed assignment scope:** Fill the missing override summaries with the correct inherited/C#-specific meaning and verify the corresponding rendered member pages. Use the API repository's established inheritance/content pattern; don't add conceptual Markdown to this checkout as a substitute for the API fix or advertise experimental feature keys as stable compiler options.

**Acceptance criteria:** Both member pages provide meaningful descriptions consistent with the base contracts, and existing documented overrides remain intact. Arrange the change in `dotnet/roslyn-api-docs` and obtain Roslyn API review before assignment.

### dotnet/docs#33728: Explain runtime registration of a custom type converter

**Issue:** [dotnet/docs#33728](https://github.com/dotnet/docs/issues/33728). **Opened:** January 26, 2023. **Size:** Small to medium, paired-language example and cross-links. **GHCP suitability:** Suitable with component-model/Windows Forms coordination.

**Why it still applies:** The [type-conversion guide's TypeConverter section](../docs/standard/base-types/type-conversion.md#the-typeconverter-class) only describes attribute association. The [Windows Forms team's registration guide](https://github.com/dotnet/winforms/blob/main/docs/serialization/register-custom-type-converter.md) already supplies a concrete provider/descriptor implementation and registration/removal sequence, but that recipe isn't linked from the general conceptual section.

**Proposed assignment scope:** Extend the existing section with the no-source-attribute scenario, a link to the established recipe, and a minimal C#/VB runtime demonstration of `TypeDescriptor` registration and cleanup. Arrange a TypeConverter API-remarks cross-link with its API owner so the original entry point leads to the recipe. Reuse the documented provider pattern rather than invent a converter framework. Coordinate with `lonitra` and the existing [dotnet/winforms#8296](https://github.com/dotnet/winforms/issues/8296) designer-documentation task; don't duplicate that task or promise that process-local runtime registration automatically reaches an out-of-process designer, XAML loader, or every serializer.

**Acceptance criteria:** An owned example changes the converter returned for the selected type, performs the intended conversion, and restores the previous provider afterward. Clarify process/type scope and verify the conceptual/API navigation together. The API-remarks change needs a separate API-owner handoff, not an assumed docs-only publication.

### dotnet/docs#33785: Use a still-valid flexible-type contrast

**Issue:** [dotnet/docs#33785](https://github.com/dotnet/docs/issues/33785). **Opened:** January 30, 2023. **Size:** Small, F# prose and snippet correction. **GHCP suitability:** Strong; the current compiler reproduces a valid replacement distinction.

**Why it still applies:** The [flexible-types guide](../docs/fsharp/language-reference/flexible-types.md) and its [first snippet](../samples/snippets/fsharp/lang-ref-2/snippet4101.fs) still use an inline list-returning lambda to argue that the nonflexible parameter requires an explicit sequence conversion. Current F# accepts that lambda without the cast, so the example no longer proves the stated contrast.

**Proposed assignment scope:** Correct the implicit-conversion explanation and demonstrate the difference with an already-bound `unit -> int list` function passed to ordinary and flexible sequence-returning parameters. Retain the distinct `Seq.concat` lesson. Don't replace the stale example with another case that both declarations accept, or state that flexible types are obsolete.

**Acceptance criteria:** Run the positive and expected-failure examples with the supported stable compiler. In an owned FSI probe, the inline lambda and the prebound function passed to the flexible parameter both printed `1`; the same prebound function passed to `unit -> seq<int>` failed with FS0001. Attempts to select language version 6 were rejected by the installed compiler as out of support, so don't describe that attempted check as historical-version execution evidence.

### dotnet/docs#33866: Explain CSharpSyntaxWalker depth modes and their default

**Issue:** [dotnet/docs#33866](https://github.com/dotnet/docs/issues/33866). **Opened:** February 5, 2023. **Size:** Small, API documentation. **GHCP suitability:** Strong after a Roslyn API-source handoff.

**Why it still applies:** The [walker API XML](https://github.com/dotnet/roslyn-api-docs/blob/main/dotnet/xml/Microsoft.CodeAnalysis.CSharp/CSharpSyntaxWalker.xml) still leaves the constructor's `depth` parameter and the `Depth` summary as placeholders. The class summary mentions tokens without explaining why the default walker doesn't visit them.

**Proposed assignment scope:** Describe `SyntaxWalkerDepth` as traversal categories, not a numeric tree-depth limit. Explain the default `Node`, progressively included token/trivia visits, and descent into structured trivia. Align the constructor, property, and class summaries, and link the enum rather than duplicate unrelated walker internals.

**Acceptance criteria:** Verify all four modes against one syntax tree with tokens, ordinary trivia, and XML documentation trivia. An owned SDK-assembly probe observed no token/trivia callbacks for `Node`, tokens only for `Token`, trivia for `Trivia`, and additional structured-trivia nodes for `StructuredTrivia`. Publish the correction in `dotnet/roslyn-api-docs` with API-owner review, not only in a local conceptual article.

### dotnet/docs#33924: Put the OLS package prerequisite beside the examples

**Issue:** [dotnet/docs#33924](https://github.com/dotnet/docs/issues/33924). **Opened:** February 8, 2023. **Size:** Small, API example prerequisites/navigation. **GHCP suitability:** Strong after ML.NET API-owner coordination.

**Why it still applies:** The reporter [confirms](https://github.com/dotnet/docs/issues/33924#issuecomment-1447321194) that `Microsoft.ML.Mkl.Components` resolves the missing extension, but explicitly retains a request for the package requirement in the example and for trainer discovery. The live API header already names that package; its [owning XML](https://github.com/dotnet/ml-api-docs/blob/live/dotnet/xml/Microsoft.ML/MklComponentsCatalog.xml) still embeds both OLS examples without an explicit prerequisite in their remarks. Don't present the header's package information as absent.

**Proposed assignment scope:** Add a concise package prerequisite beside both OLS examples in `dotnet/ml-api-docs` and link the existing [algorithm/trainer inventory](../docs/machine-learning/how-to-choose-an-ml-net-algorithm.md), which already includes OLS and other regression trainers. Explain that extension availability depends on the relevant trainer package; don't invent a rationale for package partitioning or build a new exhaustive trainer catalog. Coordinate with `luisquintanilla`, who supplied the original package answer.

**Acceptance criteria:** A minimal project with aligned, supported stable ML.NET/MKL package versions resolves `mlContext.Regression.Trainers.Ols` and executes the documented example. Verify any native-platform prerequisites and both rendered example locations. Arrange the API-repository handoff before assignment; a change only to the general algorithm guide won't fix the example's locality.

### dotnet/docs#33939: Add an asynchronous duplex named-pipe example

**Issue:** [dotnet/docs#33939](https://github.com/dotnet/docs/issues/33939). **Opened:** February 9, 2023. **Size:** Medium, paired client/server example. **GHCP suitability:** Suitable as a bounded supplement, not a rewrite of pipe security guidance.

**Why it still applies:** The [named-pipe article](../docs/standard/io/how-to-use-named-pipes-for-network-interprocess-communication.md) demonstrates synchronous request/response and impersonation, but doesn't supply the requested async client/server communication example.

**Proposed assignment scope:** Add a small `PipeDirection.InOut` client/server pair with asynchronous connection and read/write operations, explicit framing, cancellation, and deterministic disposal. Demonstrate traffic in both directions and explain what the sample does and doesn't make simultaneous. Preserve the existing impersonation lesson separately; don't use arbitrary server-side file access just to demonstrate duplex transport. Follow the article's platform boundaries, including Unix-domain-socket implementation details.

**Acceptance criteria:** Execute both endpoints on owned fixtures, show the messages received in each direction, and cover disconnect/cancellation without a hang. Use both C# and VB if the general article adds new runnable samples. Build the projects and verify framing/flush behavior rather than infer duplex correctness from successful compilation.

### dotnet/docs#33969: Make Fuslogvw prerequisites and elevated launch discoverable

**Issue:** [dotnet/docs#33969](https://github.com/dotnet/docs/issues/33969). **Opened:** February 10, 2023. **Size:** Small, Windows setup/troubleshooting. **GHCP suitability:** Suitable with a verified Windows SDK/Visual Studio fixture.

**Why it still applies:** The [Fuslogvw reference](../docs/framework/tools/fuslogvw-exe-assembly-binding-log-viewer.md) tells readers to run the bare command from an elevated developer shell without enough help when the tool isn't installed, the environment isn't initialized, or the shell isn't elevated. The issue's failure to find that route remains distinct from assembly-binding-log interpretation.

**Proposed assignment scope:** Add a prerequisite and launch signpost to the relevant .NET Framework SDK tools and developer-shell instructions. Explain how to start a separate elevated, initialized shell and locate the matching tool; qualify any example installation path and architecture. Don't claim Visual Studio can never launch an elevated shell or that every installation includes the required SDK component. Keep the scope on .NET Framework, not modern .NET assembly diagnostics.

**Acceptance criteria:** On an owned Windows fixture, verify the documented installed component, actual executable location, shell initialization, and elevated launch. No `fuslogvw.exe` was available on the current PATH, and no elevation or viewer launch was attempted during triage. Don't publish a guessed hard-coded SDK path or change shared-machine logging/registry settings to satisfy the check.

### dotnet/docs#34454: Add a Bicep role-assignment alternative

**Issue:** [dotnet/docs#34454](https://github.com/dotnet/docs/issues/34454). **Opened:** March 8, 2023. **Size:** Small to medium, infrastructure example in a shared include. **GHCP suitability:** Strong after Azure documentation-owner coordination.

**Why it still applies:** The [current developer-account guide](../docs/azure/sdk/authentication/local-development-dev-accounts.md) consumes [assign-group-roles.md](https://github.com/MicrosoftDocs/azure-dev-docs/blob/main/articles/includes/authentication/assign-group-roles.md) from `MicrosoftDocs/azure-dev-docs`. That include still offers only portal and Azure CLI tabs for the role assignment. The old article's redirect isn't evidence that infrastructure-as-code coverage was added.

**Proposed assignment scope:** Add a Bicep alternative for the same existing Microsoft Entra group and resource-group-scoped role assignment. Parameterize the group object ID and role definition, use a deterministic role-assignment name and correct principal type, and explain the deployment identity's role-assignment permission. Reuse Azure RBAC's established Bicep resource pattern. Don't broaden the scope/permissions or turn the task into group provisioning or an authentication rewrite.

**Acceptance criteria:** Compile the Bicep and validate an idempotent deployment on an owned Azure fixture with the same principal, role, and scope as the other tabs. Review all consumers of the shared include and tab grouping. Arrange the include change in `MicrosoftDocs/azure-dev-docs`; editing only the .NET article won't update the embedded instructions.

### dotnet/docs#34467: Explain implementation-only incremental generator output

**Issue:** [dotnet/docs#34467](https://github.com/dotnet/docs/issues/34467). **Opened:** March 8, 2023. **Size:** Small, API-source clarification. **GHCP suitability:** Strong after a Roslyn API handoff.

**Why it still applies:** The [API XML](https://github.com/dotnet/roslyn-api-docs/blob/main/dotnet/xml/Microsoft.CodeAnalysis/IncrementalGeneratorInitializationContext.xml) describes implementation output as treated differently in some scenarios, but leaves remarks empty. The [compiler's feature guide](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md) already states the precise distinction, and [dotnet/roslyn#57963](https://github.com/dotnet/roslyn/issues/57963#issuecomment-1460710846) explicitly retains the Learn API-page gap after that guide was updated.

**Proposed assignment scope:** Explain the relationship between `RegisterSourceOutput` and `RegisterImplementationSourceOutput` on both single-value and values-provider overloads, with reciprocal links. Implementation-only output declares no semantic impact on user-code analysis, so an analysis host can skip it; an executable-producing host runs it. Don't describe the distinction as reflection-only code versus ordinary code or promise every IDE always skips it.

**Acceptance criteria:** Match the compiler-owner contract and verify all affected rendered overloads in `dotnet/roslyn-api-docs`. An owned driver probe generated four files normally and only the two ordinary-output files when implementation output was explicitly disabled, covering all four overloads. That controlled driver test isn't a measurement of a particular IDE's optimization policy.

### dotnet/docs#34475: Focus the displayed named-pipe examples

**Issue:** [dotnet/docs#34475](https://github.com/dotnet/docs/issues/34475). **Opened:** March 9, 2023. **Size:** Medium, example presentation/refactoring. **GHCP suitability:** Suitable as one coordinated article change with the retained duplex-example task.

**Why it still applies:** The [named-pipe article](../docs/standard/io/how-to-use-named-pipes-for-network-interprocess-communication.md) still displays the broad `01` regions of the full multi-threaded impersonation/file-transfer client and server. Those programs combine protocol helpers, identity handling, file access, and IPC setup rather than isolate the basic pipe lesson.

**Proposed assignment scope:** Put a compact, focused client/server path first, show short regions around connection and data exchange, and link complete runnable projects. Keep the existing impersonation/file-transfer scenario as a separate advanced example with its prerequisites. Coordinate with [dotnet/docs#33939](https://github.com/dotnet/docs/issues/33939) rather than assign a second competing sample rewrite. Preserve C#/VB coverage and platform distinctions; don't remove security context just to shorten a code block.

**Acceptance criteria:** The displayed regions teach one step at a time without unrelated helpers or unnecessarily wide statements, while full source remains available. Build and execute the paired minimal sample and verify messages/cleanup, then check the rendered layout. Preserve advanced-example behavior and cross-links; an accordion around the same oversized block alone doesn't meet the request.

### dotnet/docs#34480: Identify the archived custom-provider walkthrough

**Issue:** [dotnet/docs#34480](https://github.com/dotnet/docs/issues/34480). **Opened:** March 9, 2023. **Size:** Small, prose/link context. **GHCP suitability:** Strong with current assignee `BillWagner`'s agreement.

**Why it still applies:** The [LINQ overview](../docs/standard/linq/index.md) still introduces the previous-versions provider walkthrough without any historical qualification. The discussion distinguishes the reader's concern about applicability from the archived site's language selector; the maintainer doesn't propose changes inside the unmaintained page.

**Proposed assignment scope:** Label the destination as an archived walkthrough, describe its advanced custom-provider purpose, and pair it with the current `IQueryable`/`IQueryProvider` API entry points. Don't imply the APIs are obsolete or that the old sample is broken merely because its host is archived. Coordinate the localized change with [dotnet/docs#33345](https://github.com/dotnet/docs/issues/33345)'s introductory roadmap in the same article pass; don't create another provider tutorial or edit the archive's language UI.

**Acceptance criteria:** The source page sets the destination's maintenance/version context before navigation and supplies working current API links. Preserve the historical example as an explicitly identified reference rather than silently substitute an unrelated dynamic-query tutorial.

### dotnet/docs#34638: Correct the ReadyToRun cross-target table

**Issue:** [dotnet/docs#34638](https://github.com/dotnet/docs/issues/34638). **Opened:** March 17, 2023. **Size:** Small to medium, version-qualified table correction. **GHCP suitability:** Suitable with a Linux build fixture and runtime-owner review.

**Why it still applies:** The [ReadyToRun table](../docs/core/deploying/ready-to-run.md) still excludes Windows from the Linux x64 host row for .NET 6 and later. The modern SDK's [compiler-selection source](https://github.com/dotnet/sdk/blob/v10.0.100/src/Tasks/Microsoft.NET.Build.Tasks/ResolveReadyToRunCompilers.cs) selects the Crossgen2 host tool and target OS separately; its old same-platform restriction belongs to the legacy Crossgen path, not a blanket rule for modern Crossgen2.

**Proposed assignment scope:** Verify the reported Linux x64-to-Windows target with the applicable supported SDK, correct the affected cells/release qualifications, and retain the separate historical table. Don't copy Native AOT's cross-OS limitation into ReadyToRun or extrapolate a complete host/architecture matrix from one successful target.

**Acceptance criteria:** Publish on Linux for the stated Windows RID with ReadyToRun enabled, inspect the output's ReadyToRun header, and run it on a matching Windows fixture. Distinguish plain IL publication from actual R2R output. No Linux-to-Windows publish was executed during triage; obtain owner confirmation of the supported release scope before publishing the table correction.

### dotnet/docs#34675: Qualify the unsupported IdentityServer4 recipes

**Issue:** [dotnet/docs#34675](https://github.com/dotnet/docs/issues/34675). **Opened:** March 21, 2023. **Size:** Small, support-status/signpost correction. **GHCP suitability:** Strong for the bounded correction, not a wholesale provider migration.

**Why it still applies:** The [microservices authentication chapter](../docs/architecture/microservices/secure-net-microservices-web-applications/index.md) still presents IdentityServer4 configuration as current guidance. The [provider's README](https://github.com/IdentityServer/IdentityServer4) explicitly says it isn't maintained and went out of support on December 13, 2022. Its former documentation link now redirects to Duende documentation, which doesn't make the old package/configuration current.

**Proposed assignment scope:** Clearly mark the IdentityServer4 instructions as historical/unsupported and stop presenting them as a supported production starting point. Link current ASP.NET Core authentication guidance and accurately identified provider documentation. Distinguish IdentityServer4 from Duende IdentityServer and link the latter's licensing terms, including applicable community eligibility, rather than call it a universally free drop-in update. Review the chapter's provider references and further-reading links together.

**Acceptance criteria:** Readers see the support boundary before the legacy steps and have a maintained next step. Don't silently rename packages/APIs or claim a verified provider migration without executing one. A full reference-application/provider replacement remains a separate architecture decision; this brief addresses the concrete misleading support claim.

### dotnet/docs#34862: Explain narrow suppression at a logging adapter boundary

**Issue:** [dotnet/docs#34862](https://github.com/dotnet/docs/issues/34862). **Opened:** April 3, 2023. **Size:** Small, analyzer rationale and focused example. **GHCP suitability:** Strong with analyzer review.

**Why it still applies:** The [CA2254 suppression section](../docs/fundamentals/code-analysis/quality-rules/ca2254.md#when-to-suppress-errors) doesn't discuss a pass-through logger adapter. The cited [adapter source](https://github.com/dotnet-architecture/eShopOnWeb/blob/main/src/Infrastructure/Logging/LoggerAdapter.cs) forwards the template and argument array unchanged. An owned stable-SDK probe emitted CA2254 at that forwarding call even when the caller supplied a constant template.

**Proposed assignment scope:** Explain a narrowly justified suppression at the forwarding boundary when the caller contract preserves a constant template and separate values. Show the difference from an adapter that interpolates/concatenates or accepts genuinely varying templates. Layer placement or an interface alone isn't justification; don't recommend a project-wide suppression or describe all wrappers as false positives. Use both language examples if the general rule page adds executable code.

**Acceptance criteria:** Verify the analyzer result and structured log state. The owned run preserved `OriginalFormat=Person {Name}` and `Name=Ada`; a local suppression removed only the wrapper diagnostic while the direct interpolated call still warned. Apply the same proof to the final published sample and state the caller/template contract rather than hide a real loss of structured data.

### dotnet/docs#34908: Show how to populate a Linux user certificate store

**Issue:** [dotnet/docs#34908](https://github.com/dotnet/docs/issues/34908). **Opened:** April 6, 2023. **Size:** Small to medium, paired-language recipe. **GHCP suitability:** Strong with an isolated Linux test fixture.

**Why it still applies:** The [cross-platform cryptography guide](../docs/standard/security/cross-platform-cryptography.md#x509store) documents read/write support and creation on first write, but doesn't show how to add a certificate to `CurrentUser\My`. The comment's internal storage path isn't a supported import procedure.

**Proposed assignment scope:** Add a concise `X509Store` open/add/find recipe for `StoreName.My` and `StoreLocation.CurrentUser`, with certificate-loading and private-key requirements appropriate to the selected supported .NET version. Explain application identity/home-directory scope, disposal, and the difference between personal key storage and trusted roots. Don't direct users to copy files into an implementation-private directory, use unsupported Linux `LocalMachine\My`, or promise that store placement alone makes Data Protection configuration work.

**Acceptance criteria:** In an owned Linux home/profile, add a disposable test certificate, reopen the store under the same identity, find it by thumbprint, and verify private-key usability when required. Test both C# and VB, remove only the owned certificate afterward, and avoid shared user/root stores. Don't infer Linux persistence from a Windows-only run.

### dotnet/docs#34916: Connect native package assets to P/Invoke probing

**Issue:** [dotnet/docs#34916](https://github.com/dotnet/docs/issues/34916). **Opened:** April 7, 2023. **Size:** Small, explanation and authoritative cross-links. **GHCP suitability:** Strong; the packaging/loading contract is already documented elsewhere.

**Why it still applies:** The old page redirects to [native library loading](../docs/standard/native-interop/native-library-loading.md), which explains name variants and a custom resolver but still doesn't connect NuGet's `runtimes` layout to native dependency selection. The [NuGet native-files guide](https://learn.microsoft.com/nuget/create-packages/native-files-in-net-packages) already explains RID-specific versus RID-less publish output and `.deps.json`.

**Proposed assignment scope:** Add a short package-asset subsection and link the NuGet guide, RID guidance, and [host-configured native probing](../docs/core/dependency-loading/default-probing.md). Distinguish native `runtimes/{rid}/native` assets from managed `runtimes/{rid}/lib/{tfm}` assets, and explain the host's dependency metadata/search paths. Don't say `DllImport` recursively scans arbitrary `runtimes` folders, require a custom resolver for ordinary package assets, or apply the modern contract unchanged to .NET Framework.

**Acceptance criteria:** Match the authoritative RID and publish-mode distinctions, including current portable-RID rules. Verify links and any concrete output/layout example against an owned package; if the change adds runnable publish/P/Invoke steps, execute the stated RID-specific and RID-less cases with matching native fixtures. Keep the task a bridge to established packaging guidance, not a duplicate packaging tutorial.

### dotnet/docs#35043: Distinguish the two type-forwarding attributes

**Issue:** [dotnet/docs#35043](https://github.com/dotnet/docs/issues/35043). **Opened:** April 18, 2023. **Size:** Small, conceptual clarification and API cross-links. **GHCP suitability:** Suitable with runtime/serialization-owner review.

**Why it still applies:** The [type-forwarding guide](../docs/standard/assembly/type-forwarding.md) explains only `TypeForwardedToAttribute`. The [TypeForwardedFrom API source](https://github.com/dotnet/dotnet-api-docs/blob/main/xml/System.Runtime.CompilerServices/TypeForwardedFromAttribute.xml) still offers only the brief origin-tracing statement. Runtime source distinguishes assembly-level forwarding metadata from a type-level original assembly identity; the legacy formatter reads the latter.

**Proposed assignment scope:** Explain where each attribute belongs and that origin metadata doesn't create a forwarder or become a universal requirement for an ordinary type move. Describe the compatibility scenario with explicit serializer/version qualifications, not a blanket recommendation to add it everywhere. Add discoverable conceptual back-links in the two API topics through `dotnet/dotnet-api-docs`, coordinated with the existing API cross-link effort.

**Acceptance criteria:** Preserve the existing binary-compatible type-move walkthrough and verify it without assuming `TypeForwardedFrom` is mandatory. Confirm the origin identity behavior against the actual consuming implementation. Don't introduce a new BinaryFormatter recipe or portray its removed/unsupported modern implementation as a recommended serializer.

### dotnet/docs#35094: Signpost runtime-specific mobile GC configuration

**Issue:** [dotnet/docs#35094](https://github.com/dotnet/docs/issues/35094). **Opened:** April 21, 2023. **Size:** Small, scope note and platform links. **GHCP suitability:** Strong with Android/Apple runtime review.

**Why it still applies:** The [GC configuration page](../docs/core/runtime-config/garbage-collector.md) doesn't identify mobile runtime/configuration differences. The current [Android build-property reference](https://learn.microsoft.com/dotnet/android/building-apps/build-properties#androidenablesgenconcurrent) explicitly scopes `AndroidEnableSGenConcurrent` to supported Mono projects, not CoreCLR or NativeAOT. The [Apple build-property reference](https://learn.microsoft.com/dotnet/ios/building-apps/build-properties#enablesgenconc) similarly scopes `EnableSGenConc` to Mono and identifies the older property as deprecated.

**Proposed assignment scope:** Add a short mobile/runtime applicability note and links to those maintained platform guides. Explain that Mono's SGen controls aren't interchangeable with the listed runtime GC settings; identify runtime and release before choosing a configuration mechanism. Don't imply every Android/iOS deployment always uses the same runtime or apply a preview runtime transition retroactively to supported releases.

**Acceptance criteria:** Platform owners confirm the scope and current property names/aliases. Keep the change a signpost rather than invent a complete mobile GC tuning matrix. If it adds an executable configuration recipe, validate it on the applicable mobile workload; a desktop CoreCLR process doesn't validate SGen behavior.

### dotnet/docs#35127: Define the MAUI Toolkit XAML prefix

**Issue:** [dotnet/docs#35127](https://github.com/dotnet/docs/issues/35127). **Opened:** April 26, 2023. **Size:** Small, namespace/prerequisite clarification. **GHCP suitability:** Strong with MAUI sample-version review.

**Why it still applies:** The [validation chapter](../docs/architecture/maui/validation.md#highlighting-a-control-that-contains-invalid-data) still uses `mct:EventToCommandBehavior` without defining `mct`. The maintained [Toolkit behavior reference](https://learn.microsoft.com/dotnet/communitytoolkit/maui/behaviors/event-to-command-behavior) supplies the `http://schemas.microsoft.com/dotnet/2022/maui/toolkit` mapping and explains the behavior's explicit binding-context requirements.

**Proposed assignment scope:** Define the prefix in its containing XAML/root context and link the CommunityToolkit.Maui package/initialization prerequisites. Distinguish the UI Toolkit namespace from CommunityToolkit.Mvvm; `mct` is an example prefix, not a built-in XML namespace. Preserve the validation lesson instead of rewrite the whole chapter.

**Acceptance criteria:** The referenced toolkit type resolves for the stated sample version, and the command still runs on the control event. Don't repair only XML parsing while retaining an incompatible implicit behavior `BindingContext` assumption in a sample updated to a current Toolkit. Check prerequisite links and the rendered XAML; no MAUI workload was executed during triage.

### dotnet/docs#35180: Make semaphore platform boundaries explicit

**Issue:** [dotnet/docs#35180](https://github.com/dotnet/docs/issues/35180). **Opened:** April 27, 2023. **Size:** Small, introduction/description correction. **GHCP suitability:** Strong; the runtime source settles the distinction.

**Why it still applies:** The [semaphore guide](../docs/standard/threading/semaphore-and-semaphoreslim.md) still describes `Semaphore` as a Win32 wrapper in both its description metadata and introduction without a Windows qualification. The owner points to the [Unix implementation](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Threading/Semaphore.Unix.cs), which implements unnamed semaphores but rejects names.

**Proposed assignment scope:** Describe the general counting-semaphore contract first, qualify the Windows implementation, and clearly separate local semaphore support from Windows-only named/systemwide behavior. Correct the metadata too. Don't replace Win32 with an unverified claim that every Unix implementation wraps the same POSIX object, or extend named semaphore/ACL advice to Unix.

**Acceptance criteria:** Verify unnamed acquisition/release on Windows and Linux and the named-constructor platform boundary against the selected supported runtime. Preserve Windows named-semaphore/security guidance and `SemaphoreSlim`'s process-local distinction. Keep implementation details version-scoped rather than promise an internal representation.

### dotnet/docs#35181: Explain how to obtain a control-flow graph's entry block

**Issue:** [dotnet/docs#35181](https://github.com/dotnet/docs/issues/35181). **Opened:** April 27, 2023. **Size:** Small, API-source clarification. **GHCP suitability:** Strong after a Roslyn API handoff.

**Why it still applies:** The [ControlFlowGraph API source](https://github.com/dotnet/roslyn-api-docs/blob/main/dotnet/xml/Microsoft.CodeAnalysis.FlowAnalysis/ControlFlowGraph.xml) mentions an entry block but doesn't say how to obtain it. The [BasicBlockKind contract](https://github.com/dotnet/roslyn-api-docs/blob/main/dotnet/xml/Microsoft.CodeAnalysis.FlowAnalysis/BasicBlockKind.xml) explicitly says the entry is the first block and the exit is the last.

**Proposed assignment scope:** Put the ordering guarantee and `Blocks[0]` discovery guidance beside the class/`Blocks` property, cross-link the entry/exit kind definitions, and distinguish the entry boundary from the first user operation. Don't invent an `Entry` property or imply the entry block itself contains the method's first statement.

**Acceptance criteria:** An owned compiler-API probe produced `Entry` at ordinal 0 and `Exit` at the final position. Validate the final wording against the authoritative ordering guarantee and publish through `dotnet/roslyn-api-docs`; a conceptual docs edit alone can't correct the API page.

### dotnet/docs#43915: Map the global-using F1 keyword to the using guide

**Issue:** [dotnet/docs#43915](https://github.com/dotnet/docs/issues/43915). **Opened:** April 27, 2023. **Size:** Small, F1 metadata. **GHCP suitability:** Strong with an IDE lookup check; coordinate with current assignee `arunchndr`.

**Why it still applies:** [dotnet/roslyn#76327](https://github.com/dotnet/roslyn/pull/76327) merged the distinct `global-using_CSharpKeyword` help label, and current compiler IDE source still emits it. The [using-directive guide](../docs/csharp/language-reference/keywords/using-directive.md) lists `using_CSharpKeyword` and `using-static_CSharpKeyword`, but not the new global-using label.

**Proposed assignment scope:** Add the distinct label to the using-directive page's F1 metadata. Preserve the namespace-alias page's `global_CSharpKeyword` mapping, which is still appropriate for `global::`, and preserve existing using/static help labels. The merged compiler PR fixes only one half of the integration.

**Acceptance criteria:** In an IDE that emits the new label, F1 on `global using` reaches the using guide; `using static`, ordinary `using`, and `global::` retain the correct destinations. Confirm the published help mapping, not only the YAML edit. Follow original creation order despite the issue's later transferred number.

### dotnet/docs#35322: Add a source-backed F# version-history overview

**Issue:** [dotnet/docs#35322](https://github.com/dotnet/docs/issues/35322). **Opened:** May 12, 2023. **Size:** Medium, one new overview and TOC entry. **GHCP suitability:** Suitable with an F# maintainer's factual review.

**Why it still applies:** The [F# TOC](../docs/fsharp/toc.yml) lists individual release pages but no history overview. Existing [What's New pages](../docs/fsharp/whats-new/fsharp-10.md) cover modern language versions, and the author's [early-history paper](https://fsharp.org/history/hopl-final/hopl-fsharp.pdf) supplies the historical source the issue identifies.

**Proposed assignment scope:** Add `docs/fsharp/whats-new/fsharp-version-history.md`, modeled on the C# history article's concise release/feature navigation, and include it in the TOC. Use the paper for early context and the individual release articles/accepted design records for newer version highlights. Cite each release's evidence and link detail rather than duplicate tutorials or invent historical examples.

**Acceptance criteria:** Distinguish language, FSharp.Core, tooling, and .NET release versions. Verify dates and first-feature versions, preserve preview labels, and include the latest documented stable release. Don't fabricate a new release or copy the paper's narrative. Paraphrase sourced facts and flag unverified historical claims for maintainer review; don't guess.

### dotnet/docs#35431: Preserve the backslash in rendered AddSource remarks

**Issue:** [dotnet/docs#35431](https://github.com/dotnet/docs/issues/35431). **Opened:** May 22, 2023. **Size:** Small, API XML/rendering fix. **GHCP suitability:** Strong after a Roslyn API handoff.

**Why it still applies:** Both [GeneratorExecutionContext](https://github.com/dotnet/roslyn-api-docs/blob/main/dotnet/xml/Microsoft.CodeAnalysis/GeneratorExecutionContext.xml) and [SourceProductionContext](https://github.com/dotnet/roslyn-api-docs/blob/main/dotnet/xml/Microsoft.CodeAnalysis/SourceProductionContext.xml) contain the literal backslash, but the live `GeneratorExecutionContext.AddSource` HTML still displays an empty quoted separator. [dotnet/roslyn#83179](https://github.com/dotnet/roslyn/pull/83179) proposed code formatting but closed **unmerged**; it isn't a completed implementation.

**Proposed assignment scope:** Use the API pipeline's supported inline-code markup for the separator characters in the owning XML remarks, and coordinate compiler XML-comment parity where necessary. Check both context types and affected overloads. Don't change generator path behavior or add an unnecessary empty-string restriction to fix a presentation defect.

**Acceptance criteria:** The rendered page visibly shows slash and backslash, including the reported version view. An owned generator run normalized `first\One.cs` to `first/One.cs` and retained `second/Two.cs`; preserve that behavior. A raw-source diff showing a backslash isn't sufficient proof because the defect occurs during publication.

### dotnet/docs#35537: Use SDK versions in the manual CI install examples

**Issue:** [dotnet/docs#35537](https://github.com/dotnet/docs/issues/35537). **Opened:** May 30, 2023. **Size:** Small to medium, paired scripts and version explanation. **GHCP suitability:** Strong with isolated script validation.

**Why it still applies:** The [CI guide](../docs/devops/dotnet-cli-and-continuous-integration.md) still passes runtime-style `6.0.7` as the SDK version in PowerShell, Bash, and the provider example. Its installer invocation doesn't select a runtime-only installation, so that value names a nonexistent SDK payload.

**Proposed assignment scope:** Use one verified supported SDK version consistently, distinguish SDK and runtime patch/feature-band numbering, and link the canonical version/installer guidance. Check every occurrence and the provider assumptions. Don't turn the task into a CI-provider redesign or assert that every historical SDK version must have a three-digit patch.

**Acceptance criteria:** Official release metadata currently identifies SDK 10.0.403; both its Windows x64 and Linux x64 payload URLs returned 200 during triage. Execute the retained scripts in isolated install directories and show the expected `dotnet --version`/build result, including quoting and failure propagation. URL checks alone aren't a full installer or hosted-provider CI run.

### dotnet/docs#35576: Correct the missing earlier CQRS explanation

**Issue:** [dotnet/docs#35576](https://github.com/dotnet/docs/issues/35576). **Opened:** May 31, 2023. **Size:** Small, sentence and contextual cross-link. **GHCP suitability:** Strong; the book already contains the intended explanation.

**Why it still applies:** The [distributed-data chapter](../docs/architecture/microservices/architect-microservice-container-applications/distributed-data-management.md) still says propagation was described earlier for CQRS query tables, but the earlier paragraph only introduces denormalized read tables. The same chapter later describes the catalog/basket integration-event example and links the event-driven communication section.

**Proposed assignment scope:** Replace the false backward reference with a correct forward link and a short description of events updating derived/query data. Preserve source-of-truth ownership and eventual consistency. Don't invent an earlier walkthrough, imply a cross-service database transaction, or expand the correction into a new CQRS implementation tutorial.

**Acceptance criteria:** Follow the chapter in reading order and verify every propagation reference resolves to an actual explanation. The revised sentence and destination agree; no new runtime sample is necessary for the prose/link correction.

### dotnet/docs#35733: Update the legacy certificate-tool setup section

**Issue:** [dotnet/docs#35733](https://github.com/dotnet/docs/issues/35733). **Opened:** June 9, 2023. **Size:** Small to medium, scoped Windows tool guidance. **GHCP suitability:** Suitable with Windows networking-owner review.

**Why it still applies:** The [certificate-selection article](../docs/framework/network-programming/certificate-selection-and-validation.md#tools-for-certificate-configuration) still directs readers to Windows XP/Server 2003 support media and generic Microsoft download links for HttpCfg/Winhttpcertcfg. The maintained [Windows HTTP configuration reference](https://learn.microsoft.com/windows-server/networking/technologies/netsh/netsh-http) documents current HTTP.sys certificate-binding commands.

**Proposed assignment scope:** Refresh the tool section: identify historical instructions, replace obsolete download/CD steps with maintained Windows certificate-management and HTTP.sys binding references, and retain the article's .NET Framework/API scope. Don't present `netsh http` as an automatic replacement for every private-key ACL operation, or confuse an HTTP.sys server binding with client certificate selection or Kestrel configuration.

**Acceptance criteria:** Verify links, supported Windows applicability, certificate-store/private-key permission prerequisites, and any newly shown commands on an owned Windows fixture. Preserve the selection/validation API contract and don't disable certificate validation to simplify setup. Triage didn't execute elevated certificate-binding changes.

### dotnet/docs#35737: Keep placeholder casing guidance consistent

**Issue:** [dotnet/docs#35737](https://github.com/dotnet/docs/issues/35737). **Opened:** June 9, 2023. **Size:** Small, convention clarification and cross-link. **GHCP suitability:** Strong.

**Why it still applies:** [High-performance logging](../docs/core/extensions/logging/high-performance-logging.md) explicitly recommends PascalCase placeholder names. [Source generation](../docs/core/extensions/logging/source-generation.md#case-insensitive-template-name-support) explains case-insensitive parameter matching but doesn't state the same convention. Its current example already combines `{City}`/`{Province}` with camelCase C# parameters correctly.

**Proposed assignment scope:** Add the matching placeholder recommendation and link the common rationale: placeholder names become structured property names. Retain the case-insensitive matching explanation and distinguish a style convention from a compiler/generator requirement. Don't rename normal C# parameters to PascalCase or say all logging APIs bind arguments by name.

**Acceptance criteria:** Preserve a case-insensitive generated-method example and its structured keys. An owned run matched a `city` argument to `{City}` and recorded `City=Vancouver` with `OriginalFormat=Hello {City}`. Keep the prose-only correction focused; no new duplicate logging tutorial is needed.

### dotnet/docs#35828: Give Windows dump readers a concrete starting workflow

**Issue:** [dotnet/docs#35828](https://github.com/dotnet/docs/issues/35828). **Opened:** June 14, 2023. **Size:** Medium, introductory workflow built on existing tool guides. **GHCP suitability:** Suitable with a Windows fixture; coordinate with current assignee `samsp-msft`.

**Why it still applies:** [Debug Windows dumps](../docs/core/diagnostics/debug-windows-dumps.md) still consists of a tool-list paragraph. It links Visual Studio, WinDbg, and dotnet-dump without an introductory path from a dump file to useful process/thread/stack information.

**Proposed assignment scope:** Explain tool choice, matching runtime/architecture and symbol prerequisites, how to open a dump, and a minimal first managed-stack investigation with one supported tool. Link existing tool-specific worked examples for deeper analysis instead of create three full manuals. Preserve that dotnet-dump isn't a native debugger; don't reuse .NET Framework SOS-loading commands blindly for modern .NET.

**Acceptance criteria:** Follow the instructions on Windows against an owned, known-state process dump and record the expected thread/stack result. Mark intentional sample waits as such rather than claim every blocked stack is a deadlock. Don't commit production dumps, which can contain secrets. Triage confirmed the concrete introduction gap but didn't run a debugger session.

### dotnet/docs#35887: Qualify profiler object-size padding for the pinned object heap

**Issue:** [dotnet/docs#35887](https://github.com/dotnet/docs/issues/35887). **Opened:** June 20, 2023. **Size:** Small. **GHCP suitability:** Suitable for a source-backed clarification with profiler/GC-owner review.

**Why it still applies:** The [GetObjectSize remarks](../docs/framework/unmanaged-api/profiling/icorprofilerinfo-getobjectsize-method.md#remarks) list SOH and LOH alignment, but omit POH; the [GetObjectSize2 page](../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-getobjectsize2-method.md) doesn't explain padding. The shared profiler interfaces also serve modern CoreCLR, whereas these pages retain .NET Framework requirements.

**Why the solution is defined:** In [.NET 10 GC source](https://github.com/dotnet/runtime/blob/v10.0.0/src/coreclr/gc/gc.cpp), `GCHeap::Alloc` selects `poh_generation` for `GC_ALLOC_PINNED_OBJECT_HEAP`, then calls `allocate_uoh_object`; that allocator rounds size with `AlignQword` and checks eight-byte object alignment. The [profiler implementation](https://github.com/dotnet/runtime/blob/v10.0.0/src/coreclr/vm/proftoeeinterfaceimpl.cpp) returns object size, not the allocator's trailing heap padding.

**Proposed assignment scope:** Add a version-qualified modern-CoreCLR POH alignment note and make it discoverable from `GetObjectSize2`. Preserve the legacy Framework contract and the recommendation to use `GetObjectSize2`; don't imply that .NET Framework has POH, that every pinned SOH object moves to POH, or that Windows-specific alignment statements describe every runtime/platform.

**Acceptance criteria:** GC/profiler owners confirm the Windows x86/x64 values and version scope against the actual allocation path, and both API pages lead to the clarification. No native profiler/32-bit heap walk was executed during triage; include that platform evidence if the implementation adds a heap-walking example rather than only the source-backed note.

### dotnet/docs#35927: Align the introductory metrics samples

**Issue:** [dotnet/docs#35927](https://github.com/dotnet/docs/issues/35927). **Opened:** June 22, 2023. **Size:** Medium. **GHCP suitability:** Strong; two named articles and their sample/filter references define the work.

**Why it still applies:** [Create metrics](../docs/core/diagnostics/metrics-instrumentation.md#create-a-custom-metric) still uses `HatCo.Store`, `hatco.store.hats_sold`, and a fixed four-hat transaction. [Collect metrics](../docs/core/diagnostics/metrics-collection.md#create-an-example-app) uses the `HatCo.HatStore`/`hats-sold` sample with random transactions. The samples aren't already identical. The closed [dotnet/AspNetCore.Docs#29621](https://github.com/dotnet/AspNetCore.Docs/issues/29621) redirects the same request here; it isn't implementation evidence.

**Proposed assignment scope:** Use one shared minimal console sample for both introductions, with consistent meter/instrument names and transaction behavior. Start from the collection article's existing `snippet` region, update the creation article's corresponding explanation, and align each affected listener filter, collection command, and output label. Preserve separately labeled OpenTelemetry/Prometheus extensions; don't import those dependencies into the first minimal example. The source file's default `SECOND` branch differs from the displayed first region, so explicitly build the intended branch or isolate the shared example.

**Acceptance criteria:** Both introductions display the same baseline code and describe its actual cadence/values. Build/run that baseline and demonstrate that the exact documented meter filter receives its counter measurements; verify the collector-specific variants separately.

### dotnet/docs#35932: Name the emitted desktop application configuration file

**Issue:** [dotnet/docs#35932](https://github.com/dotnet/docs/issues/35932). **Opened:** June 23, 2023. **Size:** Small. **GHCP suitability:** Strong; a localized filename clarification.

**Why it still applies:** The [automatic binding-redirection guide](../docs/framework/configure-apps/how-to-enable-and-disable-automatic-binding-redirection.md#disable-automatic-binding-redirects-in-desktop-apps) calls the output configuration file `app.config` immediately before stating that source `app.config` isn't modified. The naming still obscures where a desktop developer should inspect generated redirects.

**Proposed assignment scope:** Distinguish source `App.config` from the generated `<application>.exe.config` beside a .NET Framework desktop executable. Explain that automatic redirects modify the emitted configuration, not the source file. Preserve the separately documented web-app `web.config` prompt and the existing enable/disable behavior; don't apply Framework binding redirects to modern .NET. Installed SDK MSBuild targets confirm the generated intermediate filename uses `$(TargetFileName).config`.

**Acceptance criteria:** A desktop reader can identify source and output files without treating them as the same path. If an example artifact is added, build a small Framework desktop fixture and show the output redirect and unchanged source; no binding-conflict build was run during triage.

### dotnet/docs#35947: Explain the Azure compute quota prerequisite

**Issue:** [dotnet/docs#35947](https://github.com/dotnet/docs/issues/35947). **Opened:** June 25, 2023. **Size:** Small. **GHCP suitability:** Strong for a prerequisite/troubleshooting note, with ML owner review.

**Why it still applies:** The [object-detection tutorial](../docs/machine-learning/tutorials/object-detection-model-builder.md) already includes compute selection/creation instructions, but its prerequisites don't explain the reported zero-vCPU subscription quota failure. Adding another generic create-compute step alone wouldn't address the actual error.

**Why the solution is defined:** [Azure Machine Learning quota guidance](https://learn.microsoft.com/azure/machine-learning/how-to-manage-quotas?view=azureml-api-2) distinguishes regional total cores, VM-family cores, offer-dependent limits, and quota requests. Some specialized/GPU families start at zero. Those existing instructions supply the missing resolution path.

**Proposed assignment scope:** Add a short prerequisite and signpost beside compute selection: confirm quota for the selected region/VM family and request an eligible increase through the current Azure workflow before training. Link maintained quota and compute guidance instead of copying portal screenshots. Don't assert that every trial/plan has the same limit, promise a free GPU or approved increase, or silently provision billable resources.

**Acceptance criteria:** The reported zero-quota error leads to the correct quota checks and conditional request path. Retain the existing compute steps and state subscription/region assumptions. No Azure resource or training job was created during triage.

### dotnet/docs#36045: Simplify the partial JSON reader without losing stream correctness

**Issue:** [dotnet/docs#36045](https://github.com/dotnet/docs/issues/36045). **Opened:** June 28, 2023. **Size:** Medium. **GHCP suitability:** Suitable for a bounded sample refactor with current assignee `gewarren` and serialization-owner review.

**Why it still applies:** The [stream-reader section](../docs/standard/serialization/system-text-json/use-utf8jsonreader.md#read-from-a-stream-using-utf8jsonreader) still displays the large buffer/logging example. Proposed [dotnet/docs#38755](https://github.com/dotnet/docs/pull/38755) closed unmerged, so it didn't complete the simplification.

**Proposed assignment scope:** Refactor the example into a readable token loop and a focused refill helper, with concise output that demonstrates state preservation and buffer growth. Preserve the existing explanation of partial tokens, leftover bytes, BOM handling, and bounded progress. Count actual bytes read, retain only valid leftover bytes, grow when a token fills the buffer, and distinguish a short read from confirmed EOF. Correct the existing fixture's trailing comma under default reader options. Don't copy the linked gist verbatim: an owned complete-parser check rejected its current raw-string payload because a JSON object remains unclosed; an early property match doesn't validate a whole document.

**Acceptance criteria:** Compile/run the published example and test small buffers, tokens larger than the initial buffer, fragmented reads, final partial buffers, absent target properties, and invalid/truncated JSON. Validate the entire fixture independently even if the demonstrated search stops early. Preserve the documented Visual Basic limitation/C# helper arrangement; don't promise direct use of a ref struct from Visual Basic or equate every short `Stream.Read` with EOF.

### dotnet/docs#36104: Separate synchronous semaphore blocking from async waits

**Issue:** [dotnet/docs#36104](https://github.com/dotnet/docs/issues/36104). **Opened:** July 5, 2023. **Size:** Small. **GHCP suitability:** Strong; precise API semantics and localized prose.

**Why it still applies:** The [semaphore guide](../docs/standard/threading/semaphore-and-semaphoreslim.md) introduces `WaitAsync` but still says a zero count blocks the requesting thread without qualification. An owned zero-count probe obtained an incomplete task, allowed caller progress, released a permit, and completed the wait.

**Proposed assignment scope:** Explain that synchronous `Wait` blocks until entry, whereas `WaitAsync` returns a task and `await` can suspend a logical operation without occupying a waiting thread. Describe the count as a limit on concurrent entries/operations, not exclusively distinct OS threads; async operations can coordinate through the same semaphore. Preserve the lack of thread/task ownership enforcement and the need to release only acquired permits, normally in `finally`. Coordinate this edit with [dotnet/docs#35180](https://github.com/dotnet/docs/issues/35180)'s platform wording in the same article.

**Acceptance criteria:** A reader can distinguish blocking and asynchronous acquisition and understand an async I/O concurrency limit. Any new example demonstrates the actual bound, handles cancellation/acquisition correctly, and doesn't claim a continuation must resume on the original thread.

### dotnet/docs#36240: Remove the unnecessary PowerShell 5 cmdlet dependency

**Issue:** [dotnet/docs#36240](https://github.com/dotnet/docs/issues/36240). **Opened:** July 12, 2023. **Size:** Small. **GHCP suitability:** Strong for a read-only detection correction.

**Why it still applies:** The moved [Framework version-detection guide](../docs/framework/install/how-to-determine-which-versions-are-installed.md#query-the-registry-using-powershell) still calls `Get-ItemPropertyValue` without a minimum-version note. That cmdlet isn't available in the older PowerShell versions identified in the report.

**Proposed assignment scope:** Use `Get-ItemProperty` and explicitly read `.Release` before the existing version switch, so the example doesn't need the newer convenience cmdlet. Preserve descending greater-than-or-equal release checks and the no-detection message. Don't copy the reporter's installer branch: its `Invoke-WebRequest` isn't a PowerShell 2 solution, its download variables aren't defined, and it reports installation success without checking the installer.

**Acceptance criteria:** The read-only old/new retrieval forms produce the same release value and classification, with explicit behavior for absent keys. A current Windows probe confirmed both forms return `534296`; PowerShell 2/4 weren't executed during triage. Validate any promised down-level compatibility in the applicable host rather than infer it from a successful newer-host run. Don't install Framework, edit the registry, or introduce an OS-upgrade recipe.

### dotnet/docs#36242: Align the string-marshalling overview with current guidance

**Issue:** [dotnet/docs#36242](https://github.com/dotnet/docs/issues/36242). **Opened:** July 13, 2023. **Size:** Small. **GHCP suitability:** Strong with current assignee `gewarren` and interop-owner review.

**Why it still applies:** The old Framework route now leads to the [standard string-marshalling overview](../docs/standard/native-interop/marshalling-strings.md). Its table still presents `StringBuilder` output and archived examples without the performance/encoding context from [current best practices](../docs/standard/native-interop/best-practices.md#string-parameters). A path move didn't reconcile the guidance.

**Proposed assignment scope:** Add a prominent current-guidance link and qualify the legacy `StringBuilder`/archived examples. Explain that `StringBuilder` remains a supported runtime-marshalling technique but isn't the default efficient choice for output buffers; signpost caller-owned `char[]`/`byte[]` buffers and their size/encoding contracts. Preserve native ABI-specific valid cases and distinguish modern `LibraryImport` availability from .NET Framework `DllImport`. Coordinate the concrete examples with [dotnet/docs#36243](https://github.com/dotnet/docs/issues/36243) rather than create two competing rewrites.

**Acceptance criteria:** The overview no longer reads as an unconditional recommendation of the expensive pattern, its links reach the current guidance/examples, and no text claims that Framework supports `LibraryImport` or that every native string uses the same encoding or allocator.

### dotnet/docs#36243: Demonstrate input strings and native output buffers

**Issue:** [dotnet/docs#36243](https://github.com/dotnet/docs/issues/36243). **Opened:** July 13, 2023. **Size:** Medium. **GHCP suitability:** Suitable for two bounded native-call examples with interop-owner review.

**Why it still applies:** The [best-practices String parameters section](../docs/standard/native-interop/best-practices.md#string-parameters) supplies recommendations and allocation explanations, but still lacks runnable examples of the recommended input/output patterns.

**Proposed assignment scope:** Add a read-only UTF-16 input-string example and a caller-owned output-buffer example with explicit capacity, returned length, terminator handling, and error handling. Windows `GetFileAttributesW` and `GetCurrentDirectoryW` provide concrete non-destructive APIs for those two cases; label that platform scope. Use supported C# `LibraryImport` where applicable and an equivalent Visual Basic `DllImport` form, with exact declarations and current guidance. Show an `ArrayPool` buffer returned in `finally` if pooling is demonstrated. Don't pass an immutable/interned `string` as a writable `[Out]` buffer or confuse a native-owned string with a caller-owned buffer.

**Acceptance criteria:** Execute both language examples on Windows, including a non-ASCII path and a buffer-resize case, and record actual native results. Verify allocation/ownership, native count units, and null termination against the Win32 contracts; a managed-only build isn't evidence that marshalling works. Cross-link the companion overview correction instead of duplicating all of its legacy examples.

### dotnet/docs#36262: Qualify the YARP telemetry package's platform dependencies

**Issue:** [dotnet/docs#36262](https://github.com/dotnet/docs/issues/36262). **Opened:** July 14, 2023. **Size:** Small. **GHCP suitability:** Strong for the documentation claim; exclude the separate library-extraction proposal.

**Why it still applies:** After the telemetry article split, both [events](../docs/fundamentals/networking/telemetry/events.md#yarptelemetryconsumption) and [event counters](../docs/fundamentals/networking/telemetry/event-counters.md) still say `Yarp.Telemetry.Consumption` works in "any .NET application." Released YARP 2.3.0 [telemetry project source](https://github.com/dotnet/yarp/blob/v2.3.0/src/TelemetryConsumption/Yarp.Telemetry.Consumption.csproj) references the reverse-proxy project, whose [project file](https://github.com/dotnet/yarp/blob/v2.3.0/src/ReverseProxy/Yarp.ReverseProxy.csproj) requires `Microsoft.AspNetCore.App`.

**Proposed assignment scope:** Replace both universal claims with compatible-framework/platform qualifications. Explain that use outside a reverse-proxy app doesn't remove the package's dependencies, and that platforms without the required ASP.NET Core shared framework, such as Android, aren't covered by the claim. Preserve supported non-web console scenarios. Link native `EventListener`/counter guidance where appropriate without promising identical telemetry support on every mobile runtime.

**Acceptance criteria:** Check the dependency chain for the actual published package/version used by the article and validate representative supported-console versus Android-target restore/build behavior. Released 2.3.0 and current source were inspected, but NuGet metadata retrieval failed and no MAUI restore was run during triage. A component extraction in `dotnet/yarp` (formerly `microsoft/reverse-proxy`) requires a separate product decision; don't include it in this docs assignment.

### dotnet/docs#36368: Add the missing MAUI test-project setup bridge

**Issue:** [dotnet/docs#36368](https://github.com/dotnet/docs/issues/36368). **Opened:** July 24, 2023. **Size:** Medium. **GHCP suitability:** Suitable for a focused setup/example correction with MAUI owner review.

**Why it still applies:** The [architecture chapter](../docs/architecture/maui/unit-testing.md) names MSTest and links alternatives, but doesn't show how a host-side test project references app code with compatible target frameworks. Its displayed `OrderDetailViewModel` constructor and later test invocation also disagree, so naming a framework alone doesn't provide the requested working example.

**Why the solution is defined:** The current [MAUI unit-testing guide](https://learn.microsoft.com/dotnet/maui/deployment/unit-testing) supplies concrete class-library/app-project target-framework and reference setup. Use that canonical recipe rather than invent platform compatibility or require device execution for every view-model test.

**Proposed assignment scope:** Add a short host-side test-project setup section and link the maintained MAUI configuration steps, using a supported .NET target. Keep the chapter's MSTest convention explicit; the canonical guide's xUnit recommendation isn't permission to mix attributes/assertions from different frameworks. Provide one matching model/view-model constructor, mock dependencies, project reference, and passing test. Distinguish host-side unit tests from tests that require platform services or UI.

**Acceptance criteria:** Start from the documented projects and run the test command on the named SDK/platform without constructor or TFM incompatibilities. Show that the test uses mocked services rather than live servers. No MAUI workload, emulator, or referenced application test suite was installed or run during triage.

### dotnet/docs#36373: Make the Enumeration sample nullable-correct

**Issue:** [dotnet/docs#36373](https://github.com/dotnet/docs/issues/36373). **Opened:** July 24, 2023. **Size:** Small. **GHCP suitability:** Strong; actual compiler diagnostics bound the correction.

**Why it still applies:** An owned compilation of the exact [Enumeration base class](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types.md#implement-an-enumeration-base-class), with necessary imports and nullable analysis enabled, emitted CS8765 for `Equals(object)`, CS8767 for `CompareTo(object)`, and CS0659 for equality without a hash override.

**Proposed assignment scope:** Match the nullable override/interface signatures, handle null and invalid comparison arguments explicitly, and supply a hash implementation consistent with the existing runtime-type/Id equality rule. Preserve equality for distinct instances with the same derived type and Id, and preserve the class's reflection-based enumeration purpose. Include necessary imports in the runnable sample; don't disable nullable analysis, hide the warnings with pragmas, or add an unrelated enumeration-library redesign.

**Acceptance criteria:** Compile the complete base/derived examples with nullable warnings as errors, and test null/non-enumeration equality, valid ordering, null/invalid comparison behavior, and equal values' hash codes. Explain any intentional `IComparable` null-handling correction; don't promise collision-free hashes. Keep the displayed excerpt aligned with its verified executable.

### dotnet/docs#36405: Replace the deprecated Key Vault FlexVolume reference

**Issue:** [dotnet/docs#36405](https://github.com/dotnet/docs/issues/36405). **Opened:** July 26, 2023. **Size:** Small. **GHCP suitability:** Strong; a vendor-identified successor resolves the named reference.

**Why it still applies:** The [centralized-configuration chapter](../docs/architecture/cloud-native/centralized-configuration.md#azure-key-vault) still recommends Key Vault FlexVolume. The [provider README](https://github.com/Azure/kubernetes-keyvault-flexvol#readme) explicitly marks that solution deprecated/unsupported and directs newer Kubernetes users to the Azure Key Vault provider for Secrets Store CSI Driver.

**Proposed assignment scope:** Replace the obsolete recommendation with a short, accurate reference to the [current AKS Key Vault/Secrets Store CSI Driver guide](https://learn.microsoft.com/azure/aks/csi-secrets-store-driver). Explain the secret-as-mounted-volume role and delegate prerequisites, identity/authorization, and rotation limitations to maintained guidance. Don't copy the old installer manifest or silently present its client-secret authentication model as the current CSI setup.

**Acceptance criteria:** No active FlexVolume recommendation remains in the affected paragraph, the successor link resolves, and the wording doesn't promise automatic refresh of every application configuration source. Keep the work a prose/link update; no AKS cluster or Key Vault resources need to be created for it.

### dotnet/docs#36504: Document the CA1068 params exception

**Issue:** [dotnet/docs#36504](https://github.com/dotnet/docs/issues/36504). **Opened:** August 3, 2023. **Size:** Small. **GHCP suitability:** Strong; analyzer execution confirms the missing case.

**Why it still applies:** The [CA1068 special cases](../docs/fundamentals/code-analysis/quality-rules/ca1068.md#special-cases) list optional and ref/out parameters but omit the trailing parameter-array exception. An SDK 10.0.403 probe explicitly enabled CA1068: a required `string` after the token produced the one expected diagnostic, while trailing `params string[]`, a supported `params IEnumerable<string>` collection, and an optional parameter didn't.

**Proposed assignment scope:** Add the `params` exception and explain that a parameter array must occupy the final parameter position. Link the existing language reference and provide a concise signature if helpful. Keep C# parameter arrays/collections and Visual Basic `ParamArray` language/version support distinct; don't claim that any arbitrary required parameter after a token is exempt.

**Acceptance criteria:** Run enabled-rule positive/negative controls for each documented form on the named analyzer/compiler versions. The rule's ordinary cancellation-token-last recommendation and breaking-change warning remain intact.

### dotnet/docs#36539: Explain native-library lookup and Framework architecture constraints

**Issue:** [dotnet/docs#36539](https://github.com/dotnet/docs/issues/36539). **Opened:** August 7, 2023. **Size:** Small. **GHCP suitability:** Suitable for a bounded compatibility clarification, with interop-owner review.

**Why it still applies:** The [P/Invoke introduction](../docs/standard/native-interop/pinvoke.md) points to [native-library loading](../docs/standard/native-interop/native-library-loading.md), but the latter's modern resolver APIs don't answer the reporter's .NET Framework and AnyCPU question. The important distinction is the architecture of the running process, not merely the operating system or managed assembly.

**Bounded fix:** Add a Framework compatibility note and links to Windows DLL search behavior and `DefaultDllImportSearchPathsAttribute`. Distinguish native DLL lookup from managed assembly binding, explain that an in-process native library must match the process architecture, and avoid presenting `NativeLibrary.SetDllImportResolver` as a Framework API. Qualify search behavior by the import, search flags, and OS rather than inventing one universal search order. Don't recommend global current-directory changes or an x86-versus-x64-only rule that misclassifies ARM64.

**Acceptance:** Check Framework availability of every named API and validate any architecture-selection example on the architectures it claims to support. Coordinate with retained dotnet/docs#34916 on modern RID assets without merging its scope into this Framework question. No native loader experiment was executed during triage.

### dotnet/docs#36678: Preserve the timeout budget in both SpinWait latch samples

**Issue:** [dotnet/docs#36678](https://github.com/dotnet/docs/issues/36678). **Opened:** August 14, 2023. **Size:** Small. **GHCP suitability:** Suitable for a paired sample correction with controlled timeout tests.

**Why it still applies:** The [two-phase wait article](../docs/standard/threading/how-to-use-spinwait-to-implement-a-two-phase-wait-operation.md) includes C# and Visual Basic samples that restart the stopwatch inside the outer loop. Both also subtract elapsed time from `Timeout.Infinite` and reject the negative result. An owned probe compiled the exact C# sample without invoking its interactive `Main`; `Wait(Timeout.Infinite)` returned `false` without any signal.

**Bounded fix:** Start elapsed-time accounting once per wait operation, preserve the original finite budget across spins and kernel waits, and handle infinite timeouts separately. Update both language samples and the directly related explanation. Don't certify or redesign unrelated aspects of the demonstration latch.

**Acceptance:** Exercise zero, finite, and infinite timeouts; signal before and after the kernel transition; and verify that repeated iterations can't restart the finite budget. Run both languages with bounded harnesses rather than the interactive sample driver.

### dotnet/docs#36680: Link code-style rules to their analyzer source

**Issue:** [dotnet/docs#36680](https://github.com/dotnet/docs/issues/36680). **Opened:** August 14, 2023. **Size:** Small. **GHCP suitability:** Suitable for an introductory link addition coordinated with assignee `gewarren`.

**Why it still applies:** The [style-rule overview](../docs/fundamentals/code-analysis/style-rules/index.md) doesn't provide the requested implementation source entry point. The discussion supplies IDE0001 as a concrete example. Current Roslyn source still maps `SimplifyNamesDiagnosticId` to `IDE0001` in [IDEDiagnosticIds.cs](https://github.com/dotnet/roslyn/blob/main/src/Analyzers/Core/Analyzers/IDEDiagnosticIds.cs), with its C# implementation in [CSharpSimplifyTypeNamesDiagnosticAnalyzer.cs](https://github.com/dotnet/roslyn/blob/main/src/Features/CSharp/Portable/Diagnostics/Analyzers/CSharpSimplifyTypeNamesDiagnosticAnalyzer.cs).

**Bounded fix:** Add a short source-code pointer and explain how a reader can use a diagnostic ID to locate its implementation. Use the verified example and repository/folder links; don't imply that all IDE analyzers live in one folder or that the documentation table is automatically generated from that file.

**Acceptance:** Follow the links and confirm the shared ID and language-specific implementation. Keep IDE code-style analyzers distinct from CA code-quality analyzers.

### dotnet/docs#36694: State the Azure Artifacts snupkg limitation

**Issue:** [dotnet/docs#36694](https://github.com/dotnet/docs/issues/36694). **Opened:** August 15, 2023. **Size:** Small. **GHCP suitability:** Suitable for a provider-specific note and authoritative link.

**Why it still applies:** The [library NuGet guidance](../docs/standard/library-guidance/nuget.md) recommends symbol packages without the relevant provider qualification. The [NuGet symbol-package guide](/nuget/create-packages/symbol-packages-snupkg) explicitly states that Azure DevOps Artifacts doesn't support debugging via `.snupkg` files.

**Bounded fix:** Add that precise qualification near the symbol-package advice and link the NuGet explanation. Don't broaden the limitation into a claim that Azure Artifacts can't host packages containing PDBs, that all symbol formats are unsupported, or that Source Link supplies a missing PDB.

**Acceptance:** Preserve the distinction between separate `.snupkg` publication, PDBs inside a normal package, and source retrieval. Coordinate with dotnet/docs#25426 and its open [implementation PR](https://github.com/dotnet/docs/pull/56650), plus the retained Source Link clarification in dotnet/docs#22373.

### dotnet/docs#42239: Complete marshaller mode and precedence guidance

**Issue:** [dotnet/docs#42239](https://github.com/dotnet/docs/issues/42239). **Opened:** August 15, 2023. **Size:** Medium. **GHCP suitability:** Suitable for a source-backed shape correction, with interop-owner review.

**Why it still applies:** The [marshaller-shapes reference](../docs/standard/native-interop/custom-marshaller-shapes.md) doesn't fully explain the element-mode requirements or the selection priority raised by the owner. Its stateless bidirectional value example lists `ElementRef`, but not `ElementIn` or `ElementOut`. An owned SDK 10.0.403 generator probe registered an `ElementIn` value marshaller for an array parameter: a one-way implementation failed with SYSLIB1057 for the missing `ConvertToManaged`, while the bidirectional implementation built with no warnings or errors.

**Bounded fix:** Correct the affected mode annotations and explain the supported pinning, caller-buffer, and conversion paths with their applicability and precedence. Use `GetPinnableReference`, not the comment's misspelled method name. Check value and collection shapes separately; don't infer that every similarly named shape supports every optimization.

**Acceptance:** Compile minimal positive and negative generator cases for the documented modes and inspect generated calls for each precedence claim. The triage probe verified the `ElementIn` requirement only; it neither invoked a native function nor established the entire priority matrix.

### dotnet/docs#36706: Make the XML serializer tutorial's Program.cs unambiguous

**Issue:** [dotnet/docs#36706](https://github.com/dotnet/docs/issues/36706). **Opened:** August 16, 2023. **Size:** Small. **GHCP suitability:** Suitable for an executable tutorial correction rather than another package-version-only edit.

**Why it still applies:** The [current tutorial](../docs/core/additional-tools/xml-serializer-generator.md) now selects package 10.0.0, but its sequence tells readers to add `MyClass`, then add a top-level serializer statement. That order after the template's top-level statement produces CS8803. An owned compiler probe reproduced the error and confirmed that the serializer statement before the class compiles.

**Bounded fix:** Supply an explicit complete `Program.cs` or equally unambiguous insertion instructions, with all top-level statements before type declarations. Check the advertised SDK prerequisites against the selected generator package and runtime; don't assume that changing the version alone demonstrates success.

**Acceptance:** Follow the tutorial from a fresh named project, execute the application, and verify that `MyApp.XmlSerializers.dll` actually appears and can be used. The triage probe verified source ordering, not a generator-package restore or serializer-assembly generation.

### dotnet/docs#36739: Document modern SOS ThreadPool options

**Issue:** [dotnet/docs#36739](https://github.com/dotnet/docs/issues/36739). **Opened:** August 17, 2023. **Size:** Small. **GHCP suitability:** Suitable for a command-reference clarification with diagnostics-owner review.

**Why it still applies:** The [modern SOS reference](../docs/core/diagnostics/sos-debugging-extension.md) describes `ThreadPool` without the requested arguments. The reporter uses LLDB, not WinDbg's unrelated `!tp` command. Current [ThreadPoolCommand source](https://github.com/dotnet/diagnostics/blob/main/src/Microsoft.Diagnostics.ExtensionCommands/ThreadPoolCommand.cs) defines `-ti` for the hill-climbing log and `-wi` for queued work items, with explicit option help.

**Bounded fix:** Add syntax, explanations, and the supported help-discovery command for those options. Distinguish modern SOS from the legacy [Framework SOS reference](../docs/framework/tools/sos-dll-sos-debugging-extension.md); don't apply modern flags to an incompatible legacy implementation. Treat newer aliases and summary flags as version-dependent rather than promising them everywhere.

**Acceptance:** Check the selected shipped SOS version's help and exercise the examples against an owned process or dump. No LLDB session or dump inspection was performed during triage.

### dotnet/docs#36744: Correct the OS-default TLS guidance

**Issue:** [dotnet/docs#36744](https://github.com/dotnet/docs/issues/36744). **Opened:** August 17, 2023. **Size:** Small. **GHCP suitability:** Suitable for a precise correction within the now-expanded TLS 1.3 guidance.

**Why it still applies:** The [Framework TLS article](../docs/framework/network-programming/tls.md) now covers TLS 1.3 extensively, but the practical recommendation passes nonexistent `SslProtocols.SystemDefault` to `SslStream`. An owned Framework compiler probe rejected that member with CS0117 and accepted `SslProtocols.None`. `SecurityProtocolType.SystemDefault` is a different enum member and shouldn't be replaced.

**Bounded fix:** Correct the `SslStream` recommendation to the documented OS-default value, distinguish it from obsolete `SslProtocols.Default`, and keep the OS/Framework support qualifications visible. Don't turn a successful compilation or an enum numeric constant into a guarantee that a given OS and peer negotiate TLS 1.3.

**Acceptance:** Compile any accompanying Framework example, check the `SslProtocols.None` API contract and Schannel support documentation, and review the surrounding recommendations for consistency. Triage verified the enum distinction, not a live TLS handshake.

### dotnet/docs#36748: Finish the built-in metrics cross-reference checklist

**Issue:** [dotnet/docs#36748](https://github.com/dotnet/docs/issues/36748). **Opened:** August 18, 2023. **Size:** Small. **GHCP suitability:** Suitable for a bounded link-completion task coordinated with assignee `noahfalk` and the blog owner.

**Why it still applies:** The [built-in metrics catalog](../docs/core/diagnostics/built-in-metrics.md) now exists, the ASP.NET Core guide links to its catalog, and [the semantic-conventions PR](https://github.com/open-telemetry/semantic-conventions/pull/283) merged on December 11, 2023. However, the [RC1 announcement](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-rc-1/#metrics) still links its .NET metrics text to `lmolkova/semantic-conventions` on the `dotnet8-metrics` branch. That isn't the merged upstream definition requested by the final checklist.

**Bounded fix:** Replace the historical fork link with the corresponding current upstream .NET semantic-conventions reference, and finish the checklist's definition-link check in the built-in pages. Check instrument-specific destinations, including the client-duration link in [networking metrics](../docs/core/diagnostics/built-in-metrics-system-net.md), rather than treating a link to the wrong instrument as complete.

**Acceptance:** Verify the final URLs and anchors against the upstream definitions. Coordinate the blog edit through an editor with access; a docs-only PR doesn't complete that external step. Don't recreate the catalog, reopen the merged OTel proposal, or invent standardized definitions for .NET-specific instruments that lack one.

### dotnet/docs#36875: Remove redundant ASP.NET Core metrics setup from successor samples

**Issue:** [dotnet/docs#36875](https://github.com/dotnet/docs/issues/36875). **Opened:** August 28, 2023. **Size:** Small. **GHCP suitability:** Suitable for a coordinated sample cleanup with assignee `samsp-msft`.

**Why it still applies:** The original numbered setup section was replaced, but the successor [OTLP walkthrough](../docs/core/diagnostics/observability-otlp-example.md) still includes a sample with both metrics `AddAspNetCoreInstrumentation()` and `AddMeter("Microsoft.AspNetCore.Hosting")`. The same pattern remains in related OTLP and Prometheus/Grafana/Jaeger snippet programs. Current [instrumentation source](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/blob/main/src/OpenTelemetry.Instrumentation.AspNetCore/AspNetCoreInstrumentationMeterProviderBuilderExtensions.cs) registers built-in ASP.NET Core meters for applicable targets.

**Bounded fix:** Retain metrics `AddAspNetCoreInstrumentation()` and remove the explicit Hosting meter registration where the selected package already supplies it. Check the other built-in meter registrations against that package's source before removing them, and preserve the custom meters. The extension can do more than subscribe to meters, including version-dependent enrichment, so deleting the extension isn't an equivalent cleanup. Don't remove `AddAspNetCoreInstrumentation()` from the separate tracing pipeline.

**Acceptance:** Build and run the actual referenced samples, verify the expected server/custom metrics and traces, and keep project dependencies consistent with the chosen path. Don't claim that duplicate subscription configuration necessarily emits duplicate measurements; no exporter or backend was run during triage.

### dotnet/docs#36983: Add a position-based GetNullableContext example

**Issue:** [dotnet/docs#36983](https://github.com/dotnet/docs/issues/36983). **Opened:** September 6, 2023. **Size:** Small. **GHCP suitability:** Suitable for a focused API example in the API documentation repository.

**Why it still applies:** The current [SemanticModel XML](https://github.com/dotnet/roslyn-api-docs/blob/main/dotnet/xml/Microsoft.CodeAnalysis/SemanticModel.xml) describes `GetNullableContext(position)` but has no example, and its return/remarks text remains a placeholder. An owned Roslyn probe queried two positions in one syntax tree: after `#nullable enable`, the result was `Enabled`; after `#nullable disable warnings`, it was `AnnotationsEnabled`.

**Bounded fix:** Add a minimal example that creates a syntax tree and compilation, obtains its semantic model, queries explicit source positions, and explains annotations and warnings separately. Place the edit in `dotnet/roslyn-api-docs`, not an unrelated language-guide article.

**Acceptance:** Compile and execute with the documented Roslyn package version, show the context flags at each position, and avoid interpreting nullable context as the flow-state analysis of an individual expression. Include the required imports and package/project setup.

### dotnet/docs#36988: Explain suppression field values and matching scope

**Issue:** [dotnet/docs#36988](https://github.com/dotnet/docs/issues/36988). **Opened:** September 6, 2023. **Size:** Small. **GHCP suitability:** Suitable for a source-backed reference expansion with SDK-owner review.

**Why it still applies:** The moved [package validation overview](../docs/fundamentals/apicompat/package-validation/overview.md) links to the [suppression reference](../docs/fundamentals/apicompat/diagnostic-ids.md#suppression-file), which now lists fields and a sample. Its one-line descriptions still don't establish the accepted `Target`, `Left`, and `Right` values or how rules differ. Closing the separate file-generation follow-up, dotnet/docs#37649, doesn't resolve those format questions.

**Bounded fix:** Explain diagnostic IDs, member/asset target values, comparison operands, baseline applicability, and supported omissions with examples generated by the selected SDK. Base matching claims on [SuppressionEngine](https://github.com/dotnet/sdk/blob/main/src/Compatibility/ApiCompat/Microsoft.DotNet.ApiCompatibility/Logging/SuppressionEngine.cs) and its model. Current source supports particular broader suppression combinations for CP errors only; don't describe every empty field as an unrestricted wildcard or extend CP behavior to PKV rules.

**Acceptance:** Generate representative CP and PKV diagnostics, verify the documented XML and field values, and demonstrate that a targeted suppression leaves unrelated diagnostics visible. Preserve automatic file-generation guidance instead of replacing it with speculative hand-authored formats.

### dotnet/docs#37034: Provide a complete Orleans test project setup

**Issue:** [dotnet/docs#37034](https://github.com/dotnet/docs/issues/37034). **Opened:** September 9, 2023. **Size:** Medium. **GHCP suitability:** Suitable for a runnable setup/sample addition coordinated with assignee `mikekistler`.

**Why it still applies:** The moved [Orleans testing guide](../docs/orleans/implementation/testing.md) now includes substantial cluster/test code, but still lacks the requested complete sample-project link and project/package setup. The final discussion identifies the missing `Microsoft.Orleans.Sdk` reference in the grains project; a page rewrite alone doesn't demonstrate that a reader's separate grain and test projects receive the required generated code.

**Bounded fix:** Add or link a complete minimal sample with the grain project, test project, project references, matching Orleans packages, and the supported SDK/code-generation setup for the selected version. Reuse the upstream [practical testing guide and its referenced sample](https://github.com/dotnet/orleans/blob/main/docs/site/src/content/docs/grains/testing.md) where applicable rather than inventing another cluster harness. Connect the existing test snippets to that sample and distinguish the modern in-process cluster path from older `TestCluster` examples.

**Acceptance:** Restore and run `dotnet test` from the linked project, prove that the sample discovers and activates its grain, and check package requirements in each project. Verify that a copied/downloaded sample doesn't depend on unmentioned parent repository build files. Don't prescribe the old `Microsoft.Orleans.CodeGenerator.MSBuild` 3.7.1 workaround for modern Orleans or add redundant SDK references without checking transitive package behavior. No Orleans packages were restored or test cluster started during triage.

### dotnet/docs#37103: Refresh Activity status output

**Issue:** [dotnet/docs#37103](https://github.com/dotnet/docs/issues/37103). **Opened:** September 13, 2023. **Size:** Small. **GHCP suitability:** Strong; finish the remaining code/output mismatch.

**Why it still applies:** The [instrumentation walkthrough](../docs/core/diagnostics/distributed-tracing-instrumentation-walkthroughs.md) already calls `Activity.SetStatus`, but its subsequent complete console output still shows the old `otel.status_code` and `otel.status_description` tags. Replacing the correct API again or closing on that partial update would miss the stale output.

**Bounded fix:** Regenerate the affected output from the documented status example with an explicit compatible OpenTelemetry console-exporter version. Explain native activity status separately from user tags. An owned run with exporter 1.19.1 emitted `StatusCode: Error` and `Activity.StatusDescription`, not the legacy status tags.

**Acceptance:** The displayed output matches the selected runnable example, including the status description and ordinary tags. Preserve the existing `SetStatus` call and don't present exporter-specific formatting as an immutable Activity API contract.

### dotnet/docs#37108: Identify the test framework used by the examples

**Issue:** [dotnet/docs#37108](https://github.com/dotnet/docs/issues/37108). **Opened:** September 13, 2023. **Size:** Small. **GHCP suitability:** Strong; a localized introduction and related correction.

**Why it still applies:** The [unit-testing best-practices article](../docs/core/testing/unit-testing-best-practices.md) doesn't identify its sample framework at the introduction. Its linked source imports `Xunit`, uses `[Fact]`, and references xUnit 2.9.3. A later lifecycle note misleadingly says that xUnit 2 removed `SetUp` and `TearDown`.

**Bounded fix:** State near the introduction that the examples use xUnit while the general principles apply more broadly. Correct the lifecycle note: xUnit uses constructors and disposal for per-test setup and cleanup; don't attribute another framework's attributes to an older xUnit version.

**Acceptance:** A reader can identify the sample framework before the first example. The lifecycle explanation agrees with the linked test source and xUnit guidance without rewriting framework-neutral practices or migrating the test suite.

### dotnet/docs#37148: Detect .NET Framework 4 in the legacy PowerShell example

**Issue:** [dotnet/docs#37148](https://github.com/dotnet/docs/issues/37148). **Opened:** September 18, 2023. **Size:** Small. **GHCP suitability:** Strong; coordinate with assignee `gewarren` and dotnet/docs#36240.

**Why it still applies:** The legacy script in [Determine installed .NET Framework versions](../docs/framework/install/how-to-determine-which-versions-are-installed.md) filters out `v4` although its section promises versions 1-4. The adjacent `Release`-key instructions cover 4.5 and later, not 4.0. An owned synthetic registry fixture confirmed that the filter drops an installed 4.0 entry.

**Bounded fix:** Read registry values explicitly, include installed `v4` Client/Full profiles where applicable, and avoid carrying values from an earlier key into a later result. Preserve the distinction between `Version`/`Install` checks for older releases and `Release` checks for 4.5+. Coordinate the compatible registry-access pattern with the existing task rather than produce competing rewrites.

**Acceptance:** Read-only fixtures cover 3.5, 4.0 Client/Full, 4.5+, and missing/uninstalled entries without duplicate or inherited version output. Check the claimed PowerShell compatibility; don't silently replace an older-host example with a modern-only command. No Server 2003 installation was exercised during triage.

### dotnet/docs#37195: Restore the missing cancellation link in the dataflow diagram

**Issue:** [dotnet/docs#37195](https://github.com/dotnet/docs/issues/37195). **Opened:** September 20, 2023. **Size:** Small. **GHCP suitability:** Strong; coordinate with assignee `adegeo`.

**Why it still applies:** The current diagram in the [Windows Forms dataflow walkthrough](../docs/standard/parallel-programming/walkthrough-using-dataflow-in-a-windows-forms-application.md) omits the `loadBitmaps` to `operationCancelled` edge. The actual C# source links those blocks. Both the current image and the reporter's proposed replacement were inspected; the proposed image adds that edge.

**Bounded fix:** Use the supplied correction, subject to normal image review, to update `dataflow-winforms-image-processing.png` in the article's media folder. Preserve the existing block names, other edges, readability, and reference path.

**Acceptance:** Compare the rendered diagram with the source's cancellation `LinkTo` calls and confirm that the missing direct edge appears. Don't redesign the pipeline or infer a new cancellation behavior from the picture.

### dotnet/docs#37217: Document both CompilationUnitSyntax.Accept overloads

**Issue:** [dotnet/docs#37217](https://github.com/dotnet/docs/issues/37217). **Opened:** September 22, 2023. **Size:** Small. **GHCP suitability:** Strong; route the API correction through `dotnet/roslyn-api-docs`.

**Why it still applies:** Current `CompilationUnitSyntax` API XML still contains placeholder documentation for both `Accept(CSharpSyntaxVisitor)` and `Accept<TResult>(CSharpSyntaxVisitor<TResult>)`. The generic member has its own XML name, so a search for only the exact `Accept` name misses half the request.

**Bounded fix:** Document visitor dispatch, each visitor parameter, and the generic return value with a small example. Explain that dispatch to `VisitCompilationUnit` doesn't itself promise a recursive walk over every descendant. An owned Roslyn probe invoked the void visitor once and returned a two-member count from the generic visitor.

**Acceptance:** Both overloads render useful summaries and parameter/return documentation on the API site. Execute the final example and distinguish a visitor's explicit recursion from syntax-walker traversal. Don't add an unrelated conceptual article in this repository that leaves the API placeholders unchanged.

### dotnet/docs#37282: Qualify Native AOT EventPipe provider support by release

**Issue:** [dotnet/docs#37282](https://github.com/dotnet/docs/issues/37282). **Opened:** September 27, 2023. **Size:** Small. **GHCP suitability:** Suitable for a source-backed clarification with assignee `LakshanF`.

**Why it still applies:** [Native AOT diagnostics](../docs/core/deploying/native-aot/diagnostics.md) still gives vague partial-provider guidance and links to the general runtime-provider catalog. The original .NET 8 limitation isn't a timeless rule: the final owner update in [dotnet/runtime#92734](https://github.com/dotnet/runtime/issues/92734) identifies SampleProfiler support in .NET 10 through merged [dotnet/runtime#108083](https://github.com/dotnet/runtime/pull/108083). Released .NET 10 runtime source includes that implementation.

**Bounded fix:** Explain the documented provider subset and release differences, including .NET 10 sampling support. Distinguish missing managed-method rundown from unavailable sampling, and describe the external native-symbol requirements for stack interpretation. Link the Native AOT-specific guidance from the general provider page where needed.

**Acceptance:** Claims match the selected released runtime and owner guidance, with no blanket statement that SampleProfiler never works on Native AOT or that all CoreCLR events are available. Any capture recipe must demonstrate the selected provider and usable symbol resolution on its stated platform. No Native AOT publish/trace was executed during triage.

### dotnet/docs#37370: Add a concrete JSON source-generation contract example

**Issue:** [dotnet/docs#37370](https://github.com/dotnet/docs/issues/37370). **Opened:** October 3, 2023. **Size:** Medium. **GHCP suitability:** Suitable for the bounded documentation/example subset of the discussion.

**Why it still applies:** The [source-generation guide](../docs/standard/serialization/system-text-json/source-generation.md) now explains transitive types, collection roots, multiple contexts, and reflection control, but still lacks the requested small, connected DTO example that applies those rules together. Related dotnet/docs#37363 closed as a duplicate of this issue, not as evidence of completion.

**Bounded fix:** Add one complete three-type DTO scenario with an explicit context and a realistic collection/API root. Explain nested types, a nested type reused independently, and additional collection contracts. Reuse the existing context-composition and reflection-disable guidance instead of inventing a new generator API or duplicating the whole guide.

**Acceptance:** Run the example with reflection disabled. Demonstrate the successful graph/root contracts and an unregistered collection failure, then show the explicit contract that fixes it. If the example uses ASP.NET Core, verify the actual endpoint and serializer configuration rather than only direct serialization. An owned .NET 10 probe confirmed the graph, standalone nested root, missing collection metadata, and combined-context behavior; it didn't start an HTTP server.

### dotnet/docs#37404: Explain how to discover assemblies in a framework reference

**Issue:** [dotnet/docs#37404](https://github.com/dotnet/docs/issues/37404). **Opened:** October 9, 2023. **Size:** Small. **GHCP suitability:** Strong; coordinate with assignee `gewarren`.

**Why it still applies:** The [FrameworkReference section](../docs/core/project-sdk/msbuild-props.md#frameworkreference) explains the shared framework but gives no route to discover its compile-time assemblies. The owner points to `Microsoft.AspNetCore.App.Ref`, which provides a defined reference rather than a guessed list of all similarly named packages.

**Bounded fix:** Link the versioned ASP.NET Core reference pack and explain how to inspect the installed targeting pack's `ref` directory. Distinguish reference assemblies, runtime implementation assemblies, and independently distributed packages. An installed .NET 10 pack contained `Microsoft.Extensions.Hosting` but not `Microsoft.Extensions.Http.Resilience`, which illustrates why name prefixes don't establish inclusion.

**Acceptance:** The discovery route matches the reader's selected framework version. Don't promise that every `Microsoft.Extensions.*` package belongs to `Microsoft.AspNetCore.App`, maintain an unversioned static inventory, or replace `FrameworkReference` with a runtime implementation package.

### dotnet/docs#37490: Clarify ITypeSymbol.IsTupleType

**Issue:** [dotnet/docs#37490](https://github.com/dotnet/docs/issues/37490). **Opened:** October 13, 2023. **Size:** Small. **GHCP suitability:** Strong; update the owning Roslyn API documentation.

**Why it still applies:** Current `ITypeSymbol.IsTupleType` XML still contains the incomplete phrase "tuple ." and placeholder remarks. The question concerns the semantic symbol API, not merely tuple syntax.

**Bounded fix:** Define the property and contrast compiler-recognized `System.ValueTuple` types with the reference-type `System.Tuple` family. An owned Roslyn check returned true for tuple syntax, explicit `ValueTuple<int, string>`, `ValueTuple<int>`, and non-generic `ValueTuple`, and false for `System.Tuple<int, string>`. Don't incorrectly require two or more elements in the API description.

**Acceptance:** Replace the API placeholders in `dotnet/roslyn-api-docs`, verify the examples with the supported Roslyn version, and check the rendered API page. Preserve the distinction between language syntax restrictions and the property values returned for explicit framework types.

### dotnet/docs#37501: Link a complete Orleans streaming application

**Issue:** [dotnet/docs#37501](https://github.com/dotnet/docs/issues/37501). **Opened:** October 14, 2023. **Size:** Medium. **GHCP suitability:** Suitable for a focused sample/discoverability fix.

**Why it still applies:** The [streaming quickstart](../docs/orleans/streaming/streams-quick-start.md) now names `Microsoft.Orleans.Streaming` and `AddMemoryStreams`, but still lacks the requested complete application/source link. The package note alone doesn't provide the missing grain contracts, host/client setup, or usable identifier behind the partial snippets.

**Bounded fix:** Link and verify the existing [Simple streaming sample](https://github.com/dotnet/samples/tree/main/orleans/Streaming/Simple), whose structure includes client, grain interface, grain, and silo projects. Align the quickstart with the selected runnable sample and package version rather than recreate another full tutorial or retain an invalid placeholder GUID.

**Acceptance:** Follow the linked setup from a clean sample checkout, start the silo/client, and observe a produced item at the consumer. Check all required package/project references and keep the article's identifiers/configuration consistent. File existence alone isn't execution evidence; no Orleans cluster was started during triage.

### dotnet/docs#37550: Explain the Windows-prefixed runtime provider on Linux

**Issue:** [dotnet/docs#37550](https://github.com/dotnet/docs/issues/37550). **Opened:** October 17, 2023. **Size:** Small. **GHCP suitability:** Strong; a transport/scope clarification with a verified collection example.

**Why it still applies:** The [well-known provider catalog](../docs/core/diagnostics/well-known-event-providers.md) lists `Microsoft-Windows-DotNETRuntime` without explaining whether its name restricts it to Windows. The [EventPipe overview](../docs/core/diagnostics/eventpipe.md) explicitly documents cross-platform runtime-event collection but isn't connected to that question.

**Bounded fix:** Explain that the historical provider name doesn't make CoreCLR's EventPipe events Windows-only. Link the EventPipe collection route and give a minimal Linux runtime/GC collection example with appropriate keywords. Distinguish provider identity from ETW transport, and coordinate Native AOT qualifications with dotnet/docs#37282.

**Acceptance:** Capture and inspect the stated event on Linux with the selected runtime/tool version. Don't claim that all ETW events, OS/kernel events, or Native AOT providers become available merely because EventPipe works cross-platform. Linux capture wasn't executed during triage.

### dotnet/docs#37644: Demonstrate out-of-process DiagnosticSource collection

**Issue:** [dotnet/docs#37644](https://github.com/dotnet/docs/issues/37644). **Opened:** October 19, 2023. **Size:** Medium. **GHCP suitability:** Strong; the owner supplies a bounded bridge/walkthrough design.

**Why it still applies:** The [DiagnosticSource guide](../docs/core/diagnostics/diagnosticsource-diagnosticlistener.md) only incidentally links `DiagnosticSourceEventSource`; it doesn't show the requested out-of-process collector. The owner identifies EventPipe, TraceEvent, and the bridge's filter/property-transform protocol as the implementation route.

**Bounded fix:** Add a minimal emitter and separate collector using `Microsoft-Diagnostics-DiagnosticSource`, `Microsoft.Diagnostics.NETCore.Client`, and TraceEvent. Explain provider keywords, `FilterAndPayloadSpecs`, named property extraction, process selection, and bounded session shutdown. Use the actual bridge protocol rather than substitute an in-process `EventListener` example.

**Acceptance:** Build both projects and collect a filtered payload from the separate process. An owned .NET 10 two-process check used client 0.2.750501 and TraceEvent 3.2.8, received exactly the extracted `requestId` value `42`, excluded a sibling secret field, and stopped both processes. The final walkthrough still needs its own execution evidence. Explain that reflection-based payload discovery isn't a recommended trimming/Native AOT recipe.

### dotnet/docs#37664: Distinguish delegate completion waits from EndInvoke

**Issue:** [dotnet/docs#37664](https://github.com/dotnet/docs/issues/37664). **Opened:** October 21, 2023. **Size:** Small. **GHCP suitability:** Strong; clarify the legacy contract without recommending it for modern .NET.

**Why it still applies:** [Call synchronous methods asynchronously](../docs/standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously.md) explains blocking but doesn't clearly answer why a reader would wait on the handle before `EndInvoke`. Its applicability text also doesn't clearly delimit delegate `BeginInvoke`/`EndInvoke` to .NET Framework.

**Bounded fix:** Explain that `EndInvoke` alone suffices when the caller only wants to wait and retrieve the result; a wait handle adds timed waits or coordinated waits. Require one `EndInvoke` to retrieve results/propagate failures even after a successful wait. State the .NET Framework limitation and point modern .NET readers to task-based alternatives.

**Acceptance:** Verify on .NET Framework that a timed wait can return false, a signaled wait doesn't itself retrieve the result or throw the delegate's exception, and a second `EndInvoke` fails. Owned Framework executions confirmed those distinctions, a result of `42`, and exception propagation through `EndInvoke`. Don't publish a modern .NET sample that calls the unsupported delegate methods or imply that a timeout cancels the operation.

### dotnet/docs#37744: Distinguish WinDbg package versions from debugger-engine versions

**Issue:** [dotnet/docs#37744](https://github.com/dotnet/docs/issues/37744). **Opened:** October 26, 2023. **Size:** Small. **GHCP suitability:** Strong; align the related Windows installation notes.

**Why it still applies:** Both [dotnet-sos](../docs/core/diagnostics/dotnet-sos.md) and [dotnet-debugger-extensions](../docs/core/diagnostics/dotnet-debugger-extensions.md) retain an unexplained `10.0.18317.1001` threshold. The question compares that value with the separately numbered modern WinDbg application.

**Bounded fix:** Identify the threshold as a debugger-engine/tool build, not a numeric minimum for the Store application's package version. Link the [current WinDbg installation page](https://learn.microsoft.com/windows-hardware/drivers/debugger/), which says modern WinDbg was formerly WinDbg Preview and shares the classic engine. Distinguish modern auto-loading from legacy/manual SOS installation and provide the documented load/inspection fallback.

**Acceptance:** Both tool pages use consistent terminology and current WinDbg naming. Check the actual extension/loading behavior on the stated distribution before promising automatic loading; don't compare a `1.x` package number numerically with a `10.x` engine build. The archived diagnostics installation guide supports the historical distinction but explicitly defers maintained guidance to this repository; a Windows debugger session wasn't started during triage.

### dotnet/docs#37757: State P/Invoke source-generation target requirements

**Issue:** [dotnet/docs#37757](https://github.com/dotnet/docs/issues/37757). **Opened:** October 27, 2023. **Size:** Small. **GHCP suitability:** Strong; an interop-owner answer defines the missing qualification.

**Why it still applies:** The [P/Invoke source-generation guide](../docs/standard/native-interop/pinvoke-source-generation.md) says that the .NET 7 SDK includes the generator but doesn't clearly distinguish SDK availability from target-framework support. The [owner's answer](https://github.com/dotnet/docs/issues/37757#issuecomment-1821447683) explicitly rejects .NET Standard 2.0 because generated code depends on newer runtime APIs.

**Bounded fix:** Add an applicability note that explains the supported modern .NET targets and version-specific generated-code dependencies. Link the existing [.NET 7+ recommendation](../docs/standard/native-interop/best-practices.md) and explain the compatible `DllImport`/multitargeting alternative without promising a generator NuGet package or copied-attribute workaround.

**Acceptance:** A reader can't mistake installation of a newer SDK for supported `LibraryImport` generation in a `netstandard2.0` asset. Verify any multitargeted example on each stated target and don't imply that every later generator emits code compatible with the original .NET 7 API surface.

### dotnet/docs#37788: Explain how to prepare managed libraries for Native AOT

**Issue:** [dotnet/docs#37788](https://github.com/dotnet/docs/issues/37788). **Opened:** October 29, 2023. **Size:** Medium. **GHCP suitability:** Strong; coordinate with assignee `jtschuster`.

**Why it still applies:** The [Native AOT overview](../docs/core/deploying/native-aot/index.md#aot-compatibility-analyzers) now documents `IsAotCompatible`, including its analyzer defaults and target requirements, but doesn't supply the requested library test-app workflow. The [trimming preparation guide](../docs/core/deploying/trimming/prepare-libraries-for-trimming.md) supplies a related test-app pattern, not a complete Native AOT preparation recipe. The native-library export page addresses a different task.

**Bounded fix:** Add a focused managed-library preparation guide, connect the existing analyzer material, and show a small console test app that roots the library for complete analysis and publishes with Native AOT. The discussion explicitly approves the [owner's library-compatibility blog](https://devblogs.microsoft.com/dotnet/creating-aot-compatible-libraries/) as source material. Keep release-specific claims aligned with one selected supported example version.

**Acceptance:** Demonstrate analysis warnings and their correction, publish and execute the test app with the stated native toolchain, and explain why a normal library build alone doesn't analyze every dependency implementation. Preserve conditional settings for older targets, add the TOC entry, and identify copied/adapted source content in the implementation PR. Don't confuse AOT-compatible managed assemblies with exporting a native DLL.

### dotnet/docs#37817: Document an SDK servicing update before Visual Studio updates

**Issue:** [dotnet/docs#37817](https://github.com/dotnet/docs/issues/37817). **Opened:** October 31, 2023. **Size:** Small. **GHCP suitability:** Strong; coordinate with assignee `gewarren`.

**Why it still applies:** The [SDK/Visual Studio versioning guide](../docs/core/porting/versioning-sdk-msbuild-vs.md) explains separate SDK installations, and the [upgrade guide](../docs/core/install/upgrade.md) explains version control, but neither gives the requested short security-servicing playbook for a customer who can't update Visual Studio yet.

**Bounded fix:** Add a linked procedure: identify the supported SDK feature band for the existing Visual Studio, install its newer servicing SDK, and inspect/update `global.json` selection. Explain `latestPatch` where the reader intentionally wants the newest installed patch in that feature band. Don't recommend a jump to an incompatible feature band or a persistent `RuntimeFrameworkVersion` override as the normal solution.

**Acceptance:** Verify SDK selection and a build with the unchanged target framework in the stated Visual Studio/SDK pairing. Explain the difference between updating development tools and patching a deployed app; self-contained apps still require an updated publication. Preserve deliberate SDK pinning rather than advise every customer to delete `global.json`.

### dotnet/docs#37852: Correct the POCO definition behind the domain-model contradiction

**Issue:** [dotnet/docs#37852](https://github.com/dotnet/docs/issues/37852). **Opened:** November 1, 2023. **Size:** Small. **GHCP suitability:** Strong; a paired terminology correction.

**Why it still applies:** The [DDD chapter](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice.md) allows behavior in POCO entities, but its linked [glossary](../docs/standard/glossary.md#poco) forbids methods and interfaces and equates POCOs with DTOs. The reporter's contradiction follows the actual linked definition, not merely a misunderstanding to dismiss.

**Bounded fix:** Define POCO as a plain CLR object without required infrastructure-framework coupling, not necessarily a data-only DTO. Clarify that ordinary domain behavior, domain-owned base classes, and interfaces don't inherently disqualify an object. Align the chapter's wording with its [concrete domain-model example](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/net-core-microservice-domain-model.md#implement-domain-entities-as-poco-classes), which already explains those distinctions.

**Acceptance:** The glossary and both domain explanations agree. Preserve the persistence-ignorance guidance and the distinction from an anemic model; don't remove business logic from the sample or claim that a POCO must avoid every base class or interface.

### dotnet/docs#37864: Document startup EventPipe provider arguments

**Issue:** [dotnet/docs#37864](https://github.com/dotnet/docs/issues/37864). **Opened:** November 2, 2023. **Size:** Small. **GHCP suitability:** Strong; coordinate with assignee `tommcdon`.

**Why it still applies:** The [environment-variable reference](../docs/core/diagnostics/eventpipe.md#trace-using-environment-variables) still documents only three `DOTNET_EventPipeConfig` fields. Released .NET 10 `ep_enable_2` source parses a fourth argument field. An owned startup trace delivered `Example=42` to an EventSource through that field and captured its emitted value.

**Bounded fix:** Document the fourth field, hexadecimal keywords, decimal levels, and a verified shell-specific example. Explain parser delimiter limitations: the released helper splits at commas and colons and doesn't provide a general quoted-value escape. Don't promise that every `dotnet-trace --providers` string, nested filter expression, empty field, or repeated-provider entry has identical environment-variable behavior.

**Acceptance:** Start a child app through environment variables alone and inspect the resulting trace to prove that the argument reached the provider. Include a representative supported built-in provider case and explicitly delimit any unsupported argument syntax rather than invent a quoting workaround.

### dotnet/docs#37874: Explain and demonstrate scopes in a custom logging provider

**Issue:** [dotnet/docs#37874](https://github.com/dotnet/docs/issues/37874). **Opened:** November 2, 2023. **Size:** Medium. **GHCP suitability:** Strong; the framework's scope-provider contract supplies the implementation path.

**Why it still applies:** The moved [custom-provider guide](../docs/core/extensions/logging/custom-provider.md) doesn't explain scopes. Its actual logger implements `BeginScope` as a no-op, so the current sample compiles but doesn't preserve scope information. An owned check compiled the exact logger and confirmed its null scope result; the problem isn't a missing `CreateScope` member on `ILogger`.

**Bounded fix:** Explain the intentional no-op and add a focused scope-support path that uses `ISupportExternalScope` and `IExternalScopeProvider`, including how the provider receives scope state and includes it in log output. Reuse framework scope storage rather than create a global mutable stack, and link the existing consumer-side scope overview.

**Acceptance:** Use the logger through `LoggerFactory`; verify nested scopes, disposal, and independent asynchronous operations without duplicated scope entries or cross-request state leaks. Preserve the simple provider's color/configuration behavior and don't confuse logging scopes with dependency-injection service scopes.

### dotnet/docs#37999: Clarify HTTP content ownership, buffering, and decoding

**Issue:** [dotnet/docs#37999](https://github.com/dotnet/docs/issues/37999). **Opened:** November 10, 2023. **Size:** Medium. **GHCP suitability:** Suitable for the three source-backed documentation corrections, with networking-owner review.

**Why it still applies:** Current `HttpContent` XML doesn't clearly document supplied-stream ownership or `ReadAsStringAsync` charset/BOM/UTF-8 selection. The [HTTP migration guide](../docs/fundamentals/networking/http/httpclient-migrate-from-httpwebrequest.md#usage-of-buffering-properties) now describes response buffering, but doesn't resolve all three concerns. The [complete runtime discussion](https://github.com/dotnet/runtime/issues/94471) supplies the owner's answers; its closure redirects the remaining work here.

**Bounded fix:** Route API remarks through `dotnet/dotnet-api-docs`: don't dispose the supplied serialization stream, use `leaveOpen` for wrappers, and throw to fail content production. Explain charset selection, BOM detection, and the UTF-8 default without promising general encoding sniffing. Connect the conceptual HttpClient guidance to `ResponseHeadersRead`, including the `SendAsync` route for a POST and response/stream lifetime.

**Acceptance:** Verify a failed request-content producer, a slow streamed response, and representative charset/BOM/default-decoding cases against a controlled server. Preserve the difference between generic `HttpContent` behavior and HttpClient's completion option. Don't copy the discussion's erroneous claim that network JSON can freely use any encoding; keep RFC requirements distinct from the API's decoder behavior.

### dotnet/docs#40841: Provide a migration path from legacy HTTP Polly handlers

**Issue:** [dotnet/docs#40841](https://github.com/dotnet/docs/issues/40841). **Opened:** November 14, 2023. **Size:** Medium. **GHCP suitability:** Strong; the owner explicitly agrees that a guide is needed.

**Why it still applies:** The [resilience overview](../docs/core/resilience/index.md) deprecates `Microsoft.Extensions.Http.Polly`, while [HTTP resilience guidance](../docs/core/resilience/http-resilience.md) explains the replacement APIs without a before/after migration. Its standard handler adds multiple strategies, so a mechanical API rename doesn't preserve every old policy.

**Bounded fix:** Add a focused migration guide for one representative named/typed client, map its legacy retry/timeout configuration to an explicit resilience pipeline, and link the remaining strategy references. Explain default strategy ordering, timeout scope, state sharing, retry predicates, unsafe-method retries, and removal of the old handler registration where those affect the migration.

**Acceptance:** Pin compatible package versions and execute before/after cases with a deterministic test handler, including transient failure, success, timeout, and a non-idempotent request. Don't claim universal policy equivalence, stack old/new handlers accidentally, or promise that Upgrade Assistant performs the migration based on a speculative discussion. Preserve this transferred issue's original creation date in triage order.

### dotnet/docs#38262: Document StreamReader's corrected decoder flush at EOF

**Issue:** [dotnet/docs#38262](https://github.com/dotnet/docs/issues/38262). **Opened:** November 15, 2023. **Size:** Small. **GHCP suitability:** Suitable for a precise .NET 8 compatibility entry with assignee `gewarren`.

**Why it still applies:** The issue reports a specific missing compatibility note, not a request to restore silent data loss. Merged [dotnet/runtime#69888](https://github.com/dotnet/runtime/pull/69888), assigned to .NET 8, explains the EOF decoder-flush fix and the prior missing `DecoderFallbackException`. An owned .NET 10 check produced the replacement character with default UTF-8 and the exception with strict UTF-8.

**Bounded fix:** Add the .NET 8 entry using the breaking-change template and relevant index/TOC. Describe incomplete encoded input at EOF, replacement fallback, and strict decoder behavior. Keep the separate ICU/NLS string-comparison observations out of the cause of the decoding change.

**Acceptance:** Run the original minimal input on the documented before/after runtime versions and verify both fallback configurations. State the actual affected APIs and fix invalid/incomplete input where appropriate; don't recommend a culture switch or silently discarding data as the general workaround. The owned modern-runtime check isn't a substitute for the final .NET 7/.NET 8 comparison.

### dotnet/docs#38290: Fix the BinaryFormatter alternatives list

**Issue:** [dotnet/docs#38290](https://github.com/dotnet/docs/issues/38290). **Opened:** November 17, 2023. **Size:** Small. **GHCP suitability:** Strong; coordinate with assignee `gewarren`.

**Why it still applies:** The [security guide](../docs/standard/serialization/binaryformatter-security-guide.md#preferred-alternatives) still lists `BinaryReader` and `BinaryWriter` "for XML and JSON" under serializers. The newer [serializer chooser](../docs/standard/serialization/binaryformatter-migration-guide/choose-a-serializer.md) already documents MessagePack and protobuf-net for compact binary formats, but the original list remains misleading.

**Bounded fix:** Remove the incorrect low-level I/O recommendation from the serializer list and connect readers to the existing migration chooser, including its binary-format options and trade-offs. Explain that no alternative is a universal drop-in replacement rather than promise identical performance, payload size, or type support.

**Acceptance:** The original entry no longer presents primitive binary readers/writers as XML/JSON object serializers. Preserve the security warnings and maintained migration links; don't introduce another custom binary format, unsafe compatibility switch, or unsupported claim that the original issue was fully resolved by a different page.

### dotnet/docs#38328: Explain when to choose JSON source-generation modes

**Issue:** [dotnet/docs#38328](https://github.com/dotnet/docs/issues/38328). **Opened:** November 19, 2023. **Size:** Small. **GHCP suitability:** Strong; coordinate with assignee `gewarren` and dotnet/docs#37370.

**Why it still applies:** The [how-to](../docs/standard/serialization/system-text-json/source-generation.md#specify-source-generation-mode) shows configuration and the companion mode pages describe capabilities, but the choice still lacks the owner's direct default recommendation. The discussion explains that the default emits both modes and usually avoids a needless functionality/size trade-off.

**Bounded fix:** Add a short decision guide: normally retain the default, use metadata for deserialization/required fallback contracts, and treat serialization-only generation as a deliberate restriction for a verified serialization-only workload. Link the existing mode/capability pages and qualify streaming fast-path behavior by release instead of repeating an obsolete blanket async limitation.

**Acceptance:** Verify a default round trip, metadata-only round trip, and serialization-only deserialization failure; owned .NET 10 checks confirmed those cases and the generated handler differences. Don't reuse the old example's native-image sizes as universal measurements or say that the default supports every possible model/options combination.

### dotnet/docs#38558: Complete LOH diagnostic scope and event distinctions

**Issue:** [dotnet/docs#38558](https://github.com/dotnet/docs/issues/38558). **Opened:** December 2, 2023. **Size:** Small. **GHCP suitability:** Suitable for the remaining diagnostic clarification with assignee `gewarren`.

**Why it still applies:** Merged [dotnet/docs#39683](https://github.com/dotnet/docs/pull/39683) fixed the category/counter names and added lightboxes for the ETW images. The [current article](../docs/standard/garbage-collection/large-object-heap.md) still leaves an instance-name placeholder and blurs an allocation event with the conditions for a generation-2 collection. Those remaining questions aren't resolved by that partial merge.

**Bounded fix:** Qualify the legacy `.NET CLR Memory` counters, explain how to select an owned Framework process using its `Process ID` counter, and point modern .NET readers to current runtime diagnostics. Distinguish allocation notifications from budget-driven full collections and qualify the illustrative trace. Add the same full-size-image access to the first counter screenshot if needed; the current source image was inspected and doesn't need an invented missing-image fix.

**Acceptance:** Verify the counter-instance example with an owned .NET Framework process and the modern diagnostic route with the selected runtime. Confirm that the event explanation doesn't promise a collection for every LOH allocation. An owned modern check allocated three 90,000-byte generation-2 arrays without an intervening generation-2 collection; that result doesn't establish a universal AllocationTick sampling interval.

### dotnet/docs#38661: Make the workspace diagram readable in dark mode

**Issue:** [dotnet/docs#38661](https://github.com/dotnet/docs/issues/38661). **Opened:** December 7, 2023. **Size:** Small. **GHCP suitability:** Strong; the owner accepted the localized visual correction.

**Why it still applies and why the solution is defined:** The [workspace article](../docs/csharp/roslyn-sdk/work-with-workspace.md#solutions-projects-and-documents) still embeds `media/work-with-workspace/workspace-obj-relations.png`. Visual inspection confirms dark connector labels and lines outside the white boxes; the 604-by-371 PNG has a transparent background. That combination loses contrast on dark backgrounds.

**Scope and acceptance:** Preserve the diagram's labels, relationships, and dimensions, and give the asset an opaque light background or an equivalent theme-safe treatment. Verify the actual rendered article in both light and dark themes, including small connector captions and arrowheads. Don't redraw the model or change its technical meaning to fix contrast.

### dotnet/docs#38687: Show explicit opt-in JSON member selection

**Issue:** [dotnet/docs#38687](https://github.com/dotnet/docs/issues/38687). **Opened:** December 9, 2023. **Size:** Small. **GHCP suitability:** Suitable for a focused example using the existing contract-customization mechanism.

**Why it still applies and why the solution is defined:** The [migration guide](../docs/standard/serialization/system-text-json/migrate-from-newtonsoft.md#systemruntimeserialization-attributes) already states that `DataContract` and `DataMember` aren't built-in System.Text.Json contracts and links a custom resolver. The [custom-contract guide](../docs/standard/serialization/system-text-json/custom-contracts.md#modifiers) explains property removal, but doesn't directly demonstrate the requested opt-in member policy.

**Scope and acceptance:** Add a short opt-in recipe and a discoverability link between those existing sections. Distinguish an explicit DTO from a custom resolver that retains only marked members; state exactly which attributes and semantics the example implements, rather than advertise full DataContractSerializer compatibility or endorse a third-party package. Prove that an unmarked member neither appears in output nor accepts input. An owned .NET 8/.NET 10 modifier check produced only `{"PublicValue":7}` and ignored an unmarked input member; the default serializer included both public properties. Keep reflection-based customization distinct from source-generated contracts and validate the eventual published language samples.

### dotnet/docs#38701: Explain why span concatenation also changes the call

**Issue:** [dotnet/docs#38701](https://github.com/dotnet/docs/issues/38701). **Opened:** December 11, 2023. **Size:** Small. **GHCP suitability:** Strong; the correction is a local explanation and paired example.

**Why it still applies and why the solution is defined:** [CA1845](../docs/fundamentals/code-analysis/quality-rules/ca1845.md#how-to-fix-violations) already lists both required changes, but its before/after example changes the concatenation syntax without explaining the span overload. The proposed `AsSpan(...) + "..."` replacement isn't valid C#: an owned build produced CS0019.

**Scope and acceptance:** Explain that the span-based `string.Concat` overload avoids intermediate substring strings and that `+` isn't the demonstrated span API. For a controlled comparison, optionally use `string.Concat` in both versions. Preserve the final string and avoid claims of zero total allocation. Owned .NET 8 and .NET 10 checks returned `fwutzle---fwobz` from both valid forms; verify CA1845's diagnostic and code fix against the eventual published examples.

### dotnet/docs#39216: Explain populated collections after DI constructor selection

**Issue:** [dotnet/docs#39216](https://github.com/dotnet/docs/issues/39216). **Opened:** January 22, 2024. **Size:** Small. **GHCP suitability:** Suitable for an example in the existing compatibility note, coordinated with assignee `gewarren`.

**Why it still applies and why the solution is defined:** The [existing .NET 8 change](../docs/core/compatibility/extensions/8.0/activatorutilities-createinstance-behavior.md) already documents the longest-resolvable-constructor rule. It doesn't illustrate that DI can resolve `IEnumerable<T>` for a collection's copy constructor, producing a populated collection instead of the empty collection expected by a deserializer.

**Scope and acceptance:** Extend that note rather than create a duplicate breaking-change article. Demonstrate two registrations, the selected collection constructor, and explicit parameterless construction when an empty collection is required. Distinguish DI activation from ordinary construction and don't suggest changing framework collection constructors or relying on their declaration order. Owned .NET 8 and .NET 10 checks returned two elements through `ActivatorUtilities` and zero through parameterless `Activator.CreateInstance`. Verify the historical comparison against the relevant package versions before publishing a before/after claim, and check `GetServiceOrCreateInstance` separately.

### dotnet/docs#39222: Distinguish handle ownership from owner lifetime

**Issue:** [dotnet/docs#39222](https://github.com/dotnet/docs/issues/39222). **Opened:** January 23, 2024. **Size:** Small. **GHCP suitability:** Suitable for a bounded interop clarification with interop-owner review.

**Why it still applies and why the solution is defined:** The [best-practices guide](../docs/standard/native-interop/best-practices.md#keeping-managed-objects-alive) still says to replace `HandleRef` with `SafeHandle` without explaining the original wrapper object's lifetime. The actual HandleRef API remarks establish that the wrapper stays alive through the P/Invoke; merely wrapping its borrowed pointer doesn't establish ownership or preserve that wrapper.

**Scope and acceptance:** Explain owned SafeHandle-based resource design versus a borrowed handle whose managed owner must remain alive. Don't recommend two owners for one native resource, claim that a non-owning SafeHandle automatically roots the original owner, or describe HandleRef as obsolete. Clarify the role of `GC.KeepAlive` after the native call without presenting a universal mechanical conversion. Align the conceptual guide with the HandleRef API remarks through `dotnet/dotnet-api-docs` where needed. Any new native example needs an actual lifetime/release fixture, not only a managed compilation.

### dotnet/docs#39274: Connect compiler diagnostics and analyzer configuration

**Issue:** [dotnet/docs#39274](https://github.com/dotnet/docs/issues/39274). **Opened:** January 26, 2024. **Size:** Small. **GHCP suitability:** Suitable for the bounded navigation hub the owner approved.

**Why it still applies and why the solution is defined:** The [compiler-message landing page](../docs/csharp/language-reference/compiler-messages/index.md) still focuses on CS diagnostics and compiler options. It doesn't provide the requested bridge to [code-quality rules](../docs/fundamentals/code-analysis/quality-rules/index.md), [code-style rules](../docs/fundamentals/code-analysis/style-rules/index.md), and their distinct configuration mechanisms. The owner accepted a central index without competing diagnostic F1 tags.

**Scope and acceptance:** Expand the existing landing page with a compact CS/CA/IDE navigation and configuration map, and identify where currently undocumented compiler messages are tracked. Link maintained inventories rather than promise a complete hand-maintained table of every diagnostic. Keep compiler warning levels, warning waves, analyzer enablement, severity, and nullable settings distinct; don't copy the issue's proposed `9999`/`latest` guarantee or its analysis-level matrix. Verify destinations and representative help routes, preserve diagnostic-specific F1 ownership, and obtain compiler/analyzer-owner review.

### dotnet/docs#39347: Poll observable instruments in metrics tests

**Issue:** [dotnet/docs#39347](https://github.com/dotnet/docs/issues/39347). **Opened:** January 31, 2024. **Size:** Small. **GHCP suitability:** Strong; the API contract and reproduction define the missing step.

**Why it still applies and why the solution is defined:** [Test custom metrics](../docs/core/diagnostics/metrics-instrumentation.md#test-custom-metrics) demonstrates counters but never calls `MetricCollector<T>.RecordObservableInstruments`. The collector's source delegates that method to `MeterListener.RecordObservableInstruments`; taking a snapshot alone doesn't request an observable callback.

**Scope and acceptance:** Add a minimal observable-gauge test beside the counter examples and explain when to poll, then inspect the snapshot. Show that another poll adds another observation rather than silently replacing the first. Keep meter/collector disposal and test isolation explicit. Owned checks with Microsoft.Extensions.Diagnostics.Testing 10.0.0 on .NET 8 and .NET 10 saw an empty snapshot before polling, `150` after the first poll, and `150,42` after the second. Execute the eventual test and link the method's API reference; don't make fake-time advancement a substitute for collection.

### dotnet/docs#39352: Convert the two remaining Framework detection projects

**Issue:** [dotnet/docs#39352](https://github.com/dotnet/docs/issues/39352). **Opened:** February 1, 2024. **Size:** Small. **GHCP suitability:** Suitable for a two-project conversion with Windows build verification.

**Why it still applies and why the solution is defined:** The Framework-version detection [C# project](../docs/framework/install/snippets/how-to-determine-which-versions-are-installed/csharp/FrameworkVersions.csproj) and [VB project](../docs/framework/install/snippets/how-to-determine-which-versions-are-installed/vb/FrameworkVersions.vbproj) still use ToolsVersion/import-based project files and target .NET Framework 4.8.1. The third, XmlDocument WinForms project in the auto-generated issue no longer exists, so it isn't a reason to recreate that sample or declare the whole issue resolved.

**Scope and acceptance:** Convert only the two remaining projects to SDK style while retaining `net481`, output type, namespaces, startup selection, snippet files/regions, and configuration behavior. Resolve generated/explicit assembly metadata duplication and preserve VB's `My` resources/settings deliberately. Build Debug and Release on Windows with the Framework reference assemblies, and compare the read-only registry output with the baseline. Don't retarget this Framework-detection example to modern .NET or add a blanket versionsweeper exclusion to hide the outstanding conversion.

### dotnet/docs#39649: Explain implicit stream subscription constructors

**Issue:** [dotnet/docs#39649](https://github.com/dotnet/docs/issues/39649). **Opened:** February 23, 2024. **Size:** Small. **GHCP suitability:** Suitable for version-matched examples from the existing Orleans contract.

**Why it still applies and why the solution is defined:** The [subscription guide](../docs/orleans/streaming/streams-programming-apis.md#explicit-and-implicit-subscriptions) only illustrates a namespace string. Actual Orleans 7.2.7 and 10.0.0 source defines all-namespace, exact-namespace, and predicate-type constructors, an optional named stream-ID mapper, and a predicate-instance constructor for derived-attribute extensibility.

**Scope and acceptance:** Explain those choices and demonstrate ordinary attribute usage with a parameterless custom predicate type, including `PredicatePattern`/provider reconstruction requirements. Don't put an arbitrary predicate instance in attribute arguments or confuse namespace matching with stream-ID mapping. Retain the separate observer-attachment requirement. Compile against each documented Orleans pivot and prove matching/nonmatching namespaces; include a real provider/consumer check for any delivery or mapper example.

### dotnet/docs#39654: Stop treating pinnability as a blittability test

**Issue:** [dotnet/docs#39654](https://github.com/dotnet/docs/issues/39654). **Opened:** February 24, 2024. **Size:** Small. **GHCP suitability:** Strong for the source-backed correction, with interop-owner review.

**Why it still applies and why the solution is defined:** The [blittability section](../docs/standard/native-interop/best-practices.md#blittable-types-when-runtime-marshalling-is-enabled) and a later struct-performance paragraph both claim that a pinned GCHandle tests blittability. The runtime actually checks pinnability. Owned .NET 8 and .NET 10 probes successfully pinned a boxed Boolean even though its managed size was one byte and its default marshaled size was four; a reference-containing list was rejected.

**Scope and acceptance:** Correct both occurrences and distinguish reference-free/pinnable storage from matching a specific native representation. Preserve the separate enabled/disabled-runtime-marshalling rules and Boolean conversion explanation. Don't replace the test with another universal blittability predicate or claim that pinning changes an ABI. Verify the Boolean and reference-containing cases and review native-layout wording against the selected marshalling model.

### dotnet/docs#39771: Clarify the default scaffolded context directory

**Issue:** [dotnet/docs#39771](https://github.com/dotnet/docs/issues/39771). **Opened:** March 1, 2024. **Size:** Small. **GHCP suitability:** Strong, but the edit belongs in `dotnet/EntityFramework.Docs`, not this checkout.

**Why it still applies and why the solution is defined:** The live [Scaffold-DbContext table](https://learn.microsoft.com/ef/core/cli/powershell#scaffold-dbcontext) still describes `-OutputDir` only as the entity-class directory and doesn't state the context default. The linked scaffolding guide already explains separate directories, and EF Core 10's `DatabaseOperations.ScaffoldContext` defaults an omitted context directory to the resolved output directory.

**Scope and acceptance:** Update `entity-framework/core/cli/powershell.md` to say that `-OutputDir` also receives the context when `-ContextDir` is omitted, and cross-link the existing target-directory guidance. Preserve paths relative to the project directory. Verify omitted and explicit `-ContextDir` cases through the PMC command; don't assume an explicitly empty string has the same behavior as an omitted parameter, because source distinguishes null from empty paths. Route the assignment to the owning repository without changing EF tooling or filing a duplicate issue automatically.

### dotnet/docs#39852: Correct the version history for delegate variance

**Issue:** [dotnet/docs#39852](https://github.com/dotnet/docs/issues/39852). **Opened:** March 6, 2024. **Size:** Small. **GHCP suitability:** Strong; a localized historical correction.

**Why it still applies and why the solution is defined:** The opening of [Variance in delegates](../docs/csharp/programming-guide/concepts/covariance-contravariance/variance-in-delegates.md) still gives .NET Framework 3.5 as the starting point. The [C# version history](../docs/csharp/whats-new/csharp-version-history.md) lists covariance and contravariance under C# 2.0 and generic variance under C# 4.0. An owned C# 2 language-mode fixture accepted both covariant-return and contravariant-parameter method-group conversions.

**Scope and acceptance:** Correct the opening to distinguish method-group compatibility introduced with C# 2.0 from `in`/`out` generic-delegate variance introduced with C# 4.0/.NET Framework 4. Preserve both generic and nongeneric examples. Don't imply that every delegate API used by a modern example existed in the first supporting release. Verify the two conversion forms with the stated language version and obtain C# review of the historical wording.

### dotnet/docs#39902: Explain custom marshalling at callback boundaries

**Issue:** [dotnet/docs#39902](https://github.com/dotnet/docs/issues/39902). **Opened:** March 12, 2024. **Size:** Medium. **GHCP suitability:** Suitable for a bounded limitation/example addition, with interop-owner review.

**Why it still applies and why the solution is defined:** The [custom-marshalling guide](../docs/standard/native-interop/custom-marshalling-source-generation.md) describes `MarshalUsing` and reverse-call modes without explaining that a `LibraryImport` declaration doesn't generate a custom marshalling stub for a delegate's `Invoke` signature. Owned .NET 8 and .NET 10 probes showed the generated import using `Marshal.GetFunctionPointerForDelegate`. A callback with `MarshalUsing` on its string parameter received `A` from a UTF-32 `AB` buffer, with zero custom-converter calls; explicit conversion returned `AB`.

**Scope and acceptance:** Explain the distinction between the outer generated import, runtime delegate marshalling, and source-generated COM support. Add a minimal, explicitly typed unmanaged callback/manual-conversion example that uses the actual UTF-32 ABI, rather than advertise attributes on a delegate parameter as automatic support. State callback lifetime, calling convention, pointer ownership, and exception-boundary requirements. Execute the eventual example against a native caller, show the conversion result, and review any disabled-runtime-marshalling or Native AOT claims separately. Don't invent a source-generated reverse-P/Invoke feature.

### dotnet/docs#39909: Replace MessagingCenter in the MAUI unit test

**Issue:** [dotnet/docs#39909](https://github.com/dotnet/docs/issues/39909). **Opened:** March 12, 2024. **Size:** Small to medium. **GHCP suitability:** Strong, coordinated with the existing MAUI test-sample task.

**Why it still applies and why the solution is defined:** [Testing message-based communication](../docs/architecture/maui/unit-testing.md#testing-message-based-communication) still subscribes through `MessagingCenter` and expects a `CatalogItem`. The companion [communication chapter](../docs/architecture/maui/communicating-between-components.md) explicitly rejects that API and already defines the replacement: `WeakReferenceMessenger`, `AddProductMessage`, and an integer count payload. Its producer uses `WeakReferenceMessenger.Default`.

**Scope and acceptance:** Update the test and explanation to that actual message contract, with a matching producer version and constructor dependencies. Register a test recipient on the producer's messenger, execute or await the actual command, assert receipt and the count payload, and unregister in a `finally` block. Isolate tests that share the default messenger; don't create a fresh messenger that the producer never uses or invent an injectable constructor. Compile and execute the test with the existing MAUI unit-test bridge work rather than create competing sample rewrites.

### dotnet/docs#40059: Demonstrate exception handling in F# asynchronous expressions

**Issue:** [dotnet/docs#40059](https://github.com/dotnet/docs/issues/40059). **Opened:** March 18, 2024. **Size:** Small to medium. **GHCP suitability:** Strong; focused examples in two existing guides.

**Why it still applies and why the solution is defined:** The [task-expression](../docs/fsharp/language-reference/task-expressions.md) and [async-expression](../docs/fsharp/language-reference/async-expressions.md) guides list exception constructs but don't demonstrate the requested awaited-fault/recovery flow. Owned F# fixtures caught an awaited `InvalidOperationException`, returned `42`, and ran synchronous `finally` cleanup in both expression types. The async workflow didn't execute before it was started.

**Scope and acceptance:** Add paired `try`/`with` recovery and `try`/`finally` cleanup examples with explicit execution/await steps and actual output. Explain that an awaited operation's fault reaches the handler, distinguish cold `Async` workflows from started tasks, and preserve the documented limits of the handler/cleanup forms. Keep cancellation distinct from an ordinary caught failure; don't suggest blanket exception swallowing, asynchronous `finally` support, or that a task automatically runs on a different thread. Execute the published snippets and obtain F# review.

### dotnet/docs#40171: Explain the object-initializer style preference

**Issue:** [dotnet/docs#40171](https://github.com/dotnet/docs/issues/40171). **Opened:** March 21, 2024. **Size:** Small. **GHCP suitability:** Strong, coordinated with assignee `gewarren`.

**Why it still applies and why the solution is defined:** The [IDE0017 reference](../docs/fundamentals/code-analysis/style-rules/ide0017.md) identifies a style rule and shows the transformation, but doesn't answer the reader's question about motivation versus performance.

**Scope and acceptance:** Explain the readability/initialization-style preference and link the existing object-initializer language reference. For the simple equivalent example, describe construction followed by member assignment rather than promise a speedup. Preserve evaluation order and don't generalize equivalence to every constructor overload, side-effecting expression, or initialization scenario. Keep configuration and suppression guidance intact. A performance claim needs a scoped measurement; the clarification doesn't require one.

### dotnet/docs#40172: Show what a Boolean-backed enum means

**Issue:** [dotnet/docs#40172](https://github.com/dotnet/docs/issues/40172). **Opened:** March 21, 2024. **Size:** Small to medium. **GHCP suitability:** Strong for a versioned compatibility example, coordinated with assignee `gewarren`.

**Why it still applies and why the solution is defined:** The [compatibility note](../docs/core/compatibility/core-libraries/8.0/bool-backed-enum.md) describes the changed APIs and says that C# can't declare this enum shape, but supplies no concrete example. An owned Reflection.Emit fixture created the type; `Enum.GetNames` threw `InvalidOperationException` on both .NET 8 and .NET 10, while a byte-backed replacement returned its two names.

**Scope and acceptance:** Add a minimal IL or Reflection.Emit fixture, show a specific affected API before .NET 8 and its .NET 8 failure, and demonstrate the legal byte-backed alternative. Don't write an invalid C# `enum : bool` declaration or equate two logical values with a Boolean underlying type. Execute the historical side on the actual pre-.NET 8 runtime as well as the changed side; the triage checks didn't run that older runtime. Keep the breaking-change scope aligned with the API list rather than claim that every operation on any such value fails.

### dotnet/docs#40177: Add before-and-after examples for CA1842

**Issue:** [dotnet/docs#40177](https://github.com/dotnet/docs/issues/40177). **Opened:** March 21, 2024. **Size:** Small. **GHCP suitability:** Strong, coordinated with assignee `gewarren`.

**Why it still applies and why the solution is defined:** The [CA1842 reference](../docs/fundamentals/code-analysis/quality-rules/ca1842.md) describes unnecessary `Task.WhenAll` wrappers but still lacks the requested example. The fix is to await the one known task directly, not aggregate a single operation.

**Scope and acceptance:** Add executable C# and VB violation/fix examples that keep the enclosing method's result and observable failure behavior intentional. Prefer a nongeneric example for the simplest equivalent transformation. If a generic example is included, preserve the consumer's result shape: owned checks confirmed that `await Task.WhenAll(Task<int>)` produces `int[]`, whereas direct await produces `int`. Enable CA1842 to prove the before diagnostic and clean replacement, and show actual completion/fault results rather than imply an arbitrary array-to-scalar replacement is type-preserving.

### dotnet/docs#40178: Explain why CA1840 prefers the ID-only API

**Issue:** [dotnet/docs#40178](https://github.com/dotnet/docs/issues/40178). **Opened:** March 21, 2024. **Size:** Small. **GHCP suitability:** Strong, coordinated with assignee `gewarren`.

**Why it still applies and why the solution is defined:** [CA1840](../docs/fundamentals/code-analysis/quality-rules/ca1840.md) still calls the replacement "compact and efficient" without explaining why. The .NET 10 sources expose `Environment.CurrentManagedThreadId` directly; `Thread.CurrentThread` instead checks a cached managed thread and has an initialization path before its `ManagedThreadId` is read. The page's two VB examples also incorrectly close a `Sub` with `End Function`.

**Scope and acceptance:** Explain the ID-only intent and the extra thread-object lookup/initialization path the API avoids. Qualify runtime/JIT-dependent costs; don't claim an allocation on every old-form call or a universal measured speedup. Correct both VB terminators as part of the example pass. Compile and execute C# and VB before/after forms, confirm that both return the current managed thread's ID, and verify CA1840 on the old form. Keep managed IDs distinct from operating-system thread IDs.

### dotnet/docs#40264: Separate compiler defaults from SDK output defaults

**Issue:** [dotnet/docs#40264](https://github.com/dotnet/docs/issues/40264). **Opened:** March 29, 2024. **Size:** Small to medium. **GHCP suitability:** Strong for a bounded five-option reference correction.

**Why it still applies and why the solution is defined:** The [output-options reference](../docs/csharp/language-reference/compiler-options/output.md) mixes direct compiler switches, SDK properties, and template settings. Its reference-assembly location already includes the .NET 6.0.200 change, but several defaults remain implicit. An SDK 10.0.403 check of plain SDK libraries targeting .NET 8 and .NET 10 evaluated `OutputType=Library`, `GenerateDocumentationFile=false`, and `ProduceReferenceAssembly=true`. Direct Roslyn compilation without `-target` required an entry point and produced CS5001 for an empty class; explicit `-target:library` accepted the same class.

**Scope and acceptance:** Document defaults or their conditions for all five options, explicitly separating `csc` defaults from SDK evaluation and template overrides. In particular, don't label `library` as the raw compiler's default or imply that XML documentation/reference output is enabled identically in both contexts. Present modern intermediate reference-assembly placement first, with the older-location change as history. Cross-link SDK property documentation and verify evaluated properties plus actual output files with pinned tools; don't turn unset property text into a universal value or equate SDK `Exe` with an assembly filename ending in `.exe`.

### dotnet/docs#40275: Upgrade the remaining .NET 7 action container coherently

**Issue:** [dotnet/docs#40275](https://github.com/dotnet/docs/issues/40275). **Opened:** April 1, 2024. **Size:** Small to medium. **GHCP suitability:** Strong; a bounded project/container version alignment.

**Why it still applies and why the solution is defined:** The old `core/docker/snippets/7.0` sample is gone, but both stages of the [GitHub action Dockerfile](../docs/devops/snippets/create-dotnet-github-action/Dockerfile) still pin the .NET 7 SDK image and its old digest. The actual [action project](../docs/devops/snippets/create-dotnet-github-action/DotNet.GitHubAction/DotNet.GitHubAction.csproj) now targets .NET 8 and references version 10.0.14 hosting/DI packages. Deleting one listed sample didn't resolve the remaining build/runtime mismatch.

**Scope and acceptance:** Align the retained action project and both container stages on stable .NET 10, update the version comment, and resolve a real matching image digest rather than retain the .NET 7 digest under a new tag. Preserve action arguments, workspace access, entry-point behavior, and the existing SDK-bearing final stage. Build and execute the container against the documented action inputs; verify its exit status and `GITHUB_OUTPUT` values without expanding the example's intentional analysis pseudocode into a new implementation. Don't recreate the removed sample, hide the remaining file in the versionsweeper ignore list, or claim that a managed-only publish proves container execution.

### dotnet/docs#40680: Signpost the Windows native-tool environment for static linking

**Issue:** [dotnet/docs#40680](https://github.com/dotnet/docs/issues/40680). **Opened:** April 10, 2024. **Size:** Small. **GHCP suitability:** Suitable for a narrow signpost, with placement confirmed by current owners `nagilson` and `adegeo`.

**Why it still applies and why the solution is defined:** The [Native AOT linking section](../docs/core/deploying/native-aot/interop.md#linking) describes native linker inputs but doesn't identify the architecture-specific Windows native-tool environment. The reporter explicitly confirmed that the x64 Native Tools prompt made the static-dependency build work, whereas a generic Developer Command Prompt and the presence of `cl`/`link` weren't sufficient. The latest owner question concerns where to put the explanation, not an unresolved reproducer.

**Scope and acceptance:** Add a short Windows environment/prerequisite signpost beside the native-link input instructions, with a link to maintained Native AOT prerequisites rather than another full publishing tutorial. State that native library architecture and the compiler/linker environment must match the target RID; use the x64 prompt as the `win-x64` example, not a universal target choice. Confirm placement with both owners, then verify the documented native-library build and AOT link in that environment. Don't assert that every LNK2001 error is a PATH problem or that this reporter-specific resolution diagnoses arbitrary missing symbols.

### dotnet/docs#40440: Publish the CodeDom stream limitations in the API reference

**Issue:** [dotnet/docs#40440](https://github.com/dotnet/docs/issues/40440). **Opened:** April 10, 2024. **Size:** Small. **GHCP suitability:** Strong, but the edit belongs in `dotnet/dotnet-api-docs`, not this checkout.

**Why it still applies and why the solution is defined:** The [Windows Forms source correction](https://github.com/dotnet/winforms/commit/bdb87e21120b0b4a1c9e1c273c00c8c719012235) already explains supported in-memory operations and unsupported stream operations. Released .NET 10 source also throws `PlatformNotSupportedException` from `LoadStore` and the returned store's `Save`. However, the current [central API XML](https://github.com/dotnet/dotnet-api-docs/blob/main/xml/System.ComponentModel.Design.Serialization/CodeDomComponentSerializationService.xml) and [published LoadStore reference](https://learn.microsoft.com/dotnet/api/system.componentmodel.design.serialization.codedomcomponentserializationservice.loadstore?view=windowsdesktop-10.0) still describe loading and list only null/empty-stream exceptions.

**Scope and acceptance:** Update the class remarks and `LoadStore` documentation in that XML file with version-appropriate Framework/modern .NET distinctions and the supported-platform exception. Explain that this implementation's returned store supports in-memory use but not stream persistence. Don't say the entire service is nonfunctional, remove supported in-memory APIs, or mark every implementation of the abstract `SerializationStore.Save` contract unsupported. Verify published moniker-specific output and preserve Framework behavior; a source-comment-only change isn't proof that the API reference is corrected.

### dotnet/docs#40643: Show how to register a JsonConverterFactory

**Issue:** [dotnet/docs#40643](https://github.com/dotnet/docs/issues/40643). **Opened:** April 27, 2024. **Size:** Small. **GHCP suitability:** Strong; extend the existing factory example rather than introduce another converter design.

**Why it still applies:** The [converter guide](../docs/standard/serialization/system-text-json/converters-how-to.md#sample-factory-pattern-converter) explains the factory and inner converter, but its explicit registration examples use basic converters. The later open-generic attribute discussion doesn't show how to register this existing factory on supported .NET 8/.NET 10 versions.

**Why the solution is defined:** A factory instance belongs in `JsonSerializerOptions.Converters`; the serializer calls its `CreateConverter` method. An owned run linked the exact `DictionaryTKeyEnumTValueConverter.cs` source, selected `DictionaryEnumConverterInner` through `GetConverter`, and round-tripped `{"Monday":42}` on both runtimes. Output alone wouldn't prove selection because the built-in dictionary converter also supports enum keys.

**Scope and acceptance:** Add a short factory-registration example beside the factory pattern, and link to it from the existing registration section. Register the factory once, then serialize and deserialize a matching enum-keyed dictionary with the same options. Explain that callers don't manually instantiate the private inner converter or call `CreateConverter` for normal serialization. Verify the selected converter and round-trip result on supported runtimes; don't imply that this reflection-based generic factory is Native AOT-safe.

### dotnet/docs#40736: List built-in ASP.NET Core EventSource providers

**Issue:** [dotnet/docs#40736](https://github.com/dotnet/docs/issues/40736). **Opened:** May 3, 2024. **Size:** Small. **GHCP suitability:** Strong, with ASP.NET Core diagnostics-owner review.

**Why it still applies:** The ASP.NET Core section of [well-known event providers](../docs/core/diagnostics/well-known-event-providers.md) still supplies a logging link instead of the requested provider inventory.

**Why the solution is defined:** Released ASP.NET Core 10 source defines `Microsoft.AspNetCore.Hosting` in [HostingEventSource](https://github.com/dotnet/aspnetcore/blob/v10.0.0/src/Hosting/Hosting/src/Internal/HostingEventSource.cs) and `Microsoft-AspNetCore-Server-Kestrel` in [KestrelEventSource](https://github.com/dotnet/aspnetcore/blob/v10.0.0/src/Servers/Kestrel/Core/src/Internal/Infrastructure/KestrelEventSource.cs). Their event declarations establish the names, identifiers, and levels; those provider names aren't interchangeable with dotted meter or counter names.

**Scope and acceptance:** Replace the placeholder with a concise, version-scoped table for Hosting and Kestrel, their purpose, and links to maintained diagnostic guidance/source. Include a working `dotnet-trace` provider-selection example if needed; verify it against an owned HTTP application and identify the emitted request/connection events. Keep `Microsoft-Extensions-Logging` separate from those built-in sources. Don't promise an exhaustive inventory across every ASP.NET Core release or use a metric name as an EventSource selector.

### dotnet/docs#40799: Add a typed MTP discovery and execution walkthrough

**Issue:** [dotnet/docs#40799](https://github.com/dotnet/docs/issues/40799). **Opened:** May 8, 2024. **Size:** Medium. **GHCP suitability:** Suitable for a bounded client recipe, coordinated with current assignee `nohwnd`.

**Why it still applies:** The [server-mode guide](../docs/core/testing/microsoft-testing-platform-server-mode.md) now identifies the canonical source-only C# client, but doesn't demonstrate initialization, discovery metadata, selected execution, and result collection. The 2024 reply that no TranslationLayer-like client was planned no longer describes the whole current surface. `--list-tests json` also exists now, but listing names alone doesn't answer the custom-UI requirement.

**Why the solution is defined:** The actual [client interface](https://github.com/microsoft/testfx/blob/main/src/Platform/Microsoft.Testing.Platform.ServerMode.Client.Sources/Client/IMtpServerClient.cs) exposes initialization, discovery, filtered/selected execution, ordered node-update events, and asynchronous shutdown. Node updates retain their raw property bag as well as common typed fields. The upstream [client acceptance test](https://github.com/microsoft/testfx/blob/main/test/IntegrationTests/MSTest.Acceptance.IntegrationTests/MtpServerClientAcceptanceTests.cs) already demonstrates discovery and execution through the source package; no reflection into internal host constructors or fragile console parser is necessary.

**Scope and acceptance:** Add an article-relative executable example that consumes a released `Microsoft.Testing.Platform.ServerMode.Client.Sources` version and drives a small MSTest application. Capture discovered node IDs, display names, categories/custom test properties actually supplied by that framework, selected execution updates, and final results. Explain the raw property-bag shape rather than promise that every arbitrary framework object becomes JSON metadata. Respect negotiated `MultiRequestSupport`; use separate sessions when required, and don't confuse `IsStateful` with that capability. Verify successful discovery, metadata preservation, one filtered run, failure reporting, cancellation, and awaited shutdown without a leaked child process. Link the JSON-listing alternative with its version/banner requirements, and retain the distinction from the SDK's internal `dotnettestcli` protocol.

### dotnet/docs#40832: Complete the heterogeneous-cluster stream configuration warning

**Issue:** [dotnet/docs#40832](https://github.com/dotnet/docs/issues/40832). **Opened:** May 9, 2024. **Size:** Small. **GHCP suitability:** Strong for the remaining streaming clarification, with Orleans-owner review.

**Why it still applies:** The [reminder guide](../docs/orleans/grains/timers-and-reminders.md) already warns that all silos, including silos without reminder grains, must receive the reminder configuration. The issue also requests the corresponding streaming warning. The [stream quick-start](../docs/orleans/streaming/streams-quick-start.md) and [provider guidance](../docs/orleans/streaming/stream-providers.md) don't supply that explicit heterogeneous-cluster requirement.

**Scope and acceptance:** Add the all-silo requirement beside the quick-start's stream-provider configuration, and cross-link the existing reminder warning rather than duplicate or rewrite it. Explain that silos in the heterogeneous cluster need the required common logical stream-provider configuration even if a particular silo doesn't host the stream-using grain types. Have the Orleans owner confirm the provider-specific wording; don't equate compatible provider/backend registration with identical values for every silo option, prescribe silo-only registrations on clients, or invent an unverified runtime failure mechanism.

### dotnet/docs#40860: Document SQLite null-parameter values

**Issue:** [dotnet/docs#40860](https://github.com/dotnet/docs/issues/40860). **Opened:** May 13, 2024. **Size:** Small. **GHCP suitability:** Strong; the affected [parameters article](../docs/standard/data/sqlite/parameters.md) remains in this repository.

**Why it still applies:** The article explains names, types, and sizes but doesn't distinguish an unset/null CLR parameter value from SQL `NULL`. An owned Microsoft.Data.Sqlite 10.0.13 check reproduced "Value must be set" for a parameter whose value was C# `null`; explicit `DBNull.Value` returned SQL `NULL`.

**Scope and acceptance:** Add a short null-values section with a parameterized nullable-value example that supplies `DBNull.Value` for a missing value and preserves a non-null value. Use the actual `DBNull.Value` API, not the issue's `Db.Null` typo. Execute C# and Visual Basic equivalents against an in-memory database, assert `IsDBNull` for the null case, and round-trip a non-null value that contains an apostrophe. Keep SQL parameterization intact; don't recommend interpolation, a magic string `"NULL"`, or treat an uninitialized parameter as SQL `NULL`.

### dotnet/docs#41074: Demonstrate MaximumEntropy multiclass warm-start training

**Issue:** [dotnet/docs#41074](https://github.com/dotnet/docs/issues/41074). **Opened:** May 25, 2024. **Size:** Medium. **GHCP suitability:** Strong for a trainer-specific example, not a generic promise of incremental learning.

**Why it still applies:** The [retraining guide](../docs/machine-learning/how-to-guides/retrain-model-ml-net.md) names `MaximumEntropyModelParameters` but demonstrates only regression extraction and training. It doesn't show the corresponding multiclass transformer or the two-argument trainer call requested by the issue.

**Why the solution is defined:** The trainer provides `Fit(IDataView, MaximumEntropyModelParameters)`. An owned ML.NET 5.0.1 fixture trained a three-class model, saved and loaded its `MulticlassPredictionTransformer<MaximumEntropyModelParameters>`, and passed its `Model` to that overload. On .NET 8 and .NET 10, the warm-start result scored 18 rows with three finite scores each.

**Scope and acceptance:** Add the trainer-specific extraction, compatible data preparation, `Fit(newData, originalParameters)`, and save/load path alongside the existing regression example. Preserve the label-key mapping, feature schema, and known class set across both datasets. Execute the complete example and inspect the resulting model/output; don't cast multiclass parameters to the regression type, promise support for new classes, equate warm-start optimization with online learning, or claim an accuracy improvement from a successful call alone. Coordinate with the separate calibrated-model extraction task, dotnet/docs#28677, without replacing that binary-model fix.

### dotnet/docs#41305: Add PrimeService to the solution before the first edit

**Issue:** [dotnet/docs#41305](https://github.com/dotnet/docs/issues/41305). **Opened:** June 5, 2024. **Size:** Small. **GHCP suitability:** Strong; reorder the existing tutorial without changing its test-driven progression.

**Why it still applies:** The original URL now serves a conceptual `dotnet test` article, but the moved [xUnit tutorial](../docs/core/testing/unit-testing-csharp-with-xunit.md) still tells readers to rename/edit `Class1.cs` before `dotnet sln add`. That sequence prevents a reader who opens the new solution in Solution Explorer from seeing the library at the point where the tutorial asks for an edit.

**Scope and acceptance:** Move the existing solution-add step immediately after library creation and before file edits. Update both the narrative and the equivalent command sequence so they agree, preserve working directories/project paths, and leave the intentional failing/passing tests in order. Verify a fresh CLI execution and solution membership at the first edit; check the IDE route if claiming that specific UI experience. Don't add an unconditional clean/rebuild requirement based only on a later comment, or edit the replacement conceptual page instead of the actual walkthrough.

### dotnet/docs#41327: Explain structured state in the custom logger

**Issue:** [dotnet/docs#41327](https://github.com/dotnet/docs/issues/41327). **Opened:** June 6, 2024. **Size:** Small. **GHCP suitability:** Strong for the remaining explanation, coordinated with assignee `gewarren`.

**Why it still applies:** [dotnet/docs#51524](https://github.com/dotnet/docs/pull/51524), merged February 5, 2026, corrected the orphaned snippet fragment and line range in the [custom-provider guide](../docs/core/extensions/logging/custom-provider.md). It didn't add the requested explanation of message-template properties or the original template carried in state. Closing the whole issue because the fragment was repaired would lose that remaining requirement.

**Scope and acceptance:** Explain the structured key/value state used by normal logging extensions, including `"{OriginalFormat}"`, and show how a provider can inspect it through public enumerable interfaces. Preserve the generic `TState` contract and the formatter fallback for nonstructured callers; keep the exception argument distinct from state. Owned .NET 8/.NET 10 executions captured `OrderId`, `Customer`, and the original template, accepted a plain-string state, and received the separate exception. Verify those cases and a source-generated logging call in the final example. Don't reflect into internal `FormattedLogValues`, parse the formatted message to recover properties, or promise that every `ILogger.Log<TState>` caller supplies a key/value list. Coordinate changes to the same sample with the scope task dotnet/docs#37874.

### dotnet/docs#41369: Introduce optional SDK workloads

**Issue:** [dotnet/docs#41369](https://github.com/dotnet/docs/issues/41369). **Opened:** June 11, 2024. **Size:** Small. **GHCP suitability:** Strong; add a conceptual bridge rather than another command reference.

**Why it still applies:** The [SDK overview](../docs/core/sdk.md) doesn't explain workloads. The [workload-install reference](../docs/core/tools/dotnet-workload-install.md) already defines optional SDK additions for application types, but readers must reach that command page to learn the concept.

**Scope and acceptance:** Add a short workloads section to the SDK overview that distinguishes optional platform/tooling components from project NuGet dependencies and installed runtimes. Use .NET MAUI and WebAssembly AOT as examples, and link to workload discovery, installation, listing, and workload sets. Explain SDK/version context without promising a universal list of workload IDs or that every .NET app needs a workload. Preserve the command references as the detailed source; don't run installation commands as part of this explanatory change.

### dotnet/docs#41421: Correct the Finalize reference's blanket managed-object rule

**Issue:** [dotnet/docs#41421](https://github.com/dotnet/docs/issues/41421). **Opened:** June 13, 2024. **Size:** Small. **GHCP suitability:** Suitable for a narrow API-reference correction, with GC-owner review.

**Why it still applies:** The old supplemental article has moved into the [Object XML reference](https://github.com/dotnet/dotnet-api-docs/blob/main/xml/System/Object.xml). Its `Finalize` remarks still prohibit calls on all objects except the base class while its example calls a referenced `Stopwatch`. The same remarks describe unordered finalization and also assert that an object can be resurrected only once. An owned .NET 8/.NET 10 fixture safely accessed a retained `Stopwatch` and, with explicit `ReRegisterForFinalize`, resurrected an object twice before its third finalizer pass.

**Scope and acceptance:** Edit the `Finalize` remarks in the API repository, not the removed local Markdown file. Distinguish managed-object reachability from the unspecified finalization/cleanup order of finalizable dependencies; don't claim that arbitrary dependency state remains safe. Reconcile the resurrection sentence with explicit re-registration and the existing API explanation. Keep deterministic disposal and `SafeHandle` as the recommended resource-management approach, and qualify any touched shutdown/output claims by runtime. Have a GC owner review the wording; a successful `Stopwatch` fixture isn't proof that all managed-object operations are safe in finalizers.

### dotnet/docs#41515: Distinguish native host-context cleanup from runtime unloading

**Issue:** [dotnet/docs#41515](https://github.com/dotnet/docs/issues/41515). **Opened:** June 21, 2024. **Size:** Small. **GHCP suitability:** Strong for a lifecycle explanation, with hosting-owner review.

**Why it still applies:** The [native-host tutorial](../docs/core/tutorials/netcore-hosting.md) names `hostfxr_close` and limits the process to one runtime, but doesn't directly explain the cleanup/repeated-initialization question. Its actual native sample already closes the host context after it obtains the delegate; adding another close call wouldn't unload CoreCLR. The [hosting design](https://github.com/dotnet/runtime/blob/main/docs/design/features/native-hosting.md) explicitly describes compatible contexts attaching to the existing runtime and reusable function pointers.

**Scope and acceptance:** Add a concise lifecycle note beside initialization and cross-link the limitations. Explain that closing a host context releases that context, not the process's loaded runtime; reuse delegates for repeated managed calls, and don't present compatible reinitialization as a fresh runtime. Distinguish assembly-load-context unloading from runtime teardown. Preserve the existing close/error paths, and verify repeated callbacks in an owned native host before adding runnable lifecycle code. Don't invent a supported CoreCLR unload/restart API or claim a native execution that wasn't performed.

### dotnet/docs#41539: Qualify Windows analysis of source-built Linux runtime dumps

**Issue:** [dotnet/docs#41539](https://github.com/dotnet/docs/issues/41539). **Opened:** June 24, 2024. **Size:** Small. **GHCP suitability:** Strong for a version/tool-qualified limitation, with diagnostics-owner review.

**Why it still applies:** The [Linux-dump guide](../docs/core/diagnostics/debug-linux-dumps.md) discusses matching private runtime binaries in its Linux section but makes an unqualified Windows cross-debugging claim. The [cDAC tracking discussion](https://github.com/dotnet/runtime/issues/99298) distinguishes the tightly coupled existing DAC from a portable replacement whose supported commands and rollout remain version-dependent.

**Scope and acceptance:** Qualify the Windows route for custom/source-built Linux runtimes: the selected tool needs a compatible Windows DAC for the exact target runtime, which needn't be available for that private build. Link the matching-binary guidance and give Linux-native analysis as the fallback. Have the diagnostics owner confirm the tool/version matrix and reproduce any newly advertised cDAC route. Don't suggest loading a Linux `.so` as a Windows DAC, claim that all Linux dumps fail on Windows, or treat a portability roadmap as a completed general solution.

### dotnet/docs#49641: Explain generated-code classification for analyzer authors

**Issue:** [dotnet/docs#49641](https://github.com/dotnet/docs/issues/49641). **Opened:** June 27, 2024. **Size:** Small. **GHCP suitability:** Strong for a source-backed API explanation, with Roslyn-owner review.

**Why it still applies:** The [ConfigureGeneratedCodeAnalysis API XML](https://github.com/dotnet/roslyn-api-docs/blob/main/dotnet/xml/Microsoft.CodeAnalysis.Diagnostics/AnalysisContext.xml) still leaves the method's remarks as "To be added." The [analyzer driver](https://github.com/dotnet/roslyn/blob/main/src/Compilers/Core/Portable/DiagnosticAnalyzer/AnalyzerDriver.cs) applies explicit `generated_code` configuration before filename/header heuristics; the issue's `.gen.cs` suffix isn't one of those automatic filename conventions.

**Scope and acceptance:** Explain current recognized filename/header conventions, the explicit `.editorconfig` override, and the difference between generated-code analysis and diagnostic-reporting flags. Distinguish file heuristics from symbol-level `GeneratedCodeAttribute` and compiler-generated-source behavior rather than promise one exhaustive permanent rule. An owned SDK Roslyn analyzer confirmed `.gen.cs` as ordinary code, five recognized filename forms and an auto-generated header as generated, explicit true/false overrides, and suppression of an attributed type. Reproduce those cases for the documented Roslyn version and review the source-generator/attribute boundaries with the owner. Don't invent a `.gen.cs` default or advise renaming every generator output when explicit configuration solves the case.

### dotnet/docs#41573: Prevent the Iris tutorial from saving a GitHub HTML page as data

**Issue:** [dotnet/docs#41573](https://github.com/dotnet/docs/issues/41573). **Opened:** June 27, 2024. **Size:** Small. **GHCP suitability:** Strong; the attachment supplies a reproducible root cause.

**Why it still applies:** The [Iris tutorial](../docs/machine-learning/tutorials/iris-clustering.md) links to a GitHub `blob` page as its dataset download. The reporter's attached ZIP contains `iris.data`, but that file begins with `<!DOCTYPE html>` and contains the GitHub file-viewer page, not numeric CSV rows. With the tutorial's exact four-column schema, that attachment reproduced "Failed to initialize clusters: too few examples" on ML.NET 3.0.1 and 5.0.1. The actual dataset trained successfully with 150 rows and three cluster distances.

**Scope and acceptance:** Link to the raw dataset or explicitly direct readers to GitHub's raw-download control. Explain that the saved file must contain the five CSV columns, not HTML, and include a brief first-row/data-format check in the preparation instructions. Execute the current tutorial with the actual dataset and preserve the useful distinction between the reported saved-page error and other possible causes of too few valid training examples. Don't change the cluster count, invent a package downgrade, or replace this confirmed download problem with generic model-tuning advice.

### dotnet/docs#41673: Add actionable exemplar configuration and correlation guidance

**Issue:** [dotnet/docs#41673](https://github.com/dotnet/docs/issues/41673). **Opened:** July 8, 2024. **Size:** Medium. **GHCP suitability:** Strong for the specified OpenTelemetry/Aspire recipe, with diagnostics review.

**Why it still applies:** The [current OTLP walkthrough](../docs/core/diagnostics/observability-otlp-example.md) explains exemplar dots and trace navigation, but doesn't explain configuration, selection, and instrumentation context. The [OpenTelemetry .NET exemplar guide](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/docs/metrics/exemplars/README.md) supplies the existing filter APIs and requirements.

**Scope and acceptance:** Extend the existing walkthrough or add a linked diagnostics article with the requested Aspire example. Pin compatible OpenTelemetry/dashboard versions, show the supported exemplar filter, record histogram measurements inside the appropriate recorded activity, and export both metrics and traces to the same usable backend. Explain sampling/filtering, activity lifetime, and backend support; don't turn trace IDs into metric dimensions or promise an exemplar for every measurement. Execute the example, inspect the exported exemplar's trace/span IDs, and verify navigation to that trace in Aspire before producing screenshots or claiming UI success. Add a TOC entry if the implementation creates a page; don't duplicate the current introductory paragraph as the whole fix.

### dotnet/docs#41682: Match dependency-arrow prose to the actual architecture diagram

**Issue:** [dotnet/docs#41682](https://github.com/dotnet/docs/issues/41682). **Opened:** July 9, 2024. **Size:** Very small. **GHCP suitability:** Strong for a localized correction, with architecture-owner review.

**Why it still applies:** The [web-architecture chapter](../docs/architecture/modern-web-apps-azure/common-web-application-architectures.md) says solid arrows mean compile-time dependencies and dashed arrows mean runtime-only dependencies. Inspection of its actual figure 5-8 shows the opposite legend distinction: dashed gray arrows denote compile-time dependencies, and the solid black UI-to-Infrastructure arrow denotes an optional compile-time dependency.

**Scope and acceptance:** Correct the prose to match the current legend, and explain the optional composition-root reference without relabeling it runtime-only. Check both the rendered image and surrounding explanation; don't rely on the issue's mistaken description of the arrow style. Keep a general configuration/IoC redesign out of this bounded correction, and don't silently redraw the diagram to introduce a different dependency policy.

### dotnet/docs#41683: Document HttpContent constructor header defaults

**Issue:** [dotnet/docs#41683](https://github.com/dotnet/docs/issues/41683). **Opened:** July 9, 2024. **Size:** Small. **GHCP suitability:** Strong; the default values and explicit-header remedy are reproducible.

**Why it still applies:** The [HTTP content section](../docs/fundamentals/networking/http/httpclient.md#understand-http-content) still lists subclasses without their default `Content-Type` values. [dotnet/runtime#102923](https://github.com/dotnet/runtime/issues/102923) confirms the Android native handler's absent-header behavior; the reporter later confirmed that setting the header explicitly worked.

**Scope and acceptance:** Replace the list with a table that separates constructor defaults from handler-supplied values. Owned .NET 8/.NET 10 checks found no default for `ByteArrayContent`, `StreamContent`, or `ReadOnlyMemoryContent`; form, JSON, string, and multipart content supplied their expected media types, charset parameters, or generated boundaries. Include a short explicit `application/octet-stream` example and a platform-qualified Android caveat. Verify all eight listed types and don't publish a fixed multipart boundary as the universal default. Don't call the behavior random, imply an Android-device run, or recommend Base64 or a handler replacement instead of the confirmed explicit header.

### dotnet/docs#41739: Complete the application-facing feature-switch guidance

**Issue:** [dotnet/docs#41739](https://github.com/dotnet/docs/issues/41739). **Opened:** July 12, 2024. **Size:** Small. **GHCP suitability:** Strong for the owner-approved subset, coordinated with assignee `LakshanF`.

**Why it still applies:** The [trim-feature table](../docs/core/deploying/trimming/trimming-options.md#trim-framework-library-features) lacks `PredefinedCulturesOnly`, `JsonSerializerIsReflectionEnabledByDefault`, and the scoped WebAssembly `HybridGlobalization` guidance. It also sends readers to an implementation-details table rather than directly supplying the requested public mappings. Maintainers explicitly distinguish application-facing switches from app-model internals and unsafe escape hatches.

**Scope and acceptance:** Add those three supported entries or direct links to their existing feature documentation, with current version/platform limits. An owned SDK 10.0.403 build emitted and read back the requested debugger, EventSource, resource-key, predefined-culture, JSON-reflection, and native-HTTP mappings; the hybrid WebAssembly case still needs its platform-specific check. For the approved application-facing switches, document only verified MSBuild/AppContext mappings and distinguish build-time feature removal from runtime configuration: a runtime switch can't restore trimmed code. Confirm the mappings against SDK output and current runtime sources, especially the platform-specific hybrid/native-handler cases. Don't publish every item in the original issue, promote underscored/app-model switches to supported app APIs, or restore removed BinaryFormatter functionality. Coordinate the narrowed scope with the current owner rather than duplicate ownership.

### dotnet/docs#41772: Clarify the legacy DDD sample's application/infrastructure dependencies

**Issue:** [dotnet/docs#41772](https://github.com/dotnet/docs/issues/41772). **Opened:** July 16, 2024. **Size:** Small. **GHCP suitability:** Suitable for a source-backed architecture clarification, with owner review.

**Why it still applies:** The [DDD chapter](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice.md) and its diagram say that the application depends on infrastructure "through DI" without separating bootstrap wiring from business dependencies. The archived [Ordering.API project](https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.API/Ordering.API.csproj) really references Infrastructure, while its [create-order handler](https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.API/Application/Commands/CreateOrderCommandHandler.cs) consumes the domain `IOrderRepository` contract.

**Scope and acceptance:** Explain that the legacy API project includes the composition root and therefore references implementations for registration, while business handlers can depend on domain abstractions. Distinguish that concrete sample arrangement from a mandatory outward dependency for every application layer or strict Clean Architecture. Cross-link the existing architecture explanation and check the diagram/text against the archived `dev` sources; the repository's default `repo_moved` branch doesn't contain the old project. Don't falsely remove its real reference in prose, attribute a universal Clean Architecture rule to DDD, or redesign the sample as part of this clarification.

### dotnet/docs#41811: Identify the correct service principal by stable IDs

**Issue:** [dotnet/docs#41811](https://github.com/dotnet/docs/issues/41811). **Opened:** July 17, 2024. **Size:** Small. **GHCP suitability:** Strong for a scoped identity-selection clarification, with Azure-owner review.

**Why it still applies:** The [local-development authentication page](../docs/azure/sdk/authentication/local-development-service-principal.md) includes shared Azure instructions that select a principal by display name. The [current group include](https://github.com/MicrosoftDocs/azure-dev-docs/blob/main/articles/includes/authentication/create-entra-group.md) distinguishes application ID from object ID, but its name-prefix lookup doesn't resolve same-name identities. The actual issue screenshots confirm the ambiguous picker, not why those particular duplicate entries exist.

**Scope and acceptance:** Explain how the local app-registration principal differs from a deployed app's managed identity, including slot-specific identities. Match the tenant and actual credential's client/application ID to the service-principal object ID before group membership or role assignment; use a precise ID lookup rather than choose by display name alone. Update the shared include in `MicrosoftDocs/azure-dev-docs` where appropriate and coordinate its other language consumers. Validate any CLI recipe and portal labels without publishing real identifiers or granting access during triage. Don't always choose the managed identity, use the app-registration object's ID as the principal ID, infer the screenshots' exact cause, or grant both ambiguous principals access.

### dotnet/docs#41976: Finish the remaining Framework 4.0 sample target updates

**Issue:** [dotnet/docs#41976](https://github.com/dotnet/docs/issues/41976). **Opened:** August 1, 2024. **Size:** Medium. **GHCP suitability:** Suitable for a project-checklist change with Windows/.NET Framework build coverage.

**Why it still applies:** Of the 45 exact project paths in the version-sweeper report, 34 still declare `v4.0`. Six already use `v4.8`, four now use `net10.0-windows`, and the Office VB project was removed. The [Framework support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-framework) records Framework 4.0's end of support; the completed paths don't resolve the remaining checklist.

**Scope and acceptance:** Retarget the 34 remaining projects to an appropriate supported Framework baseline, normally 4.8, and retain traditional project syntax, sample regions, resources, and Windows-only dependencies where needed. Don't port WCF, WPF, or Framework-specific APIs to modern .NET as an incidental version edit. Check each sample's article for intentional historical constraints, build the changed projects with the Windows Framework toolchain, and record any required reference-pack or dependency corrections. Exclude the eleven already-migrated or removed paths rather than reopen their work.

### dotnet/docs#41977: Update the six remaining netcoreapp3.1 projects

**Issue:** [dotnet/docs#41977](https://github.com/dotnet/docs/issues/41977). **Opened:** August 1, 2024. **Size:** Medium. **GHCP suitability:** Strong for the six named project targets, with analyzer/tutorial regression checks.

**Why it still applies:** All six full project URLs in the report still resolve to projects that target `netcoreapp3.1`. The list includes `MakeConst.Test`; the shorter link title isn't its complete path. That test project already references modern Roslyn, MSTest, and test-SDK packages, so the unsupported target remains a real build-baseline mismatch rather than a deleted-file alert.

**Scope and acceptance:** Retarget the six projects to a supported modern .NET baseline consistent with their articles, preferably .NET 10, and make only dependency adjustments required for compatibility. Restore, build, and run their applicable tests or tutorial steps, including the analyzer's fail/pass sequence. Don't retarget the separate Framework VSIX merely because it shares a solution, or infer that a successful restore proves the analyzer runs in its documented host.

### dotnet/docs#41978: Update the five remaining Framework 4.5 projects

**Issue:** [dotnet/docs#41978](https://github.com/dotnet/docs/issues/41978). **Opened:** August 1, 2024. **Size:** Medium. **GHCP suitability:** Suitable for a bounded Framework-target maintenance task.

**Why it still applies:** All five exact project URLs still exist and declare `v4.5`; none is resolved by a missing file. The [Framework support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-framework) records Framework 4.5's end of support.

**Scope and acceptance:** Retarget the five traditional projects to Framework 4.8 where their article doesn't require a historical target. Preserve their Framework/Windows Forms and Dataflow teaching scenarios; resolve only reference or restore failures tied to the target change. Build each project with the appropriate Windows toolchain and verify referenced snippet regions. Don't replace the projects with modern .NET applications, delete their resources, or describe unrelated old package versions as fixed without separate evidence.

### dotnet/docs#41979: Retarget the Framework AppDomain setup sample

**Issue:** [dotnet/docs#41979](https://github.com/dotnet/docs/issues/41979). **Opened:** August 1, 2024. **Size:** Small. **GHCP suitability:** Strong for a Framework-only project target update.

**Why it still applies:** The [named project](../samples/snippets/csharp/VS_Snippets_CLR/AppDomain_Setup/CS/Test.csproj) still targets `net45`. Its source is `setup.cs`, not `Test.cs`, and uses Framework AppDomain setup and evidence APIs that shouldn't be ported to modern .NET.

**Scope and acceptance:** Change the supported compile baseline to `net48`, retain `StartupObject` and all three existing source files, and build with Framework reference assemblies. Preserve the article's historical/API context and explicit placeholder configuration. Don't advertise the placeholder-bearing example as a ready-to-run sandbox, remove its APIs to make it compile on .NET 10, or claim AppDomain isolation supplies a modern security boundary.

### dotnet/docs#41980: Update the two memory/span sample compile targets

**Issue:** [dotnet/docs#41980](https://github.com/dotnet/docs/issues/41980). **Opened:** August 1, 2024. **Size:** Small. **GHCP suitability:** Strong for two scoped project-target edits.

**Why it still applies:** Both [task-returning](../docs/standard/memory-and-spans/snippets/usage-guidelines/task-returning/task-returning.csproj) and [task-returning-async](../docs/standard/memory-and-spans/snippets/usage-guidelines/task-returning-async/project.csproj) projects still target `net7.0`. The linked source files retain the memory-lifetime examples; neither project is a deleted-path alert.

**Scope and acceptance:** Retarget both projects to .NET 10, build their actual source files, and check the article's extracted regions. Preserve the distinction between synchronous and task-returning memory consumption. Don't use compilation as proof that the existing console driver awaits every task or disposes every resource; any separately discovered lifetime defect needs explicit evidence and scope, not an unexplained behavioral rewrite inside a target-only maintenance task.

### dotnet/docs#42008: Complete the existing Orleans grain-migration guidance

**Issue:** [dotnet/docs#42008](https://github.com/dotnet/docs/issues/42008). **Opened:** August 2, 2024. **Size:** Small. **GHCP suitability:** Suitable for the remaining owner-reviewed clarification, not a duplicate feature article.

**Why it still applies:** The [grain-migration section](../docs/orleans/grains/grain-lifecycle.md#grain-migration) already covers migration triggers, dehydration/rehydration, `IGrainMigrationParticipant`, persistent state, placement hints, and immovable grains. It doesn't explicitly establish serializer requirements for custom migrated values or explain pending-message behavior with the qualifications the original request needs. The Orleans [migration lifecycle contract](https://github.com/dotnet/orleans/blob/main/src/Orleans.Core.Abstractions/Lifecycle/IGrainLifecycle.cs) and state-storage implementation provide concrete sources for the remaining explanation.

**Scope and acceptance:** With current assignee `ReubenBond`, add the custom-state serialization prerequisite and a source/version-checked explanation of message routing during a normal migration and its failure limits. Link existing serializer guidance instead of reproduce it. Use the actual `IPlacementDirector` API name, preserve automatic persistent-state participation, and distinguish migration from persistence or durable backup. Don't promise exactly-once execution, losslessness through arbitrary failures, or automatic transfer of every field and resource. Have the Orleans owner confirm the new claims and execute any added example on a matching multi-silo fixture.

### dotnet/docs#42026: Add an actionable Azure Monitor route from metric collection

**Issue:** [dotnet/docs#42026](https://github.com/dotnet/docs/issues/42026). **Opened:** August 3, 2024. **Size:** Small. **GHCP suitability:** Strong for a discoverability addition with existing-owner coordination.

**Why it still applies:** The [metric-collection guide](../docs/core/diagnostics/metrics-collection.md) mentions Azure Monitor's endorsement but doesn't lead readers through the requested App Service collection and analysis route. A dedicated [Application Insights walkthrough](../docs/core/diagnostics/observability-applicationinsights.md) already exists, so another full Azure guide isn't needed. The related [dotnet/AspNetCore.Docs#33246](https://github.com/dotnet/AspNetCore.Docs/issues/33246) remains open.

**Scope and acceptance:** Coordinate with assignee `Rick-Anderson` and the ASP.NET Core counterpart. Add a short Azure Monitor signpost/subsection that links the existing walkthrough and current authoritative App Service instrumentation and metric-analysis guidance. Distinguish application instrumentation/export from platform metrics and automatic instrumentation; don't imply arbitrary custom meters are collected without configuration. Keep the separately tracked Azure connection-string sample bug on its existing PR rather than duplicate that implementation.

### dotnet/docs#42092: Clarify MSBuild property aliases and command boundaries

**Issue:** [dotnet/docs#42092](https://github.com/dotnet/docs/issues/42092). **Opened:** August 9, 2024. **Size:** Small. **GHCP suitability:** Strong for a command-reference clarification with current assignee `pojith`.

**Why it still applies:** The [build reference](../docs/core/tools/dotnet-build.md) lists `-p|--property` and links MSBuild, but doesn't explicitly explain accepted `/p:` and `/property:` aliases. An owned property-echo project on SDK 10.0.403 verified that both slash forms and `-p:` passed the expected value to `dotnet build`.

**Scope and acceptance:** Explain the MSBuild aliases in the existing pass-through/property material and cross-link `dotnet msbuild`. Distinguish build/MSBuild switches from `dotnet run`'s own option parser and application arguments. Verify any `run` statement separately on the documented SDK; don't generalize the build probe or preserve a stale blanket claim about every spelling. Include exact command/output evidence for each documented alias without change to repository build behavior.

### dotnet/docs#42098: Demonstrate a DelegatingHandler chain without DI

**Issue:** [dotnet/docs#42098](https://github.com/dotnet/docs/issues/42098). **Opened:** August 9, 2024. **Size:** Small. **GHCP suitability:** Strong for a focused, executable HTTP recipe.

**Why it still applies:** The [HttpClient guidance](../docs/fundamentals/networking/http/httpclient.md) doesn't show the requested manual `DelegatingHandler`/inner-handler chain. The closed predecessor was a duplicate, not evidence that the retained request was implemented. An owned .NET 8/.NET 10 fixture constructed the chain without a service container and confirmed that the terminal handler received the outgoing header without network access.

**Scope and acceptance:** Add a short manually constructed handler-chain example with a terminal transport, cancellation forwarding, and the distinction between forwarding and short-circuit responses. Align client/handler disposal and reuse with the existing lifetime guidance; don't promote a new client per request. Execute normal, short-circuit, cancellation, and disposal cases with a controlled handler, and retain language/snippet conventions. A client-side header example must not claim to enforce server-side authorization or security.

### dotnet/docs#42377: Update the EF value-object recommendation for complex types

**Issue:** [dotnet/docs#42377](https://github.com/dotnet/docs/issues/42377). **Opened:** August 29, 2024. **Size:** Small. **GHCP suitability:** Suitable for a version-qualified architecture clarification and model example.

**Why it still applies:** The [value-object chapter](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects.md) still describes owned entities as the current best mapping from EF Core 2.0 onward. EF Core 8 added complex types, and the [current EF guidance](https://learn.microsoft.com/ef/core/modeling/complex-types) supplies the alternative requested by the issue.

**Scope and acceptance:** Add a modern, version-qualified complex-type recommendation for value-object scenarios without identity, with an explicit `ComplexProperty` or attribute example and a link to the authoritative version-specific limits. Preserve the archived sample's owned-entity explanation and identify when identity/ownership semantics still justify owned entities. Verify the selected EF version with a model and database round trip. Don't declare owned entities obsolete, force an archived application upgrade, or assign later collection/constructor/JSON capabilities to EF Core 8.

### dotnet/docs#42473: Explain one-way analyzer options without implying inverse enforcement

**Issue:** [dotnet/docs#42473](https://github.com/dotnet/docs/issues/42473). **Opened:** September 4, 2024. **Size:** Small. **GHCP suitability:** Strong for the five named rule pages and their shared explanation, with assignee `gewarren`.

**Why it still applies:** The current IDE0040, IDE0042, IDE0071, IDE0075, and IDE0090 pages use ambiguous "Do not prefer" descriptions, and the [general language-rule explanation](../docs/fundamentals/code-analysis/style-rules/language-rules.md) doesn't clearly distinguish a one-way simplification option from an enforced opposite style. Roslyn's deconstruction, interpolation, conditional-simplification, and implicit-object-creation analyzers return without analysis when their preference is false; the accessibility analyzer likewise skips `never`, while `omit_if_default` is a different active option.

**Scope and acceptance:** Revise those five option descriptions and the shared explanation to state the actual diagnostic behavior, with positive and no-diagnostic examples for each relevant setting. Distinguish a preference that disables a particular suggestion from severity `none`, and don't generalize that every Boolean option behaves this way. Confirm each table against its analyzer implementation and a matching diagnostic fixture; don't change analyzer behavior or expand the task into an unbounded audit of every style rule.

### dotnet/docs#42584: Define mutability and readonly in the type-system introduction

**Issue:** [dotnet/docs#42584](https://github.com/dotnet/docs/issues/42584). **Opened:** September 11, 2024. **Size:** Small. **GHCP suitability:** Strong for a short conceptual addition and cross-links.

**Why it still applies:** The [type-system introduction](../docs/csharp/fundamentals/types/index.md) mentions immutability when it compares type constructs, but doesn't define mutable, immutable, or `readonly`. The related class, record, and struct pages don't replace the missing introductory distinction. An owned .NET 8/.NET 10 example confirmed that a readonly struct can still reference a mutable list.

**Scope and acceptance:** Define the three terms and distinguish value/reference semantics from mutability. Explain that `readonly` restricts assignment or mutation through a particular member/reference and doesn't automatically make the reachable object graph immutable. Link the existing readonly and record guidance, including mutable record structs and shallow immutability. Keep examples small and execute any added snippets. Check with the earlier volunteer before parallel implementation, and coordinate with the existing type-selection PR rather than duplicate its matrix.

### dotnet/docs#42655: Correct the historical host-shutdown explanation

**Issue:** [dotnet/docs#42655](https://github.com/dotnet/docs/issues/42655). **Opened:** September 18, 2024. **Size:** Small. **GHCP suitability:** Strong for two source-backed prose corrections.

**Why it still applies:** The [host-shutdown section](../docs/core/extensions/generic-host.md#host-shutdown) still says that `Environment.Exit` raises SIGTERM, where the explanation requires `ProcessExit`, and retains the malformed deadlock sentence shown in the issue's actual screenshot. The linked [runtime investigation](https://github.com/dotnet/runtime/issues/50397) supplies the historical wait-cycle context.

**Scope and acceptance:** Correct the event name and explain that the old `ProcessExit` handler could wait for host shutdown while `Environment.Exit` blocked a thread needed to complete that shutdown. Preserve the before-.NET-6 context and the later POSIX-signal behavior. Don't imply that `Environment.Exit` sends SIGTERM or that current hosting turns an abrupt exit into graceful cleanup. Review the revised paragraph with the hosting owner; the correction doesn't require changing shutdown APIs or running a service on the reviewer's machine.

### dotnet/docs#42805: Explain the throw-helper performance rationale

**Issue:** [dotnet/docs#42805](https://github.com/dotnet/docs/issues/42805). **Opened:** October 2, 2024. **Size:** Small. **GHCP suitability:** Strong for a bounded explanation, not a new performance guarantee.

**Why it still applies:** The [.NET 8 SDK summary](../docs/core/whats-new/dotnet-8/sdk.md) still asserts that throw helpers are more efficient, but doesn't explain why source-level method-call counting is misleading. The runtime's [ThrowHelper rationale](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/ThrowHelper.cs) identifies code-size reduction; related runtime/JIT sources explain the inlinable guard and out-of-line throw pattern.

**Scope and acceptance:** Explain the small nonthrowing guard, cold exception path, and potential inlining/code-size benefit, with a link to the rule or runtime rationale. Qualify the claim so it doesn't promise a speedup for every JIT, caller, or throwing path. Don't claim that manual guards allocate on a successful path or that two C# calls imply two machine calls. If the change includes measured or assembly-level results, reproduce them with a named SDK/runtime and configuration rather than invent a benchmark result.

### dotnet/docs#42878: Include structs in the deserialization introduction

**Issue:** [dotnet/docs#42878](https://github.com/dotnet/docs/issues/42878). **Opened:** October 8, 2024. **Size:** Small. **GHCP suitability:** Strong for terminology and a focused supported-type example.

**Why it still applies:** The [deserialization how-to](../docs/standard/serialization/system-text-json/deserialization.md) still describes the target and generic type parameter only as a class. Its linked [constructor guidance](../docs/standard/serialization/system-text-json/immutability.md#parameterized-constructors) already supports structs, but the introduction doesn't make that capability discoverable. Owned .NET 8/.NET 10 tests deserialized both a mutable property-based struct and a readonly struct with `[JsonConstructor]`.

**Scope and acceptance:** Describe the target as an appropriate .NET type, including classes and structs, and add or link a short struct example. Preserve constructor-selection and public-field rules: the unannotated get-only struct in the same fixture used its default initialization rather than its parameterized constructor. Don't promise every struct is supported or rename Visual Studio's literal **Paste JSON as Classes** command. Execute the published C#/VB examples and retain the existing immutable-type cross-link.

### dotnet/docs#42901: Show how work can outlive a returned task

**Issue:** [dotnet/docs#42901](https://github.com/dotnet/docs/issues/42901). **Opened:** October 9, 2024. **Size:** Small. **GHCP suitability:** Strong for a deterministic lease-lifetime example, paired with dotnet/docs#42921.

**Why it still applies:** [Memory usage rule 4](../docs/standard/memory-and-spans/memory-t-usage-guidelines.md) repeats a compliant example but doesn't show the requested violation. An owned .NET 8/.NET 10 fixture returned an already-completed task while a separately tracked continuation retained the memory. After the caller reused the buffer, that continuation read the changed data; returning the actual consuming task preserved the lease.

**Scope and acceptance:** Contrast an explicitly incorrect detached-operation example with a task that covers all memory access. Use synchronization gates, not sleeps or nondeterministic pool reuse, and explain method return versus the advertised task's terminal state. Retain completed, faulted, and canceled outcomes and the existing task-like scope. Don't suggest that statements after an `await` within the same async operation inherently violate the rule. Coordinate snippet/target changes with dotnet/docs#41980 and the synchronous-rule correction rather than create competing edits.

### dotnet/docs#42921: Apply the synchronous memory lease rule beyond void

**Issue:** [dotnet/docs#42921](https://github.com/dotnet/docs/issues/42921). **Opened:** October 9, 2024. **Size:** Small. **GHCP suitability:** Strong as the same article pass as dotnet/docs#42901.

**Why it still applies:** [Rule 3](../docs/standard/memory-and-spans/memory-t-usage-guidelines.md) still limits its heading and summary to `void`. A synchronous method that returns an `int` can retain and misuse the same buffer after return. The owned .NET 8/.NET 10 gated fixture reproduced that counterexample without file I/O or a timing race.

**Scope and acceptance:** State the synchronous-consumer lease independently of a `void` return type and distinguish it from a contract that explicitly transfers ownership or returns an awaitable lifetime. Update both the summary list and detailed explanation; preserve existing fragment destinations if headings change. Use a simple non-void counterexample alongside the task-returning correction, not a new rule that treats every non-void method as asynchronous.

### dotnet/docs#43001: Add a complete ClientWebSocket lifecycle example

**Issue:** [dotnet/docs#43001](https://github.com/dotnet/docs/issues/43001). **Opened:** October 10, 2024. **Size:** Medium. **GHCP suitability:** Suitable for the explicit client-lifecycle checklist, with networking-owner review.

**Why it still applies:** The [WebSocket article](../docs/fundamentals/networking/websockets.md) covers connection options, a single send/receive, and modern keep-alive behavior, but not the requested receive loop, lifecycle notifications, and bounded reconnection. Keep-alive guidance alone doesn't implement those requirements.

**Scope and acceptance:** Add a minimal, awaitable text-client example with connection, complete-message receive, send, close/error notification, cancellation, and an explicitly illustrative bounded retry policy. Reassemble fragmented messages before UTF-8 decoding, respect supported send/receive concurrency, and create a fresh disposed/replaced `ClientWebSocket` for each reconnect. Don't copy the issue's global mutable socket, fire-and-forget connection, `async void` event pattern, or frame-as-message assumption. Verify a controlled local peer with split UTF-8, orderly close, abrupt disconnect, cancellation, and one reconnect. Don't promise automatic application-message replay, exactly-once delivery, or a production-ready universal reconnection framework.

### dotnet/docs#43054: Explain the scope of shared JSON options

**Issue:** [dotnet/docs#43054](https://github.com/dotnet/docs/issues/43054). **Opened:** October 15, 2024. **Size:** Small. **GHCP suitability:** Strong for a scope clarification and centralized-call example.

**Why it still applies:** The [property-customization guide](../docs/standard/serialization/system-text-json/customize-properties.md) and [options-reuse page](../docs/standard/serialization/system-text-json/configure-options.md) don't directly answer whether "global" means every plain serializer call in a project. Owned .NET 8/.NET 10 tests confirmed that a shared explicit naming policy doesn't change calls that omit options, and that `JsonSerializerOptions.Default` rejects mutation.

**Scope and acceptance:** Explain options-instance versus process-wide scope and show a reusable application wrapper or shared serializer context for centralized calls. Cross-link options reuse and distinguish host-managed ASP.NET Core MVC/HTTP JSON configuration from unrelated direct static calls. Don't invent a mutable global defaults setter or imply configuring one web component changes all serialization in the process. Verify default and configured outputs and thread-safe reuse of the frozen options instance.

### dotnet/docs#43058: Distinguish null handling on reads from write-only ignore settings

**Issue:** [dotnet/docs#43058](https://github.com/dotnet/docs/issues/43058). **Opened:** October 15, 2024. **Size:** Small. **GHCP suitability:** Strong for a concrete option-matrix clarification, not a new serializer feature.

**Why it still applies:** The [ignore-properties guide](../docs/standard/serialization/system-text-json/ignore-properties.md) presents write-side settings, while the [migration table](../docs/standard/serialization/system-text-json/migrate-from-newtonsoft.md) lists `NullValueHandling.Ignore` as supported through `DefaultIgnoreCondition` without a read/write qualification. Owned .NET 8/.NET 10 tests showed that `WhenWritingNull` still assigns a JSON null to an initialized reference property. Obsolete `IgnoreNullValues` preserved that reference default, but all tested settings rejected JSON null for a non-nullable integer.

**Scope and acceptance:** Add the read/write distinction at the question's entry point and qualify the migration row. Link the existing non-nullable-value workaround and preserve its warning that a converter's default value can overwrite a property's initializer. Distinguish missing properties, explicit null, nullable references, and non-nullable values. Don't recommend the obsolete option for new code, equate a write-only ignore condition with read-side default preservation, or advertise a single equivalent process-wide null-ignore switch.

### dotnet/docs#43159: Mark the CA1515 fix as potentially breaking

**Issue:** [dotnet/docs#43159](https://github.com/dotnet/docs/issues/43159). **Opened:** October 22, 2024. **Size:** Small. **GHCP suitability:** Strong for rule metadata and a suppression clarification.

**Why it still applies:** [CA1515](../docs/fundamentals/code-analysis/quality-rules/ca1515.md) still labels a public-to-internal change non-breaking. An executable can expose types to another assembly; an owned compiler fixture compiled that consumer with the public type and produced CS0122 after the same executable type became internal. The rule also permits configuration for library output kinds.

**Scope and acceptance:** Mark the fix as breaking and explain why "typically not referenced" isn't a compatibility guarantee. Mention intentional external/test/framework consumers as a reason to preserve the public contract and suppress the recommendation where appropriate. Verify the small two-assembly before/after case without changes to analyzer behavior, default enablement, or a blanket recommendation to replace public APIs with friend-assembly access.

### dotnet/docs#43189: Add Rebus at the requested service-bus comparison

**Issue:** [dotnet/docs#43189](https://github.com/dotnet/docs/issues/43189). **Opened:** October 23, 2024. **Size:** Small. **GHCP suitability:** Strong for a neutral inventory/link correction, coordinated with ebook curation.

**Why it still applies:** The [integration-event article](../docs/architecture/microservices/multi-container-microservice-net-applications/integration-event-based-microservice-communications.md) lists NServiceBus, MassTransit, and Brighter but omits Rebus. The adjacent RabbitMQ article already mentions Rebus in additional resources; that isn't the requested comparison location. The curation draft copies that adjacent resource and still doesn't add Rebus to the comparison.

**Scope and acceptance:** Add a concise, linked Rebus entry alongside the higher-level .NET service-bus examples, using the [official project description](https://github.com/rebus-org/Rebus). Distinguish a service-bus library from its broker/transport and keep the list nonexclusive; don't assert feature parity, universal production suitability, or that eShop uses Rebus. Coordinate the destination with draft dotnet/docs#43185 so the edit reaches retained content rather than a chapter due for removal. No new setup guide or sample dependency is needed.

### dotnet/docs#43202: Explain when dictionary assignment is a different alternative

**Issue:** [dotnet/docs#43202](https://github.com/dotnet/docs/issues/43202). **Opened:** October 25, 2024. **Size:** Small. **GHCP suitability:** Strong for a qualified note, not an analyzer-code-fix change.

**Why it still applies:** [CA1864](../docs/fundamentals/code-analysis/quality-rules/ca1864.md) correctly explains that `TryAdd` preserves an existing value, but doesn't discuss the requested indexer alternative. Owned .NET 8/.NET 10 checks confirmed that `TryAdd` retains `existing` while assignment replaces it with `replacement`.

**Scope and acceptance:** Add the indexer only as an option when overwrite/last-value-wins semantics are intended. Retain `TryAdd` as the behavior-preserving replacement for the shown guarded add, and explicitly warn about the existing-key difference. Check absent and existing keys in both documented languages. Don't advertise assignment as an equivalent automatic refactoring or change the analyzer's non-breaking classification to justify a different operation.

### dotnet/docs#43242: Reconcile disposable-transient guidance with handler ownership

**Issue:** [dotnet/docs#43242](https://github.com/dotnet/docs/issues/43242). **Opened:** October 30, 2024. **Size:** Small to medium. **GHCP suitability:** Strong for an ownership/scope clarification with DI/networking review.

**Why it still applies:** The moved [DI guidelines](../docs/core/extensions/dependency-injection/guidelines.md#general-idisposable-guidelines) still contain a blanket prohibition on disposable transients, while the [HTTP factory guide](../docs/core/extensions/httpclient-factory.md#message-handler-scopes-in-ihttpclientfactory) deliberately uses transient handlers. The latter distinguishes a cached handler's private DI scope from an application scope; "scope-aware" doesn't mean blindly change registration to scoped.

**Scope and acceptance:** Qualify the general warning about container-captured transients, root resolution, and early disposal. Explain factory-owned handler scopes/pooling separately from the transient scope-aware outer-handler workaround, and cross-link the existing recipe. The [factory implementation](https://github.com/dotnet/runtime/blob/v10.0.0/src/libraries/Microsoft.Extensions.Http/src/DefaultHttpClientFactory.cs) owns the handler scope and disposes eligible expired entries; client disposal isn't immediate pooled-handler disposal. An owned .NET 8/.NET 10 fixture reused one transient handler across two distinct application scopes and verified that separation without network traffic. Preserve appropriate lifetime cleanup and sensitive-scope-data warnings; don't promise absence of every leak, reuse a singleton delegating-handler instance, or make all handlers scoped.

### dotnet/docs#43409: Document the time-in-jit EventCounter

**Issue:** [dotnet/docs#43409](https://github.com/dotnet/docs/issues/43409). **Opened:** November 11, 2024. **Size:** Small. **GHCP suitability:** Strong for a source-verified catalog row.

**Why it still applies:** The [available-counters catalog](../docs/core/diagnostics/available-counters.md) omits `System.Runtime`'s `time-in-jit`. Tagged runtime source contains the counter in .NET 6, 7, 8, and 10, but not .NET 5.

**Scope and acceptance:** Add the exact name, display name, first-available version, and incrementing semantics from [RuntimeEventSource](https://github.com/dotnet/runtime/blob/v10.0.0/src/libraries/System.Private.CoreLib/src/System/Diagnostics/Tracing/RuntimeEventSource.cs). It samples cumulative compilation time in milliseconds through `IncrementingPollingCounter`, with a one-second display rate scale. Owned .NET 8/.NET 10 listeners observed `CounterType=Sum`, `DisplayUnits=ms`, and `DisplayRateTimeScale=00:00:01`. Explain interval/rate presentation without relabeling the raw counter as a CPU percentage, substituting a newer Meter instrument, or expanding this row into an unbounded inventory audit.

### dotnet/docs#43566: Add the GCAllocationTick V4 payload

**Issue:** [dotnet/docs#43566](https://github.com/dotnet/docs/issues/43566). **Opened:** November 13, 2024. **Size:** Small. **GHCP suitability:** Strong for a manifest-backed event-table addition.

**Why it still applies:** The [modern runtime GC-event guide](../docs/fundamentals/diagnostics/runtime-garbage-collection-events.md) still documents V3 only. The [runtime manifest](https://github.com/dotnet/runtime/blob/v10.0.0/src/coreclr/vm/ClrEtwAll.man) defines event 10, version 4, with the additional `ObjectSize` field. Bounded owned .NET 8/.NET 10 listeners observed V4 and all nine payload names.

**Scope and acceptance:** Document the V4 event and exact field order/types from the manifest, including `AllocationKind` before `ClrInstanceID`, not the reporter's reversed order. Distinguish interval allocation amounts from the triggering object's size, pointer fields from fixed-width integers, and allocation ticks from a record for every allocation. Preserve historical V3 coverage and add an appropriate modern-runtime signpost from the original Framework page rather than imply all Framework versions emit V4. Use a finite allocation fixture and capture the actual event/payload; don't copy the issue's infinite allocation loop.

### dotnet/docs#43570: Document the httpListener timeouts child

**Issue:** [dotnet/docs#43570](https://github.com/dotnet/docs/issues/43570). **Opened:** November 13, 2024. **Size:** Small. **GHCP suitability:** Strong for a Framework schema completion.

**Why it still applies:** The [httpListener schema page](../docs/framework/configure-apps/file-schema/network/httplistener-element-network-settings.md) says it has no child elements. The [reference implementation](https://github.com/microsoft/referencesource/blob/main/System/net/System/Net/Configuration/HttpListenerElement.cs) explicitly registers `timeouts`, backed by `HttpListenerTimeoutsElement`.

**Scope and acceptance:** Add the child to syntax and the child-element table, with a linked explanation of its five `TimeSpan` attributes and `minSendBytesPerSecond`. Verify names, units, defaults, ranges, and HTTP.sys/platform constraints against [the configuration class](https://github.com/microsoft/referencesource/blob/main/System/net/System/Net/Configuration/HttpListenerTimeoutsElement.cs) and its consumer. Validate a mapped application configuration on supported .NET Framework without changes to machine-wide HTTP settings. Don't assume zero means an immediate timeout or present this Framework configuration mechanism as modern .NET configuration. If a separate schema page is needed, include it in the appropriate index and TOC.

### dotnet/docs#43575: Show polymorphism for nested declared-base contracts

**Issue:** [dotnet/docs#43575](https://github.com/dotnet/docs/issues/43575). **Opened:** November 14, 2024. **Size:** Small to medium. **GHCP suitability:** Strong for a minimal nested example, not an unverified serializer bug fix.

**Why it still applies:** The [polymorphism guide](../docs/standard/serialization/system-text-json/polymorphism.md) explains a root declared-base contract but doesn't show a wrapper with nested polymorphic members. Owned .NET 8/.NET 10 examples emitted discriminators and restored the correct derived types for both a base-typed property and `List<Base>` elements. Serializing the concrete derived contract didn't emit that base contract's discriminator.

**Scope and acceptance:** Add a small complete nested-property/collection example in both languages and explain where the base-type attributes, derived registrations, and discriminators belong. Verify actual JSON and deserialized runtime types, and contrast a relevant declared-contract mismatch. Don't claim nested objects are generally unsupported or that the reporter's unspecified model was reproduced and repaired. Preserve opt-in and unrecognized-type limitations instead of adding a universal runtime-type converter.

### dotnet/docs#43598: Explain the Framework boundary in HttpClient lifetime advice

**Issue:** [dotnet/docs#43598](https://github.com/dotnet/docs/issues/43598). **Opened:** November 16, 2024. **Size:** Small. **GHCP suitability:** Suitable for a compatibility rationale with networking-owner review.

**Why it still applies:** The [recommended-use section](../docs/fundamentals/networking/http/httpclient-guidelines.md#recommended-use) offers a long-lived client with `SocketsHttpHandler.PooledConnectionLifetime` for modern .NET, but only recommends `IHttpClientFactory` for Framework without explaining the different transport/DNS-lifetime mechanism.

**Scope and acceptance:** Explain that the modern pooled-connection-lifetime recipe isn't an API available on Framework, not that singleton clients are prohibited there. Distinguish connection reuse from DNS refresh, retain the factory recommendation, and explain that factory/DI support doesn't require an ASP.NET Core web application. Verify any concrete Framework alternative on supported Framework/handler versions before publication; don't copy `PooledConnectionLifetime` into a Framework sample, recommend per-request unmanaged clients, or advertise a universal DNS timeout. Preserve the existing cookie-container caveat.

### dotnet/docs#43627: Explain GroupBy inputs and grouped results before the example

**Issue:** [dotnet/docs#43627](https://github.com/dotnet/docs/issues/43627). **Opened:** November 18, 2024. **Size:** Small. **GHCP suitability:** Strong for a bounded introductory clarification with C# review.

**Why it still applies:** The [grouping guide](../docs/csharp/linq/standard-query-operators/grouping-data.md) already contains prose and noninteger examples, so replacing all examples isn't necessary. Its opening still doesn't explicitly connect source elements, the key-selector input/output, `IGrouping<TKey,TElement>.Key`, and traversal of each group's elements.

**Scope and acceptance:** Before the parity example, explain the LINQ-to-Objects input and nested result shape and add or adapt a small string-key/object example with visible output. An owned .NET 8/.NET 10 fixture grouped rows into `A=[1,3]; B=[2]`, retaining original elements under each key. Contrast those groups with a flat aggregate projection where useful; don't promise that every SQL/provider query materializes identical grouping objects. Retain the useful existing examples and scope the edit separately from the reporter's Excel/PDF workflow or a complete SQL-to-LINQ textbook.

### dotnet/docs#43705: Limit K and zzz equivalence to date formatting

**Issue:** [dotnet/docs#43705](https://github.com/dotnet/docs/issues/43705). **Opened:** November 22, 2024. **Size:** Small. **GHCP suitability:** Strong; the exact parsing distinction is reproduced.

**Why it still applies:** The [K-specifier section](../docs/standard/base-types/custom-date-and-time-format-strings.md#KSpecifier) describes `DateTimeOffset`'s `K`/`zzz` equivalence without a parsing qualification. Owned .NET 8/.NET 10 checks confirmed equal formatted offsets but different `TryParseExact` results for composite patterns: `K` accepted numeric offset, `Z`, and absent offset; `zzz` accepted only the numeric-offset input.

**Scope and acceptance:** State that the equivalence concerns formatting, then add a concise exact-parsing comparison with explicit culture/styles. Distinguish `DateTimeOffset` from `DateTime.Kind`, keep the single-custom-specifier `%K` rule, and explain the local/default interpretation of an omitted offset rather than imply UTC. Verify both formatting equality and all six parse cases; don't close merely because the existing formatting statement is technically true.

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

### dotnet/docs#32996: Cover the CS0281 public-key mismatch

**Issue:** [dotnet/docs#32996](https://github.com/dotnet/docs/issues/32996). **Opened:** December 13, 2022. **Status:** Covered by open, non-draft [dotnet/docs#56661](https://github.com/dotnet/docs/pull/56661).

**Why the solution is defined:** The actual patch adds the missing public-key diagnostic and project-signing guidance to [CS0281](../docs/csharp/misc/cs0281.md). However, its example still combines a fixed public-key literal with newly generated keys and relies on assembly version/culture changes while claiming to demonstrate a key mismatch. The reporter's granting assembly is unsigned, which the patch's strong-named-grantor-only explanation doesn't cover.

**Maintainer next action:** Correct and execute the existing PR's reproductions rather than assign a duplicate. Demonstrate matching assembly names with missing/wrong consumer keys, derive the attribute's full public key from the actual fixture, and verify the corresponding correction. Preserve the original name-mismatch case separately, distinguish public keys from tokens, and explain applicable signing/toolchain boundaries. Don't change signing policy or remove signing as a universal fix, and don't close before the verified correction merges.

### dotnet/docs#33166: Replace F# release-note pointers with verified documentation

**Issue:** [dotnet/docs#33166](https://github.com/dotnet/docs/issues/33166). **Opened:** December 21, 2022. **Status:** Partially covered by open, draft [dotnet/docs#50098](https://github.com/dotnet/docs/pull/50098); current assignees are `BillWagner` and `Copilot`.

**Why the solution is defined:** [F# 7](../docs/fsharp/whats-new/fsharp-7.md) and [F# 8](../docs/fsharp/whats-new/fsharp-8.md) still contain only announcement links. The [maintainer's latest direction](https://github.com/dotnet/docs/issues/33166#issuecomment-3398616215) explicitly requires documentation for both versions. The current draft adds F# 7 sections and examples, but doesn't address F# 8. Earlier [dotnet/docs#49119](https://github.com/dotnet/docs/pull/49119) closed unmerged and explicitly warns of fabricated content; it isn't completion evidence.

**Maintainer next action:** Review the existing F# 7 draft with its owners rather than duplicate that implementation. Map each feature to the F# 7 announcement/RFC and run examples with the intended language version, including C# interop and expected diagnostics. Review the broad miscellaneous-feature list rather than accept it without source checks. Keep F# 8 as an explicit remaining requirement in a separate version-scoped change, with source mapping, executable examples, and expert review. Don't close the issue after F# 7 alone or merge both release adaptations into one PR.

### dotnet/docs#33488: Offer a text-specific alternative to byte-read loops

**Issue:** [dotnet/docs#33488](https://github.com/dotnet/docs/issues/33488). **Opened:** January 11, 2023. **Status:** Covered by open, non-draft [dotnet/docs#56109](https://github.com/dotnet/docs/pull/56109).

**Why the solution is defined:** The actual patch adds a `StreamReader.ReadToEnd` alternative for text and a separately qualified .NET 7 `ReadExactly` option to the [.NET 6 partial-byte-read compatibility note](../docs/core/compatibility/core-libraries/6.0/partial-byte-reads-in-streams.md). Earlier [dotnet/docs#37752](https://github.com/dotnet/docs/pull/37752) closed unmerged, so it isn't a completed fix.

**Maintainer next action:** Review the existing PR, preserve the byte-loop remedy for binary streams and .NET 6, and verify the text encoding, stream lifetime, and end-of-stream assumptions. Execute the text example and byte-read alternative on their applicable versions. Don't imply that `StreamReader` is a universal binary replacement or that `ReadExactly` existed in .NET 6; don't close before merge.

### dotnet/docs#33546: Improve StartupObject discovery and IDE guidance

**Issue:** [dotnet/docs#33546](https://github.com/dotnet/docs/issues/33546). **Opened:** January 15, 2023. **Status:** Covered by open, non-draft [dotnet/docs#56656](https://github.com/dotnet/docs/pull/56656).

**Why the solution is defined:** The actual patch updates [compiler-option metadata and StartupObject guidance](../docs/csharp/language-reference/compiler-options/advanced.md#startupobject), adds a Visual Studio property-page route, and cross-links the [top-level entry-point restriction](../docs/csharp/fundamentals/program-structure/top-level-statements.md#entry-point-rules). It addresses type-versus-method confusion instead of treating external search ranking as an implementation.

**Maintainer next action:** Verify the UI route for the stated Visual Studio/project version and execute a multiple-entry-point selection plus the top-level-statement restriction. Keep fully qualified type naming and the applicable project boundaries clear. Review the existing PR rather than assign a duplicate, and don't guarantee a particular search-engine result position.

### dotnet/docs#33590: Keep the HTTP tutorial stages and header explanation consistent

**Issue:** [dotnet/docs#33590](https://github.com/dotnet/docs/issues/33590). **Opened:** January 18, 2023. **Status:** Partially covered by open, non-draft [dotnet/docs#56680](https://github.com/dotnet/docs/pull/56680).

**Why the solution is defined:** The [HTTP tutorial](../docs/csharp/tutorials/console-webapiclient.md) retains the reported initial call/signature inconsistency and explanatory gaps. Earlier [dotnet/docs#36896](https://github.com/dotnet/docs/pull/36896) merged but didn't complete every request. The current patch removes the stub's parameter instead of consistently passing the client, and describes the vendor JSON media type as selecting API version 3.

**Maintainer next action:** Correct the existing PR so each instructional stage compiles with matching calls/signatures and the final example still passes its configured `HttpClient`. Distinguish response representation from GitHub REST API version selection; explain both `Accept` and the required `User-Agent` without inventing requirements. Preserve the original `Write`/`WriteLine` output concern and verify the displayed output against the staged/final code. Don't close on the earlier partial merge or assign another parallel implementation.

### dotnet/docs#33722: Keep warning-suppression guidance reusable

**Issue:** [dotnet/docs#33722](https://github.com/dotnet/docs/issues/33722). **Opened:** January 26, 2023. **Status:** Partially covered by open, non-draft [dotnet/docs#56678](https://github.com/dotnet/docs/pull/56678).

**Why the solution is defined:** The actual patch adds local suppression material to [CS0184](../docs/csharp/misc/cs0184.md), but the request and maintainer reply call for reusable generic guidance across compiler-warning pages. Its pragma example also references an undefined `value`. Existing [warning directives](../docs/csharp/language-reference/preprocessor-directives.md#pragma-warning) and [NoWarn guidance](../docs/csharp/language-reference/compiler-options/errors-warnings.md#nowarn) provide shared targets.

**Maintainer next action:** Correct the current example and establish the shared suppression link/content pattern before a bounded, reviewed rollout to applicable warning pages. Preserve existing `NoWarn` entries and restore locally disabled warnings. Don't imply that actual compiler errors can all be suppressed like warnings or duplicate a long generic recipe on hundreds of pages. An owned Roslyn compilation produced one CS0184 without the pragma and none with it; the final published example and project-level form still need their own verification. Don't close the broader request after this one-page patch alone.

### dotnet/docs#37262: Show collection equality limits in the record example

**Issue:** [dotnet/docs#37262](https://github.com/dotnet/docs/issues/37262). **Opened:** September 27, 2023. **Status:** Covered by open, non-draft [dotnet/docs#56667](https://github.com/dotnet/docs/pull/56667).

**Why the solution is defined:** The actual two-file patch expands the [record equality example](../docs/csharp/fundamentals/types/records.md) to compare records that share an array with a record that has a distinct equal-content array. Its proposed source compiled and produced `True`, `False`, and `False` in an owned .NET 10 run.

**Maintainer next action:** Review the existing PR instead of assigning another implementation. Replace `%60` with literal backticks in the API xref, qualify equality claims for the actual collection types rather than every possible collection, and correct the new paragraph that describes all generated record properties as `init`-only: positional record structs are read-write unless `readonly`. Verify that the published snippet regions expose every required declaration and remain consistent with the earlier `Person` examples. Merge only after those corrections; an open patch isn't closure evidence.

### dotnet/docs#37861: Demonstrate COM properties, methods, and events

**Issue:** [dotnet/docs#37861](https://github.com/dotnet/docs/issues/37861). **Opened:** November 2, 2023. **Status:** Covered by open, non-draft [dotnet/docs#56690](https://github.com/dotnet/docs/pull/56690).

**Why the solution is defined:** The actual patch replaces empty interfaces/classes in the [COM class example](../docs/csharp/advanced-topics/interop/example-com-class.md) with a calculator, a property, operations, and event interfaces. Its source compiled in an owned .NET 10 wrapper; managed calls returned `5` and `20`, updated the property, and raised the expected completion/clear events.

**Maintainer next action:** Review the existing PR rather than assign another implementation. Correct the snippet reference's `ExampleCOMClass` casing to match the changed `ExampleComClass` directory on case-sensitive builds. State the intended runtime/COM hosting model and verify native activation, property access, and event subscriptions with its registration/type-library steps. Managed C# event invocation doesn't prove COM connection-point delivery, and the new link to modern COM hosting doesn't replace that evidence.

### dotnet/docs#37987: Explain CS8103 string-heap limits and supported workarounds

**Issue:** [dotnet/docs#37987](https://github.com/dotnet/docs/issues/37987). **Opened:** November 9, 2023. **Status:** Covered by open, non-draft [dotnet/docs#56666](https://github.com/dotnet/docs/pull/56666).

**Why the solution is defined:** The actual patch adds CS8103 to the [string-literal diagnostic article](../docs/csharp/language-reference/compiler-messages/string-literal.md), removes its catch-all F1 entry, and gives resource/assembly-splitting and experimental compiler-feature alternatives. The [compiler feature contract](https://github.com/dotnet/roslyn/blob/main/docs/features/string-literals-data-section.md) documents the flag, threshold, eligible literals, experimental status, and C#-only scope.

**Maintainer next action:** Correct byte/character units and avoid treating source-text size as an exact heap threshold; account for metadata addressing, repeated strings, and overhead. Version the experimental option: the owner identifies SDK 9.0.200/Visual Studio 17.13 availability, and the feature isn't a universal supported fix for every older compiler or VB project. Test a real CS8103 fixture, the resource alternative, flag-enabled execution, and relevant reflection behavior; preserve the distinction from CS9274/CS9315 and verify F1 discovery. Don't close on the open patch or recommend an experimental compiler mode without its restrictions.

### dotnet/docs#38651: Give the programming-concepts landing page useful scope

**Issue:** [dotnet/docs#38651](https://github.com/dotnet/docs/issues/38651). **Opened:** December 7, 2023. **Status:** Covered by open, non-draft [dotnet/docs#56688](https://github.com/dotnet/docs/pull/56688).

**Evidence:** The current landing page principally links variance and iterators, matching the original navigation concern. The actual one-file patch adds a broader map of paradigms and advanced topics and removes the old Framework-performance detour. Its relative article links resolve in the current checkout.

**Maintainer next action:** Review the existing patch with the C# owner rather than assign another rewrite. Confirm that the proposed taxonomy and variance placement satisfy the accepted navigation request; adding a broad index doesn't itself move the variance subtree under generics. Keep descriptions aligned with the linked articles, verify rendered navigation, and avoid implying that links alone supply new conceptual tutorials. Don't close on an open patch or expand this into an unapproved guide-wide reorganization.

### dotnet/docs#38870: Complete version-specific ADO.NET schema guidance

**Issue:** [dotnet/docs#38870](https://github.com/dotnet/docs/issues/38870). **Opened:** December 25, 2023. **Status:** Covered by open, non-draft [dotnet/docs#56247](https://github.com/dotnet/docs/pull/56247).

**Evidence:** [dotnet/docs#54410](https://github.com/dotnet/docs/pull/54410) merged July 29, 2026, adding migration-directory links for existing schema upgrades. The current guide contains those links. The actual remaining patch also points users with missing-required-query setup errors toward migrations; the original reporter specifically identified `CleanupDefunctSiloEntriesKey`. Contributor `adarsh6980` already owns the proposed implementation.

**Maintainer next action:** Complete the existing contribution instead of duplicating it or treating the merged link-only change as proof that every reported setup is fixed. Match scripts to the actual Orleans/provider release, distinguish new installations from upgrades, and verify a clean schema plus an applicable upgrade. Don't instruct readers to execute every migration for every missing-query error. The related merged Orleans SQL Server correction doesn't alone prove the original MySQL path; verify that path and any script ordering explicitly before closure.

### dotnet/docs#40075: Correct the proxy-bypass hostname examples

**Issue:** [dotnet/docs#40075](https://github.com/dotnet/docs/issues/40075). **Opened:** March 19, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56621](https://github.com/dotnet/docs/pull/56621).

**Evidence:** The actual patch changes the hostname class to `[a-zA-Z0-9_-]+` in the [defaultProxy example](../docs/framework/configure-apps/file-schema/network/defaultproxy-element-network-settings.md) and its [bypass-list child reference](../docs/framework/configure-apps/file-schema/network/add-element-for-bypasslist-network-settings.md). An owned .NET Framework `WebProxy` check reproduced the old failure for `www1.contoso.com` and `build-node2.contoso.com`; the proposed pattern bypassed both and rejected `www1.contoso.com.cpandl.com`.

**Maintainer next action:** Finish the existing patch rather than assign another regex edit. Preserve literal backslashes in XML and correct the doubled prose escaping. Qualify "any host" claims: `WebProxy` tests a URI-derived address, and the proposed end-anchored pattern didn't bypass the same hostname on port 8080. Cover the intended hostname/port boundary and suffix negatives with the real Framework API; don't market the character class as a universal DNS validator. Verify the rendered prose and configuration examples before closure.

### dotnet/docs#40168: Make the mutually recursive example visible in the source preview

**Issue:** [dotnet/docs#40168](https://github.com/dotnet/docs/issues/40168). **Opened:** March 21, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56490](https://github.com/dotnet/docs/pull/56490).

**Evidence:** The report points to the GitHub article view, where a DocFX include isn't a normal relative Markdown code link. The actual referenced `snippet4002.fs` exists, and the [published Learn page](https://learn.microsoft.com/dotnet/fsharp/language-reference/functions/recursive-functions-the-rec-keyword) already renders the two mutually recursive functions. The actual PR replaces only that short include with an inline F# block in the [rec reference](../docs/fsharp/language-reference/functions/recursive-functions-the-rec-keyword.md).

**Maintainer next action:** Review the existing two-line source-preview improvement on its actual merits; don't describe it as a missing or uncompiled example on Learn. Verify both the GitHub preview and published output retain `let rec`/`and`. The proposed definitions ran in an owned F# fixture with `Even 4=true` and `Odd 5=true`. Keep the change local rather than migrate the full snippet collection or claim that the open patch has already landed.

### dotnet/docs#40356: Correct the cross-culture millisecond-format example

**Issue:** [dotnet/docs#40356](https://github.com/dotnet/docs/issues/40356). **Opened:** April 8, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56664](https://github.com/dotnet/docs/pull/56664).

**Evidence:** The actual patch replaces the colon-dependent match in both languages of the [millisecond guide](../docs/standard/base-types/how-to-display-milliseconds-in-date-and-time-values.md). Its C# pattern handled compact `HHmmss`, quoted-unit formats, and all 605 installed specific-culture patterns in owned .NET 8/.NET 10 checks. However, the exact proposed VB source compiled and ran but printed the modified full date/time without any milliseconds, even under en-US. The C# pattern also inserted fractional seconds after an escaped literal `\s`, where no seconds token existed.

**Maintainer next action:** Correct the VB regex translation and the escaped/quoted-token boundaries before merge. Check semantic equivalence between the C# raw-string pattern and VB's different string-escaping rules; successful compilation alone didn't prove the fix. Execute both actual language examples for colon-separated, compact, quoted-unit, and escaped-literal formats, and inspect real date output across cultures. Don't claim all custom formats work merely because the installed-culture scan passed, and don't close on the open patch or its stale expected-output comments.

### dotnet/docs#40476: Supply the required query parameter for nested greetings

**Issue:** [dotnet/docs#40476](https://github.com/dotnet/docs/issues/40476). **Opened:** April 13, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56610](https://github.com/dotnet/docs/pull/56610).

**Evidence:** The actual patch adds `/NestedGreeting?nestlevel=5` at the right location in the moved [Prometheus/Grafana/Jaeger walkthrough](../docs/core/diagnostics/observability-prgrja-example.md). The [actual endpoint](../docs/core/diagnostics/snippets/OTel-Prometheus-Grafana-Jaeger/csharp/Program.cs) requires an integer query parameter and recurses until zero. An owned ASP.NET Core harness with that handler returned HTTP 400 without the parameter and, with `?nestlevel=5`, returned all six greeting levels from 5 through 0.

**Maintainer next action:** Complete the existing patch and tie the relative path to the running application's actual HTTP/HTTPS address and port. Preserve the single question mark, the maximum supported level, and the walkthrough's tracing setup. Verify the resulting nested trace in Jaeger before claiming that the pictured visualization was reproduced; the handler check established request binding and recursion, not a full telemetry-stack run. Don't modify the overview instead of the moved walkthrough or create a duplicate assignment.

### dotnet/docs#40769: Update analyzer tutorial entry-point instructions

**Issue:** [dotnet/docs#40769](https://github.com/dotnet/docs/issues/40769). **Opened:** May 6, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56676](https://github.com/dotnet/docs/pull/56676).

**Evidence:** The actual patch adds a top-level-template explanation to the [analyzer/code-fix tutorial](../docs/csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix.md) and updates later local-variable exercises. The initial template analyzer needs an explicit named type; a synthesized top-level entry point doesn't supply the source class declaration the exercise expects. However, the proposed instruction says to *uncheck* **Do not use top-level statements** to obtain an explicit class, reversing the checkbox's meaning.

**Maintainer next action:** Correct the instruction to *check* that box, or retain the explicit `class MyClass { }` alternative. Keep the initial named-type analyzer distinct from the completed local-declaration analyzer: an owned build of the exact current `MakeConstAnalyzer` reported one valid diagnostic for both top-level locals and locals inside `Main`. Verify the initial warning, both later entry-point forms, and the code fix in the experimental Visual Studio instance before merge. Don't introduce an unnecessary claim that the finished analyzer can't process top-level statements or assign a duplicate patch.

### dotnet/docs#41093: Complete the vector-store provider inventory

**Issue:** [dotnet/docs#41093](https://github.com/dotnet/docs/issues/41093). **Opened:** May 28, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56647](https://github.com/dotnet/docs/pull/56647).

**Evidence:** The actual patch adds an engine/package table to the moved [vector-store overview](../docs/ai/vector-stores/overview.md), including OSS choices. It also retains the surrounding claim that every listed package implements `VectorStore`/`VectorStoreCollection`. The [Pgvector packages](https://github.com/pgvector/pgvector-dotnet) instead supply Npgsql/EF Core integration, not those provider implementations. The Cosmos row describes both NoSQL and MongoDB vCore even though the linked [CommunityToolkit package](https://www.nuget.org/packages/CommunityToolkit.VectorData.AzureCosmosDB) identifies itself as the NoSQL provider. Several other entries have only preview/alpha versions in the checked package feed.

**Maintainer next action:** Separate raw database-client/EF integrations from actual abstraction providers, or replace those rows with verified matching connectors. Limit each connector's capabilities to its backend; don't imply that one NoSQL package handles MongoDB vCore. Check current package names, API/abstraction versions, prerelease status, and authoritative engine licenses. In particular, [Redis licensing](https://redis.io/legal/licenses/) differs by version: 7.4 is source-available, while Redis 8 includes an AGPLv3 open-source option. Don't replace the stale blanket classification with another blanket claim, confuse a connector's license with the server's, or treat a mirror's missing package as proof that NuGet.org lacks it. Complete the existing PR rather than create a duplicate inventory assignment.

### dotnet/docs#41390: Replace the empty COM example with a practical class

**Issue:** [dotnet/docs#41390](https://github.com/dotnet/docs/issues/41390). **Opened:** June 11, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56690](https://github.com/dotnet/docs/pull/56690), shared with dotnet/docs#37861.

**Evidence and next action:** The actual calculator/property/method/event patch addresses this practical-example request as well as the earlier [COM demonstration task](#dotnetdocs37861-demonstrate-com-properties-methods-and-events). Keep both issues associated with that one implementation rather than create another assignment or close against an unmerged change. Preserve the earlier review's case-sensitive snippet-path correction and native COM activation/event-delivery checks; a managed-only example execution doesn't prove COM connection points.

### dotnet/docs#41394: Explain byte-array migration without changing the write contract accidentally

**Issue:** [dotnet/docs#41394](https://github.com/dotnet/docs/issues/41394). **Opened:** June 11, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56654](https://github.com/dotnet/docs/pull/56654).

**Evidence:** The actual migration-guide patch correctly distinguishes default Base64 writes from reads: Newtonsoft.Json also accepts numeric byte arrays, whereas System.Text.Json requires Base64 by default. Owned .NET 8/.NET 10 runs with Newtonsoft.Json 13.0.4 confirmed those defaults and the proposed converter's dual-read behavior. Its registered `Write` method instead emits a number array, changing the write contract even when only read compatibility was requested; malformed, out-of-range, fractional, and wrong-token inputs were rejected.

**Maintainer next action:** Preserve Base64 writes unless numeric-array output is an explicit, documented migration requirement. Show converter registration, extract the long example into the required snippet project, update AI-usage metadata for the added section, and verify both accepted formats, invalid inputs, null handling, and output. Don't describe ordinary serialization as different between the two libraries or merge a hidden wire-format change into a read-compatibility recipe.

### dotnet/docs#41401: Demonstrate how code consumes a custom attribute

**Issue:** [dotnet/docs#41401](https://github.com/dotnet/docs/issues/41401). **Opened:** June 12, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56675](https://github.com/dotnet/docs/pull/56675).

**Evidence:** The actual patch adds range metadata to `PlayerAccount.Level` and reads it through reflection. Its exact source ran on .NET 8 and .NET 10 and printed "Property 'Level' must be between 1 and 100." It never constructs an account, reads its value, or performs validation, despite calling the example "read and act."

**Maintainer next action:** Either supply a small explicit consumer that checks values and demonstrates pass/fail behavior, or label the existing example as metadata inspection rather than validation. Explain that the attribute doesn't automatically execute application policy. Correct the encoded generic-method backticks in the new API cross-reference, and keep the distinction between attribute construction when metadata is requested and arbitrary interception/AOP. Complete the existing implementation rather than assign a duplicate example.

### dotnet/docs#41509: Remove the premature AutoML trial-history accessor

**Issue:** [dotnet/docs#41509](https://github.com/dotnet/docs/issues/41509). **Opened:** June 20, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56519](https://github.com/dotnet/docs/pull/56519).

**Evidence:** The actual patch removes the initial monitor's `GetCompletedTrials() => _completedTrials` member. That initial field doesn't exist and isn't required by `IMonitor`; the later optional **Persist trials** section deliberately adds the field, initialization, accessor, and completed-trial collection. With Microsoft.ML.AutoML 0.23.1, the original class produced CS0103 on both .NET 8 and .NET 10, and the patched class compiled and implemented `IMonitor`.

**Maintainer next action:** Merge the focused correction after confirming the initial and later extended monitor remain coherent. Don't add an unused collection to the first example or remove the later persistence feature. Preserve the distinction from unrelated optional-exception handling in the existing sample; the compile error doesn't require a monitor redesign.

### dotnet/docs#41762: Separate syntax-tree iteration from its later transformation

**Issue:** [dotnet/docs#41762](https://github.com/dotnet/docs/issues/41762). **Opened:** July 15, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56652](https://github.com/dotnet/docs/pull/56652).

**Evidence:** The actual patch gives `SnippetIterateTrees` its own nontransforming loop inside `#if false` and retains the active transformation loop outside that region. The exact proposed program and current rewriter compiled and executed against owned source copies, not the repository's files. The iteration region contains setup but no visitor call or file write.

**Maintainer next action:** Verify documentation extraction/rendering as well as compilation: the disabled source region must still render as the iteration-only step, and the next step must show the transformation once. Confirm snippet markers and article progression without an active duplicate loop or preprocessor directives in the displayed snippet. A build alone doesn't prove the disabled region was extracted correctly.

### dotnet/docs#42464: Complete delegate terminology and resolve overlapping guidance

**Issue:** [dotnet/docs#42464](https://github.com/dotnet/docs/issues/42464). **Opened:** September 4, 2024. **Status:** Partially covered by open, non-draft [dotnet/docs#56674](https://github.com/dotnet/docs/pull/56674).

**Evidence:** The actual patch adds terminology and multicast notes to the delegate overview, but doesn't consolidate the overlapping [programming-guide introduction](../docs/csharp/programming-guide/delegates/index.md), [usage article](../docs/csharp/programming-guide/delegates/using-delegates.md), or their separate TOC family. The patch also percent-encodes generic API backticks in `Func`/`Action` xrefs. Owned .NET 8/.NET 10 checks confirmed final-return-value and synchronous-exception behavior; those checks don't establish sequential completion of asynchronous callbacks.

**Maintainer next action:** Finish the original consolidation request or explicitly retain its unresolved scope before close. Correct generic xrefs, include local functions in any precise named-method definition, and avoid implying anonymous methods are deprecated merely because lambdas are usually preferred. Qualify invocation order versus asynchronous completion, especially for `Func<Task>` multicast delegates. Preserve useful existing examples, coordinate any page/TOC/redirect work, add required AI metadata for new sections, and execute the published multicast examples before merge.

### dotnet/docs#42467: Honor JSON-configured Azure Monitor connection strings

**Issue:** [dotnet/docs#42467](https://github.com/dotnet/docs/issues/42467). **Opened:** September 4, 2024. **Status:** Covered by open, non-draft [dotnet/docs#42468](https://github.com/dotnet/docs/pull/42468).

**Evidence:** The [Application Insights walkthrough](../docs/core/diagnostics/observability-applicationinsights.md) recommends `AzureMonitor:ConnectionString` configuration, but its sample gates `UseAzureMonitor()` on the environment-style key alone. The actual patch adds a null-coalescing fallback to the JSON key. An owned configuration matrix on .NET 8/.NET 10 confirmed the missing-key fix, but an empty environment-style value still masks a valid JSON value because `??` doesn't skip empty strings.

**Maintainer next action:** Complete the existing PR with explicit precedence and empty-value handling aligned with the actual Azure Monitor options binding. Check missing, empty, environment-only, JSON-only, and both-key cases, and verify that the selected exporter configuration matches the gate. Don't widen the change into an unrelated distro/package upgrade or claim successful cloud telemetry export from the local configuration-only probe.

### dotnet/docs#42480: Remove the obsolete required/source-generation restriction

**Issue:** [dotnet/docs#42480](https://github.com/dotnet/docs/issues/42480). **Opened:** September 5, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56645](https://github.com/dotnet/docs/pull/56645).

**Evidence:** The [required-properties article](../docs/standard/serialization/system-text-json/required-properties.md) still says C# `required` can't compile with source generation. The actual patch removes that blanket restriction; the issue's other old date/list complaints are already corrected in current content. Owned .NET 8/.NET 10 source-generated metadata and default contexts compiled, marked the required property `IsRequired=True`, and rejected a missing JSON property. A present null value satisfied the presence requirement. Serialization-only contexts successfully wrote JSON with zero deserialization properties, which explains rather than validates the screenshot's contrary inference.

**Maintainer next action:** Merge the focused correction after review of current-versus-historical version wording. Preserve the legitimate differences between `required` and `[JsonRequired]`, presence versus non-nullability, and metadata-capable versus serialization-only source-generation modes. Don't use an empty fast-path property collection to claim source generation generally ignores required members.

### dotnet/docs#42512: Refine the type-selection and static-class guidance

**Issue:** [dotnet/docs#42512](https://github.com/dotnet/docs/issues/42512). **Opened:** September 9, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56655](https://github.com/dotnet/docs/pull/56655).

**Evidence:** The actual patch adds a type-selection matrix and static-class design notes to the [class guide](../docs/csharp/fundamentals/types/classes.md), which already has a static-class section. The [type-system introduction](../docs/csharp/fundamentals/types/index.md) also has a selection list. The patch introduces stronger claims that structs require stack allocation and record structs avoid heap allocation, along with a new 16-byte heuristic that conflicts with the introduction's existing 64-byte heuristic.

**Maintainer next action:** Remove allocation guarantees and reconcile the overlapping guidance; don't treat either size heuristic as a language rule. Distinguish value tuples from `System.Tuple`, record equality from deep immutability, and utility-class advice from a claim that static classes can never maintain state. Retain useful extension-member and testability guidance, but don't imply every external operation requires a new interface. Review the matrix with the language owner before merge; don't create another type-selection assignment.

### dotnet/docs#42727: Finish the interpolated raw-string example and JSON cross-links

**Issue:** [dotnet/docs#42727](https://github.com/dotnet/docs/issues/42727). **Opened:** September 26, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56642](https://github.com/dotnet/docs/pull/56642).

**Evidence:** The actual patch adds an extracted `$$` raw-string JSON example, explains literal versus interpolation braces, and adds both serializer and language-reference links. Its exact proposed source compiled and emitted valid Seattle JSON under `en-US` and `fr-FR` on .NET 8/.NET 10; `FormattableString.Invariant` kept numeric formatting valid.

**Maintainer next action:** Keep the serializer recommendation and clarify that interpolation doesn't escape arbitrary string values for JSON. Verify the snippet region and both rendered cross-links, and add the required AI metadata for the substantive new article content. Don't restore the issue's original missing quotation mark, remove invariant numeric formatting, or present handcrafted interpolation as a replacement for serialization of untrusted data.

### dotnet/docs#42764: Add the concrete FakeTimeProvider testing link

**Issue:** [dotnet/docs#42764](https://github.com/dotnet/docs/issues/42764). **Opened:** September 30, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56624](https://github.com/dotnet/docs/pull/56624).

**Evidence:** The actual patch adds a focused tip to the .NET 8 time-abstraction section with the correct `Microsoft.Extensions.Time.Testing.FakeTimeProvider` API and `Microsoft.Extensions.TimeProvider.Testing` package. The [implementation](https://github.com/dotnet/extensions/blob/main/src/Libraries/Microsoft.Extensions.TimeProvider.Testing/FakeTimeProvider.cs) confirms that the concrete synthetic provider derives from `TimeProvider` and supports deterministic tests.

**Maintainer next action:** Check the API/package links and merge the discoverability correction. Preserve the distinction between the base abstraction that enables substitution and the convenient fake implementation; don't repeat the issue's implication that a custom `TimeProvider` subclass can't support tests.

### dotnet/docs#42831: Add friend-assembly attributes without misleading signing advice

**Issue:** [dotnet/docs#42831](https://github.com/dotnet/docs/issues/42831). **Opened:** October 4, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56644](https://github.com/dotnet/docs/pull/56644).

**Evidence:** The actual patch adds `InternalsVisibleToAttribute` and three signing attributes to the [global-attribute reference](../docs/csharp/language-reference/attributes/global.md), with existing friend-assembly and signing links. It doesn't add every optional attribute suggested in the comment thread.

**Maintainer next action:** State the internal-access boundary precisely; a friend assembly doesn't gain arbitrary private-member access. Check signing-attribute platform/legacy constraints and prefer modern project/compiler settings where appropriate rather than recommend old attributes indiscriminately. Resolve the optional attribute-inventory comments explicitly, retain full-public-key versus token distinctions in linked guidance, and add required AI metadata for the new section. Don't close the original missing-entry request before the reviewed PR lands.

### dotnet/docs#43182: Complete the owner-led ebook curation draft

**Issue:** [dotnet/docs#43182](https://github.com/dotnet/docs/issues/43182). **Opened:** October 23, 2024. **Status:** Covered by open, draft [dotnet/docs#43185](https://github.com/dotnet/docs/pull/43185), coordinated with `IEvangelist` and `jamesmontemagno`.

**Evidence:** The actual 545-file manifest includes 356 removals, 123 additions, 54 renames, and 12 modifications. Relevant patches retire legacy architecture-book content, add the distributed/cloud-native replacement and navigation, and add redirects to downloadable archived books. This is an existing owner-led replacement, not a merged removal or a small unclaimed deletion task.

**Maintainer next action:** Resolve the curation/replacement decision in the draft; validate redirect destinations, retained links/assets, navigation, and publishing results before closure. Coordinate dependent fixes against surviving content and don't create a parallel GHCP book-deletion assignment. The manifest and relevant patches establish the work's scope, not approval of every new architecture claim or a complete review of all 545 files.

### dotnet/docs#43745: Finish the abstract/sealed article's beginner-language pass

**Issue:** [dotnet/docs#43745](https://github.com/dotnet/docs/issues/43745). **Opened:** November 25, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56677](https://github.com/dotnet/docs/pull/56677).

**Evidence:** The actual patch defines base/derived classes and "instantiate," expands the abstract-method explanation, and explains sealed members while retaining existing snippet references. It directly implements the requested less-formal edit pass.

**Maintainer next action:** Complete the existing editorial PR, preserving the distinction between abstract and concrete derived classes. Describe a sealed override as prevention of further overrides, not removal of virtual dispatch from every call; keep devirtualization as an optimization possibility, not a guarantee. Don't assign a duplicate rewrite or claim closure before merge.

### dotnet/docs#43779: Explain lambda parameter modifiers and inferred delegates

**Issue:** [dotnet/docs#43779](https://github.com/dotnet/docs/issues/43779). **Opened:** November 26, 2024. **Status:** Covered by open, non-draft [dotnet/docs#56651](https://github.com/dotnet/docs/pull/56651).

**Evidence:** The actual patch updates the consolidated [lambda-diagnostic guide](../docs/csharp/language-reference/compiler-messages/lambda-expression-errors.md) and explains why an `in` lambda doesn't match `Action<int>`. It offers removal of the modifier, a natural delegate inferred through `var`, or an explicitly declared compatible delegate.

**Maintainer next action:** The installed SDK 10.0.403 compiler reports CS1677 alone for the minimal `Action<int>` mismatch, so don't promise both CS1677 and CS1661 on every compiler. Verify the positive fixes, qualify natural delegate inference by language version, and retain an exact diagnostic resource/message representation rather than invent literal parenthesized message text. Distinguish parameter passing modifiers from generic variance. A custom delegate can express this signature explicitly; don't repeat the reporter's inference that only `var` can express it.

### dotnet/docs#43950: Review modular-monolith coverage in the architecture replacement

**Issue:** [dotnet/docs#43950](https://github.com/dotnet/docs/issues/43950). **Opened:** December 12, 2024. **Status:** Covered in the scope of open, draft [dotnet/docs#43185](https://github.com/dotnet/docs/pull/43185), also tracked for dotnet/docs#43182.

**Evidence:** The actual draft removes the old `common-web-application-architectures.md` and adds a substantive "Modular monoliths" section and diagram in the replacement book's `different-distributed-architectures.md`. The section describes modules, shared-process deployment, and scaling trade-offs. The original author `ardalis` offered to contribute but still requested the docs team's placement approval.

**Maintainer next action:** Decide the replacement/placement with `ardalis` and the curation owners instead of commissioning a competing architecture chapter. Review the draft's blanket claims that modules lack data ownership or that their boundaries matter less: shared process or physical database doesn't by itself preclude logical ownership and enforced module boundaries. Ensure readers of the retired page reach approved replacement guidance, and don't close this issue just because a draft contains the heading.

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

The variance-position illustration, POCO definition, CA1506 suppression choices, and Native AOT feature prominence are additional localized tasks. Keep the UI-culture explanation distinct from omitted-provider fixes. The ambiguous-time correction needs historical and negative-daylight fixtures in both languages; the CRLF parser needs full delimiter/state regressions, not only an index reset.

Coordinate the worker/I/O count clarification with `kouvel`. Arrange the JsonTypeInfo API and Bootstrap signpost work in their owning repositories before assignment. Preserve both custom-transform owners and verify modern factory discovery rather than copy the obsolete registration requirement. Complete the existing DataFrame guide instead of replacing its merged work; coordinate the general ONNX guide with its current owner and verify schema/provider assumptions.

The LINQ roadmap and corrected flexible-type example are additional small changes. Coordinate converter discoverability with the existing Windows Forms task. Arrange the CSharpParseOptions, syntax-walker, and OLS API work in their actual owning repositories; don't assign a docs-only change that can't publish the correction. The duplex pipe sample needs two live endpoints, and Fuslogvw setup needs a verified Windows tool/launch path.

Pair the archived-provider signpost with the LINQ roadmap, and pair the named-pipe presentation issue with its async duplex example rather than create competing rewrites. The native-asset explanation and IdentityServer4 support warning are focused prose/link tasks; don't turn either into an unapproved platform/provider redesign. The CA2254 adapter exception needs structured-state evidence and a narrow suppression, not an architecture-based blanket exemption.

Arrange the shared Azure Bicep include and incremental-generator API work in their owning repositories. The role assignment needs an owned Azure validation, the R2R table needs a real Linux-to-Windows artifact check, and the certificate recipe needs isolated Linux persistence/private-key checks.

The global-using F1 metadata, CQRS forward reference, and placeholder-casing recommendation are small, source-backed changes. Coordinate the F1 lookup with the existing IDE assignee. Pair the missing Toolkit namespace with prerequisite/binding-context checks; don't assume a prefix-only edit makes a current sample runnable.

Route the entry-block and AddSource rendering corrections through Roslyn API documentation; the latter needs rendered-output evidence, not another unmerged compiler patch. Keep the mobile GC change runtime-specific and link maintained platform references. The SDK install, certificate-tool, and dump-introduction tasks need isolated platform validation; the F# overview needs release-by-release factual review rather than unsourced historical reconstruction.

The output-config filename, async semaphore wording, CA1068 exception, and deprecated FlexVolume reference are additional small changes. Pair semaphore edits with the existing platform correction. Keep quota guidance conditional on the actual subscription/region rather than promise compute availability.

Coordinate the two string-marshalling tasks as one coherent update, with actual native execution for new examples. Align the metrics examples and all collection filters together. The JSON simplification needs complete valid fixtures and partial-read regressions; the Enumeration correction needs nullable and equality-contract checks, not warning suppression.

Qualify POH guidance for modern CoreCLR without inventing Framework support. Verify the selected YARP package's platform dependencies before publishing universal claims. The PowerShell correction must stay read-only, and the MAUI test bridge must demonstrate compatible target frameworks and matching constructor dependencies.

The diagram contrast and span-concatenation explanation are additional localized changes. Coordinate the collection example with the compatibility-note owner, and keep the diagnostic navigation hub distinct from an exhaustive new inventory. Pair the pinnability and handle-lifetime clarifications with interop-owner review. The opt-in JSON recipe and observable-metric test need executed, published examples; the Framework project conversion must retain its Framework target. Route the scaffolding parameter edit to EntityFramework.Docs rather than create an ineffective docs-only patch.

The delegate-version and object-initializer explanations are additional localized changes. Coordinate the CA1840, CA1842, and Boolean-enum examples with their existing owner, and pair the MAUI messenger test with the existing test bridge. Keep the callback-marshalling addition ABI-specific and the F# exception examples explicit about execution and cancellation. The output-default table needs separate compiler/SDK evidence; the action-container update needs an actual container run. Confirm the Native AOT signpost's placement with its owners, and route the CodeDom API correction to the publishing repository.

The factory-registration and SQLite-null recipes are additional small, reproducible changes. Keep the stream warning scoped to the unfinished half of the Orleans request, and the custom-logger explanation coordinated with the existing scope work. The provider inventory needs exact EventSource names, not metric names. Preserve the xUnit walkthrough's test sequence; the multiclass warm-start and typed MTP client recipes need complete executable fixtures and their stated schema/metadata boundaries.

Keep the Framework and modern .NET retargeting checklists separate; preserve intentionally historical examples and verify the analyzer tutorial's host/test boundaries. The Azure metrics signpost, MSBuild alias explanation, and one-way analyzer-option tables are additional localized tasks. Coordinate grain-migration details with the Orleans owner, and retain version-specific EF mapping semantics. The non-DI handler recipe needs cancellation/disposal tests, not just a header demonstration.

Pair the two memory-lease issues in one article pass and coordinate with their separate target-framework maintenance task. The mutability definitions, host-shutdown correction, throw-helper rationale, struct-deserialization signpost, JSON option/null distinctions, and CA1515 metadata are additional bounded assignments. The WebSocket lifecycle example needs an actual controlled-peer run and networking review, not only a successful compilation.

Review the forty-two distinct existing implementation PRs separately from new assignments; forty-three issue entries share those PRs. The F# 7 PR remains a draft and only partially covers its issue. Correct the unhandled-exception method name and static-lambda diagnostic IDs, complete the CA2000 two-example verification, refine the CS8032 version advice/tutorial signpost, and verify the CS1574 diagnostics and all three original help routes before merge. Check the packaged-PDB clarification against an isolated consumer, and coordinate it with the existing Source Link task. Complete the HTTPS reference and SOAP-version checks in the WCF PR, and add real conceptual examples to the conversion-operator PR. Measure the async concurrency limit and verify CS1961 help discovery rather than close either implementation early. Verify real CS0281 key fixtures, and preserve the separate F# 8 requirement after the F# 7 source-backed review.

For the newest implementations, qualify the proxy pattern's address/port assumptions, distinguish GitHub source preview from the already-working F# Learn rendering, correct both millisecond patterns with real output checks, and verify the nested-greeting request in the complete tracing walkthrough.

Correct the analyzer tutorial's negatively worded checkbox instruction, and distinguish real vector-abstraction providers from native clients in the existing inventory PR. Verify backend coverage and version-specific package/license claims before merge.

The workload introduction, Iris raw-download correction, arrow-legend correction, and HTTP content table are additional bounded assignments. Coordinate public feature-switch guidance with its current owner, and send the Finalize and generated-code reference changes to their actual API repositories. The native-host lifecycle, private-runtime dump, exemplar, DDD dependency, and identity-selection clarifications need their specified specialist or platform checks.

For the new active entries, keep the two COM issues on one PR, preserve Base64 writes in the byte-array migration recipe unless explicitly changed, and distinguish attribute metadata inspection from real validation. Retain the AutoML monitor's staged optional persistence, and verify documentation extraction for the disabled iteration-only source region.

Keep the new stream-reading alternative text-specific and version-correct. Verify StartupObject's IDE route, correct the HTTP tutorial's staged calls and API-header explanation, and preserve the reusable warning-suppression requirement beyond the CS0184 patch. Issues that don't fit either candidate category are omitted for a future task.
