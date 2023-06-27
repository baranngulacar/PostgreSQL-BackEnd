using System;
namespace Core.Entities.Concrete
{
    public class User : IEntity
	{
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public UserStatus Status { get; set; }
    }

    public enum UserStatus
    {
        Active=0,
        Passive=1,
        Suspend=2,
        Pending=3
    }
}

