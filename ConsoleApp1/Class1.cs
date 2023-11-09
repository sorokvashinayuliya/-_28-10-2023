using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum TaskStatuses
    {
        Назначена,
        Не_назначена,
        В_работе,
        На_проверке,
        Выполнена
    }
    internal class ProjectTask
    {
        private string taskDescription;
        private DateTime taskDeadline;
        private DateTime startDateAfterReport;
        private DateTime nextTaskReportDate;
        private Employee taskAssigner;
        private Employee taskPerformer;
        private TaskStatuses taskStatus;
        private Project projectToWhichItRelates;
        private List<TaskReport> taskReports = new List<TaskReport>();
        private Employee employee;
        private Project project;

        public ProjectTask(string taskDescription, DateTime taskDeadline, Employee employee, Project project)
        {
            this.taskDescription = taskDescription;
            this.taskDeadline = taskDeadline;
            this.employee = employee;
            this.project = project;
        }

        public string TaskDescription
        {
            get
            {
                return taskDescription;
            }
        }
        public DateTime TaskDeadline
        {
            get
            {
                return taskDeadline;
            }
        }
        public DateTime StartDateAfterReport
        {
            get
            {
                return startDateAfterReport;
            }
        }
        public DateTime NextTaskReportDate
        {
            get
            {
                return nextTaskReportDate;
            }
        }
        public Employee TaskAssigner
        {
            get
            {
                return taskAssigner;
            }
        }
        public Employee TaskPerformer
        {
            get
            {
                return taskPerformer;
            }
        }
        public TaskStatuses TaskStatus
        {
            get
            {
                return taskStatus;
            }
        }
        public Project ProjectToWhichItRelates
        {
            get
            {
                return projectToWhichItRelates;
            }
        }
        public List<TaskReport> TaskReports
        {
            get
            {
                return taskReports;
            }
        }
        public void AddingTaskPerformer(Employee newTaskPerformer)
        {
            ProjectTask projectTask = newTaskPerformer.AssignedTask as ProjectTask;

            if (projectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект)
            {
                if (projectTask != null)
                {
                    projectTask.taskPerformer = null;
                    projectTask.taskStatus = TaskStatuses.Не_назначена;
                }

                taskPerformer = newTaskPerformer;
                taskStatus = TaskStatuses.Назначена;
            }
            void TransitionToStatusWork()
            {
                if (projectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект)
                {
                    taskStatus = TaskStatuses.В_работе;
                }
            }
            void SettingReportDate(DateTime taskReportDate, DateTime dateAfterReport)
            {
                startDateAfterReport = dateAfterReport;
                nextTaskReportDate = taskReportDate;
            }
            void RemovePerformer()
            {
                if (projectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект)
                {
                    taskPerformer = null;
                    taskStatus = TaskStatuses.Не_назначена;
                }
            }
            void AddTaskReportToList(TaskReport taskReport)
            {
                if (taskStatus == TaskStatuses.В_работе)
                {
                    taskReports.Add(taskReport);
                }
            }
            void CheckingTask(Employee taskAssigner)
            {
                if (this.taskAssigner == TaskAssigner)
                {
                    taskStatus = TaskStatuses.На_проверке;
                    TransitionToStageCompleted();
                }
            }
            void TransitionToStageCompleted()
            {
                if (taskStatus == TaskStatuses.На_проверке)
                {
                    taskStatus = TaskStatuses.Выполнена;
                }
            }
            void ProjectTask(string taskDescription, DateTime taskDeadline, Employee taskAssigner, Project projectToWhichItRelates)
            {
                this.taskDescription = taskDescription;
                this.taskDeadline = taskDeadline;
                this.taskAssigner = taskAssigner;
                this.projectToWhichItRelates = projectToWhichItRelates;
                taskStatus = TaskStatuses.Не_назначена;
                taskPerformer = null;
            }
        }

        internal void AddTaskReportToList(TaskReport taskReport)
        {
            throw new NotImplementedException();
        }

        internal void RemovePerformer()
        {
            throw new NotImplementedException();
        }

        internal void SettingReportDate(DateTime nextTaskReportDate, DateTime dateAfterReport)
        {
            throw new NotImplementedException();
        }

        internal void TransitionToStatusWork()
        {
            throw new NotImplementedException();
        }
    }
}

