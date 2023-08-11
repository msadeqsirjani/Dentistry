namespace Dentistry.Common.Utils.Helper;

public static class GuidHelper
{
    public static string GenerateStringUnique()
    {
        return Guid.NewGuid().ToString();
    }
}