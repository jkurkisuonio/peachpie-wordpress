using PeachPied.WordPress.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Pchp.Core;
using Peachpie.AspNetCore.Mvc;


namespace PeachPied.Demo.Plugins
{
   public class JaniKoePlugin : IWpPlugin

    {
        public string Title { get; } = "JaniKoe Widget";
        public void Configure(WpApp app)
        {
            
            app.DashboardWidget("peachpied.widget.2", "Janikoe Razor Partial View", writer =>
            {
                app.Context.RenderPartial("JaniKoe", this);
            });
        }


    }
}
