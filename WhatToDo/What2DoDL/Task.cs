using System;
using System.Collections.Generic;
using System.Text;

namespace What2DoDL
{
    public class Task
    {
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; set; }
        public bool IsDone { get; set; }
        public string Name { get; set; }

        public Task()
        {
            Id = Guid.NewGuid();
            Name = "New Task";
            DateCreated = DateTime.Now;
            IsDone = false;
        }

        public Task(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateCreated = DateTime.Now;
            IsDone = false;
        }

        public Task(string id, string name, string dateCreated, bool isDone)
        {
            Id = new Guid(id);
            Name = name;
            DateCreated = Convert.ToDateTime(dateCreated);
            IsDone = isDone;
        }
    }

}
