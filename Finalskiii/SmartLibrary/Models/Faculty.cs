using Finalskiii.Finalskiii.Enums;

namespace Finalskiii.Finalskiii.Models
{
    public class Faculty : Users
    {
        public Faculty()
        {
            UserType = UserType.Faculty;
        }

        // Faculty has a higher borrow limit
        public override int GetBorrowLimit() => 6;

        // Faculty gets 28 days loan period
        public override int GetLoanDays() => 28;
    }
}
