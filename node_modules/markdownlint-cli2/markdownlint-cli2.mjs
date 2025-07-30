// @ts-ignore

// Imports
import fsNode from "node:fs";
import os from "node:os";
import pathDefault from "node:path";
const pathPosix = pathDefault.posix;
import { pathToFileURL } from "node:url";
import { globby } from "globby";
import micromatch from "micromatch";
import { applyFixes, getVersion, resolveModule } from "markdownlint";
import { lint, extendConfig, readConfig } from "markdownlint/promise";
import { expandTildePath } from "markdownlint/helpers";
import appendToArray from "./append-to-array.mjs";
import mergeOptions from "./merge-options.mjs";
import parsers from "./parsers/parsers.mjs";
import jsoncParse from "./parsers/jsonc-parse.mjs";
import yamlParse from "./parsers/yaml-parse.mjs";

// Variables
const packageName = "markdownlint-cli2";
const packageVersion = "0.18.1";
const libraryName = "markdownlint";
const libraryVersion = getVersion();
const bannerMessage = `${packageName} v${packageVersion} (${libraryName} v${libraryVersion})`;
const dotOnlySubstitute = "*.{md,markdown}";
const utf8 = "utf8";

// No-op function
const noop = () => null;

// Negates a glob
const negateGlob = (glob) => `!${glob}`;

// Throws a meaningful exception for an unusable configuration file
const throwForConfigurationFile = (file, error) => {
  throw new Error(
    `Unable to use configuration file '${file}'; ${error?.message}`,
    { "cause": error }
  );
};

// Return a posix path (even on Windows)
const posixPath = (p) => p.split(pathDefault.sep).join(pathPosix.sep);

// Resolves module paths relative to the specified directory
const resolveModulePaths = (dir, modulePaths) => (
  modulePaths.map((path) => pathDefault.resolve(dir, expandTildePath(path, os)))
);

// Read a JSON(C) or YAML file and return the object
const readConfigFile = (fs, dir, name, otherwise) => () => {
  const file = pathPosix.join(dir, name);
  return fs.promises.access(file).
    then(
      () => readConfig(
        file,
        parsers,
        fs
      ),
      otherwise
    );
};

// Import a module ID with a custom directory in the path
const importModule = async (dirOrDirs, id, noImport) => {
  if (typeof id !== "string") {
    return id;
  } else if (noImport) {
    return null;
  }
  const dirs = Array.isArray(dirOrDirs) ? dirOrDirs : [ dirOrDirs ];
  const expandId = expandTildePath(id, os);
  const errors = [];
  let moduleName = null;
  try {
    try {
      moduleName = pathToFileURL(resolveModule(expandId, dirs));
    } catch (error) {
      errors.push(error);
      moduleName =
        (!pathDefault.isAbsolute(expandId) && URL.canParse(expandId))
          ? new URL(expandId)
          : pathToFileURL(pathDefault.resolve(dirs[0], expandId));
    }
    // eslint-disable-next-line no-inline-comments
    const module = await import(/* webpackIgnore: true */ moduleName);
    return module.default;
  } catch (error) {
    errors.push(error);
    throw new AggregateError(
      errors,
      `Unable to import module '${id}'.`
    );
  }
};

// Import an array of modules by ID
const importModuleIds = (dirs, ids, noImport) => (
  Promise.all(
    ids.map(
      (id) => importModule(dirs, id, noImport)
    )
  ).then((results) => results.filter(Boolean))
);

// Import an array of modules by ID (preserving parameters)
const importModuleIdsAndParams = (dirs, idsAndParams, noImport) => (
  Promise.all(
    idsAndParams.map(
      (idAndParams) => importModule(dirs, idAndParams[0], noImport).
        then((module) => module && [ module, ...idAndParams.slice(1) ])
    )
  ).then((results) => results.filter(Boolean))
);

// Import a JavaScript file and return the exported object
const importConfig = (fs, dir, name, noImport, otherwise) => () => {
  const file = pathPosix.join(dir, name);
  return fs.promises.access(file).
    then(
      () => importModule(dir, name, noImport),
      otherwise
    );
};

