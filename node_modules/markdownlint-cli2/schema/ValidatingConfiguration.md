# Validating Configuration

A [JSON Schema][json-schema] is provided to enable validating options objects:
[`markdownlint-cli2-config-schema.json`][markdownlint-cli2-config-schema]

Some editors automatically use a JSON Schema with files that reference it. For
example, a `.markdownlint-cli2.jsonc` file with:

```json
"$schema": "https://raw.githubusercontent.com/DavidAnson/markdownlint-cli2/main/schema/markdownlint-cli2-config-schema.json"
```

A JSON Schema validator can be used to check configuration files like so:

```bash
npx ajv-cli validate -s ./markdownlint-cli2/schema/markdownlint-cli2-config-schema.json -r ./markdownlint-cli2/schema/markdownlint-config-schema.json -d "**/.markdownlint-cli2.{jsonc,yaml}" --strict=false
```

A similar process is documented for validating `markdownlint` configuration
objects: [Validating Configuration][validating-configuration].

[json-schema]: https://json-schema.org
[markdownlint-cli2-config-schema]: markdownlint-cli2-config-schema.json
[validating-configuration]: https://github.com/DavidAnson/markdownlint/blob/main/schema/ValidatingConfiguration.md
