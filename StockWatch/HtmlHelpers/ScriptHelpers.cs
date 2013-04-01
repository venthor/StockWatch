﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;

namespace StockWatch.HtmlHelpers
{
    public static class ScriptHelpers
    {
        public static string RequireScript(this HtmlHelper html, string path, int priority = 1)
        {
            var requiredScripts = HttpContext.Current.Items["RequiredScripts"] as List<ResourceInclude>;
            if (requiredScripts == null) HttpContext.Current.Items["RequiredScripts"] = requiredScripts = new List<ResourceInclude>();
            if (!requiredScripts.Any(i => i.Path == path)) requiredScripts.Add(new ResourceInclude() { Path = path, Priority = priority });
            return null;
        }

        public static HtmlString EmitRequiredScripts(this HtmlHelper html)
        {
            var requiredScripts = HttpContext.Current.Items["RequiredScripts"] as List<ResourceInclude>;
            if (requiredScripts == null) return null;
            StringBuilder sb = new StringBuilder();
            foreach (var item in requiredScripts.OrderByDescending(i => i.Priority))
            {
                sb.AppendFormat("<script src=\"{0}\" type=\"text/javascript\"></script>\n", item.Path);
            }
            return new HtmlString(sb.ToString());
        }

        public class ResourceInclude
        {
            public string Path { get; set; }
            public int Priority { get; set; }
        }
    }
}