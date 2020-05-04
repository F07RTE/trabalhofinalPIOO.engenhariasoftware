using Database.Action;
using Database.Context;
using Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //bool  result = false;

            //AdministratorAction adminAction = new AdministratorAction();

            //Administrator admin = new Administrator();
            //admin.Name = "Guilherme";
            //admin.Password = "123";

            //result = adminAction.AdministratorAccessValidation(admin);

            List<Task> tasks = new List<Task>();
            TaskAction taskAction = new TaskAction();

            tasks = taskAction.TaskSelectAll();

            Console.WriteLine(tasks.Count);
            Console.WriteLine("Atualização finalizada");
        }
    }
}
