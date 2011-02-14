namespace MefContrib.Web
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Primitives;
    using System.Linq;
    using System.Web;

    public abstract class WebScopedComposablePart : ComposablePart
    {
        private readonly ComposablePart _composablePart;
        private readonly ExportDefinition _exportDef;
        private readonly string _key;

        protected WebScopedComposablePart(ComposablePart composablePart)
        {
            _composablePart = composablePart;

            _exportDef = composablePart.ExportDefinitions.First();
            _key = ((string)_exportDef.Metadata["ExportTypeIdentity"]).Replace('.', '_');
        }

        public override IEnumerable<ExportDefinition> ExportDefinitions
        {
            get { return _composablePart.ExportDefinitions; }
        }

        public override IEnumerable<ImportDefinition> ImportDefinitions
        {
            get { return _composablePart.ImportDefinitions; }
        }

        protected HttpContext CurrentHttpContext
        {
            get { return HttpContext.Current; }
        }

        protected string Key
        {
            get { return _key; }
        }

        protected object CreatePart()
        {
            return _composablePart.GetExportedValue(_exportDef);
        }

        public override void SetImport(ImportDefinition definition, IEnumerable<Export> exports)
        { }
    }
}