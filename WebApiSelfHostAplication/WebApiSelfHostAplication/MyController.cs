﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiSelfHostAplication
{
    public class MyController: ApiController
    {
        public string Get()
        {
            return "Desde el controller api";
        }
    }
}
