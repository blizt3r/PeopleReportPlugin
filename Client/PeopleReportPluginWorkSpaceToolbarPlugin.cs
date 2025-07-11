using System;
using System.Collections.Generic;
using VideoOS.Platform;
using VideoOS.Platform.Client;

namespace PeopleReportPlugin.Client
{
    internal class PeopleReportPluginWorkSpaceToolbarPluginInstance : WorkSpaceToolbarPluginInstance
    {
        private Item _window;

        public PeopleReportPluginWorkSpaceToolbarPluginInstance()
        {
        }

        public override void Init(Item window)
        {
            _window = window;

            Title = "PeopleReportPlugin";
        }

        public override void Activate()
        {
            // Here you should put whatever action that should be executed when the toolbar button is pressed
        }

        public override void Close()
        {
        }

    }

    internal class PeopleReportPluginWorkSpaceToolbarPlugin : WorkSpaceToolbarPlugin
    {
        public PeopleReportPluginWorkSpaceToolbarPlugin()
        {
        }

        public override Guid Id
        {
            get { return PeopleReportPluginDefinition.PeopleReportPluginWorkSpaceToolbarPluginId; }
        }

        public override string Name
        {
            get { return "PeopleReportPlugin"; }
        }

        public override void Init()
        {
            // TODO: remove below check when PeopleReportPluginDefinition.PeopleReportPluginWorkSpaceToolbarPluginId has been replaced with proper GUID
            if (Id == new Guid("22222222-2222-2222-2222-222222222222"))
            {
                System.Windows.MessageBox.Show("Default GUID has not been replaced for PeopleReportPluginWorkSpaceToolbarPluginId!");
            }

            WorkSpaceToolbarPlaceDefinition.WorkSpaceIds = new List<Guid>() { ClientControl.LiveBuildInWorkSpaceId, ClientControl.PlaybackBuildInWorkSpaceId, PeopleReportPluginDefinition.PeopleReportPluginWorkSpacePluginId };
            WorkSpaceToolbarPlaceDefinition.WorkSpaceStates = new List<WorkSpaceState>() { WorkSpaceState.Normal };
        }

        public override void Close()
        {
        }

        public override WorkSpaceToolbarPluginInstance GenerateWorkSpaceToolbarPluginInstance()
        {
            return new PeopleReportPluginWorkSpaceToolbarPluginInstance();
        }
    }
}
