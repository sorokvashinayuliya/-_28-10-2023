using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum ProjectStatuses
    {
        Проект,
        Исполнение,
        Закрыт
    }
    internal class Project
    {
        private string projectDescription;
        private DateTime projectDeadline;
        private string projectCustomer;
        private Employee teamLead;
        private ProjectStatuses projectStatus;
        private List<ProjectTask> projectTasks = new List<ProjectTask>();
        public string ProjectDescription
        {
            get
            {
                return projectDescription;
            }
        }
        public DateTime ProjectDeadline
        {
            get
            {
                return projectDeadline;
            }
        }
        public string ProjectCustomer
        {
            get
            {
                return projectCustomer;
            }
        }
        public Employee TeamLead
        {
            get
            {
                return teamLead;
            }
        }
        public ProjectStatuses ProjectStatus
        {
            get
            {
                return projectStatus;
            }
        }
        public List<ProjectTask> ProjectTasks
        {
            get
            {
                return projectTasks;
            }
        }
        public bool AppointTeamLeader(Employee teamLead)
        {
            if ((teamLead.AssignedTask == null) && (this.teamLead == null) && (projectStatus == ProjectStatuses.Проект))
            {
                teamLead.AddTask(this);
                this.teamLead = teamLead;

                return true;
            }

            return false;
        }
        public bool AddingTaskToList(ProjectTask projectTask)
        {
            if (projectStatus == ProjectStatuses.Проект)
            {
                projectTasks.Add(projectTask);

                return true;
            }

            return false;
        }
        public bool RemoveTaskFromList(ProjectTask projectTask)
        {
            if (projectStatus == ProjectStatuses.Проект)
            {
                projectTasks.Remove(projectTask);

                return true;
            }

            return false;
        }
        public void TransitionToExecutionStatus()
        {
            if (projectStatus == ProjectStatuses.Проект)
            {
                bool checkResult = true;

                for (int i = 0; i < projectTasks.Count; i++)
                {
                    if (projectTasks[i].TaskStatus != TaskStatuses.В_работе)
                    {
                        checkResult = false;
                        break;
                    }
                }

                if (checkResult)
                {
                    projectStatus = ProjectStatuses.Исполнение;
                }
            }
        }
        public void TransitionToClosedStatus()
        {
            if (projectStatus == ProjectStatuses.Исполнение)
            {
                bool checkResult = true;

                for (int i = 0; i < projectTasks.Count; i++)
                {
                    if (projectTasks[i].TaskStatus != TaskStatuses.Выполнена)
                    {
                        checkResult = false;
                        break;
                    }
                }

                if (checkResult)
                {
                    projectStatus = ProjectStatuses.Закрыт;
                }
            }
        }
        public Project(string projectDescription, DateTime projectDeadline, string projectCustomer)
        {
            this.projectDescription = projectDescription;
            this.projectDeadline = projectDeadline;
            this.projectCustomer = projectCustomer;
            projectStatus = ProjectStatuses.Проект;
            teamLead = null;
        }


    }
}
