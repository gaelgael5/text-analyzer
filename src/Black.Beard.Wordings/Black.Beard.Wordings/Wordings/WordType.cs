using Bb.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Wordings
{

    /// <summary>
    /// category of word
    /// </summary>
    public class WordType
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="WordType"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        internal WordType(string text)
        {
            Assert.NotEmpty(text, "text");
            this.Text = text;
        }

        /// <summary>
        /// Gets the text category name.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; }

    }

}
