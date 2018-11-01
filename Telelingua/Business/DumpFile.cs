using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Telelingua.API.Business
{
    public class DumpFile : IDumpFile
    {
        public bool Create(Stream stream, string destinationPath)
        {
            using (var fileStream = File.Create(destinationPath))
            {
               stream.CopyTo(fileStream);
            }
            return true;
        }

        public string Read(string destinationPath)
        {
            Stream fs = File.OpenRead(destinationPath);
            StreamReader reader = new StreamReader(fs);
            return reader.ReadToEnd();
        }
    }
}
