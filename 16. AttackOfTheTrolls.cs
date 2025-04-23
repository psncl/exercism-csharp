// https://exercism.org/tracks/csharp/exercises/attack-of-the-trolls
// Practice Flag Enums and bitwise operations on them.

enum AccountType
{
    Guest,
    User,
    Moderator
}

[Flags]
enum Permission : byte
{
    // @formatter:off
    None   = 0b_0000_0000,
    Read   = 0b_0000_0001,
    Write  = 0b_0000_0010,
    Delete = 0b_0000_0100,
    All    = Read | Write | Delete
    // @formatter:on
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        return accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Moderator => Permission.All,
            _ => Permission.None
        };
    }

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke) => current & ~revoke;

    public static bool Check(Permission current, Permission check) => (current & check) == check;
    // Enum.HasFlag method could also be used for the above.
}