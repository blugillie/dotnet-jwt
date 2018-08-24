using System;
using System.Collections.Generic;
using dotnetJwt.Data;
using dotnetJwt.Entities;

namespace dotnetJwt.InMemoryProvider 
{

    public static class TestData 
    {
        public static void AddTestData(DataContext dataContext) 
        {
            TaskEntity entity1 = new TaskEntity();
            entity1.Id = Guid.NewGuid();
            entity1.Title = "testing";
            entity1.IsDone = true;
            entity1.DeadLine = new DateTime();

            TaskEntity entity2 = new TaskEntity();
            entity2.Id = Guid.NewGuid();
            entity2.Title = "title";
            entity2.IsDone = true;
            entity2.DeadLine = new DateTime();

            TaskEntity entity3 = new TaskEntity();
            entity3.Id = Guid.NewGuid();
            entity3.Title = "another test";
            entity3.IsDone = false;
            entity3.DeadLine = new DateTime();

            TaskEntity entity4 = new TaskEntity();
            entity4.Id = Guid.NewGuid();
            entity4.Title = "and another ojne";
            entity4.IsDone = false;
            entity4.DeadLine = new DateTime();

            List<TaskEntity> tasks = new List<TaskEntity>();
            tasks.Add(entity1);
            tasks.Add(entity2);
            tasks.Add(entity3);
            tasks.Add(entity4);

            dataContext.AddRange(tasks);
            dataContext.SaveChanges();
        }
    }

}