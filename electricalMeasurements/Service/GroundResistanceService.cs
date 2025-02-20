using System.Globalization;

namespace electricalMeasurements.Service
    {
    public class GroundResistanceService : IGroundResistanceService
        {
        public object ValidateMeasurement(double resistance)
            {
            bool isValid = resistance <= 10.0;
            return new
                {
                TypPomiaru = "Rezystancja uziemienia",
                Rezystancja = resistance.ToString(CultureInfo.InvariantCulture),
                Status = isValid ? "Poprawny" : "Niepoprawny",
                Wiadomość = isValid ? "Rezystancja uziemienia w normie." : "Rezystancja zbyt wysoka, sprawdź uziemienie!"
                };
            }
        }
    }
