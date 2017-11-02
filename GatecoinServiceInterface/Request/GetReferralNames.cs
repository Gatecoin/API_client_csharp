using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Account/ReferralNames", "GET", Summary = @"Get names of referred traders", Notes = @"")]
public class GetReferralNames : IReturn<CommonResponse>
{
}
}

