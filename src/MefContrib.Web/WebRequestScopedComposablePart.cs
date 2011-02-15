namespace MefContrib.Web
{
    using System.ComponentModel.Composition.Primitives;

    /// <summary>
    /// Represents a composable part that is created once per HTTP request.
    /// </summary>
    public class WebRequestScopedComposablePart : WebScopedComposablePart
    {
        internal WebRequestScopedComposablePart(ComposablePart composablePart)
            : base(composablePart)
        { }

        public override object GetExportedValue(ExportDefinition definition)
        {
            string requestKey = string.Format("__Request_{0}", Key);

            var obj = CurrentHttpContext.Items[requestKey];

            if (obj != null)
                return obj;

            obj = CreatePart();

            CurrentHttpContext.Items[requestKey] = obj;

            return obj;
        }
    }
}