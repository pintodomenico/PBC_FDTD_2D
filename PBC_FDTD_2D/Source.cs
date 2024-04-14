using static System.Math;

namespace PBC_FDTD_2D;

public class Source
{
    //let's consider only gaussian bell for the moment
    private double timeDelay;
    private double timeWidth;
    private double centralFrequency;
    private double deltaT;
    private int timeSteps;

    //no space variation at the moment
    //public double[,] SpaceVariation { get; private set; }
    public double[] TimeVariation { get; private set; }

    public Source(double timeDelay, double timeWidth, double centralFrequency, double deltaT, int timeSteps)
    {
        this.timeDelay = timeDelay;
        this.timeWidth = timeWidth;
        this.centralFrequency = centralFrequency;
        this.deltaT = deltaT;
        this.timeSteps = timeSteps;

        CreateSource();
    }

    private void CreateSource()
    {
        TimeVariation = new double[timeSteps];
        for (int t = 0; t < timeSteps; t++)
        {
            double time = t * deltaT;
            double sinTerm = Sin(2.0 * PI * centralFrequency * time);
            double expTerm = Exp(-Pow((time - timeDelay) / timeWidth, 2.0));
            TimeVariation[t] = sinTerm * expTerm;
        }
    }
}
