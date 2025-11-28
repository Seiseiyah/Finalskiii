using Finalskiii.Finalskiii.Enums;

namespace Finalskiii.SmartLibrary.Models
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public UserType UserType { get; protected set; }

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
    }
}
