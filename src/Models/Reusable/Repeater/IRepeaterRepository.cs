using Kentico.Xperience.Custom.Models.Reusable.Repeater;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kentico.Xperience.Custom.Models.Reusable.Repeater
{
    public interface IRepeaterRepository
    {
        /// <summary>
        /// Retrieves data for a particular page type dynamically, based on the provided class name and query parameters.
        /// </summary>
        /// <param name="pageTypeClassName">The class name of the page type to retrieve.</param>
        /// <param name="path">The content path to filter pages.</param>
        /// <param name="maxItems">The maximum number of items to retrieve.</param>
        /// <param name="orderBy">The field by which to order the results.</param>
        /// /// <param name="cultureCode">The raw where condition for filtering results.</param>
        /// /// <param name="orderDirection">The raw where condition for filtering results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the request.</param>
        /// <returns>A list of dictionaries containing page data for the specified page type.</returns>
        Task<List<Dictionary<string, object>>> GetParticularPageTypeDataAsync(
            string pageTypeClassName,
            string path,
            int maxItems,
            string orderBy,
            string cultureCode,
            string orderDirection,
            CancellationToken cancellationToken = default);
    }
}
