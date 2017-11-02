using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Account/Referral", "GET", Summary = @"Get referral information", Notes = @"")]
public class GetReferralStatus : IReturn<CommonResponse>
{
}
}

