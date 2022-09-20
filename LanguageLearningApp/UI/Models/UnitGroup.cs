using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp
{
    public class UnitGroup : ObservableCollection<GradedUnit>
    {
        #region Constructors

        public UnitGroup(string name) : base()
        {
            Name = name;
        }

        public UnitGroup(string name, IEnumerable<GradedUnit> source)
        : base(source)
        {
            Name = name;
        }

        #endregion Constructors

        #region Properties
        public string Name { get; set; }

        #endregion Properties
    }
}