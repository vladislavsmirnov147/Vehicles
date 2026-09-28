namespace Vehicles.Core
{
    public class Car : Vehicle, IDriveable
    {
        public Car(string name) : base(name)
        {
        }

        public string Drive(double distance)
        {
            return Move(distance);
        }

        public override string Move(double distance)
        {
            if (distance <= 0)
                return "Car: distance must be greater than 0.";

            string result = base.Move(distance);
            return $"Car {result}";
        }
    }
}