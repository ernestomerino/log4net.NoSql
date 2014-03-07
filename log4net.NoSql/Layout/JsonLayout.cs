using System;
using System.IO;
using log4net.Core;
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

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            string loggingEventJson = _transform.Serialize(new
            {
                    timestamp = loggingEvent.TimeStamp.ToUniversalTime().ToString("o"),
                    thread = loggingEvent.ThreadName,
                    level = loggingEvent.Level.ToString(),
                    userName = string.IsNullOrEmpty(loggingEvent.UserName) ? string.Empty : loggingEvent.UserName,
                    message = BuildEventMessage(loggingEvent),
                    host = Environment.MachineName                                
            });

            //write json
            writer.Write(loggingEventJson);

        }

        private string BuildEventMessage(LoggingEvent loggingEvent)
        {
            if (loggingEvent.ExceptionObject == null)
            {
                return loggingEvent.MessageObject.ToString();
            }
            else
            {
                return loggingEvent.MessageObject.ToString() + Environment.NewLine +
                       loggingEvent.ExceptionObject.ToString();
            }
        }

        
    }
}