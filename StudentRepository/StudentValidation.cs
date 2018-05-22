using System;
using UserLogin;

namespace StudentRepository
{
    public class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            return StudentData.GetStudent(user.FacNumber);
        }
    }
}
