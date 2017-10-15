using System;
using System.IO;
using System.Reflection;

namespace AspNetCoreApp.Service.Bootstrapping
{
    public class AssemblyHelper
    {
        readonly Assembly _assembly;
        public AssemblyHelper()
        {
            this._assembly = this.GetType().Assembly;
        }

        public string Description
        {
            get { return GetAttributeValue<AssemblyDescriptionAttribute>(a => a.Description); }
        }

        public string Title
        {
            get { return GetAttributeValue<AssemblyTitleAttribute>(a => a.Title, Path.GetFileNameWithoutExtension(this._assembly.CodeBase)); }
        }

        private string GetAttributeValue<TAttr>(Func<TAttr, string> resolveFunc, string defaultResult = null) where TAttr : Attribute
        {
            object[] attributes = this._assembly.GetCustomAttributes(typeof(TAttr), false);

            if (attributes.Length > 0)
            {
                return resolveFunc((TAttr)attributes[0]);
            }
            else
            {
                return defaultResult;
            }
        }
    }
}
