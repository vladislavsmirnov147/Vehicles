namespace Vehicles.Core
{
    public class AmphibiousCar : Vehicle, IDriveable, ISailable
    {
        public AmphibiousCar(string name) : base(name)
        {
        }

        public string Drive(double distance)
        {
            return Move(distance);
        }

        public string Sail(double distance)
        {
            return Move(distance);
        }

        public override string Move(double distance)
        {
            if (distance <= 0)
                return "AmphibiousCar: distance must be greater than 0.";

            string result = base.Move(distance);
            return $"AmphibiousCar {result}";
        }
    }
}