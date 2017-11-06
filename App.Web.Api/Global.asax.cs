﻿using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace App.Web.Api
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}