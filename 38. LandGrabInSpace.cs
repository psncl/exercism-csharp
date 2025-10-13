// https://exercism.org/tracks/csharp/exercises/land-grab-in-space

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot(Coord sideA, Coord sideB, Coord sideC, Coord sideD)
{
    private Coord _sideA = sideA, _sideB = sideB, _sideC = sideC, _sideD = sideD;

    public ushort GetLargestSide()
    {
        var list = new[] { _sideA, _sideB, _sideC, _sideD };
        return list.Max(coord => Math.Max(coord.X, coord.Y));
    }
}


public class ClaimsHandler
{
    private readonly HashSet<Plot> _claims = [];
    public void StakeClaim(Plot plot) => _claims.Add(plot);

    public bool IsClaimStaked(Plot plot) => _claims.Contains(plot);

    public bool IsLastClaim(Plot plot) => plot.Equals(_claims.Last());

    public Plot GetClaimWithLongestSide() => _claims.MaxBy(plot => plot.GetLargestSide());
}