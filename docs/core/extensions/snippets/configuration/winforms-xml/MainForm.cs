using Microsoft.Extensions.Configuration;

namespace WinForms.Xml;

public sealed partial class MainForm : Form
{
    private readonly IConfiguration _config;

    public MainForm()
    {
        _config = new ConfigurationBuilder()
            .AddXmlFile("winforms-xml.dll.config", optional: true)
            .AddXmlFile("winforms-xml.exe.config", optional: true)
            .Build();

        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        var secretKey = _config["SecretKey"];
        AddItemToGrid("SecretKey", secretKey);

        var transientFaultHandlingOptions =
            _config.GetRequiredSection("TransientFaultHandlingOptions");
        var isEnabled =
            transientFaultHandlingOptions.GetValue<bool>("Enabled");
        var autoRetryDelay =
            transientFaultHandlingOptions.GetValue<TimeSpan>("AutoRetryDelay");

        AddItemToGrid("TransientFaultHandlingOptions:Enabled", isEnabled);
        AddItemToGrid("TransientFaultHandlingOptions:AutoRetryDelay", autoRetryDelay);

        _settingsDataGridView.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
    }

    void AddItemToGrid<T>(string key, T value)
    {
        var row = new DataGridViewRow();
        row.Cells.Add(new DataGridViewTextBoxCell { Value = key });
        row.Cells.Add(new DataGridViewTextBoxCell { Value = typeof(T) });
        row.Cells.Add(new DataGridViewTextBoxCell { Value = value });

        _settingsDataGridView.Rows.Add(row);
    }
}
