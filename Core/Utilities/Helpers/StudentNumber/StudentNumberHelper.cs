using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.StudentNumber
{
    public class StudentNumberHelper : IStudentNumberHelper
    {
        public string Generate()
        {
            Random random = new Random();
            StringBuilder studentNumber = new StringBuilder();

            studentNumber.Append("2023");

            for (int i = 0; i < 8; i++)
            {
                int randomNumber = random.Next(0, 10);
                studentNumber.Append(randomNumber.ToString());
            }

            return studentNumber.ToString();
        }
    }
}
