﻿using EmployeesApp.Web.Attributes;
using EmployeesApp.Web.Models;
using EmployeesApp.Web.Services;
using EmployeesApp.Web.Views.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Web.Controllers;

public class EmployeesController(IEmployeeService service, ILogger<EmployeesController> logger) : Controller
{
    //static readonly EmployeeService service = new();
    //[ServiceFilter(typeof(EmployeeService))]
    [HttpGet("")]
    public IActionResult Index()
    {
        var model = service.GetAll();

        var viewModel = new IndexVM()
        {
            EmployeeVMs = model
            .Select(e => new IndexVM.EmployeeVM()
            {
                Id = e.Id,
                Name = e.Name,
                ShowAsHighlighted = service.CheckIsVIP(e),
            })
            .ToArray()
        };
        logger.LogInformation("Index action called");
        return View(viewModel);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [ServiceFilter(typeof(MyLogFilterAttribute))]
    [HttpPost("create")]
    public IActionResult Create(CreateVM viewModel)
    {
        if (!ModelState.IsValid)
            return View();

        Employee employee = new()
        {
            Name = viewModel.Name,
            Email = viewModel.Email,
        };

        service.Add(employee);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("details/{id}")]
    public IActionResult Details(int id)
    {
        var model = service.GetById(id);

        DetailsVM viewModel = new()
        {
            Id = model.Id,
            Name = model.Name,
            Email = model.Email,
        };

        return View(viewModel);
    }
}
