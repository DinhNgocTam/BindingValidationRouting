﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Company
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullAddress { get; set; }
    }
}
