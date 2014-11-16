using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkdownDeep;

namespace UALMedia.Tests.Markdown_Tests
{
    public class MarkdownToHtmlConverter
    {

        public string ConvertMarkdownToHtml(string markdownString)
        {
            var md = new MarkdownDeep.Markdown();
            md.SafeMode = true;

            string outputHtml = md.Transform(markdownString);

            //Review form input and html page format to check if this stage is desirable
            string outputHtmlWithoutLineBreaks = RemoveLineBreaksFromString(outputHtml);

            return outputHtmlWithoutLineBreaks;
        }


        //Consider moving this into an extension method
        public string RemoveLineBreaksFromString(string stringWithLineBreaks)
        {
            string stringWithoutLineBreaks = stringWithLineBreaks.Replace("\n","");

            return stringWithoutLineBreaks;
        }
    }
}
