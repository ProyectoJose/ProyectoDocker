namespace Empresa.App.Domain
{
    public class BaseEntity
    {
        public string UserCreation = "user";
        public DateTime DateCreation = DateTime.Now;
        public string UserModification = "user";
        public DateTime? DateModification = DateTime.Now;
        public bool RowStatus = true;
    }
}
