namespace MefContrib.Web
{
    using System;
    using System.ComponentModel.Composition;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [MetadataAttribute]
    public class WebPartCreationPolicyAttribute : Attribute
    {
        public WebPartCreationPolicyAttribute(WebCreationPolicy creationPolicy)
        {
            CreationPolicy = creationPolicy;
        }

        public WebCreationPolicy CreationPolicy { get; private set; }
    }
}
