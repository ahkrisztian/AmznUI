using System;
using System.Collections.Generic;
using System.Linq;
using AmazonMetaUI.Models;

namespace AmazonMetaUI.CreateLinks
{
    public class CreateLinkList
    {
        private readonly List<CommentModel> models;
        public CreateLinkList()
        {
            models = new List<CommentModel>();
        }

        public List<CommentModel> AddLinkModel(List<ReviewModel> commentandtitle)
        {

            for (int i = 0; i < commentandtitle.Count; i++)
            {
                string title = commentandtitle[i].title;
                string comment = commentandtitle[i].comment;
                string formed = $"Title: {title}\n Comment:{comment}\n";

                models.Add(new CommentModel(title, comment, formed));

                //commentandtitle.RemoveRange(0, 1);
            }

            return models;
        }

        public override string ToString() =>
                string.Join(Environment.NewLine,
                models.Select(x => $"Title: {x.CommentTitle}{Environment.NewLine}Comment: {x.Comment}{Environment.NewLine}------------------------------------------"));
    }
}
