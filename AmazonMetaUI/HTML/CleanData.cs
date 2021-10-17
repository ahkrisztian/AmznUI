﻿using AmazonMetaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMetaUI.HTML
{
    public static class CleanData
    {
        public static List<ReviewModel> Middle(string text)
        {

            string[] html = text.Split(new[] { "cr-filter-info-section", "window.P.register('cf')" }, StringSplitOptions.RemoveEmptyEntries);

            //Second part - where the reviews are
            string[] htmll = html[1].Split(new[] { "data-hook=\"review\"" }, StringSplitOptions.RemoveEmptyEntries);


            List<ReviewModel> models = new List<ReviewModel>();

            for (int i = 1; i < htmll.Length; i++)
            {
                string[] x = htmll[i].Split(new[] { "<" }, StringSplitOptions.RemoveEmptyEntries);

                ReviewModel model = new ReviewModel();

                List<string> commentandtitle = new List<string>();

                //Create Comment and Title
                foreach (var v in x)
                {
                    if (commentandtitle.Count == 2)
                    {
                        model.title = commentandtitle[0];
                        model.comment = commentandtitle[1].Replace("\r\n", "");
                        break;
                    }

                    if (v.Contains("span") && !v.Contains("class"))
                    {
                        string[] result = v.Split(">");

                        foreach (var r in result)
                        {
                            if (!r.Contains("span") && !String.IsNullOrWhiteSpace(r) && !r.Contains("Kommentare anzeigen"))
                            {
                                commentandtitle.Add(r);
                            }
                        }
                    }

                    if (v.Contains("cr-original-review-content"))
                    {
                        string[] result = v.Split(">");

                        foreach (var r in result)
                        {
                            if (!r.Contains("span") && !String.IsNullOrWhiteSpace(r) && !r.Contains("Kommentare anzeigen"))
                            {
                                commentandtitle.Add(r);
                            }
                        }
                    }
                }

                //Create Date and From
                foreach (var v in x)
                {
                    if (v.Contains("review-date"))
                    {
                        int index = v.IndexOf('>');
                        model.date = v.Remove(0, index + 1);
                    }
                }

                //Create Stars and link to the Costumer
                foreach (var v in x)
                {
                    if (v.Contains("href") && v.Contains("title="))
                    {
                        string[] splitat = v.Split("\"");

                        foreach (var z in splitat)
                        {
                            if (z.Contains("von"))
                            {
                                model.stars = z;
                            }

                            if (z.Contains("customer"))
                            {
                                model.linkToCostumer = z;
                            }
                        }
                    }
                }

                model.modelId = i;
                models.Add(model);
            }

            return models;
        }
    }
}

