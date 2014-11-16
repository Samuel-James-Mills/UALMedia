using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UALMedia.Tests.PathValidator;

namespace UALMedia.Tests.FileCreator
{
    public class TextFileCreator
    {
        private IFilePathValidator _filePathValidator;
        public TextFileCreator()
            :this(new FilePathValidator())
        {

        }
        public TextFileCreator(IFilePathValidator filePathValidator)
        {
            this._filePathValidator = filePathValidator;
        }



        public void CreateFile(string filePath, string fileName, string fileExtension, string fileContent)
        {
            using (FileStream fs = new FileStream(filePath + fileName + "." + fileExtension, FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(fileContent);
                }
            }
        }

        public bool ValidateInputAndParameters(string filePath, string fileName, string fileExtension, string fileContent)
        {

            if (!_filePathValidator.FilePathContainsValidCharacters(filePath))
            {
                return false;
            }
            else if (!_filePathValidator.FilePathRootExists(filePath))
            {
                return false;
            }
            else if (!_filePathValidator.FilePathIsValid(filePath + fileName + "." + fileExtension))
            {
                return false;
            }

            return true;
        }


    }
}
