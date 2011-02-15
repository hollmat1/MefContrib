namespace MefContrib.Web
{
    using System;
    using System.Linq;
    using System.ComponentModel.Composition.Primitives;

    /// <summary>
    /// Represents a catalog which wraps any other <see cref="ComposablePartCatalog"/> and returns exports based
    /// on any associated <see cref="WebPartCreationPolicyAttribute"/> that may be associated with them.
    /// </summary>
    public class WebScopedCatalog : ComposablePartCatalog
    {
        private readonly IQueryable<ComposablePartDefinition> _parts;

        public WebScopedCatalog(ComposablePartCatalog partCatalog)
        {
            if (partCatalog == null)
                throw new ArgumentNullException("partCatalog");

            var webScopedParts
                = from part in partCatalog.Parts
                    let exportDef = part.ExportDefinitions.First()
                  where exportDef.Metadata.ContainsKey("WebCreationPolicy")
                  select part;

            var nonScopedParts = partCatalog.Parts.Except(webScopedParts);

            _parts
                = webScopedParts.Select(p => new WebScopedComposablePartDefinition(p))
                    .Union(nonScopedParts)
                    .AsQueryable();
        }

        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return _parts; }
        }
    }
}
