﻿namespace RJCP.Diagnostics.Config
{
    using System.Configuration;

    internal class StyleSheetElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
        }
    }
}
