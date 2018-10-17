using AcsugDemo.FunctionApp.Contracts.Salesforce;
using AcsugDemo.FunctionApp.Contracts.Unleashed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AcsugDemo.FunctionApp.BusinessLogics
{
    public static class TransformLogic
    {        

        public static Customer TransformToUnleashedCustomer(Account salesforceAccount)  
        {
#if DEBUG
            var templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TemplateResources/SalesforceAccountToUnleashedCustomer.json"); ;
#else
            var templatePath = Path.Combine(@"D:\home\site\wwwroot\LiquidTemplates\SalesforceAccountToUnleashedCustomer.json");
#endif
            DotLiquidHelper.RegisterSafeTypeAllProperties(new List<object> { new Account(), new Customer(), new Address(), new Currency()});

            var liquidTemplate = File.ReadAllText(templatePath);
            var commonPoString = DotLiquidHelper.RenderTemplate(salesforceAccount, liquidTemplate);

            var unleashedCustomer = JsonConvert.DeserializeObject<Customer>(commonPoString);
            unleashedCustomer.Guid = Guid.NewGuid().ToString();

            return unleashedCustomer;
        }
    }
}
