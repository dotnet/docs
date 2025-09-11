---
title: Responsible AI with .NET
description: Learn what responsible AI is and how you can use .NET to evaluate the safety of your AI apps.
ms.date: 09/08/2025
ai-usage: ai-assisted
---

# Responsible AI with .NET

*Responsible AI* refers to the practice of designing, developing, and deploying artificial intelligence systems in a way that is ethical, transparent, and aligned with human values. It emphasizes fairness, accountability, privacy, and safety to ensure that AI technologies benefit individuals and society as a whole. As AI becomes increasingly integrated into applications and decision-making processes, prioritizing responsible AI is of utmost importance.

Microsoft has identified [six principles](https://www.microsoft.com/ai/responsible-ai) for responsible AI:

- Fairness
- Reliability and safety
- Privacy and security
- Inclusiveness
- Transparency
- Accountability

If you're building an AI app with .NET, the [📦 Microsoft.Extensions.AI.Evaluation.Safety](https://www.nuget.org/packages/Microsoft.Extensions.AI.Evaluation.Safety) package provides evaluators to help ensure that the responses, both text and image, that your app generates meet the standards for responsible AI. The evaluators can also detect problematic content in user input. These safety evaluators use the [Azure AI Foundry evaluation service](/azure/ai-foundry/concepts/evaluation-evaluators/risk-safety-evaluators) to perform evaluations. They include metrics for hate and unfairness, groundedness, ungrounded inference of human attributes, and the presence of:

- Protected material
- Self-harm content
- Sexual content
- Violent content
- Vulnerable code (text-based only)
- Indirect attacks (text-based only)

For more information about the safety evaluators, see [Safety evaluators](libraries.md#safety-evaluators). To get started with the Microsoft.Extensions.AI.Evaluation.Safety evaluators, see [Tutorial: Evaluate response safety with caching and reporting](evaluate-safety.md).

## See also

- [Responsible AI at Microsoft](https://www.microsoft.com/ai/responsible-ai)
- [Training: Embrace responsible AI principles and practices](/training/modules/embrace-responsible-ai-principles-practices/)
- [Azure AI Foundry evaluation service](/azure/ai-foundry/concepts/evaluation-evaluators/risk-safety-evaluators)
- [Azure AI Content Safety](/azure/ai-services/content-safety/overview)
