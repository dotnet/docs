# markdownlint-cli2

> A fast, flexible, configuration-based command-line interface for linting
> Markdown/CommonMark files with the `markdownlint` library

[![npm version][npm-image]][npm-url]
[![License][license-image]][license-url]

## Install

As a global CLI:

```bash
npm install markdownlint-cli2 --global
```

As a development dependency of the current [Node.js][nodejs] package:

```bash
npm install markdownlint-cli2 --save-dev
```

As a [Docker][docker] container image:

```bash
docker pull davidanson/markdownlint-cli2
```

As a global CLI with [Homebrew][homebrew]:

```bash
brew install markdownlint-cli2
```

As a [GitHub Action][github-action] via
[`markdownlint-cli2-action`][markdownlint-cli2-action]:

```yaml
- name: markdownlint-cli2-action
  uses: DavidAnson/markdownlint-cli2-action@v9
```

## Overview

- [`markdownlint`][markdownlint] is a library for linting [Markdown][markdown]/
  [CommonMark][commonmark] files on [Node.js][nodejs] using the
  [markdown-it][markdown-it] parser.
- [`markdownlint-cli`][markdownlint-cli] is a traditional command-line interface
  for `markdownlint`.
- [`markdownlint-cli2`][markdownlint-cli2] is a slightly unconventional
  command-line interface for `markdownlint`.
- `markdownlint-cli2` is configuration-based and prioritizes speed and
  simplicity.
- `markdownlint-cli2` supports all the features of `markdownlint-cli` (sometimes
  a little differently).
- [`vscode-markdownlint`][vscode-markdownlint] is a `markdownlint` extension for
  the [Visual Studio Code editor][vscode].
- `markdownlint-cli2` is designed to work well in conjunction with
  `vscode-markdownlint`.
- More about the [motivation for `markdownlint-cli2`][markdownlint-cli2-blog].

## Use

### Command Line

```text
markdownlint-cli2 vX.Y.Z (markdownlint vX.Y.Z)
https://github.com/DavidAnson/markdownlint-cli2

Syntax: markdownlint-cli2 glob0 [glob1] [...] [globN] [--config file] [--fix] [--help]

Glob expressions (from the globby library):
- * matches any number of characters, but not /
- ? matches a single character, but not /
- ** matches any number of characters, including /
- {} allows for a comma-separated list of "or" expressions
- ! or # at the beginning of a pattern negate the match
- : at the beginning identifies a literal file path
- - as a glob represents standard input (stdin)

Dot-only glob:
- The command "markdownlint-cli2 ." would lint every file in the current directory tree which is probably not intended
- Instead, it is mapped to "markdownlint-cli2 *.{md,markdown}" which lints all Markdown files in the current directory
- To lint every file in the current directory tree, the command "markdownlint-cli2 **" can be used instead

Optional parameters:
- --config    specifies the path to a configuration file to define the base configuration
- --fix       updates files to resolve fixable issues (can be overridden in configuration)
- --help      writes this message to the console and exits without doing anything else
- --no-globs  ignores the "globs" property if present in the top-level options object

Configuration via:
- .markdownlint-cli2.jsonc
- .markdownlint-cli2.yaml
- .markdownlint-cli2.cjs or .markdownlint-cli2.mjs
- .markdownlint.jsonc or .markdownlint.json
- .markdownlint.yaml or .markdownlint.yml
- .markdownlint.cjs or .markdownlint.mjs
- package.json

Cross-platform compatibility:
- UNIX and Windows shells expand globs according to different rules; quoting arguments is recommended
- Some Windows shells don't handle single-quoted (') arguments well; double-quote (") is recommended
- Shells that expand globs do not support negated patterns (!node_modules); quoting is required here
- Some UNIX shells parse exclamation (!) in double-quotes; hashtag (#) is recommended in these cases
- The path separator is forward slash (/) on all platforms; backslash (\) is automatically converted
- On any platform, passing the parameter "--" causes all remaining parameters to be treated literally

The most compatible syntax for cross-platform support:
$ markdownlint-cli2 "**/*.md" "#node_modules"
```

