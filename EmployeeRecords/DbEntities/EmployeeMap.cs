using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords.DbEntities
{
    public class EmployeeMap
    {
        public EmployeeMap(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.HasKey(t => t.EmployeeId);
            entityBuilder.HasKey(t => t.PersonId);
            entityBuilder.Property(t => t.EmployeeNo).IsRequired();
            entityBuilder.Property(t => t.EmployeeDate).IsRequired();
            entityBuilder.Property(t => t.TerminatedDate).IsRequired();
            //entityBuilder.Property(t => t.MobileNo).IsRequired();

            // entityBuilder.HasKey(t => t.EmployeeId);
            //entityBuilder.Has



        }
    }
}
