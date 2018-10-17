using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords.Models
{
    public class EmployeeViewModel
    {       

      
            //[Column("EmployeeID")]
            public int EmployeeId { set; get; }
            //[Column("Person ID") Foreign]
            [ForeignKey("PersonId")]
            public new int PersonId { set; get; }
            [Column("Employee No")]
            public string EmployeeNo { set; get; }
            [Column("Employee Date")]
            public DateTime EmployeeDate { set; get; }
            [Column("Termination Date")]
            public DateTime TerminatedDate { set; get; }

        
    }

}