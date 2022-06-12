using Grpc.Core;
using server;
using server.Data;
using System;
namespace server.Services{ // export item service
    public class ExportItemService : ExportItem.ExportItemBase

    {
        private readonly ILogger<ExportItemService> _logger;
        public ExportItemService(ILogger<ExportItemService> logger)
        {
            _logger = logger;
        }
                
        public override async Task FindItems(QueryRequest request,IServerStreamWriter<QueryResponse> responseStream, ServerCallContext context)
        {
            string req = request.Filter;
            req.Trim();
            
            var items = MessageData.MessagesData.Where(p => p.HasAttachments == true).ToList();
            foreach(var item in items){
                await responseStream.WriteAsync(item);
            }
        }
}

}

//C:\Users\t-anigupta\grpcexamp\server\Services\ExportItemService.cs