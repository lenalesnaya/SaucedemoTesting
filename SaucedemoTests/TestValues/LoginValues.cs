using SaucedemoTests.Models.Utilities;
using System.Collections;

namespace SaucedemoTests.TestValues
{
    internal class LoginValidValues
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(UserBuilder.StandartUser);
                yield return new TestCaseData(UserBuilder.ProblemUser);
                yield return new TestCaseData(UserBuilder.PerformanceGlitchUser);
            }
        }
    }

    internal class LoginLockedOutUserValues
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(UserBuilder.LockedOutUser);
            }
        }
    }

    internal class LoginNonExistentUserValues
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(UserBuilder.GetRandomUser());
            }
        }
    }
}