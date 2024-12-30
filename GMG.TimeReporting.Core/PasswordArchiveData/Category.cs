using System.Collections.Generic;

namespace GMG.TimeReporting.Core.PasswordArchiveData
{
    public partial class Category
    {
        public Category()
        {
            PasswordCategories = new HashSet<PasswordCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<PasswordCategory> PasswordCategories { get; set; }
    }
}
