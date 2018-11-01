using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Telelingua.API.DTO
{
    public class FileInfoDto
    {
        public string Name { get; set; }
        public DateTime LastAccessTime { get; set; }
        public long Length { get; set; }

        public FileInfoDto(FileInfo fileInfo)
        {
            Name = fileInfo.Name;
            LastAccessTime = fileInfo.LastAccessTime;
            Length = fileInfo.Length;
        }
    }

}
