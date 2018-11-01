
using System;
using System.IO;
using System.Linq;
using Telelingua.API.Business;
using Xunit;

namespace Telelingua.Tests
{
    /// <summary>
    /// 1) Test 
    /// 
    /// </summary>
    public class ReadFilesTest
    {
        [Fact]
        public void ShouldListFilesInDirectory()
        {
            var directoyReader = IOC.Get<IReadFiles>();
            var actual = directoyReader.ListDirectoryInfo(@"c:\blalval");
            Assert.Equal(actual, Enumerable.Empty<FileInfo>());
        }
    }
}
