using System;
using VideoOS.Platform.Client;

namespace PeopleReportPlugin.Client
{
    /// <summary>
    /// Interaction logic for PeopleReportPluginWorkSpaceViewItemWpfUserControl.xaml
    /// </summary>
    public partial class PeopleReportPluginWorkSpaceViewItemWpfUserControl : ViewItemWpfUserControl
    {
        public PeopleReportPluginWorkSpaceViewItemWpfUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        /// <summary>
        /// Do not show the sliding toolbar!
        /// </summary>
        public override bool ShowToolbar
        {
            get { return false; }
        }

        private void ViewItemWpfUserControl_ClickEvent(object sender, EventArgs e)
        {
            FireClickEvent();
        }

        private void ViewItemWpfUserControl_DoubleClickEvent(object sender, EventArgs e)
        {
            FireDoubleClickEvent();
        }
    }
}
