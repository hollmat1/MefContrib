namespace MefContrib.Web
{
    using System.ComponentModel.Composition.Primitives;

    public class WebSessionScopedComposablePart : WebScopedComposablePart
    {
        internal WebSessionScopedComposablePart(ComposablePart composablePart)
            : base(composablePart)
        { }

        public override object GetExportedValue(ExportDefinition definition)
        {
            string sessionKey = string.Format("__Session_{0}", Key);

            var obj = CurrentHttpContext.Session[sessionKey];

            if (obj != null)
                return obj;

            obj = CreatePart();

            CurrentHttpContext.Session[sessionKey] = obj;

            return obj;
        }
    }
}