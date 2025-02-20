namespace electricalMeasurements.Service
    {
    public interface IContinuityTestService
        {
        object ValidateMeasurement(double resistance);
        }
    }