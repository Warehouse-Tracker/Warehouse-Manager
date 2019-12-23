using WarehouseManager.Domain.Enums;

namespace WarehouseManager.Utilities
{
    public class MeasurementsMap
    {
        /// <summary>
        /// Generalize the amount of a certain measurement, depending on 1 kg. = 1 l in tones.
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="amount"></param>
        /// <returns>The amount in metric tons.</returns>
        public static double GetGeneralizedAmount(Measurement measurement, double amount)
        {
            double generalizedAmount = 0;
            switch (measurement)
            {
                case Measurement.Gram:
                    generalizedAmount = ConvertMeasurement.GrammToKilogram(amount);
                    break;
                case Measurement.Pound:
                    generalizedAmount = ConvertMeasurement.PoundToKilogram(amount);
                    break;
                case Measurement.Ounce:
                    generalizedAmount = ConvertMeasurement.OunceToKilogram(amount);
                    break;
                case Measurement.Oz:
                    generalizedAmount = ConvertMeasurement.OzToLitre(amount);
                    break;
                case Measurement.Gallon:
                    generalizedAmount = ConvertMeasurement.GallonToLitre(amount);
                    break;
                case Measurement.Kilogram:
                case Measurement.Litre:
                    generalizedAmount = ConvertMeasurement.KilogramToTone(amount);
                    break;
                case Measurement.Ton:
                case Measurement.CubicMeter:
                    generalizedAmount = amount;
                    break;
            }
            return generalizedAmount;
        }

    }
}
