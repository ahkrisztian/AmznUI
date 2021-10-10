using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonMetaUI.HTML;

namespace AmazonMetaUI.Comments
{
    public static class NumberOfComments
    {
        public static int GetNumberOfComments(string url, IProgress<string> progress)
        {
            progress.Report("Counting Comments");

            string asyncHtml = GetHtml.getHtml(url).Result;

            string[] divs = asyncHtml.Split('<');

            string reviewlinkfoot = GetLinksFunctions.linkfoot(divs, "see-all-reviews-link-foot");


            //Get a reviews page
            string nexturl = GetLinksFunctions.link(reviewlinkfoot);

            string nextUrlAsync = GetHtml.getHtml(nexturl).Result;

            string[] div = nextUrlAsync.Split('\n');

            string temp = "";

            foreach (string s in div)
            {

                if (s.Contains("globale Rezensionen"))
                {
                    string[] sTemp = s.Split('|');
                    temp = sTemp[1].TrimStart();
                }

                progress.Report("Counting Comments");
            }

            List<char> numbers = new List<char>();

            foreach (char c in temp)
            {
                if (Char.IsDigit(c))
                {
                    numbers.Add(c);
                }

                progress.Report("Counting Comments");
            }

            string charsStr = new string(numbers.ToArray());

            progress.Report("");

            return Convert.ToInt32(charsStr);
           
        }
    }
}
