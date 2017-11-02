using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Reference/IncomeRangeList", "GET", Summary = @"Get the income range list.", Notes = @"")]
public class GetIncomeRangeList : IReturn<ReferenceListResponse>
{
}
}

