> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase M: Delegates (§21)

### PR 43 — Delegate values and callable behavior

Retain `docs/csharp/fundamentals/types/delegates-lambdas.md` as the canonical beginner introduction. Explicitly expose the Delegates checkpoint in the proposed standard-aligned learning path without writing a competing introduction.

Harvest the applicable subset of `programming-guide/delegates/{index,using-delegates,delegates-with-named-vs-anonymous-methods}.md` and consuming examples from `concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md`.

- Teach `Func<>`/`Action<>`, method-group and lambda assignment, invocation, and passing behavior, with ordinary named-method alternatives.
- Link PR #56333's practical lambda guide for capture, static lambdas, and local-helper comparisons. BS04 owns API-choice guidance.
- Preserve custom delegate declarations, multicast return/exception rules, and full variance mechanics in reference/advanced homes. A named phase doesn't override the existing limited delegate scope.
- Done when the introduction, Building software guides, and complete reference have distinct roles and legacy delegate sources have an explicit preservation/retirement disposition.

### PR 44 — Basic events

This takes the events portion of legacy PR 31. Proposed destination: `fundamentals/delegates/events.md`; approve the location before moving existing sources.

Harvest `programming-guide/events/{index,how-to-subscribe-to-and-unsubscribe-from-events}.md`.

- Demonstrate subscribing, raising a standard event, and unsubscribing with the same handler identity. Explain the publisher/subscriber relationship before naming it.
- BS04 compares a supplied callback with a publisher-owned notification. Don't imply every lambda subscription can later be removed by writing an equivalent new lambda.
- Route custom accessors, explicit interface events, derived-class event extensibility, weak events, and threading rules to existing reference/advanced material.
- Done when the full subscribe/raise/unsubscribe lifecycle runs, the standard pattern is clear without custom delegate/multicast internals, and every migrated snippet and URL is accounted for.

**Dependencies:** existing delegate introduction and class/property vocabulary. Event comparison work need not block the mechanics article. Apply the [shared move/verification contract](verification-and-decisions.md).
