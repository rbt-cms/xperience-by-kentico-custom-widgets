using CMS.ContentEngine;
using CMS.Core;
using CMS.DataEngine;
using CMS.Websites;
using CMS.Websites.Routing;
using Kentico.Xperience.Custom.Models.Reusable.Repeater;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class RepeaterRepository : IRepeaterRepository
{
    private readonly IContentQueryExecutor _contentQueryExecutor;
    private readonly IWebsiteChannelContext _channelContext;
    private readonly IEventLogService _eventLogService;

    public RepeaterRepository(IContentQueryExecutor contentQueryExecutor, IWebsiteChannelContext channelContext, IEventLogService eventLogService)
    {
        _contentQueryExecutor = contentQueryExecutor ?? throw new ArgumentNullException(nameof(contentQueryExecutor));
        _channelContext = channelContext ?? throw new ArgumentNullException(nameof(channelContext));
        _eventLogService = eventLogService ?? throw new ArgumentNullException(nameof(eventLogService));
    }

    public async Task<List<Dictionary<string, object>>> GetParticularPageTypeDataAsync(string pageTypeClassName, string path, int maxItems, string orderBy, string languageName, string orderDirection, CancellationToken cancellationToken = default)
    {
        var pageData = new List<Dictionary<string, object>>();
        var orderDirec = orderDirection == "Descending" ? OrderDirection.Descending : OrderDirection.Ascending;


        try
        {
            orderBy = string.IsNullOrEmpty(orderBy) ? nameof(IWebPageFieldsSource.SystemFields.WebPageItemOrder) : orderBy;
            var builder = new ContentItemQueryBuilder();
            builder.ForContentType(pageTypeClassName, query =>
            {
                query.ForWebsite(_channelContext.WebsiteChannelName, PathMatch.Children(path))
                     .TopN(maxItems);

                // Optional methods for global parametrization of their preceding queries
            }).InLanguage(languageName)

             .Parameters(subqueryParameters =>
                   subqueryParameters.OrderBy(new OrderByColumn(orderBy, orderDirec)));
            IEnumerable<IContentItemFieldsSource> result = await _contentQueryExecutor.GetMappedResult<IContentItemFieldsSource>(builder);

            foreach (var item in result)
            {
                var data = new Dictionary<string, object>();
                foreach (var prop in item.GetType().GetProperties())
                {
                    data[prop.Name] = prop.GetValue(item);
                }
                pageData.Add(data);
            }
        }
        catch (Exception ex)
        {
            _eventLogService.LogException(nameof(RepeaterRepository), nameof(GetParticularPageTypeDataAsync), ex);
        }

        return pageData;
    }
}

