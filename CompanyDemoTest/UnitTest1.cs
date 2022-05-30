using CompanyDemo.Data;
using CompanyDemo.Interfaces;
using CompanyDemo.Models;
using CompanyDemo.Repository;
using Microsoft.Extensions.Configuration;
using Moq;

namespace CompanyDemoTest;

public class UnitTest1
{
    private IDepartmentRepository _departmentRepository;
    [Fact]
    public async Task Is_the_count_of_depts_created_are_correct()
    {
        var mock = new Mock<IDepartmentRepository>();
        mock.Setup(x => x.GetAll()).Returns(new List<Department>()
        {
            new Department()
            {
                Id = 1,
                DeptName = "Test1",
                MgrId = 1
            },
            new Department()
            {
                Id = 2,
                DeptName = "Test2",
                MgrId = 2
            }
        });
        _departmentRepository = mock.Object;
        var result = _departmentRepository.GetAll();
        Assert.Equal(2, result.Count);
    }
    
    [Fact]
    public async Task Update()
    {
        var mock = new Mock<IDepartmentRepository>();
        
        
        mock.Setup(x => x.Update(It.IsAny<Department>())).;
        mock.Setup(x => x.Create()).Returns(new List<Department>()
        {
            new Department(id: 1, deptName: "Test1", mgrId: 1)
        });
        _departmentRepository = mock.Object;
        var result = _departmentRepository.GetAll();
        Assert.Equal(2, result.Count);
    }
}