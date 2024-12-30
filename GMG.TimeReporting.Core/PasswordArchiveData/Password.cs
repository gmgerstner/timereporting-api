using System;
using System.Collections.Generic;

namespace GMG.TimeReporting.Core.PasswordArchiveData
{
    public partial class Password
    {
        public Password()
        {
            PasswordCategories = new HashSet<PasswordCategory>();
        }

        public int PasswordId { get; set; }
        public int SystemUserId { get; set; }
        public string Title { get; set; }
        public string PasswordValue { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Notes { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public virtual SystemUser SystemUser { get; set; }
        public virtual ICollection<PasswordCategory> PasswordCategories { get; set; }
    }
}
