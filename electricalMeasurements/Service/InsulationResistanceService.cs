using System.Globalization;

namespace electricalMeasurements.Service
    {
    public class InsulationResistanceService : IInsulationResistanceService
        {
        public object ValidateMeasurement(double resistance)
            {
            bool isValid = resistance >= 1.0;
            return new
                {
                TypPomiaru = "Rezystancja izolacji",
                Rezystancja = resistance.ToString(CultureInfo.InvariantCulture),
                Status = isValid ? "Poprawny" : "Niepoprawny",
                Wiadomość = isValid ? "Rezystancja izolacji spełnia normy." : "Rezystancja zbyt niska, ryzyko przebicia!"
                };
            }
        }
    }
