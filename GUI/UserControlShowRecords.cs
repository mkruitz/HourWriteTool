using System;
using System.Collections.Generic;
using System.Drawing;
using Core;
using Raven.Abstractions.Extensions;

namespace GUI
{
    public partial class UserControlShowRecords : UserControlWithStore
    {
        public UserControlShowRecords()
        {
            InitializeComponent();
            StoreChanged += OnStoreChanged;
        }

        public override string Title
        {
            get { return "Show Records"; }
        }

        public override Size SizeToStart
        {
            get { return new Size(404, 295); }
        }

        private void OnStoreChanged()
        {
            listBoxRecords.Items.Clear();

            var report = new WorkTimeReportGenerator(Store).GetReport();

            AddHeaderLine("Total");
            AddLineTotalTime(report);

            AddHeaderLine("Details");
            report.WorkedOnDays.ForEach(AddDateDetails);

            AddEmptyLine();
            AddHeaderLine("All records");
            Store.GetEvents().ForEach(AddLine);
            AddHeaderLine("End");
        }

        private void AddDateDetails(KeyValuePair<DateTime, GroupOfEventsReport> pair)
        {
            AddLine(String.Format("Date: {0}", pair.Key.ToString("yyyy-MM-dd")));
            AddLineTotalTime(pair.Value);
        }

        private void AddLineTotalTime(GroupOfEventsReport report)
        {
            var groupedEvents = report.TotalTimeWorked;
            AddLine(String.Format("Report worked{0} {1:D2}:{2:D2}",
                (groupedEvents.Days > 0)
                    ? String.Format(" {0} day(s)", groupedEvents.Days)
                    : String.Empty,
                groupedEvents.Hours,
                groupedEvents.Minutes));
        }

        private void AddHeaderLine(string title)
        {
            AddLine(String.Format("=== {0} ===", title));
        }

        private void AddEmptyLine()
        {
            AddLine(String.Empty);
        }

        private void AddLine(HourWriteEvent evnt)
        {
            AddLine(evnt.ToString());
        }

        private void AddLine(string text)
        {
            listBoxRecords.Items.Add(text);
        }
    }
}
