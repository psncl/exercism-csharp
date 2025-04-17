// https://exercism.org/tracks/csharp/exercises/faceid-2
// Practice Equals, GetHashCode, and HashSet

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    // No explicit null check required below, because the 'as' keyword returns null if casting is not possible.
    public override bool Equals(Object? obj) => ReferenceEquals(this, obj) || Equals(obj as FacialFeatures);

    public bool Equals(FacialFeatures? other) =>
        other != null && this.EyeColor == other.EyeColor && this.PhiltrumWidth == other.PhiltrumWidth;

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(Object? obj) => ReferenceEquals(this, obj) || Equals(obj as Identity);

    public bool Equals(Identity? other) =>
        other != null && this.Email == other.Email && this.FacialFeatures.Equals(other.FacialFeatures);


    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private HashSet<Identity> _registeredIdentities = new();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));
    }

    // Utilize short-circuiting behavior below.
    // Actually, it isn't even required to check !IsRegistered, because HashSet's Add method returns false if the element is already present.
    public bool Register(Identity identity) => !IsRegistered(identity) && _registeredIdentities.Add(identity);

    public bool IsRegistered(Identity identity) => _registeredIdentities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) =>
        ReferenceEquals(identityA, identityB);
}