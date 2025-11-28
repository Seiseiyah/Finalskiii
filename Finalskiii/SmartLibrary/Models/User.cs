using Finalskiii.Finalskiii.Enums;
using Finalskiii.Controllers;
namespace Finalskiii.Finalskiii.Models
{
    public abstract class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public UserType UserType { get;  set; }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _phone = value;
            }
        }

        public virtual int GetBorrowLimit() => 2;
        public virtual int GetLoanDays() => 14;
    }
}
