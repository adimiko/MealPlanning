namespace Core.Extensions
{
    public static class FloatExtensionMethod
    {
        public static bool IsEqualOrAboveZero(this float value)
        {
            if(value >= 0) return true;
            return false;
        }
    }
}