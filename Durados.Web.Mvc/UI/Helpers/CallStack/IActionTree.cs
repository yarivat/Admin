﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Durados.Web.Mvc.UI.Helpers.CallStack
{
    public interface IActionTree
    {
        IAction ActionRoot { get; }
    }
}