// Extend a config object if it has 'extends' property
const getExtendedConfig = (config, configPath, fs) => {
  if (config.extends) {
    return extendConfig(
      config,
      configPath,
      parsers,
      fs
    );
  }

  return Promise.resolve(config);
};

// Read an options or config file in any format and return the object
const readOptionsOrConfig = async (configPath, fs, noImport) => {
  const basename = pathPosix.basename(configPath);
  const dirname = pathPosix.dirname(configPath);
  let options = null;
  let config = null;
  try {
    if (basename.endsWith(".markdownlint-cli2.jsonc")) {
      options = jsoncParse(await fs.promises.readFile(configPath, utf8));
    } else if (basename.endsWith(".markdownlint-cli2.yaml")) {
      options = yamlParse(await fs.promises.readFile(configPath, utf8));
    } else if (
      basename.endsWith(".markdownlint-cli2.cjs") ||
      basename.endsWith(".markdownlint-cli2.mjs")
    ) {
      options = await importModule(dirname, basename, noImport);
    } else if (
      basename.endsWith(".markdownlint.jsonc") ||
      basename.endsWith(".markdownlint.json") ||
      basename.endsWith(".markdownlint.yaml") ||
      basename.endsWith(".markdownlint.yml")
    ) {
      config = await readConfig(configPath, parsers, fs);
    } else if (
      basename.endsWith(".markdownlint.cjs") ||
      basename.endsWith(".markdownlint.mjs")
    ) {
      config = await importModule(dirname, basename, noImport);
    } else {
      throw new Error(
        "Configuration file should be one of the supported names " +
        "(e.g., '.markdownlint-cli2.jsonc') or a prefix with a supported name " +
        "(e.g., 'example.markdownlint-cli2.jsonc')."
      );
    }
  } catch (error) {
    throwForConfigurationFile(configPath, error);
  }
  if (options) {
    if (options.config) {
      options.config = await getExtendedConfig(options.config, configPath, fs);
    }
    return options;
  }
  config = await getExtendedConfig(config, configPath, fs);
  return { config };
};

// Filter a list of files to ignore by glob
const removeIgnoredFiles = (dir, files, ignores) => (
  micromatch(
    files.map((file) => pathPosix.relative(dir, file)),
    ignores
  ).map((file) => pathPosix.join(dir, file))
);

// Process/normalize command-line arguments and return glob patterns
const processArgv = (argv) => {
  const globPatterns = argv.map(
    (glob) => {
      if (glob.startsWith(":")) {
        return glob;
      }
      // Escape RegExp special characters recognized by fast-glob
      // https://github.com/mrmlnc/fast-glob#advanced-syntax
      const specialCharacters = /\\(?![$()*+?[\]^])/gu;
      if (glob.startsWith("\\:")) {
        return `\\:${glob.slice(2).replace(specialCharacters, "/")}`;
      }
      return (glob.startsWith("#") ? `!${glob.slice(1)}` : glob).
        replace(specialCharacters, "/");
    }
  );
  if ((globPatterns.length === 1) && (globPatterns[0] === ".")) {
    // Substitute a more reasonable pattern
    globPatterns[0] = dotOnlySubstitute;
  }
  return globPatterns;
};

// Show help if missing arguments
const showHelp = (logMessage, showBanner) => {
  if (showBanner) {
    logMessage(bannerMessage);
  }
  logMessage(`https://github.com/DavidAnson/markdownlint-cli2

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
- Instead, it is mapped to "markdownlint-cli2 ${dotOnlySubstitute}" which lints all Markdown files in the current directory
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
- The path separator is forward slash (/) on all platforms; backslash (\\) is automatically converted
- On any platform, passing the parameter "--" causes all remaining parameters to be treated literally

The most compatible syntax for cross-platform support:
$ markdownlint-cli2 "**/*.md" "#node_modules"`
  );
  return 2;
};

