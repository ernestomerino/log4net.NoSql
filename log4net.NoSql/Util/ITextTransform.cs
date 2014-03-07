namespace log4net.NoSql.Util
{
    public interface ITextTransform
    {
        string JavaScriptEncode(string value);
        string Serialize(object obj);
    }
}