For scenarios where it is preferable to specify glob expressions in a
configuration file, the `globs` property of `.markdownlint-cli2.jsonc`, `.yaml`,
`.cjs`, or `.mjs` may be used instead of (or in addition to) passing
`glob0 ... globN` on the command-line.

As shown above, a typical command-line for `markdownlint-cli2` looks something
like:

```bash
markdownlint-cli2 "**/*.md" "#node_modules"
```

Because sharing the same configuration between "normal" and "fix" modes is
common, the `--fix` argument can be used to default the `fix` property (see
below) to `true` (though it can still be overridden by a configuration file):

```bash
markdownlint-cli2 --fix "**/*.md" "#node_modules"
```

In cases where it is not convenient to store a configuration file in the root
of a project, the `--config` argument can be used to provide a path to any
supported configuration file (except `package.json`):

```bash
markdownlint-cli2 --config "config/.markdownlint-cli2.jsonc" "**/*.md" "#node_modules"
```

The configuration file name must be (or end with) one of the supported names
above. For example, `.markdownlint.json` or `example.markdownlint-cli2.jsonc`.
The specified configuration file will be loaded, parsed, and applied as a base
configuration for the current directory - which will then be handled normally.

### Container Image

A container image [`davidanson/markdownlint-cli2`][docker-hub-markdownlint-cli2]
can also be used (e.g., as part of a CI pipeline):

```bash
docker run -v $PWD:/workdir davidanson/markdownlint-cli2:v0.18.1 "**/*.md" "#node_modules"
```

Notes:

- As when using the [command line][command-line], glob patterns are passed as
  arguments.
- This image is built on the official [Node.js Docker image][nodejs-docker].
  Per security best practices, the [default user `node`][nodejs-docker-non-root]
  runs with restricted permissions. If it is necessary to run as `root`, pass
  the `-u root` option when invoking `docker`.
- By default, `markdownlint-cli2` will execute within the `/workdir` directory
  *inside the container*. So, as shown above, [bind mount][docker-bind-mounts]
  the project's directory there.
  - A custom working directory can be specified with Docker's `-w` flag:

    ```bash
    docker run -w /myfolder -v $PWD:/myfolder davidanson/markdownlint-cli2:v0.18.1 "**/*.md" "#node_modules"
    ```

For convenience, the container image
[`davidanson/markdownlint-cli2-rules`][docker-hub-markdownlint-cli2-rules]
includes the latest versions of custom rules published to npm with the tag
[`markdownlint-rule`][markdownlint-rule]. These rules are installed globally
onto the base image `davidanson/markdownlint-cli2`.

**Note**: This container image exists for convenience and is not an endorsement
of the rules within.

### Exit Codes

- `0`: Linting was successful and there were no errors
- `1`: Linting was successful and there were errors
- `2`: Linting was not completed due to a runtime issue

## Rule List

- See the [Rules / Aliases][markdownlint-rules-aliases] and
  [Tags][markdownlint-rules-tags] sections of the `markdownlint` documentation.

## Glob expressions

- Globbing is performed by the [globby][globby] library; refer to that
  documentation for more information and examples.

## Configuration

- See the [Configuration][markdownlint-configuration] section of the
  `markdownlint` documentation for information about the inline comment syntax
  for enabling and disabling rules with HTML comments.
- In general, glob expressions should match files under the current directory;
  the configuration for that directory will apply to the entire tree.
  - When glob expressions match files *not* under the current directory,
    configuration for the current directory is applied to the closest common
    parent directory.
- Paths beginning with `~` are resolved relative to the user's home directory
  (typically `$HOME` on UNIX and `%USERPROFILE%` on Windows)
