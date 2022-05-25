using System.Data;
using CompanyDemo.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CompanyDemo.Repository;

public class DepartmentRepositoryStored : IDepartmentRepository
    {
        private IDbConnection dbConnection;

        public DepartmentRepositoryStored(IConfiguration configuration)
        {
            this.dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }





        //Add new Company Object
        public Department Create(Department department)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", 0,
                DbType.Int32, direction: ParameterDirection.Output);

            parameters.Add("@DeptName", department.DeptName);
            parameters.Add("@MgrId", department.MgrId);
            //parameters.Add("@Name", department.State);
            this.dbConnection.Execute("usp_AddDepartment",
                parameters, commandType: CommandType.StoredProcedure);

            department.Id = parameters.Get<int>("ID");
            return department;
        }





        //Get details in Company Table by Id
        public Department Find(int id)
        {
            return dbConnection.Query<Department>("usp_GetDepartment",
                new { Id = id },
                commandType: CommandType.StoredProcedure).SingleOrDefault();
        }





        //Get all Company details
        public List<Department> GetAll()
        {
            return dbConnection.Query<Department>("usp_GetAllDepartments", 
                commandType: CommandType.StoredProcedure).ToList();
        }





        public void Delete(int id)
        {
            dbConnection.Execute("usp_RemoveDepartment",
                new { ComanyId = id },
                commandType: CommandType.StoredProcedure);
        }





        public Department Update(Department department)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CompanyId", department.Id,
                DbType.Int32);

            parameters.Add("@ID", 0,
                DbType.Int32, direction: ParameterDirection.Output);

            parameters.Add("@DeptName", department.DeptName);
            parameters.Add("@MgrId", department.MgrId);
            //parameters.Add("@Name", department.State);
            this.dbConnection.Execute("usp_UpdateDepartment",
                parameters, commandType: CommandType.StoredProcedure);

            department.Id = parameters.Get<int>("ID");
            return department;
        }
    }