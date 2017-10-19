using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bb.Wordings
{
    /// <summary>
    /// evaluated word sequence
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable{Bb.Wordings.EvaluatedWordRange}" />
    public class Sentence : IEnumerable<EvaluatedWordRange>
    {

        public Sentence()
        {
            this.words = new List<EvaluatedWordRange>();
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        internal void Add(EvaluatedWordRange item)
        {
            if (this.last != null)
            {
                this.last.Next = item;
                item.Previous = last;
            }

            this.words.Add(item);

            this.last = item;

        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<EvaluatedWordRange> GetEnumerator()
        {
            return ((IEnumerable<EvaluatedWordRange>)words).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<EvaluatedWordRange>)words).GetEnumerator();
        }

        public bool Ended { get; internal set; }

        private List<EvaluatedWordRange> words;
        private EvaluatedWordRange last;

    }
}
