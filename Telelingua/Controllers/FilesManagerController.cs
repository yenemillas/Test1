using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Telelingua.API.Business;
using Telelingua.API.DTO;

namespace Telelingua.API.Controllers
{
    [Route("files")]
    [ApiController]
    public class FilesManagerController : ControllerBase
    {
        private readonly IReadFiles _readFiles;
        private readonly IReadFileInfo _readFileInfo;
        private readonly IDumpFile _dumpFile;

        public FilesManagerController(IReadFiles filesReader, IReadFileInfo readFileInfo, IDumpFile dumpFile)
        {
            _readFiles = filesReader;
            _readFileInfo = readFileInfo;
            _dumpFile = dumpFile;
        }
        
        [HttpGet]
        [Route("list")]
        public ActionResult<IEnumerable<string>> List(string path)
        {
            try
            {
                return Ok(_readFiles.ListDirectoryInfo(path).Select(fi => fi.Name));
            }
            catch (DirectoryNotFoundException)
            {
                return NotFound("le chemin n'existe pas");
            }
            catch (Exception e)
            {
                throw new Exception("Erreur inconnue", e);
            }
        }

        [HttpGet]
        [Route("info")]
        public ActionResult<FileInfoDto> Info(string path)
        {
            try
            {
                return Ok(_readFileInfo.DirectoryInfo(path));
            }
            catch (FileNotFoundException)
            {
                return NotFound("le fichier n'existe pas");
            }
            catch (Exception e)
            {
                throw new Exception("Erreur inconnue", e);
            }
        }

        [HttpPost]
        [Route("dump")]
        public ActionResult DumpFile(string destinationPath)
        {
            try
            {
                _dumpFile.Create(Request.Body, destinationPath);
                return Ok();
            }
            catch (Exception e)
            {

                throw new Exception("Erreur inconnue", e);
            }
        }

        [HttpGet]
        [Route("steam")]
        public ActionResult<string> SteamFile(string destinationPath)
        {
            try
            {
                  return Ok(_dumpFile.Read(destinationPath));
            }
            catch (Exception e)
            {

                throw new Exception("Erreur inconnue", e);
            }
        }
    }
}
