# Changelog

## 0.18.1

- Update dependencies (including `markdownlint`)

## 0.18.0

- Use user ID in Docker containers for security
- Update dependencies (including `markdownlint`)
- Remove support for end-of-life Node 18

## 0.17.2

- Update dependencies (including `markdownlint`)

## 0.17.1

- Update dependencies (including `markdownlint`)

## 0.17.0

- Convert to ECMAScript modules
- Use import() when loading modules
- Update dependencies (including `markdownlint`)

## 0.16.0

- Try not to use require for modules (due to Node 22.12)
- Update dependencies (EXcluding `markdownlint`)

## 0.15.0

- Add support for `stdin` input via `-` glob
- Add output formatter based on string templates
- Update dependencies (including `markdownlint`)

## 0.14.0

- Handle `--` parameter per POSIX convention
- Add support for glob to `gitignore` configuration
- Update dependencies (including `markdownlint`)

## 0.13.0

- Add `noBanner` and `gitignore` configuration options
- Reduce install size by switching to `js-yaml` package
- Add more detail to some error messages
- Export JSONC/YAML parsers for reuse
- Update dependencies (including `markdownlint`)

## 0.12.1

- Update JSONC parsing to handle trailing commas
- Add documentation links to JSON schema
- Update dependencies

## 0.12.0

- Remove deprecated `markdownlint-cli2-config` entry point
  - Use `markdownlint-cli2 --config ...` instead
- Remove deprecated `markdownlint-cli2-fix` entry point
  - Use `markdownlint-cli2 --fix ...` instead
- Add `--help` and `--no-globs` parameters
- Improve and document included JSON schemas
- Update dependencies (including `markdownlint`)

## 0.11.0

- Add `modulePaths` configuration option
- Update dependencies (including `markdownlint`)
- Remove support for end-of-life Node 16

## 0.10.0

- Add `showFound` configuration option
- Add `.markdownlint-cli2.jsonc` config schema
- Update dependencies (including `markdownlint`)

## 0.9.2

- Remove `npm-shrinkwrap.json` entirely to avoid `npm` failures

## 0.9.1

- Remove `devDependencies` from `npm-shrinkwrap.json` to avoid `npm` failures

## 0.9.0

- Add support for Node.js's `package.json` as a configuration file source
- Add output formatter for Static Analysis Results Interchange Format/SARIF
- Bundle `npm-shrinkwrap.json` for reproducible/faster installs
- Update dependencies (including `markdownlint`)

## 0.8.1

- Handle `--config` edge case

## 0.8.0

- Add support for `--config` and `--fix` parameters
- Update dependencies (including `markdownlint`)
- Remove support for end-of-life Node 14

## 0.7.1

- Update dependencies (including `markdownlint`)

## 0.7.0

- Add support for `extends` in `config` property of `.markdownlint-cli2.*` files
- Build and publish `davidanson/markdownlint-cli2-rules` Docker container image
- Update dependencies (including `markdownlint`)

## 0.6.0

- Update dependencies (including `markdownlint`)

## 0.5.1

- Update dependencies

## 0.5.0

- New rules
- Support modules (MJS) everywhere
- Include dotfiles

## 0.4.0

- New rules
- Async custom rules
- Explicit config
- CJS (breaking)

## 0.3.2

- Extensibility/Windows/consistency improvements

## 0.3.1

- Extensibility tweaks

## 0.3.0

- Add Docker container
- Update dependencies

## 0.2.0

- Improve handling of Windows paths using backslash

## 0.1.3

- Support rule collections

## 0.1.2

- Update use of `require` to be more flexible

## 0.1.1

- Restore previous use of `require`

## 0.1.0

- Simplify use of `require`
- Increment minor version

## 0.0.15

- Improve extensibility

## 0.0.14

- Update dependencies (including `markdownlint`)

## 0.0.13

- Add `markdownlint-cli2-fix` command

## 0.0.12

- Update dependencies (including `markdownlint`)

## 0.0.11

- Improve performance of `fix`
- Update banner

## 0.0.10

- Improve performance and configuration

## 0.0.9

- Improve configuration file handling

## 0.0.8

- Support `.markdownlint-cli2.yaml`
- Add progress

## 0.0.7

- Support `.markdownlint-cli2.js` and `.markdownlint.js`

## 0.0.6

- Improve handling of very large directory trees

## 0.0.5

- Improve support for ignoring files

## 0.0.4

- Support output formatters and `markdown-it` plugins

## 0.0.3

- Feature parity with `markdownlint-cli`

## 0.0.2

- Initial release
