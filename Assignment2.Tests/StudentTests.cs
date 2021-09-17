using System;
using Xunit;
using Assignment2;

namespace Assignment2.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CorrectStatus()
        {
            var student = new Student(
                1,
                "Gregers",
                "Rørdam",
                startDate: new DateTime(year: 2020, month: 8, day: 23),
                endDate: new DateTime(year: 2023, month: 6, day: 27),
                graduationDate: new DateTime(year: 2023, month: 6, day: 27)
            );
            Assert.Equal(Assignment2.Status.Active, student.Status);
        }
    }
}
