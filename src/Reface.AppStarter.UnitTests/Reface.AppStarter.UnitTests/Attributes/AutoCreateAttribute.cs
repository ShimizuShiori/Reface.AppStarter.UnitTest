using System;

namespace Reface.AppStarter.Attributes
{
    [Obsolete("不再需要此特征就可以对属性属入了")]
    [AttributeUsage(AttributeTargets.Property)]
    public class AutoCreateAttribute : Attribute
    {
    }
}
