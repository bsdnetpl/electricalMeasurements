namespace electricalMeasurements.Service
    {
    public class RCDTestService : IRCDTestService
        {
        public object ValidateMeasurement(double tripTime)
            {
            bool isValid = tripTime <= 0.3;
            return new
                {
                MeasurementType = "RCD Test",
                TripTime = tripTime,
                Status = isValid ? "Pass" : "Fail",
                Message = isValid ? "RCD operates correctly." : "Trip time too high, possible faulty RCD."
                };
            }
        }
    }