- There are two kinds of configuration file (both detailed below):
  - Configuration files like `.markdownlint-cli2.*` allow complete control of
    `markdownlint-cli2` behavior and are also used by `vscode-markdownlint`.
    - If multiple of these files are present in the same directory, only one is
      used according to the following precedence:
      1. `.markdownlint-cli2.jsonc`
      2. `.markdownlint-cli2.yaml`
      3. `.markdownlint-cli2.cjs`
      4. `.markdownlint-cli2.mjs`
      5. `package.json` (only supported in the current directory)
  - Configuration files like `.markdownlint.*` allow control over only the
    `markdownlint` `config` object and tend to be supported more broadly (such
    as by `markdownlint-cli`).
    - If multiple of these files are present in the same directory, only one is
      used according to the following precedence:
      1. `.markdownlint.jsonc`
      2. `.markdownlint.json`
      3. `.markdownlint.yaml`
      4. `.markdownlint.yml`
      5. `.markdownlint.cjs`
      6. `.markdownlint.mjs`
- The VS Code extension includes a [JSON Schema][json-schema] definition for the
  `JSON(C)` configuration files described below. This adds auto-complete and can
  make it easier to define proper structure.
- See [markdownlint-cli2-config-schema.json][markdownlint-cli2-config-schema]
  for that schema and [ValidatingConfiguration.md][validating-configuration] for
  ways to use it to validate configuration files.

### `.markdownlint-cli2.jsonc`

- The format of this file is a [JSONC][jsonc] object similar to the
  [`markdownlint` `options` object][markdownlint-options].
- Valid properties are:
  - `config`: [`markdownlint` `config` object][markdownlint-config] to configure
    rules for this part of the directory tree
    - If a `.markdownlint.{jsonc,json,yaml,yml,js}` file (see below) is present
      in the same directory, it overrides the value of this property
    - If the `config` object contains an `extends` property, it will be resolved
      the same as `.markdownlint.{jsonc,json,yaml,yml,js}` (see below)
  - `customRules`: `Array` of `String`s (or `Array`s of `String`s) of module
    names/paths of [custom rules][markdownlint-custom-rules] to load and use
    when linting
    - Relative paths are resolved based on the location of the `JSONC` file
    - Search [`markdownlint-rule` on npm][markdownlint-rule]
  - `fix`: `Boolean` value to enable fixing of linting errors reported by rules
    that emit fix information
    - Fixes are made directly to the relevant file(s); no backup is created
  - `frontMatter`: `String` defining the [`RegExp`][regexp] used to match and
    ignore any [front matter][front-matter] at the beginning of a document
    - The `String` is passed as the `pattern` parameter to the
      [`RegExp` constructor][regexp-constructor]
    - For example: `(^---\s*$[^]*?^---\s*$)(\r\n|\r|\n|$)`
  - `gitignore`: `Boolean` or `String` value to automatically ignore files
    referenced by `.gitignore` (or similar) when linting
    - When the value `true` is specified, all `.gitignore` files in the tree are
      imported (default `git` behavior)
    - When a `String` value is specified, that glob pattern is used to identify
      the set of ignore files to import
      - The value `**/.gitignore` corresponds to the `Boolean` value `true`
      - The value `.gitignore` imports only the file in the root of the tree;
        this is usually equivalent and can be much faster for large trees
    - This top-level setting is valid **only** in the directory from which
      `markdownlint-cli2` is run
  - `globs`: `Array` of `String`s defining glob expressions to append to the
    command-line arguments
    - This setting can be used instead of (or in addition to) passing globs on
      the command-line and offers identical performance
    - This setting is ignored when the `--no-globs` parameter is passed on the
      command-line
    - This top-level setting is valid **only** in the directory from which
      `markdownlint-cli2` is run
  - `ignores`: `Array` of `String`s defining glob expressions to ignore when
    linting
    - This setting has the best performance when applied to the directory from
      which `markdownlint-cli2` is run
      - In this case, glob expressions are negated (by adding a leading `!`) and
        appended to the command-line arguments before file enumeration
      - The setting is not inherited by nested configuration files in this case
    - When this setting is applied in subdirectories, ignoring of files is done
      after file enumeration, so large directories can negatively impact
      performance
      - Nested configuration files inherit and reapply the setting to the
        contents of nested directories in this case
  - `markdownItPlugins`: `Array` of `Array`s, each of which has a `String`
    naming a [markdown-it plugin][markdown-it-syntax-extensions] followed by
    parameters
    - Plugins can be used to add support for additional Markdown syntax
    - Relative paths are resolved based on the location of the `JSONC` file
    - For example: `[ [ "plugin-name", param_0, param_1, ... ], ... ]`
    - Search [`markdown-it-plugins` on npm][markdown-it-plugins]
  - `modulePaths`: `Array` of `String`s providing additional paths to use when
    resolving module references (e.g., alternate locations for `node_modules`)
  - `noBanner`: `Boolean` value to disable the display of the banner message and
    version numbers on `stdout`
    - This top-level setting is valid **only** in the directory from which
      `markdownlint-cli2` is run
    - Use with `noProgress` to suppress all output to `stdout` (i.e., `--quiet`)
  - `noInlineConfig`: `Boolean` value to disable the support of
    [HTML comments][html-comment] within Markdown content
    - For example: `<!-- markdownlint-disable some-rule -->`
  - `noProgress`: `Boolean` value to disable the display of progress on `stdout`
    - This top-level setting is valid **only** in the directory from which
      `markdownlint-cli2` is run
    - Use with `noBanner` to suppress all output to `stdout` (i.e., `--quiet`)
  - `outputFormatters`: `Array` of `Array`s, each of which has a `String`
    naming an [output formatter][output-formatters] followed by parameters
    - Formatters can be used to customize the tool's output for different
      scenarios
    - Relative paths are resolved based on the location of the `JSONC` file
    - For example: `[ [ "formatter-name", param_0, param_1, ... ], ... ]`
    - This top-level setting is valid **only** in the directory from which
      `markdownlint-cli2` is run
    - Search [`markdownlint-cli2-formatter` on npm][markdownlint-cli2-formatter]
  - `showFound`: `Boolean` value to display the list of found files on `stdout`
    - This top-level setting is valid **only** in the directory from which
      `markdownlint-cli2` is run and **only** when `noProgress` has not been set
