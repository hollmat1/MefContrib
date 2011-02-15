namespace MefContrib.Web
{
    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Primitives;

    /// <summary>
    /// Specifies the <see cref="Web.WebCreationPolicy"/> for a given <see cref="ComposablePart"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [MetadataAttribute]
    public class WebPartCreationPolicyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="WebPartCreationPolicyAttribute"/> object with a specified web-scoped
        /// creation policy.
        /// </summary>
        /// <param name="creationPolicy">The web-scoped creation policy to use.</param>
        public WebPartCreationPolicyAttribute(WebCreationPolicy creationPolicy)
        {
            WebCreationPolicy = creationPolicy;
        }

        /// <summary>
        /// Gets a value that indicates the web-scoped creation policy of the attributed part.
        /// </summary>
        /// <value>A <see cref="Web.WebCreationPolicy"/> value.</value>
        public WebCreationPolicy WebCreationPolicy { get; private set; }
    }
}
