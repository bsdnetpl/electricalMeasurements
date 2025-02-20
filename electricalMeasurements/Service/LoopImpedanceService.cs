namespace electricalMeasurements.Service
    {
    public class LoopImpedanceService : ILoopImpedanceService
        {
        public object ValidateMeasurement(double impedance, double voltage = 230, int mcb = 16)
            {
            if (impedance <= 0)
                {
                return new
                    {
                    TypPomiaru = "Impedancja pętli zwarcia",
                    Impedancja = impedance,
                    Status = "Niepoprawny",
                    Wiadomość = "Impedancja musi być większa niż 0 Ω."
                    };
                }

            // Obliczenie prądu zwarciowego (Ik = U / Z)
            double ik = Math.Round(voltage / impedance, 2);

            // Wyznaczenie minimalnego wymaganego prądu zwarciowego (5x In dla B, 10x In dla C)
            double minRequiredIk = 5 * mcb; // Dla zabezpieczeń typu B

            bool isValid = impedance <= 1.0 && ik >= minRequiredIk;

            return new
                {
                TypPomiaru = "Impedancja pętli zwarcia",
                Impedancja = impedance,
                Napięcie = voltage + " V",
                PrądZwarciowy = ik + " A",
                MCB = mcb + " A",
                MinimalnyPrądWymagany = minRequiredIk + " A",
                Status = isValid ? "Poprawny" : "Niepoprawny",
                Wiadomość = isValid
                    ? "Impedancja i prąd zwarciowy są prawidłowe."
                    : "Prąd zwarciowy jest zbyt niski, może nie wyzwolić zabezpieczenia!"
                };
            }
        }
    }
