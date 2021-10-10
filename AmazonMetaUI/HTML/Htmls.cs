using AmazonMetaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AmazonMetaUI.HTML
{
    public static class Htmls
    {

        public static async Task<List<string>> asynchtml(List<IPageLinkModel> htmls, IProgress<string> progress)
        {
            //
            List<string> websites = new List<string>();

            List<Task<List<string>>> tasks = new List<Task<List<string>>>();

            foreach (var html in htmls)
            {
                tasks.Add(Task.Run(() => HTML.GetHtmlTextParallel.getHtml2(html.LinkForth)));
                progress.Report($"Collecting Data");
                Thread.Sleep(100);
            }

            var result = await Task.WhenAll(tasks);

            foreach (var item in result)
            {
                foreach (var v in item)
                {
                    websites.Add(v);
                }
            }

            return websites;
        }

    }
}
