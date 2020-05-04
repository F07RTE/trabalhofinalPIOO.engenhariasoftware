using Database.Context;
using Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Action
{
    public class AdministratorAction
    {
        DbContextOptionsBuilder<AdministratorContext> optionsBuilder;

        public AdministratorAction()
        {
            optionsBuilder = new DbContextOptionsBuilder<AdministratorContext>();
            optionsBuilder.UseSqlServer("Server = LAPTOP-FU814NT7; Database = TASK_ORGANIZER; User Id = sa; Password = 123;");
        }

        public bool AdministratorAccessValidation(Administrator administrator)
        {
            using (var context = new AdministratorContext(optionsBuilder.Options))
            {

                try
                {
                    var result = context.Administrator.Where(a => a.Password == administrator.Password).Where(a => a.Name == administrator.Name).Select(p => new Administrator() { ID = p.ID, Name = p.Name, Password = p.Password });

                    if (result.Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException);
                }

                return false;
            }
        }
    }
}
