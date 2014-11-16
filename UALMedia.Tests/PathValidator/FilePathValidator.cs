using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UALMedia.Tests.PathValidator
{
    public class FilePathValidator : IFilePathValidator
    {        
        public bool FilePathIsValid(string filePath)
        {
            bool bOk = System.IO.Path.IsPathRooted(filePath);
            try
            {
                new System.IO.FileInfo(filePath);
                bOk = true;
            }
            catch (ArgumentException) { return false; }
            catch (System.IO.PathTooLongException) { return false; }
            catch (NotSupportedException) { return false; }

            if (bOk)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool FilePathContainsValidCharacters(string filePath)
        {
            string regexString = "[" + Regex.Escape(new string(Path.GetInvalidPathChars())) + "]";
            Regex containsABadCharacter = new Regex(regexString);

            if (containsABadCharacter.IsMatch(filePath))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool FilePathRootExists(string filePath)
        {
            string pathRoot = string.Empty;
            try
            {
                pathRoot = Path.GetPathRoot(filePath);
            }
            catch (ArgumentException) { return false; }

            try
            {
                bool DirectoryContainsRoot = Directory.GetLogicalDrives().Contains(pathRoot);

                if (DirectoryContainsRoot)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (IOException) { return false; }
            catch (UnauthorizedAccessException) { return false; }
        }
    }
    
}
