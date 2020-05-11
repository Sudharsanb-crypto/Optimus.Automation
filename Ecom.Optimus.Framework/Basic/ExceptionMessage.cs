using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Optimus.Framework.Basic
{
    public class EmptyPageUrlException : Exception
    {
        public override string Message => "\t\tPage cannot be loaded, no page url was provided.";
    }

    public class IncorrectBrowserException : Exception
    {
        public override string Message => "\t\tInvalid browser type provided";
    }

    public class TestConfigBrowserEmptyException : Exception
    {
        public override string Message => "\t\tTestConfig browser value cannot be null or empty";
    }

    public class TestConfigUrlEmptyException : Exception
    {
        public override string Message => "\t\tTestConfig url value cannot be null or empty";
    }

    public class TestConfigPasswordEmptyException : Exception
    {
        public override string Message => "\t\tTestConfig password value cannot be null or empty";
    }

    public class TestConfigPageLoadTimeEmptyException : Exception
    {
        public override string Message => "\t\tTestConfig page load time value cannot be zero";
    }

    public class TestConfigImpilicitWaitEmptyException : Exception
    {
        public override string Message => "\t\tTestConfig  Impilicit wait value cannot be zero";
    }

    public class TestConfigDefaultTimeEmptyException : Exception
    {
        public override string Message => "\t\tTestConfig password value cannot be zero";
    }

    public class TestConfigTestReportPathEmptyException : Exception
    {
        public override string Message => "\t\tTestConfig report path cannot be null or empty";
    }
}
