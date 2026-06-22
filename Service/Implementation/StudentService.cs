using Domain.Entities;
using Repository.Repositories.Implementation;
using Service.Interface;

namespace Service.Implementation
{
    public class StudentService : IStudentService
    {
        private static int count;
        private readonly StudentRepository _repository = new();

        public void CreateStudent(Student student)
        {

                count++;
                student.SetId(count);
                _repository.Add(student);

        }

        public void DeleteStudent(int id)
        {
            var entity = GetStudentById(id);
            _repository.Delete(entity);
        }

        public List<Student> GetAllStudents()
        {
            return _repository.GetAll();
        }

        public Student GetStudentById(int id)
        {
            return _repository.Get(x => x.Id == id);
        }

        public List<Student> GetStudents(int page, int pageSize)
        {
            return _repository.GetAll(page, pageSize);
        }

        public List<Student> GetStudentsByAge(int age)
        {
            return _repository.GetAll(x => x.Age == age);
        }

        public List<Student> GetStudentsByGroupId(int groupId)
        {
            return _repository.GetAll(x => x.GroupId == groupId);
        }

        public List<Student> OrderByAge()
        {
            return _repository.GetAll().OrderBy(x => x.Age).ToList();
        }

        public List<Student> OrderByGroups()
        {
            return _repository.GetAll().OrderBy(x => x.GroupId).ToList();
        }

        public List<Student> SearchStudent(string query)
        {
            return _repository.Search(query);
        }

        public Student UpdateStudent(int id, Student student)
        {
            return _repository.Update(student, id);
        }


    }
}