// Get (creating if necessary) and process a directory's info object
const getAndProcessDirInfo = (
  fs,
  tasks,
  dirToDirInfo,
  dir,
  relativeDir,
  noImport,
  allowPackageJson
) => {
  // Create dirInfo
  let dirInfo = dirToDirInfo[dir];
  if (!dirInfo) {
    dirInfo = {
      dir,
      relativeDir,
      "parent": null,
      "files": [],
      "markdownlintConfig": null,
      "markdownlintOptions": null
    };
    dirToDirInfo[dir] = dirInfo;

    // Load markdownlint-cli2 object(s)
    const markdownlintCli2Jsonc = pathPosix.join(dir, ".markdownlint-cli2.jsonc");
    const markdownlintCli2Yaml = pathPosix.join(dir, ".markdownlint-cli2.yaml");
    const markdownlintCli2Cjs = pathPosix.join(dir, ".markdownlint-cli2.cjs");
    const markdownlintCli2Mjs = pathPosix.join(dir, ".markdownlint-cli2.mjs");
    const packageJson = pathPosix.join(dir, "package.json");
    let file = "[UNKNOWN]";
    // eslint-disable-next-line no-return-assign
    const captureFile = (f) => file = f;
    tasks.push(
      fs.promises.access(captureFile(markdownlintCli2Jsonc)).
        then(
          () => fs.promises.readFile(file, utf8).then(jsoncParse),
          () => fs.promises.access(captureFile(markdownlintCli2Yaml)).
            then(
              () => fs.promises.readFile(file, utf8).then(yamlParse),
              () => fs.promises.access(captureFile(markdownlintCli2Cjs)).
                then(
                  () => importModule(dir, file, noImport),
                  () => fs.promises.access(captureFile(markdownlintCli2Mjs)).
                    then(
                      () => importModule(dir, file, noImport),
                      () => (allowPackageJson
                        ? fs.promises.access(captureFile(packageJson))
                        // eslint-disable-next-line prefer-promise-reject-errors
                        : Promise.reject()
                      ).
                        then(
                          () => fs.promises.
                            readFile(file, utf8).
                            then(jsoncParse).
                            then((obj) => obj[packageName]),
                          noop
                        )
                    )
                )
            )
        ).
        then((options) => {
          dirInfo.markdownlintOptions = options;
          return options &&
            options.config &&
            getExtendedConfig(
              options.config,
              // Just need to identify a file in the right directory
              markdownlintCli2Jsonc,
              fs
            ).
              then((config) => {
                options.config = config;
              });
        }).
        catch((error) => {
          throwForConfigurationFile(file, error);
        })
    );

    // Load markdownlint object(s)
    const readConfigs =
      readConfigFile(
        fs,
        dir,
        ".markdownlint.jsonc",
        readConfigFile(
          fs,
          dir,
          ".markdownlint.json",
          readConfigFile(
            fs,
            dir,
            ".markdownlint.yaml",
            readConfigFile(
              fs,
              dir,
              ".markdownlint.yml",
              importConfig(
                fs,
                dir,
                ".markdownlint.cjs",
                noImport,
                importConfig(
                  fs,
                  dir,
                  ".markdownlint.mjs",
                  noImport,
                  noop
                )
              )
            )
          )
        )
      );
    tasks.push(
      readConfigs().
        then((config) => {
          dirInfo.markdownlintConfig = config;
        })
    );
  }

  // Return dirInfo
  return dirInfo;
};

