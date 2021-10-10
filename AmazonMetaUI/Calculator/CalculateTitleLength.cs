using AmazonMetaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMetaUI.Calculator
{
    public class CalculateTitleLength : CalculatorBaseClass
    {
        public CalculateTitleLength(List<CommentModel> models)
        : base(models)
        {
        }
        public override double CommentLength()
        {
            List<double> temp = new List<double>();

            _models.ForEach(n => temp.Add(n.CommentTitle.Length));

            return temp.Average();
        }

        public override string ToString()
        {
            return $"The average length of the titles:{Environment.NewLine} {CommentLength():0}";
        }
    }
}
