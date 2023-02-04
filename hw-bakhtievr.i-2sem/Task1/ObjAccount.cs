namespace Task1
{
    public class ObjAccount 
    {
        public ObjAccount(object password)
        {
            Password = password;
        }
        public object Password { get; set; }
        
        public void ChangePassword(object newPassword)
        {
            Password = newPassword;
        }
    }
}