// Get base markdownlint-cli2 options object
const getBaseOptions = async (
  fs,
  baseDir,
  relativeDir,
  globPatterns,
  options,
  fixDefault,
  noGlobs,
  noImport
) => {
  const tasks = [];
  const dirToDirInfo = {};
  getAndProcessDirInfo(
    fs,
    tasks,
    dirToDirInfo,
    baseDir,
    relativeDir,
    noImport,
    true
  );
  await Promise.all(tasks);
  // eslint-disable-next-line no-multi-assign
  const baseMarkdownlintOptions = dirToDirInfo[baseDir].markdownlintOptions =
    mergeOptions(
      mergeOptions(
        { "fix": fixDefault },
        options
      ),
      dirToDirInfo[baseDir].markdownlintOptions
    );

  if (!noGlobs) {
    // Append any globs specified in markdownlint-cli2 configuration
    const globs = baseMarkdownlintOptions.globs || [];
    appendToArray(globPatterns, globs);
  }

  // Pass base ignore globs as globby patterns (best performance)
  const ignorePatterns =
    // eslint-disable-next-line unicorn/no-array-callback-reference
    (baseMarkdownlintOptions.ignores || []).map(negateGlob);
  appendToArray(globPatterns, ignorePatterns);

  return {
    baseMarkdownlintOptions,
    dirToDirInfo
  };
};

// Enumerate files from globs and build directory infos
const enumerateFiles = async (
  fs,
  baseDirSystem,
  baseDir,
  globPatterns,
  dirToDirInfo,
  gitignore,
  ignoreFiles,
  noImport
) => {
  const tasks = [];
  /** @type {import("globby").Options} */
  const globbyOptions = {
    "absolute": true,
    "cwd": baseDir,
    "dot": true,
    "expandDirectories": false,
    gitignore,
    ignoreFiles,
    "suppressErrors": true,
    fs
  };
  // Special-case literal files
  const literalFiles = [];
  const filteredGlobPatterns = globPatterns.filter(
    (globPattern) => {
      if (globPattern.startsWith(":")) {
        literalFiles.push(
          posixPath(pathDefault.resolve(baseDirSystem, globPattern.slice(1)))
        );
        return false;
      }
      return true;
    }
  ).map((globPattern) => globPattern.replace(/^\\:/u, ":"));
  const baseMarkdownlintOptions = dirToDirInfo[baseDir].markdownlintOptions;
  const globsForIgnore =
    (baseMarkdownlintOptions.globs || []).
      filter((glob) => glob.startsWith("!"));
  const filteredLiteralFiles =
    ((literalFiles.length > 0) && (globsForIgnore.length > 0))
      ? removeIgnoredFiles(baseDir, literalFiles, globsForIgnore)
      : literalFiles;
  // Manually expand directories to avoid globby call to dir-glob.sync
  const expandedDirectories = await Promise.all(
    filteredGlobPatterns.map((globPattern) => {
      const barePattern =
        globPattern.startsWith("!")
          ? globPattern.slice(1)
          : globPattern;
      const globPath = (
        pathPosix.isAbsolute(barePattern) ||
        pathDefault.isAbsolute(barePattern)
      )
        ? barePattern
        : pathPosix.join(baseDir, barePattern);
      return fs.promises.stat(globPath).
        then((stats) => (stats.isDirectory()
          ? pathPosix.join(globPattern, "**")
          : globPattern)).
        catch(() => globPattern);
    })
  );
  // Process glob patterns
  const files = [
    ...await globby(expandedDirectories, globbyOptions),
    ...filteredLiteralFiles
  ];
  for (const file of files) {
    const dir = pathPosix.dirname(file);
    const dirInfo = getAndProcessDirInfo(
      fs,
      tasks,
      dirToDirInfo,
      dir,
      null,
      noImport,
      false
    );
    dirInfo.files.push(file);
  }
  await Promise.all(tasks);
};