- When referencing a module via the `customRules`, `markdownItPlugins`, or
  `outputFormatters` properties, each `String` identifier is passed to Node's
  [`require` function][nodejs-require] then (if that failed) its
  [`import` expression][nodejs-import-expression]
  - Importing a locally-installed module using a bare specifier (ex:
    `package-name`) or using a directory name (ex: `./package-dir`) will not
    work until [`import.meta.resolve`][nodejs-import-meta-resolve] is available
- Settings in this file apply to the directory it is in and all subdirectories.
- Settings **merge with** those applied by any versions of this file in a parent
  directory (up to the current directory).
- For example: [`.markdownlint-cli2.jsonc`][markdownlint-cli2-jsonc] with all
  properties set

### `.markdownlint-cli2.yaml`

- The format of this file is a [YAML][yaml] object with the structure described
  above for `.markdownlint-cli2.jsonc`.
- Other details are the same as for `.markdownlint-cli2.jsonc` described above.
- For example: [`.markdownlint-cli2.yaml`][markdownlint-cli2-yaml] with all
  properties set

### `.markdownlint-cli2.cjs` or `.markdownlint-cli2.mjs`

- The format of this file is a [CommonJS module][commonjs-module] (`.cjs`) or
  [ECMAScript module][ecmascript-module] (`.mjs`) that exports the object
  described above for `.markdownlint-cli2.jsonc` (directly or from a `Promise`).
- Instead of passing a `String` to identify the module name/path to load for
  `customRules`, `markdownItPlugins`, and `outputFormatters`, the corresponding
  `Object` or `Function` can be provided directly.
- Other details are the same as for `.markdownlint-cli2.jsonc` described above.
- For example: [`.markdownlint-cli2.cjs`][markdownlint-cli2-cjs] or
  [`.markdownlint-cli2.mjs`][markdownlint-cli2-mjs]

### `package.json`

