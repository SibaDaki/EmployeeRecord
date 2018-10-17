using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords.DbEntities
{
    public class Person
    {
        [Key]
        public int PersonId { set; get; }
        public string LastName { set; get; }
        public string FirstName { set; get; }
        public DateTime BirthDate { set; get; }
        public List<Employee> State { get; set; }
    }
}
