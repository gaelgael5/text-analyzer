using Bb.Helpers;

namespace Bb.Wordings
{

    /// <summary>
    /// readed word
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("'{Text}'")]
    public class EvaluatedWord
    {

        /// <summary>
        /// The word item
        /// </summary>
        public readonly WordItem Item;

        /// <summary>
        /// Initializes a new instance of the <see cref="EvaluatedWord"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public EvaluatedWord(WordItem item)
        {

            Assert.NotNull(item, "item");

            this.Item = item;
        }

        /// <summary>
        /// Gets the text for display.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get
            {
                return this.Item?.Text;
            }
        }

    }

}