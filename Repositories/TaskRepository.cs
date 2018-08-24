


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetJwt.Contracts;
using dotnetJwt.Data;
using dotnetJwt.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnetJwt.Repositories {

    public class TaskRepository : ITaskRepository {
        
        private readonly DataContext context;

        public TaskRepository(DataContext context) {
            this.context = context;
        }

        public async Task<TaskEntity> AddTask(TaskEntity task)
        {
            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskEntity> DeleteTask(Guid id)
        {
            TaskEntity task = await context.Tasks.SingleOrDefaultAsync(e => e.Id == id);
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await context.Tasks.AnyAsync(e => e.Id == id);
        }

        public async Task<TaskEntity> FindTask(Guid id)
        {
            return await context.Tasks.FindAsync(id);
        }

        public IEnumerable<TaskEntity> GetAllTasks()
        {
            return context.Tasks;
        }

        public async Task<TaskEntity> UpdateTask(TaskEntity task)
        {
            context.Entry(task).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return task;
        }
    }
}