// Enumerate (possibly missing) parent directories and update directory infos
const enumerateParents = async (
  fs,
  baseDir,
  dirToDirInfo,
  noImport
) => {
  const tasks = [];

  // Create a lookup of baseDir and parents
  const baseDirParents = {};
  let baseDirParent = baseDir;
  do {
    baseDirParents[baseDirParent] = true;
    baseDirParent = pathPosix.dirname(baseDirParent);
  } while (!baseDirParents[baseDirParent]);

  // Visit parents of each dirInfo
  for (let lastDirInfo of Object.values(dirToDirInfo)) {
    let { dir } = lastDirInfo;
    let lastDir = dir;
    while (
      !baseDirParents[dir] &&
      (dir = pathPosix.dirname(dir)) &&
      (dir !== lastDir)
    ) {
      lastDir = dir;
      const dirInfo =
        getAndProcessDirInfo(
          fs,
          tasks,
          dirToDirInfo,
          dir,
          null,
          noImport,
          false
        );
      lastDirInfo.parent = dirInfo;
      lastDirInfo = dirInfo;
    }

    // If dir not under baseDir, inject it as parent for configuration
    if (dir !== baseDir) {
      dirToDirInfo[dir].parent = dirToDirInfo[baseDir];
    }
  }
  await Promise.all(tasks);
};

// Create directory info objects by enumerating file globs
const createDirInfos = async (
  fs,
  baseDirSystem,
  baseDir,
  globPatterns,
  dirToDirInfo,
  optionsOverride,
  gitignore,
  ignoreFiles,
  noImport
) => {
  await enumerateFiles(
    fs,
    baseDirSystem,
    baseDir,
    globPatterns,
    dirToDirInfo,
    gitignore,
    ignoreFiles,
    noImport
  );
  await enumerateParents(
    fs,
    baseDir,
    dirToDirInfo,
    noImport
  );

  // Merge file lists with identical configuration
  const dirs = Object.keys(dirToDirInfo);
  dirs.sort((a, b) => b.length - a.length);
  const dirInfos = [];
  const noConfigDirInfo =
    // eslint-disable-next-line unicorn/consistent-function-scoping
    (dirInfo) => (
      dirInfo.parent &&
      !dirInfo.markdownlintConfig &&
      !dirInfo.markdownlintOptions
    );
  const tasks = [];
  for (const dir of dirs) {
    const dirInfo = dirToDirInfo[dir];
    if (noConfigDirInfo(dirInfo)) {
      if (dirInfo.parent) {
        appendToArray(dirInfo.parent.files, dirInfo.files);
      }
      dirToDirInfo[dir] = null;
    } else {
      const { markdownlintOptions, relativeDir } = dirInfo;
      const effectiveDir = relativeDir || dir;
      const effectiveModulePaths = resolveModulePaths(
        effectiveDir,
        (markdownlintOptions && markdownlintOptions.modulePaths) || []
      );
      if (markdownlintOptions && markdownlintOptions.customRules) {
        tasks.push(
          importModuleIds(
            [ effectiveDir, ...effectiveModulePaths ],
            markdownlintOptions.customRules,
            noImport
          ).then((customRules) => {
            // Expand nested arrays (for packages that export multiple rules)
            markdownlintOptions.customRules = customRules.flat();
          })
        );
      }
      if (markdownlintOptions && markdownlintOptions.markdownItPlugins) {
        tasks.push(
          importModuleIdsAndParams(
            [ effectiveDir, ...effectiveModulePaths ],
            markdownlintOptions.markdownItPlugins,
            noImport
          ).then((markdownItPlugins) => {
            markdownlintOptions.markdownItPlugins = markdownItPlugins;
          })
        );
      }
      dirInfos.push(dirInfo);
    }
  }
  await Promise.all(tasks);
  for (const dirInfo of dirInfos) {
    while (dirInfo.parent && !dirToDirInfo[dirInfo.parent.dir]) {
      dirInfo.parent = dirInfo.parent.parent;
    }
  }

  // Verify dirInfos is simplified
  // if (
  //   dirInfos.filter(
  //     (di) => di.parent && !dirInfos.includes(di.parent)
  //   ).length > 0
  // ) {
  //   throw new Error("Extra parent");
  // }
  // if (
  //   dirInfos.filter(
  //     (di) => !di.parent && (di.dir !== baseDir)
  //   ).length > 0
  // ) {
  //   throw new Error("Missing parent");
  // }
  // if (
  //   dirInfos.filter(
  //     (di) => di.parent &&
  //     !((di.markdownlintConfig ? 1 : 0) ^ (di.markdownlintOptions ? 1 : 0))
  //   ).length > 0
  // ) {
  //   throw new Error("Missing object");
  // }
  // if (dirInfos.filter((di) => di.dir === "/").length > 0) {
  //   throw new Error("Includes root");
  // }

  // Merge configuration by inheritance
  for (const dirInfo of dirInfos) {
    let markdownlintOptions = dirInfo.markdownlintOptions || {};
    let { markdownlintConfig } = dirInfo;
    let parent = dirInfo;
    // eslint-disable-next-line prefer-destructuring
    while ((parent = parent.parent)) {
      if (parent.markdownlintOptions) {
        markdownlintOptions = mergeOptions(
          parent.markdownlintOptions,
          markdownlintOptions
        );
      }
      if (
        !markdownlintConfig &&
        parent.markdownlintConfig &&
        !markdownlintOptions.config
      ) {
        // eslint-disable-next-line prefer-destructuring
        markdownlintConfig = parent.markdownlintConfig;
      }
    }
    dirInfo.markdownlintOptions = mergeOptions(
      markdownlintOptions,
      optionsOverride
    );
    dirInfo.markdownlintConfig = markdownlintConfig;
  }
  return dirInfos;
};

