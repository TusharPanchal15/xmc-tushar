using Newtonsoft.Json.Linq;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XmCloudSXAStarter.JSS_Content_Resolver
{
    public class RelatedBlogItemResolver : RenderingContentsResolver
    {
        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            //check if the parameters are not null
            Assert.ArgumentNotNull(rendering, nameof(rendering));
            Assert.ArgumentNotNull(renderingConfig, nameof(renderingConfig));
            //get the datasource item
            Item datasourceItem = this.GetContextItem(rendering, renderingConfig);
            //return null object if the datasourceItem is null
            if (datasourceItem == null)
                return null;




            //initialize the JSON object to be returned with the datasourceItem details 
            JObject jobject = ProcessItem(datasourceItem, rendering, renderingConfig);
           
            //Read the Multifield List
            Sitecore.Data.Fields.MultilistField multiselectField = datasourceItem.Fields["Related Blogs"];

            Sitecore.Data.Items.Item[] items = multiselectField.GetItems();

            List<Item> itemList = items != null ? items.ToList() : null;
            //return the JSON object if children do not exist
            if (itemList == null || itemList.Count == 0)
                return jobject;
            //add children item details to the JSON object and return the object
            jobject["items"] = ProcessItems(itemList, rendering, renderingConfig);
            return jobject;
        }
    }
    
    
}