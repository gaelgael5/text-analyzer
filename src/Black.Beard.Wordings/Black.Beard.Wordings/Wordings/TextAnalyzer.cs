using Bb.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.Wordings
{

    /// <summary>
    /// text analyzer
    /// </summary>
    public class TextAnalyzer
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyzer"/> class.
        /// </summary>
        /// <param name="worditems">The worditems.</param>
        internal TextAnalyzer(WordItems worditems)
        {
            this.worditems = worditems;
        }

        /// <summary>
        /// Analyzes the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        public IEnumerable<Sentence> Analyze(TextReader reader)
        {

            Assert.NotNull(reader, "reader");

            Sentence s = new Sentence();
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {

                foreach (var item in this.worditems.Resolve(line))
                {

                    s.Add(item);

                    if (s.Ended)
                    {
                        yield return s;
                        s = new Sentence();
                    }
                }

            }

            yield return s;

        }

        /// <summary>
        /// Analyzes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public IEnumerable<Sentence> Analyze(string text)
        {

            Assert.NotEmpty(text, "text");

            var textReader = new StringReader(text);
            return Analyze(textReader);
        }

        private readonly WordItems worditems;

    }

}
