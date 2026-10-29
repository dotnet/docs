> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase M: Delegates (§21)

### PR 43 — Delegate values and callable behavior

Retain `docs/csharp/fundamentals/types/delegates-lambdas.md` as the canonical beginner introduction. Explicitly expose the Delegates checkpoint in the approved standard-aligned learning path without writing a competing introduction. Keep the shipped Build software lambda guide in place; this task doesn't require another language-foundations home.

Harvest the applicable subset of `programming-guide/delegates/{index,using-delegates,delegates-with-named-vs-anonymous-methods}.md` and consuming examples from `concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md`.

- Teach `Func<>`/`Action<>`, method-group and lambda assignment, invocation, and passing behavior, with ordinary named-method alternatives.
- Link PR #56333's practical lambda guide for capture, static lambdas, and local-helper comparisons. BS04 owns API-choice guidance.
- Preserve custom delegate declarations, multicast return/exception rules, and full variance mechanics in reference/advanced homes. A named phase doesn't override the existing limited delegate scope.
- Done when the introduction, Building software guides, and complete reference have distinct roles and legacy delegate sources have an explicit preservation/retirement disposition.

### PR 44 — Basic events

This takes the events portion of legacy PR 31. Planned destination: `fundamentals/delegates/events.md`; resolve the final location and source split during assigned work before moving existing sources, after the Phase G namespace checkpoint.

Harvest `programming-guide/events/{index,how-to-subscribe-to-and-unsubscribe-from-events}.md`.

- Demonstrate subscribing, raising a standard event, and unsubscribing with the same handler identity. Explain the publisher/subscriber relationship before naming it.
- BS04 compares a supplied callback with a publisher-owned notification. Don't imply every lambda subscription can later be removed by writing an equivalent new lambda.
- Route custom accessors, explicit interface events, derived-class event extensibility, weak events, and threading rules to existing reference/advanced material.
- Done when the full subscribe/raise/unsubscribe lifecycle runs, the standard pattern is clear without custom delegate/multicast internals, and every migrated snippet and URL is accounted for.

### Execution and focused verification

Enter after L; deliver PR 43 → PR 44, then N. H's methods/classes are the baseline.
The live lambda guide remains the depth owner for its practical coverage; BS04's later comparison
doesn't block either mechanics article.

| Unit | Reader outcome / observable sample | Source preservation |
|---|---|---|
| PR 43 | Assign the same compatible named method and lambda to `Func<>`/`Action<>`, invoke/pass them, and compare equal output. Define delegate type versus delegate value before natural-type inference. | The named/anonymous source's custom declarations, anonymous-method syntax, multicast cautions, and full variance detail route to reference/BS12; don't copy them wholesale or imply every method group has an unambiguous inferred type. |
| PR 44 | Subscribe a stored handler, raise a standard `EventHandler` event, unsubscribe, and verify no later notification reaches that handler. | Extract programmatic subscription/handler identity from the source how-to; IDE/Windows Forms designer procedures require a named UI preservation route, not a new general tutorial. BS04 needs subscription ownership; BS12 holds advanced/custom event material. |

Before creating the proposed event article, reconcile the event orientation already in
`types/delegates-lambdas.md`; keep a short route there rather than two lifecycle lessons.
Retire a mixed delegate/event source only after its foundation, applied, and advanced consumers
are accounted for. Apply the [shared move/verification contract](verification-and-decisions.md).
