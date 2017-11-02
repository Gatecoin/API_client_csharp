using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Account/User", "GET", Summary = @"Get all user info", Notes = @"")]
public class GetAllUserInfo : IReturn<AllUserInfoResponse>
{
}
}

