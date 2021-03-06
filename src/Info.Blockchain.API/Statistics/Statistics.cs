﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Info.Blockchain.API.Statistics
{
    /// <summary>
    /// This class allows users to get the bitcoin network statistics.
    /// It reflects the functionality documented at https://blockchain.info/api/charts_api
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// Gets the network statistics.
        /// </summary>
        /// <param name="apiCode">Blockchain.info API code</param>
        /// <returns>An instance of the StatisticsResponse class</returns>
        /// <exception cref="APIException">If the server returns an error</exception>
        public static StatisticsResponse Get(string apiCode = null)
        {
            var req = new NameValueCollection();
            req["format"] = "json";
            if (apiCode != null)
                req["api_code"] = apiCode;

            string response = HttpClient.Get("stats", req);
            return new StatisticsResponse(JObject.Parse(response));
        }
    }
}
