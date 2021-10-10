﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMetaUI.Models
{
    public class PageLinkModel : IPageLinkModel
    {
        public int PageNumber { get; set; }
        public string LinkFirst { get; set; }
        public string LinkSecond { get; set; }
        public string LinkThird { get; set; }

        public string LinkForth { get; set; }
    }
}
