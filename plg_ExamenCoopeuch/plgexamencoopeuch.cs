using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plg_ExamenCoopeuch
{
    public class plgexamencoopeuch : IPlugin

    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            try
            {
                if (context.InputParameters.Contains("Target") &&
            context.InputParameters["Target"] is Entity)
                {
                    try
                    {
                        //Obtener registro de entidad Requerimiento(incident)
                        Entity entidad = (Entity)context.InputParameters["Target"];

                        if (context.OutputParameters.Contains("id"))
                        {
                            // Creacion registro entidad Peticion
                            Entity regpeticion = new Entity("new_peticion");

                            Guid regardingobjectid = entidad.Id;
                            string regardingobjectidType = "incident";

                            regpeticion["regardingobjectid"] = new EntityReference(regardingobjectidType, regardingobjectid);
                            

                            regpeticion["ownerid"] = new EntityReference("systemuser", ((EntityReference)entidad.Attributes["ownerid"]).Id);
                          
                            if (entidad.Contains("title"))
                            {
                                regpeticion["subject"] = entidad.GetAttributeValue<string>("title");
                            }

                            if (entidad.Contains("description"))
                            {
                                regpeticion["new_descripcion"] = entidad.GetAttributeValue<string>("description");
                            }

                            if (entidad.Contains("ticketnumber"))
                            {
                                regpeticion["new_name"] = entidad.GetAttributeValue<string>("ticketnumber");
                            }

                            regpeticion["new_feharesolucion"] = DateTime.Now.AddDays(10);


                            service.Create(regpeticion);
                        }

                    }
                    catch (Exception e)
                    {
                        throw new InvalidPluginExecutionException(e.Message);
                    }
                }
            }
            catch (InvalidPluginExecutionException ex)
            {
                tracingService.Trace(ex.GetType().FullName + "Ejecución Plugin inválida: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
