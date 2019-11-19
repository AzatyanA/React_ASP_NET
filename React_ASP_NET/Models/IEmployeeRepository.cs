using System;
using System.Collections.Generic;


namespace React_ASP_NET.Models
{
    public interface IEmployeeRepository: IDisposable
    {
        IEnumerable<Employee> GetAll();

    }
}
