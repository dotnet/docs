using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using YamlDotNet.RepresentationModel;

namespace CustomProvider.Example;

internal sealed class YamlConfigurationFileParser
{
    private YamlConfigurationFileParser() { }

    private readonly Dictionary<string, string?> _data = new(StringComparer.OrdinalIgnoreCase);
    private readonly Stack<string> _paths = new();

    public static IDictionary<string, string?> Parse(Stream input) =>
        new YamlConfigurationFileParser().ParseStream(input);

    private IDictionary<string, string?> ParseStream(Stream input)
    {
        using TextReader reader = new StreamReader(input);

        var yaml = new YamlStream();
        yaml.Load(reader);

        foreach (YamlDocument document in yaml)
        {
            VisitMappingNode((YamlMappingNode)document.RootNode);
        }

        return _data;
    }

    private bool VisitScalarNode(YamlScalarNode node)
    {
        string key = _paths.Peek();
        if (_data.ContainsKey(key))
        {
            throw new FormatException($"Error: the key is duplicated {key}");
        }
        _data[key] = node.Value!;
        return true;
    }

    private bool VisitSequenceNode(YamlSequenceNode node)
    {
        int index = 0;

        foreach (YamlNode child in node.Children)
        {
            EnterContext(index.ToString());
            VisitValue(child);
            ExitContext();
            ++ index;
        }

        SetNullIfElementIsEmpty(isEmpty: index == 0);
        return index == 0;
    }

    private bool VisitMappingNode(YamlMappingNode node)
    {
        var isEmpty = true;

        foreach (var (key, value) in node.Children)
        {
            isEmpty = false;
            EnterContext(((YamlScalarNode)key).Value!);
            VisitValue(value);
            ExitContext();
        }

        SetNullIfElementIsEmpty(isEmpty);
        return isEmpty;
    }

    private void SetNullIfElementIsEmpty(bool isEmpty)
    {
        if (isEmpty && _paths.Count > 0)
        {
            _data[_paths.Peek()] = null;
        }
    }

    private void VisitValue(YamlNode value)
    {
        Debug.Assert(_paths.Count > 0);

        _ = (value.NodeType, value) switch
        {
            (YamlNodeType.Scalar, YamlScalarNode scalar) => VisitScalarNode(scalar),
            (YamlNodeType.Sequence, YamlSequenceNode sequence) => VisitSequenceNode(sequence),
            (YamlNodeType.Mapping, YamlMappingNode mapping) => VisitMappingNode(mapping),
            _ => throw new NotSupportedException($"Node type {value.NodeType} is not supported.")
        };
    }

    private void EnterContext(string context) =>
        _paths.Push(_paths.Count > 0
            ? $"{_paths.Peek()}{ConfigurationPath.KeyDelimiter}{context}"
            : context);

    private void ExitContext() => _paths.Pop();
}
