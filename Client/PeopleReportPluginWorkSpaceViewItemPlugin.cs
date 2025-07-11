using System;
using VideoOS.Platform.Client;
using VideoOS.Platform.UI.Controls;

namespace PeopleReportPlugin.Client
{
    public class PeopleReportPluginWorkSpaceViewItemPlugin : ViewItemPlugin
    {
        public PeopleReportPluginWorkSpaceViewItemPlugin()
        {
        }

        public override Guid Id
        {
            get { return PeopleReportPluginDefinition.PeopleReportPluginWorkSpaceViewItemPluginId; }
        }

        public override VideoOSIconSourceBase IconSource { get => PeopleReportPluginDefinition.PluginIcon; protected set => base.IconSource = value; }

        public override string Name
        {
            get { return "WorkSpace Plugin View Item"; }
        }

        public override bool HideSetupItem
        {
            get
            {
                return false;
            }
        }

        public override ViewItemManager GenerateViewItemManager()
        {
            return new PeopleReportPluginWorkSpaceViewItemManager();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }


    }
}
