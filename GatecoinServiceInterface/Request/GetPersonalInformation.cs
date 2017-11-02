using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Account/PersonalInformation", "GET", Summary = @"Get Step1 Data", Notes = @"")]
public class GetPersonalInformation : IReturn<PersonalInformationResponse>
{
}
}

