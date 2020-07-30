using What2DoDL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace What2DoDL.Tests
{
    [TestClass()]
    public class TaskTests
    {
        [TestMethod()]
        public void TaskConstructorNameOnlyHasDefaults()
        {
            var name = "Test Task";
            var t = new Task(name);
            Assert.AreEqual(name, t.Name);
        }

        [TestMethod()]
        public void TaskConstructorAllValuesHasProperValues()
        {
            // Messages for bad Guid or Date
            const string BAD_GUID = "The id must be a valid Guid";
            const string BAD_DATE = "The DateCreated must be a valid DateTime";

            // Set up values to use in the test
            var id = "b699e74d-3053-4ae2-828f-53a724b707cc";
            var name = "Test Task";
            var dateCreated = Convert.ToDateTime("7/29/2020 11:29:03 PM");
            var status = TaskStatus.InProgress;

            // Perform the test
            var t = new Task(id, name, dateCreated, status);

            // Check the results
            Assert.IsInstanceOfType(t.Id, typeof(Guid), BAD_GUID);
            Assert.AreEqual(name, t.Name);
            Assert.IsInstanceOfType(t.DateCreated, typeof(DateTime), BAD_DATE);
            Assert.AreEqual(status, t.Status);
        }

    }
}