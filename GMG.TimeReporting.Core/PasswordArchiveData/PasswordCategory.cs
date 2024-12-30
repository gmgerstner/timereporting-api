namespace GMG.TimeReporting.Core.PasswordArchiveData
{
    public partial class PasswordCategory
    {
        public int PasswordId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Password Password { get; set; }
    }
}
