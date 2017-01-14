using PBC_FDTD_2D.Utilities;

namespace PBC_FDTD_2D
{
    public class Structure
    {
        public double[,] Permittivity { get; private set; }
        public double[,] Permeability { get; private set; }
        public double[,] ElecCond { get; private set; }
        public double[,] MagnCond { get; private set; }
        public readonly int xCells;
        public readonly int yCells;
        public readonly double deltaX;
        public readonly double deltaY;

        private UnitCell unitCell;

        public Structure(UnitCellDetails unitCellDetails)
        {
            unitCell = new UnitCell(unitCellDetails);

            xCells = unitCell.XCells;
            yCells = unitCell.YCells;
            deltaX = unitCell.DeltaX;
            deltaY = unitCell.DeltaY;
            InitialiseStructure();
        }

        private void InitialiseStructure()
        {
            Permittivity = new double [unitCell.XCells,unitCell.YCells];
            Permeability = new double[unitCell.XCells, unitCell.YCells];
            ElecCond = new double[unitCell.XCells, unitCell.YCells];
            MagnCond = new double[unitCell.XCells, unitCell.YCells];
            //at the moment i'm only considering circular rod/hole placed at the centre of the unit cell
            double xCentre = unitCell.XPeriod/2.0;
            double yCentre = unitCell.YPeriod/2.0;
            for (int indexX = 0; indexX < unitCell.XCells; indexX++)
            {
                double x = indexX * unitCell.DeltaX;
                for (int indexY = 0; indexY < unitCell.YCells; indexY++)
                {
                    double y = indexY * unitCell.DeltaY;
                    //at the moment i'm only considering circular rod/hole in the unit cell
                    if (((x-xCentre)*(x-xCentre)+(y-yCentre)*(y-yCentre))<unitCell.RodHoleRadius*unitCell.RodHoleRadius)
                        Permittivity[indexX, indexY] = unitCell.RodHoleDielectric;
                    else
                        Permittivity[indexX, indexY] = unitCell.BackgroundDielectric;

                    Permeability[indexX, indexY] = PhysicalConstants.Mi0;
                    ElecCond[indexX, indexY] = 0.0;
                    MagnCond[indexX, indexY] = 0.0;
                }
            }
        }
    }
}
