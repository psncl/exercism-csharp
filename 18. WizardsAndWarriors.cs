// https://exercism.org/tracks/csharp/exercises/wizards-and-warriors
// Practice abstract classes and inheritance

abstract class Character
{
    private readonly string _characterType;
    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {_characterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    private bool _preparedSpell;

    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target) => _preparedSpell ? 12 : 3;

    public void PrepareSpell()
    {
        _preparedSpell = true;
    }

    public override bool Vulnerable() => !_preparedSpell;
}
