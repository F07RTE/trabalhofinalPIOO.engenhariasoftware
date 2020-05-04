using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class TaskContext: DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
           
        }

        //Entities
        public DbSet<Model.Task> Task { get; set; }
    }
}
