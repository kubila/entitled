using AutoMapper;
using Entitled.Contracts;
using Entitled.Data;
using Entitled.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly ILeaveTypeRepository _typerepo;
        private readonly ILeaveAllocationRepository _repo;
        private readonly IMapper _mapper;

        public LeaveAllocationsController(ILeaveTypeRepository typerepo, ILeaveAllocationRepository repo, IMapper mapper)
        {
            _typerepo = typerepo;
            _repo = repo;
            _mapper = mapper;

        }

        // GET: LeaveAllocationsController
        public ActionResult Index()
        {
            var leaves = _typerepo.FindAll().ToList();
            var modelMapped = _mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(leaves);
            var model = new CreateLeaveAllocationViewModel
            {
                LeaveTypes = modelMapped
            };
            return View(model);
        }


        public ActionResult SetLeave(int id)
        {

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
