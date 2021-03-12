using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;
using System.Web;

namespace Talrand.Core
{
    public class UrlBuilder
    {
        private string BaseUrl = "";
        private Hashtable QueryParameters = new Hashtable();
        private Collection<string> PathSegments = new Collection<string>();
 
        public void SetBaseUrl(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public void AddQueryParameter(string key, string value)
        {
            QueryParameters.Add(key, value);
        }

        public void RemoveQueryParameter(string key)
        {
            if (QueryParameters.ContainsKey(key))
            {
                QueryParameters.Remove(key);
            }
        }

        public void AppendPathSegment(string pathSegment)
        {
            PathSegments.Add(pathSegment);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int paramCount = 0;

            stringBuilder.Append(BaseUrl);

            // Append path segments
            foreach(string pathSegment in PathSegments)
            {
                stringBuilder.Append("/" + pathSegment);
            }

            // Append query parameters
            foreach (DictionaryEntry parameter in QueryParameters)
            {
                paramCount = paramCount + 1;

                // Prefix first parameter with ?, prefix all other parameters with &
                if(paramCount == 1)
                {
                    stringBuilder.Append("?");
                }
                else
                {
                    stringBuilder.Append("&");
                }

                // Appened parameter. Ensuring to url encode value
                stringBuilder.Append(parameter.Key + "=" + HttpUtility.UrlEncode(parameter.Value.ToString()));
            }

            return stringBuilder.ToString();
        }
    }
}