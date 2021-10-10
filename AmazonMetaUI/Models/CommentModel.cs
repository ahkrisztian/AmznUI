using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMetaUI.Models
{
    public class CommentModel
    {

        public string CommentTitle;
        public string Comment;
        public string Formed;


        public CommentModel(string title, string comment, string formed)
        {
            CommentTitle = title;
            Comment = comment;
            Formed = formed;
        }


    }
}
