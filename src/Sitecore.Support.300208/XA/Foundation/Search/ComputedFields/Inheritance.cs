using Sitecore.Buckets.Util;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using System.Linq;

namespace Sitecore.Support.XA.Foundation.Search.ComputedFields
{
  public class Inheritance : AbstractComputedIndexField
  {
    public override object ComputeFieldValue(IIndexable indexable)
    {
      Item item = null;
      if (indexable is SitecoreIndexableItem)
      {
        item = ((Item)(indexable as SitecoreIndexableItem));
      }
      else
      {
        return null;
      }
      return from template in item.Template.BaseTemplates
             select IdHelper.NormalizeGuid(template.ID.ToString(), true);
    }
  }
}