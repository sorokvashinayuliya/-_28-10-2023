using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee Vitya = new Employee("Витя");
            Employee Maria = new Employee("Мария");
            Employee Anton = new Employee("Антон");
            Employee Volodya = new Employee("Володя");
            Employee Anna = new Employee("Анна");
            Employee Alina = new Employee("Алина");
            Employee Peter = new Employee("Петр");
            Employee Ivan = new Employee("Иван");
            Employee Ilya = new Employee("Илья");
            Employee Anastasia = new Employee("Анастасия");
            Employee Zhenya = new Employee("Женя");

            Console.WriteLine($"Сотрудники компании: {Vitya.EmployeeName}, {Maria.EmployeeName}, {Anton.EmployeeName}, {Volodya.EmployeeName}, {Anna.EmployeeName}, " +
                              $"{Alina.EmployeeName}, {Peter.EmployeeName}, {Ivan.EmployeeName}, {Ilya.EmployeeName}, {Anastasia.EmployeeName}, {Zhenya.EmployeeName}");
            Project gameDevelopment = new Project("Разработать компьютерную игру", DateTime.Today.AddYears(1), "ООО GameCompany");
            gameDevelopment.AppointTeamLeader(Vitya);

            Console.WriteLine($"Описание проекта: {gameDevelopment.ProjectDescription}. Срок сдачи: {gameDevelopment.ProjectDeadline.ToLongDateString()}\n" +
                              $"Заказчик: {gameDevelopment.ProjectCustomer}. Ответсвенный: {gameDevelopment.TeamLead.EmployeeName}. Статус проекта: {gameDevelopment.ProjectStatus}");
            Vitya.CreatingTask("Написать сюжет", DateTime.Today.AddMonths(2));
            Vitya.CreatingTask("Выбрать главного героя", DateTime.Today.AddMonths(2));
            Vitya.CreatingTask("Нарисовать текстуры", DateTime.Today.AddMonths(4));
            Vitya.CreatingTask("Нарисовать карту игры", DateTime.Today.AddMonths(1));
            Vitya.CreatingTask("Сделать анимации", DateTime.Today.AddMonths(7));
            Vitya.CreatingTask("Разработать механику игры", DateTime.Today.AddMonths(10));
            Vitya.CreatingTask("Разработать интерфейс", DateTime.Today.AddMonths(6));
            Vitya.CreatingTask("Прорекламировать игру", DateTime.Today.AddMonths(10));
            Vitya.CreatingTask("Протестировать", DateTime.Today.AddMonths(9));
            Vitya.CreatingTask("Исправить ошибки", DateTime.Today.AddMonths(11));

            List<ProjectTask> projectTasks = gameDevelopment.ProjectTasks;
            for (int i = 0; i < projectTasks.Count; i++)
            {
                Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", $"{projectTasks[i].TaskDescription}", $"{projectTasks[i].TaskDeadline.ToLongDateString()}",
                                                                     $"{projectTasks[i].TaskAssigner.EmployeeName}", $"{projectTasks[i].TaskStatus}");
            }
            Vitya.DistributeTheTask(projectTasks[0], Maria, DateTime.Today.AddDays(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[1], Anton, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[2], Volodya, DateTime.Today.AddDays(2), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[3], Anna, DateTime.Today.AddDays(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[4], Alina, DateTime.Today.AddMonths(2), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[5], Peter, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[6], Ivan, DateTime.Today.AddDays(7), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[7], Ilya, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[8], Anastasia, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[9], Zhenya, DateTime.Today.AddDays(7), DateTime.Today);
            projectTasks = gameDevelopment.ProjectTasks;
            for (int i = 0; i < projectTasks.Count; i++)
            {
                Console.WriteLine($"{projectTasks[i].TaskDescription}", $"{projectTasks[i].TaskDeadline.ToLongDateString()}",
                                                                     $"{projectTasks[i].TaskPerformer.EmployeeName}", $"{projectTasks[i].TaskStatus}");
            }
            for (DateTime date = DateTime.Today; date <= gameDevelopment.ProjectDeadline; date = date.AddDays(1))
            {
                for (int i = 0; i < projectTasks.Count; i++)
                {
                    if ((projectTasks[i].NextTaskReportDate == date) && (projectTasks[i].TaskStatus == TaskStatuses.В_работе))
                    {
                        bool checkResult = false;
                        TaskReport taskReport = projectTasks[i].TaskPerformer.CreatingReport($"Отчет задачи {projectTasks[i].TaskDescription}", date);

                        do
                        {
                            bool result;
                            Random randomNumbers = new Random();
                            int randomNum = randomNumbers.Next(0, 2);

                            if (randomNum == 0)
                            {
                                result = false;
                            }
                            else
                            {
                                result = true;
                            }

                            checkResult = projectTasks[i].TaskAssigner.CheckingTheReport(result, taskReport, date);
                        } while (!checkResult);

                        if (checkResult)
                        {
                            if (date == projectTasks[i].TaskDeadline)
                            {
                                projectTasks[i].CheckingTask(Vitya);
                                projectTasks[i].ProjectToWhichItRelates.TransitionToClosedStatus();
                            }

                        }
                        Console.WriteLine($"\nОписание проекта: {gameDevelopment.ProjectDescription}. Срок сдачи: {gameDevelopment.ProjectDeadline.ToLongDateString()}\n" +
                              $"Заказчик: {gameDevelopment.ProjectCustomer}. Ответсвенный: {gameDevelopment.TeamLead.EmployeeName}. Статус проекта: {gameDevelopment.ProjectStatus}\n");
                        for (int i = 0; i < projectTasks.Count; i++)
                        {
                            Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", $"{projectTasks[i].TaskDescription}", $"{projectTasks[i].TaskDeadline.ToLongDateString()}",
                                                                                 $"{projectTasks[i].TaskPerformer.EmployeeName}", $"{projectTasks[i].TaskStatus}");
                        }
                    }
                }
            }
        }
    }
}
