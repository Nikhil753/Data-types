using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approvals
{
    public class Class1 : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context =
                (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            IOrganizationServiceFactory serviceFactory =
                (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));

            IOrganizationService service = (IOrganizationService)serviceFactory.CreateOrganizationService(context.UserId);

            if (context.Depth == 1)
            {
                if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
                {
                    Entity account = (Entity)context.InputParameters["Target"];
                    account = service.Retrieve("crc66_my_account", account.Id, new ColumnSet(true));
                

                    //    string dummy_user1 = "61615e87-db34-ed11-9db2-6045bdaaa9b1";
                    //     string dummy_user2 = "98e86c85-dc34-ed11-9db2-6045bdaaa9b1";
                    //       string userr = "a1efdb5e-89b8-ec11-9840-6045bdad7d12";
                    //       Guid GuidUser = ((EntityReference)Reimbursemt.Attributes["systemuser"]).Id;
                    //    int dat= ((OptionSetValue)Reimbursemt.Attributes["crc66_option"]).Value;
                    //  Reimbursemt.Attributes["crc66_textdate"] = dat.ToString();
                    //date1.Date.ToString("MM/dd/yyyy")  
                    //   Reimbursemt.Attributes["crc66_textdate"] = dat.ToString();
                    Guid dat = ((EntityReference)account.Attributes["crc66_data"]).Id;
                    Entity data1 = (Entity)context.InputParameters["Target"];
                    data1 = service.Retrieve("crc66_data_types",dat, new ColumnSet(true));
                    Guid user1 = ((EntityReference)data1.Attributes["crc66_users"]).Id;

                    account.Attributes["crc66_datetext"] = user1.ToString();
                    account.Attributes["crc66_users"] = new EntityReference("systemuser", new Guid(user1.ToString()));













                    service.Update(account);


                    //      int abc = int.Parse(amount);
                  



                }
            }

        }
    }
}

/*nikhil
decimal abc = decimal.Parse(amount);

if (abc >= 1000 && abc <= 5000)
{
    Reimbursemt.Attributes["cr3ea_uuuu"] = new EntityReference("systemuser", new Guid("61615e87-db34-ed11-9db2-6045bdaaa9b1"));
    service.Update(Reimbursemt);
}

else if (abc > 5000)

{
    Reimbursemt.Attributes["cr3ea_uuuu"] = new EntityReference("systemuser", new Guid("98e86c85-dc34-ed11-9db2-6045bdaaa9b1"));
    service.Update(Reimbursemt);
}

else if (abc < 1000)
{
    Reimbursemt.Attributes["cr3ea_uuuu"] = new EntityReference("systemuser", new Guid(""));
    service.Update(Reimbursemt);
}
*/

/*

DateTime dat = ((DateTime)Reimbursemt.Attributes["crc66_date"]);

//date1.Date.ToString("MM/dd/yyyy")

Reimbursemt.Attributes["crc66_textdate"] = dat.Date.ToString("M/d/yyyy");*/