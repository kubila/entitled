﻿using Entitled.Contracts;
using Entitled.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entitled.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            return _db.LeaveTypes.ToList(); // cast a list of LeaveTypes
        }

        public LeaveType FindById(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id); 
            return leaveType;
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveTypes.Any(q => q.Id == id); // if there is any record this is true, if not this is false
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0; // return if its grater than 0
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
           
            return Save();
        }
    }
}
