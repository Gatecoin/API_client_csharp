using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Reference/IncomeSourceList", "GET", Summary = @"Get the income source list.", Notes = @"")]
public class GetIncomeSourceList : IReturn<ReferenceListResponse>
{
}
}

