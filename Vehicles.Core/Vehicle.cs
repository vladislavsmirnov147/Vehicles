namespace Vehicles.Core
{
    public abstract class Vehicle
    {
        public string Name { get; set; }
        public double Mileage { get; protected set; }

        protected Vehicle(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            Name = name;
            Mileage = 0;
        }

        public virtual string Move(double distance)
        {
            if (distance <= 0)
                return "Distance must be greater than 0.";

            Mileage += distance;

            return $"{Name} moved {distance} km. Total mileage: {Mileage} km.";
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name}, mileage: {Mileage} km";
        }
    }
}