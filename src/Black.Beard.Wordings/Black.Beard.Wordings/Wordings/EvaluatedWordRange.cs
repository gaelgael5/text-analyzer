using System.Collections.Generic;

namespace Bb.Wordings
{

    /// <summary>
    /// expose a list of word resolved by letters sequence
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{Bb.Wordings.EvaluatedWord}" />
    [System.Diagnostics.DebuggerDisplay("'{Text}'")]
    public class EvaluatedWordRange : List<EvaluatedWord>
    {

        /// <summary>
        /// Gets the next word in the sentence sequence
        /// </summary>
        /// <value>
        /// The next.
        /// </value>
        public EvaluatedWordRange Next { get; internal set; }

        /// <summary>
        /// Gets the previous word in the sentence sequence
        /// </summary>
        /// <value>
        /// The previous.
        /// </value>
        public EvaluatedWordRange Previous { get; internal set; }

        /// <summary>
        /// Gets the text display.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get
            {

                if (this.Count == 0)
                    return string.Empty;

                return this[0].Item.Text;

            }
        }


    }


}