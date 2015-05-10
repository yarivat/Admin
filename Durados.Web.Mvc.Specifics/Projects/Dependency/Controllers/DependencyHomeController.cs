﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;

using Durados;
using Durados.Web.Mvc.UI.Helpers;

namespace Durados.Web.Mvc.App.Controllers
{
    [HandleError]
    public class DependencyHomeController : DependencyBaseController
    {
        public ActionResult Stam()
        {
            return View();
        }
    }

}
