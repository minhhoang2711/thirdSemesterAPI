using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Security
{
    public class MyPrincial : IPrincipal
    {
        private EmployeeEntity employee;
        public MyPrincial(EmployeeEntity employee)
        {
            this.employee = employee;
        }

        public IIdentity Identity
        { get; set; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        //public bool IsInRole(string role)
        //{
        //    string[] roles = role.Split(new char[] { ',' });
        //    return roles.Any(r => employee.Roles.Contains(r));
        //}
    }
}