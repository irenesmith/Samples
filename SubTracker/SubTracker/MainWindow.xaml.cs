using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace SubTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int ProjectTabIndex = 0;
        const int PublisherTabIndex = 1;
        const int SubmissionTabIndex = 2;

        // Icon made by Freepik from www.flaticon.com
        // Icons made by <a href="https://www.flaticon.com/authors/freepik" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon"> www.flaticon.com</a>
        public MainWindow()
        {
            InitializeComponent();
            MainTabs.SelectedIndex = 0;
            UpdateButtons("Project");
        }

        private void cmdExit_Click(object sender, RoutedEventArgs e)
        {
            // Exit the application by closing the main window.
            Close();
        }

        private void tabProjects_GotFocus(object sender, RoutedEventArgs e) =>
            // Change the button text to match the current tab
            UpdateButtons("Project");

        private void tabPublishers_GotFocus(object sender, RoutedEventArgs e) =>
            // Change the button text to match the current tab
            UpdateButtons("Publisher");

        private void tabSubmissions_GotFocus(object sender, RoutedEventArgs e) =>
            // Change the button text to match the current tab
            UpdateButtons("Submission");

        private void UpdateButtons(string labelText)
        {
            // Change the button text to match the current tab
            cmdAdd.Content = $"Add {labelText}";
            cmdEdit.Content = $"Edit {labelText}";
            cmdDelete.Content = $"Delete {labelText}";
        }

        private void cmdAdd_Click(object sender, RoutedEventArgs e)
        {
            switch(MainTabs.SelectedIndex)
            {
                case ProjectTabIndex:
                    var addProject = new AddProject();
                    addProject.ShowDialog();
                    break;
                case PublisherTabIndex:
                    _ = MessageBox.Show("Adding Publisher");
                    break;
                case SubmissionTabIndex:
                    _ = MessageBox.Show("Adding Submission.");
                    break;
                default:
                    throw new NotSupportedException();
            };
        }

        private void cmdEdit_Click(object sender, RoutedEventArgs e)
        {
            _ = (MainTabs.SelectedIndex switch
            {
                ProjectTabIndex => MessageBox.Show("Editing selected Project."),
                PublisherTabIndex => MessageBox.Show("Editing selected Publisher"),
                SubmissionTabIndex => MessageBox.Show("Editing selected Submission."),
                _ => throw new NotSupportedException()
            });
        }

        private void cmdDelete_Click(object sender, RoutedEventArgs e)
        {
            _ = (MainTabs.SelectedIndex switch
            {
                ProjectTabIndex => MessageBox.Show("Deleting selected Project."),
                PublisherTabIndex => MessageBox.Show("Deleting selected Publisher"),
                SubmissionTabIndex => MessageBox.Show("Deleting selected Submission."),
                _ => throw new NotSupportedException()
            });
        }
    }
}
