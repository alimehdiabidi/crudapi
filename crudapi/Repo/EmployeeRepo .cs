using crudapi.Model;
using crudapi.Model.Data;
using Dapper;
using System.Data;

namespace crudapi.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DapperDBContext context;
        public EmployeeRepo(DapperDBContext context)
        {
            this.context = context;
        }

        public async Task<string> Create(Employee employee)
        {
            string response = string.Empty;
            string query = "INSERT INTO FROM EMPLOYEE (name,email,phone, designation) VALUES (@name,@email, @phone, @designation)";
            var parameters = new DynamicParameters();
            parameters.Add("name", employee.name, DbType.String);
            parameters.Add("email", employee.email, DbType.String);
            parameters.Add("phone", employee.phone, DbType.String);
            parameters.Add("designation", employee.designation, DbType.String);

            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters );
                response = "pass";
            }
            return response;
        }

       
        public async Task<List<Employee>> GetAll()
        {
            string query = "SELECT * FROM EMPLOYEE";
            using (var connection = this.context.CreateConnection()) 
            {
                var emplist = await connection.QueryAsync<Employee>(query);
                return emplist.ToList();
            }

        }

        public async Task<Employee> Getbycode(int code)
        {
            string query = "SELECT * FROM EMPLOYEE where code=@code";
            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.QueryFirstOrDefaultAsync<Employee>(query, new {code});
                return emplist;
            }
        }

        public async Task<string> Remove(int code)
        {
            string response = string.Empty;
            string query = "DELETE * FROM EMPLOYEE where code=@code";
            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { code });
                response = "pass";
            }
            return response;
        }

        //public async Task<string> Update(Employee employee, int code    )
        //{
        //    string response = string.Empty;
        //    string query = "UPDATE EMPLOYEE set name=@name , email=@email, phone=@phone, designation=@designation";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("code", code, DbType.Int32);

        //    parameters.Add("name", employee.name, DbType.String);
        //    parameters.Add("email", employee.email, DbType.String);
        //    parameters.Add("phone", employee.phone, DbType.String);
        //    parameters.Add("designation", employee.designation, DbType.String);

        //    using (var connection = this.context.CreateConnection())
        //    {
        //        await connection.ExecuteAsync(query, parameters);
        //        response = "pass";
        //    }
        //    return response; 
        //}

        public async Task<string> Update(Employee employee, int code)
        {
            string response = string.Empty;
            string query = "UPDATE EMPLOYEE set name=@name , email=@email, phone=@phone, designation=@designation";
            var parameters = new DynamicParameters();
            parameters.Add("code", code, DbType.Int32);

            parameters.Add("name", employee.name, DbType.String);
            parameters.Add("email", employee.email, DbType.String);
            parameters.Add("phone", employee.phone, DbType.String);
            parameters.Add("designation", employee.designation, DbType.String);

            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
    }
}
