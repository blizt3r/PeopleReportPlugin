using VideoOS.Platform.Admin;

namespace PeopleReportPlugin.Admin
{
    public partial class PeopleReportPluginToolsOptionDialogUserControl : ToolsOptionsDialogUserControl
    {
        public PeopleReportPluginToolsOptionDialogUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        public string MyPropValue
        {
            set { textBoxPropValue.Text = value ?? ""; }
            get { return textBoxPropValue.Text; }
        }
    }
}
