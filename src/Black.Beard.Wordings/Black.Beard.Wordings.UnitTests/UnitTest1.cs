using Bb.Wordings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace Black.Beard.Wordings.UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {

            WordItems storage = new WordItems();
            storage.Add("la", KindEnum.Female, MultiplicityEnum.Singular, "déterminant");
            storage.Add("vélocité", KindEnum.Female, MultiplicityEnum.Singular, "Nom");
            storage.Add("c'", KindEnum.Female, MultiplicityEnum.Singular, "???");
            storage.Add("est", KindEnum.Female, MultiplicityEnum.Singular, "Auxiliaire", "Verbe");
            storage.Add("vitesse", KindEnum.Female, MultiplicityEnum.Singular, "Nom");

            storage.Add(".", KindEnum.Undefined, MultiplicityEnum.Undefined, "Ponctuation");

            var analyzer = storage.GetTextAnalyzer();

            foreach (Sentence sentence in analyzer.Analyze("la vélocité c'est la vitesse."))
            {

            }

        }
    }
}
