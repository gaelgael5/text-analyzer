using Bb.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.Wordings
{

    public class WordLoader
    {

        public void Load(string filename)
        {

            Assert.NotEmpty(filename, "filename");

            this.file = new FileInfo(filename);
            Assert.Ensure(this.file.Exists, () => new FileNotFoundException(this.file.FullName));

        }


        private FileInfo file;

    }

}
