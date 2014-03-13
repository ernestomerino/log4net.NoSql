namespace log4net.NoSql.Util
{
    public interface ITextTransform
    {
        string Serialize(object obj);
    }
}