namespace electricalMeasurements.Service
    {
    public interface ILoopImpedanceService
        {
        object ValidateMeasurement(double impedance, double voltage = 230, int mcb = 16);
        }
    }