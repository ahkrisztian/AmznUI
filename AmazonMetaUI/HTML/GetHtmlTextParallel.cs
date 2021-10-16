using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMetaUI.HTML
{
    public static class GetHtmlTextParallel
    {
        public static async Task<List<string>> getHtml2(string x)
        {
            string responseFromServer = await GetHtml.getHtml(x);

            return CleanHtml.GetCommentsTitlesParallel(responseFromServer);

        }
    }
}
