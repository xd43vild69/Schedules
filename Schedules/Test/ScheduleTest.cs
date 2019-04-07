using BAL;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ScheduleTest
    {
        public Patient Patient { get; set; }
        public Schedule Schedule { get; set; }

        [TestMethod]
        public void isValidaCreateDatbook()
        {
            // arrange
            bool isValidCreation = false;
            Schedule schedule = new Schedule() { Id = 4, Datebook = System.DateTime.Now, Description = "Desc1", IdPatient = 1 };
            ScheduleBAL scheduleBal = new ScheduleBAL();

            // act
            //isValidCreation = scheduleBal.IsPatientWithDatesSameDay(schedule.IdPatient, schedule.Datebook);
            // Assert
            Assert.IsTrue(isValidCreation);
        }

        [TestMethod]
        public void isValidaCancelDatabook()
        {
            // arrange
            bool isValidCancelation = false;
            DateTime dateTime1 = new DateTime(2019, 4, 7, 13, 0, 0);
            Schedule schedule = new Schedule() { Id = 4, Datebook = System.DateTime.Now, Description = "Desc1", IdPatient = 1 };
            ScheduleBAL scheduleBal = new ScheduleBAL();

            // act
            //isValidCancelation = scheduleBal.IsDateValidToCancel(schedule.IdPatient);
            // Assert
            Assert.IsTrue(isValidCancelation);
        }

        [TestMethod]
        public void InsertTest()
        {

            Schedule schedule = new Schedule() { Id = 4, Datebook = System.DateTime.Now, Description = "Desc1", IdPatient = 1 };
            ScheduleBAL scheduleBal = new ScheduleBAL();
            //scheduleBal.Insert(schedule);
        }

        public void ConfigTest()
        {
            //Patient = new DTO.Patient { Id = 1, Name = "Patient1" };
            //Schedule = new DTO.Dates { Id = 1, Description = "Desc1", Datebook = System.DateTime.Now.AddDays(-1) };
        }

    }
}