- The format of this file is a standard [npm `package.json`][package-json] file
  including a `markdownlint-cli2` property at the root and a value corresponding
  to the object described above for `.markdownlint-cli2.jsonc`.
- `package.json` is only supported in the current directory.
- `package.json` is not supported by the `--config` argument.
- For example: [`package-json-sample`][package-json-sample]

### `.markdownlint.jsonc` or `.markdownlint.json`

- The format of this file is a [JSONC][jsonc] or [JSON][json] object matching
  the [`markdownlint` `config` object][markdownlint-config].
- Settings in this file apply to the directory it is in and all subdirectories
- Settings **override** those applied by any versions of this file in a parent
  directory (up to the current directory).
- To merge the settings of these files or share configuration, use the `extends`
  property (documented in the link above).
- Both file types support comments in JSON.
- For example: [`.markdownlint.jsonc`][markdownlint-jsonc]

### `.markdownlint.yaml` or `.markdownlint.yml`

- The format of this file is a [YAML][yaml] object representing the
  [`markdownlint` `config` object][markdownlint-config].
- Other details are the same as for `jsonc`/`json` files described above.
- For example: [`.markdownlint.yaml`][markdownlint-yaml]

### `.markdownlint.cjs` or `.markdownlint.mjs`

- The format of this file is a [CommonJS module][commonjs-module] (`.cjs`) or
  [ECMAScript module][ecmascript-module] (`.mjs`) that exports the
  [`markdownlint` `config` object][markdownlint-config] (directly or from a
  `Promise`).
- Other details are the same as for `jsonc`/`json` files described above.
- For example: [`.markdownlint.cjs`][markdownlint-cjs] or
  [`.markdownlint.mjs`][markdownlint-mjs]

## Compatibility

### `markdownlint-cli`

- The glob implementation and handling of pattern matching is slightly
  different.
- Configuration files are supported in every directory (vs. only one at the
  root).
- The `INI` config format, `.markdownlintrc`, and `.markdownlintignore` are not
  supported.

### `vscode-markdownlint`

- `.markdownlintignore` is not supported.

## pre-commit

To run `markdownlint-cli2` as part of a [pre-commit][pre-commit] workflow, add a
reference to the `repos` list in that project's `.pre-commit-config.yaml` like:

```yaml
- repo: https://github.com/DavidAnson/markdownlint-cli2
  rev: v0.18.1
  hooks:
  - id: markdownlint-cli2
```

> Depending on the environment that workflow runs in, it may be necessary to
> [override the version of Node.js used by pre-commit][pre-commit-version].

## History

See [CHANGELOG.md][changelog].

