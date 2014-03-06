using System.IO;
using log4net.Core;
using log4net.ElasticSearch.Util;
using log4net.Layout;
using log4net.NoSql.Util;

namespace log4net.NoSql.Layout
{
    public class JsonLayout : LayoutSkeleton
    {
        private readonly ITextTransform _transform;

        public JsonLayout(ITextTransform transform)
        {
            _transform = transform;
        }

        public JsonLayout() : base()
        {
            _transform = TextTransform.Instance;
        }

        public override string ContentType
        {
            get { return "application/json"; }
        }

        public override void ActivateOptions()
        {
            //nothing to do here
        }

//        public override string Header
//        {
//            get { return "["; }
//        }
//
//        public override string Footer
//        {
//            get { return "]"; }
//        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            //write json
            writer.Write("{");

            writer.Write(@"eventTime: ""{0}""", _transform.JavaScriptEncode(loggingEvent.TimeStamp.ToString("yyyy-MM-ddTHH:mm:ss")));
            //writer.Write(@", _timestamp: ""{0}""", _transform.JavaScriptEncode(loggingEvent.TimeStamp.ToString("o")));
            
            //writer.Write(@", thread: ""{0}""", _transform.JavaScriptEncode(loggingEvent.ThreadName));
            writer.Write(@", level: ""{0}""", _transform.JavaScriptEncode(loggingEvent.Level.ToString()));
            writer.Write(@", message: ""hello""");
            
            //if (!string.IsNullOrEmpty( loggingEvent.UserName))
            //    writer.Write(@", userName: ""{0}""", _transform.JavaScriptEncode(loggingEvent.UserName));

            //if (!string.IsNullOrEmpty(loggingEvent.Identity))
            //    writer.Write(@", identity: ""{0}""", _transform.JavaScriptEncode(loggingEvent.Identity));

//            writer.Write(": \"{0}\"", loggingEvent);
//            writer.Write(": \"{0}\"", loggingEvent);
//            writer.Write(": \"{0}\"", loggingEvent);
//            writer.Write(": \"{0}\"", loggingEvent);
//            writer.Write(": \"{0}\"", loggingEvent);

            //writer.Write(@", message: ""{0}""", _transform.JavaScriptEncode(loggingEvent.RenderedMessage));
            //writer.Write(@", _ttl: ""1d""");
            writer.Write("}");
        }

        
    }
}