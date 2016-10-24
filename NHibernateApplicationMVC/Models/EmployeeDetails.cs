using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateApplicationMVC.Models
{
    public class EmployeeDetails
    {
        public virtual int? Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string MobileNo { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string BloodGroup { get; set; }
        public virtual string EmergencyNo { get; set; }
        public virtual DateTime? AddedOn { get; set; }
        public virtual DateTime? UpdatedOn { get; set; }
        public virtual Boolean? Isactive { get; set; }

    }
}