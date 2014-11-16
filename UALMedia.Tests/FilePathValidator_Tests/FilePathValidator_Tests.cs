using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UALMedia.Tests.PathValidator;

namespace UALMedia.Tests.FilePathValidator_Tests
{
    [TestFixture]
    public class FilePathValidator_Tests
    {
        private FilePathValidator _filePathValidator;
        
        [SetUp]
        public void SetUp()
        {
            _filePathValidator = new FilePathValidator();
        }


        [Test]
        public void FilePathIsValid_WhenValidPathIsEntered_ReturnsTrue()
        {
            //Arrange
            string filePath = @"C:\Dev\Projects\";


            //Act
            bool isValidInputAndParameters = _filePathValidator.FilePathIsValid(filePath);
            //Assert
            Assert.True(isValidInputAndParameters);
        }

        [Test]
        public void FilePathIsValid_WhenInvalidPathIsEntered_ReturnsTrue()
        {
            //Arrange
            string filePath = @"AD:\Dev\Projects\";
            

            //Act
            bool isValidInputAndParameters = _filePathValidator.FilePathIsValid(filePath);
            //Assert
            Assert.False(isValidInputAndParameters);
        }

        [Test]
        public void FilePathContainsValidCharacters_WhenPathContainsValidCharacters_ReturnsTrue()
        {
            //Arrange
            string filePath = @"C:\Dev\Projects\";
           

            //Act
            bool isValidInputAndParameters = _filePathValidator.FilePathContainsValidCharacters(filePath);
            //Assert
            Assert.True(isValidInputAndParameters);
        }

        [Test]
        public void FilePathContainsValidCharacters_WhenPathContainsInvalidCharacters_ReturnsFalse()
        {
            //Arrange
            string filePath = @"C>:\Dev\Projects\";
            //Act
            bool isValidInputAndParameters = _filePathValidator.FilePathContainsValidCharacters(filePath);
            //Assert
            Assert.False(isValidInputAndParameters);
        }

        [Test]
        public void FilePathRootExsists_WhenFilePathRootExists_ReturnsFalse()
        {
            //Arrange
            string filePath = @"C:\Dev\Projects\";
            //Act
            bool isValidInputAndParameters = _filePathValidator.FilePathRootExists(filePath);
            //Assert
            Assert.True(isValidInputAndParameters);
        }

        [Test]
        public void FilePathRootExsists_WhenFilePathRootDoesNotExist_ReturnsFalse()
        {
            //Arrange
            string filePath = @"B:\Dev\Projects\";
            //Act
            bool isValidInputAndParameters = _filePathValidator.FilePathRootExists(filePath);
            //Assert
            Assert.False(isValidInputAndParameters);
        }
    }
}
