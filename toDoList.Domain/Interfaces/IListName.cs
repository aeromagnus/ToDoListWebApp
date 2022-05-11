using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoList.Domain;
namespace toDoList.Domain.Interfaces
{
    public interface IListName:IDisposable
    {
        //toDoList Get();
        //toDoList Add(toDoList Record);
        //List<toDoList> List();
        //void SaveChanges();
        //toDoList Get();
        //List<toDoList> GetAll();
        //toDoList Update(toDoList Record);
        //int Delete(toDoList Record);
        //IEnumerable<Student> GetStudents();
        //Student GetStudentByID(int studentId);
        //void InsertStudent(Student student);
        //void DeleteStudent(int studentID);
        //void UpdateStudent(Student student);
        //void Save();

        IEnumerable<toDoList> Getlists();
        toDoList GetListById(int listId);
        void InsertList(toDoList Record);
        void DeleteList(int listID);
        void UpdateList(toDoList Record);
        void Save();
        
    }
}
