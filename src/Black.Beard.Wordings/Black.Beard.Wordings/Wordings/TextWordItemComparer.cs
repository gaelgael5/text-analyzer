using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Wordings
{

    /// <summary>
    /// evaluate if two <see cref="Bb.Wordings.WordItem" /> text are equals
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEqualityComparer{Bb.Wordings.WordItem}" />
    public class TextWordItemComparer : IEqualityComparer<WordItem>
    {

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(WordItem x, WordItem y)
        {
            return x.Text == y.Text                
                ;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public int GetHashCode(WordItem obj)
        {
            return obj.Text.GetHashCode();
        }

    }


}
