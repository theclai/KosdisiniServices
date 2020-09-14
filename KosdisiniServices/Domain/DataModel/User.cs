using System;
namespace KosdisiniServices.Domain.DataModel
{
    public class User
    {
        public User(string fullName, string mobileNumber, string email, string userType)
        {
            CreateDate = DateTime.UtcNow;
            FullName = fullName;
            MobileNumber = mobileNumber;
            Email = email;
            UserType = userType;

        }

        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }

        public string FullName { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string UserType { get; set; }

    }
}
