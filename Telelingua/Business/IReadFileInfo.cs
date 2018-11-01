using Telelingua.API.DTO;

namespace Telelingua.API.Business
{
    public interface IReadFileInfo
    {
        FileInfoDto DirectoryInfo(string path);
    }
}
