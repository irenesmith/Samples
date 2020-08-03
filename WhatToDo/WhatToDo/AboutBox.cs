using System;
using System.Reflection;
using System.Windows.Forms;

namespace WhatToDo
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
