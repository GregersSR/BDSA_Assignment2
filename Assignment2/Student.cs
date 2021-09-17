using System;

namespace Assignment2
{
    public enum Status {
            New,
            Active,
            Dropout,
            Graduated,
        }
    
    public class Student
    {
        int Id { get; init; }
        string GivenName, Surname;

        public Status Status { get; set; }

        DateTime StartDate, EndDate, GraduationDate;

        public Student(int id, string givenName, string surname, DateTime startDate, DateTime endDate, DateTime graduationDate) {
            Id = id;
            GivenName = givenName;
            Surname = surname;
            StartDate = startDate;
            EndDate = endDate;
            GraduationDate = graduationDate;
            if (startDate <= endDate && startDate < graduationDate && endDate <= graduationDate) {
                if (graduationDate <= DateTime.Now && endDate == graduationDate) {
                    Status = Status.Graduated;
                } else if (startDate <= DateTime.Now && endDate > DateTime.Now) {
                    Status = Status.Active;
                } else if (DateTime.Now < startDate) {
                    Status = Status.New;
                } else if (endDate < graduationDate && DateTime.Now > startDate) {
                    Status = Status.Dropout;
                } else {
                    throw new NotImplementedException("Coding error!");
                }
            } else {
                throw new ArgumentException("Some error");
            }
            
        }

        public override string ToString() {
            return "Name: "+ GivenName +" "+ Surname+ ", ID: " + Id + " Startdate: " + StartDate + ", Enddate: " + EndDate+ ", GraduationD date: " + GraduationDate;
        }
    }
}
