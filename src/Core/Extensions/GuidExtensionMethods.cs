using System;

namespace Core.Extensions
{
    public static class GuidExtensionMethods
    {
        public static bool IsEmpty(this Guid value)
        {
            if(value == Guid.Empty) return true;
            return false;
        }

        public static bool IsNotEmpty(this Guid value) 
        => !IsEmpty(value);
    }
}