namespace electricalMeasurements.Service
    {
    public class ContinuityTestService : IContinuityTestService
        {
        public object ValidateMeasurement(double resistance)
            {
            bool isValid = resistance <= 0.1;
            return new
                {
                MeasurementType = "Continuity Test",
                Resistance = resistance,
                Status = isValid ? "Pass" : "Fail",
                Message = isValid ? "Measurement is within acceptable range." : "Resistance too high, check connections."
                };
            }
        }
    }
