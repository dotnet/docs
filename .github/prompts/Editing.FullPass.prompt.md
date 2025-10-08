---
model: Claude Sonnet 4 (copilot)
mode: agent
description: "Performs comprehensive editing pass following Microsoft Style Guide"
---

# Article Editing Instructions for LLMs

You are performing an edit pass on a Microsoft documentation article. Your MANDATORY goal is to aggressively transform the content to follow the Microsoft Style Guide while preserving technical accuracy and meaning.

## EDITING APPROACH - FOLLOW THIS METHODOLOGY

1. **Read the entire document first**
2. **Systematically scan for PATTERNS, not just exact matches** - The examples below represent common patterns; look for similar constructions throughout
3. **Apply ALL transformations aggressively** - Don't skip patterns just because they're not exactly like the examples
4. **Focus especially on voice, tense, and weak constructions** - These are the most commonly missed transformations
5. **Be thorough in pattern recognition** - If you see "There are many ways to", treat it the same as "There are several ways to"
6. **Simplify aggressively while preserving meaning** - When in doubt, choose the simpler, more direct alternative

## PATTERN EXAMPLES FOR RECOGNITION

**Voice Patterns to Convert:**
- Any "X is/are done by Y" → "Y does X" 
- Any "X can be done" → "Do X" or "You can do X"
- Any "X will be created" → "X creates" or "Create X"

**Instruction Patterns to Convert:**
- Any "You can/should/might/need to [verb]" → "[Verb]"
- Any "It's possible to [verb]" → "[Verb]" or "You can [verb]"
- Any "You have the option to" → "You can" or direct command

**Tense Patterns to Convert:**
- Any "will/would [verb]" in descriptions → "[verb]s" or "[verb]"
- Any "This would happen" → "This happens"

## CRITICAL RULES - Follow These First

1. **Code Protection**: NEVER edit code within code blocks. Only edit code comments if necessary.
2. **AI Disclosure**: If the `ai-usage` frontmatter is missing, add `ai-usage: ai-assisted`.
3. **Preserve Meaning**: Never change the technical meaning or accuracy of content.
4. **Markdown Structure**: Maintain existing markdown formatting and structure.

## MANDATORY TRANSFORMATIONS - Apply These Aggressively

You MUST systematically scan the entire document and apply ALL of these transformations. Do not skip any that apply:

## Primary Edit Targets

When editing, focus on these areas in order of priority:

### 1. VOICE AND TENSE - MANDATORY FIXES

**SCAN FOR AND CONVERT ALL PASSIVE VOICE to active voice (these are examples - find ALL similar patterns):**
- ❌ "The method can be called" → ✅ "Call the method"
- ❌ "Settings are configured by..." → ✅ "Configure the settings..."
- ❌ "This can be done by..." → ✅ "Do this by..." or "To do this..."
- ❌ "The file will be created" → ✅ "The system creates the file" or "Create the file"
- Look for ANY pattern with: "is/are/was/were + past participle", "can be + verb", "will be + verb"

**SCAN FOR AND CONVERT ALL weak instruction language to imperative mood (these are examples - find ALL similar patterns):**
- ❌ "You can call the method" → ✅ "Call the method"
- ❌ "You should configure" → ✅ "Configure"
- ❌ "You need to set" → ✅ "Set"
- ❌ "You might want to" → ✅ "Consider" or direct command
- Look for ANY pattern with: "You can/should/need to/might want to/have to + verb"

**SCAN FOR AND CONVERT ALL future tense to present tense for descriptions (these are examples - find ALL similar patterns):**
- ❌ "This will create a file" → ✅ "This creates a file"
- ❌ "The application would start" → ✅ "The application starts"
- ❌ "You would see the result" → ✅ "You see the result"
- Look for ANY pattern with: "will/would/shall + verb" in descriptions

**SCAN FOR AND CONVERT ALL present perfect tense with simple present tense (these are examples - find ALL similar patterns):**
- ❌ "The system has processed the data" → ✅ "The system processes the data"
- ❌ "You have configured the settings" → ✅ "Configure the settings"
- ❌ "The service has been running" → ✅ "The service runs"
- ❌ "Once you have completed the setup" → ✅ "Once you complete the setup"
- Look for ANY pattern with: "have/has + past participle", "have/has been + verb-ing"

**SCAN FOR AND ELIMINATE ALL weak constructions (these are examples - find ALL similar patterns):**
- ❌ "There are three ways to..." → ✅ "Use these three methods..."
- ❌ "It's possible to..." → ✅ "You can..." or start with the action
- ❌ "One way to do this is..." → ✅ "To do this..."
- ❌ "What this means is..." → ✅ "This means..."
- Look for ANY pattern starting with: "There are/is", "It's possible", "One way", "What this"

### 2. CONTRACTIONS - MANDATORY ADDITIONS

**SCAN FOR AND ADD contractions wherever appropriate (these are examples - find ALL similar patterns):**
- ❌ "it is" → ✅ "it's"
- ❌ "you are" → ✅ "you're"  
- ❌ "do not" → ✅ "don't"
- ❌ "cannot" → ✅ "can't"
- ❌ "will not" → ✅ "won't"
- ❌ "does not" → ✅ "doesn't"
- ❌ "is not" → ✅ "isn't"
- ❌ "are not" → ✅ "aren't"
- ❌ "have not" → ✅ "haven't"
- ❌ "has not" → ✅ "hasn't"
- Look for ANY pattern with: full forms of common contractions

**NEVER use these awkward contractions:**
- ❌ "there'd", "it'll", "they'd", "would've"
- ❌ Noun + verb contractions like "Microsoft's developing"

### 3. WORD CHOICE - MANDATORY REPLACEMENTS

