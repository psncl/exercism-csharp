public enum Allergen
{
    // @formatter:off
    Eggs           = 1 << 0,
    Peanuts        = 1 << 1,
    Shellfish      = 1 << 2,
    Strawberries   = 1 << 3,
    Tomatoes       = 1 << 4,
    Chocolate      = 1 << 5,
    Pollen         = 1 << 6,
    Cats           = 1 << 7
    // @formatter:on
}

public class Allergies
{
    private readonly int _mask;

    public Allergies(int mask)
    {
        _mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen) => ((Allergen)_mask).HasFlag(allergen);

    public Allergen[] List() => Enum.GetValues<Allergen>().Where(IsAllergicTo).ToArray();
}