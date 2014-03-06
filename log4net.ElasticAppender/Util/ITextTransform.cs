namespace log4net.ElasticSearch.Util
{
    public interface ITextTransform
    {
        string JavaScriptEncode(string value);
    }
}