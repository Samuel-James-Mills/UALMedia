using System;
namespace UALMedia.Tests.PathValidator
{
    public interface IFilePathValidator
    {
        bool FilePathContainsValidCharacters(string filePath);
        bool FilePathIsValid(string filePath);
        bool FilePathRootExists(string filePath);
    }
}
