using AutoMapper;
using Entitled.Contracts;
using Entitled.Data;
using Entitled.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entitled.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LeaveAllocationsController : Controller
    {
        private readonly ILeaveTypeRepository _typeRepo;
        private readonly ILeaveAllocationRepository _repo;
        private readonly IMapper _mapper;
        public UserManager<IdentityUser> _userManager;

        public LeaveAllocationsController(ILeaveTypeRepository typerepo, ILeaveAllocationRepository repo, UserManager<IdentityUser> userManager,IMapper mapper)
        {
            _typeRepo = typerepo;
            _repo = repo;
            _userManager = userManager;
            _mapper = mapper;

        }

        // GET: LeaveAllocationsController
        public ActionResult Index()
        {
            var leaves = _typeRepo.FindAll().ToList();
            var modelMapped = _mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(leaves);
            var model = new CreateLeaveAllocationViewModel
            {
                LeaveTypes = modelMapped,
                NumberUpdated = 0
            };
            return View(model);
        }


        public ActionResult SetLeave(int id)
        {
            var leaveType = _typeRepo.FindById(id);
            // get all users with Employee role
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;

            // iterate the users with employee role 
            foreach (var item in employees)
            {
                // check if they already allocated to prevent duplicates
                if(_repo.CheckAllocation(id, item.Id))                
                    continue;

                
                var allocation = new LeaveAllocationViewModel
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = item.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year
                };

                // map the allocated user
                var leaveAllocated = _mapper.Map<LeaveAllocation>(allocation);

                //create mapped user for leavement
                _repo.Create(leaveAllocated);
            }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: LeaveAllocationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaveAllocationsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveAllocationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
