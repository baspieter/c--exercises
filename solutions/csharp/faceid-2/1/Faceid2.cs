public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

        public static bool IsEqual(FacialFeatures faceA, FacialFeatures faceB) => faceA.EyeColor == faceB.EyeColor && faceA.PhiltrumWidth == faceB.PhiltrumWidth;
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
    
    public static bool IsEqual(Identity identityA, Identity identityB) => identityA.Email == identityB.Email && FacialFeatures.IsEqual(identityA.FacialFeatures, identityB.FacialFeatures);
}

public class Authenticator
{
    HashSet<Identity> RegisteredIdentities = new HashSet<Identity>();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => FacialFeatures.IsEqual(faceA, faceB);

    public bool IsAdmin(Identity identity) => identity.Email == "admin@exerc.ism" && identity.FacialFeatures.EyeColor == "green" && identity.FacialFeatures.PhiltrumWidth == 0.9m;

    public bool Register(Identity identity) => IsRegistered(identity) ? false : RegisteredIdentities.Add(identity);

    public bool IsRegistered(Identity identity)
    {
        if (RegisteredIdentities.Count < 1)
        {
            return false;
        }

        foreach (Identity registeredIdentity in RegisteredIdentities)
        {
            if (Identity.IsEqual(registeredIdentity, identity))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA.Equals(identityB);
}
