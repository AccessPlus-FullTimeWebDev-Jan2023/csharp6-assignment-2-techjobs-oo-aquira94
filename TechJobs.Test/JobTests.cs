
using System.Diagnostics.Metrics;

namespace TechJobs.Tests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job job = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            Assert.AreEqual("Product tester", job.Name);
            Assert.AreEqual("ACME", job.EmployerName.Value);
            Assert.AreEqual("Desert", job.EmployerLocation.Value);
            Assert.AreEqual("Quality control", job.JobType.Value);
            Assert.AreEqual("Persistence", job.JobCoreCompetency.Value);
            Assert.IsTrue(job.Id > 0);
        }
        [TestMethod]
        public void TestJobsForEquality()
        {
            Job job1 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Job job2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Job job3 = new Job("Web Developer", new Employer("ACME"), new Location("Desert"), new PositionType("Software"), new CoreCompetency("Coding"));

            Assert.IsFalse(job1.Equals(job2));
            Assert.IsFalse(job1.Equals(job3));
            Assert.IsFalse(job2.Equals(job3));
        }





        Job job1 = new Job();

        Job job2 = new Job();

        Job job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

        Job job4 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

        [TestMethod]
        public void TestSettingJobId()
        {
            Job job1 = new Job();
            Job job2 = new Job();

            Assert.IsFalse(job1.Id == job2.Id);
            Assert.IsTrue(job2.Id - job1.Id == 1);

        }
        [TestMethod]
        public void TestToStringStartsAndEndsWithNewLine()
        {
            Assert.IsTrue(job3.ToString().StartsWith(Environment.NewLine));
            Assert.IsTrue(job3.ToString().EndsWith(Environment.NewLine));
        }
        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
            Assert.IsTrue(job3.ToString() == Environment.NewLine + "ID: " + job3.Id + Environment.NewLine + "Name: " + job3.Name + Environment.NewLine + "Employer: " + job3.EmployerName.Value + Environment.NewLine + "Location: " + job3.EmployerLocation.Value + Environment.NewLine + "Position Type: " + job3.JobType.Value + Environment.NewLine + "Core Competency: " + job3.JobCoreCompetency.Value + Environment.NewLine);
        }
        [TestMethod]
        public void TestToStringHandlesEmptyField()
        {
            job3.JobCoreCompetency.Value = "";
            job3.EmployerLocation.Value = "";
            Assert.IsTrue(job3.ToString() == Environment.NewLine + "ID: " + job3.Id + Environment.NewLine + "Name: " + job3.Name + Environment.NewLine + "Employer: " + job3.EmployerName.Value + Environment.NewLine + "Location: " + "Data not available" + Environment.NewLine + "Position Type: " + job3.JobType.Value + Environment.NewLine + "Core Competency: " + "Data not available" + Environment.NewLine);
        }
    }
}

