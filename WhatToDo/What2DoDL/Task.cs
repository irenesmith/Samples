using System;
using System.Collections.Generic;
using System.Text;

namespace What2DoDL
{
    public class Task
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public TaskStatus Status { get; set; }

        public Task()
        {
            Id = new Guid();
            Name = "New Task";
            DateCreated = DateTime.Now;
            Status = TaskStatus.ToDo;
        }

        public Task(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateCreated = DateTime.Now;
            Status = TaskStatus.ToDo;
        }

        public Task(String id, String name, DateTime dateCreated, TaskStatus status)
        {
            Id = new Guid(id);
            Name = name;
            DateCreated = dateCreated;
            Status = status;
        }
    }

}
