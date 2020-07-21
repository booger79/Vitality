﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid FieldId { get; set; }
        public Guid CollegeId { get; set; }

       
        public College College { get; set; }
        public Field Field { get; set; }
    }
}
