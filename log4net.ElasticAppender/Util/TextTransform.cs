using System.Web.Util;
using log4net.ElasticSearch.Util;

namespace log4net.NoSql.Util
{
    public class TextTransform : HttpEncoder, ITextTransform
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
            return base.JavaScriptStringEncode(value);
//            return value.Replace(@"\", @"\\");
        }
    }
}
