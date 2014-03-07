using log4net.Core;
using RestSharp.Serializers;

namespace log4net.NoSql.Util
{
    public class TextTransform : ITextTransform
    {
        private static readonly TextTransform _instance = new TextTransform();
        private TextTransform()
        {
        }

        public static TextTransform Instance
        {
            get { return _instance; }
        }

        public string JavaScriptEncode(string value)
        {
            return value
                .Replace(@"\", @"\\")
                .Replace(@"""", @"\""");
        }

        public string Serialize(object obj)
        {
            var serializer = new JsonSerializer();
            serializer.ContentType = "application/json";
            return serializer.Serialize(obj).Replace("timestamp", "@timestamp");
        }
    }
}
