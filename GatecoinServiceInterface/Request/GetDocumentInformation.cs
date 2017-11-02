using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using GatecoinServiceInterface.Response;
namespace GatecoinServiceInterface.Request{
[Route("/Account/DocumentInformation", "GET", Summary = @"Get Step3 Data", Notes = @"")]
public class GetDocumentInformation : IReturn<DocumentInformationResponse>
{
}
}

