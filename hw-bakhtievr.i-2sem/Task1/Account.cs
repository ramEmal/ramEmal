namespace Task1
{
    public class Account<T> : IPlaying<T>
    {
        public Account(T password)
        {
            Password = password;
        }
        public T Password { get; set; }
        
        public void ChangePassword(T newPassword)
        {
            Password = newPassword;
        }
    }
}