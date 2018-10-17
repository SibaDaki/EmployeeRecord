using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords.DbEntities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { set; get; }
        //[ForeignKey("PersonId")]
        //Adding Foreign Key constraints for Person
        public int PersonId { set; get; }
        public Person person { get; set; }
        public string EmployeeNo { set; get; }
        public DateTime EmployeeDate { set; get; }
        public DateTime TerminatedDate { set; get; }

        //public List<Person> people { get; set; }

    }
}
