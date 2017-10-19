using Bb.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bb.Wordings
{

    /// <summary>
    /// category of word referentiel
    /// </summary>
    public class WordTypes
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="WordTypes"/> class.
        /// </summary>
        public WordTypes()
        {
            this._items = new Dictionary<string, WordType>();
        }

        /// <summary>
        /// Resolves the wordType for the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public WordType Resolve(string item)
        {

            Assert.NotEmpty(item, "item");

            WordType wordType;

                string _item = item.ToLower();
                if (!this._items.TryGetValue(_item, out wordType))
                {
                    var type = new WordType(_item);
                    this._items.Add(_item, type);
                }

            return wordType;

        }

        /// <summary>
        /// The wordtypes's list
        /// </summary>
        private Dictionary<string, WordType> _items;

    }

}