// Lint files in groups by shared configuration
const lintFiles = (fs, dirInfos, fileContents) => {
  const tasks = [];
  // For each dirInfo
  for (const dirInfo of dirInfos) {
    const { dir, files, markdownlintConfig, markdownlintOptions } = dirInfo;
    // Filter file/string inputs to only those in the dirInfo
    let filesAfterIgnores = files;
    if (
      markdownlintOptions.ignores &&
      (markdownlintOptions.ignores.length > 0)
    ) {
      // eslint-disable-next-line unicorn/no-array-callback-reference
      const ignores = markdownlintOptions.ignores.map(negateGlob);
      filesAfterIgnores = removeIgnoredFiles(dir, files, ignores);
    }
    const filteredFiles = filesAfterIgnores.filter(
      (file) => fileContents[file] === undefined
    );
    /** @type {Record<string, string>} */
    const filteredStrings = {};
    for (const file of filesAfterIgnores) {
      if (fileContents[file] !== undefined) {
        filteredStrings[file] = fileContents[file];
      }
    }
    // Create markdown-it factory
    // eslint-disable-next-line unicorn/consistent-function-scoping
    const markdownItFactory = async () => {
      // eslint-disable-next-line no-inline-comments
      const module = await import(/* webpackMode: "eager" */ "markdown-it");
      const markdownIt = module.default({ "html": true });
      for (const plugin of (markdownlintOptions.markdownItPlugins || [])) {
        markdownIt.use(...plugin);
      }
      return markdownIt;
    };
    // Create markdownlint options object
    /** @type {import("markdownlint").Options} */
    const options = {
      "files": filteredFiles,
      "strings": filteredStrings,
      "config": markdownlintConfig || markdownlintOptions.config,
      "configParsers": parsers,
      "customRules": markdownlintOptions.customRules,
      "frontMatter": markdownlintOptions.frontMatter
        ? new RegExp(markdownlintOptions.frontMatter, "u")
        : undefined,
      "handleRuleFailures": true,
      markdownItFactory,
      "noInlineConfig": Boolean(markdownlintOptions.noInlineConfig),
      fs
    };
    // Invoke markdownlint
    let task = lint(options);
    // For any fixable errors, read file, apply fixes, and write it back
    if (markdownlintOptions.fix) {
      task = task.then((results) => {
        options.files = [];
        const subTasks = [];
        const errorFiles = Object.keys(results).
          filter((result) => filteredFiles.includes(result));
        for (const fileName of errorFiles) {
          const errorInfos = results[fileName].
            filter((errorInfo) => errorInfo.fixInfo);
          if (errorInfos.length > 0) {
            delete results[fileName];
            options.files.push(fileName);
            subTasks.push(fs.promises.readFile(fileName, utf8).
              then((original) => {
                const fixed = applyFixes(original, errorInfos);
                return fs.promises.writeFile(fileName, fixed, utf8);
              })
            );
          }
        }
        return Promise.all(subTasks).
          then(() => lint(options)).
          then((fixResults) => ({
            ...results,
            ...fixResults
          }));
      });
    }
    // Queue tasks for this dirInfo
    tasks.push(task);
  }
  // Return result of all tasks
  return Promise.all(tasks);
};

