using System.Collections.Generic;

using static System.Console;

using static PBC_FDTD_2D.Utilities.PhysicalConstants;
using static PBC_FDTD_2D.Utilities.SaveFile;
using static PBC_FDTD_2D.Utilities.Discretisation;
using static PBC_FDTD_2D.Utilities.MagnitudeOrders;

namespace PBC_FDTD_2D
{
    class Program
    {
        static void Main(string[] args)
        {
            var unitCellDetails = new UnitCellDetails(
                xPeriod: 0.58652*u,
                yPeriod: 0.58652*u,
                deltaX: 0.58652*u / 40.0,
                deltaY: 0.58652*u / 40.0,
                dielectricBackground: Eps0,
                rodholeDielectric: 3.4 * 3.4 * Eps0,
                rodHoleRadius: 0.2 * 0.58652*u);

            //calculating the time step using Corant Limit formula
            var deltaT = 0.9 * CalculateTimeStepUsingCourantLimit(unitCellDetails.DeltaX, unitCellDetails.DeltaY);


            var structure = new Structure(unitCellDetails);
            string filename = @"D:\data\structureCss.dat";
            WriteLine("Saving the structure in " + filename);
            Save(structure.Permittivity, structure.xCells, structure.yCells, filename);

            double timeWidth = 15*f;
            double timeDelay = 3.0*timeWidth;
            double centralFrequency = C0 / 1.5*u;
            int timeSteps = 200000;
            var source = new Source(timeDelay, timeWidth, centralFrequency, deltaT, timeSteps);
            filename = @"D:\data\sourceCss.dat";
            WriteLine("Saving the source in " + filename);
            Save(source.TimeVariation, filename);

            var EField = new ComplexField(structure.xCells, structure.yCells);
            var HField = new ComplexField(structure.xCells, structure.yCells);
            var fdtdPropagator = new FDTDPropagator(EField, HField, structure);
            var detector1 = new Detector(timeSteps, 20, 20);
            var detector2 = new Detector(timeSteps, unitCellDetails.XPeriod / 3.0, unitCellDetails.YPeriod * 0.8, unitCellDetails.DeltaX, unitCellDetails.DeltaY);
            var detectors = new List<Detector> { detector1, detector2 };
            WriteLine();
            fdtdPropagator.Propagate(timeSteps, deltaT, source, detectors);
            WriteLine();

            WriteLine("Saving the detectors");
            for (int index = 0; index < detectors.Count; index++)
            {
                filename = @"D:\data\detector" + (index + 1) + ".dat";
                WriteLine("Detector" + (index + 1) + " in " + filename);
                Save(detectors[index].timeVariation, filename);
            }

            WriteLine("Press Enter to terminate");
            ReadLine();
        }
    }

    public struct UnitCellDetails
    {
        public double XPeriod;
        public double YPeriod;
        public double DeltaX;
        public double DeltaY;
        public double DielectricBackground;
        public double RodHoleDielectric;
        public double RodHoleRadius;

        public UnitCellDetails(
            double xPeriod, 
            double yPeriod, 
            double deltaX,
            double deltaY,
            double dielectricBackground,
            double rodholeDielectric,
            double rodHoleRadius)
        {
            XPeriod = xPeriod;
            YPeriod = yPeriod;
            DeltaX = deltaX;
            DeltaY = deltaY;
            DielectricBackground = dielectricBackground;
            RodHoleDielectric = rodholeDielectric;
            RodHoleRadius = rodHoleRadius;
        }
    }
}
