using System;
using System.Collections.Generic;
using System.Linq;

namespace React_ASP_NET.Models
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private EmployeeContext context;
        public EmployeeRepository (EmployeeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}