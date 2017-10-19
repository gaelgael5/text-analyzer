using Bb.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Bb.Wordings
{

    /// <summary>
    /// word referential
    /// </summary>
    public class WordItems
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="WordItems"/> class.
        /// </summary>
        public WordItems()
        {
            this.Types = new WordTypes();
        }

        #region Build

        private void Build()
        {

            foreach (var item in this._items)
            {
                BuildItem(item, item.Text);

                if (item.Text.EndsWith("'"))
                    BuildItem(item, item.Text.Substring(item.Text.Length - 1));

            }

            _initialized = true;

        }

        private void BuildItem(WordItem item, string text)
        {
            int index = 0;
            char[] arr = text.ToCharArray();
            int length = text.Length;

            var bs = this.boxs;
            boxWord b = null;

            while (index < length)
            {
                int c = (int)arr[index++];
                Debug.Assert(c < bs.Length);
                b = bs[c];
                if (b == null)
                    bs[c] = b = new boxWord();

                bs = b.boxs;

            }

            Debug.Assert(b != null);

            b.Add(item);
        }

        #endregion Build

        internal IEnumerable<EvaluatedWordRange> Resolve(string text)
        {

            int index = 0;
            char[] arr = text.ToCharArray();
            int length = text.Length;
            boxWord[] bs = this.boxs;
            boxWord last = null;

            while (index < length)
            {
                char c = text[index++];
                Debug.Assert(c < this.boxs.Length);
                var currentItem = bs[c];
                if (currentItem != null)
                {

                    bs = currentItem.boxs;

                    if (currentItem.Count > 0)
                        last = currentItem;

                }
                else
                {
                    if (last != null)
                    {

                        var result = new EvaluatedWordRange();
                        foreach (var wordItem in last)
                            result.Add(new EvaluatedWord(wordItem));

                        yield return result;

                        last = null;
                        bs = this.boxs;

                    }
                }
            }

            if (last != null)
            {

                var result = new EvaluatedWordRange();
                foreach (var wordItem in last)
                    result.Add(new EvaluatedWord(wordItem));

                yield return result;

            }

        }

        /// <summary>
        /// Gets the text analyzer.
        /// </summary>
        /// <returns></returns>
        public TextAnalyzer GetTextAnalyzer()
        {

            if (!this._initialized)
                lock (_lock)
                    if (!this._initialized)
                        Build();

            return new TextAnalyzer(this);

        }

        /// <summary>
        /// Adds an new word in the referential
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="kind">The kind.</param>
        /// <param name="multiplicity">The multiplicity.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public WordItem Add(string text, KindEnum kind, MultiplicityEnum multiplicity, params string[] types)
        {

            Assert.NotEmpty(text, "text");
            Assert.Ensure(types.Length > 0, () => new ArgumentOutOfRangeException("types can't be empty"));

            List<WordType> _types = new List<WordType>();

            foreach (var item in types)
                this.Types.Resolve(item.Trim());

            WordItem w = new WordItem()
            {
                Text = text.Trim(),
                Kind = kind,
                Multiplicity = multiplicity,
                Types = _types,
            };

            this._items.Add(w);

            return w;

        }

        #region private

        private class boxWord : List<WordItem>
        {
            internal boxWord[] boxs = new boxWord[256];
        }

        private volatile object _lock = new object();
        private List<WordItem> _items = new List<WordItem>();
        private boxWord[] boxs = new boxWord[256];
        //internal const int Regul = (int)'A';
        internal readonly WordTypes Types;
        private bool _initialized;

        #endregion private

    }

}
