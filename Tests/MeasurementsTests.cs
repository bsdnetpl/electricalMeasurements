using electricalMeasurements.Service;

namespace Tests
    {
    public class MeasurementsTests
        {
        [Fact]
        public void ValidateContinuityMeasurement_ShouldReturnCorrectFormat()
            {
            // Arrange
            var service = new ContinuityTestService();
            double resistance = 0.05;

            // Act
            var result = service.ValidateMeasurement(resistance);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Poprawny", result.GetType().GetProperty("Status")?.GetValue(result));
            Assert.Equal("0.05", result.GetType().GetProperty("Rezystancja")?.GetValue(result)?.ToString());
            }

        [Fact]
        public void ValidateInsulationResistance_ShouldReturnFailForLowResistance()
            {
            // Arrange
            var service = new InsulationResistanceService();
            double resistance = 0.5;

            // Act
            var result = service.ValidateMeasurement(resistance);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Niepoprawny", result.GetType().GetProperty("Status")?.GetValue(result));
            }

        [Theory]
        [InlineData(0.5, 230, 16, "B", "Poprawny")]
        [InlineData(3.0, 230, 16, "B", "Niepoprawny")]
        [InlineData(0.2, 230, 16, "C", "Poprawny")]
        [InlineData(5.0, 230, 20, "D", "Niepoprawny")]
        public void ValidateLoopImpedance_ShouldCheckZwarciowyPrad(double impedance, double voltage, int mcb, string type, string expectedStatus)
            {
            // Arrange
            var service = new LoopImpedanceService();

            // Act
            var result = service.ValidateMeasurement(impedance, voltage, mcb, type);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedStatus, result.GetType().GetProperty("Status")?.GetValue(result));
            }

        [Fact]
        public void ValidateRCDTest_ShouldReturnPassForLowTripTime()
            {
            // Arrange
            var service = new RCDTestService();
            double tripTime = 0.25;

            // Act
            var result = service.ValidateMeasurement(tripTime);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Poprawny", result.GetType().GetProperty("Status")?.GetValue(result));
            }

        [Fact]
        public void ValidateGroundResistance_ShouldReturnFailForHighResistance()
            {
            // Arrange
            var service = new GroundResistanceService();
            double resistance = 15.0;

            // Act
            var result = service.ValidateMeasurement(resistance);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Niepoprawny", result.GetType().GetProperty("Status")?.GetValue(result));
            }
        }
    }
    
