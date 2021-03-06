﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durados.Web.Mvc.Stat
{
    public enum MeasurementType
    {
        TeamSize,
        RegisteredUsers,
        //AnonymousUsers
        XmlSize,
        DbSize,
        TotalRows,
        MaxTableTotalRows,
        S3HostingSize,
        S3FilesSize,
        S3NodeJsSize,
        Factor,
    }
}
