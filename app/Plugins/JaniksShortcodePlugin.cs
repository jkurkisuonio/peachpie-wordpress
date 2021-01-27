using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Pchp.Core;
using Peachpie.AspNetCore.Mvc;
using Peachpie.AspNetCore.Web;
using PeachPied.WordPress.Standard;

namespace PeachPied.Demo.Plugins
{
  public  class JaniksShortcodePlugin : IWpPlugin
    {
        public JaniksShortcodePlugin()
        {
        }

        public void Configure(WpApp app)
        {
            app.AddShortcode("JaniksdotnetWpUser", new Func<string>(() => //new shortcode_handler((attrs, content) =>
            {
                var user = (WP_User)app.Context.Call("wp_get_current_user", Array.Empty<PhpValue>()).AsObject();
                if (user != null)
                {
                    return $"JANIKS Your WP_User ID is {user.ID}.";
                }
                else
                {
                    return "JANIKS You are not logged in.";
                }
            }));
        }
    }
}
