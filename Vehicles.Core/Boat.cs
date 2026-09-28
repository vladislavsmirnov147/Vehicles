namespace Vehicles.Core
{
    public class Boat : Vehicle, ISailable
    {
        public Boat(string name) : base(name)
        {
        }

        public string Sail(double distance)
        {
            return Move(distance);
        }

        public override string Move(double distance)
        {
            if (distance <= 0)
                return "Boat: distance must be greater than 0.";

            string result = base.Move(distance);
            return $"Boat {result}";
        }
    }
}