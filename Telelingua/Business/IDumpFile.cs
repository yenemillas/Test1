using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Telelingua.API.Business
{
    public interface IDumpFile
    {
        bool Create(Stream stream, string destinationPath);

        string Read(string destinationPath);
    }
}
