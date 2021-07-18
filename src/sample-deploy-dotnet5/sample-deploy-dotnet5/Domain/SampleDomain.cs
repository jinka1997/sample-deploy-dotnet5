using System.Reflection;

namespace Domain
{
    public static class SampleDomain
    {
        public static Assembly Assembly { get => (typeof(SampleDomain)).GetTypeInfo().Assembly; }
    }
}
