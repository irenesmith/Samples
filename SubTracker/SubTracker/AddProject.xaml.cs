using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SubTracker
{
    /// <summary>
    /// Interaction logic for AddProject.xaml
    /// </summary>
    public partial class AddProject : Window
    {
        List<string> stringList = new List<string>();

        public AddProject()
        {
            InitializeComponent();
            stringList.Add("Warren");
            stringList.Add("Matt");
            stringList.Add("Irene");

            itemList.ItemsSource = stringList;
        }
    }
}
