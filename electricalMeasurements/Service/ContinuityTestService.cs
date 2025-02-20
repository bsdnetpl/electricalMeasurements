using System.Globalization;

namespace electricalMeasurements.Service
    {
    public class ContinuityTestService : IContinuityTestService
        {
        public object ValidateMeasurement(double resistance)
            {
            bool isValid = resistance <= 0.1;
            return new
                {
                TypPomiaru = "Test ciągłości przewodów ochronnych",
                Rezystancja = resistance.ToString(CultureInfo.InvariantCulture),
                Status = isValid ? "Poprawny" : "Niepoprawny",
                Wiadomość = isValid ? "Rezystancja w dopuszczalnym zakresie." : "Rezystancja za wysoka, sprawdź połączenia."
                };
            }
        }
    }
