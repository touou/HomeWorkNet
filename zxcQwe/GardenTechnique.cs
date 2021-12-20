namespace zxcQwe
{
    public class GardenTechnique : Technics
    {
        public Season _Season { get; set; }
        public bool IsRightSeasonNow { get; set; }

        public GardenTechnique(string manufacturer, int power, EnergyСonsumption energy,
            string name, Season season, bool isRightSeasonNow) : base(manufacturer, power, energy, name)
        {
            _Season = season;
            IsRightSeasonNow = isRightSeasonNow;
        }

        public new object Clone()
        {
            return  this.MemberwiseClone();
        }
        
    }

    public enum Season
    {
        Winter,
        Summer,
        Autumn,
        Spring,
    }
}