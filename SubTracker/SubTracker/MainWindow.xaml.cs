using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
            // Determine what to add
            switch (MainTabs.SelectedIndex)
            {
                case ProjectTabIndex:
                    _ = MessageBox.Show("Adding new Project.");
                    break;
                case PublisherTabIndex:
                    _ = MessageBox.Show("Adding new Publisher.");
                    break;
                case SubmissionTabIndex:
                    _ = MessageBox.Show("Adding new Submission.");
                    break;
                default:
                    // Error invalid choice.
                    return;
            }
        }

        private void cmdEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (MainTabs.SelectedIndex)
            {
                case ProjectTabIndex:
                    _ = MessageBox.Show("Editing selected Project.");
                    break;
                case PublisherTabIndex:
                    _ = MessageBox.Show("Editing selected Publisher.");
                    break;
                case SubmissionTabIndex:
                    _ = MessageBox.Show("Editing selected Submission.");
                    break;
                default:
                    // Error invalid choice.
                    return;
            }
        }

        private void cmdDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (MainTabs.SelectedIndex)
            {
                case ProjectTabIndex:
                    _ = MessageBox.Show("Deleting selected Project.");
                    break;
                case PublisherTabIndex:
                    _ = MessageBox.Show("Deleting selected Publisher.");
                    break;
                case SubmissionTabIndex:
                    _ = MessageBox.Show("Deleting selected Submission.");
                    break;
                default:
                    // Error invalid choice.
                    return;
            }
        }
    }
}
