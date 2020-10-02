using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Devices;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class ServiceClientService
    {
        private ServiceClient serviceClient;

        public ServiceClientService(string connectionstring) 
        {
            serviceClient = ServiceClient.CreateFromConnectionString(connectionstring);
        }

        public async Task<CloudToDeviceMethodResult> InvokeMetodAsync(string targetDevice, string metodName, string payload) 
        {
            var metodInvocation = new CloudToDeviceMethod(metodName);
            metodInvocation.SetPayloadJson(payload);

            var response = await serviceClient.InvokeDeviceMethodAsync(targetDevice, metodInvocation);
            return response;
        
        }





    }
}
