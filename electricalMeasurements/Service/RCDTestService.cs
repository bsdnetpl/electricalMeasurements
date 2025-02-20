using System.Globalization;

namespace electricalMeasurements.Service
    {
    public class RCDTestService : IRCDTestService
        {
        public object ValidateMeasurement(double tripTime)
            {
            bool isValid = tripTime <= 0.3;
            return new
                {
                TypPomiaru = "Test RCD",
                CzasWyzwolenia = tripTime.ToString(CultureInfo.InvariantCulture) + " s",
                Status = isValid ? "Poprawny" : "Niepoprawny",
                Wiadomość = isValid ? "RCD działa prawidłowo." : "Czas wyzwolenia zbyt długi, możliwe uszkodzenie!"
                };
            }
        }
    }
