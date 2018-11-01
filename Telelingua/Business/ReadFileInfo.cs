using System.IO;
using Telelingua.API.DTO;

namespace Telelingua.API.Business
{
    public class ReadFileInfo : IReadFileInfo
    {
        public FileInfoDto DirectoryInfo(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return new FileInfoDto(fileInfo);
        }
    }
}
