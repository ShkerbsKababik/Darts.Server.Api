public class UserCanNotBeCreatedException : Exception
{
    public UserCanNotBeCreatedException() : base("user with this given parameter cannot be created") { }
}