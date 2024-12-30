using System.Collections.Generic;

namespace GMG.TimeReporting.Core.PasswordArchiveData
{
    public partial class SystemUser
    {
        public SystemUser()
        {
            Passwords = new HashSet<Password>();
        }

        public int SystemUserId { get; set; }
        public string SystemUsername { get; set; }
        public string HashedSystemPassword { get; set; }
        public string DefaultUsername { get; set; }
        public string SystemPasswordHint { get; set; }

        public virtual ICollection<Password> Passwords { get; set; }
    }
}
