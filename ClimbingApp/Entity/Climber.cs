namespace ClimbingApp.Entity
{
    public class Climber : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString() => $"Id: {Id} Name: {FirstName} {LastName}";

    }
}
