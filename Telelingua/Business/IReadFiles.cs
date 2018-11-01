using System.Collections.Generic;
using Telelingua.API.DTO;

namespace Telelingua.API.Business
{
    public interface IReadFiles
    {
        IEnumerable<FileInfoDto> ListDirectoryInfo(string path);

    }
}
