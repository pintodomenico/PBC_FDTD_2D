using PBC_FDTD_2D.Utilities;

namespace PBC_FDTD_2D;

internal class UnitCell
{
    public double XPeriod { get; }
    public double YPeriod { get; }
    public double DeltaX { get; }
    public double DeltaY { get; }
    public int XCells { get; }
    public int YCells { get; }

    public double BackgroundDielectric { get; }
    public double RodHoleDielectric { get; }
    public double RodHoleRadius { get; }

    public UnitCell(UnitCellDetails unitCellDetails)
    {
        XPeriod = unitCellDetails.XPeriod;
        YPeriod = unitCellDetails.YPeriod;
        DeltaX = unitCellDetails.DeltaX;
        DeltaY = unitCellDetails.DeltaY;
        BackgroundDielectric = unitCellDetails.DielectricBackground;
        RodHoleDielectric = unitCellDetails.RodHoleDielectric;
        RodHoleRadius = unitCellDetails.RodHoleRadius;

        XCells = Discretisation.CalculateDiscreteQuantity(XPeriod, DeltaX);
        YCells = Discretisation.CalculateDiscreteQuantity(YPeriod, DeltaY);
    }
}
