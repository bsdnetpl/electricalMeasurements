using System.Globalization;

namespace electricalMeasurements.Service
    {
    public class LoopImpedanceService : ILoopImpedanceService
        {
        public object ValidateMeasurement(double impedance, double voltage = 230, int mcb = 16, string type = "B")
            {
            if (impedance <= 0)
                {
                return new
                    {
                    TypPomiaru = "Impedancja pętli zwarcia",
                    Impedancja = impedance.ToString(CultureInfo.InvariantCulture),
                    Status = "Niepoprawny",
                    Wiadomość = "Impedancja musi być większa niż 0 Ω."
                    };
                }

            // Obliczenie prądu zwarciowego (Ik = U / Z)
            double ik = Math.Round(voltage / impedance, 2);

            // Współczynnik w zależności od typu zabezpieczenia
            int multiplier = type switch
                {
                    "C" => 10,  // Typ C (10 × MCB)
                    "D" => 20,  // Typ D (20 × MCB)
                    _ => 5       // Domyślnie typ B (5 × MCB)
                    };

            // Minimalny wymagany prąd zwarciowy
            double minRequiredIk = multiplier * mcb;

            bool isValid = impedance <= 1.0 && ik >= minRequiredIk;

            return new
                {
                TypPomiaru = "Impedancja pętli zwarcia",
                Impedancja = impedance.ToString(CultureInfo.InvariantCulture),
                Napięcie = voltage.ToString(CultureInfo.InvariantCulture) + " V",
                PrądZwarciowy = ik.ToString(CultureInfo.InvariantCulture) + " A",
                MCB = mcb.ToString(CultureInfo.InvariantCulture) + " A",
                TypZabezpieczenia = type,
                MinimalnyPrądWymagany = minRequiredIk.ToString(CultureInfo.InvariantCulture) + " A",
                Status = isValid ? "Poprawny" : "Niepoprawny",
                Wiadomość = isValid
                    ? "Impedancja i prąd zwarciowy są prawidłowe."
                    : "Prąd zwarciowy jest zbyt niski, może nie wyzwolić zabezpieczenia!"
                };
            }
        }
    }