**SCAN FOR AND REPLACE verbose phrases (these are examples - find ALL similar patterns):**
- ❌ "make use of" → ✅ "use"
- ❌ "be able to" → ✅ "can"
- ❌ "in order to" → ✅ "to"
- ❌ "utilize" → ✅ "use"
- ❌ "eliminate" → ✅ "remove"
- ❌ "inform" → ✅ "tell"
- ❌ "establish connectivity" → ✅ "connect"
- ❌ "implement functionality" → ✅ "implement features" or "add functionality"
- ❌ "demonstrate how to" → ✅ "show how to"
- Look for ANY unnecessarily complex or verbose phrasing

**SCAN FOR AND REMOVE unnecessary words (these are examples - find ALL similar patterns):**
- ❌ "in addition" → ✅ "also"
- ❌ "as a means to" → ✅ "to"
- ❌ "for the purpose of" → ✅ "to"
- ❌ "with regard to" → ✅ "about" or "for"
- ❌ Remove filler words: "quite", "very", "easily", "simply" (unless essential)
- Look for ANY unnecessary prepositional phrases or filler words

**SCAN FOR AND ENSURE consistent terminology (apply this principle throughout):**
- Pick one term for each concept and use it throughout
- ❌ "Because" and "Since" mixed → ✅ "Because" consistently
- Choose "method" OR "function" consistently within a section
- Look for ANY inconsistent terminology for the same concept

### 4. SENTENCE STRUCTURE - MANDATORY IMPROVEMENTS

**ALWAYS break up long sentences:**
- Target maximum 20-25 words per sentence
- Split any sentence with multiple clauses
- ❌ "When you configure the settings, which are located in the main menu, you can customize the behavior that controls how the application responds to user input."
- ✅ "Configure the settings in the main menu. These settings customize how the application responds to user input."

**ALWAYS lead with key information:**
- Put the most important information first
- Front-load keywords for scanning
- ❌ "In the event that you need to configure the application, you should..." → ✅ "To configure the application..."
- ❌ "Before you can use the feature, you must..." → ✅ "Configure X before using the feature."

**ALWAYS make next steps obvious:**
- Use clear transitions
- Number steps when there's a sequence
- Start action items with verbs

### 5. FORMATTING - MANDATORY FIXES

**ALWAYS use sentence case for headings:**
- ❌ "How To Configure The Settings" → ✅ "How to configure the settings"
- ❌ "Using The API" → ✅ "Using the API"
- ❌ "Getting Started With The Framework" → ✅ "Getting started with the framework"

**ALWAYS fix punctuation:**
- Remove colons from headings: ❌ "Next steps:" → ✅ "Next steps"
- Periods in lists: Use periods for complete sentences over 3 words
- ❌ "Prerequisites." → ✅ "Prerequisites" (for short list items)

**ALWAYS use proper formatting:**
- **Bold** for UI elements: "Select **File** > **Open**"
- `Code style` for: file names, folders, API names, code elements
- Remove `https://learn.microsoft.com/en-us` from internal links

## MANDATORY WORD/PHRASE REPLACEMENTS

**SCAN THE ENTIRE DOCUMENT for these patterns and replace ALL instances (not just exact matches):**

| ❌ FIND AND REPLACE | ✅ ALWAYS Use Instead | Pattern to Look For |
|-------------|---------------|---------------------|
| "we", "our" (referring to Microsoft) | "the", "this", or direct statements | Any first-person plural |
| "may" (for possibility) | "might" | "may" when expressing possibility |
| "may" (for permission) | "can" | "may" when expressing permission |
| "etc.", "and so on" | "for example" or complete the list | Any open-ended list endings |
| "in order to" | "to" | Any purpose clauses |
| "be able to" | "can" | Any ability expressions |
| "make use of" | "use" | Any verbose action phrases |
| "There are several ways" | "Use these methods" | Any "There are..." constructions |
| "It's possible to" | "You can" or start with action | Any possibility statements |
| "You should" | Direct imperative or "Consider" | Any weak instruction language |
| "You can" (in instructions) | Direct imperative | Instructions that could be commands |
| "allows you to" | "lets you" | Any formal permission language |
| "provides the ability to" | "lets you" | Any verbose capability descriptions |

**PATTERN RECOGNITION INSTRUCTIONS:**
- These examples represent PATTERNS, not exhaustive lists
- Look for similar constructions and apply the same principles
- When in doubt, choose the simpler, more direct alternative
- Focus on the underlying pattern (passive vs active, verbose vs concise, formal vs conversational)

## LIST AND STRUCTURE RULES - MANDATORY

### Lists
- ALWAYS use Oxford comma: "Android, iOS, and Windows"
- ALWAYS number ordered lists as "1." for all items (not 1., 2., 3.)
- ALWAYS use periods for complete sentences in lists (if more than 3 words)
- ALWAYS replace "etc." with "for example" or complete the list

### Spacing and Punctuation
- ALWAYS use one space after periods, colons, question marks
- ALWAYS use no spaces around dashes: "Use pipelines—logical groups—to consolidate"
- ALWAYS add blank lines around markdown elements (don't add extra if they exist)

## FINAL VALIDATION - MANDATORY CHECKS

After editing, you MUST verify:
- [ ] ALL passive voice converted to active voice
- [ ] ALL "you can/should" converted to imperative mood
- [ ] ALL future tense converted to present tense for descriptions
- [ ] ALL contractions added where appropriate
- [ ] ALL verbose phrases simplified
- [ ] ALL weak constructions eliminated
- [ ] Content maintains technical accuracy
- [ ] Tone is conversational and helpful
- [ ] Sentences are concise and scannable
- [ ] Formatting follows conventions
- [ ] No consecutive headings without content
- [ ] Code blocks are unchanged (except comments if needed)
