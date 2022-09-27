using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Models
{
    public class QuestionAnswerObj
    {
        #region Properties
        public List<string> Answer { get; set; }
        public string Question { get; set; }

        #endregion Properties
    }
}