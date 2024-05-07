using crudapi.Model;        
namespace crudapi.Repo
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAll();// task=asynchronous
        Task<Employee> Getbycode(int code );
        Task<string> Create(Employee employee );
        Task<string> Update(Employee employee, int code);
         Task<string> Remove(int code); 

    }
}
