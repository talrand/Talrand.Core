using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;
using System.Web;

namespace Talrand.Core
{
    public class UrlBuilder
    {
        private string _baseUrl = "";
        private readonly Hashtable _queryParameters = new Hashtable();
        private readonly Collection<string> _pathSegments = new Collection<string>();
 
        public UrlBuilder(string baseUrl = "")
        {
            _baseUrl = baseUrl;
        }

        public void SetBaseUrl(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public void AddQueryParameter(string key, string value)
        {
            _queryParameters.Add(key, value);
        }

        public void RemoveQueryParameter(string key)
        {
            if (_queryParameters.ContainsKey(key))
            {
                _queryParameters.Remove(key);
            }
        }

        public void AddPathSegment(string pathSegment)
        {
            _pathSegments.Add(pathSegment);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int paramCount = 0;

            stringBuilder.Append(_baseUrl);

            // Append path segments
            foreach(string pathSegment in _pathSegments)
            {
                stringBuilder.Append("/" + pathSegment);
            }

            // Append query parameters
            foreach (DictionaryEntry parameter in _queryParameters)
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