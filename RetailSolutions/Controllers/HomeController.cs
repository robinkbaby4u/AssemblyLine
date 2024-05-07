using Business.Domain;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RetailSolutions.Models;
using System.Diagnostics;

namespace RetailSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  IEmployeeService _employeeService;
        private IWorkProcessorService _workProcessorService;

        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService, IWorkProcessorService workProcessorService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _workProcessorService=workProcessorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(OrderDetail orderDetail)
        {
            string path = @"C:\Users\Robin\file.csv"; // Local path
            
            // Get Employees data from csv
            var employees = _employeeService.GetEmployees(path);

            // Process Work
            var totalHoursTaken = _workProcessorService.ProcessOrder(orderDetail, employees);
            
            
            ViewBag.TotalHoursTaken = totalHoursTaken;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
