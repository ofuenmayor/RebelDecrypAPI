using System;
using Castle.Core.Logging;

namespace RebelDecprypApi_test.FakeObjects
{
  public class FakeILogger : ILogger
  {
    public bool IsTraceEnabled => throw new NotImplementedException();

    public bool IsDebugEnabled => throw new NotImplementedException();

    public bool IsErrorEnabled => throw new NotImplementedException();

    public bool IsFatalEnabled => throw new NotImplementedException();

    public bool IsInfoEnabled => throw new NotImplementedException();

    public bool IsWarnEnabled => throw new NotImplementedException();

    public ILogger CreateChildLogger(string loggerName)
    {
      throw new NotImplementedException();
    }

    public void Debug(string message)
    {
      throw new NotImplementedException();
    }

    public void Debug(Func<string> messageFactory)
    {
      throw new NotImplementedException();
    }

    public void Debug(string message, Exception exception)
    {
      throw new NotImplementedException();
    }

    public void DebugFormat(string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void DebugFormat(Exception exception, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void DebugFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void Error(string message)
    {
      throw new NotImplementedException();
    }

    public void Error(Func<string> messageFactory)
    {
      throw new NotImplementedException();
    }

    public void Error(string message, Exception exception)
    {
      throw new NotImplementedException();
    }

    public void ErrorFormat(string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void ErrorFormat(Exception exception, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void ErrorFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void Fatal(string message)
    {
      throw new NotImplementedException();
    }

    public void Fatal(Func<string> messageFactory)
    {
      throw new NotImplementedException();
    }

    public void Fatal(string message, Exception exception)
    {
      throw new NotImplementedException();
    }

    public void FatalFormat(string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void FatalFormat(Exception exception, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void FatalFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void Info(string message)
    {
      throw new NotImplementedException();
    }

    public void Info(Func<string> messageFactory)
    {
      throw new NotImplementedException();
    }

    public void Info(string message, Exception exception)
    {
      throw new NotImplementedException();
    }

    public void InfoFormat(string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void InfoFormat(Exception exception, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void InfoFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void Trace(string message)
    {
      throw new NotImplementedException();
    }

    public void Trace(Func<string> messageFactory)
    {
      throw new NotImplementedException();
    }

    public void Trace(string message, Exception exception)
    {
      throw new NotImplementedException();
    }

    public void TraceFormat(string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void TraceFormat(Exception exception, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void TraceFormat(IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void TraceFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void Warn(string message)
    {
      throw new NotImplementedException();
    }

    public void Warn(Func<string> messageFactory)
    {
      throw new NotImplementedException();
    }

    public void Warn(string message, Exception exception)
    {
      throw new NotImplementedException();
    }

    public void WarnFormat(string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void WarnFormat(Exception exception, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }

    public void WarnFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
    {
      throw new NotImplementedException();
    }
  }
}