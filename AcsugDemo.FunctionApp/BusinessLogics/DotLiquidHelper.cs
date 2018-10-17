using DotLiquid;
using DotLiquid.NamingConventions;
using System.Collections.Generic;

namespace AcsugDemo.FunctionApp.BusinessLogics
{
    public static class DotLiquidHelper
    {

        public static string RenderTemplate(object commonContract, string liquidTemplate)
        {
            Template.NamingConvention = new CSharpNamingConvention();
            Template template = Template.Parse(liquidTemplate);
            var retval = template.Render(Hash.FromAnonymousObject(commonContract));

            return retval;
        }

        public static void RegisterSafeTypeAllProperties(List<object> classesToRegister)
        {
            foreach (var classToRegister in classesToRegister)
            {
                var propertiesToRegister = new List<string>();

                foreach (var property in classToRegister.GetType().GetProperties())
                {
                    propertiesToRegister.Add(property.Name);
                }

                Template.RegisterSafeType(classToRegister.GetType(), propertiesToRegister.ToArray());
            }

        }
    }
}
