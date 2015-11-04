using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TRoschinsky.App.SPWood
{
    /// <summary>
    /// SPWood - the lightweight alternative to SPMetal.
    /// This tool generates C#-code representing SharePoint lists or libraries to wrap 
    /// their field names in enums and additional properties in summary-comments.
    /// </summary>
    public class SPWood
    {
        private const string tplClassHeader = "/* ***** Automatically generated code by SPWood ***** */\n/* Date/Time {0}                      */\n/* http://about.me/thomas.roschinsky                  */\n\n";
        private const string tplClass = "namespace SPWoodProxy\n{{\n\tpublic static class Web{0}\n\t{{\n{1}\n\t}}\n}}";
        private const string tplEnum = "\t\t/// <summary>\n\t\t/// {0}\n\t\t/// </summary>\n\t\tpublic enum {1}\n\t\t{{\n{2}\n\t\t}}";
        private const string tplEnumItem = "\t\t\t/// <summary>\n\t\t\t/// Display name: '{0}'\n\t\t\t/// Type: {1}; Hidden: {2}; Mandatory: {3}; Read-only: {4}\n\t\t\t/// </summary>\n\t\t\t{5},\n";

        private List<SPWoodEntity> spwLists = new List<SPWoodEntity>();
        /// <summary>
        /// Returns all lists and libraries in connected web
        /// </summary>
        public List<SPWoodEntity> SpwLists { get { return spwLists; } }

        private bool isConnected;
        /// <summary>
        /// Is true if connection to web was successful
        /// </summary>
        public bool IsConnected { get { return isConnected; } }

        private ClientContext clCtx;
        private Web web;


        public SPWood(Uri url)
        {
            clCtx = Connect(url, null);
            if(clCtx != null)
            {
                web = clCtx.Web;
                isConnected = true;
                spwLists = GetLists(true);
            }
            else
            {
                isConnected = false;
            }
        }

        private ClientContext Connect(Uri url, NetworkCredential creds)
        {
            ClientContext spContext = new ClientContext(url);
            if (creds != null)
            {
                spContext.Credentials = creds;
            }
            spContext.Load(spContext.Web);
            spContext.ExecuteQuery();
            return spContext;
        }

        private List<SPWoodEntity> GetLists(bool includeHidden)
        {
            List<SPWoodEntity> lists = new List<SPWoodEntity>();
            if(isConnected)
            {
                clCtx.Load(web.Lists);
                clCtx.ExecuteQuery();
                foreach(List list in web.Lists)
                {
                    clCtx.Load(list, l => l.Hidden, l => l.Description, l => l.EntityTypeName, l => l.DefaultViewUrl);
                    clCtx.ExecuteQuery();
                    if (!includeHidden || !list.Hidden)
                    {
                        SPWoodEntity spwList = new SPWoodEntity()
                        {
                            ListName = list.EntityTypeName,
                            ListTitle = list.Title,
                            ListDescription = list.Description,
                            ListType = (list.BaseType.ToString() == "DocumentLibrary" ? 1 : 0),
                            ListId = list.Id,
                            ListServerRelativeUrl = list.DefaultViewUrl,
                            IsHidden = list.Hidden
                        };
                        lists.Add(spwList);
                    }
                }
            }
            return lists;
        }

        private FieldCollection GetFields(Guid listId)
        {
            FieldCollection fields = null;
            if(isConnected)
            {
                List list = web.Lists.GetById(listId);
                clCtx.Load(list, l => l.Fields);
                clCtx.ExecuteQuery();
                fields = list.Fields;
            }
            return fields;
        }

        /// <summary>
        /// Generates C# code that represents the fields of a SharePoint list or library
        /// </summary>
        /// <param name="spwEntity">SPWoodEntity object to specify the desired list or library</param>
        /// <param name="includeHidden">Specify wether you want to include hidden lists/libs or not</param>
        /// <returns>C# code: single enum with fields</returns>
        public string GetCodeEnumForList(SPWoodEntity spwEntity, bool includeHidden)
        {
            return String.Format(tplClassHeader, DateTime.Now) + getCodeEnumForList(spwEntity, includeHidden);
        }

        private string getCodeEnumForList(SPWoodEntity spwEntity, bool includeHidden)
        {
            string code = String.Empty;
            StringBuilder codeBuilder = new StringBuilder();
            foreach (Field field in GetFields(spwEntity.ListId))
            {
                if (field.Group != "_Hidden")
                {
                    if (includeHidden || !field.Hidden)
                    {
                        codeBuilder.Append(String.Format(tplEnumItem, field.Title, field.TypeAsString, field.Hidden, field.Required, field.ReadOnlyField, field.StaticName));
                    }
                }
            }
            code = codeBuilder.ToString();
            code = code.Substring(0, code.Length - 2);
            return String.Format(tplEnum, spwEntity.ListTitle + " (" + spwEntity.ListServerRelativeUrl + ")", (spwEntity.ListType == 0 ? "List" : "Lib") + spwEntity.ListName, code);
        }

        /// <summary>
        /// Generates C# class that represents all the fields of SharePoint lists and libraries
        /// </summary>
        /// <param name="spwEntity">SPWoodEntities array to specify the desired lists or libraries</param>
        /// <param name="includeHidden">Specify wether you want to include hidden lists/libs or not</param>
        /// <returns>C# code: a static class with lists/libs and their fields</returns>
        public string GetCodeProxyClassForLists(SPWoodEntity[] spwEntities, bool includeHidden)
        {
            StringBuilder codeBuilder = new StringBuilder();
            foreach (SPWoodEntity spwEntity in spwEntities)
            {
                codeBuilder.AppendLine(getCodeEnumForList(spwEntity, includeHidden));
            }
            return String.Format(tplClassHeader, DateTime.Now) + String.Format(tplClass, web.ServerRelativeUrl.Replace("/", "_"), codeBuilder.ToString());
        }
    }


    /// <summary>
    /// Internal representation of a SharePoint list
    /// </summary>
    public class SPWoodEntity
    {
        public string ListName;
        public string ListTitle;
        public string ListDescription;
        public int ListType = 0; // 0=list; 1=lib
        public Guid ListId = Guid.Empty;
        public string ListServerRelativeUrl;
        public bool IsHidden = false;

        public override string ToString()
        {
            if(String.IsNullOrWhiteSpace(ListTitle))
            {
                return ListId.ToString();
            }
            else
            {
                return ListTitle;
            }
        }
    }
}
