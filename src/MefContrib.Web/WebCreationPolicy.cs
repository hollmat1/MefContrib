namespace MefContrib.Web
{
    using System.ComponentModel.Composition.Hosting;

    /// <summary>
    /// Specifies the web-scope options that control when a <see cref="CompositionContainer"/> objects creates
    /// a new instance of the associated part.
    /// </summary>
    public enum WebCreationPolicy
    {
        /// <summary>
        /// The part will be created for each HTTP request.
        /// </summary>
        Request,

        /// <summary>
        /// The part will be created for each HTTP session.
        /// </summary>
        Session
    }
}
