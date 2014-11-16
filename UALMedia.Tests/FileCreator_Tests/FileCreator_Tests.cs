using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using UALMedia.Tests.FileCreator;

namespace UALMedia.Tests.FileCreator_Tests
{
    [TestFixture]
    public class FileCreator_Tests
    {
        TextFileCreator creator;
        [SetUp]
        public void Setup()
        {
            creator = new TextFileCreator();
        }

        [Test] //SETUP: this test requires appropriate permissions to access the external file
               //and may return a false negative if configured incorrectly!
        public void CreateNewFile_ValidTextStringAndFileExtentionAndPath_CreatesNewFile()
        {
            //Arrange           
            
            string filePath = @"C:\Dev\Projects\UALMedia\UALMedia\UALMedia.Tests\FileCreator\"; 
            string fileName = "test"; 
            string fileExtension= "html"; 
            string fileContent = "<H1>Hello</H1>";
            //Act
            creator.CreateFile(filePath, fileName, fileExtension, fileContent);

            //Assert
            Assert.True(File.Exists(filePath + fileName + "." + fileExtension));
        }

        [Test]
        public void ValidateInputAndParameters_WhenValidPathIsEntered_ChecksPathsValidity()
        {
            //Arrange
            string filePath = @"C:\Dev\Projects\UALMedia\UALMedia\UALMedia.Tests\FileCreator\";
            string fileName = "test";
            string fileExtension = "html";
            string fileContent = "<H1>Hello</H1>";

            //Act
            bool  isValidInputAndParameters = creator.ValidateInputAndParameters(filePath, fileName, fileExtension, fileContent);
            //Assert
            Assert.True(isValidInputAndParameters);
        }

        [Test]
        public void ValidateInputAndParameters_WhenInvalidPathIsEntered_ChecksPathsValidityAndReturnsFalse()
        {
            //Arrange
            string filePath = @"AD:\Dev\Projects\UALMedia\UALMedia.Tests\FileCreator\";
            string fileName = "test";
            string fileExtension = "html";
            string fileContent = "<H1>Hello</H1>";

            //Act
            bool isValidInputAndParameters = creator.ValidateInputAndParameters(filePath, fileName, fileExtension, fileContent);
            //Assert
            Assert.False(isValidInputAndParameters);
        }

        [Test]
        public void ValidateInputAndParameters_WhenPathContainsValidCharacters_ChecksPathsCharacterValidityAndReturnsFalse()
        {
            //Arrange
            string filePath = @"C:\Dev\Projects\UALMedia\UALMedia\UALMedia.Tests\FileCreator\";
            string fileName = "test";
            string fileExtension = "html";
            string fileContent = "<H1>Hello</H1>";

            //Act
            bool isValidInputAndParameters = creator.ValidateInputAndParameters(filePath, fileName, fileExtension, fileContent);
            //Assert
            Assert.True(isValidInputAndParameters);
        }

        [Test]
        public void ValidateInputAndParameters_WhenPathContainsInvalidCharacters_ChecksPathsCharacterValidityAndReturnsFalse()
        {
            //Arrange
            string filePath = @"C>:\Dev\Projects\UALMedia\UALMedia\UALMedia.Tests\FileCreator\";
            string fileName = "test";
            string fileExtension = "html";
            string fileContent = "<H1>Hello</H1>";

            //Act
            bool isValidInputAndParameters = creator.ValidateInputAndParameters(filePath, fileName, fileExtension, fileContent);
            //Assert
            Assert.False(isValidInputAndParameters);
        }

        [Test]
        public void ValidateInputAndParameters_WhenFilePathRootDoesNotExist_ChecksPathsRootValidityAndReturnsFalse()
        {
            //Arrange
            string filePath = @"B:\Dev\Projects\UALMedia\UALMedia\UALMedia.Tests\FileCreator\";
            string fileName = "test";
            string fileExtension = "html";
            string fileContent = "<H1>Hello</H1>";

            //Act
            bool isValidInputAndParameters = creator.ValidateInputAndParameters(filePath, fileName, fileExtension, fileContent);
            //Assert
            Assert.False(isValidInputAndParameters);
        }
    }
}
