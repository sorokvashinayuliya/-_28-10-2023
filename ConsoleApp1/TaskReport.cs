using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TaskReport
    {
        private string reportText;
        private DateTime dateAcceptanceTheReport;
        private Employee executor;
        private ProjectTask taskToWhichReportBelongs;
        public string ReportText
        {
            get
            {
                return reportText;
            }
        }
        public DateTime DateAcceptanceTheReport
        {
            get
            {
                return dateAcceptanceTheReport;
            }
        }
        public Employee Executor
        {
            get
            {
                return executor;
            }
        }
        public ProjectTask TaskToWhichReportBelongs
        {
            get
            {
                return taskToWhichReportBelongs;
            }
        }
        public void AddReportAcceptanceDate(DateTime dateCompletionReport)
        {
            dateAcceptanceTheReport = dateCompletionReport;

        }
        public void RewriteTheTaskReport()
        {
            reportText = $"Отчет на тему {taskToWhichReportBelongs.TaskDescription}";
        }
        public TaskReport(string reportText, Employee executor, ProjectTask taskToWhichReportBelongs)
        {
            this.reportText = reportText;
            this.executor = executor;
            this.taskToWhichReportBelongs = taskToWhichReportBelongs;
        }
    }
}
