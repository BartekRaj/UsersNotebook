namespace UsersNotebook.UI.Models
{
    public interface IUserList
    {
        public List<UserView> Users { get; set; }
    }
    public class UserList : IUserList
    {
        public List<UserView> Users { get; set; } = new List<UserView>();
    }
}
