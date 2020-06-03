namespace Core.Extensions
{
    public static class IntExtensionMethods
    {
        public static bool IsGreaterThanZero(this int value)
        {
            if(value > 0) return true;
            return false;
        }
    }
}