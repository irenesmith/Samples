using What2DoDL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace What2DoDL.Tests
{
    [TestClass()]
    public class TasksTests
    {
        [TestMethod()]
        public void TaskTestListLoadedFromTestFileShouldHave10Tasks()
        {
            // I created a test file with ten tasks called "TestTaskList.txt"
            // Loading this file should obviously have a count of 10.
            var tasks = new Tasks();
            var taskCount = tasks.Load("TestTasksList.txt");
            Assert.AreEqual(10, taskCount);
        }

        [TestMethod()]
        public void TaskTestListLoadedFromTestFileSavedShouldBeTrue()
        {
            // I created a test file with ten tasks called "TestTaskList.txt"
            // Loading this file should obviously have a count of 10.
            var tasks = new Tasks();
            _ = tasks.Load("TestTasksList.txt");
            Assert.IsTrue(tasks.Saved);
        }

        [TestMethod()]
        public void TasksSavedPropertyShouldBeFalseAfterAdd()
        {
            // Set up values to use in the test
            var id = "b699e74d-3053-4ae2-828f-53a724b707cc";
            var name = "Test Task";
            var dateCreated = "7/29/2020 11:29:03 PM";
            var isDone = false;

            // Create a new Task object
            var task = new Task(id, name, dateCreated, isDone);

            // Create a new Tasks object
            var taskList = new Tasks();
            taskList.Add(task);
            Assert.IsFalse(taskList.Saved);
        }

    }
}
