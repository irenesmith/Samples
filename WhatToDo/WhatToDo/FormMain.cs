using System;
using System.Windows.Forms;
using System.IO;
using What2DoDL;

namespace WhatToDo
{
    public partial class FormMain : Form
    {
        const string MSGBOX_MSG = "You have unsaved changes. Save before continuing?";
        const string MSGBOX_TITLE = "Save Changes";
        const string MSGBOX_SAVE_ERROR = "There was an error saving the file.";

        private readonly Tasks _tasks;
        private string _FileName;

        public FormMain()
        {
            InitializeComponent();

            // Get the file name from the Program Settings
            _FileName = Properties.Settings.Default.FileNameSetting;
            _tasks = new Tasks();

            // Load returns a count. Right now, we don't care.
            if (File.Exists(_FileName))
                _ = _tasks.Load(_FileName);

            BindList();
            SetTitle();
        }

        private void BindList()
        {
            // Bind _tasks.List<Tasks> to the DataGridView
            var bindingSource = new BindingSource
            {
                DataSource = _tasks.Items
            };
            dataViewTasks.DataSource = bindingSource;
        }

        private void SetTitle()
        {
            // Set the title to match the current _FileName
            Text = $"{_FileName} - What to Do";
        }

        private void SaveChanges()
        {
            {
                var result = MessageBox.Show(MSGBOX_MSG, MSGBOX_TITLE, MessageBoxButtons.YesNoCancel);
                switch (result)
                {
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
        }

        private void FileNew_Click(object sender, EventArgs e)
        {
            // If there are unsaved changes, ask whether the
            // user wants to save first.
            if(_tasks.Count > 0 && !_tasks.Saved)
            {
                SaveChanges();
            }

            // The user doesn't want to save clear the list.
            dataViewTasks.Rows.Clear();
            _FileName = "Untitled";
            SetTitle();
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

            dataViewTasks.Rows.Clear();
            _FileName = openFileDlg.FileName;
            _ = _tasks.Load(_FileName);

            BindList();
            SetTitle();
        }

        private void FileSave_Click(object sender, EventArgs e)
        {
            if (_tasks.Save(_FileName) == false)
            {
                // Save didn't succeed.
                MessageBox.Show(MSGBOX_SAVE_ERROR, MSGBOX_TITLE, MessageBoxButtons.OK);
            } else
            {
                _tasks.Saved = true;
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
            var result = saveFileDlg.ShowDialog();
            if(result == DialogResult.OK)
            {
                _FileName = saveFileDlg.FileName;
                var fileSaved =_tasks.Save(_FileName);
                if(fileSaved == false)
                {
                    MessageBox.Show(MSGBOX_SAVE_ERROR, MSGBOX_TITLE, MessageBoxButtons.OK);
                }
                _tasks.Saved = true;
            }
        }

        private void FileExit_Click(object sender, EventArgs e)
        {
            if (!_tasks.Saved)
            {
                SaveChanges();
            }

            // Save the current file name to Settings
            Properties.Settings.Default.FileNameSetting = _FileName;
            Application.Exit();
        }
        
        private void UserMadeChanges(object sender, DataGridViewCellEventArgs e)
        {
            // The DataGridView updates the List<Task> but we want
            // to mark it as needing saving
            _tasks.Saved = false;
        }

        private void UserChangedRows(object sender, DataGridViewRowEventArgs e)
        {
            // The DataGridView updates the List<Task> but we want
            // to mark it as needing saving.
            _tasks.Saved = false;
        }
    }
}
