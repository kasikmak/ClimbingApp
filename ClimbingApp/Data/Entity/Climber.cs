namespace ClimbingApp.Data.Entity;

public class Climber : EntityBase
{

    //public Climber(string firstName, string lastName)
    //{
    //    this.FirstName = firstName;
    //    this.LastName = lastName;
    //}

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Nationality { get; set; }

    public override string ToString() => $"Id: {Id} Name: {FirstName} {LastName}";

}