[changelog]: CHANGELOG.md
[command-line]: #command-line
[commonmark]: https://commonmark.org/
[commonjs-module]: https://nodejs.org/api/modules.html#modules_modules_commonjs_modules
[ecmascript-module]: https://nodejs.org/api/esm.html#modules-ecmascript-modules
[docker]: https://www.docker.com
[docker-bind-mounts]: https://docs.docker.com/storage/bind-mounts/
[docker-hub-markdownlint-cli2]: https://hub.docker.com/r/davidanson/markdownlint-cli2
[docker-hub-markdownlint-cli2-rules]: https://hub.docker.com/r/davidanson/markdownlint-cli2-rules
[front-matter]: https://jekyllrb.com/docs/frontmatter/
[github-action]: https://docs.github.com/actions
[globby]: https://www.npmjs.com/package/globby
[homebrew]: https://brew.sh
[html-comment]: https://developer.mozilla.org/en-US/docs/Learn/HTML/Introduction_to_HTML/Getting_started
[json]: https://wikipedia.org/wiki/JSON
[json-schema]: https://json-schema.org
[jsonc]: https://code.visualstudio.com/Docs/languages/json#_json-with-comments
[license-image]: https://img.shields.io/npm/l/markdownlint-cli2.svg
[license-url]: https://opensource.org/licenses/MIT
[markdown]: https://wikipedia.org/wiki/Markdown
[markdown-it]: https://www.npmjs.com/package/markdown-it
[markdown-it-plugins]: https://www.npmjs.com/search?q=keywords:markdown-it-plugin
[markdown-it-syntax-extensions]: https://github.com/markdown-it/markdown-it#syntax-extensions
[markdownlint]: https://github.com/DavidAnson/markdownlint
[markdownlint-config]: https://github.com/DavidAnson/markdownlint/blob/v0.32.1/README.md#optionsconfig
[markdownlint-configuration]: https://github.com/DavidAnson/markdownlint/blob/v0.32.1/README.md#configuration
[markdownlint-custom-rules]: https://github.com/DavidAnson/markdownlint/blob/v0.32.1/doc/CustomRules.md
[markdownlint-options]: https://github.com/DavidAnson/markdownlint/blob/v0.32.1/README.md#options
[markdownlint-rules-aliases]: https://github.com/DavidAnson/markdownlint/blob/v0.32.1/README.md#rules--aliases
[markdownlint-rules-tags]: https://github.com/DavidAnson/markdownlint/blob/v0.32.1/README.md#tags
[markdownlint-cli]: https://github.com/igorshubovych/markdownlint-cli
[markdownlint-cli2]: https://github.com/DavidAnson/markdownlint-cli2
[markdownlint-cli2-action]: https://github.com/marketplace/actions/markdownlint-cli2-action
[markdownlint-cli2-blog]: https://dlaa.me/blog/post/markdownlintcli2
[markdownlint-cli2-cjs]: test/markdownlint-cli2-cjs/.markdownlint-cli2.cjs
[markdownlint-cli2-config-schema]: schema/markdownlint-cli2-config-schema.json
[markdownlint-cli2-formatter]: https://www.npmjs.com/search?q=keywords:markdownlint-cli2-formatter
[markdownlint-cli2-jsonc]: test/markdownlint-cli2-jsonc-example/.markdownlint-cli2.jsonc
[markdownlint-cli2-mjs]: test/markdownlint-cli2-mjs/.markdownlint-cli2.mjs
[markdownlint-cli2-yaml]: test/markdownlint-cli2-yaml-example/.markdownlint-cli2.yaml
[markdownlint-cjs]: test/markdownlint-cjs/.markdownlint.cjs
[markdownlint-jsonc]: https://github.com/DavidAnson/markdownlint/blob/v0.32.1/schema/.markdownlint.jsonc
[markdownlint-mjs]: test/markdownlint-mjs/.markdownlint.mjs
[markdownlint-rule]: https://www.npmjs.com/search?q=keywords:markdownlint-rule
[markdownlint-yaml]: https://github.com/DavidAnson/markdownlint/blob/v0.32.1/schema/.markdownlint.yaml
[nodejs]: https://nodejs.org/
[nodejs-docker]: https://github.com/nodejs/docker-node
[nodejs-docker-non-root]: https://github.com/nodejs/docker-node/blob/main/docs/BestPractices.md#non-root-user
[nodejs-import-expression]: https://nodejs.org/api/esm.html#import-expressions
[nodejs-import-meta-resolve]: https://nodejs.org/api/esm.html#importmetaresolvespecifier-parent
[nodejs-require]: https://nodejs.org/api/modules.html#modules_require_id
[npm-image]: https://img.shields.io/npm/v/markdownlint-cli2.svg
[npm-url]: https://www.npmjs.com/package/markdownlint-cli2
[output-formatters]: doc/OutputFormatters.md
[package-json]: https://docs.npmjs.com/cli/v9/configuring-npm/package-json
[package-json-sample]: test/package-json/package.json
[pre-commit]: https://pre-commit.com/
[pre-commit-version]: https://pre-commit.com/#overriding-language-version
[regexp]: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp
[regexp-constructor]: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp/RegExp
[validating-configuration]: schema/ValidatingConfiguration.md
[vscode]: https://code.visualstudio.com/
[vscode-markdownlint]: https://marketplace.visualstudio.com/items?itemName=DavidAnson.vscode-markdownlint
[yaml]: https://wikipedia.org/wiki/YAML
