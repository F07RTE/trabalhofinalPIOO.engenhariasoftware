using Database.Context;
using Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Action
{
    public class TaskAction
    {
        DbContextOptionsBuilder<TaskContext> optionsBuilder;

        public TaskAction()
        {
            optionsBuilder = new DbContextOptionsBuilder<TaskContext>();
            optionsBuilder.UseSqlServer("Server = LAPTOP-FU814NT7; Database = TASK_ORGANIZER; User Id = sa; Password = 123;");
        }

        public List<Task> TaskSelectAll()
        {
            using (var context = new TaskContext(optionsBuilder.Options))
            {
                List<Task> result = null;

                try
                {
                    result = context.Task.Select(x => x).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException);
                }

                return result;
            }
        }

        public Task TaskSelect(int id)
        {
            using (var context = new TaskContext(optionsBuilder.Options))
            {
                Model.Task result = null;

                try
                {
                    result = context.Task.Find(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException);
                }

                return result;
            }
        }

        public bool TaskInsert(Task task)
        {
            bool result;

            using (var context = new TaskContext(optionsBuilder.Options))
            {
                var newTask = new Task()
                {
                    ID = task.ID,
                    Name = task.Name,
                    Description = task.Description,
                    DueDate = task.DueDate
                };

                try
                {
                    context.Task.Add(newTask);
                    int response = context.SaveChanges();

                    if(response == 1)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException);

                    result = false;
                }

                return result;
            }
        }

        public bool TaskUpdate(Task task)
        {
            bool result;

            using (var context = new TaskContext(optionsBuilder.Options))
            {
                var newTask = new Task()
                {
                    ID = task.ID,
                    Name = task.Name,
                    Description = task.Description,
                    DueDate = task.DueDate
                };

                try
                {
                    context.Task.Update(newTask);
                    int response = context.SaveChanges();

                    if (response == 1)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException);

                    result = false;
                }

                return result;
            }
        }

        public bool TaskDelete(int id)
        {
            bool result;

            using (var context = new TaskContext(optionsBuilder.Options))
            {
                var task = new Task()
                {
                    ID = id
                };

                try
                {
                    context.Task.Remove(task);
                    int response = context.SaveChanges();

                    if (response == 1)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException);

                    result = false;
                }

                return result;
            }
        }
    }
}
