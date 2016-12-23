namespace Odusseus.Rules.Model.Enumeration
{
    using System;
    using System.Collections.Generic;

    public static class EnumExtension
    {
        /// <summary>
        /// Gets all items for an enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAllItems<T>(this Enum value)
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}
