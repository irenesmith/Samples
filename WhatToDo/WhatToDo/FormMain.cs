using System;
using System.Windows.Forms;
using System.IO;
using What2DoDL;

namespace WhatToDo
{
    public partial class FormMain : Form
    {
        Tasks _tasks;
        string _FileName;

        public FormMain()
        {
            InitializeComponent();

            // Get the name of the file that the user
            // wants to use to store tasks.
            _FileName = Properties.Settings.Default.FileNameSetting;
            _tasks = new Tasks();
            var binding = new BindingSource();

            if (File.Exists(_FileName))
            {
                var count = _tasks.Load(_FileName);
                binding.DataSource = _tasks.Items;
                dataViewTasks.DataSource = binding;
            }
            else
            {
                binding.DataSource = _tasks.Items;
                dataViewTasks.DataSource = binding;
            }
            dataViewTasks.Refresh();
            this.Text = $"{ _FileName} - What To Do";
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            if(_tasks.Count() > 0 && !_tasks.Saved)
            {
                string box_msg = "You have unsaved changes. Save before creating a new list?";
                string box_title = "Confirm New File";

                var result = MessageBox.Show(box_msg, box_title, MessageBoxButtons.YesNoCancel);
                switch(result) {
                    case DialogResult.Yes:
                        _tasks.Save(_FileName);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return;
                    default:
                        return;
                }
            }

            _tasks.Clear();
        }

        private void dataViewTasks_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _tasks.Saved = false;
        }

        private void dataViewTasks_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _tasks.Saved = false;
        }
    }
}
