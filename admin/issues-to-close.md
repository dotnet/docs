---
title: Issue closure recommendations
ai-usage: ai-generated
---

# Issue closure recommendations

Recommend closing the following issues because current documentation addresses the request, an authoritative answer resolves the documentation question, the affected sample has been superseded, another tracked issue covers the same work, or the proposal belongs to another documentation set. These are recommendations only: no issues have been closed, commented on, labeled, or assigned.

## Review coverage

- **Repository and snapshot:** `dotnet/docs`, November 2, 2026; 848 open issues, excluding pull requests.
- **Order:** Issue creation time, oldest first, not most recent activity.
- **Completed batches:** The 848 oldest issues in the original open-issue snapshot, from [dotnet/docs#2608](https://github.com/dotnet/docs/issues/2608), opened July 12, 2017, through [dotnet/docs#56692](https://github.com/dotnet/docs/issues/56692), opened November 1, 2026. The original snapshot is complete.
- **Results:** 165 closure candidates and 405 [clearly defined fixes](issues-with-defined-fixes.md) (321 assignment candidates and 84 fixes covered by 81 open implementation PRs).
- **Latest batch:** Issues 826-848, from [dotnet/docs#55955](https://github.com/dotnet/docs/issues/55955) through dotnet/docs#56692: 2 closure candidates, 3 new assignment candidates, and 10 new fixes with open implementation PRs.
- **Remaining:** 0 issues from this snapshot are unreviewed. Of the requested remaining 298 issues (positions 551-848), 298 are complete and 0 remain. Issues created after the November 2 snapshot aren't included. Refresh states before acting on any recommendation.
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

### dotnet/docs#40587: Recognize the existing polymorphic serialization example

**Opened:** April 22, 2024. **Confidence:** High. **Reason:** The example already serializes a derived instance through its base-type contract.

The [polymorphism guide](../docs/standard/serialization/system-text-json/polymorphism.md) declares `WeatherForecastWithCity` as a derived type of `WeatherForecastBase`, annotates the base contract with `JsonDerivedType`, and serializes a base-typed variable. The [referenced example](../docs/standard/serialization/system-text-json/snippets/how-to/csharp/SerializePolymorphic.cs) explicitly calls `Serialize<WeatherForecastBase>`. The absence of a virtual method doesn't remove that type relationship or the serializer's configured derived-type behavior.

**Suggested closure explanation:** Point to the base-typed variable, the derived-type annotation, and the JSON `City` property. An owned fixture with those exact class definitions and the same base-type serialization call emitted `"City":"Milwaukee"` on .NET 8 and .NET 10. Coordinate closure with assignee `gewarren`; don't add virtual members to create a requirement that System.Text.Json doesn't impose.

### dotnet/docs#40633: Refresh the Portuguese CRUD startup example

**Opened:** April 26, 2024. **Confidence:** High for the reported English/Portuguese mismatch. **Reason:** The published Portuguese example now uses the same Program.cs startup pattern as the English source.

The issue points specifically to the Swagger setup that formerly differed between the English and pt-BR versions of the [CRUD microservice chapter](../docs/architecture/microservices/multi-container-microservice-net-applications/data-driven-crud-microservice.md). The [current published pt-BR page](https://learn.microsoft.com/pt-br/dotnet/architecture/microservices/multi-container-microservice-net-applications/data-driven-crud-microservice) now says `Program.cs` and shows `builder.Services.AddSwaggerGen`, `app.UseSwagger()`, and `app.Environment.IsDevelopment()`, matching the current English section. Its DbContext registration also uses `builder.Services`.

**Suggested closure explanation:** The particular translation lag reported in April 2024 is no longer present in the published startup examples. Close that mismatch rather than assign a translation of code already synchronized. Don't claim that the entire legacy eShopOnContainers chapter, its screenshots, or every third-party API has been modernized or validated against .NET 10.

### dotnet/docs#40754: Identify the Reflection.Emit example's Framework target

**Opened:** May 4, 2024. **Confidence:** High. **Reason:** The article now explicitly identifies the Framework-only save APIs and the modern alternative.

The [generic-type Reflection.Emit how-to](../docs/fundamentals/reflection/how-to-define-a-generic-type-with-reflection-emit.md) now includes ".NET Framework" in its title and an important notice explaining that the sample uses APIs unavailable in modern .NET. It links to `PersistedAssemblyBuilder` guidance for modern assembly persistence. [dotnet/docs#51035](https://github.com/dotnet/docs/pull/51035) merged January 15, 2026.

**Suggested closure explanation:** Close the unmarked-target complaint against the explicit scope notice. The exact current C# source compiled against Framework reference assemblies, executed under Framework, saved `GenericEmitExample1.dll`, and printed the expected generic constraints. Preserve that supported example; don't claim that `PersistedAssemblyBuilder`, introduced in .NET 9, is a .NET 8 replacement or that the original save calls work on .NET 8.

### dotnet/docs#40763: Consolidate external logger-scope guidance under the existing task

**Opened:** May 5, 2024. **Confidence:** High. **Reason:** The earlier custom-provider scope issue already covers this implementation requirement.

The request asks why a custom logger needs an external scope provider and how to use it. The existing [dotnet/docs#37874 assignment brief](issues-with-defined-fixes.md#dotnetdocs37874-explain-and-demonstrate-scopes-in-a-custom-logging-provider) covers the same [custom-provider article](../docs/core/extensions/logging/custom-provider.md), including `ISupportExternalScope`, `IExternalScopeProvider`, scope enumeration, and the replacement of the sample's no-op `BeginScope`.

**Suggested closure explanation:** Close as a duplicate of [dotnet/docs#37874](https://github.com/dotnet/docs/issues/37874), and retain the external-provider rationale and setup in that primary task. The current no-op sample isn't fixed yet; the reason for closure is duplicate work, not implemented scope support. Keep the separate structured-state requirement in dotnet/docs#41327 visible.

### dotnet/docs#40862: Correct the early-bailout helper's return type

**Opened:** May 13, 2024. **Confidence:** High. **Reason:** Both current language examples already return a task whose result is the original operation.

The [early-bailout discussion](../docs/standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern.md#early-bailout) includes the current helper as `async Task<Task>` in [C#](../docs/standard/asynchronous-programming-patterns/snippets/consuming-the-task-based-asynchronous-pattern/csharp/Program.cs) and `Task(Of Task)` in [Visual Basic](../docs/standard/asynchronous-programming-patterns/snippets/consuming-the-task-based-asynchronous-pattern/vb/Program.vb). Returning `asyncOp` therefore matches the declared result type. The surrounding text explicitly says that early bailout doesn't cancel the underlying operation.

**Suggested closure explanation:** The reported return-type mismatch is absent from both current snippets. An owned execution of the C# helper on .NET 8 and .NET 10 preserved a completed task's identity, returned an incomplete original task for a pre-canceled wait, and observed that task's later fault. Don't remove the returned task or unconditionally await the underlying operation, which would change the intended early-bailout contract.

### dotnet/docs#41052: Explain ICU comparison behavior and update the examples

**Opened:** May 23, 2024. **Confidence:** High for the owner-approved corrections. **Reason:** Both documentation destinations now contain the requested backend explanation and revised examples.

The [current CompareOptions XML](https://github.com/dotnet/dotnet-api-docs/blob/main/xml/System.Globalization/CompareOptions.xml) and [published reference](https://learn.microsoft.com/dotnet/api/system.globalization.compareoptions?view=net-10.0) explain ICU's equivalent `None`/`StringSort` behavior, link to the NLS restoration guidance, and include the contributor's expanded option examples. The modernized string-sort examples in C#, F#, and Visual Basic retain the older output but explicitly qualify the modern default. The [globalization guide](../docs/core/extensions/globalization-icu.md#string-sorting-and-systemglobalizationcompareoptions) also explains the backend distinction; [dotnet/docs#41661](https://github.com/dotnet/docs/pull/41661) merged August 1, 2024.

**Suggested closure explanation:** Close the missing-behavior and outdated-example request against both current destinations, not merely the merged conceptual-page PR. The exact current C# sort example ran in fresh .NET 8 and .NET 10 processes: ICU produced identical orders, while explicit NLS selection reproduced the two distinct legacy orders. Describe equivalent behavior under ICU, not enum aliases: `None` remains 0 and `StringSort` remains 536870912. Don't claim that selecting a modern .NET version prevents an application from using NLS.

### dotnet/docs#41082: Resolve the interface-to-interface DI registration question

**Opened:** May 26, 2024. **Confidence:** High for the reported registration mistake. **Reason:** The maintainer's concrete-type correction and current lifetime guides answer the documentation question.

The issue's registration uses `AddScoped<IContatoAppService, IContatoAppService>()`. The maintainer explains that the second type must be a concrete implementation. The [current DI overview](../docs/core/extensions/dependency-injection/overview.md#the-concept) explicitly registers an interface with its concrete class and links to the dedicated [service-lifetime examples](../docs/core/extensions/dependency-injection/service-lifetimes.md). The reporter's later application-specific failure doesn't establish another defect in those examples.

**Suggested closure explanation:** Link the maintainer's answer and the current registration/lifetime guidance. On .NET 8 and .NET 10, an owned interface-to-interface registration failed with "Cannot instantiate implementation type," while the equivalent interface-to-concrete scoped registration resolved successfully. Close the general documentation question without claiming to have diagnosed or repaired the reporter's separate application, dependency graph, or circular dependencies.

### dotnet/docs#41457: Remove compiler-lowered entry-point details from the Main overview

**Opened:** June 17, 2024. **Confidence:** High. **Reason:** The requested simplification is already present.

The [current Main overview](../docs/csharp/fundamentals/program-structure/main-command-line.md) explains entry-point signatures, arguments, asynchronous completion, and exit codes without the old compiler-generated entry-point implementation. [dotnet/docs#52082](https://github.com/dotnet/docs/pull/52082), merged March 19, 2026, contains the program-structure revision. The reporter and maintainer asked to remove hidden lowering details, not the useful explanation that asynchronous entry points complete before the application exits.

**Suggested closure explanation:** The current overview no longer includes the generated `Main`/awaiter boilerplate that prompted the issue. Close the simplification request against the revised page without requiring unrelated changes to entry-point behavior or terminology.

### dotnet/docs#41492: Remove the obsolete code-analysis GitHub action reference

**Opened:** June 20, 2024. **Confidence:** High. **Reason:** The obsolete action section was removed.

[dotnet/docs#41940](https://github.com/dotnet/docs/pull/41940), merged July 30, 2024, removed the code-analysis action from the [.NET GitHub action reference](../docs/devops/dotnet-github-action-reference.md). The current page lists the version-sweeper action, not the discontinued code-analysis workflow reported here.

**Suggested closure explanation:** Close against the merged removal and current reference. Don't retain a task to update an action that the guide no longer recommends, or conflate the issue with separate maintenance work on custom-action Dockerfiles.

### dotnet/docs#41530: Supply the current MAUI ebook edition

**Opened:** June 22, 2024. **Confidence:** High for the current download. **Reason:** The advertised version and downloaded PDF now agree.

The [MAUI ebook index](../docs/architecture/maui/index.md) advertises edition v2.0. Followed through `https://aka.ms/maui-ebook`, the current download landing page links to the [actual PDF](https://github.com/dotnet-architecture/eBooks/blob/main/current/maui/Enterprise-Application-Patterns-Using-.NET-MAUI.pdf). Downloaded the PDF, verified its readable PDF structure, and extracted its opening pages: the edition line reads **EDITION v2.0**. The alias first returns an HTML landing page; its filename or HTTP redirect alone doesn't establish the book edition.

**Suggested closure explanation:** The current download supplies edition v2.0, resolving the reported v1/v2 mismatch. Link to the verified download, without treating the retained 2022 copyright year as an edition number or claiming that every chapter was audited.

### dotnet/docs#41627: Explain synchronization for observable metric callbacks

**Opened:** July 2, 2024. **Confidence:** High. **Reason:** The current instrumentation guide directly answers the question.

The [metrics instrumentation guide](../docs/core/diagnostics/metrics-instrumentation.md) explicitly states that observable callbacks aren't synchronized with code that updates their observed values. It assigns synchronization or tolerance of inconsistent state to the application, identifies locks and `Volatile.Read`/`Volatile.Write` as appropriate mechanisms, and supplies adjacent callback-performance guidance.

**Suggested closure explanation:** Link to the existing observable-instrument guidance. The thread safety of instrument APIs doesn't synchronize application-owned measurement state; the current text already makes that distinction, so another duplicate warning isn't needed.

### dotnet/docs#41974: Resolve contradictory CPU counter units

**Opened:** July 31, 2024. **Confidence:** High. **Reason:** The contradictory counter listing has been removed, and the remaining references distinguish the metrics.

The issue's two screenshots show conflicting units in the old `dotnet-counters list` material. The [current command reference](../docs/core/diagnostics/dotnet-counters.md) no longer documents that listing. Its version-qualified EventCounter example labels CPU usage as a percentage, consistent with the [System.Runtime counter definition](../docs/core/diagnostics/available-counters.md#systemruntime-counters), which defines `cpu-usage` relative to the system's CPU resources.

**Suggested closure explanation:** The obsolete, contradictory listing is gone, and the retained EventCounter guidance uses percent consistently. Don't describe the newer `dotnet.process.cpu.time` metric as another name for the old percentage counter; CPU time and CPU usage are distinct measurements.

### dotnet/docs#41981: Retire the obsolete net461 data-protection project alert

**Opened:** August 1, 2024. **Confidence:** High. **Reason:** The flagged project was removed and replaced with platform-qualified projects.

The version sweeper names one legacy DPAPI project, which no longer exists. Merged [dotnet/docs#54853](https://github.com/dotnet/docs/pull/54853), July 22, 2026, migrated the example. The [current article](../docs/standard/security/how-to-use-data-protection.md) references a [.NET Framework 4.8 project](../docs/standard/security/snippets/how-to-use-data-protection/framework/csharp/DataProtectionSample.csproj) and a [net10.0-windows project](../docs/standard/security/snippets/how-to-use-data-protection/net/csharp/DataProtectionSample.csproj). Its text distinguishes the Framework-only `ProtectedMemory` example from Windows-specific `ProtectedData`.

**Suggested closure explanation:** The specific `net461` project has been replaced, and its replacements already target Framework 4.8 and .NET 10 for Windows. Close the obsolete project alert rather than retarget a deleted file or claim that all DPAPI APIs are cross-platform.

### dotnet/docs#41982: Correct the net472 end-of-support premise

**Opened:** August 1, 2024. **Confidence:** High for the support-policy distinction. **Reason:** The alert treats an active .NET Framework version as an unsupported modern .NET release.

All three named projects still target `net472`; their presence isn't evidence that the bot's end-of-support claim is correct. The [.NET Framework support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-framework) lists .NET Framework 4.7.2 as active and ties applicable support to the parent Windows lifecycle. The issue's `N/A` end date doesn't establish end of support. The [Framework version guide](../docs/framework/install/versions-and-dependencies.md) also explains the relationship between Framework 4.x versions.

**Suggested closure explanation:** Close this blanket unsupported-version alert as inapplicable to .NET Framework 4.7.2. Don't apply modern .NET STS/LTS dates to Framework projects, promise support on every Windows version, or port VSIX and Framework-specific samples merely to satisfy the bot.

### dotnet/docs#41983: Correct the v4.7.2 end-of-support premise

**Opened:** August 1, 2024. **Confidence:** High for the support-policy distinction. **Reason:** The WPF project uses the same active Framework version in traditional project syntax.

The named StringReaderWriter WPF project still declares `v4.7.2`. That spelling identifies .NET Framework 4.7.2, not a separate release with a different lifecycle. The [Framework support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-framework) lists that version as active subject to its Windows support conditions.

**Suggested closure explanation:** Close the unsupported-version alert on the same basis as dotnet/docs#41982. A separately justified project modernization task would need its own scope; the bot's missing end date doesn't require a WPF port or target change.

### dotnet/docs#42196: Document Native AOT CFG and CET

**Opened:** August 15, 2024. **Confidence:** High. **Reason:** Dedicated documentation now covers both requested protections.

The [Native AOT security page](../docs/core/deploying/native-aot/security.md) includes a Control Flow Guard section with the `ControlFlowGuard` property and a CET Shadow Stack section. It explains the Windows default from .NET 9 and the `CetCompat` opt-out. The issue contains no additional unresolved scenario beyond its CFG/CET documentation title.

**Suggested closure explanation:** Link to the existing Native AOT security guidance and close the documentation request as addressed, in coordination with current assignee `MichalStrehovsky`. Don't infer that every protection or default applies identically to every operating system.

### dotnet/docs#42249: Provide direct discovery links for official container images

**Opened:** August 20, 2024. **Confidence:** High. **Reason:** The current article already supplies the requested discovery route.

The [official image article](../docs/architecture/microservices/net-core-net-framework-containers/official-net-docker-images.md) opens with the Microsoft Artifact Registry catalog and a direct .NET SDK repository link, rather than send readers only to a GitHub repository. The current [dotnet-docker README](https://github.com/dotnet/dotnet-docker) also has a featured-repository list for SDK, ASP.NET Core, runtime, and runtime-dependency images.

**Suggested closure explanation:** Direct image-discovery links now exist at the start of the article. Close the original navigation request without treating unrelated version examples as part of the fix or claiming that a container pull or the registry's interactive tag UI was tested.

### dotnet/docs#42406: Explain removal of Visual Studio's unsupported components

**Opened:** August 31, 2024. **Confidence:** High. **Reason:** Visual Studio documentation now explains the supported installer routes.

The [Visual Studio update guide's Remove out-of-support components section](https://learn.microsoft.com/visualstudio/install/update-visual-studio?view=vs-2022#remove-out-of-support-components) documents both the one-time **Modify** action and the persistent update setting. The [.NET Uninstall tool overview](../docs/core/additional-tools/uninstall-tool-overview.md) correctly limits its ability to remove Visual Studio-installed components; a new standalone uninstall-tool recommendation wouldn't resolve modern installer ownership.

**Suggested closure explanation:** Link to Visual Studio Installer's existing one-time and future-update controls. Close the missing-guidance question without promising that every application can lose an old runtime safely; readers must still check their projects and deployed applications' dependencies. No components were removed during this review.

### dotnet/docs#42627: Document NUnit Category and TestCategory filtering

**Opened:** September 16, 2024. **Confidence:** High for the documented VSTest/NUnit adapter route. **Reason:** Both supported property names now appear in the reference.

The [selective-test guide](../docs/core/testing/selective-unit-tests.md) explicitly lists both `Category` and `TestCategory` for NUnit. The adapter's [filter tests](https://github.com/nunit/nunit3-vs-adapter/blob/main/src/NUnitTestAdapterTests/Filtering/TestFilterTests.cs) exercise both names against the same category trait, including no-category and multiple-category cases. The issue's premise that `Category` is undocumented no longer applies.

**Suggested closure explanation:** Both spellings are documented for NUnit's VSTest adapter and map to its category traits. Link the current property table and adapter tests; don't generalize those aliases to MSTest, xUnit, or every Microsoft.Testing.Platform runner.

### dotnet/docs#42745: Resolve the ActivitySource static-initialization question

**Opened:** September 28, 2024. **Confidence:** High. **Reason:** The runtime owner answered the specific failure and supplied a safe initialization sequence.

In [the runtime owner's answer](https://github.com/dotnet/runtime/issues/110249#issuecomment-2512961687), `ShouldListenTo` reenters the source's initializer before its static property has received a value. The owner identifies an application initialization problem, not an `ActivitySource` bug, and initializes the source before listener registration. Owned .NET 8/.NET 10 fixtures reproduced the circular initialization failure and verified that ordering fix.

**Suggested closure explanation:** Close the question as answered by the runtime owner. Retain the [walkthrough's static-source best practice](../docs/core/diagnostics/distributed-tracing-instrumentation-walkthroughs.md); the failure doesn't justify a blanket warning against static sources. Initialize the source first or match a stable source name without dereferencing an unfinished initializer. Don't prescribe catching the initializer exception and continuing with the failed type.

### dotnet/docs#42812: Complete the .NET 9 SYSLIB documentation checklist

**Opened:** October 3, 2024. **Confidence:** High. **Reason:** Every listed diagnostic now has documentation and a working destination.

Dedicated pages cover [SYSLIB1230](../docs/fundamentals/syslib-diagnostics/syslib1230.md) and [SYSLIB5003](../docs/fundamentals/syslib-diagnostics/syslib5003.md). The [experimental API overview](../docs/fundamentals/syslib-diagnostics/experimental-overview.md) documents SYSLIB5001, SYSLIB5002, SYSLIB5004, and SYSLIB5005, includes their F1 metadata, and explains their shared opt-in/suppression model. All four corresponding `aka.ms/dotnet-warnings/SYSLIB...` routes resolved to that published overview with HTTP 200.

The supporting PRs also merged: [dotnet/docs#42884](https://github.com/dotnet/docs/pull/42884), October 9, 2024; [dotnet/docs#43119](https://github.com/dotnet/docs/pull/43119), October 25, 2024; and [dotnet/docs#43288](https://github.com/dotnet/docs/pull/43288), November 12, 2024.

**Suggested closure explanation:** The requested .NET 9 diagnostic coverage exists, including the experimental overview. Close the checklist; four duplicate standalone pages aren't required. Don't imply that an API introduced as experimental remains experimental in every later release.

### dotnet/docs#43167: Prefer project-level consent for experimental diagnostics

**Opened:** October 23, 2024. **Confidence:** High for the original review comment's scope. **Reason:** The requested section order and recommendation are already present.

The [original review comment](https://github.com/dotnet/docs/pull/43119#discussion_r1811567034) targets `experimental-overview.md`. Its [current suppression section](../docs/fundamentals/syslib-diagnostics/experimental-overview.md#suppress-warnings) now recommends `<NoWarn>` and shows the project-file example before `#pragma`. The introduction also explains that consent applies to a particular experimental diagnostic rather than all experimental features.

**Suggested closure explanation:** The exact section identified by the request now uses the preferred order and explicit project-level recommendation. Coordinate closure with assignee `gewarren`. Preserve the author's clarification that this consent guidance isn't a blanket preference for project-wide suppression of ordinary compiler warnings.

### dotnet/docs#43392: Correct the deferred domain-event transaction explanation

**Opened:** November 9, 2024. **Confidence:** High for consolidation, not implementation. **Reason:** The older open transaction-boundary issue covers the same faulty explanation; retain the additional reliability concern there.

The [retained dotnet/docs#27904 brief](issues-with-defined-fixes.md#dotnetdocs27904-state-the-transaction-boundary-for-nested-domain-event-saves) addresses the same `SaveEntitiesAsync` example and false inference that a shared scoped context alone establishes one transaction. That brief now explicitly preserves this issue's post-commit crash/failure window and durable-dispatch caveat. The current [chapter](../docs/architecture/microservices/microservice-ddd-cqrs-patterns/domain-events-design-implementation.md) already discusses post-commit inconsistency and persistent event records, but those paragraphs don't repair the misleading transaction comment or guarantee crash-safe in-memory dispatch.

**Suggested closure explanation:** Consolidate with dotnet/docs#27904 and carry over both the explicit outer-transaction correction and post-commit reliability caveat. Don't close as fixed or discard the extra concern as an exact duplicate. Keep the domain/integration distinction about semantic boundaries; eventual consistency doesn't automatically turn aggregates into actors. Coordinate the surviving content with the separate ebook-curation draft before implementation.

### dotnet/docs#43641: Replace OrleansConfiguration.xml in cluster-management guidance

**Opened:** November 19, 2024. **Confidence:** High for the requested XML removal. **Reason:** The current article no longer refers to the legacy XML configuration file.

The [cluster-management article's configuration section](../docs/orleans/implementation/cluster-management.md#configuration) now uses `siloBuilder.Configure<ClusterMembershipOptions>` and shows the option properties. A check of the complete article found no `OrleansConfiguration.xml` reference. The article distinguishes current and historical Orleans version pivots.

**Suggested closure explanation:** The exact legacy-configuration reference has been replaced with options-based configuration. Coordinate with assignee `ReubenBond`; don't interpret closure as a new claim that every membership default or failure-detection estimate is identical across all pivots.

### dotnet/docs#43781: Correct the Host.CreateApplicationBuilder configuration priority

**Opened:** November 26, 2024. **Confidence:** High. **Reason:** The specific priority list now has the requested order.

The [configuration overview](../docs/core/extensions/configuration.md) explicitly orders its defaults from highest to lowest priority and lists environment-specific `appsettings.Environment.json` before `appsettings.json`. It also explains that providers added later override earlier values. The reported inversion isn't present in the current `Host.CreateApplicationBuilder` list.

**Suggested closure explanation:** The environment-specific JSON file now outranks the base JSON file in the exact list identified by the issue. Close as addressed; don't reverse provider-registration order or confuse this list with host-configuration callbacks.

### dotnet/docs#43922: Document dotnet-coverage telemetry and opt-out

**Opened:** December 10, 2024. **Confidence:** High for the documentation request. **Reason:** The tool article now links to a detailed, product-specific telemetry reference.

The [dotnet-coverage Telemetry section](../docs/core/additional-tools/dotnet-coverage.md#telemetry) identifies collection beginning with version 18.10.0 and links to the [coverage-tools telemetry reference](https://learn.microsoft.com/visualstudio/test/microsoft-code-coverage-console-tool-telemetry). That live reference explicitly covers `dotnet-coverage`, enumerates data points, explains Boolean recording rather than verbatim paths/arguments, and documents both `DOTNET_COVERAGE_TELEMETRY_OPTOUT=1` and `DOTNET_CLI_TELEMETRY_OPTOUT=1`.

**Suggested closure explanation:** The requested data description and opt-out instructions now exist and are linked from the tool page. Don't confuse `DOTNET_COVERAGE_NOLOGO` with a telemetry opt-out, infer that older versions collect the same schema, or offer a legal-compliance certification. No coverage command or telemetry transmission was needed to verify the documentation.

### dotnet/docs#43958: Correct the blanket AnalysisLevel latest default

**Opened:** December 13, 2024. **Confidence:** High for duplication, not completion. **Reason:** The older open issue already covers this exact property-reference error.

The [dotnet/docs#29054 brief](issues-with-defined-fixes.md#dotnetdocs29054-state-analysislevel-defaults-by-target-framework-and-sdk) retains both the MSBuild property page and analysis overview. Its SDK 10.0.403 property-evaluation matrix reproduces target-dependent defaults and explicitly configured `latest`. The older issue remains open; the incorrect blanket wording isn't being treated as fixed.

**Suggested closure explanation:** Consolidate with dotnet/docs#29054 rather than assign a second implementation for the same two-page correction. Preserve the supported-target/SDK/explicit-override acceptance matrix and the distinction between analyzer availability, enablement, and severity.

### dotnet/docs#43966: Publish guidance for safe customer-code reproduction

**Opened:** December 13, 2024. **Confidence:** Medium for repository ownership. **Reason:** The guidance has a maintained SDK-contributor home, and the discussion questions a second product-docs article.

[dotnet/sdk#45456](https://github.com/dotnet/sdk/pull/45456) merged on January 30, 2025. The current [Executing Customer Code guide](https://github.com/dotnet/sdk/blob/main/documentation/general/ExecutingCustomerCode.md) contains the substantive contributor guidance, including design-time-build risks, isolated environments, credential precautions, and malicious-repro handling. In the complete issue discussion, a docs maintainer identifies repository/contributor guidance as the appropriate home, and the author accepts closure if the topic doesn't belong in product documentation.

**Suggested closure explanation:** Recommend closure as contributor guidance with an existing canonical SDK home, subject to agreement from `gewarren`, `Forgind`, and `marcpopMSFT`. Preserve the final comment's cross-repository discoverability concern as an ownership/navigation decision; don't claim that visibility is already solved or that a second dotnet/docs article was approved. This recommendation isn't a security audit or an endorsement of absolute safety claims in the linked guide.

### dotnet/docs#43996: Missing CS8955 documentation

**Opened:** December 17, 2024. **Confidence:** High. **Reason:** The diagnostic and its resolution are now documented.

The consolidated [using-directive diagnostics article](../docs/csharp/language-reference/compiler-messages/using-directive-errors.md#file-scoped-namespace) includes CS8955 in its F1/help metadata, diagnostic list, and file-scoped namespace section. It explains that a file can't mix file-scoped and block-scoped namespace declarations and directs the reader to choose one style. A March 2026 issue comment independently identifies that coverage.

**Suggested closure explanation:** Link to the consolidated CS8955 explanation and namespace reference. A separate diagnostic page isn't necessary; don't base closure on an unrelated diagnostic PR or imply that an unmerged patch supplies the current explanation.

### dotnet/docs#44084: Missing downloadable NER sample data

**Opened:** December 26, 2024. **Confidence:** High for duplication, not completion. **Reason:** Older open dotnet/docs#43317 already tracks the same Model Builder NER data gap.

The [Model Builder dataset table](../docs/machine-learning/automate-training-with-model-builder.md#example-datasets) still lacks the requested NER download. The older [dotnet/docs#43317](https://github.com/dotnet/docs/issues/43317) remains open and includes the missing sample/data-format problem. Closing this duplicate wouldn't imply that either the data or loader instructions have been supplied.

**Suggested closure explanation:** Consolidate with dotnet/docs#43317 and preserve the request for a downloadable sample that the actual Model Builder NER loader accepts. Don't substitute a generic trainer's BIO/CoNLL format or classify the canonical issue as fixed.

### dotnet/docs#44193: Additional CA1853 suppression reason for dictionary updates

**Opened:** January 9, 2025. **Confidence:** Medium. **Reason:** The proposed conditional work doesn't require a redundant lookup or an additional suppression exemption.

`Dictionary.Remove(key)` returns whether it removed an entry. Use that result to guard the remaining copy/clear/reassignment work instead of first calling `ContainsKey`. An owned, compilable equivalent on .NET 8 and .NET 10 preserved the result and the original dictionary alias for both an existing and a missing key: the existing-key path copied the survivors and cleared the original; the absent-key path didn't. The reporter's literal collection-expression example isn't compilable as written, so this wasn't execution of the unchanged issue code.

**Suggested closure explanation:** Explain the Boolean-returning `Remove` alternative and link to [CA1853](../docs/fundamentals/code-analysis/quality-rules/ca1853.md). Don't recommend removal of the conditional side effects, promise a contractual dictionary move-to-end operation, or claim that every analyzer code fix handles additional statements correctly. A reproducible unsafe analyzer transformation would be a separate analyzer defect, not evidence that the extra lookup is inherently required.

### dotnet/docs#44233: Edit the introduction to records

**Opened:** January 13, 2025. **Confidence:** High for the quoted passage. **Reason:** The requested equality explanation has already been rewritten.

The [record introduction](../docs/csharp/fundamentals/types/records.md) now separates the `record` modifier from class/struct semantics. Its value-equality section compares plain classes, plain structs, record classes, and record structs, then explains the example and the reference comparison of array properties. The quoted paragraph no longer appears. The inheritance section also preserves the run-time-type distinction.

An owned .NET 8/.NET 10 fixture confirmed that equal-content but distinct arrays don't make two records equal, a shared array can, and a derived record isn't equal to its base-record counterpart.

**Suggested closure explanation:** Close the specific edit-pass request as addressed by the current introduction and examples. Don't describe record equality as recursive collection equality or rely on another open type-comparison PR to supply text that's already present.

### dotnet/docs#44496: Azure DevOps for Agile System of Systems

**Opened:** January 23, 2025. **Confidence:** High for repository scope. **Reason:** The proposal explicitly targets Azure DevOps documentation, not .NET documentation.

The proposed TOC location is **Learn / Azure / Azure DevOps / Azure DevOps for Agile SoS**. Its abstract concerns Azure DevOps, digital-thread coordination, and OpsHub Integration Manager, without a .NET API, runtime, language, or application-development task. The appropriate destination is the [Azure DevOps documentation](https://learn.microsoft.com/azure/devops/), subject to that team's content and third-party-product policies.

**Suggested closure explanation:** Close as a proposal for a different documentation set and direct the proposer to Azure DevOps content owners. Don't claim that the proposed article already exists, endorse its marketing or reliability claims, or transfer/create an issue without maintainer approval.

### dotnet/docs#44562: Replace the Prometheus endpoint mapping API

**Opened:** January 28, 2025. **Confidence:** High for API coexistence; package-execution limits noted below. **Reason:** The middleware API doesn't replace the endpoint-routing API used by the tutorial.

Current exporter source exposes both [MapPrometheusScrapingEndpoint](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry.Exporter.Prometheus.AspNetCore/PrometheusExporterEndpointRouteBuilderExtensions.cs) for endpoint routing and [UseOpenTelemetryPrometheusScrapingEndpoint](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry.Exporter.Prometheus.AspNetCore/PrometheusExporterApplicationBuilderExtensions.cs) for middleware. The [tutorial](../docs/core/diagnostics/observability-prgrja-example.md) uses a `WebApplication`, and merged [dotnet/docs#50357](https://github.com/dotnet/docs/pull/50357) already adds the required `--prerelease` package-install flag.

Owned .NET 8/.NET 10 applications served `/metrics` successfully with either API and returned the recorded counter value `3`. Those executions used exporter `1.9.0-beta.2`, available on the official Microsoft mirror. The repository's `1.16.0-beta.1` dependency wasn't available there, so they aren't a build claim for the tutorial's exact current dependency set.

**Suggested closure explanation:** Retain the valid endpoint-routing form and explain the two integration styles. Don't replace a supported API merely because the middleware alternative also works. A failure with a specific restored package set needs its actual versions and compiler/runtime diagnostic.

### dotnet/docs#44568: .NET agent ecosystem overview

**Opened:** January 28, 2025. **Confidence:** High. **Reason:** Current ecosystem and agent guidance supply the requested selection overview.

The [.NET AI ecosystem overview](../docs/ai/dotnet-ai-ecosystem.md) now provides an objective-to-technology table, describes the libraries and their roles, distinguishes direct model calls from agent orchestration, and compares a prebuilt Copilot SDK harness with Microsoft Agent Framework. The [agents article](../docs/ai/conceptual/agents.md) explains agent/workflow patterns. The linked [Agent Framework overview](https://learn.microsoft.com/agent-framework/overview/) supplies C# package/start instructions and explicitly identifies the framework as the successor to AutoGen and Semantic Kernel.

**Suggested closure explanation:** Link to the maintained ecosystem selection guide and agent concepts rather than add another overview based on the 2025 framework landscape. Don't present an ordinary MEAI chat call as a multi-agent framework or imply that every provider package has identical maturity.

### dotnet/docs#44569: New .NET multi-agent tutorial using AutoGen

**Opened:** January 28, 2025. **Confidence:** High for the changed product direction. **Reason:** The requested framework-specific investment has been superseded by official successor guidance.

The current [AutoGen project README](https://github.com/microsoft/autogen) explicitly says that the project is no longer maintained and directs new users to Microsoft Agent Framework. That statement concerns the project's maintenance policy; the repository's live GitHub `archived` flag was still `false` when checked. The [Agent Framework overview](https://learn.microsoft.com/agent-framework/overview/) confirms the succession and links migration guidance, while this repository's [agent concepts](../docs/ai/conceptual/agents.md) already describe multi-agent patterns and link to the current framework.

**Suggested closure explanation:** Close the new AutoGen-specific tutorial proposal as superseded and use the supported framework's .NET workflow documentation for new work. Don't claim that dotnet/docs shipped the originally requested AutoGen tutorial, that all old AutoGen applications stop working, or that a migration was executed during triage.

### dotnet/docs#44687: CI guidance for multiple test projects

**Opened:** February 5, 2025. **Confidence:** High for the current SDK workflow. **Reason:** Current MTP guidance covers solution-wide execution without a per-project command list.

The [run/debug guide's CI tab](../docs/core/testing/microsoft-testing-platform-run-and-debug.md) now includes `dotnet test` and the MTP-aware Azure Pipelines task. Its linked [runner-selection guide](../docs/core/testing/unit-testing-with-dotnet-test.md#mtp-mode-of-dotnet-test) documents .NET 10 SDK/MTP 1.7-or-later requirements and `global.json`. The [MTP CLI reference](../docs/core/tools/dotnet-test-mtp.md) documents solution selection, built-module globbing, and `--max-parallel-test-modules`, whose default is the processor count.

**Suggested closure explanation:** Link to solution-wide MTP-mode `dotnet test` and the parallel-module option. A solution must include its test projects, and module-glob execution requires matching built modules. Don't promise the same dedicated mode on older SDKs, confuse module concurrency with test-case parallelism, or describe a sequential `foreach` loop as the resolution.

### dotnet/docs#44751: Add .NET AI template documentation

**Opened:** February 11, 2025. **Confidence:** High for the original quickstart/setup request. **Reason:** The template quickstart and provider-specific environment instructions now exist.

The [AI template quickstart](../docs/ai/quickstarts/ai-templates.md) includes template installation, project creation, configuration, and a run/test walkthrough. Its actual [Azure OpenAI include](../docs/ai/quickstarts/includes/ai-templates-azure-openai.md) explains model deployments, developer authentication, roles, and the endpoint setting. The [OpenAI](../docs/ai/quickstarts/includes/ai-templates-openai.md) and [Ollama](../docs/ai/quickstarts/includes/ai-templates-ollama.md) includes supply their corresponding prerequisites, credentials or local models, and creation workflows.

**Suggested closure explanation:** The requested initial template onboarding documentation is published. Coordinate closure with existing owners `JeremyLikness` and `alexwolfmsft`. Don't describe the local-vector-store walkthrough as instructions for the separately proposed Azure AI Search variant, or claim that a paid cloud deployment or local model run was performed during triage. The minimal non-template RAG requests remain separate.

### dotnet/docs#45064: Add ASP.NET Core authentication and authorization metrics

**Opened:** February 27, 2025. **Confidence:** High. **Reason:** The current metrics catalog explicitly documents the requested instruments.

The published [authentication and authorization metrics reference](https://learn.microsoft.com/aspnet/core/metrics/security?view=aspnetcore-10.0) documents `aspnetcore.authorization.attempts` and the authentication duration, challenge, forbid, sign-in, and sign-out instruments, including units and attributes. The [catalog entry point](https://learn.microsoft.com/aspnet/core/metrics/built-in?view=aspnetcore-10.0) links that reference and explicitly limits these metrics to ASP.NET Core 10.0 or later. Its source now lives in `dotnet/AspNetCore.Docs`, not the original local metrics file.

**Suggested closure explanation:** Link to the current catalog and security metrics page; the documentation-specific request is addressed. Don't infer .NET 8 availability from the original URL's version selector. The separate [dotnet/aspnetcore#60468](https://github.com/dotnet/aspnetcore/issues/60468) follow-up is closed as completed, but that status alone doesn't prove every OpenTelemetry normative specification changed.

### dotnet/docs#45073: Private-field naming in the C# specification

**Opened:** February 28, 2025. **Confidence:** High for source ownership. **Reason:** The proposed standards edit belongs in the canonical specification repository.

The published [attributes chapter](https://learn.microsoft.com/dotnet/csharp/language-reference/language-specification/attributes) identifies its source as [dotnet/csharpstandard's attributes chapter](https://github.com/dotnet/csharpstandard/blob/alpha-v13/standard/attributes.md). That source still contains `isInitialized`; the recommendation isn't a claim that the field was renamed. The specification is included from the standards repository rather than maintained in the reported `dotnet/docs` file.

**Suggested closure explanation:** Close here with a pointer to the canonical source for any editorial consistency proposal. An underscore prefix is a naming convention, not a C# validity requirement. Don't edit generated or absent content in this checkout, declare the example illegal, or transfer/file another issue without authorization.

### dotnet/docs#45327: C# tour challenge answers render raw directives

**Opened:** March 13, 2025. **Confidence:** High. **Reason:** All four current published answers contain rendered C# code.

The four original screenshots were inspected. The current published HTML for [Hello World](https://learn.microsoft.com/dotnet/csharp/tour-of-csharp/tutorials/hello-world), [numbers](https://learn.microsoft.com/dotnet/csharp/tour-of-csharp/tutorials/numbers-in-csharp), [branches and loops](https://learn.microsoft.com/dotnet/csharp/tour-of-csharp/tutorials/branches-and-loops), and [collections](https://learn.microsoft.com/dotnet/csharp/tour-of-csharp/tutorials/list-collection) now contains an actual `<pre><code class="lang-csharp">` answer inside each article's `<details>` element. None of those answer elements contains the literal `:::code` directive shown in the screenshots.

**Suggested closure explanation:** The four published challenge answers now render as code. No speculative markup change is needed. The evidence is the generated answer HTML for each affected page, not merely a changed snippet path or removal of the old interactive attribute.

### dotnet/docs#45927: Explain the SQLite base connection string

**Opened:** April 26, 2025. **Confidence:** High. **Reason:** The current page explicitly defines the placeholder and supplies a value.

The [connection-string guide](../docs/standard/data/sqlite/connection-strings.md) now explains that `baseConnectionString` represents an existing connection string and gives `Data Source=EncryptionSample.db` as an example. The same page describes the semicolon-separated keyword/value format and supported keywords.

**Suggested closure explanation:** Point to the explicit note and example rather than add another explanation of the same placeholder. Keep the existing warning that `Password` doesn't add encryption when the native SQLite library doesn't support it; clarifying a connection string isn't proof that an arbitrary SQLite build supports encryption.

### dotnet/docs#45956: Socket example compilation and complete projects

**Opened:** April 29, 2025. **Confidence:** High for the reported compilation/setup question. **Reason:** Complete projects exist, compile, and accompany explicit run instructions.

The [socket guide](../docs/fundamentals/networking/sockets/socket-services.md#run-the-sample-client-and-server) gives separate server/client run commands and says to start the server first. Its [server project](../docs/fundamentals/networking/snippets/socket/socket-server/socket-server.csproj) and [client project](../docs/fundamentals/networking/snippets/socket/socket-client/socket-client.csproj) include complete programs and reference the shared helper project. Both actual projects built successfully with SDK 10.0.403, with zero warnings and errors and all outputs redirected outside the checkout. The reporter also confirmed in the discussion that the code worked after placement in an async entry-point workflow.

**Suggested closure explanation:** Link the complete projects and the run section; the excerpt isn't intended to be pasted outside any entry point in an arbitrary legacy project. No remaining compiler diagnostic is supplied. These build results don't certify the helper's network-address selection, arbitrary port availability, or a full network exchange, and don't imply TCP preserves application-message boundaries.

### dotnet/docs#46045: Spanish SLM abbreviation

**Opened:** May 7, 2025. **Confidence:** High. **Reason:** The reported translation is corrected in the published localized page.

The current [Spanish .NET 9 overview](https://learn.microsoft.com/es-es/dotnet/core/whats-new/dotnet-9/overview) uses `SLM y LLM`, not the reported `SLA`, in its AI discussion. The live localized text was checked directly; the recommendation doesn't depend on access to the internal translation work item mentioned in the discussion.

**Suggested closure explanation:** The published Spanish abbreviation is now correct. No English source edit or additional translation request is needed for this specific typo. Don't infer the status of unrelated localized passages.

### dotnet/docs#46061: Register a dependency twice to choose its lifetime

**Opened:** May 9, 2025. **Confidence:** High. **Reason:** Existing guidance answers the question, and the proposed automatic lifetime selection isn't container behavior.

The [registration guide](../docs/core/extensions/dependency-injection/service-registration.md) explains that a single-service lookup uses the last registration, while `IEnumerable<T>` retains all registrations. The [scoped-background-service tutorial](../docs/core/extensions/scoped-service.md) supplies the supported explicit-scope pattern. An isolated .NET 8/.NET 10 fixture verified both scoped/singleton registration orders: the last descriptor controlled cross-scope identity, and scope validation rejected root resolution when the last descriptor was scoped.

**Suggested closure explanation:** Registering the same dependency with two lifetimes doesn't tell the container to select whichever lifetime suits a consumer. Keep the explicit async scope in the worker and link the existing registration and lifetime guidance. Don't recommend a service-locator fallback or claim that build-time validation catches every factory or runtime configuration error.

### dotnet/docs#47086: Thread safety of dependency-injection resolution

**Opened:** July 3, 2025. **Confidence:** High for the built-in container question. **Reason:** The current guidance explicitly answers the question and distinguishes container safety from service-instance safety.

The [DI thread-safety section](../docs/core/extensions/dependency-injection/guidelines.md#thread-safety) now says that concurrent resolution from a built `IServiceProvider` or `IServiceScope` is safe for the built-in .NET container. Its note explicitly says that the guarantee doesn't make resolved objects thread-safe. [dotnet/docs#50123](https://github.com/dotnet/docs/pull/50123) merged the clarification; the current text was checked directly.

**Suggested closure explanation:** Link the existing explicit answer. The separate open [dotnet/docs#56682](https://github.com/dotnet/docs/pull/56682) adds similar guidance to the lifetime article, but that optional additional placement doesn't leave the original question unanswered. Don't add a universal implementation guarantee to the `IServiceProvider` interface remarks: third-party providers implement that interface too.

### dotnet/docs#47911: Relative and absolute codeBase locations

**Opened:** August 9, 2025. **Confidence:** High. **Reason:** The existing remarks already explain the requested distinction.

The [codeBase remarks](../docs/framework/configure-apps/file-schema/runtime/codebase-element.md#remarks) state that a strong-named assembly can use a local, intranet, or Internet location, while a private assembly's codebase must be relative to the application directory. The absolute HTTP example accompanies the strong-name identity case; it isn't a rule that every assembly requires an absolute URI.

**Suggested closure explanation:** Point to the existing strong-name/private-assembly distinction and relative-path rule. No source correction is necessary to answer the question. Keep the explanation limited to the .NET Framework configuration mechanism; don't promise arbitrary unsigned assemblies can load from absolute Internet URLs or imply modern .NET uses this configuration element.

### dotnet/docs#48204: Windows Update doesn't download a Framework preview

**Opened:** August 31, 2025. **Confidence:** High for documentation-scope routing, not the cause of the installation failure. **Reason:** The report requests Windows Update troubleshooting without identifying a documentation error.

The [August 26, 2025 release note](../docs/framework/release-notes/2025/08-26-august-cumulative-update-preview.md) provides the applicable update links and distinguishes the Windows offering KB from the .NET Framework update KB. The report supplies no failed documentation link, KB-specific correction, error code, or reproducible defect in that article. Microsoft's [Windows Update troubleshooting guidance](https://support.microsoft.com/en-us/windows/experience/windows-update-troubleshooter) is the appropriate support destination.

**Suggested closure explanation:** Route the download/install problem to Windows Update support with the OS version, exact KB, and error code. Don't claim that the preview installed, that supersedence caused the failure, or that a release note's lack of known issues disproves the user's experience. No documentation-only change is established by this report.

### dotnet/docs#48677: TestContext.CancellationToken doesn't exist

**Opened:** September 23, 2025. **Confidence:** High for the current API. **Reason:** The property now exists, and the reporter confirms the version-dependent discrepancy is resolved.

The current [MSTEST0049 guide](../docs/core/testing/mstest-analyzers/mstest0049.md) uses `TestContext.CancellationToken`. Current `microsoft/testfx` source defines that public property as `CancellationTokenSource.Token`; the discussion links the introducing commit and includes the reporter's acknowledgment that the code is now correct.

**Suggested closure explanation:** The current property name is valid. Readers on an older package need the corresponding older API or an appropriate MSTest package update, not a blanket replacement of today's documentation with `CancellationTokenSource`. The analyzer's introduction version doesn't prove that every later convenience API existed in that same release. The recommendation relies on source and the reporter's confirmation, not the screenshot alone.

### dotnet/docs#49427: MCP quickstart's chat-client adapter method

**Opened:** October 23, 2025. **Confidence:** High for the reported missing method. **Reason:** The current method exists and the actual sample compiles.

The [MCP quickstart](../docs/ai/quickstarts/build-mcp-client.md) includes `Microsoft.Extensions.AI.OpenAI`, and its [program](../docs/ai/quickstarts/snippets/mcp-client/program.cs) imports `Microsoft.Extensions.AI` and calls `AsIChatClient()`, not `AsIChat`. Current upstream source declares that extension for the OpenAI `ChatClient` returned by `GetChatClient`. The actual pinned [project](../docs/ai/quickstarts/snippets/mcp-client/MinimalMCPClient.csproj) built with zero warnings and errors under SDK 10.0.403.

**Suggested closure explanation:** The adapter is available with the documented package and namespace; no method-renaming edit is needed. The build doesn't establish that the placeholder endpoint, transport command, credentials, or remote tool invocation work. No MCP server or paid model call was launched.

### dotnet/docs#50400: Update the MEAI experimental diagnostic IDs

**Opened:** December 9, 2025. **Confidence:** High for the linked decision. **Reason:** The upstream outcome retains the shared ID and the existing diagnostic reference reflects it.

[dotnet/extensions#7116](https://github.com/dotnet/extensions/pull/7116) merged on January 16, 2026. It groups experiments behind feature-specific source constants but deliberately keeps their public diagnostic ID as `MEAI001`. The current [canonical diagnostics list](https://github.com/dotnet/extensions/blob/main/docs/list-of-diagnostics.md#experiments) lists `MEAI001` for AI experiments, and the local [image-generation guide](../docs/ai/quickstarts/text-to-image.md) uses that same ID.

**Suggested closure explanation:** No migration to newly numbered MEAI diagnostics resulted from the linked PR. Keep the existing shared-ID guidance; don't mistake internal constant names for new public warning codes or invent a family of numbered documentation pages. This doesn't assert that every experimental API remains experimental indefinitely.

### dotnet/docs#50562: CacheSignal's initial semaphore count

**Opened:** December 12, 2025. **Confidence:** High for the reported startup-order claim. **Reason:** The report overlooks the producer's startup acquisition.

The actual [CacheWorker.StartAsync](../docs/core/extensions/snippets/caching/memory-worker/CacheWorker.cs) acquires the initial permit before it starts background work. The [program](../docs/core/extensions/snippets/caching/memory-worker/Program.cs) awaits host startup before it reads through `PhotoService`. An owned .NET 8/.NET 10 fixture compiled the actual worker, signal, consumer, and photo types; two consumers both remained blocked until a controlled HTTP response populated the cache, then each received one photo.

**Suggested closure explanation:** Changing only the initial count from one to zero would block the worker's own startup acquisition. The existing startup sequence addresses the stated premature-read claim; a `TaskCompletionSource` redesign isn't required for that reason. The fixture covers successful initialization, not every failure path: the worker releases in `finally`, so don't reinterpret this recommendation as an unconditional guarantee that HTTP failure or empty data always yields a populated cache.

### dotnet/docs#51291: Explicit missing files in the command-line tutorial

**Opened:** January 23, 2026. **Confidence:** High for the current final-stage sample. **Reason:** Explicit arguments now receive separate validation.

The [tutorial](../docs/standard/commandline/get-started-tutorial.md) now distinguishes `DefaultValueFactory`, which supplies an omitted option's value, from `CustomParser`, which validates an explicitly supplied filename. The actual final-stage source rejects a nonexistent file before the action runs. The preceding batch executed that source with `System.CommandLine` 2.0.12 and confirmed a parser error instead of the reported file-open stack trace.

**Suggested closure explanation:** The missing-file defect is addressed by the current parser and explanation. Close the original exception report, not the separate remaining nullability task in dotnet/docs#46915. Retain current owner `gewarren`; don't claim the default-value factory validates explicit arguments.

### dotnet/docs#51988: Document the unsafe evolution preview

**Opened:** March 3, 2026. **Confidence:** High for the requested documentation coverage. **Reason:** The preview model and compilation opt-ins are now documented.

The [unsafe-code reference](../docs/csharp/language-reference/unsafe-code.md) now explains requires-unsafe contracts, safe boundaries, relaxed pointer operations, unsafe expressions, field-layout requirements, interop declarations, and the `safe` keyword. The [compiler-option guidance](../docs/csharp/language-reference/compiler-options/language.md#enable-the-updated-memory-safety-rules) distinguishes `LangVersion=preview`, `AllowUnsafeBlocks`, and the separate `updated-memory-safety-rules` opt-in, including mixed-model callers and callees. The C# 15 overview links to that coverage.

**Suggested closure explanation:** The requested expansion beyond the initial compiler announcement now exists. Preserve `BillWagner`'s ownership and the explicit preview/version qualifications; this recommendation doesn't declare the memory-safety model stable or certify every example against every compiler build.

### dotnet/docs#52980: Separate command hierarchy from recursive options

**Opened:** April 10, 2026. **Confidence:** High for the stated scope/confusion. **Reason:** The current stages already separate the concepts and explain their combination.

The [current tutorial](../docs/standard/commandline/get-started-tutorial.md) starts with one root command and one option. Its next command stage explicitly removes the option from the root and attaches it to `read`. Only the later multi-command stage moves `read` beneath `quotes`, makes the shared file option recursive, displays the command hierarchy, and explains that root placement makes the option available to all subcommands. These aren't competing invocation pipelines.

**Suggested closure explanation:** The current staged walkthrough and explicit scope explanation answer the original mental-model concern. Link to those stages and the syntax guide. A preference for a larger chapter reorganization isn't evidence that recursive option scope remains unexplained. Retain owner `gewarren`.

### dotnet/docs#53522: Replace the obsolete OneOrMore union example

**Opened:** May 1, 2026. **Confidence:** High for the reported example. **Reason:** The current reference no longer uses that example.

The [union reference](../docs/csharp/language-reference/builtin-types/union.md) and its referenced snippets now use the refreshed union model rather than the reported `OneOrMore` example. [dotnet/docs#54198](https://github.com/dotnet/docs/pull/54198) merged on June 10, 2026. The actual current union snippet project built with the installed .NET 11 RC 3 SDK with zero warnings and errors.

**Suggested closure explanation:** The defective example was superseded by the merged reference refresh. Link to the current examples instead of repairing retired syntax. The project build corroborates the current source, not every preview compiler or the entire union specification.

### dotnet/docs#53990: Explain why the forecast displays known actual values

**Opened:** May 21, 2026. **Confidence:** High. **Reason:** The tutorial and source distinguish training from held-out comparison.

The [forecasting tutorial](../docs/machine-learning/tutorials/time-series-demand-forecasting.md) explains the first-year/second-year split and evaluates predictions against observations. Its [actual sample program](https://github.com/dotnet/machinelearning-samples/blob/main/samples/csharp/getting-started/Forecasting_BikeSharingDemand/BikeDemandForecasting/Program.cs) fits the model to `firstYearData`, evaluates `secondYearData`, and displays held-out actual rentals alongside the forecast. The display function calls `Predict()` before it reads actual values for the comparison output.

**Suggested closure explanation:** Known held-out observations provide a comparison for a forecasting demonstration; their presence in the database doesn't make the displayed forecast a database lookup or mean the model trained on the second year. Link to the existing split, evaluation, and forecast explanations. No LocalDB training run or model-accuracy claim was made during triage.

### dotnet/docs#54001: Document the updated union member-provider model

**Opened:** May 22, 2026. **Confidence:** High for the requested reference coverage. **Reason:** The current guide describes and demonstrates the updated model.

The [union reference](../docs/csharp/language-reference/builtin-types/union.md) now explains member providers and `TryGetValue`, with article-relative implementation and usage snippets. The merged [reference refresh](https://github.com/dotnet/docs/pull/54198) postdates this request, and the actual current snippet project built successfully with the installed .NET 11 RC 3 SDK.

**Suggested closure explanation:** The requested feature update is present in the reference and its compiled examples. Preserve the preview qualifications and any separate fundamentals work; don't reopen an already-covered reference update or infer release stability from a successful preview build.

### dotnet/docs#55458: Route the unspecified runtime/server-error report

**Opened:** August 17, 2026. **Confidence:** Medium; maintainer confirmation is appropriate. **Reason:** The report supplies no actionable documentation correction.

The issue says only that a website/application has a runtime/server error. It doesn't identify an incorrect statement, a failing documentation sample, an error trace, or reproduction steps. The attached upgrade-assistance page metadata alone doesn't establish a documentation defect.

**Suggested closure explanation:** Close as nonactionable documentation feedback, not as proof that the server or application was repaired. For an application problem, direct the reporter to [Microsoft Q&A](https://learn.microsoft.com/answers/); for a Learn-site failure, request the actual affected URL and site-feedback details through the appropriate support channel. Reopen if the reporter supplies a specific documentation defect.

### dotnet/docs#56114: Redesign upgrade guidance for multiple technologies

**Opened:** September 17, 2026. **Confidence:** High for the requested content/navigation redesign. **Reason:** The current documentation already separates shared workflows from technology-specific guidance.

The [upgrade overview](../docs/core/porting/github-copilot-upgrade/overview.md) now introduces technology packs and explicitly supports .NET, JavaScript, and TypeScript. The [TOC](../docs/core/porting/github-copilot-upgrade/toc.yml) has separate .NET and JavaScript/TypeScript branches. Dedicated [JavaScript/TypeScript guidance](../docs/core/porting/github-copilot-upgrade/javascript-typescript-overview.md) links dependency upgrades, compiler upgrades, and application validation; the [capability reference](../docs/core/porting/github-copilot-upgrade/javascript-typescript-capabilities.md) and [.NET scenarios/skills reference](../docs/core/porting/github-copilot-upgrade/dotnet-scenarios-and-skills.md) describe their respective workflows.

**Suggested closure explanation:** The requested multilanguage structure and technology-specific capability inventory are present. Retain owner `adegeo` for final confirmation against the associated work item; identify any newly missing capability separately instead of keeping the original redesign open indefinitely. This recommendation verifies documentation coverage, not execution of every upgrade scenario or every future plugin release.

### dotnet/docs#56527: Route Android VNDK material outside the ML.NET article

**Opened:** October 22, 2026. **Confidence:** High. **Reason:** The submitted content concerns another platform's documentation.

The issue describes Android `ro.vndk.version`, `BOARD_VNDK_VERSION`, and vendor APEX libraries. The linked [ML.NET Model Builder article](../docs/machine-learning/automate-training-with-model-builder.md) instead explains Visual Studio model creation, AutoML scenarios, generated model artifacts, and predictions. The maintainer's translation confirms the Android-specific subject; it doesn't identify a missing Model Builder step.

**Suggested closure explanation:** Close as feedback filed against the wrong documentation set and direct any concrete Android platform correction to the relevant [AOSP documentation](https://source.android.com/docs/core/architecture). Don't insert unrelated VNDK instructions into ML.NET guidance or claim the submitted Android versioning rules were validated.