// Create summary of results
const createSummary = (baseDir, taskResults) => {
  const summary = [];
  let counter = 0;
  for (const results of taskResults) {
    for (const fileName in results) {
      const errorInfos = results[fileName];
      for (const errorInfo of errorInfos) {
        const fileNameRelative = pathPosix.relative(baseDir, fileName);
        summary.push({
          "fileName": fileNameRelative,
          ...errorInfo,
          counter
        });
        counter++;
      }
    }
  }
  summary.sort((a, b) => (
    a.fileName.localeCompare(b.fileName) ||
    (a.lineNumber - b.lineNumber) ||
    a.ruleNames[0].localeCompare(b.ruleNames[0]) ||
    (a.counter - b.counter)
  ));
  for (const result of summary) {
    delete result.counter;
  }
  return summary;
};

// Output summary via formatters
const outputSummary = async (
  baseDir,
  relativeDir,
  summary,
  outputFormatters,
  modulePaths,
  logMessage,
  logError,
  noImport
) => {
  const errorsPresent = (summary.length > 0);
  if (errorsPresent || outputFormatters) {
    const formatterOptions = {
      "directory": baseDir,
      "results": summary,
      logMessage,
      logError
    };
    const dir = relativeDir || baseDir;
    const dirs = [ dir, ...modulePaths ];
    const formattersAndParams = outputFormatters
      ? await importModuleIdsAndParams(dirs, outputFormatters, noImport)
      // eslint-disable-next-line no-inline-comments, unicorn/no-await-expression-member
      : [ [ (await import(/* webpackMode: "eager" */ "markdownlint-cli2-formatter-default")).default ] ];
    await Promise.all(formattersAndParams.map((formatterAndParams) => {
      const [ formatter, ...formatterParams ] = formatterAndParams;
      return formatter(formatterOptions, ...formatterParams);
    }));
  }
  return errorsPresent;
};

