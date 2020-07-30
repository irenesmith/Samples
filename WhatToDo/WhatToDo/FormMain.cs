using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            if(String.IsNullOrEmpty(_FileName))
            {
                openFileDlg.ShowDialog();
                _FileName = openFileDlg.FileName;
                _tasks = new Tasks(_FileName);
                txtFileName.Text = _FileName;
            }
        }
    }
}
