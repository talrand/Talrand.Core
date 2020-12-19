using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Talrand.Core
{
    /// <summary>
    /// Extends the System.Net.WebClient class
    /// </summary>
    public class WebClientEx : WebClient
    {
        /// <summary>
        /// CookieContainer for WebClient
        /// </summary>
        public CookieContainer cookieContainer { get; private set; }

        /// <summary>
        /// When class is created instanciate an internal CookieContainer
        /// </summary>
        public WebClientEx()
        {
            this.cookieContainer = new CookieContainer();
        }

        /// <summary>
        /// Adds Cookie Container to WebRequest
        /// </summary>
        /// <param name="webAddress">A string containing the url for the web request</param>
        /// <returns></returns>
        protected override WebRequest GetWebRequest(Uri webAddress)
        {
            // Convert base request to HttpWebRequest object
            var request = base.GetWebRequest(webAddress) as HttpWebRequest;

            // Don't continue if conversion failed
            if (request == null)
            {
                return base.GetWebRequest(webAddress);
            }

            // Assign cookie container to request
            request.CookieContainer = cookieContainer;

            // Set TLS protocol
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            // Return updated request object
            return request;
        }
    }
}
