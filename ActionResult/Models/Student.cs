namespace ActionResult.Models
{
    public class Student
    {
        private static readonly List<Student> students = new List<Student>();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public static (bool, string) Add(Student student)
        {
            var exits = students.Where(s => s.Email == student.Email).Any();
            if (!exits)
            {
                
                student.Id = students.Count() == 0 ? 1 : students.Max(s => s.Id) + 1;
                students.Add(student);
                return (true, "Student Added");
            }
            return (false, "Email Already exit");
        }

        public static (bool, string) Edit(int id, Student updatedStudent)
        {
            var student = Find(id);
            if(student != null)
            {
                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                student.Email = updatedStudent.Email;
                return (true, "Student Updated");
            }
            return (false, "Student Not Found");
        }
        public static (bool, string) Delete(int id)
        {
            var student = Find(id);
            if(student == null)
            {
                return (false, "Studnet Not found");
            }
            students.Remove(student);
            return (true, "Student Removed");
        }

        public static List<Student> List()
        {
            return students;
        }
        public static Student Find(int Id)
        {
            return students.Where(s => s.Id == Id).SingleOrDefault();
        }
    }
}
