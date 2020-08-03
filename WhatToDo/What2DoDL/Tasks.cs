using System;
using System.Collections.Generic;
using System.IO;
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
        public int Count => Items.Count;

        public Tasks()
        {
            Items = new List<Task>();
            Saved = false;
        }

        public int Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || File.Exists(fileName) == false)
            {
                Saved = false;
                return 0;
            }

            // Read the contents of the list from the file.
            using (StreamReader reader = File.OpenText(fileName))
            {
                string lineIn;
                string[] columns;

                while (!reader.EndOfStream)
                {
                    // Split the line into columns at the tabs.
                    lineIn = reader.ReadLine();
                    columns = lineIn.Split('\t');

                    // Assign the column values to a new Task
                    // object and add it to the list.
                    Items.Add(new Task(columns[_ID_COLUMN],
                        columns[_NAME_COLUMN],
                        columns[_DATE_CREATED_COLUMN],
                        Convert.ToBoolean(columns[_STATUS_COLUMN])));
                }

            }
            // The file was just loaded so it's also "saved"
            Saved = true;
            return Items.Count;
        }

        public bool Save(string fileName)
        {
            // Write the contents of the list to the file.
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (var t in Items)
                {
                    var stringOut = new StringBuilder(
                        $"{t.Id}\t{t.Name}\t{ t.DateCreated}\t{t.IsDone}"
                    );
                    writer.WriteLine(stringOut);
                }

            }
            Saved = true;
            return true;
        }
    }
}
