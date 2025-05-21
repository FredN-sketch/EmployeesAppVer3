using EmployeesApp.Web.Models;

namespace EmployeesApp.Web.Services;

public class OtherEmployeeService : IEmployeeService
{
    readonly List<Employee> employees =
    [
        new Employee()
        {
            Id = 562,
            Name = "Ove Hejlsberg",
            Email = "ove.Hejlsberg@outlook.com",
        },
        new Employee()
        {
            Id = 62,
            Name = "Anna Dollard",
            Email = "anna.d@outlook.com",
        },
        new Employee()
        {
            Id = 15662,
            Name = "Anders Torgersen",
            Email = "Admin.Torgersen@outlook.com",
        },
        new Employee()
        {
            Id = 52,
            Name = "Test Hanselman",
            Email = "test.h@outlook.com",
        }
    ];

    public void Add(Employee employee)
    {
        employee.Id = employees.Count < 0 ? 1 : employees.Max(e => e.Id) + 1;
        employees.Add(employee);
    }


    // Collection expression syntax, introduced in C# 12.
    public Employee[] GetAll() => [.. employees.OrderBy(e => e.Name)];

    ////Classic C# syntax for GetAll()
    //public Employee[] GetAll()
    //{
    //    return employees
    //        .OrderBy(e => e.Name)
    //        .ToArray();
    //}

    public Employee GetById(int id) => employees
        .Single(e => e.Id == id);

    public bool CheckIsVIP(Employee employee) =>
        employee.Email.StartsWith("ADMIN", StringComparison.CurrentCultureIgnoreCase);
}