using VideoOS.Platform.Client;

namespace PeopleReportPlugin.Client
{
    public class PeopleReportPluginWorkSpaceViewItemManager : ViewItemManager
    {
        public PeopleReportPluginWorkSpaceViewItemManager() : base("PeopleReportPluginWorkSpaceViewItemManager")
        {
        }

        public override ViewItemWpfUserControl GenerateViewItemWpfUserControl()
        {
            return new PeopleReportPluginWorkSpaceViewItemWpfUserControl();
        }
    }
}
