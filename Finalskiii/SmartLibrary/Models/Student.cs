using Finalskiii.Finalskiii.Enums;
using Finalskiii.Finalskiii.Models;

namespace SmartsLibrary.Core.Models
{
    public class Student : Users
    {
        private UserType studentEnum;
        public Student()
        {
             studentEnum =  UserType.Student;
        }

        public override int GetBorrowLimit() => 3;
        public override int GetLoanDays() => 14;
    }
}