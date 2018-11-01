using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telelingua.API.DTO;

namespace Telelingua.API.Business
{
    public class ReadFiles : IReadFiles
    {

        public IEnumerable<FileInfoDto> ListDirectoryInfo(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles().Select(fileInfo => new FileInfoDto(fileInfo));
        }
        
    }
}
