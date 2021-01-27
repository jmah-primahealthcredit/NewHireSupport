using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Newtonsoft.Json;
using HelpDeskService;
using HelpDeskService.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace HelpDesk.NewHireSupport
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>        /// <param name="context"></param>
        /// <returns></returns>
        public async Task FunctionHandler(NewHireSupportData newHireSupportData, ILambdaContext context)
        {
            // newHireSupportJson is not set
            if (newHireSupportData == null)
            {
                throw new Exception("New hire support json is not set.");
            }

            SupportService service = new SupportService(context);
            await service.NotifyNewHireAsync(newHireSupportData);
        }
    }
}
