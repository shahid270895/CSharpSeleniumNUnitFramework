// using System;
// using LearningNUnit2026.Base;
// using NUnit.Framework.Internal;

// namespace LearningNUnit2026.Tests;

// [Parallelizable(ParallelScope.All)]
// public class GoogleTest : BaseTest
// {
//     [Test]
//     public void VerifyGooglePageTitle()
//     {
//         driver.Navigate().GoToUrl("https://www.google.com");
//         Thread.Sleep(2000);
//         TestContext.WriteLine(driver.Title);
//         Assert.That(driver.Title == "Google");
//     }

//     [Test]
//     public void VerifyGoogleUrl()
//     {
//         driver.Navigate().GoToUrl("https://www.google.com");
//         Thread.Sleep(2000);
//         TestContext.WriteLine(driver.Title);
//         Assert.That(driver.Url.Contains("google"));
//     }
// }
