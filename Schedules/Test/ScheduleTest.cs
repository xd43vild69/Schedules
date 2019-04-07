using System;
using Moq;
using BAL;
using DTO;
using SAL.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using API;

namespace Test
{
    [TestClass]
    public class ScheduleTest
    {
        public Patient Patient { get; set; }
        public Schedule Schedule { get; set; }

        public ScheduleTest()
        {
            ConfigTest();
        }

        [TestMethod]
        public void isNOTaValidaCancelDatabook()
        {
            // arrange

            bool isValidCancelation = false;

            DateTime dateTime1 = new DateTime(2019, 4, 7, 13, 0, 0);
            Schedule schedule = new Schedule() { Id = 4, Datebook = dateTime1, Description = "Desc1", IdPatient = 1 };
            ScheduleBAL scheduleBal = new ScheduleBAL();

            var moqSet = new Mock<IValidations<Schedule>>();

            var validations = new ScheduleBAL(moqSet.Object);
            moqSet.Setup(x => x.GetScheduleToCancel(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(schedule);

            // act
            isValidCancelation = validations.IsValidToCancel(schedule.Id, schedule.Datebook);

            // Assert
            Assert.IsFalse(isValidCancelation);
        }

        [TestMethod]
        public void isValidaCancelDatabook()
        {
            // arrange

            bool isValidCancelation = false;

            DateTime dateTime1 = new DateTime(2019, 4, 10, 13, 0, 0);
            Schedule schedule = new Schedule() { Id = 4, Datebook = dateTime1, Description = "Desc1", IdPatient = 1 };
            ScheduleBAL scheduleBal = new ScheduleBAL();

            var moqSet = new Mock<IValidations<Schedule>>();

            var validations = new ScheduleBAL(moqSet.Object);
            moqSet.Setup(x => x.GetScheduleToCancel(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(schedule);

            // act
            isValidCancelation = validations.IsValidToCancel(schedule.Id, schedule.Datebook);

            // Assert
            Assert.IsTrue(isValidCancelation);
        }

        [TestMethod]
        public void IsNOTaValidedCreateSchedule()
        {
            // arrange

            bool isValidCancelation = false;

            DateTime dateTime1 = new DateTime(2019, 4, 7, 13, 0, 0);
            Schedule schedule = new Schedule() { Id = 4, Datebook = System.DateTime.Now, Description = "Desc1", IdPatient = 1 };
            ScheduleBAL scheduleBal = new ScheduleBAL();

            var moqSet = new Mock<IValidations<Schedule>>();

            var validations = new ScheduleBAL(moqSet.Object);
            moqSet.Setup(x => x.GetSchedulesSameDay(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(schedule);

            // act
            isValidCancelation = validations.IsValidedCreateSchedule(schedule.IdPatient, schedule.Datebook);

            // Assert
            Assert.IsFalse(isValidCancelation);
        }

        [TestMethod]
        public void IsValidedCreateSchedule()
        {
            // arrange

            bool isValidCancelation = false;

            DateTime dateTime1 = new DateTime(2019, 4, 7, 13, 0, 0);
            Schedule schedule = new Schedule() { Id = 4, Datebook = System.DateTime.Now.AddDays(1), Description = "Desc1", IdPatient = 1 };
            ScheduleBAL scheduleBal = new ScheduleBAL();

            var moqSet = new Mock<IValidations<Schedule>>();

            var validations = new ScheduleBAL(moqSet.Object);
            moqSet.Setup(x => x.GetSchedulesSameDay(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(schedule);

            // act
            isValidCancelation = validations.IsValidedCreateSchedule(schedule.IdPatient, schedule.Datebook);

            // Assert
            Assert.IsFalse(isValidCancelation);
        }

        public void ConfigTest()
        {
            ConfigIOC.ConfigureIOC();
        }

    }
}
