using System;

namespace Assignment2
{
    
    public record ImmutableStudent
    {
        int Id { get; init; }
        public string GivenName { get; init; }
        public string Surname { get; init; }

        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public DateTime GraduationDate { get; init; }

        public Status Status { get => calculateStatus(); }
        public ImmutableStudent(int id, string givenName, string surname, DateTime startDate, DateTime endDate, DateTime graduationDate) {
            if  (!(startDate <= endDate && startDate < graduationDate && endDate <= graduationDate)) {
                throw new ArgumentException("StartDate must be before or on the EndDate, which must in turn be before or on GraduationDate. StartDate must be before GraduationDate, however");
            }
            Id = id;
            GivenName = givenName;
            Surname = surname;
            StartDate = startDate;
            EndDate = endDate;
            GraduationDate = graduationDate;
        }

        Status calculateStatus() {
            if (GraduationDate <= DateTime.Now && EndDate == GraduationDate) {
                return Status.Graduated;
            } else if (StartDate <= DateTime.Now && EndDate > DateTime.Now) {
                return Status.Active;
            } else if (DateTime.Now < StartDate) {
                return Status.New;
            } else if (EndDate < GraduationDate && DateTime.Now > StartDate) {
                return Status.Dropout;
            } else {
                throw new NotImplementedException("Logic error!");
            }
        }

        public override string ToString() {
            return "Name: "+ GivenName +" "+ Surname+ ", ID: " + Id + " Startdate: " + StartDate + ", Enddate: " + EndDate+ ", GraduationD date: " + GraduationDate;
        }
    }
}
