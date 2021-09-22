using System;
using Xunit;
using Assignment2;

namespace Assignment2.Tests
{
    public class ImmutableStudentTests
    {
        [Fact]
        public void Student_StatusNewForAllAfterNow()
        {
            var student = new ImmutableStudent(
                1,
                "Gregers",
                "Rørdam",
                startDate: new DateTime(year: 2022, month: 8, day: 23),
                endDate: new DateTime(year: 2023, month: 6, day: 27),
                graduationDate: new DateTime(year: 2023, month: 6, day: 27)
            );
            Assert.Equal(Assignment2.Status.New, student.Status);
        }

        [Fact]
        public void Student_StatusActiveForStartBeforeNowAndOthersAfter()
        {
            var student = new ImmutableStudent(
                1,
                "Gregers",
                "Rørdam",
                startDate: new DateTime(year: 2020, month: 8, day: 23),
                endDate: new DateTime(year: 2023, month: 6, day: 27),
                graduationDate: new DateTime(year: 2023, month: 6, day: 27)
            );
            Assert.Equal(Assignment2.Status.Active, student.Status);
        }

        [Fact]
        public void Student_StatusGraduatedForAllBeforeNowAndEndOnGraduation()
        {
            var student = new ImmutableStudent(
                1,
                "Gregers",
                "Rørdam",
                startDate: new DateTime(year: 2018, month: 8, day: 23),
                endDate: new DateTime(year: 2021, month: 6, day: 27),
                graduationDate: new DateTime(year: 2021, month: 6, day: 27)
            );
            Assert.Equal(Assignment2.Status.Graduated, student.Status);
        }

        [Fact]
        public void Student_StatusDropoutForStartAndEndBeforeNowAndGraduationAfter()
        {
            var student = new ImmutableStudent(
                1,
                "Gregers",
                "Rørdam",
                startDate: new DateTime(year: 2020, month: 8, day: 23),
                endDate: new DateTime(year: 2021, month: 6, day: 27),
                graduationDate: new DateTime(year: 2023, month: 6, day: 27)
            );
            Assert.Equal(Assignment2.Status.Dropout, student.Status);
        }

        [Fact]
        public void Student_StatusDropoutForAllBeforeNow()
        {
            var student = new ImmutableStudent(
                1,
                "Gregers",
                "Rørdam",
                startDate: new DateTime(year: 2010, month: 8, day: 23),
                endDate: new DateTime(year: 2012, month: 6, day: 27),
                graduationDate: new DateTime(year: 2013, month: 6, day: 27)
            );
            Assert.Equal(Assignment2.Status.Dropout, student.Status);
        }

        [Fact]
        public void Student_ArgumentErrorIfStartAfterEnd()
        {
            Assert.Throws<ArgumentException>(() => {
                new ImmutableStudent(
                    1,
                    "Gregers",
                    "Rørdam",
                    startDate: new DateTime(year: 2021, month: 8, day: 23),
                    endDate: new DateTime(year: 2012, month: 6, day: 27),
                    graduationDate: new DateTime(year: 2013, month: 6, day: 27)
                );
            });
        }
    }
}
