namespace zxcQwe
{
    public abstract class Technics : ICloneable
    {
        public string Manufacturer { get; set; }
        public int Power { get; set; }
        public EnergyСonsumption Energy { get; set; }
        public string Name { get; set; }
        

        public Technics(string manufacturer, int power, EnergyСonsumption energy, string name)
        {
            Manufacturer = manufacturer;
            Power = power;
            Energy = energy;
            Name = name;
        }

        public object Clone()
        {
            return this.MemberwiseClone();   
        }
    }

    public enum EnergyСonsumption
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G
    }
}