// Main function
export const main = async (params) => {
  // Capture parameters
  const {
    directory,
    argv,
    optionsDefault,
    optionsOverride,
    fileContents,
    noImport,
    allowStdin
  } = params;
  let {
    noGlobs,
    nonFileContents
  } = params;
  const logMessage = params.logMessage || noop;
  const logError = params.logError || noop;
  const fs = params.fs || fsNode;
  const baseDirSystem =
    (directory && pathDefault.resolve(directory)) ||
    process.cwd();
  const baseDir = posixPath(baseDirSystem);
  // Merge and process args/argv
  let fixDefault = false;
  // eslint-disable-next-line unicorn/no-useless-undefined
  let configPath = undefined;
  let useStdin = false;
  let sawDashDash = false;
  let shouldShowHelp = false;
  const argvFiltered = (argv || []).filter((arg) => {
    if (sawDashDash) {
      return true;
    } else if (configPath === null) {
      configPath = arg;
    } else if ((arg === "-") && allowStdin) {
      useStdin = true;
      // eslint-disable-next-line unicorn/prefer-switch
    } else if (arg === "--") {
      sawDashDash = true;
    } else if (arg === "--config") {
      configPath = null;
    } else if (arg === "--fix") {
      fixDefault = true;
    } else if (arg === "--help") {
      shouldShowHelp = true;
    } else if (arg === "--no-globs") {
      noGlobs = true;
    } else {
      return true;
    }
    return false;
  });
  if (shouldShowHelp) {
    return showHelp(logMessage, true);
  }
  // Read argv configuration file (if relevant and present)
  let optionsArgv = null;
  let relativeDir = null;
  let globPatterns = null;
  let baseOptions = null;
  try {
    if (configPath) {
      const resolvedConfigPath =
        posixPath(pathDefault.resolve(baseDirSystem, configPath));
      optionsArgv =
        await readOptionsOrConfig(resolvedConfigPath, fs, noImport);
      relativeDir = pathPosix.dirname(resolvedConfigPath);
    }
    // Process arguments and get base options
    globPatterns = processArgv(argvFiltered);
    baseOptions = await getBaseOptions(
      fs,
      baseDir,
      relativeDir,
      globPatterns,
      optionsArgv || optionsDefault,
      fixDefault,
      noGlobs,
      noImport
    );
  } finally {
    if (!baseOptions?.baseMarkdownlintOptions.noBanner) {
      logMessage(bannerMessage);
    }
  }
  if (
    ((globPatterns.length === 0) && !useStdin && !nonFileContents) ||
    (configPath === null)
  ) {
    return showHelp(logMessage, false);
  }
  // Add stdin as a non-file input if necessary
  if (useStdin) {
    const key = pathPosix.join(baseDir, "stdin");
    const { text } = await import("node:stream/consumers");
    nonFileContents = {
      ...nonFileContents,
      [key]: await text(process.stdin)
    };
  }
  // Include any file overrides or non-file content
  const resolvedFileContents = {};
  for (const file in fileContents) {
    const resolvedFile = posixPath(pathDefault.resolve(baseDirSystem, file));
    resolvedFileContents[resolvedFile] = fileContents[file];
  }
  for (const nonFile in nonFileContents) {
    resolvedFileContents[nonFile] = nonFileContents[nonFile];
  }
  const { baseMarkdownlintOptions, dirToDirInfo } = baseOptions;
  appendToArray(
    dirToDirInfo[baseDir].files,
    Object.keys(nonFileContents || {})
  );
  // Output finding status
  const showProgress = !baseMarkdownlintOptions.noProgress;
  if (showProgress) {
    logMessage(`Finding: ${globPatterns.join(" ")}`);
  }
  // Create linting tasks
  const gitignore =
    // https://github.com/sindresorhus/globby/issues/265
    (!params.fs && (baseMarkdownlintOptions.gitignore === true));
  const ignoreFiles =
    (!params.fs && (typeof baseMarkdownlintOptions.gitignore === "string"))
      ? baseMarkdownlintOptions.gitignore
      : undefined;
  const dirInfos =
    await createDirInfos(
      fs,
      baseDirSystem,
      baseDir,
      globPatterns,
      dirToDirInfo,
      optionsOverride,
      gitignore,
      ignoreFiles,
      noImport
    );
  // Output linting status
  if (showProgress) {
    const fileNames = dirInfos.flatMap((dirInfo) => {
      const { files } = dirInfo;
      return files.map((file) => pathPosix.relative(baseDir, file));
    });
    const fileCount = fileNames.length;
    if (baseMarkdownlintOptions.showFound) {
      fileNames.push("");
      fileNames.sort();
      logMessage(`Found:${fileNames.join("\n ")}`);
    }
    logMessage(`Linting: ${fileCount} file(s)`);
  }
  // Lint files
  const lintResults = await lintFiles(fs, dirInfos, resolvedFileContents);
  // Output summary
  const summary = createSummary(baseDir, lintResults);
  if (showProgress) {
    logMessage(`Summary: ${summary.length} error(s)`);
  }
  const outputFormatters =
    (optionsOverride && optionsOverride.outputFormatters) ||
    baseMarkdownlintOptions.outputFormatters;
  const modulePaths = resolveModulePaths(
    baseDir,
    baseMarkdownlintOptions.modulePaths || []
  );
  const errorsPresent = await outputSummary(
    baseDir,
    relativeDir,
    summary,
    outputFormatters,
    modulePaths,
    logMessage,
    logError,
    noImport
  );
  // Return result
  return errorsPresent ? 1 : 0;
};
