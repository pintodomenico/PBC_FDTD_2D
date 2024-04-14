using PBC_FDTD_2D.Utilities;

namespace PBC_FDTD_2D;
public class Detector
{
    public double[] timeVariation;
    public double X { get; }
    public double Y { get; }
    public int Index1 { get; }
    public int Index2 { get; }

    #region Constructors
    public Detector(int numberOfSamples, double xPosition, double yPosition, double deltaX, double deltaY)
    {
        timeVariation = new double[numberOfSamples];
        X = xPosition;
        Y = yPosition;
        Index1 = Discretisation.CalculateDiscreteQuantity(xPosition, deltaX);
        Index2 = Discretisation.CalculateDiscreteQuantity(yPosition, deltaY);
    }

    public Detector(int numberOfSamples, int index1, int index2)
    {
        timeVariation = new double[numberOfSamples];
        Index1 = index1;
        Index2 = index2;
    }
    #endregion
}
