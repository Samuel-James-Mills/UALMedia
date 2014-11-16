using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UALMedia.Tests.Markdown_Tests
{
    [TestFixture]
    public class MarkdownToHtmlConverter_Tests
    {
        MarkdownToHtmlConverter converter;

        [SetUp]
        public void Setup()
        {
            converter = new MarkdownToHtmlConverter();
        }
        
        [Test]
        public void ConvertMarkdownToHtml_ValidMarkdownString_ReturnsValidHtmlString()
        {
            //Arrange     
            string markdownString = "##Heading##\n\nparagraph";                                  
                    
            //Act
            string htmlString = converter.ConvertMarkdownToHtml(markdownString);
            
            //Assert
            Assert.AreEqual("<h2>Heading</h2><p>paragraph</p>", htmlString);
        }

        [Test]
        public void RemoveLineBreaksFromString_StringWithLineBreaks_ReturnsStringWithoutLineBreaks()
        {
            //Arrange
            string stringWithLineBreak = "\nHello\n World\n";
            
            //Act
            string stringWithoutLineBreak = converter.RemoveLineBreaksFromString(stringWithLineBreak);

            //Assert
            Assert.AreEqual("Hello World", stringWithoutLineBreak);
        }

        
    }
}
