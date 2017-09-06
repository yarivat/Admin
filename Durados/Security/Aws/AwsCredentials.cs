﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durados.Security.Cloud
{
    public class AwsCredentials : ICloudCredentials
    {
        public string AccessKeyID { get; set; }

        public string SecretAccessKey { get; set; }

        public string Region { get; set; }

        
    }
}
