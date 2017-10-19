using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Wordings
{

    /// <summary>
    /// word in the referential
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Text} - {Multiplicity} - {Kind} - {TypeString}")]
    public class WordItem
    {

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the types of the words (name, verb, ...).
        /// </summary>
        /// <value>
        /// The types.
        /// </value>
        public IEnumerable<WordType> Types { get; set; }

        /// <summary>
        /// Gets or sets the multiplicity (singular, plurial).
        /// </summary>
        /// <value>
        /// The multiplicity.
        /// </value>
        public MultiplicityEnum Multiplicity { get; set; }

        /// <summary>
        /// Gets or sets the kind (male, female).
        /// </summary>
        /// <value>
        /// The kind.
        /// </value>
        public KindEnum Kind { get; set; }

        /// <summary>
        /// Gets the types sequence in string.
        /// </summary>
        /// <value>
        /// The types to string.
        /// </value>
        public string TypeString
        {
            get
            {
                return string.Join(", ", this.Types.Select(c => c.Text));
            }
        }

    }

}
