using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Employee
    {
        private string employeeName;
        private object assignedTask;
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
        }
        public object AssignedTask
        {
            get
            {
                return assignedTask;
            }
        }
        public bool CreatingTask(string taskDescription, DateTime taskDeadline)
        {
            Project project = assignedTask as Project;

            if ((project != null) && (project.ProjectStatus == ProjectStatuses.Проект))
            {
                ProjectTask projectTask = new ProjectTask(taskDescription, taskDeadline, this, project);
                project.AddingTaskToList(projectTask);

                return true;
            }

            return false;
            public bool DistributeTheTask(ProjectTask projectTask, Employee tasPerformer, DateTime taskReportDate, DateTime taskStartDate)
            {
                if ((assignedTask is Project project) && (projectTask.TaskPerformer == null) && (tasPerformer.AssignedTask == null) && (project.ProjectStatus == ProjectStatuses.Проект))
                {
                    tasPerformer.AddTask(projectTask);
                    projectTask.AddingTaskPerformer(tasPerformer);
                    projectTask.SettingReportDate(taskReportDate, taskStartDate);

                    return true;
                }

                return false;
            }
            public bool DeleteTask(ProjectTask projectTask)
            {
                if ((assignedTask is Project project) && (project.ProjectStatus == ProjectStatuses.Проект))
                {
                    project.RemoveTaskFromList(projectTask);

                    return true;
                }

                return false;
            }
            public bool AddTask(object task)
            {
                ProjectTask projectTask = task as ProjectTask;

                if ((task is Project project) && (assignedTask == null) && (project.TeamLead == null) && (project.ProjectStatus == ProjectStatuses.Проект))
                {
                    assignedTask = project;

                    return true;
                }
                else if ((projectTask != null) && (assignedTask == null) && (projectTask.TaskPerformer == null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
                {
                    assignedTask = projectTask;

                    return true;
                }

                return false;
            }
            public bool TakeTask()
            {
                ProjectTask projectTask = assignedTask as ProjectTask;

                if ((projectTask != null) && (projectTask.ProjectToWhichItRelates != null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
                {
                    projectTask.TransitionToStatusWork();
                    projectTask.ProjectToWhichItRelates.TransitionToExecutionStatus();

                    return true;
                }

                return false;
            }
            public bool DelegateTask(Employee newTaskPerformer)
            {
                ProjectTask projectTask = assignedTask as ProjectTask;

                if ((projectTask != null) && (projectTask.ProjectToWhichItRelates != null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
                {
                    projectTask.AddingTaskPerformer(newTaskPerformer);

                    assignedTask = null;
                    newTaskPerformer.assignedTask = projectTask;

                    return true;
                }

                return false;
            }
            public bool AbandonTheTask()
            {
                ProjectTask projectTask = assignedTask as ProjectTask;

                if ((projectTask != null) && (projectTask.ProjectToWhichItRelates != null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
                {
                    projectTask.RemovePerformer();
                    assignedTask = null;

                    return true;
                }

                return false;
            }
            public TaskReport CreatingReport(string reportText, DateTime dateAfterReport)
            {
                ProjectTask projectTask = assignedTask as ProjectTask;

                if ((projectTask != null) && (projectTask.TaskStatus == TaskStatuses.В_работе))
                {
                    TaskReport taskReport = new TaskReport(reportText, this, projectTask);
                    DateTime nextTaskReportDate = projectTask.NextTaskReportDate.Add(projectTask.NextTaskReportDate.Subtract(projectTask.StartDateAfterReport));

                    if (nextTaskReportDate <= projectTask.TaskDeadline)
                    {
                        projectTask.SettingReportDate(nextTaskReportDate, dateAfterReport);
                    }
                    else
                    {
                        projectTask.SettingReportDate(projectTask.TaskDeadline, dateAfterReport);
                    }

                    return taskReport;
                }

                return null;
            }
            public bool CheckingTheReport(bool checkResult, TaskReport taskReport, DateTime date)
            {
                if (taskReport.TaskToWhichReportBelongs.TaskAssigner == this)
                {
                    if (checkResult)
                    {
                        taskReport.AddReportAcceptanceDate(date);
                        taskReport.TaskToWhichReportBelongs.AddTaskReportToList(taskReport);
                        return true;
                    }
                    else
                    {
                        taskReport.RewriteTheTaskReport();
                        return false;
                    }
                }

                return false;
            }
            public Employee(string employeeName)
            {
                this.employeeName = employeeName;
            }
        }

        private void AddTask(ProjectTask projectTask)
        {
            throw new NotImplementedException();
        }
    }
}
