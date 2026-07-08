using NUnit.Framework;

namespace LearningNUnit2026.Utilities;

public class RetryAnalyzer : RetryAttribute
{
    public RetryAnalyzer() : base(ConfigReader.RetryCount)
    {
    }
}