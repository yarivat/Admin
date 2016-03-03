﻿using Durados.Web.Mvc.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durados.Web.Mvc.SocialLogin
{
    public static class SocialProviderFactory
    {
        public static SocialProvider GetSocialProvider(string providerName)
        {
            switch (providerName.ToLower())
            {
                case "google":
                    return new GoogleSocialProvider();
                case "github":
                    return new GithubSocialProvider();
                case "facebook":
                    return new FacebookSocialProvider();

                default:
                    return null;
            }
        }
    }
}
