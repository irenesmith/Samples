using System;
using System.Collections.Generic;
using System.Text;

namespace What2DoDL
{
    public class Tasks
    {
        public string _FileName { get; private set; }
        List<Task> Items { get; set; }

        public Tasks(string fileName)
        {
            _FileName = fileName;
            Items = new List<Task>();
        }
    }
}
