---
title: Issue closure recommendations
ai-usage: ai-generated
---

# Issue closure recommendations

Recommend closing the following issues because current documentation addresses the request, an authoritative answer resolves the documentation question, the affected sample has been superseded, or another tracked issue covers the same work. These are recommendations only: no issues have been closed, commented on, labeled, or assigned.

## Review coverage

- **Repository and snapshot:** `dotnet/docs`, November 2, 2026; 848 open issues, excluding pull requests.
- **Order:** Issue creation time, oldest first, not most recent activity.
- **Completed batches:** The 550 oldest open issues, from [dotnet/docs#2608](https://github.com/dotnet/docs/issues/2608), opened July 12, 2017, through [dotnet/docs#40543](https://github.com/dotnet/docs/issues/40543), opened April 18, 2024.
- **Results:** 104 closure candidates and 248 [clearly defined fixes](issues-with-defined-fixes.md) (219 assignment candidates and 29 fixes with open implementation PRs).
- **Latest batch:** Issues 526-550, from [dotnet/docs#39852](https://github.com/dotnet/docs/issues/39852) through dotnet/docs#40543: 5 closure candidates, 12 new assignment candidates, and 4 new fixes with open implementation PRs.
- **Remaining:** 298 issues from this snapshot are unreviewed. Of the requested next 300 issues (positions 526-825), 25 are complete and 275 remain. Continue with [dotnet/docs#40556](https://github.com/dotnet/docs/issues/40556), opened April 19, 2024, and stop at position 825. Refresh issue states; don't skip later issues just because their numbers are lower.
- **Evidence:** Issue bodies, complete comment threads, relevant current documentation, and candidate cross-reference timelines. Local source matched upstream `main` at commit `81cd030da804aa06cfbd8f23474cbbacba597c72` during this review. External sources were checked where noted.

Age, inactivity, an out-of-support version, a `won't fix` label, or a stale-bot closure in another repository doesn't establish that an issue no longer applies. Partial coverage alone isn't sufficient either. Issues that don't fit either candidate category are omitted for a future task.

## Closure candidates

### dotnet/docs#2608: Documentation on creating ETW events

**Opened:** July 12, 2017. **Confidence:** High. **Reason:** The requested documentation now exists.

The original request asks for documentation about how applications create their own ETW events, beyond scattered blog posts and API examples. The [EventSource getting-started tutorial](../docs/core/diagnostics/eventsource-getting-started.md#log-an-event) now defines a custom `EventSource`, declares an event, and emits it from an application. The companion [trace collection tutorial](../docs/core/diagnostics/eventsource-collect-and-view-traces.md#perfview) demonstrates ETW collection and inspection with PerfView. The [instrumentation guide](../docs/core/diagnostics/eventsource-instrumentation.md) supplies the broader authoring guidance.

These articles address both event creation and consumption, not just runtime-generated diagnostic events. A [comment on the issue](https://github.com/dotnet/docs/issues/2608#issuecomment-4137511089) independently identifies the same documentation suite. The earlier stale-bot closure and subsequent reopening aren't the basis for this recommendation.

**Suggested closure explanation:** The EventSource documentation now covers custom events, instrumentation, and ETW trace collection. Link to the getting-started and collection tutorials; no documentation change is needed for the original request.

### dotnet/docs#18405: Create a page for how the SDK and Visual Studio work together

**Opened:** May 13, 2020. **Confidence:** High. **Reason:** Existing guidance now covers the requested relationship and SDK selection.

The issue asks which SDK Visual Studio uses when several SDKs or Visual Studio versions are installed, and how `global.json` affects the build. The dedicated [.NET SDK, MSBuild, and Visual Studio versioning article](../docs/core/porting/versioning-sdk-msbuild-vs.md) explains the relationship, the SDK bundled with each Visual Studio installation, separately installed SDKs, compatibility requirements, and the support matrix.

The [global.json overview](../docs/core/tools/global-json.md) now distinguishes the CLI muxer from the MSBuild project SDK resolver, explains their search locations, documents version matching, and describes Visual Studio's prerelease selection behavior. The [version-selection guide](../docs/core/versions/selection.md#the-sdk-uses-the-latest-installed-version) provides the general selection rules and links to `global.json`.

Together, these pages supply the bridge and selection guidance requested by the issue. The original observation that `global.json` was discouraged shouldn't become new guidance: current documentation explicitly supports its use to constrain SDK selection.

**Suggested closure explanation:** The SDK/MSBuild/Visual Studio relationship and `global.json` resolution rules are now documented. Link to the versioning article and `global.json` overview rather than create another overlapping page.

### dotnet/docs#19006: Need for a sample or clarification on how to use PFI with AutoML in ML.NET

**Opened:** June 18, 2020. **Confidence:** High for the current AutoML workflow. **Reason:** A dedicated AutoML example and a discoverability link now exist.

The issue asks how to use permutation feature importance (PFI) with an AutoML model. The current [AutoML guide's Determine feature importance section](../docs/machine-learning/how-to-guides/how-to-use-the-automl-api.md#determine-feature-importance) retrieves the best model, transforms the dataset, calls `PermutationFeatureImportance`, and orders the results. The [PFI article's next steps](../docs/machine-learning/how-to-guides/explain-machine-learning-model-permutation-feature-importance-ml-net.md#next-steps) directly links to that AutoML example, at the location the issue proposed.

The request predates that documented workflow. Don't copy the issue's original cast sequence into current guidance: the discussion itself explains that transformer nesting varies, and the current example uses a different API shape.

**Suggested closure explanation:** Current documentation includes a step-by-step AutoML/PFI example and a link from the PFI guide. Close the general documentation request as addressed; a reproducible failure with a specific legacy model or package version would need a separate, version-specific report. The issue is currently assigned to `luisquintanilla`; retain that context when the maintainer reviews the recommendation.

### dotnet/docs#20590: Tutorial for immutable types

**Opened:** September 11, 2020. **Confidence:** High. **Reason:** The requested feature guidance and practical exploration now exist.

The issue requests updated immutable-type guidance for `init` accessors and an exploration of C# 9 immutable types. The [lightweight immutable-class how-to](../docs/csharp/programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties.md) now lists `init` as an alternative to getter-only properties or private setters. The [`init` reference](../docs/csharp/language-reference/keywords/init.md) explains initialization-only assignment, compares the alternatives, and supplies examples.

The [record tutorial](../docs/csharp/fundamentals/tutorials/records.md) supplies a practical exploration of immutable data models and nondestructive mutation. The [record-type overview](../docs/csharp/fundamentals/types/records.md) explicitly distinguishes the `init`-only properties of record classes and readonly record structs from the mutable defaults of record structs. The coverage has advanced beyond C# 9 without losing the requested concepts.

**Suggested closure explanation:** Immutable-type guidance now includes `init` accessors, and the record tutorial demonstrates immutable models and `with` expressions. Link to those articles; another C# 9-specific tutorial isn't needed. The issue is currently assigned to `BillWagner`.

### dotnet/docs#20935: Add a page for undocumented Visual Basic compiler messages

**Opened:** October 6, 2020. **Confidence:** High. **Reason:** The requested fallback page already exists.

The issue asks for a Visual Basic counterpart to the C# catch-all diagnostic article. [Sorry, we don't have specifics on this Visual Basic error](../docs/visual-basic/misc/sorry-we-don-t-have-specifics-on-this-visual-basic-error.md) provides that counterpart, including extensive `f1_keywords` metadata and advice for readers who reach an undocumented diagnostic.

The issue explicitly excludes automatic F1-keyword generation from its scope. The existence of a separate automation request therefore doesn't keep this page-creation request open. The page's old metadata date isn't the evidence of completion; its actual content and diagnostic metadata are.

**Suggested closure explanation:** The Visual Basic fallback diagnostic page exists and contains F1 mappings. Close this page-creation request as already satisfied. Any specific missing diagnostic mapping or automation work should remain a separate task.

### dotnet/docs#21827: Legacy hosting sample fails with non-ASCII paths

**Opened:** December 4, 2020. **Confidence:** High that the reported sample is superseded; no claim that its historical implementation was fixed.

The [runtime-owner diagnosis](https://github.com/dotnet/docs/issues/21827#issuecomment-767211822) identifies incorrect non-ASCII path handling in the old `HostWithCoreClrHost` sample. The current [hosting tutorial](../docs/core/tutorials/netcore-hosting.md) instead teaches `nethost`/`hostfxr` and links to the replacement [.NET hosting sample](https://github.com/dotnet/samples/tree/main/core/hosting). The old `core/hosting/HostWithCoreClrHost` directory is no longer present in the current `dotnet/samples` tree.

The replacement [sample source](https://github.com/dotnet/samples/blob/main/core/hosting/src/NativeHost/nativehost.cpp) uses `char_t` strings, a Windows `wmain` entry point, and `GetFullPathNameW`, rather than the old CoreCLR delegate workflow. The [local snippet used by the tutorial](../samples/snippets/core/tutorials/netcore-hosting/csharp/HostWithHostFxr/src/NativeHost/nativehost.cpp) uses the same wide-character approach.

**Suggested closure explanation:** The report concerns a retired sample at a historical commit. Current documentation uses the replacement hostfxr sample, so no change to the retired example is needed for the current tutorial. Link to the replacement and request a new reproduction only if that sample fails. Don't claim a successful non-ASCII-path execution test or a fix to the historical sample. The issue is currently assigned to `vitek-karas`.

### dotnet/docs#22075: Conflicting Materialized View guidance

**Opened:** December 17, 2020. **Confidence:** High. **Reason:** The linked architecture guidance no longer contains the reported prohibition.

The issue identifies a direct contradiction: the .NET microservices guide recommends materialized views, while the linked Azure pattern article reportedly says not to use them with microservices. The current [Azure Materialized View pattern article](https://learn.microsoft.com/azure/architecture/patterns/materialized-view#when-to-use-this-pattern) now explicitly says that materialized views can consolidate data from loosely coupled microservices. It distinguishes application-maintained projections from database-native views and discusses refresh strategies, consistency, and operational trade-offs.

The [.NET distributed-data guide](../docs/architecture/microservices/architect-microservice-container-applications/distributed-data-management.md) already compares API aggregation, CQRS/read tables, and reporting stores. It explains the extra development effort and eventual consistency involved in precomputed query data. Together, the two current pages also address the issue's request for context on when to select these approaches.

**Suggested closure explanation:** The Azure pattern article now explicitly supports the applicable microservices scenario and explains the trade-offs. The original contradiction is gone; link to its current guidance and the existing .NET discussion without changing either page.

### dotnet/docs#22155: ETW payload types differ in tracerpt output

**Opened:** December 25, 2020. **Confidence:** High for the documentation answer; no claim that the Windows utility was fixed.

The report compares incorrectly shifted fields in `tracerpt` output with correctly decoded fields from `TdhFormatProperty`. The [runtime-owner reply](https://github.com/dotnet/docs/issues/22155#issuecomment-755026050) confirms that the documented PDB age fields really are `UInt32`, identifies the runtime manifest as the source of truth, and recommends TraceEvent for .NET ETW parsing. The owner treats the Windows utility's output as a separate investigation, not evidence that the documentation should change its field types.

The current [loader-event reference](../docs/framework/performance/loader-etw-events.md#module-events) still correctly lists `ManagedPdbAge` and `NativePdbAge` as `win:UInt32`, the signatures as GUIDs, and the reserved field before the paths.

**Suggested closure explanation:** The documentation question has an authoritative answer: retain the documented types and use the runtime manifest or TraceEvent to interpret the payload. Close this docs issue as answered, without claiming that the separate `tracerpt` decoding problem was resolved.

### dotnet/docs#23379: Exclude modifiers from a naming rule

**Opened:** March 18, 2021. **Confidence:** High. **Reason:** The requested exception mechanism and a worked example are documented.

The issue asks how to apply a private-field convention without applying it to private static readonly fields. The [naming-rule guide](../docs/fundamentals/code-analysis/style-rules/naming-rules.md#example-private-instance-fields-with-underscore) now explicitly explains that symbol groups express required modifiers, not absent modifiers. Its worked example pairs a general private-field rule with a more specific static-field rule whose severity is `none`.

The same guide explains that a symbol must have all the required modifiers and that more specific rules take precedence. Those rules supply the requested static-plus-readonly exception without an invented negative-modifier option. The [original code-style overview](../docs/fundamentals/code-analysis/code-style-rule-options.md) also links to the naming-rule guide, and its configuration example now includes naming rules and symbol groups rather than only naming styles.

**Suggested closure explanation:** Link to the modifier-exception example and rule-order guidance. The example uses an underscore convention, but its two-rule mechanism applies equally to the requested camelCase convention and a static/readonly intersection.

### dotnet/docs#23440: Hosted services in distributed deployments

**Opened:** March 22, 2021. **Confidence:** High. **Reason:** The core documentation gap duplicates an older issue already retained for a defined fix.

Both this issue and [dotnet/docs#19827](https://github.com/dotnet/docs/issues/19827) ask how the same hosted-service article behaves when multiple application replicas run behind a load balancer. The older issue is already retained in [the assignment brief](issues-with-defined-fixes.md#dotnetdocs19827-clarify-hosted-service-behavior-across-replicas), which requires an explicit per-host lifecycle explanation, separates background coordination from HTTP load balancing, and avoids an exactly-once guarantee.

The newer discussion adds useful concerns about the polling example and separate worker deployments. Those comments remain relevant context for the retained issue; they aren't proof that the sample provides distributed coordination.

**Suggested closure explanation:** Close as a duplicate of dotnet/docs#19827 and link to this discussion from the retained work. Don't say the documentation gap is already fixed or silently discard the additional deployment questions. Use one clarification task rather than assign two agents to the same article and explanation.

### dotnet/docs#23449: Missing Visual Basic syntax extension methods

**Opened:** March 23, 2021. **Confidence:** High. **Reason:** The missing entries now appear on the published API page.

The current [AsClauseSyntax extension-method table](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.visualbasic.syntax.asclausesyntax?view=roslyn-dotnet-5.3.0#extension-methods) includes both `Type(AsClauseSyntax)` and `Attributes(AsClauseSyntax)`, which the issue identifies as absent. The live page also links to the Visual Basic `SyntaxExtensions.Type` API. This recommendation follows the published table, not just the presence of XML source or an internal publishing bug.

The [maintainer explanation](https://github.com/dotnet/docs/issues/23449#issuecomment-806070917) also notes that a C# extension on the shared `SyntaxNode` base type can legitimately appear for a Visual Basic-derived node. Its presence alone doesn't prove an incorrect redirect.

**Suggested closure explanation:** The specifically missing Visual Basic extensions are now visible on the type page. Close that publishing-gap report as addressed. Don't claim that every extension link across the entire Roslyn API reference has been audited.

### dotnet/docs#23473: Document experimental IDE rules

**Opened:** March 24, 2021. **Confidence:** High. **Reason:** The requested experimental formatting rules now have published articles and index entries.

The linked Roslyn source identifies the IDE2000-series experimental formatting rules. Merged [dotnet/docs#48011](https://github.com/dotnet/docs/pull/48011) added documentation for IDE2000-IDE2006. The current [style-rule index](../docs/fundamentals/code-analysis/style-rules/index.md) links to all seven articles, and [IDE2000](../docs/fundamentals/code-analysis/style-rules/ide2000.md) explicitly warns that the rule is experimental and subject to change or removal.

The issue's recent comment points to that PR, but the merged state, current rule pages, and current index supply the evidence for closure.

**Suggested closure explanation:** The experimental rules referenced by the request are documented, including their experimental status. Close as addressed by dotnet/docs#48011; don't extend the request to every future experimental diagnostic.

### dotnet/docs#23582: Linux development certificates

**Opened:** April 1, 2021. **Confidence:** High for the general tooling-and-guidance request.

The [.NET development-certificate tool](../docs/core/tools/dotnet-dev-certs.md) documents certificate creation, export, trust, and verification. Its troubleshooting link leads to the current [ASP.NET Core certificate guidance](https://learn.microsoft.com/aspnet/core/security/enforcing-ssl#troubleshoot-certificate-problems-certificate-not-trusted), which now includes Linux-specific trust instructions rather than only Windows and macOS instructions.

That guide describes the community-supported `linux-dev-certs` tool and provides explicit SLES/openSUSE and RHEL workflows for certificate export, browser trust, and OpenSSL clients. It also states where `dotnet dev-certs https --trust` isn't officially supported. The [self-signed certificate overview](../docs/core/additional-tools/self-signed-certificates-guide.md) already introduces the CLI and OpenSSL alternatives.

**Suggested closure explanation:** Linux certificate tooling and documented installation/trust workflows now exist. Link to the relevant platform-specific instructions. Don't promise universal Linux trust support or describe the community tool as Microsoft-supported; a failure on a specific distribution or browser would need a separate reproduction.

### dotnet/docs#23597: Scalar query must select a single field

**Opened:** April 2, 2021. **Confidence:** High for the documentation answer. **Reason:** The owner explains why the existing query is intentional and valid.

The report proposes replacing `SELECT *` with `SELECT value` because the deferred-transaction example calls `ExecuteScalar`. The [data-owner answer](https://github.com/dotnet/docs/issues/23597#issuecomment-812618066) and [follow-up](https://github.com/dotnet/docs/issues/23597#issuecomment-812621481) explain that the API returns the first column of the first row and keeps this transaction example concise. A single-column result set isn't a prerequisite.

The current [transaction guide](../docs/standard/data/sqlite/transactions.md#deferred-transactions) references the [same sample](../samples/snippets/standard/data/sqlite/DeferredTransactionSample/Program.cs), which creates a one-column `data` table before the scalar read. The owner would accept an optional wording/query improvement, but that invitation doesn't establish a remaining correctness bug.

**Suggested closure explanation:** Close as answered: the sample's scalar read is valid and intentional. Selecting the column explicitly would be an optional clarity improvement, not a required fix to transaction behavior.

### dotnet/docs#23703: .NET Standard 2.1 support for UWP and Unity

**Opened:** April 8, 2021. **Confidence:** High. **Reason:** Both previously undecided table entries now have explicit answers.

The current [.NET Standard overview](../docs/standard/net-standard.md#net-implementation-support) uses the [version selector](../includes/net-standard-selector.md). Its [.NET Standard 2.1 table](../includes/net-standard-2.1.md) lists Unity 2021.2 and marks UWP as `N/A`, with a footnote that UWP doesn't support .NET Standard 2.1.

Merged [dotnet/docs#27837](https://github.com/dotnet/docs/pull/27837) addresses the Unity entry. That merge alone wouldn't resolve the last comment about UWP on the separate product website. The current [product page](https://dotnet.microsoft.com/platform/dotnet-standard) now links to the Learn documentation instead of displaying the old support table; its former `TBD` entries aren't the current guidance.

**Suggested closure explanation:** Link to the .NET Standard 2.1 table: Unity support begins with 2021.2, and UWP support is explicitly unavailable. Close the unresolved-table-entry request without implying that UWP gained .NET Standard 2.1 support.

### dotnet/docs#23708: Defaults for custom build configurations

**Opened:** April 8, 2021. **Confidence:** High. **Reason:** The compiler-options guide explicitly documents both requested defaults.

The [DebugType section](../docs/csharp/language-reference/compiler-options/code-generation.md#debugtype) states that `portable` is the default for Debug and Release and that PDB files are generated by default for all configurations. The [Optimize section](../docs/csharp/language-reference/compiler-options/code-generation.md#optimize) states that optimization is enabled for Release and disabled for Debug and any other build configuration.

Those statements answer the original custom-configuration question and the later request to document the PDB default. The presence of both defaults matters; a general Debug/Release comparison alone wouldn't answer the issue.

**Suggested closure explanation:** The current project/compiler-options guidance explicitly covers custom configurations. Link to both sections; don't generalize these MSBuild project defaults to a direct invocation of `csc` without project configuration.

### dotnet/docs#23756: Undeclared AutoML progress handler

**Opened:** April 12, 2021. **Confidence:** High for the reported missing declaration. **Reason:** The current tutorial replaces the obsolete progress-handler workflow and declares its replacement.

The report identifies an undeclared `progressHandler` in an older AutoML experiment example. The current [experiment-monitor section](../docs/machine-learning/how-to-guides/how-to-use-the-automl-api.md#configure-experiment-monitoring) instead supplies an `AutoMLMonitor : IMonitor` implementation, constructs `monitor`, and calls `experiment.SetMonitor(monitor)`. The following example declares a cancellation-token source before it calls `RunAsync`.

The old undeclared handler isn't part of the current article. This recommendation follows the actual replacement instructions, not just the absence of the old variable name.

**Suggested closure explanation:** The current AutoML guide defines and registers its experiment monitor before use. Close the obsolete missing-variable report and link to that section. Don't claim that every sample in the guide was executed or that the historical API example was repaired. The issue is currently assigned to `luisquintanilla`.

### dotnet/docs#24276: Install Windows services with modern .NET

**Opened:** May 18, 2021. **Confidence:** High. **Reason:** Dedicated modern .NET creation and installation guidance now exists.

The [Windows service tutorial](../docs/core/extensions/windows-service.md) teaches a Worker Service rather than the .NET Framework component designer. It covers the Windows Services hosting package, application publication, `sc.exe create`, verification, start/stop commands, and service deletion. Its installation section also links to [the installer tutorial](../docs/core/extensions/windows-service-with-installer.md).

The requested capability isn't limited to the old `InstallUtil.exe` workflow. The original issue suggests PowerShell's `New-Service`, but doesn't require that command instead of the documented Service Control Manager command. The existing [Framework installation page](../docs/framework/windows-services/how-to-install-and-uninstall-services.md) also explicitly scopes its instructions to .NET Framework.

**Suggested closure explanation:** Link to the modern Worker Service tutorial and its installation section. The requested modern .NET workflow is documented; no Framework designer workaround or duplicate installation article is needed.

### dotnet/docs#24559: Migration overview cleanup coordination

**Opened:** June 8, 2021. **Confidence:** Moderate; confirm with the current owner. **Reason:** Follow-up tasks exist, and the original overview-cleanup plan has been superseded.

The issue asks for follow-up issues based on [the proposed migration TOC](https://github.com/dotnet/docs/issues/23215), with instructions to move detailed topics out of the overview. That TOC now links to those follow-up tasks. In particular, [dotnet/docs#25237](https://github.com/dotnet/docs/issues/25237) explicitly requests a guide overview and says the detailed topics belong elsewhere.

The current [upgrade overview](../docs/core/porting/index.md), rewritten in June 2026, describes upgrade decisions, paths, and tools and links to separate Framework migration, dependency, compatibility, and modernization pages. The [current migration TOC](../docs/navigate/migration-guide/toc.yml) also navigates to those separate topics. Reopening the 2021 coordination exercise against the former overview would duplicate planning rather than define a new content fix.

**Suggested closure explanation:** With assignee `StephenBonikowsky`, close this coordination ticket as superseded by the follow-up tasks and the redesigned overview. Don't claim that the entire migration revamp is complete or automatically close its still-open child issues; evaluate those requests separately when their snapshot positions are reached.

### dotnet/docs#24800: Run MSTest in an Azure DevOps pipeline

**Opened:** June 23, 2021. **Confidence:** High for the general pipeline documentation request. **Reason:** Current guidance supplies the requested MSTest/Azure pipeline workflow.

The [MSTest SDK guide's CI section](../docs/core/testing/unit-testing-mstest-sdk.md#update-your-ci) includes an Azure Pipelines `DotNetCoreCLI@2` example and explains the test-report, result-directory, and coverage arguments for that configuration. The [MSTest execution guide](../docs/core/testing/unit-testing-mstest-running-tests.md) distinguishes runner modes and covers CI execution. The authoritative [Azure Pipelines .NET guide](https://learn.microsoft.com/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#run-your-tests) explicitly supports MSTest and provides test-task and test-result publication examples.

The recommendation rests on that concrete coverage, not on .NET Core 3.1 reaching end of support. It doesn't establish that the reporter's historical project has been executed successfully, or that VSTest and Microsoft.Testing.Platform arguments are interchangeable.

**Suggested closure explanation:** Link to the MSTest CI example and Azure Pipelines test guidance. The requested pipeline instructions now exist; a reproducible failure with a particular project or runner configuration would need separate troubleshooting.

### dotnet/docs#24828: Refresh the Model Builder sentiment tutorial

**Opened:** June 24, 2021. **Confidence:** High for the specified content changes. **Reason:** A merged replacement implements the requested tutorial update.

The current [sentiment-analysis Model Builder tutorial](../docs/machine-learning/tutorials/sentiment-analysis-model-builder.md) explicitly creates `SentimentAnalysis.mbconfig`, uses the Model Builder 2.0 scenario image, and no longer contains the Visual Studio 2017 branch. It also describes the generated consumption, training, and model files.

The actual patch in merged [dotnet/docs#32011](https://github.com/dotnet/docs/pull/32011) adds the config-file section, replaces the scenario image reference, and removes the Visual Studio 2017-specific instructions. The older linked [dotnet/docs#25407](https://github.com/dotnet/docs/pull/25407) closed without merge and isn't completion evidence. The recommendation doesn't claim a fresh execution of every current Model Builder UI step.

**Suggested closure explanation:** With assignee `luisquintanilla`, close the specified refresh as addressed by the merged tutorial replacement and current content. Track any newly reproducible UI or training failure separately.

### dotnet/docs#24903: Explain Windows Forms and WPF trimming limitations

**Opened:** June 29, 2021. **Confidence:** High for the requested technical explanation. **Reason:** A dedicated incompatibility guide now explains both frameworks.

The [WPF section](../docs/core/deploying/trimming/incompatibilities.md#wpf) explains the framework's extensive reflection and runtime inspection and why the SDK disables trimming. The [Windows Forms section](../docs/core/deploying/trimming/incompatibilities.md#windows-forms) explains its dependence on built-in COM marshalling and links to the framework's tracking issue. The same guide separately explains why automatic COM marshalling conflicts with trimming analysis.

Both `aka.ms/dotnet-illink/wpf` and `aka.ms/dotnet-illink/windows-forms` still land on [the trimming overview](../docs/core/deploying/trimming/trim-self-contained.md), whose warning links to the detailed incompatibility guide. Don't claim the aliases now target framework-specific anchors. The substantive explanation exists in one shared guide rather than two separate pages.

**Suggested closure explanation:** Link directly to the WPF and Windows Forms explanations. The requested reasons and framework follow-up links are documented; duplicate explanation pages aren't necessary. Any desired change to the external short-link destinations is a separate routing refinement, not a missing technical explanation.

### dotnet/docs#25237: Rewrite the migration-guide overview

**Opened:** July 20, 2021. **Confidence:** High. **Reason:** The redesigned overview follows the requested structure.

The current [upgrade overview](../docs/core/porting/index.md) explains upgrade decisions, support, paths, and tools, then links to separate Framework migration, pre-migration, dependency, compatibility, and modernization guidance. The [migration TOC](../docs/navigate/migration-guide/toc.yml) exposes those dedicated topics rather than require the overview to contain their full instructions.

The issue explicitly requests an overview with detailed topics moved elsewhere. The current content addresses that structural request; another rewrite against the 2021 outline would duplicate the completed redesign.

**Suggested closure explanation:** With assignee `StephenBonikowsky`, close the overview-restructure request as addressed by the current overview and linked topic pages. Don't treat this recommendation as completion of every migration-guide follow-up.

### dotnet/docs#25242: Explain .NET releases and servicing

**Opened:** July 20, 2021. **Confidence:** High. **Reason:** A dedicated release-and-support article now covers the requested subject.

The [.NET releases, patches, and support guide](../docs/core/releases-and-support.md) explains release categories, SDK feature bands, runtime roll-forward, LTS/STS support, monthly servicing, patch requirements, and operating-system support. The [upgrade overview](../docs/core/porting/index.md) directly links to that guide for release dates and patch guidance.

The issue proposes content based on a public release-and-support explanation. Current documentation supplies the substantive guidance and a migration entry point; another article adapted from the older blog isn't needed. This recommendation isn't a claim that every lifecycle date elsewhere in the documentation has been audited.

**Suggested closure explanation:** Link to the existing release-and-support guide and close the overlapping content request as addressed.

### dotnet/docs#25245: Explain the move from Windows-only to cross-platform .NET

**Opened:** July 20, 2021. **Confidence:** High. **Reason:** Connected migration guidance covers platform dependencies and the Compatibility Pack.

The [Framework migration overview](../docs/core/porting/framework-overview.md) explains cross-platform considerations, Windows desktop limitations, native dependencies, compatibility mode, and technologies unavailable in modern .NET. The [Windows Compatibility Pack guide](../docs/core/porting/windows-compat-pack.md) distinguishes Windows-only APIs from cross-platform APIs and explains whether to remove, replace, or guard platform-specific calls with analyzer assistance.

Those pages address the issue's requested separation of .NET from Windows, remaining Windows dependencies, and the role of the Compatibility Pack. Both are part of the current migration navigation. Neither implies that a WPF or Windows Forms application becomes cross-platform merely because it targets modern .NET.

**Suggested closure explanation:** Link to the migration overview and Compatibility Pack guide. The requested platform explanation now exists; no duplicate Windows-to-cross-platform overview is needed.

### dotnet/docs#25249: Introduce project-portability assessment

**Opened:** July 20, 2021. **Confidence:** High for the requested expectations and advance assessment. **Reason:** Current migration guidance covers both purposes.

The issue asks readers to set realistic expectations and analyze a project before they commit to an upgrade. The [Framework migration overview](../docs/core/porting/framework-overview.md) distinguishes relatively straightforward upgrades from app-model changes and identifies desktop, native-library, dependency, and unavailable-technology risks. Its assessment-tool guidance leads to [the upgrade workflow](../docs/core/porting/github-copilot-upgrade/concepts.md#stage-1-assessment), which explicitly analyzes the dependency graph, package compatibility, breaking APIs, test coverage, complexity, and risk before the planning and execution stages.

The [dependency-assessment guide](../docs/core/porting/third-party-deps.md) also supports manual analysis. The recommendation doesn't require the retired portability analyzer or claim that automated assessment guarantees a successful migration.

**Suggested closure explanation:** Link to the existing overview, dependency analysis, and assessment workflow. The requested expectations and analyze-before-upgrade guidance now exist; a second generic assessment overview isn't necessary.

### dotnet/docs#25478: Document backward-compatible library consumption

**Opened:** August 5, 2021. **Confidence:** High. **Reason:** The remaining documentation gap duplicates an older issue already retained for a defined fix.

The issue asks whether a newer-target application can consume a library compiled for an older .NET target and distinguishes that scenario from runtime roll-forward. [dotnet/docs#25018](https://github.com/dotnet/docs/issues/25018) asks the same question. Its [assignment brief](issues-with-defined-fixes.md#dotnetdocs25018-explain-how-newer-applications-consume-older-target-libraries) already requires a direct compatibility explanation, package asset-selection evidence, runtime-selection distinctions, and appropriate dependency/platform caveats.

The newer issue adds explicit support-confirmation context, which the retained brief now preserves. The recommendation doesn't claim that the missing paragraph has already been written or that all cross-version binaries are compatible.

**Suggested closure explanation:** With assignee `StephenBonikowsky`, close as a duplicate of dotnet/docs#25018 and preserve the request for an explicit support statement in that task. Use one documentation change rather than assign two agents to the same compatibility explanation.

### dotnet/docs#25929: Roslyn API page fails with an invalid version moniker

**Opened:** September 2, 2021. **Confidence:** High for the reported URL. **Reason:** The exact invalid-moniker request now falls back to a valid API page.

The discussion retracts an early claim that the problem was fixed: the important case was the literal `view=roslyn-dotnet` query, not simply whether the API existed. A live request to [the reported URL](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.compilation.issymbolaccessiblewithin?view=roslyn-dotnet) now redirects to the `roslyn-dotnet-5.3.0` view with `viewFallbackFrom=roslyn-dotnet`. The response contains the `Compilation.IsSymbolAccessibleWithin` definition, signatures, source metadata, and version choices instead of the reported broken page.

**Suggested closure explanation:** The exact invalid-version URL now resolves through the API browser's version fallback. Close the reported routing failure as addressed. The check doesn't establish that every Roslyn version URL or external search result is correct.

### dotnet/docs#26035: Analyzer template creates an out-of-support .NET Core 2.0 test project

**Opened:** September 10, 2021. **Confidence:** High for the original template defect. **Reason:** The template's target has changed, with a merged product fix and current source evidence.

The final discussion identifies [dotnet/roslyn-sdk#884](https://github.com/dotnet/roslyn-sdk/pull/884). That PR merged on October 29, 2021, and its actual patch changes the diagnostic test template from `netcoreapp2.0` to `netcoreapp3.1`. More importantly, the [current template on the explicit `main` branch](https://github.com/dotnet/roslyn-sdk/blob/main/src/RoslynSdk/VisualStudio.Roslyn.SDK/Roslyn.SDK/ProjectTemplates/CSharp/Diagnostic/Test/Test.csproj) now targets `net8.0`. The [documentation tutorial](../docs/csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix.md) doesn't hardcode the obsolete `netcoreapp2.0` target.

**Suggested closure explanation:** The reported .NET Core 2.0 template target was corrected upstream and isn't present in the current template source. Close the original defect rather than add instructions that preserve that target. The recommendation doesn't claim that previously generated projects or every installed extension version update automatically.

### dotnet/docs#26335: Update ML.NET deployment guides for minimal APIs and Azure Functions v4

**Opened:** October 1, 2021. **Confidence:** High for the original update request. **Reason:** Both explicitly requested deployment changes are present.

The issue's complete scope is the .NET 6-era update to minimal APIs and Azure Functions v4. The [Web API deployment guide](../docs/machine-learning/how-to-guides/serve-model-web-api-ml-net.md) now uses top-level statements, `WebApplication.CreateBuilder`, and `app.MapPost("/predict", predictionHandler)` rather than the old controller/startup workflow. The [Functions deployment guide](../docs/machine-learning/how-to-guides/serve-model-serverless-azure-functions-ml-net.md) links to a [sample project](https://github.com/dotnet/machinelearning-samples/blob/main/samples/csharp/end-to-end-apps/ScalableMLModelOnAzureFunction/SentimentAnalysisFunctionsApp/SentimentAnalysisFunctionsApp.csproj) whose actual project file targets `net6.0` and declares `AzureFunctionsVersion` as `v4`.

**Suggested closure explanation:** With assignee `luisquintanilla`, close the original minimal-API/Functions-v4 conversion request as addressed. The recommendation relies on those concrete changes, not on the age of .NET 6. It doesn't endorse .NET 6 as currently supported or claim that the older in-process Functions sample is a current isolated-worker tutorial.

### dotnet/docs#26349: Update ML.NET API tutorials and remove Visual Studio 2017 instructions

**Opened:** October 1, 2021. **Confidence:** High for the requested version/prerequisite refresh. **Reason:** Current API tutorials use newer prerequisites and project targets.

The issue asks for two changes: remove Visual Studio 2017 instructions and update tutorials to .NET 6. Current API tutorials instead require Visual Studio 2022 or later and create .NET 8 projects. Examples include [sentiment analysis](../docs/machine-learning/tutorials/sentiment-analysis.md), [price prediction](../docs/machine-learning/tutorials/predict-prices.md), [clustering](../docs/machine-learning/tutorials/iris-clustering.md), and [image classification](../docs/machine-learning/tutorials/image-classification-api-transfer-learning.md). The same newer prerequisite/target pattern appears across the regression, recommendation, anomaly, TensorFlow, and ONNX API walkthroughs.

No Visual Studio 2017 instructions remain in the tutorial Markdown searched; occurrences of 2017 in dataset citations aren't IDE prerequisites. Some introductions still mention Visual Studio 2019, but their actual prerequisites/project instructions use Visual Studio 2022 and .NET 8.

**Suggested closure explanation:** With assignee `luisquintanilla`, close the original Visual Studio 2017/.NET 6 refresh request as superseded by the newer tutorial instructions. The recommendation doesn't claim that every external sample was executed or that unrelated tutorial defects are resolved.

### dotnet/docs#26507: Clarify multiline if and match formatting

**Opened:** October 14, 2021. **Confidence:** High. **Reason:** Current guidance includes the layout accepted in the final discussion.

The discussion ultimately favors a newline after `if` or `match` for a long multiline condition/expression, one indentation level for that expression, and aligned `if`/`then` or `match`/`with` keywords. The current [if-expression guidance](../docs/fsharp/style-guide/formatting.md#formatting-if-expressions) states that rule and demonstrates it. The [pattern-matching guidance](../docs/fsharp/style-guide/formatting.md#formatting-pattern-matching) supplies the corresponding `match` example and recommends a separate binding when that improves clarity.

**Suggested closure explanation:** Link to both current formatting sections. They now document the final requested layout; the earlier objections in the discussion don't represent the final position. No new formatting-policy decision is needed for this request.

### dotnet/docs#27116: Make qualification simplification configurable

**Opened:** November 17, 2021. **Confidence:** High for the request to retain qualification. **Reason:** The current rule reference documents how to opt out.

The issue asks to make IDE0002 configurable so that explicit qualification can remain. The [IDE0002 suppression section](../docs/fundamentals/code-analysis/style-rules/ide0002.md#suppress-a-warning) now shows both a local pragma and `dotnet_diagnostic.IDE0002.severity = none` for a file, folder, or project. That configuration preserves the static-type qualification illustrated by the article.

The article still correctly says that the rule has no associated code-style options. Severity configuration isn't a new per-member style preference, and `this`/`base` qualification shouldn't be conflated with every case covered by IDE0002.

**Suggested closure explanation:** Link to the existing opt-out configuration. The requested ability to retain qualification doesn't require a documentation change. A request for a new, finer-grained analyzer preference would need its own explicit product requirements; don't describe such a feature as already implemented.

### dotnet/docs#27217: Explain single-file extraction after .NET 5

**Opened:** November 22, 2021. **Confidence:** High for the general documentation question. **Reason:** Current guidance explicitly distinguishes the extraction modes and cache location.

The [single-file guide's native-libraries section](../docs/core/deploying/single-file/overview.md#native-libraries) distinguishes managed assemblies loaded from the bundle in memory from native libraries embedded with `IncludeNativeLibrariesForSelfExtract`. It also states that `IncludeAllContentForSelfExtract` extracts all files, including managed assemblies. The same section identifies `%TEMP%/.net` as the default Windows extraction location and explains `DOTNET_BUNDLE_EXTRACT_BASE_DIR`.

**Suggested closure explanation:** Answer with the existing explanation and ask the reader to inspect the two extraction properties and the files actually extracted. A .NET 6-or-later target doesn't disable intentional native/content extraction. The recommendation doesn't diagnose the original project's unspecified publish settings or claim that a reproducible extraction bug has been fixed.

### dotnet/docs#27860: Link regex Unicode categories and named blocks

**Opened:** January 15, 2022. **Confidence:** High. **Reason:** The requested quick-reference links and supported-value lists already exist.

The [character-class quick-reference table](../docs/standard/base-types/regular-expression-language-quick-reference.md#character-classes) links both `\p{name}` and `\P{name}` explanations to the detailed character-class article. Its [Unicode category/block section](../docs/standard/base-types/character-classes-in-regular-expressions.md#unicode-category-or-unicode-block-p) links directly to the supported general-category and named-block tables. The latter explicitly includes `IsCyrillic`, the example raised in the issue.

**Suggested closure explanation:** Link to the existing category and block tables. The requested discoverability path now exists; don't introduce POSIX `Alnum` as though it were a supported .NET Unicode category or block name.

### dotnet/docs#27933: Remove the missing Startup.cs step from the ML.NET Web API guide

**Opened:** January 23, 2022. **Confidence:** High. **Reason:** The current walkthrough uses the modern Program.cs application model throughout.

The [Web API deployment guide](../docs/machine-learning/how-to-guides/serve-model-web-api-ml-net.md) now configures `PredictionEnginePool` through `builder.Services` after `WebApplication.CreateBuilder(args)` and maps the prediction endpoint with `app.MapPost`. It no longer directs readers to a nonexistent `Startup.cs` or `ConfigureServices` method. Those concrete changes address the template mismatch, rather than merely replace the prerequisite version.

**Suggested closure explanation:** With assignee `luisquintanilla`, close the original missing-Startup-file report as addressed by the Program.cs/minimal-API walkthrough. No instruction to create a legacy Startup class is needed.

### dotnet/docs#27938: Link API reference pages to implementation source

**Opened:** January 24, 2022. **Confidence:** High for the core-library source-link request. **Reason:** The published reference now includes source links, and the maintainer confirmed the change.

The [maintainer's resolution comment](https://github.com/dotnet/docs/issues/27938#issuecomment-2037771885) states that core-library API pages now link to source. The live [String.Chars reference](https://learn.microsoft.com/dotnet/api/system.string.chars?view=net-8.0), which the discussion uses as an example, exposes **Source** links to `String.cs` at specific GitHub revisions and line ranges. These are implementation-source links, not just links to the API documentation XML.

**Suggested closure explanation:** The core API reference supplies the requested source navigation. Close the documentation-platform request as implemented; don't claim every external or .NET Framework API has a corresponding public implementation link.

### dotnet/docs#28046: Document compiler error CS8112

**Opened:** February 2, 2022. **Confidence:** High. **Reason:** A dedicated diagnostic explanation and help metadata now exist.

The [local-function errors article](../docs/csharp/language-reference/compiler-messages/local-function-errors.md#local-function-bodies) lists CS8112, explains the missing-body condition, and directs readers to add a block/expression body or use a valid `static extern` declaration for an externally supplied implementation. The article also includes CS8112 in its F1/help metadata. The error code is identifiable in the original issue's help URL even though its title is generic.

**Suggested closure explanation:** Link to the CS8112 local-function-body explanation. The missing diagnostic documentation now exists; no new standalone error page is needed.

### dotnet/docs#28331: Clarify whether source-generated logging methods require this

**Opened:** February 21, 2022. **Confidence:** High. **Reason:** The guide explicitly distinguishes ordinary static methods from optional extension methods.

The [current basic-usage section](../docs/core/extensions/logging/source-generation.md#basic-usage) says that a static logging method receives `ILogger` as an argument and that adding `this` makes the method an extension method. Its separate `StaticLog.cs` and `ExtensionLog.cs` snippets match that explanation. Instance methods retrieve the logger from instance state instead.

**Suggested closure explanation:** Link to the existing optional-extension explanation. The other static examples aren't missing a required modifier; don't add `this` to every logger parameter or break the valid example where `ILogger` isn't the first parameter.

### dotnet/docs#28417: Explain compiler error CS8862

**Opened:** February 27, 2022. **Confidence:** High. **Reason:** The constructor reference now documents the diagnostic and its correction.

The [primary-constructor declaration guidance](../docs/csharp/language-reference/compiler-messages/constructor-errors.md#primary-constructor-declaration) includes the CS8862 message and explicitly tells readers to add a `: this(...)` initializer that passes appropriate arguments to the primary constructor. CS8862 also appears in the article's diagnostic inventory and F1/help metadata.

**Suggested closure explanation:** The previously missing explanation now exists in the consolidated constructor-errors article. Link to the constructor-chaining guidance instead of create a duplicate record-constructor error page.

### dotnet/docs#28739: Keep an existing POCO library on .NET Standard

**Opened:** March 20, 2022. **Confidence:** High. **Reason:** The current targeting guidance directly answers the question.

The [.NET Standard article](../docs/standard/net-standard.md) explicitly says existing .NET Standard 2.0 or later code doesn't need a different target framework unless it needs newer language features, runtime capabilities, or APIs. It also explains when to multitarget and why .NET Standard 2.0 remains relevant for .NET Framework compatibility.

That addresses the reported choice for an existing shared library of plain data types; a modern .NET consumer doesn't require that library to abandon .NET Standard. The guidance doesn't promise identical optimization opportunities for every target or recommend .NET Standard 2.1 for consumers that need .NET Framework support.

**Suggested closure explanation:** Link to the current targeting guidance. Choose targets for required consumers and APIs; don't retarget an otherwise compatible POCO library solely because its applications use modern .NET.

### dotnet/docs#28972: Explain how to run the socket server and client

**Opened:** April 10, 2022. **Confidence:** High. **Reason:** The replacement tutorial includes the requested commands and execution order.

The old .NET Framework server page redirects to the [current socket tutorial](../docs/fundamentals/networking/sockets/socket-services.md). Its [Run the sample client and server section](../docs/fundamentals/networking/sockets/socket-services.md#run-the-sample-client-and-server) explicitly starts the server first with `dotnet run --project socket-server`, then starts the client with `dotnet run --project socket-client`, and shows the expected exchange.

The sample's end-of-message marker belongs in the message the client sends, not in an additional command-line argument. The recommendation rests on the actual run instructions, not on the age of the superseded Framework sample.

**Suggested closure explanation:** The replacement tutorial now supplies both commands, their order, and expected output. Link directly to that section; no documentation change is needed for the original run-command question.

### dotnet/docs#29344: Interpret the Framework IDN setting by Uri property

**Opened:** May 10, 2022. **Confidence:** High for the reported inversion. **Reason:** The values aren't reversed; the reported output compares properties with different contracts.

The report's own results show `DnsSafeHost` in Punycode under `All` and unchanged under `None` for a Unicode-input hostname. A separate .NET Framework 4.8 reproduction with two application-local configurations confirmed those results: `All` produced `www.xn--bcher-kva.de` from `DnsSafeHost`, whereas `None` preserved the Unicode input. For that valid international DNS name, `IdnHost` produced the Punycode form under both configurations.

The [Uri property documentation](https://github.com/dotnet/dotnet-api-docs/blob/main/xml/System/Uri.xml) distinguishes configuration-dependent `DnsSafeHost` from configuration-independent `IdnHost`. A Unicode value from `Host`, or a Punycode value from `IdnHost`, doesn't establish that the [Framework configuration table](../docs/framework/configure-apps/file-schema/network/idn-element-uri-settings.md) has its `All` and `None` rows reversed.

**Suggested closure explanation:** Explain which property the setting affects and link to the property contracts. Don't invert the configuration values, infer modern .NET behavior from Framework configuration, or claim that this reproduction verifies every historical default described on the page.

### dotnet/docs#29741: Separate modern reflection guidance from Framework-only material

**Opened:** June 6, 2022. **Confidence:** High. **Reason:** The requested modern reflection section and navigation now exist.

The [reflection overview](../docs/fundamentals/reflection/overview.md) and its fundamentals TOC now provide a dedicated modern .NET section with type inspection, generic types, attributes, how-to guides, and Reflection.Emit. CodeDOM isn't presented as part of that modern overview. The old Framework reflection landing page redirects through the former fundamentals path to the current overview.

**Suggested closure explanation:** Link to the modern reflection section and its navigation. The requested separation no longer needs a new article or TOC move. Don't claim that every ancillary legacy reference throughout the reflection documentation has been removed.

### dotnet/docs#29762: Make library-targeting guidance conditional on consumer needs

**Opened:** June 8, 2022. **Confidence:** High for the original targeting recommendation. **Reason:** The guide now distinguishes modern-only libraries from libraries that need broader reach.

The [cross-platform targeting guide](../docs/standard/library-guidance/cross-platform-targeting.md) now recommends a modern .NET target for new libraries and makes `netstandard2.0` conditional on broader consumer or .NET Framework requirements. It explains the trade-off between modern APIs and platform reach and links to the .NET/.NET Standard comparison. The issue's blanket recommendation to use .NET Standard rather than a modern target no longer appears as the new-library decision.

**Suggested closure explanation:** The current decision guidance addresses the reported confusion; link to it and coordinate closure with assignee `gewarren`. Don't describe every historical multitargeting paragraph as rewritten or imply that .NET Standard is obsolete for all consumers.

### dotnet/docs#29829: Replace the AssemblyLoadContext article's Understanding title

**Opened:** June 14, 2022. **Confidence:** High. **Reason:** The specific title has already changed.

The [AssemblyLoadContext article](../docs/core/dependency-loading/understanding-assemblyloadcontext.md) now has the title **About AssemblyLoadContext - .NET** and the heading **About System.Runtime.Loader.AssemblyLoadContext**. The requested removal of **Understanding** from that title doesn't require a filename change.

**Suggested closure explanation:** Close as addressed by the current title. Preserve the stable URL; don't expand the issue into a site-wide title rewrite.

### dotnet/docs#30043: Add forecasting to the ML.NET algorithm guide

**Opened:** June 29, 2022. **Confidence:** High as a duplicate, not as completed documentation. **Reason:** The retained algorithm-coverage issue can cover the same missing material.

The [algorithm guide](../docs/machine-learning/how-to-choose-an-ml-net-algorithm.md) still lacks the requested forecasting coverage. However, the existing [dotnet/docs#24832 assignment brief](issues-with-defined-fixes.md#dotnetdocs24832-complete-the-mlnet-algorithm-guides-coverage) already requires a comparison against stable trainer and time-series catalogs. That brief now explicitly preserves SSA forecasting and relevant time-series anomaly algorithms, with the existing [forecasting tutorial](../docs/machine-learning/tutorials/time-series-demand-forecasting.md) as a source.

**Suggested closure explanation:** Close as a duplicate of [dotnet/docs#24832](https://github.com/dotnet/docs/issues/24832), not as fixed. Coordinate with `luisquintanilla` on this issue and `jwood803` on the retained issue so the forecasting requirement isn't lost or assigned twice.

### dotnet/docs#30127: Explain HttpClient reuse with per-request state

**Opened:** July 7, 2022. **Confidence:** High for the documentation question. **Reason:** The owner answer and current lifetime guidance cover the requested distinctions.

The [runtime-owner reply](https://github.com/dotnet/docs/issues/30127#issuecomment-1201297314) distinguishes concurrent requests from mutation of shared defaults and directs request-specific headers to each request. The current [HttpClient guidelines](../docs/fundamentals/networking/http/httpclient-guidelines.md) explain handler-owned connection pools, lifetime and ownership, and multiple long-lived clients when separate proxies or cookie containers are necessary.

The guide also warns that factory handler pooling can share cookie containers and discard cookies when handlers expire. That warning matters for the issue's multi-tenant scenarios: a blanket recommendation to share cookies or use a factory wouldn't answer the question safely.

**Suggested closure explanation:** Link to the owner answer and current lifetime/cookie-isolation guidance. Close the general documentation question as answered; don't promise thread safety for concurrent mutation of client defaults or isolation from a shared cookie container.

### dotnet/docs#30255: Missing histogram values in dotnet-counters

**Opened:** July 18, 2022. **Confidence:** Medium. **Reason:** The directly linked tool investigation found and fixed a parsing bug rather than a missing tutorial step.

The discussion in [dotnet/diagnostics#3542](https://github.com/dotnet/diagnostics/issues/3542) explicitly connects the histogram problem to this report and identifies culture-dependent numeric parsing. The actual patch in [dotnet/diagnostics#3558](https://github.com/dotnet/diagnostics/pull/3558), merged December 16, 2022, uses invariant culture for counter, gauge, and histogram-quantile parsing. The current [metrics tutorial](../docs/core/diagnostics/metrics-instrumentation.md) includes histogram recordings, quantile output, and an explanation that observed values vary.

**Suggested closure explanation:** Close as an upstream tool defect with a merged fix, and link to the diagnosis and patch. The evidence doesn't establish the original reporter's exact locale, and this review didn't rerun their environment. If the symptom persists with a current tool, request a versioned reproduction for the diagnostics repository rather than invent a missing histogram command.

### dotnet/docs#30301: Repeat of the AssemblyLoadContext title request

**Opened:** July 21, 2022. **Confidence:** High. **Reason:** The same author's earlier issue tracks the same article and title, which has already changed.

This report repeats [dotnet/docs#29829](https://github.com/dotnet/docs/issues/29829), including the same source article and document identifiers. The [current article](../docs/core/dependency-loading/understanding-assemblyloadcontext.md) uses **About**, not **Understanding**, in its title and heading.

**Suggested closure explanation:** Close as a duplicate of dotnet/docs#29829 and point to the current title. Neither report requires a URL rename or a broader documentation-title policy change.

### dotnet/docs#30639: Document AOT-compatible library analyzer settings

**Opened:** August 12, 2022. **Confidence:** High. **Reason:** The Native AOT overview now documents the requested library configuration.

The [AOT-compatibility analyzers section](../docs/core/deploying/native-aot/index.md#aot-compatibility-analyzers) shows `IsAotCompatible` in a project file and explains its defaults for `IsTrimmable`, `EnableTrimAnalyzer`, `EnableSingleFileAnalyzer`, and `EnableAotAnalyzer`. It also describes supported analysis targets and conditional configuration for multitargeted libraries. The [library trimming guide](../docs/core/deploying/trimming/prepare-libraries-for-trimming.md) links to that section.

**Suggested closure explanation:** Close as documented in the Native AOT deployment section. The original separate-property recipe has a current aggregate configuration and library-specific explanation. Don't confuse AOT-compatible managed libraries with the different task of exporting a native library.

### dotnet/docs#30682: Request code examples for the event-based asynchronous pattern

**Opened:** August 15, 2022. **Confidence:** High for the general example request. **Reason:** The overview already links to concrete C# and VB examples.

The [EAP overview](../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-overview.md) includes a pattern-shaped declaration and directly links to [how to use an EAP component](../docs/standard/asynchronous-programming-patterns/how-to-use-components-that-support-the-event-based-asynchronous-pattern.md). That walkthrough supplies C# and VB code for `PictureBox` completion, error/cancellation handling, and start/cancel buttons. Its related links also provide complete background-operation form walkthroughs.

**Suggested closure explanation:** Answer with the linked component walkthrough rather than add another unspecified example. Distinguish the overview's illustrative declaration from the actual component code, and preserve the examples' Windows Forms context; don't present the declaration alone as a compilable program.

### dotnet/docs#30889: Document Native AOT cross-architecture compilation

**Opened:** August 26, 2022. **Confidence:** High. **Reason:** A dedicated cross-compilation article now explains support and prerequisites.

The [Native AOT cross-compilation guide](../docs/core/deploying/native-aot/cross-compile.md) distinguishes unsupported cross-OS compilation from supported x64/Arm64 cross-architecture scenarios. It describes the Windows, macOS, and Linux toolchain requirements and qualifies its Linux package example rather than guarantee every distribution combination.

**Suggested closure explanation:** Link to the current guide and coordinate closure with assignee `LakshanF`. Don't reinterpret the request as cross-OS support or advise explicit compiler-package references instead of the SDK workflow.

### dotnet/docs#30969: Programmatic access to .NET API documentation

**Opened:** September 1, 2022. **Confidence:** Medium. **Reason:** The discussion provides an authoritative input source for the clarified API-reference question.

After the reporter narrows the request to types and their members, the [maintainer answer](https://github.com/dotnet/docs/issues/30969#issuecomment-1239735719) identifies the reference-pack IntelliSense XML files. The follow-up also points to the public [dotnet/dotnet-api-docs XML source](https://github.com/dotnet/dotnet-api-docs/blob/main/xml/System/Object.xml). That current file contains type/member identifiers, documentation, and assembly-version information that an application can parse.

**Suggested closure explanation:** Close the access question as answered with those XML sources. Don't promise a supported REST endpoint, complete historical coverage from one current file, or a versioned export of every conceptual article. The answer supplies a data source, not a new hosted API.

### dotnet/docs#31175: Refresh library-targeting recommendations

**Opened:** September 14, 2022. **Confidence:** High for the reported outdated starting point. **Reason:** The targeting decision and examples have been refreshed.

The [current targeting guide](../docs/standard/library-guidance/cross-platform-targeting.md) now starts new libraries at `net8.0` or later, makes `netstandard2.0` conditional on broad compatibility or .NET Framework consumers, and distinguishes modern API goals from breadth targeting. Its multitargeting example uses `net8.0` and .NET Standard, explains NuGet's best-match/fallback selection, and discourages redundant outputs when the stated code/dependency conditions don't justify them.

**Suggested closure explanation:** Link to the current decision guidance rather than prescribe the issue's historical `net5.0`/`net6.0` target set. No universal target list fits every library; choose consumers and required APIs first. This recommendation doesn't certify every historical paragraph or make .NET Standard mandatory for modern-only libraries.

### dotnet/docs#31295: Constructor setup versus helpers and xUnit fixtures

**Opened:** September 20, 2022. **Confidence:** Medium. **Reason:** The owner explanation and xUnit's documented lifetimes answer the question without a new general prohibition.

The [article author's reply](https://github.com/dotnet/docs/issues/31295#issuecomment-1252281013) explains the readability preference for visible Arrange steps and helper methods. The reporter's follow-up about fixtures is answered by [xUnit's shared-context documentation](https://xunit.net/docs/shared-context): constructor setup creates fresh context for each test, while class and collection fixtures intentionally share instances over their respective scopes.

**Suggested closure explanation:** Explain the distinction between common setup code and shared object state. Use helpers when they clarify each test's Arrange step; use the appropriate fixture scope when shared context is intentional. Constructor setup isn't inherently invalid, and a fixture recommendation must account for isolation, cleanup, and concurrency rather than treat a readability preference as a framework rule.

### dotnet/docs#31760: Add a Framework HTTP migration guide

**Opened:** October 13, 2022. **Confidence:** High for the requested HTTP migration documentation. **Reason:** The dedicated migration guide now exists.

The [HttpWebRequest-to-HttpClient migration guide](../docs/fundamentals/networking/http/httpclient-migrate-from-httpwebrequest.md) explicitly addresses .NET Framework migration. It supplies GET/POST comparisons, `HttpWebRequest`/handler property mappings, `ServicePointManager` and `ServicePoint` mappings, and notes for missing equivalents, headers, TLS, connection lifetime, and buffering.

**Suggested closure explanation:** Link to the dedicated migration guide rather than only the generic HttpClient overview. Close the request for that guide; a release-specific mapping error or an additional concrete networking scenario would require its own correction rather than establish that the migration article is still absent.

### dotnet/docs#31798: Include the containing class in IDE0002 examples

**Opened:** October 16, 2022. **Confidence:** High. **Reason:** Both language examples now include the requested context.

The [IDE0002 page](../docs/fundamentals/code-analysis/style-rules/ide0002.md) now wraps the C# methods in `class C`. Its VB example also includes `Public Class C`. The qualified and simplified calls visibly refer to members of that class.

**Suggested closure explanation:** Close as addressed in both examples. No further wrapper or language-specific rewrite is needed for the original request.

### dotnet/docs#32983: Match the MAUI app and unit-test target frameworks

**Opened:** December 11, 2022. **Confidence:** High for the original target-framework mismatch. **Reason:** The sample now supplies a matching platform-neutral target.

The [current chapter](../docs/architecture/maui/unit-testing.md) uses MSTest rather than the reported .NET 7 xUnit setup. In the linked sample, [ClientApp.csproj](https://github.com/dotnet/eShop/blob/main/src/ClientApp/ClientApp.csproj) includes `net10.0` alongside its platform-specific targets and omits executable output for that neutral target. [ClientApp.UnitTests.csproj](https://github.com/dotnet/eShop/blob/main/tests/ClientApp.UnitTests/ClientApp.UnitTests.csproj) targets the same `net10.0` and references the app.

The [maintainer's earlier confirmation](https://github.com/dotnet/docs/issues/32983#issuecomment-2138587623) independently reports successful tests after the .NET 8 update. Current source verifies that the neutral-target mechanism remains; this review didn't run the MAUI test suite or certify every dependency.

**Suggested closure explanation:** The sample no longer asks a neutral test project to reference only platform-specific app targets. Link the matching project files and updated chapter. Close the original framework-compatibility report without claiming every MAUI UI API works in a platform-neutral unit test.

### dotnet/docs#33121: Interpret the TensorFlow CPU-feature message

**Opened:** December 20, 2022. **Confidence:** High for the quoted message. **Reason:** The reported output is informational, not an exception or an instruction required to run the tutorial.

The issue quotes `cpu_feature_guard.cc:193` and the oneDNN/AVX2 optimization message. [TensorFlow v2.10.0 source](https://github.com/tensorflow/tensorflow/blob/v2.10.0/tensorflow/core/platform/cpu_feature_guard.cc#L192-L198) emits that exact text with `LOG(INFO)`. The optional rebuild concerns use of CPU instructions in additional operations; the message doesn't establish that model training failed.

**Suggested closure explanation:** Explain the informational severity and distinguish optional native optimization from a runtime failure. No tutorial change or TensorFlow rebuild is needed solely for this output. A separate exception, termination, or failed result would require its own evidence; this recommendation doesn't claim that the reporter's entire training run succeeded.

### dotnet/docs#33307: Locate the .NET Framework 3.5 offline installer

**Opened:** January 4, 2023. **Confidence:** High for the reported missing download. **Reason:** The current download page explicitly exposes an offline-installer link.

The [live .NET Framework 3.5 SP1 download page](https://dotnet.microsoft.com/download/dotnet-framework/net35-sp1) now has separate **Offline installer** and **Web installer** links; the former targets `net35-sp1-offline-installer`. The issue's [product-owner answer](https://github.com/dotnet/docs/issues/33307#issuecomment-1762213326) also explains the historical misleading label. The [installation article](../docs/framework/install/dotnet-35-windows.md#download-the-offline-installer) distinguishes the legacy executable from the installation-media mechanism for Windows 10 and Windows Server 2016 onward, with additional Windows 11 qualifications.

**Suggested closure explanation:** Link the explicitly labeled offline download and the OS-specific instructions. Close the missing-link report without recommending the legacy SP1 executable for every Windows version. The page and link were inspected; the installer wasn't downloaded or executed. Don't treat the still-open historical website naming reports as evidence that the current offline link is absent.

### dotnet/docs#33320: Avoid the obsolete integer-confidence overload

**Opened:** January 4, 2023. **Confidence:** High. **Reason:** Both published anomaly-detection snippets already select the double overload.

The [sales anomaly tutorial](../docs/machine-learning/tutorials/sales-anomaly-detection.md) includes `SnippetAddSpikeTrainer` and `SnippetAddChangePointTrainer` from its [current Program.cs](../docs/machine-learning/tutorials/snippets/sales-anomaly-detection/csharp/Program.cs). Both calls now pass `confidence: 95d`, not the reported integer literal. The double suffix addresses the exact obsolete-overload selection without changing the confidence value.

**Suggested closure explanation:** Close as corrected in both the spike and change-point examples. No further overload change is needed for the original report; this source check doesn't claim a complete training run against every ML.NET version.

### dotnet/docs#33324: Distinguish single-file, ReadyToRun, and Native AOT deployment

**Opened:** January 4, 2023. **Confidence:** High for the requested conceptual distinction. **Reason:** Current guidance explains the separate deployment dimensions and their principal relationship.

The [publishing overview](../docs/core/deploying/index.md) now gives single-file, Native AOT, and ReadyToRun separate explanations and commands. The [single-file guide](../docs/core/deploying/single-file/overview.md) explicitly permits ReadyToRun in a bundled app. The [ReadyToRun guide](../docs/core/deploying/ready-to-run.md) explains mixed IL/native code and continued JIT use, while the [Native AOT guide](../docs/core/deploying/native-aot/index.md) explains publish-time compilation, no JIT, self-contained deployment, and its restrictions.

**Suggested closure explanation:** Link the existing explanations: bundling, partial ahead-of-time compilation, and Native AOT aren't interchangeable names. Close the original distinction request, not a claim that every MSBuild property combination is supported. Runtime-install independence doesn't mean the executable contains no runtime services or has no native dependencies.

### dotnet/docs#33406: Explain Native AOT targets and cross-compilation

**Opened:** January 10, 2023. **Confidence:** High for the missing-guidance request. **Reason:** Dedicated target and host/target guidance now exists.

The [Native AOT overview's platform restrictions](../docs/core/deploying/native-aot/index.md#platformarchitecture-restrictions) supply a release-specific target matrix. The [cross-compilation guide](../docs/core/deploying/native-aot/cross-compile.md) distinguishes cross-architecture from unsupported cross-OS compilation, explains native-toolchain/sysroot requirements, and links container recipes. The [runtime's .NET 9 compilation guide](https://github.com/dotnet/runtime/blob/v9.0.0/src/coreclr/nativeaot/docs/compiling.md#cross-architecture-compilation) independently describes supported host/target arrangements.

**Suggested closure explanation:** Point to the target matrix and dedicated cross-compilation guide rather than leave the original absence-of-guidance question open. Apply the matrix for the selected release; don't project later targets onto .NET 7, promise arbitrary cross-OS builds, or infer QEMU support from a container recipe. Retain current assignee `LakshanF` when the owner reviews closure.

### dotnet/docs#33412: Retire the obsolete AppVeyor fixture reference

**Opened:** January 10, 2023. **Confidence:** High for the specific linked fixture. **Reason:** The article no longer directs readers to the obsolete `appveyor.yml`.

The [continuous-integration article](../docs/devops/dotnet-cli-and-continuous-integration.md) no longer links an `appveyor.yml` or teaches the reported Visual Studio 2015/.NET Core 1.0 fixture. Its AppVeyor section instead describes the service configuration and a Visual Studio 2022 image. The former `dotnet/samples` root `.appveyor.yml` isn't present.

**Suggested closure explanation:** Close the obsolete linked-file report because the current instructions no longer depend on that fixture. Don't claim that every CI example is current: the remaining .NET 6 material is a separate modernization concern. Coordinate closure with current assignee `gewarren`.

### dotnet/docs#33509: Explain whether unused imports can be removed

**Opened:** January 12, 2023. **Confidence:** High. **Reason:** Existing guidance directly answers the question.

The [IDE0005 reference](../docs/fundamentals/code-analysis/style-rules/ide0005.md) explicitly states that unnecessary imports can be removed without changing code semantics and provides before/after examples. The question doesn't identify a missing compiler behavior, a failing sample, or another unresolved documentation requirement.

**Suggested closure explanation:** Link IDE0005 and explain that unused `using` directives can be removed. Don't claim a runtime performance benefit or advise removal of imports that the compiler or tooling still needs.

### dotnet/docs#33600: Distinguish the execution host from a web app's consumers

**Opened:** January 18, 2023. **Confidence:** High for the reported runtime-install ambiguity. **Reason:** Current text explicitly scopes the requirement to the environment that executes the app.

The [publishing overview](../docs/core/deploying/index.md) describes servers, containers, and cloud deployment and consistently places the framework-dependent runtime prerequisite on the environment that runs the app. It contrasts that host requirement with self-contained deployment. A browser or HTTP API caller doesn't execute the server application.

**Suggested closure explanation:** Close the original consumer-versus-host wording report as addressed. Link the framework-dependent/self-contained explanation; don't tell remote web/API users to install .NET, or confuse modern .NET publishing with .NET Framework installation.

### dotnet/docs#33841: Route the Apple authentication key change to its provider

**Opened:** February 2, 2023. **Confidence:** High for ownership. **Reason:** The changed contract belongs to a community authentication package, not the .NET 6 runtime API.

The named option and generator belong to `AspNet.Security.OAuth.Apple` in `aspnet-contrib/AspNet.Security.OAuth.Providers`. The provider's [5.0.0 generator](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/blob/5.0.0/src/AspNet.Security.OAuth.Apple/Internal/DefaultAppleClientSecretGenerator.cs) imports decoded bytes with `ImportPkcs8PrivateKey`; its [6.0.0 generator](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/blob/6.0.0/src/AspNet.Security.OAuth.Apple/Internal/DefaultAppleClientSecretGenerator.cs) imports the option's PEM text with `ImportFromPem`. The [existing provider discussion](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/issues/385#issuecomment-1056507578) identifies the changed PEM-envelope expectation.

**Suggested closure explanation:** Close here as a provider-package migration concern and direct any missing provider release note to its maintainers. Don't add the change to the .NET runtime breaking-change catalog or claim that the closed upstream thread proves the provider's migration documentation is complete. Don't publish the reporter's ad hoc secret-normalization code as a framework workaround.

### dotnet/docs#34173: Clarify which part of dependency injection becomes immutable

**Opened:** February 19, 2023. **Confidence:** High for the reported sentence. **Reason:** The ambiguous subject has been corrected.

The [MAUI dependency-injection chapter](../docs/architecture/maui/dependency-injection.md#registration) now says that the dependency injection **container** becomes immutable after `Build` and immediately tells readers to register all required services first. It no longer says the registered services themselves become immutable. The [author's answer](https://github.com/dotnet/docs/issues/34173#issuecomment-1487820533) independently distinguishes registrations from the mutable state a service object can expose.

**Suggested closure explanation:** Close the original wording report as addressed. The registration/container configuration is fixed after the build; that statement doesn't make service instances or their data immutable.

### dotnet/docs#34709: Apply method casing to private methods

**Opened:** March 23, 2023. **Confidence:** High. **Reason:** The C# naming guide now explicitly covers all methods.

The [identifier-naming guide](../docs/csharp/fundamentals/coding-style/identifier-names.md#pascal-case) says to use Pascal casing for **all methods and local functions**, separately from its public-member guidance. Its introduction identifies the runtime/docs-team convention and distinguishes conventions from compiler-enforced rules. The older [framework design guideline](../docs/standard/design-guidelines/capitalization-conventions.md) concerns public API design and isn't the only naming reference.

**Suggested closure explanation:** Link the explicit all-methods rule, which includes private methods. Don't turn a recommended team convention into a C# language requirement or rewrite the public-API guideline to imply it dictates every project's private implementation style.

### dotnet/docs#34817: Distinguish an optional binding name from authentication configuration

**Opened:** March 29, 2023. **Confidence:** High for the optional-name contract, not the reporter's HTTP 401 cause. **Reason:** Unnamed bindings are supported and documented.

The [`basicHttpBinding` reference](../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md) explicitly states that a name isn't required from .NET Framework 4 onward and provides the equivalent unnamed/default configuration. The [simplified-configuration guide](../docs/framework/wcf/simplified-configuration.md) explains how an endpoint selects that default.

An owned .NET Framework 4.x configuration probe loaded an unnamed `basicHttpBinding` into a `ChannelFactory` and observed the configured `TransportCredentialOnly` mode and `Basic` credentials. No service request was sent, so the result doesn't diagnose the reported 401 or prove server interoperability.

**Suggested closure explanation:** Keep the correct optional-name documentation. Explain default binding selection versus an explicitly named `bindingConfiguration`; request a concrete endpoint/security configuration only if the authentication problem persists. Don't make `name` universally required as a workaround for an unisolated 401.

### dotnet/docs#34826: Resolve the specific TensorFlow native-entry-point mismatch

**Opened:** March 30, 2023. **Confidence:** High for the reported legacy mismatch. **Reason:** The reporter supplies the successful remedy, and the remaining compatibility task already has an owner-backed tracker.

The issue says that the matching `SciSharp.TensorFlow.Redist` 2.3.1 resolved `TF_StringDecode`. The cited [dotnet/machinelearning#6040](https://github.com/dotnet/machinelearning/issues/6040) contains the same confirmed result and an [owner reply](https://github.com/dotnet/machinelearning/issues/6040#issuecomment-1015723147) that explicitly tracks central dependency documentation in [dotnet/docs#27878](https://github.com/dotnet/docs/issues/27878). The [tutorial](../docs/machine-learning/tutorials/image-classification-api-transfer-learning.md) also names that historical package version.

**Suggested closure explanation:** Close the resolved entry-point report and retain release-matched managed/native compatibility guidance under the existing [defined-fix brief](issues-with-defined-fixes.md#dotnetdocs27878-document-tensorflow-native-redistributable-requirements). Don't universally prescribe 2.3.1 for current ML.NET releases, treat arbitrary native upgrades as compatible, or claim that the central documentation task is already complete.

### dotnet/docs#34992: Explain the converter collection initializer

**Opened:** April 12, 2023. **Confidence:** High for the quoted C# pattern. **Reason:** The initializer populates a fresh collection; it doesn't assign the get-only property.

The [converter guide](../docs/standard/serialization/system-text-json/converters-how-to.md) uses a nested collection initializer for `JsonSerializerOptions.Converters`. An owned run with the actual [DateTimeOffset converter](../docs/standard/serialization/system-text-json/snippets/how-to/csharp/DateTimeOffsetConverter.cs) compiled that pattern, registered one converter, and serialized the test value as `"01/02/2023"`. After serialization, an attempted collection addition correctly threw `InvalidOperationException`.

The get-only property and the collection's later read-only state are different constraints. The [maintainer reply](https://github.com/dotnet/docs/issues/34992#issuecomment-1562096432) points to the latter, but doesn't establish that the quoted fresh initializer is invalid.

**Suggested closure explanation:** Explain nested collection initialization versus property assignment and options freezing after use. Close the claim that the shown pattern is inherently broken. A failing variant needs its exact language, complete code, diagnostic, and reuse sequence; don't replace the valid initializer merely because the property has no setter. Coordinate with current assignee `gewarren`.

### dotnet/docs#35008: Match the e-book download to its advertised edition

**Opened:** April 14, 2023. **Confidence:** High for the edition mismatch. **Reason:** The actual PDF, not only its landing page, is now edition 8.

The [book introduction](../docs/architecture/modern-web-apps-azure/index.md) and [eShopOnWeb README](https://github.com/dotnet-architecture/eShopOnWeb) now advertise ASP.NET Core 8. The `aka.ms/webappebook` route leads to a download page whose PDF link targets the [current book asset](https://github.com/dotnet-architecture/eBooks/blob/main/current/architecting-modern-web-apps-azure/Architecting-Modern-Web-Applications-with-ASP.NET-Core-and-Azure.pdf). The downloaded PDF's opening edition statement and version section both identify edition 8.0/ASP.NET Core 8.0.

**Suggested closure explanation:** Close the reported edition-7 link serving edition-6 content as superseded by a verified matching edition-8 download. Repository archival or the HTML edition label alone isn't the evidence. Don't imply that this check validates every chapter or makes the historical book the preferred current architecture guide.

### dotnet/docs#35017: Mention LoggerMessageAttribute in CA1848 guidance

**Opened:** April 15, 2023. **Confidence:** High. **Reason:** The requested attribute guidance and example already exist.

The [CA1848 reference](../docs/fundamentals/code-analysis/quality-rules/ca1848.md#how-to-fix-violations) now explicitly recommends `LoggerMessageAttribute`, provides an attributed partial-method correction, retains `LoggerMessage` for older versions, and links [compile-time logging source generation](../docs/core/extensions/logging/source-generation.md).

**Suggested closure explanation:** Close as addressed in the rule's fix instructions, sample, and related links. No additional attribute introduction is needed for the original request; retain the version and language applicability of source generation rather than infer universal generator support from the rule's language list.

### dotnet/docs#35117: Verify MVVM Toolkit content in the downloadable MAUI book

**Opened:** April 24, 2023. **Confidence:** High for the specified missing content. **Reason:** The actual PDF now includes the toolkit material.

The [MAUI book](../docs/architecture/maui/index.md) and its live download route now supply edition 2.0. The downloaded [PDF asset](https://github.com/dotnet-architecture/eBooks/blob/main/current/maui/Enterprise-Application-Patterns-Using-.NET-MAUI.pdf) contains the MVVM Toolkit Features chapter, substantive `ObservableObject` and `RelayCommand`/`AsyncRelayCommand` sections, and toolkit messenger coverage. Those sections occur in the body, not only the table of contents.

**Suggested closure explanation:** Close the specific report that the PDF lacks the toolkit additions present on the web. The later follow-ups were valid at the time, so don't cite the original promise to update as completion evidence. The verified PDF content is the evidence; don't claim every future web edit or MAUI release is automatically synchronized.

### dotnet/docs#35234: Keep the framework-family heading separate from a release number

**Opened:** May 3, 2023. **Confidence:** High for the requested heading change. **Reason:** The current heading correctly contrasts .NET with .NET Framework.

The [microservices book](../docs/architecture/microservices/index.md) now identifies edition 7.0. The actual PDF downloaded from its current route says "When to choose .NET for Docker containers" and immediately explains the edition's .NET 7 choice against .NET Framework; the preceding chapter introduces the same two framework families. A heading without a release suffix isn't an error and doesn't mean .NET Framework.

**Suggested closure explanation:** Decline the proposed hard-coded .NET 6 heading. Keep modern .NET versus .NET Framework terminology and the edition-specific release in the surrounding text. Don't close on the basis that .NET 6 is old, claim that edition 7 is current supported deployment advice, or turn the naming answer into certification of the entire book.

### dotnet/docs#35334: Resolve relative resource references from a custom working directory

**Opened:** May 15, 2023. **Confidence:** High for the existing tool capability. **Reason:** A third input-base-directory switch isn't required for the described case.

The [Resgen reference](../docs/framework/tools/resgen-exe-resource-file-generator.md#parameters) documents `/useSourcePath`, separately from output-file and output-directory arguments. An owned .NET Framework 4.8-tool probe supplied absolute input/output paths and placed different `payload.txt` files beside the input and in a custom working directory. Without `/useSourcePath`, the generated resource contained `custom-working-directory`; with it, the resource contained `source-directory`.

**Suggested closure explanation:** Answer with a child-process working directory set to the desired base and absolute input/output paths, or use `/useSourcePath` for the source directory. Changing an output argument doesn't select the input base. There's no missing documented third switch to add; if a new CLI switch is still desired, distinguish that product feature request from the demonstrated supported workflow.

### dotnet/docs#35681: Route the missing CS9035 explanation to its consolidated article

**Opened:** June 7, 2023. **Confidence:** High for documentation coverage. **Reason:** The diagnostic, cause, and correction are now published.

The [property-declaration diagnostic article](../docs/csharp/language-reference/compiler-messages/property-declaration-errors.md#required-members) includes CS9035 in its diagnostic list, `f1_keywords`, and required-member resolution section. The live article also contains the diagnostic. An owned compiler run emitted **error** CS9035 for an omitted required property and no errors after an object initializer supplied it.

**Suggested closure explanation:** Close the missing-message documentation request and link the existing required-members explanation rather than create a duplicate `cs9035.md`. Correct the issue's warning/error distinction. A live Visual Studio F1 lookup wasn't exercised; if routing still fails in a specific IDE version, retain that concrete publishing/help-routing problem separately rather than claim the topic is absent.

### dotnet/docs#35940: Resolve the missing Console import in the objects examples

**Opened:** June 23, 2023. **Confidence:** High for the reported import failure. **Reason:** Both current examples explicitly import System and execute.

The [objects article](../docs/csharp/fundamentals/object-oriented/objects.md) now includes standalone [class](../docs/csharp/fundamentals/object-oriented/snippets/objects/Program.cs) and [struct](../docs/csharp/fundamentals/object-oriented/snippets/objects/Application.cs) programs. Both begin with `using System;`; neither depends on an interactive host supplying that import. An owned compiler/execution probe used the exact files without implicit global usings. The class example printed Leopold/6, Molly/16, and Molly/16; the struct example printed Alex/9, Spencer/7, and Alex/9, as documented.

**Suggested closure explanation:** Close the specific `Console`-not-found report because the current displayed files explicitly import the namespace and run. Don't infer anything about the former interactive host's imports, or claim that unrelated prose about value-type storage has been reviewed and corrected.

### dotnet/docs#36100: Find the documented AssemblyAttribute item syntax

**Opened:** July 4, 2023. **Confidence:** High. **Reason:** The linked destination now contains the syntax missing from the earlier fix.

The [GenerateAssemblyInfo property documentation](../docs/core/project-sdk/msbuild-props.md#generateassemblyinfo) links to [Set assembly attributes in a project file](../docs/standard/assembly/set-attributes-project-file.md#set-arbitrary-attributes). That destination explicitly demonstrates a fully qualified `AssemblyAttribute Include`, `_Parameter1`, `_Parameter2`, and the generated `AssemblyMetadataAttribute`, with a link for non-string parameter forms. An owned SDK 10.0.403 project followed the pattern and generated an attribute whose reflected key/value were `BuildDate=2026-11-03`.

**Suggested closure explanation:** Close the missing-syntax request and link directly to the arbitrary-attributes section. The issue correctly observed that an earlier link alone didn't solve the problem; the current destination's actual example, not that earlier PR's closure, resolves it. Coordinate the recommendation with current assignee `gewarren`; don't extend it to unrelated version-property or Source Link claims.

### dotnet/docs#36399: Keep trimming annotations and AOT code-generation guidance in their existing topics

**Opened:** July 26, 2023. **Confidence:** High. **Reason:** Both requested concepts already have dedicated explanations, identified by the runtime owner.

The [runtime-owner reply](https://github.com/dotnet/docs/issues/36399#issuecomment-1652916205) identifies [trim-warning guidance](../docs/core/deploying/trimming/fixing-warnings.md) for `DynamicallyAccessedMembers` and [AOT-warning guidance](../docs/core/deploying/native-aot/fixing-warnings.md) for runtime code generation. The current trimming page demonstrates annotation requirements and propagation, reflection alternatives, and source generators. The AOT page explains build-time native-code availability and demonstrates a `MakeGenericType` pattern that raises IL3050 and fails after AOT compilation.

**Suggested closure explanation:** Answer the placement question with those existing topics rather than duplicate the preview-blog paragraphs in the overview. Preserve the distinction between member preservation and native-code generation: an annotation doesn't generate arbitrary missing native code, and `MakeGenericType` isn't a promise that every possible invocation fails in every AOT app.

### dotnet/docs#36463: Distinguish a misleading time-zone label from a DST-invalid time

**Opened:** July 31, 2023. **Confidence:** High for the technical distinction. **Reason:** The proposed new category doesn't describe an additional TimeZoneInfo time-validity state.

The [time-zone overview](../docs/standard/datetime/time-zone-overview.md#time-zone-essentials) explicitly defines invalid and ambiguous times as consequences of a regional zone's adjustment rules. A confusing EST label in an email signature doesn't establish either condition, and a fixed UTC-05:00 offset doesn't stop representing valid instants during summer. An owned Windows probe represented July 1, 2023 at 12:00 with that offset and converted the same instant to 13:00 at UTC-04:00 in the regional Windows `Eastern Standard Time` zone.

**Suggested closure explanation:** Explain the label-versus-adjustment-rule distinction instead of adding the proposed "time zone is inoperative" definition to the .NET glossary. Human ambiguity in an email signature is real, but it doesn't make the timestamp nonexistent. Don't equate the Windows zone ID's standard-time wording with a year-round fixed offset, or claim to resolve a support team's signature policy through a runtime documentation change.

### dotnet/docs#36489: Explain Turkish casing before the comparison example

**Opened:** August 2, 2023. **Confidence:** High. **Reason:** The requested lead-in already precedes the sample.

The [culture-sensitive comparison section](../docs/standard/base-types/best-practices-strings.md#string-comparisons-that-use-the-current-culture) explicitly explains ordinary English I/i, Turkish capital dotted I (`U+0130`), and lowercase dotless i (`U+0131`) before the bill/BILL example. An owned culture-specific probe confirmed the two Turkish mappings and that case-insensitive BILL/Bill equality is true for English and false for Turkish.

**Suggested closure explanation:** Close the missing-explanation request and point to the existing lead-in. Don't repeat the issue's claim that lowercase `i` doesn't exist in Turkish; the distinction concerns its uppercase partner.

### dotnet/docs#36502: Follow the Native AOT diagnostics limitation link

**Opened:** August 2, 2023. **Confidence:** High. **Reason:** The overview now links the requested diagnostics documentation.

The [Native AOT limitations list](../docs/core/deploying/native-aot/index.md#limitations-of-native-aot-deployment) directly links "Diagnostic support for debugging and profiling" to [Diagnostics and instrumentation](../docs/core/deploying/native-aot/diagnostics.md). The destination contains actual capability/limitation guidance for telemetry, development-time diagnostics, native debugging, CPU profiling, and heap analysis, with version qualifications. The overview's native-debug-information discussion links there too.

**Suggested closure explanation:** Close the precise follow-up requested by [the review comment](https://github.com/dotnet/docs/pull/36397#discussion_r1275315265). The link and substantive destination, not merely the parent PR's merge, establish completion. Coordinate with current assignees `Rick-Anderson` and `LakshanF`; don't interpret closure as verification that every diagnostics capability is identical across all releases.

### dotnet/docs#36523: Explain the existing Option Explicit default

**Opened:** August 4, 2023. **Confidence:** High for the documentation question. **Reason:** Explicit declarations already default to On; removing the language option is a separate language-design proposal.

The [Option Explicit reference](../docs/visual-basic/language-reference/statements/option-explicit-statement.md) documents the default `On` setting, warns against `Off`, and explains project/compiler settings when a source file omits the statement. An owned Visual Basic compiler probe with no source-level option emitted BC30451 for an undeclared variable under the default options, while an explicit compiler override to `Off` allowed the same source.

**Suggested closure explanation:** Clarify that normal Visual Basic projects don't require the statement to enable the default checking. Decline the request to remove configurable behavior from Visual Basic, JavaScript, and all other languages as outside this documentation issue's scope. Don't claim that `On` can't be overridden, or conflate Option Explicit with Option Strict.

### dotnet/docs#36632: Restrict the Repository pattern to reads

**Opened:** August 10, 2023. **Confidence:** High for the naming objection. **Reason:** The proposed read-only restriction isn't part of the cited pattern.

The issue argues that repository classes must only read data, so an Entity Framework repository with writes misuses the name. Fowler's [Repository catalog entry](https://martinfowler.com/eaaCatalog/repository.html) explicitly describes a collection-like interface through which clients add and remove objects, with persistence operations encapsulated behind that interface. The current [persistence-layer chapter](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core.md) explains custom repositories and Unit of Work, while also recognizing direct `DbContext` use as an alternative.

**Suggested closure explanation:** The requested terminology correction rests on an incorrect restriction of the pattern. Close that precise objection with the catalog reference; don't claim that every repository implementation is ideal, that CQRS requires a write repository, or that the architecture chapter excludes direct EF Core use.

### dotnet/docs#36747: Test DI-aware metrics with MetricCollector

**Opened:** August 18, 2023. **Confidence:** High. **Reason:** The requested unit-test example now exists.

The [custom-metrics testing section](../docs/core/diagnostics/metrics-instrumentation.md#test-with-dependency-injection) builds a fresh service provider, calls `AddMetrics`, resolves the application's metrics holder and `IMeterFactory`, constructs a factory-scoped `MetricCollector<int>`, records a sale, and asserts the measurement count and value. The surrounding text explains isolation between service providers and the parallel-test hazard of shared static meters. Those details address the discussion's DI requirement, rather than only showing a global listener.

The [current collector implementation](https://github.com/dotnet/extensions/blob/main/src/Libraries/Microsoft.Extensions.Diagnostics.Testing/Metrics/MetricCollector.cs) accepts the scope/name/instrument arguments used by the example and filters on the instrument's meter scope. **Suggested closure explanation:** Point to the completed test and coordinate with assignee `noahfalk`. This recommendation verifies the requested content and API contract, not a fresh execution of the article's complete test project.

### dotnet/docs#36749: Create custom metrics through dependency injection

**Opened:** August 18, 2023. **Confidence:** High. **Reason:** The requested alternative to static instruments is documented.

The [DI metrics section](../docs/core/diagnostics/metrics-instrumentation.md#get-a-meter-via-dependency-injection) introduces `IMeterFactory`, defines a custom class that holds counters, registers that class with DI, and injects it into application code. It covers Generic Host registration, `AddMetrics` for a standalone service collection, isolation, automatic meter lifetime, and the associated DI-aware unit test. [dotnet/docs#36781](https://github.com/dotnet/docs/pull/36781) merged on August 26, 2023; the substantive current content, not the merge alone, establishes completion.

**Suggested closure explanation:** The core DI, holder-class, and testability requests are satisfied. The issue suggests a worker-template app as one way to demonstrate the approach; the current example uses ASP.NET Core and explicitly covers Generic Host applicability instead. Don't claim that a separate worker sample was added. Coordinate with assignee `noahfalk`.

### dotnet/docs#36934: Group nullable value and reference type navigation

**Opened:** August 31, 2023. **Confidence:** High for the navigation request. **Reason:** The requested conceptual grouping already exists.

The current [C# table of contents](../docs/csharp/toc.yml) places nullable value types and nullable reference types together under **Null safety**. The [null-safety overview](../docs/csharp/fundamentals/null-safety/index.md), also verified on the published site, introduces the shared topic and links the two concepts. That organization addresses the issue and the maintainer's promised Everyday C# rearrangement without pretending that the runtime representations are identical.

**Suggested closure explanation:** Close the original navigation request against the current TOC and published overview. [dotnet/docs#56679](https://github.com/dotnet/docs/pull/56679) remains open and unmerged, and its patch adds explanatory cross-references rather than the TOC grouping. Review that supplemental PR separately; don't cite it as a merged fix or create a duplicate assignment.

### dotnet/docs#37359: Collect metrics programmatically from another process

**Opened:** October 3, 2023. **Confidence:** High for the answered support question. **Reason:** The owner supplied the requested collection options, and the reporter accepted the explanation.

The complete discussion distinguishes the [in-process MeterListener example](../docs/core/diagnostics/metrics-collection.md#create-a-custom-collection-tool-using-the-net-meterlistener-api) from programmatic out-of-process collection. The owner explains both an OpenTelemetry/OTLP exporter and the `MetricsEventSource` bridge with EventPipe and TraceEvent; the reporter thanks the owner and accepts the answer. Follow-up questions about counter rates don't establish that `MeterListener` works across processes or require a new metric instrument.

**Suggested closure explanation:** Close as an answered usage question, and preserve the owner's two out-of-process approaches in the closure reply. Don't claim that the current article contains a complete custom out-of-process walkthrough or that every current counter display shows both totals and rates. A separate bounded walkthrough request remains distinct from this accepted answer.

### dotnet/docs#37580: Assign the transaction in the SQLite bulk-insert sample

**Opened:** October 18, 2023. **Confidence:** High. **Reason:** The provider already associates the sample's command with the active transaction.

The [bulk-insert sample](../docs/standard/data/sqlite/bulk-insert.md) starts a transaction before it calls `connection.CreateCommand()`. `Microsoft.Data.Sqlite` assigns the connection's active transaction to the command it creates; the [CreateCommand contract](https://learn.microsoft.com/dotnet/api/microsoft.data.sqlite.sqliteconnection.createcommand) and current provider source confirm that behavior. An owned SQLite 10.0.0 check verified reference identity between the active transaction and `command.Transaction`, inserted and read a value, and committed. The exact repository sample also completed its 150,000-row insert.

**Suggested closure explanation:** No explicit transaction assignment is missing from this provider-specific sample. Explain the `CreateCommand()` behavior and link the contract. Don't generalize the behavior to `SqlClient`, commands created before the transaction, or commands constructed through a different path.

### dotnet/docs#37748: Update the System.CommandLine tutorial after API renames

**Opened:** October 26, 2023. **Confidence:** High for the reported API-renaming mismatch. **Reason:** The tutorial now uses the modern API consistently.

The current [command-line tutorial](../docs/standard/commandline/get-started-tutorial.md) and all four staged projects use `System.CommandLine` 2.0.12 and the revised API rather than the old beta names identified in the issue. An owned .NET 10 harness compiled and executed the exact current stage sources with that package: the root commands, the `read` subcommand, and the final `quotes read` command all read the supplied input. Existing nullable warnings in later stages don't indicate the reported renamed-API failure.

**Suggested closure explanation:** Close the precise 2023 API-renaming gap against the current tutorial and snippets, with assignee `tdykstra` informed. Don't claim that every library article or every tutorial command path was verified, and don't close broader historical beta-documentation issues solely on this evidence.

### dotnet/docs#38551: Document baseline package validation strict mode

**Opened:** December 1, 2023. **Confidence:** High. **Reason:** The property, semantics, and both requested use cases are documented.

The [strict-mode overview](../docs/fundamentals/apicompat/overview.md#strict-mode) distinguishes equality checks from compatibility checks, names servicing as a use case, and explains how `ApiCompatGenerateSuppressionFile=true` records compatibility differences. It directly lists `EnableStrictModeForBaselineValidation`; the [property reference](../docs/core/project-sdk/msbuild-props.md#enablestrictmodeforbaselinevalidation) specifies baseline checks and the default of `false`. [dotnet/docs#38533](https://github.com/dotnet/docs/pull/38533), from which the issue originated, merged December 3, 2023.

**Suggested closure explanation:** Link the overview and baseline property reference, and close as documented with assignee `gewarren` informed. The absence of a second strict-mode tutorial in the baseline example isn't an undocumented property or use case.

### dotnet/docs#38644: Supply the movie sample's training and test files

**Opened:** December 7, 2023. **Confidence:** High for the missing-files report. **Reason:** Both exact files now exist and are accessible.

The referenced [end-to-end movie sample's Data directory](https://github.com/dotnet/machinelearning-samples/tree/main/samples/csharp/end-to-end-apps/Recommendation-MovieRecommender/MovieRecommender_Model/Data) contains `ratings_train.csv` and `ratings_test.csv`, alongside `ratings.csv`. Both exact raw-file requests returned HTTP 200, with the expected four-column header and data rows. The [current tutorial](../docs/machine-learning/tutorials/movie-recommendation.md#download-your-data) also supplies its own explicit downloads, named `recommendation-ratings-train.csv` and `recommendation-ratings-test.csv`; those links returned HTTP 200 as well.

**Suggested closure explanation:** Point to the exact files and distinguish the legacy end-to-end app from the tutorial's matrix-factorization sample. No new dataset is needed for the missing-files complaint. These checks establish file availability, not that the legacy application or its data-preparation helper was rebuilt and trained successfully.

### dotnet/docs#38645: Explain the two movie-recommendation models

**Opened:** December 7, 2023. **Confidence:** High for the comparison question. **Reason:** The existing guides and actual trainer calls identify different designs.

The [tutorial](../docs/machine-learning/tutorials/movie-recommendation.md) explicitly teaches matrix factorization to predict a numeric movie rating. The [end-to-end sample README](https://github.com/dotnet/machinelearning-samples/blob/main/samples/csharp/end-to-end-apps/Recommendation-MovieRecommender/README.md) describes its web application and includes an **Alternate Approaches** table that contrasts field-aware factorization machines, matrix factorization, and one-class recommendation. Its actual model source uses text-featurized identifiers and `BinaryClassification.Trainers.FieldAwareFactorizationMachine`, rather than the tutorial's rating-regression trainer.

**Suggested closure explanation:** Answer with the documented algorithm, prediction-task, and application-shape differences, and link the existing comparison table. The similarly named projects aren't duplicate implementations of one identical model. Don't claim that the old web app is current, that its training pipeline was executed, or that its score is interchangeable with the tutorial's predicted rating.

### dotnet/docs#38671: Update the VS Code tutorial for C# Dev Kit

**Opened:** December 8, 2023. **Confidence:** High for the obsolete project-configuration instructions. **Reason:** The replacement tutorials now use C# Dev Kit instead of the old explicit configuration-file workflow.

The old article redirects to [Create a console application](../docs/core/tutorials/create-console-app.md), whose VS Code pivot requires C# Dev Kit through its prerequisite include and uses **Create .NET Project**. The companion [debug tutorial](../docs/core/tutorials/debug-console-app.md#start-debugging) uses **C#: Launch startup project** and **C#: Debug Active File**, rather than instructions that require generated `launch.json` and `tasks.json` files. [dotnet/docs#51719](https://github.com/dotnet/docs/pull/51719) merged March 3, 2026; the current source confirms the new workflow, not just a redirect.

**Suggested closure explanation:** Close the reported mismatch between the old C#-extension-only tutorial and C# Dev Kit, with assignee `tdykstra` informed. Link the replacement creation and debugging pivots. Don't promise that Dev Kit always creates those configuration files or claim that a fresh interactive VS Code session was executed during triage.

### dotnet/docs#38989: Remove obsolete crossgen setup from PerfCollect guidance

**Opened:** January 5, 2024. **Confidence:** High. **Reason:** The exact obsolete instructions were removed.

[dotnet/docs#39200](https://github.com/dotnet/docs/pull/39200) merged January 22, 2024. Its patch removes the entire framework-symbol section that required readers to obtain `crossgen`, copy it beside the runtime, or disable precompiled code as a workaround. The [current guide](../docs/core/diagnostics/trace-perfcollect-lttng.md#prepare-your-machine) instead explains automatic framework-method resolution and keeps separate instructions for native runtime symbols.

**Suggested closure explanation:** The requested documentation cleanup has landed. Link the merged change and current guide. This recommendation doesn't claim that every historical runtime or every native-symbol scenario works without additional symbols, and it doesn't resolve unrelated container permissions or LTTng failures.

### dotnet/docs#39770: Explain thread safety in the dispose pattern

**Opened:** March 1, 2024. **Confidence:** High for the requested disposal/finalizer guard. **Reason:** The current text and both language examples explicitly address concurrent cleanup.

The [unmanaged-resource example](../docs/standard/garbage-collection/implementing-dispose.md#base-class-with-unmanaged-resources) now describes thread-safe `Dispose(bool)` and the synchronization requirement. Its actual C# and VB sources use `Interlocked.CompareExchange` on an integer guard before the unmanaged release. Both public disposal and finalization enter that guarded method. The article also recommends `SafeHandle` and explains its once-only release guarantee; [dotnet/docs#45173](https://github.com/dotnet/docs/pull/45173) merged March 11, 2025.

**Suggested closure explanation:** Link the guarded examples and SafeHandle explanation. The reported unchecked Boolean pattern is no longer the advanced unmanaged-resource example. An owned check executed the exact current C# class with 1,000 concurrent disposal calls on .NET 8 and .NET 10; that check doesn't establish that arbitrary methods on a disposable object are thread-safe or that callers can race resource use with disposal.

### dotnet/docs#40016: Interpret TensorFlow CPU information messages

**Opened:** March 15, 2024. **Confidence:** High for the quoted output. **Reason:** The report contains informational messages, not a demonstrated tutorial failure.

Every supplied line has TensorFlow's `I` severity prefix. The [TensorFlow CPU-feature implementation](https://github.com/tensorflow/tensorflow/blob/v1.15.0/tensorflow/core/platform/cpu_feature_guard.cc) emits the exact "Your CPU supports instructions that this TensorFlow binary was not compiled to use" text through `LOG(INFO)`. It reports unused CPU optimizations; a separate check handles instructions that a binary requires but the CPU lacks. The issue supplies no exception, failed assertion, or unsuccessful training result.

**Suggested closure explanation:** Explain the informational output and distinguish unused vector instructions from an execution failure. The quoted lines alone don't require a change to the [image-classification tutorial](../docs/machine-learning/tutorials/image-classification-api-transfer-learning.md). Don't recommend rebuilding TensorFlow or suppressing all native logs as a prerequisite, and don't claim that the reporter's training run succeeded. A separate failure would need its actual error and reproduction.

### dotnet/docs#40078: Follow the private-field convention in the Account example

**Opened:** March 19, 2024. **Confidence:** High for the reported field names. **Reason:** The current example already uses the requested underscore prefix.

The actual [Account source](../docs/csharp/language-reference/statements/snippets/lock/Program.cs) declares `_balanceLock` and `_balance`. [dotnet/docs#40714](https://github.com/dotnet/docs/pull/40714) merged May 2, 2024, and the current [lock reference](../docs/csharp/language-reference/statements/lock.md) includes that file. An owned .NET 10 project compiled and executed the exact file, including its modern `System.Threading.Lock`; the concurrent-account example printed `Account's balance is 2000`.

**Suggested closure explanation:** The private-field naming complaint is addressed in the source readers receive. Link the current example rather than assign another field rename. This recommendation doesn't certify every surrounding prose reference or propose replacing the current lock type with an older pattern.

### dotnet/docs#40176: Add examples for CA1844

**Opened:** March 21, 2024. **Confidence:** High. **Reason:** The requested before-and-after example has landed and demonstrates the rule.

[dotnet/docs#49034](https://github.com/dotnet/docs/pull/49034) merged October 27, 2025. The [CA1844 example section](../docs/fundamentals/code-analysis/quality-rules/ca1844.md#example) includes the actual [BadStream and GoodStream implementations](../docs/fundamentals/code-analysis/quality-rules/snippets/csharp/all-rules/ca1844.cs). `BadStream` overrides only array-based asynchronous methods; `GoodStream` also overrides the memory-based methods and forwards its array overloads to them.

**Suggested closure explanation:** Link the existing example and coordinate closure with assignee `gewarren`. An owned build with CA1844 enabled produced two diagnostics on `BadStream` and none on `GoodStream`. Both exact classes compiled and completed a three-byte write/read round trip on .NET 8 and .NET 10. The missing-example request no longer needs another implementation.

### dotnet/docs#40335: Identify AppDomain unloading as Framework-specific

**Opened:** April 5, 2024. **Confidence:** High for the applicability complaint. **Reason:** The current article explicitly excludes modern .NET.

The [AppDomain unloading article](../docs/framework/app-domains/how-to-unload-an-application-domain.md) now includes the [Framework-specific notice](../docs/framework/includes/net-framework-specific.md), which states that the article doesn't apply to newer .NET implementations, including .NET 6 and later. [dotnet/docs#41179](https://github.com/dotnet/docs/pull/41179) merged June 3, 2024. The reported attempt to execute a Framework example on .NET 8 is therefore no longer an unmarked applicability trap.

**Suggested closure explanation:** Link the explicit scope notice and the modern [assembly unloadability guide](../docs/standard/assembly/unloadability.md). Preserve the supported Framework example rather than port it in place. Don't claim that `AssemblyLoadContext` supplies AppDomain isolation or that `AppDomain.Unload` becomes supported on modern .NET.

### dotnet/docs#40543: Correct the Int64 heading and explain signed integer literals

**Opened:** April 18, 2024. **Confidence:** High for the accepted heading correction and literal question. **Reason:** The current API remarks use 64-bit wording, and existing language guidance explains the reported literal behavior.

The supplemental article has been removed in favor of the API reference. Both the [current Int64 XML remarks](https://github.com/dotnet/dotnet-api-docs/blob/main/xml/System/Int64.xml) and the [published API page](https://learn.microsoft.com/dotnet/api/system.int64?view=net-10.0) use "Work with non-decimal 64-bit integer values," not the reported 32-bit heading. The [integer-literal reference](../docs/csharp/language-reference/builtin-types/integral-numeric-types.md#integer-literals) explicitly explains positive literal magnitudes, inferred unsigned types, casts, and `unchecked` conversion.

**Suggested closure explanation:** Close the accepted heading defect against the current destination, and answer the literal question with the existing reference. The [runtime-owner reply](https://github.com/dotnet/docs/issues/40543#issuecomment-2066732167) explains the literal rule and declines the proposed terminology/CLS additions; don't turn those suggestions into an approved new policy. Owned .NET 8 and .NET 10 checks confirmed that both `1 << 31` and the explicit unchecked high-bit literal produce `Int32.MinValue`; the shift isn't an illegal expression. This recommendation doesn't claim that every optional editorial suggestion was implemented.
