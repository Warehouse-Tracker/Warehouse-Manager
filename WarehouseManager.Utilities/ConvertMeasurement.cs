namespace WarehouseManager.Utilities
{
    public static class ConvertMeasurement
    {
        public static double GrammToKilogram(double grams)
        {
            return grams / 1000;
        }

        public static double PoundToKilogram(double pounds)
        {
            return pounds / 2.2046226218;
        }

        public static double OunceToKilogram(double ounces)
        {
            return ounces / 35.2739619;
        }

        public static double OzToLitre(double fluidOunces)
        {
            return fluidOunces / 33.8140227;
        }

        public static double GallonToLitre(double gallons)
        {
            return gallons / 3.78541178;
        }

        public static double KilogramToTone(double kilos)
        {
            return kilos / 1000;
        }
    }
}
