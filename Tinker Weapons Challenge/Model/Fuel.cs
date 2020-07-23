
namespace Tinker_Weapons_Challenge.Model
{
    public class Fuel
    {

        public decimal fuel_calc(decimal distance, decimal range, int maxFuel)
        {
            //double distance;
            decimal fuelNeeded;
            //Console.Write("Enter ditance to target:");
            //distance = double.Parse(Console.ReadLine());
            fuelNeeded = distance / range;
            fuelNeeded = fuelNeeded * maxFuel;
            if (fuelNeeded < 100000)
            {
                fuelNeeded = 100000;
            }
            return fuelNeeded;
        }
    }
}
