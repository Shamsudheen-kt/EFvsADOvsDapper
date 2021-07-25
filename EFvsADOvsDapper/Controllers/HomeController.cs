using Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repository.Abstract;
using DataAccess.Data;

namespace EFvsADOvsDapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository _repo;
        private readonly AppDbContext Context;
        public HomeController( IHomeRepository repo, AppDbContext _Context)
        {
            _repo = repo;
            Context = _Context;
        }
        public IActionResult Index()
        {
            return View(_repo.GetPerfomanceDetails());
        }
    }
}
