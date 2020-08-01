using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace What2DoDL
{
    public class Tasks
    {
        private const int _ID_COLUMN = 0;
        private const int _NAME_COLUMN = 1;
        private const int _DATE_CREATED_COLUMN = 2;
        private const int _STATUS_COLUMN = 3;

        public List<Task> Items { get; private set; }
        public bool Saved { get; set; }

        public Tasks()
        {
            Items = new List<Task>();
            Saved = false;
        }

        public void Add(Task newTask)
        {
            Items.Add(newTask);
            Saved = false;
        }

        public void Clear()
        {
            Items.Clear();
            Saved = true;
        }

        public void Remove(Task itemToRemove)
        {
            Items.Remove(itemToRemove);
            Saved = false;
        }

        public int Count()
        {
            return Items.Count;
        }

        public int Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || File.Exists(fileName) == false)
            {
                Saved = false;
                return 0;
            }

            // Read the contents of the list from the file.
            // Since we're using the file, we don't have to
            // worry about disposing of it when we're done.
            using (StreamReader reader = File.OpenText(fileName))
            {
                string lineIn;
                string[] columns;

                while (!reader.EndOfStream)
                {
                    // Get the line and split it
                    // into separate columns.
                    lineIn = reader.ReadLine();
                    columns = lineIn.Split('\t');

                    // Assign the column values
                    // to the properties of a
                    // movie object.
                    Task t = new Task(columns[_ID_COLUMN],
                        columns[_NAME_COLUMN],
                        columns[_DATE_CREATED_COLUMN],
                        (TaskStatus)Enum.Parse(typeof(TaskStatus), columns[_STATUS_COLUMN]));

                    // Add the movie to list.
                    Items.Add(t);
                }

            }
            // When the file has just been loaded
            // from disk, it is also "saved"
            Saved = true;
            return Items.Count;
        }

        public bool Save(string fileName)
        {
            // Write the contents of the list to the file.
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (Task t in Items)
                {
                    StringBuilder stringOut = new StringBuilder(t.Id.ToString());
                    stringOut.Append("\t" + t.Name);
                    stringOut.Append("\t" + t.DateCreated.ToString());
                    stringOut.Append("\t" + t.Status);
                    writer.WriteLine(stringOut);
                }

            }
            Saved = true;
            return true;
        }
    }
}
