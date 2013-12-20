using System.IO;
using System.Net;

namespace Yandex
{
    public static class YandexGeocoder
    {
        #region const, fields, constructor, properties
        const string REQUESRT_URL = "http://geocode-maps.yandex.ru/1.x/?geocode={0}&format=xml&results={1}&lang={2}";

        private static string _key;

        static YandexGeocoder()
        {
            _key = string.Empty;
        }

        /// <summary>
        /// Yandex Maps API-key (not necessarily)
        /// </summary>
        public static string Key
        {
            get { return _key; }
            set { _key = value; }
        } 
        #endregion


        #region Geocode
        /// <summary>
        /// Location determination by geo object name.
        /// </summary>
        /// <param name="location">Name of a geographic location.</param>
        /// <example>Geocode("Moscow");</example>
        /// <returns>Collection of found locations</returns>
        public static GeoObjectCollection Geocode(string location)
        {
            return Geocode(location, 10);
        }

        /// <summary>
        /// Location determination by name, indicating the quantity of objects to return.
        /// </summary>
        /// <param name="location">Name of a geographic location.</param>
        /// <param name="results">Maximum number of objects to return.</param>
        /// <example>Geocode("Moscow", 10);</example>
        /// <returns>Collection of found locations</returns>
        public static GeoObjectCollection Geocode(string location, short results)
        {
            return Geocode(location, results, LangType.en_US);
        }

        /// <summary>
        /// Location determination by name, indicating the quantity of objects to return and preference language.
        /// </summary>
        /// <param name="location">Name of a geographic location.</param>
        /// <param name="results">Maximum number of objects to return.</param>
        /// <param name="lang">Preference language for describing objects.</param>
        /// <example>Geocode("Moscow", 10, LangType.en_US);</example>
        /// <returns>Collection of found locations</returns>
        public static GeoObjectCollection Geocode(string location, short results, LangType lang)
        {
            string request_ulr =
                string.Format(REQUESRT_URL, StringMakeValid(location), results, LangTypeToStr(lang)) +
                (string.IsNullOrEmpty(_key) ? string.Empty : "&key=" + _key);

            return new GeoObjectCollection(DownloadString(request_ulr));   //new GeoObjectCollection(File.ReadAllText(@"C:\Users\***\Desktop\2.x.xml"));
        }

        /// <summary>
        /// Location determination by name, indicating the quantity of objects to return and preference language.
        /// Allows limit the search or affect the issuance result.
        /// </summary>
        /// <param name="location">Name of a geographic location.</param>
        /// <param name="results">Maximum number of objects to return.</param>
        /// <param name="lang">Preference language for describing objects.</param>
        /// <param name="search_area">Search geographical area, affects to issuance of results.</param>
        /// <param name="rspn">Allows limit the search (true) or affect the issuance result (false - default).</param>
        /// <returns>Collection of found locations</returns>
        public static GeoObjectCollection Geocode(string location, short results, LangType lang, SearchArea search_area, bool rspn = false)
        {
            string request_ulr =
                string.Format(REQUESRT_URL, StringMakeValid(location), results, LangTypeToStr(lang)) +
                string.Format("&ll={0}&spn={1}&rspn={2}", search_area.LongLat.ToString("{0},{1}"), search_area.Spread.ToString("{0},{1}"), rspn ? 1 : 0) +
                (string.IsNullOrEmpty(_key) ? string.Empty : "&key=" + _key);

            return new GeoObjectCollection(DownloadString(request_ulr));
        }
        #endregion


        // ToDo: back geocoding methods
        #region ReGeokode
        private static string ReGeocode(double _long, double _lat)
        {
            return "";
        }
        #endregion

        #region helpers
        // ToDo: encode
        private static string StringMakeValid(string location)
        {
            location = location.Replace(" ", "+").Replace("&","").Replace("?","");
            return location;
        }
        private static string LangTypeToStr(LangType lang)
        {
            switch (lang)
            {
                case LangType.ru_RU: return "ru-RU";
                case LangType.uk_UA: return "uk-UA";
                case LangType.be_BY: return "be-BY";
                case LangType.en_US: return "en-US";
                case LangType.en_BR: return "en-BR";
                case LangType.tr_TR: return "tr-TR";
                default: return "ru-RU";
            }
        }
        private static string DownloadString(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using(Stream dataStream = response.GetResponseStream())
                    using(StreamReader reader = new StreamReader(dataStream))
                        return reader.ReadToEnd();
        }
        #endregion
    }

}
