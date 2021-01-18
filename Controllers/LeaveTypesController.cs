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
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        
        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: LeaveTypesController
        public ActionResult Index()
        {
            var leaves = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(leaves);
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            if(!_repo.isExists(id))
            {
                return NotFound();
            }

            var type = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeViewModel>(type);
            return View(model);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }


                var leave = _mapper.Map<LeaveType>(model); //map values for creation
                leave.DateCreated = DateTime.Now;
                var isDone = _repo.Create(leave);
                

                if (!isDone)
                {
                    ModelState.AddModelError("", "Something went wrong, please try again later.");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                ModelState.AddModelError("", "Something is wrong, please check and try again.");
                return View(model);
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if(!_repo.isExists(id))
            {
                return NotFound();
            }
            var leave = _repo.FindById(id);
            var mapsToView = _mapper.Map<LeaveTypeViewModel>(leave);

            return View(mapsToView);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeViewModel leaveType)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(leaveType);
                }

                var type = _mapper.Map<LeaveType>(leaveType);
                
                var leaveSuccess = _repo.Update(type);

                if(!leaveSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong, please try again later.");
                    return View(leaveType);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something is wrong, please check and try again.");
                return View(leaveType);
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            var leave = _repo.FindById(id);

            if (leave == null)
            {
                return NotFound();
            }

            var isDone = _repo.Delete(leave);

            if (!isDone)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // notice delete method's get and post signature, it's different, we can't have same method name, same method type and same method parameters at the same time
        public ActionResult Delete(LeaveType model, int id)
        {
            try
            {
                var leave = _repo.FindById(id);

                if(leave == null)
                {
                    return NotFound();
                }

                var isDone = _repo.Delete(leave);

                if(!isDone)
                {                   
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View(model);
            }
        }
    }
}
