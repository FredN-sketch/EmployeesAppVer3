using EmployeesApp.Web.Services;

namespace EmployeesApp.Web;

//test
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddSingleton<IEmployeeService, OtherEmployeeService>();
        var app = builder.Build();
        app.UseStaticFiles();
        app.MapControllers();
        app.Run();
    }
}