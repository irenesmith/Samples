using System;
using System.Windows.Forms;
using System.IO;
using What2DoDL;

namespace WhatToDo
{
    public partial class FormMain : Form
    {
        const string MSGBOX_MSG = "You have unsaved changes. Save before continuing?";
        const string MSGBOX_TITLE = "Save Changes?";

        private Tasks _tasks;
        private string _FileName;

        public FormMain()
        {
            InitializeComponent();

            // Get the file name from the Program Settings
            // If the user has run the program it will use
            // the file that was last saved. If not, it will
            // use the default name, "TaskList.txt"
            _FileName = Properties.Settings.Default.FileNameSetting;
            _tasks = new Tasks();

            // Load returns a count. Right now, we don't care.
            if (File.Exists(_FileName))
                _ = _tasks.Load(_FileName);

            // Now, whether we loaded tasks or not, bind
            // the _tasks variable list to the DataGridView
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _tasks.Items;
            dataViewTasks.DataSource = bindingSource;

            // Set the window title to include the name of
            // the file loaded.
            this.Text = $"{ _FileName} - What To Do";
        }

        private void FileNew_Click(object sender, EventArgs e)
        {
            // If there are unsaved changes, ask whether the
            // user wants to save first.
            if(_tasks.Count > 0 && !_tasks.Saved)
            {
                var result = MessageBox.Show(MSGBOX_MSG, MSGBOX_TITLE, MessageBoxButtons.YesNoCancel);
                switch(result) {
                    case DialogResult.Yes:
                        _tasks.Save(_FileName);
                        break;
                    case DialogResult.No:
                        // Don't save
                        break;
                    case DialogResult.Cancel:
                        // CancelButton File/Open
                        return;
                    default:
                        return;
                }
            }

            // The user doesn't want to save first
            // Just clear the contents of the list.
            _tasks.Clear();
            _FileName = "Untitled";
            this.Text = $"{_FileName} - What to Do";
        }

        private void FileOpen_Click(object sender, EventArgs e)
        {
            // Load returns a count. Right now, we don't care.
            // Get a new file name to open.
            openFileDlg.FileName = _FileName;
            var result = openFileDlg.ShowDialog();

            if(result == DialogResult.Cancel)
            {
                return;
            }

            _tasks.Clear();
            _FileName = openFileDlg.FileName;
            _ = _tasks.Load(_FileName);

            // Now, whether we loaded tasks or not, bind
            // the _tasks variable list to the DataGridView
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _tasks.Items;
            dataViewTasks.DataSource = bindingSource;

            // Set the window title to include the name of
            // the file loaded.
            this.Text = $"{ _FileName} - What To Do";
        }

        private void FileSave_Click(object sender, EventArgs e)
        {
            //if (_tasks.Save(_FileName) == false)
            if (_tasks.Save("TestTaskList.txt") == false)
            {
                // Save didn't succeed. 
            }
        }

        private void HelpAbout_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private void FileSaveAs_Click(object sender, EventArgs e)
        {
            // Get a new file name

        }

        private void FileExit_Click(object sender, EventArgs e)
        {
            if (!_tasks.Saved)
            {

            }
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
