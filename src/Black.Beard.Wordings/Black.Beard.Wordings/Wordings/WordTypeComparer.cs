using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Wordings
{

    /// <summary>
    /// Evaluate two <see cref="Bb.Wordings.WordType" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEqualityComparer{Bb.Wordings.WordType}" />
    public class WordTypeComparer : IEqualityComparer<WordType>
    {

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(WordType x, WordType y)
        {
            return x.Text == y.Text;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public int GetHashCode(WordType obj)
        {
            return obj.Text.GetHashCode();
        }

    }


}
