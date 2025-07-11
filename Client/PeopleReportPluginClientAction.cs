using System;
using System.Windows;
using System.Windows.Media.Imaging;
using VideoOS.Platform.Client;
using VideoOS.Platform.UI.Controls;

namespace PeopleReportPlugin.Client
{
    public class PeopleReportPluginClientAction : ClientAction
    {
        public override Guid Id
        {
            get => PeopleReportPluginDefinition.PeopleReportPluginClientActionId;
        }

        public override string Name
        {
            get => "PeopleReportPlugin Client Action"; //Note that the action name should be localized (unless it contains a name of an Item or similar).
        }

        public override VideoOSIconSourceBase Icon
        {
            get => PeopleReportPluginDefinition.PluginIcon;
        }

        public override void Init()
        {
            // TODO: remove below check when PeopleReportPluginDefinition.PeopleReportPluginClientActionId has been replaced with proper GUID
            if (Id == new Guid("55555555-5555-5555-5555-555555555550"))
            {
                System.Windows.MessageBox.Show("Default GUID has not been replaced for PeopleReportPluginClientActionId!");
            }
        }

        public override void Close()
        {
        }

        public override void Activated()
        {
            MessageBox.Show("PeopleReportPlugin Client Action activated.");
        }
    }
}